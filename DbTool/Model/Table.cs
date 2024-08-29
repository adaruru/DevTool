// DevTool 1.1 
// Copyright (C) 2024, Adaruru

public class Column
{
    public string ColumnDescription { get; set; } = "";
    public string ColumnName { get; set; } = "";
    public string DataType { get; set; } = "";
    public string DefaultValue { get; set; } = "";
    public string Identity { get; set; } = "";
    public string Length { get; set; } = "";
    public string NotNull { get; set; } = "";
    public string Precision { get; set; } = "";
    public string PrimaryKey { get; set; } = "";
    public string Scale { get; set; } = "";
    public string Sort { get; set; } = "";
}

public class ColumnControl
{
    public bool IsColumnDescriptionShow { get; set; }
    public bool IsDataTypeShow { get; set; }
    public bool IsDefaultValueShow { get; set; }
    public bool IsIdentityShow { get; set; }
    public bool IsLengthShow { get; set; }
    public bool IsNotNullShow { get; set; }
    public bool IsPrecisionShow { get; set; }
    public bool IsPrimaryKeyShow { get; set; }
    public bool IsScaleShow { get; set; }
    public bool IsSortShow { get; set; }
    public bool IsTableDescriptionShow { get; set; }
}

public class Table
{
    public List<Column> Columns { get; set; } = new List<Column>();
    public string TableDescription { get; set; } = "";
    public string TableName { get; set; } = "";
}