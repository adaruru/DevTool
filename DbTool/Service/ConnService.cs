using System.Data;
using System.Data.SqlClient;

public class ConnService
{
    public ConnService(string connStr)
    {
        if (string.IsNullOrEmpty(connStr))
        {
            throw new Exception("請輸入連線字串");
        }
        ConnString = connStr;
    }
    public string? ConnString;
    public DataTable GetDataTable(string query)
    {
        using SqlConnection con = new SqlConnection(ConnString);
        using SqlCommand cmd = new SqlCommand(query, con);
        con.Open();

        using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        con.Close();
        return dataTable;
    }

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

}
