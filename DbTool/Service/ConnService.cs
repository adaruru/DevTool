using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data;
using System.Data.SqlClient;

public class ConnService
{
    public Schema Schema { get; set; }
    public string? ConnString;
    public ConnService(string connStr, string schemaName)
    {
        if (string.IsNullOrEmpty(connStr))
        {
            throw new Exception("請輸入連線字串");
        }
        ConnString = connStr;
        Schema = new Schema();
        Schema.SchemaName = schemaName;
    }

    public void SetTable()
    {
        var query = @"
SELECT st.name AS TableName,
       ISNULL(p.value, '') AS TableDescription
FROM sys.tables st
--JOIN INFORMATION_SCHEMA.TABLES ist
--     ON st.name = ist.TABLE_NAME
LEFT JOIN sys.extended_properties p 
       ON p.major_id = st.object_id
       AND p.minor_id = 0
       AND p.name = 'MS_Description'
WHERE st.name != 'sysdiagrams' 
    AND st.name !='dtproperties'
	--AND ist.TABLE_TYPE = 'BASE TABLE'  
ORDER BY st.name";

        using SqlConnection con = new SqlConnection(ConnString);
        using SqlCommand cmd = new SqlCommand(query, con);
        con.Open();

        using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        con.Close();

        foreach (DataRow row in dataTable.Rows)
        {
            string tableName = row["TableName"]?.ToString();
            string tableDescription = row["TableDescription"]?.ToString();

            // Create a new Table instance
            Table table = new Table
            {
                TableName = tableName,
                TableDescription = tableDescription
            };
            Schema.Tables?.Add(table);
        }
    }

