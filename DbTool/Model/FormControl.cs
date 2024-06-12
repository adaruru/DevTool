public static class FormControl
{
    /// <summary>
    ///  表描述
    /// </summary>
    public static bool IsTableDescriptionShow { get; set; } = true;
    /// <summary>
    ///  欄描述
    /// </summary>
    public static bool IsColumnDescriptionShow { get; set; } = true;
    /// <summary>
    ///  排序
    /// </summary>
    public static bool IsSortShow { get; set; } = true;
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
    /// 主鍵
    /// </summary>
    public static bool IsPrimaryKeyShow { get; set; } = true;
    /// <summary>
    /// 必填
    /// </summary>
    public static bool IsNotNullShow { get; set; } = true;
    /// <summary>
    /// 長度
    /// </summary>
    public static bool IsLengthShow { get; set; } = false;
    /// <summary>
    /// 精度
    /// </summary>
    public static bool IsPrecisionShow { get; set; } = false;
    /// <summary>
    /// 小位數
    /// </summary>
    public static bool IsScaleShow { get; set; } = false;
}