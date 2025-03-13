// DevTool 1.1 
// Copyright (C) 2024, Adaruru

public static class FormControl
{
    /// <summary>
    /// Excel 產製使用自製範本名稱 
    /// </summary>
    public static string CustomThemeName { get; set; }

    /// <summary>
    ///  欄描述
    /// </summary>
    public static bool IsColumnDescriptionShow { get; set; } = true;

    /// <summary>
    ///  目錄欄位名顯示連結
    /// </summary>
    public static bool isTableNameAsLink { get; set; } = true;

    /// <summary>
    /// 資料型別
    /// </summary>
    public static bool IsDataTypeShow { get; set; } = true;

    /// <summary>
    /// 預設值
    /// </summary>
    public static bool IsDefaultValueShow { get; set; } = true;

    /// <summary>
    /// 識別
    /// </summary>
    public static bool IsIdentityShow { get; set; } = true;

    /// <summary>
    /// 長度
    /// </summary>
    public static bool IsLengthShow { get; set; } = false;

    /// <summary>
    /// 必填
    /// </summary>
    public static bool IsNotNullShow { get; set; } = true;

    /// <summary>
    /// 精度
    /// </summary>
    public static bool IsPrecisionShow { get; set; } = false;

    /// <summary>
    /// 主鍵
    /// </summary>
    public static bool IsPrimaryKeyShow { get; set; } = true;

    /// <summary>
    /// 小位數
    /// </summary>
    public static bool IsScaleShow { get; set; } = false;

    /// <summary>
    ///  排序
    /// </summary>
    public static bool IsSortShow { get; set; } = true;

    /// <summary>
    ///  表描述
    /// </summary>
    public static bool IsTableDescriptionShow { get; set; } = true;
    /// <summary>
    /// Word 規格產製使否包含目錄
    /// </summary>
    public static bool isWordWithToc { get; set; } = true;
    public static string namespaceModel { get; set; }
}