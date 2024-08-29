// DevTool 1.1 
// Copyright (C) 2024, Adaruru

/// <summary>
/// 
/// </summary>
public class Schema
{
    /// <summary>
    /// 
    /// </summary>
    public string SchemaId { get; set; } = "";
    public string SchemaName { get; set; } = "";
    public List<Table>? Tables { get; set; } = new List<Table>();
}