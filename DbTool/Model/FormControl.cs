public static class FormControl
{
    //下載匯入欄描述 必須固定描述欄的位置
    //下載資料庫規格 依照使用者設定
    public static bool IsTableDescriptionShow { get; set; } = true;
    public static bool IsColumnDescriptionShow { get; set; } = true;
    public static bool IsSortShow { get; set; } = false;
    public static bool IsDataTypeShow { get; set; } = false;
    public static bool IsDefaultValueShow { get; set; } = false;
    public static bool IsIdentityShow { get; set; } = false;
    public static bool IsPrimaryKeyShow { get; set; } = false;
    public static bool IsNotNullShow { get; set; } = false;
    public static bool IsLengthShow { get; set; } = false;
    public static bool IsPrecisionShow { get; set; } = false;
    public static bool IsScaleShow { get; set; } = false;
}