    public void SetColumn()
    {
        for (int i = 0; i < Schema.Tables.Count; i++)
        {
            var query = @"
SELECT DISTINCT sc.column_id AS [Sort]
	,sc.name AS [ColumnName]
	,ic.DATA_TYPE + CASE 
		WHEN ISNULL(ic.CHARACTER_MAXIMUM_LENGTH, '') = ''
			THEN ''
		ELSE '(' + CAST(ic.CHARACTER_MAXIMUM_LENGTH AS VARCHAR) + ')'
		END AS [DataType]
	,ISNULL(ic.COLUMN_DEFAULT, '') AS [DefaultValue]
	,CASE sc.is_identity
		WHEN 1
			THEN 'Y'
		ELSE ''
		END AS [Identity]
	,CASE 
		WHEN ISNULL(ik.TABLE_NAME, '') <> ''
			THEN 'Y'
		ELSE ''
		END AS [PrimaryKey]
	,ISNULL(sep.value, '') AS [ColumnDescription]
	,CASE 
		WHEN sc.is_nullable = 0
			THEN 'Y'
		ELSE ''
		END AS [NotNull]
	,ic.CHARACTER_MAXIMUM_LENGTH AS [Length]
	,ic.NUMERIC_PRECISION AS [Precision]
	,ic.NUMERIC_SCALE AS [Scale]
	,st.name AS [TableName]
FROM sys.tables st
INNER JOIN sys.columns sc ON st.object_id = sc.object_id
    AND st.name = @TableName --check table
INNER JOIN INFORMATION_SCHEMA.COLUMNS ic ON ic.TABLE_NAME = st.name
	AND ic.COLUMN_NAME = sc.name
LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE ik ON ik.TABLE_NAME = ic.TABLE_NAME
	AND ik.COLUMN_NAME = ic.COLUMN_NAME
LEFT JOIN sys.extended_properties sep ON st.object_id = sep.major_id
	AND sc.column_id = sep.minor_id
	AND sep.name = 'MS_Description'
LEFT JOIN sys.extended_properties p ON p.major_id = st.object_id
	AND p.minor_id = 0
	AND p.name = 'MS_Description'
ORDER BY st.name
	,sc.column_id
	,sc.name;
";

            using SqlConnection con = new SqlConnection(ConnString);
            using SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@TableName", Schema.Tables[i].TableName);
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                Column column = new Column
                {
                    Sort = row["Sort"]?.ToString(),
                    ColumnName = row["ColumnName"]?.ToString(),
                    DataType = row["DataType"]?.ToString(),
                    DefaultValue = row["DefaultValue"]?.ToString(),
                    Identity = row["Identity"]?.ToString(),
                    PrimaryKey = row["PrimaryKey"]?.ToString(),
                    ColumnDescription = row["ColumnDescription"]?.ToString(),
                    NotNull = row["NotNull"]?.ToString(),
                    Length = row["Length"]?.ToString(),
                    Precision = row["Precision"]?.ToString(),
                    Scale = row["Scale"]?.ToString(),
                };
                Schema.Tables[i].Columns?.Add(column);
            }
        }
    }

    /// <summary>
    /// 執行資料庫連線
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public string? GetValueStr(string query)
    {
        using SqlConnection con = new SqlConnection(ConnString);
        using SqlCommand cmd = new SqlCommand(query, con);
        con.Open();
        var exe = cmd.ExecuteScalar();

        //Check if the result is not null
        if (exe != null)
        {
            return exe.ToString();
        }
        return null;
    }

    /// <summary>
    /// 創建 model 型別轉換
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public string MapSqlTypeToCSharpType(Column? column)
    {
        if (column == null) return "object";

        // Extract the base type (e.g., "nvarchar" from "nvarchar(length)")
        string baseType = column.DataType.Split('(')[0].ToLower();
        switch (baseType)
        {
            case "int":
                return "int" + (column.NotNull == "Y" ? "" : "?");
            case "decimal":
                return "decimal" + (column.NotNull == "Y" ? "" : "?");
            case "nvarchar":
            case "varchar":
            case "text":
                return "string";
            case "bit":
                return "bool" + (column.NotNull == "Y" ? "" : "?");
            case "datetime":
            case "date":
            case "time":
            case "datetime2":
                return "DateTime" + (column.NotNull == "Y" ? "" : "?");
            case "float":
                return "double" + (column.NotNull == "Y" ? "" : "?");
            case "real":
                return "float" + (column.NotNull == "Y" ? "" : "?");
            case "uniqueidentifier":
                return "Guid" + (column.NotNull == "Y" ? "" : "?");
            case "smallint":
                return "short" + (column.NotNull == "Y" ? "" : "?");
            case "tinyint":
                return "byte" + (column.NotNull == "Y" ? "" : "?");
            default:
                return "object"; // Default to object if the type is unknown
        }
    }

    /// <summary>
    /// 創建 model 有預設值 asign 
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public string DefaultInitialValue(Column? column)
    {
        if (column == null) return "";

        if (column.NotNull == "Y")
        {
            // If the column cannot be null, return a non-null default value
            switch (column.DataType.ToLower())
            {
                case "int":
                case "decimal":
                    return "= 0;";
                case "float":
                    return "= 0.0f;";
                case "double":
                    return "= 0.0;";
                case "string":
                case "nvarchar":
                case "varchar":
                case "char":
                    return "= \"\";";
                case "bool":
                    return "= false;";
                case "datetime":
                case "date":
                    return "= DateTime.MinValue;";
                default:
                    return "";
            }
        }

        // If the column can be null, return an empty string (no default value specified)
        return "";
    }

    public void InsertTableDescription(Schema Schema)
    {

        for (int i = 0; i < Schema.Tables.Count; i++)
        {
            if (!string.IsNullOrEmpty(Schema.Tables[i].TableDescription))
            {

                var str = @"
-- Check if the description already exists
IF EXISTS (
    SELECT *
    FROM sys.extended_properties
    WHERE major_id = OBJECT_ID(@TableName) 
      AND minor_id = 0
      AND name = 'MS_Description'
)
BEGIN
    -- Update the existing description
    EXEC sp_updateextendedproperty 
      @name = N'MS_Description',
      @value = @TableDescription,
      @level0type = N'SCHEMA', @level0name = 'dbo',
      @level1type = N'TABLE',  @level1name = @TableName;
END
ELSE
BEGIN
    -- Add a new description if it doesn't exist
    EXEC sp_addextendedproperty 
      @name = N'MS_Description',
      @value = @TableDescription,
      @level0type = N'SCHEMA', @level0name = 'dbo',
      @level1type = N'TABLE',  @level1name = @TableName;
END;";
                using SqlConnection con = new SqlConnection(ConnString);
                using SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                cmd.Parameters.AddWithValue("@TableName", Schema.Tables[i].TableName);
                cmd.Parameters.AddWithValue("@TableDescription", Schema.Tables[i].TableDescription);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    public void InsertColumnDescription(Schema Schema)
    {
        for (int i = 0; i < Schema.Tables.Count; i++)
        {
            for (int c = 0; c < Schema.Tables[i].Columns.Count; c++)
            {
                var str = @"
IF EXISTS (
    SELECT *
    FROM sys.extended_properties
    WHERE major_id = OBJECT_ID(@TableName)
      AND minor_id = (
          SELECT column_id
          FROM sys.columns
          WHERE object_id = OBJECT_ID(@TableName)
            AND name = @ColumnName
      )
      AND name = 'MS_Description'
)
BEGIN
    EXEC sp_updateextendedproperty 
      @name = N'MS_Description',
      @value = @ColumnDescription,
      @level0type = N'SCHEMA', @level0name = 'dbo',
      @level1type = N'TABLE',  @level1name = @TableName,
      @level2type = N'COLUMN', @level2name = @ColumnName;
END
ELSE
BEGIN
    EXEC sp_addextendedproperty 
      @name = N'MS_Description',
      @value = @ColumnDescription,
      @level0type = N'SCHEMA', @level0name = 'dbo',
      @level1type = N'TABLE',  @level1name = @TableName,
      @level2type = N'COLUMN', @level2name = @ColumnName;
END;";
                using SqlConnection con = new SqlConnection(ConnString);
                using SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                cmd.Parameters.AddWithValue("@TableName", Schema.Tables[i].TableName);
                cmd.Parameters.AddWithValue("@ColumnName", Schema.Tables[i].Columns[c].ColumnName);
                cmd.Parameters.AddWithValue("@ColumnDescription", Schema.Tables[i].Columns[c].ColumnDescription);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
