// DevTool 2.1 
// Copyright (C) 2024, Adaruru

using System.Data;
using Npgsql;

public class PostgreSqlConnector : IDbConnector
{
    public IDbConnection CreateConnection(string connString)
    {
        var npgsqlConnStr = ToNpgsqlConnectionString(connString);
        return new NpgsqlConnection(npgsqlConnStr);
    }

    /// <summary>
    /// 將 postgres:// 或 postgresql:// URI 格式轉為 Npgsql 連線字串
    /// </summary>
    private static string ToNpgsqlConnectionString(string connString)
    {
        var s = connString.Trim();
        if (!s.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase) &&
            !s.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
        {
            return connString;
        }

        var uri = new Uri(connString);
        var host = uri.Host;
        var port = uri.Port == -1 ? 5432 : uri.Port;
        var database = uri.AbsolutePath.TrimStart('/');
        var user = "";
        var password = "";

        if (!string.IsNullOrEmpty(uri.UserInfo))
        {
            var colonIndex = uri.UserInfo.IndexOf(':');
            if (colonIndex >= 0)
            {
                user = Uri.UnescapeDataString(uri.UserInfo.Substring(0, colonIndex));
                password = Uri.UnescapeDataString(uri.UserInfo.Substring(colonIndex + 1));
            }
            else
            {
                user = Uri.UnescapeDataString(uri.UserInfo);
            }
        }

        var sb = new System.Text.StringBuilder();
        sb.Append($"Host={host};Port={port};Database={database};");
        if (!string.IsNullOrEmpty(user)) sb.Append($"Username={user};");
        if (!string.IsNullOrEmpty(password)) sb.Append($"Password={password};");
        return sb.ToString();
    }

    public string GetTestConnectionQuery()
    {
        return "SELECT current_database()";
    }

    public string GetTableQuery()
    {
        return @"
SELECT 
    t.table_name AS TableName,
    COALESCE(obj_description((quote_ident(t.table_schema) || '.' || quote_ident(t.table_name))::regclass), '') AS TableDescription
FROM information_schema.tables t
WHERE t.table_schema = 'public'
    AND t.table_type = 'BASE TABLE'
ORDER BY t.table_name";
    }

    public string GetColumnQuery()
    {
        return @"
SELECT 
    c.ordinal_position AS Sort,
    c.column_name AS ColumnName,
    CASE 
        WHEN c.character_maximum_length IS NOT NULL 
        THEN c.data_type || '(' || c.character_maximum_length || ')'
        ELSE c.data_type
    END AS DataType,
    COALESCE(c.column_default, '') AS DefaultValue,
    CASE WHEN c.column_default LIKE 'nextval%' THEN 'Y' ELSE '' END AS Identity,
    CASE WHEN pk.column_name IS NOT NULL THEN 'Y' ELSE '' END AS PrimaryKey,
    COALESCE(col_description((quote_ident(c.table_schema) || '.' || quote_ident(c.table_name))::regclass, c.ordinal_position), '') AS ColumnDescription,
    CASE WHEN c.is_nullable = 'NO' THEN 'Y' ELSE '' END AS NotNull,
    c.character_maximum_length AS Length,
    c.numeric_precision AS Precision,
    c.numeric_scale AS Scale,
    c.table_name AS TableName
FROM information_schema.columns c
LEFT JOIN (
    SELECT kcu.column_name, kcu.table_name
    FROM information_schema.table_constraints tc
    JOIN information_schema.key_column_usage kcu ON tc.constraint_name = kcu.constraint_name
    WHERE tc.constraint_type = 'PRIMARY KEY'
) pk ON c.table_name = pk.table_name AND c.column_name = pk.column_name
WHERE c.table_schema = 'public'
    AND c.table_name = @TableName
ORDER BY c.ordinal_position";
    }

    public string GetUpsertTableDescriptionQuery()
    {
        return "COMMENT ON TABLE @TableName IS @TableDescription";
    }

    public string GetUpsertColumnDescriptionQuery()
    {
        return "COMMENT ON COLUMN @TableName.@ColumnName IS @ColumnDescription";
    }

    public string MapDataTypeToCSharp(Column column)
    {
        if (column == null)
            return "object";

        string baseType = column.DataType.Split('(')[0].ToLower();
        string nullable = column.NotNull == "Y" ? "" : "?";

        return baseType switch
        {
            "integer" or "int" or "int4" => "int" + nullable,
            "smallint" or "int2" => "short" + nullable,
            "bigint" or "int8" => "long" + nullable,
            "decimal" or "numeric" => "decimal" + nullable,
            "real" or "float4" => "float" + nullable,
            "double precision" or "float8" => "double" + nullable,
            "varchar" or "character varying" or "text" or "char" or "character" => "string",
            "boolean" or "bool" => "bool" + nullable,
            "timestamp" or "timestamp without time zone" or "timestamp with time zone" or "date" => "DateTime" + nullable,
            "time" or "time without time zone" or "time with time zone" => "TimeSpan" + nullable,
            "uuid" => "Guid" + nullable,
            "bytea" => "byte[]",
            "json" or "jsonb" => "string",
            "serial" => "int" + nullable,
            "bigserial" => "long" + nullable,
            _ => "object"
        };
    }

    public string GetDefaultInitialValue(Column column)
    {
        if (column == null)
            return "";

        if (column.NotNull == "Y")
        {
            string baseType = column.DataType.Split('(')[0].ToLower();
            return baseType switch
            {
                "integer" or "int" or "int4" or "smallint" or "int2" or "bigint" or "int8" or "decimal" or "numeric" => "= 0;",
                "real" or "float4" => "= 0.0f;",
                "double precision" or "float8" => "= 0.0;",
                "varchar" or "character varying" or "text" or "char" => "= \"\";",
                "boolean" or "bool" => "= false;",
                "timestamp" or "date" => "= DateTime.MinValue;",
                _ => ""
            };
        }

        return "";
    }
}
