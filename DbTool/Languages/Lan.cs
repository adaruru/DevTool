// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using Newtonsoft.Json;

public class Lan
{

    public static LanguageObj currentLan = new LanguageObj();
    private static string _currentLanguage = "zh_TW";
    public static void LoadLanguage(string? languageCode = "zh_TW")
    {
        if (string.IsNullOrEmpty(languageCode))
        {
            languageCode = _currentLanguage;
        }

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Languages", $"{languageCode}.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var languageData = JsonConvert.DeserializeObject<LanguageObj>(json);
            currentLan = languageData;
        }
        else
        {
            throw new FileNotFoundException($"Language file not found: {filePath}");
        }
        _currentLanguage = languageCode;
    }
}

public class LanguageObj
{
    public string Column { get; set; }
    public string ColumnDescription { get; set; }
    public string ConnectionString { get; set; }
    public string ConnectionTest { get; set; }
    public string ConnSettingsLabel { get; set; }
    public string CustomExcelStyle { get; set; }
    public string CustomExcelStyleNotFound { get; set; }
    public string DatabaseConnectionTab { get; set; }
    public string DatabaseSchema { get; set; }
    public string DatabaseSpecTab { get; set; }
    public string DatabaseTableSchema { get; set; }
    public string DataType { get; set; }
    public string DateTimeFormat { get; set; }
    public string DbTool { get; set; }
    public string DefaultValue { get; set; }
    public string Display { get; set; }
    public string DownloadDatabaseSpecExcel { get; set; }
    public string DownloadDatabaseSpecWord { get; set; }
    public string DownloadDatabaseSpecWordPerTable { get; set; }
    public string DownloadExcelStyleTemplate { get; set; }
    public string DownloadImportTemplate { get; set; }
    public string EmbeddedNotFound { get; set; }
    public string EnterConnectionString { get; set; }
    public string FileGenerationCompleted { get; set; }
    public string GenerateAllModels { get; set; }
    public string Identity { get; set; }
    public string ImportDescription { get; set; }
    public string Key { get; set; }
    public string LanguageTab { get; set; }
    public string Length { get; set; }
    public string ModelGenSettings { get; set; }
    public string ModelToolTab { get; set; }
    public string NotNull { get; set; }
    public string Precision { get; set; }
    public string PrimaryKey { get; set; }
    public string Required { get; set; }
    public string ResetSettings { get; set; }
    public string Scale { get; set; }
    public string SettingsTab { get; set; }
    public string ShowExample { get; set; }
    public string Sort { get; set; }
    public string Summary { get; set; }
    public string Table { get; set; }
    public string TableDescription { get; set; }
    public string TableLists { get; set; }
    public string WordWithToc { get; set; }
    public string PleaseEnter { get; set; }
    public string NamespaceLabel { get; set; }
    public string ScriptGenTab { get; set; }
    public string GenScriptFromDllBtn { get; set; }
    public string UpDataDBSchemaBtn { get; set; }
    public string DalDllLabel { get; set; }
    public string SourceDbConnStrLabel { get; set; }
    public string TableNameAsLink { get; set; }
    public string connHistoryLabel { get; set; }
    public string clearConnHistoryBtn { get; set; }

    public string DbTypeLabel { get; set; }
}