// DevTool 2.1 
// Copyright (C) 2024, Adaruru

using System.Data;
using MySql.Data.MySqlClient;

public class MySqlDbConnector : IDbConnector
{
    public IDbConnection CreateConnection(string connString)
    {
        return new MySqlConnection(connString);
    }

    public string GetTestConnectionQuery()
    {
        return "SELECT DATABASE()";
    }

    public string GetTableQuery()
    {
        return @"
SELECT 
    t.TABLE_NAME AS TableName,
    IFNULL(t.TABLE_COMMENT, '') AS TableDescription
FROM INFORMATION_SCHEMA.TABLES t
WHERE t.TABLE_SCHEMA = DATABASE()
    AND t.TABLE_TYPE = 'BASE TABLE'
ORDER BY t.TABLE_NAME";
    }

    public string GetColumnQuery()
    {
        return @"
SELECT 
    c.ORDINAL_POSITION AS Sort,
    c.COLUMN_NAME AS ColumnName,
    CASE 
        WHEN c.CHARACTER_MAXIMUM_LENGTH IS NOT NULL 
        THEN CONCAT(c.DATA_TYPE, '(', c.CHARACTER_MAXIMUM_LENGTH, ')')
        ELSE c.DATA_TYPE
    END AS DataType,
    IFNULL(c.COLUMN_DEFAULT, '') AS DefaultValue,
    CASE WHEN c.EXTRA LIKE '%auto_increment%' THEN 'Y' ELSE '' END AS `Identity`,
    CASE WHEN c.COLUMN_KEY = 'PRI' THEN 'Y' ELSE '' END AS PrimaryKey,
    IFNULL(c.COLUMN_COMMENT, '') AS ColumnDescription,
    CASE WHEN c.IS_NULLABLE = 'NO' THEN 'Y' ELSE '' END AS NotNull,
    c.CHARACTER_MAXIMUM_LENGTH AS `Length`,
    c.NUMERIC_PRECISION AS `Precision`,
    c.NUMERIC_SCALE AS `Scale`,
    c.TABLE_NAME AS TableName
FROM INFORMATION_SCHEMA.COLUMNS c
WHERE c.TABLE_SCHEMA = DATABASE()
    AND c.TABLE_NAME = @TableName
ORDER BY c.ORDINAL_POSITION";
    }

    public string GetUpsertTableDescriptionQuery()
    {
        return @"
ALTER TABLE @TableName COMMENT = @TableDescription";
    }

    public string GetUpsertColumnDescriptionQuery()
    {
        // MySQL 需要重新定義欄位來更新 COMMENT，這比較複雜
        // 暫時返回空字串，需要另外處理
        return "";
    }

    public string MapDataTypeToCSharp(Column column)
    {
        if (column == null)
            return "object";

        string baseType = column.DataType.Split('(')[0].ToLower();
        string nullable = column.NotNull == "Y" ? "" : "?";

        return baseType switch
        {
            "int" or "integer" => "int" + nullable,
            "decimal" or "numeric" => "decimal" + nullable,
            "varchar" or "text" or "char" or "longtext" or "mediumtext" or "tinytext" => "string",
            "tinyint" when column.Length == "1" => "bool" + nullable,
            "tinyint" => "byte" + nullable,
            "bit" => "bool" + nullable,
            "datetime" or "date" or "timestamp" => "DateTime" + nullable,
            "time" => "TimeSpan" + nullable,
            "float" => "float" + nullable,
            "double" => "double" + nullable,
            "smallint" => "short" + nullable,
            "bigint" => "long" + nullable,
            "binary" or "varbinary" or "blob" or "longblob" => "byte[]",
            "json" => "string",
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
                "int" or "integer" or "decimal" or "numeric" => "= 0;",
                "float" => "= 0.0f;",
                "double" => "= 0.0;",
                "varchar" or "text" or "char" => "= \"\";",
                "tinyint" when column.Length == "1" => "= false;",
                "bit" => "= false;",
                "datetime" or "date" or "timestamp" => "= DateTime.MinValue;",
                _ => ""
            };
        }

        return "";
    }
}
