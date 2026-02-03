// DevTool 2.1 
// Copyright (C) 2024, Adaruru

using System.Data;
using Oracle.ManagedDataAccess.Client;

public class OracleConnector : IDbConnector
{
    public IDbConnection CreateConnection(string connString)
    {
        return new OracleConnection(connString);
    }

    public string GetTestConnectionQuery()
    {
        return "SELECT SYS_CONTEXT('USERENV', 'DB_NAME') FROM DUAL";
    }

    public string GetTableQuery()
    {
        return @"
SELECT 
    t.TABLE_NAME AS TableName,
    NVL(c.COMMENTS, '') AS TableDescription
FROM USER_TABLES t
LEFT JOIN USER_TAB_COMMENTS c ON t.TABLE_NAME = c.TABLE_NAME
ORDER BY t.TABLE_NAME";
    }

    public string GetColumnQuery()
    {
        return @"
SELECT 
    c.COLUMN_ID AS Sort,
    c.COLUMN_NAME AS ColumnName,
    CASE 
        WHEN c.DATA_TYPE IN ('VARCHAR2', 'NVARCHAR2', 'CHAR', 'NCHAR') 
        THEN c.DATA_TYPE || '(' || c.DATA_LENGTH || ')'
        WHEN c.DATA_TYPE = 'NUMBER' AND c.DATA_PRECISION IS NOT NULL 
        THEN c.DATA_TYPE || '(' || c.DATA_PRECISION || ',' || NVL(c.DATA_SCALE, 0) || ')'
        ELSE c.DATA_TYPE
    END AS DataType,
    NVL(c.DATA_DEFAULT, '') AS DefaultValue,
    '' AS Identity,
    CASE WHEN pk.COLUMN_NAME IS NOT NULL THEN 'Y' ELSE '' END AS PrimaryKey,
    NVL(cc.COMMENTS, '') AS ColumnDescription,
    CASE WHEN c.NULLABLE = 'N' THEN 'Y' ELSE '' END AS NotNull,
    c.DATA_LENGTH AS Length,
    c.DATA_PRECISION AS Precision,
    c.DATA_SCALE AS Scale,
    c.TABLE_NAME AS TableName
FROM USER_TAB_COLUMNS c
LEFT JOIN USER_COL_COMMENTS cc ON c.TABLE_NAME = cc.TABLE_NAME AND c.COLUMN_NAME = cc.COLUMN_NAME
LEFT JOIN (
    SELECT cols.TABLE_NAME, cols.COLUMN_NAME
    FROM USER_CONSTRAINTS cons
    JOIN USER_CONS_COLUMNS cols ON cons.CONSTRAINT_NAME = cols.CONSTRAINT_NAME
    WHERE cons.CONSTRAINT_TYPE = 'P'
) pk ON c.TABLE_NAME = pk.TABLE_NAME AND c.COLUMN_NAME = pk.COLUMN_NAME
WHERE c.TABLE_NAME = :TableName
ORDER BY c.COLUMN_ID";
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

        string baseType = column.DataType.Split('(')[0].ToUpper();
        string nullable = column.NotNull == "Y" ? "" : "?";

        return baseType switch
        {
            "NUMBER" => GetNumberType(column) + nullable,
            "VARCHAR2" or "NVARCHAR2" or "CHAR" or "NCHAR" or "CLOB" or "NCLOB" => "string",
            "DATE" or "TIMESTAMP" => "DateTime" + nullable,
            "BLOB" or "RAW" or "LONG RAW" => "byte[]",
            "BINARY_FLOAT" => "float" + nullable,
            "BINARY_DOUBLE" => "double" + nullable,
            _ => "object"
        };
    }

    private string GetNumberType(Column column)
    {
        // Oracle NUMBER 沒有精度時視為 decimal
        if (string.IsNullOrEmpty(column.Precision))
            return "decimal";

        int precision = int.Parse(column.Precision);
        int scale = string.IsNullOrEmpty(column.Scale) ? 0 : int.Parse(column.Scale);

        if (scale == 0)
        {
            if (precision <= 4) return "short";
            if (precision <= 9) return "int";
            if (precision <= 18) return "long";
        }

        return "decimal";
    }

    public string GetDefaultInitialValue(Column column)
    {
        if (column == null)
            return "";

        if (column.NotNull == "Y")
        {
            string baseType = column.DataType.Split('(')[0].ToUpper();
            return baseType switch
            {
                "NUMBER" => "= 0;",
                "VARCHAR2" or "NVARCHAR2" or "CHAR" or "NCHAR" or "CLOB" => "= \"\";",
                "DATE" or "TIMESTAMP" => "= DateTime.MinValue;",
                "BINARY_FLOAT" => "= 0.0f;",
                "BINARY_DOUBLE" => "= 0.0;",
                _ => ""
            };
        }

        return "";
    }
}
