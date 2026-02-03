// DevTool 2.1 
// Copyright (C) 2024, Adaruru

using System.Data;

public class ConnService
{
    public string? ConnString;
    public Schema Schema { get; set; }

    private readonly IDbConnector _connector;

    public ConnService(string connStr, string schemaName, DbTypeEnum dbType = DbTypeEnum.SqlServer)
    {
        if (string.IsNullOrEmpty(connStr))
        {
            throw new Exception("請輸入連線字串");
        }
        ConnString = connStr;
        Schema = new Schema();
        Schema.SchemaName = schemaName;
        _connector = DbConnectorFactory.Create(dbType);
    }

    /// <summary>
    /// 創建 model 有預設值 asign 
    /// </summary>
    public string DefaultInitialValue(Column? column)
    {
        if (column == null)
            return "";
        return _connector.GetDefaultInitialValue(column);
    }

    /// <summary>
    /// 執行資料庫查詢，取得單一值
    /// </summary>
    public string? GetValueStr(string query)
    {
        using var con = _connector.CreateConnection(ConnString);
        using var cmd = con.CreateCommand();
        cmd.CommandText = query;
        con.Open();
        var result = cmd.ExecuteScalar();
        return result?.ToString();
    }

    /// <summary>
    /// 測試連線並取得資料庫名稱
    /// </summary>
    public string? TestConnection()
    {
        var query = _connector.GetTestConnectionQuery();
        return GetValueStr(query);
    }

    /// <summary>
    /// 新增/更新欄位描述
    /// </summary>
    public void InsertColumnDescription(Schema schema)
    {
        var queryTemplate = _connector.GetUpsertColumnDescriptionQuery();
        if (string.IsNullOrEmpty(queryTemplate))
        {
            throw new NotSupportedException("此資料庫類型不支援更新欄位描述");
        }

        for (int i = 0; i < schema.Tables.Count; i++)
        {
            for (int c = 0; c < schema.Tables[i].Columns.Count; c++)
            {
                using var con = _connector.CreateConnection(ConnString);
                using var cmd = con.CreateCommand();
                cmd.CommandText = queryTemplate;
                con.Open();

                AddParameter(cmd, "@TableName", schema.Tables[i].TableName);
                AddParameter(cmd, "@ColumnName", schema.Tables[i].Columns[c].ColumnName);
                AddParameter(cmd, "@ColumnDescription", schema.Tables[i].Columns[c].ColumnDescription);

                cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// 新增/更新資料表描述
    /// </summary>
    public void InsertTableDescription(Schema schema)
    {
        var queryTemplate = _connector.GetUpsertTableDescriptionQuery();

        for (int i = 0; i < schema.Tables.Count; i++)
        {
            if (!string.IsNullOrEmpty(schema.Tables[i].TableDescription))
            {
                using var con = _connector.CreateConnection(ConnString);
                using var cmd = con.CreateCommand();
                cmd.CommandText = queryTemplate;
                con.Open();

                AddParameter(cmd, "@TableName", schema.Tables[i].TableName);
                AddParameter(cmd, "@TableDescription", schema.Tables[i].TableDescription);

                cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// 創建 model 型別轉換
    /// </summary>
    public string MapSqlTypeToCSharpType(Column? column)
    {
        if (column == null)
            return "object";
        return _connector.MapDataTypeToCSharp(column);
    }

    /// <summary>
    /// Schema Tables 寫入 Column
    /// </summary>
    public void SetColumn()
    {
        var query = _connector.GetColumnQuery();

        for (int i = 0; i < Schema.Tables.Count; i++)
        {
            using var con = _connector.CreateConnection(ConnString);
            using var cmd = con.CreateCommand();
            cmd.CommandText = query;
            con.Open();

            AddParameter(cmd, "@TableName", Schema.Tables[i].TableName);

            using var reader = cmd.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

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
    /// Schema 寫入 Tables
    /// </summary>
    public void SetTable()
    {
        var query = _connector.GetTableQuery();

        using var con = _connector.CreateConnection(ConnString);
        using var cmd = con.CreateCommand();
        cmd.CommandText = query;
        con.Open();

        using var reader = cmd.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);

        foreach (DataRow row in dataTable.Rows)
        {
            string tableName = row["TableName"]?.ToString();
            string tableDescription = row["TableDescription"]?.ToString();

            Table table = new Table
            {
                TableName = tableName,
                TableDescription = tableDescription
            };
            Schema.Tables?.Add(table);
        }
    }

    /// <summary>
    /// 統一處理參數新增（跨資料庫相容）
    /// </summary>
    private void AddParameter(IDbCommand cmd, string name, object value)
    {
        var param = cmd.CreateParameter();
        param.ParameterName = name;
        param.Value = value ?? DBNull.Value;
        cmd.Parameters.Add(param);
    }
}
