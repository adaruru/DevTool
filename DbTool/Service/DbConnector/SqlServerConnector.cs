// DevTool 2.1 
// Copyright (C) 2024, Adaruru

using System.Data;
using System.Data.SqlClient;

public class SqlServerConnector : IDbConnector
{
    public IDbConnection CreateConnection(string connString)
    {
        return new SqlConnection(connString);
    }

    public string GetTestConnectionQuery()
    {
        return "SELECT DB_NAME()";
    }

    public string GetTableQuery()
    {
        return @"
SELECT st.name AS TableName,
       ISNULL(p.value, '') AS TableDescription
FROM sys.tables st
LEFT JOIN sys.extended_properties p 
       ON p.major_id = st.object_id
       AND p.minor_id = 0
       AND p.name = 'MS_Description'
WHERE st.name != 'sysdiagrams' 
    AND st.name != 'dtproperties'
ORDER BY st.name";
    }

    public string GetColumnQuery()
    {
        return @"
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
    AND st.name = @TableName
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
    ,sc.name";
    }

    public string GetUpsertTableDescriptionQuery()
    {
        return @"
IF EXISTS (
    SELECT *
    FROM sys.extended_properties
    WHERE major_id = OBJECT_ID(@TableName) 
      AND minor_id = 0
      AND name = 'MS_Description'
)
BEGIN
    EXEC sp_updateextendedproperty 
      @name = N'MS_Description',
      @value = @TableDescription,
      @level0type = N'SCHEMA', @level0name = 'dbo',
      @level1type = N'TABLE',  @level1name = @TableName;
END
ELSE
BEGIN
    EXEC sp_addextendedproperty 
      @name = N'MS_Description',
      @value = @TableDescription,
      @level0type = N'SCHEMA', @level0name = 'dbo',
      @level1type = N'TABLE',  @level1name = @TableName;
END;";
    }

    public string GetUpsertColumnDescriptionQuery()
    {
        return @"
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
    }

    public string MapDataTypeToCSharp(Column column)
    {
        if (column == null)
            return "object";

        string baseType = column.DataType.Split('(')[0].ToLower();
        string nullable = column.NotNull == "Y" ? "" : "?";

        return baseType switch
        {
            "int" => "int" + nullable,
            "decimal" or "money" or "smallmoney" => "decimal" + nullable,
            "nvarchar" or "varchar" or "text" or "nchar" or "char" or "xml" => "string",
            "bit" => "bool" + nullable,
            "datetime" or "date" or "datetime2" or "smalldatetime" => "DateTime" + nullable,
            "time" => "TimeSpan" + nullable,
            "float" => "double" + nullable,
            "real" => "float" + nullable,
            "uniqueidentifier" => "Guid" + nullable,
            "smallint" => "short" + nullable,
            "tinyint" => "byte" + nullable,
            "bigint" => "long" + nullable,
            "binary" or "varbinary" or "image" => "byte[]",
            _ => "object"
        };
    }

    public string GetDefaultInitialValue(Column column)
    {
        if (column == null)
            return "";

        if (column.NotNull == "Y")
        {
            return column.DataType.ToLower() switch
            {
                "int" or "decimal" => "= 0;",
                "float" => "= 0.0f;",
                "double" => "= 0.0;",
                "string" or "nvarchar" or "varchar" or "char" => "= \"\";",
                "bool" => "= false;",
                "datetime" or "date" => "= DateTime.MinValue;",
                _ => ""
            };
        }

        return "";
    }
}
