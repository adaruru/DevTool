// DevTool 2.1 
// Copyright (C) 2024, Adaruru

using System.Data;
using Npgsql;

public class PostgreSqlConnector : IDbConnector
{
    private readonly string _schema = "public";
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
        // PostgreSQL 未加引號的別名會被轉成小寫
        return $@"
select
    t.table_name as ""TableName"",
    coalesce(
        obj_description(
            (quote_ident(t.table_schema) || '.' || quote_ident(t.table_name))::regclass
        ),
        ''
    ) as ""TableDescription""
from information_schema.tables t
where 1=1
  and t.table_schema = '{_schema}'
  and t.table_type = 'BASE TABLE'
order by
    t.table_name;";
    }

    public string GetColumnQuery()
    {
        return $@"
select
    c.ordinal_position as ""Sort"",
    c.column_name as ""ColumnName"",
    case
        when c.character_maximum_length is not null
        then c.data_type || '(' || c.character_maximum_length || ')'
        else c.data_type
    end as ""DataType"",
    coalesce(c.column_default, '') as ""DefaultValue"",
    case when c.column_default like 'nextval%' then 'Y' else '' end as ""Identity"",
    case when pk.column_name is not null then 'Y' else '' end as ""PrimaryKey"",
    coalesce(
        col_description(
            (quote_ident(c.table_schema) || '.' || quote_ident(c.table_name))::regclass,
            c.ordinal_position
        ),
        ''
    ) as ""ColumnDescription"",
    case when c.is_nullable = 'NO' then 'Y' else '' end as ""NotNull"",
    c.character_maximum_length as ""Length"",
    c.numeric_precision as ""Precision"",
    c.numeric_scale as ""Scale"",
    c.table_name as ""TableName"",
    coalesce(fk.foreign_table_name, '') as ""ForeignKeyTable""
from information_schema.columns c
left join (
    select
        kcu.table_schema,
        kcu.table_name,
        kcu.column_name
    from information_schema.table_constraints tc
    join information_schema.key_column_usage kcu
        on tc.constraint_schema = kcu.constraint_schema
       and tc.constraint_name = kcu.constraint_name
    where 1=1
      and tc.constraint_type = 'PRIMARY KEY'
) pk
    on c.table_schema = pk.table_schema
   and c.table_name = pk.table_name
   and c.column_name = pk.column_name
left join (
    select
        kcu.table_schema,
        kcu.table_name,
        kcu.column_name,
        ccu.table_name || '.' || ccu.column_name as foreign_table_name
    from information_schema.table_constraints tc
    join information_schema.key_column_usage kcu
        on tc.constraint_schema = kcu.constraint_schema
       and tc.constraint_name = kcu.constraint_name
    join information_schema.constraint_column_usage ccu
        on tc.constraint_schema = ccu.constraint_schema
       and tc.constraint_name = ccu.constraint_name
    where 1=1
      and tc.constraint_type = 'FOREIGN KEY'
) fk
    on c.table_schema = fk.table_schema
   and c.table_name = fk.table_name
   and c.column_name = fk.column_name
where 1=1
  and c.table_schema = '{_schema}'
  and c.table_name =  @TableName
order by
    c.ordinal_position;";
    }

    public string GetUpsertTableDescriptionQuery(IDbCommand cmd)
    {
        var tableName = cmd.GetParamValue("@TableName");
        var description = cmd.GetParamValue("@TableDescription");
        cmd.Parameters.Clear();
        return $"COMMENT ON TABLE {_schema}.{QuoteIdentifier(tableName)} IS {QuoteLiteral(description)}";
    }

    public string GetUpsertColumnDescriptionQuery(IDbCommand cmd)
    {
        var tableName = cmd.GetParamValue("@TableName");
        var columnName = cmd.GetParamValue("@ColumnName");
        var description = cmd.GetParamValue("@ColumnDescription");
        cmd.Parameters.Clear();
        return $"COMMENT ON COLUMN {_schema}.{QuoteIdentifier(tableName)}.{QuoteIdentifier(columnName)} IS {QuoteLiteral(description)}";
    }

    private static string QuoteIdentifier(string identifier)
        => "\"" + identifier.Replace("\"", "\"\"") + "\"";

    private static string QuoteLiteral(string value)
        => "'" + value.Replace("'", "''") + "'";

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
