// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using System.Diagnostics;
using System.Reflection;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DbTool.Properties;
using Humanizer;
using OfficeOpenXml;
using Settings = DbTool.Properties.Settings;

public partial class DbToolForm : Form
{
    public ConnService Conn;

    public string SchemaName = "";

    private readonly ExportExcelService _exportExcelService = new ExportExcelService();

    private readonly ExportWordService _exportWordService = new ExportWordService();

    private Schema _schemaForImportDescription = new Schema();

    public DbToolForm()
    {
        InitializeComponent();
        Lan.LoadLanguage(null);
        UpdateUI();
        using (var ms = new MemoryStream(Resources.favicon))
        {
            Icon = new Icon(ms);
        }
    }
    private void connStrBoxEvent(object sender, EventArgs e)
    {
        string conn = connStrBox.Text;
        Settings.Default.ConnString = conn;
        Settings.Default.Save();
    }
    private void ModelDllPathBoxChanged(object sender, EventArgs e)
    {
        Settings.Default.dalDllPath = dalDllPathBox.Text;
        Settings.Default.Save();
    }
    private void dbContextBoxChanged(object sender, EventArgs e)
    {
        Settings.Default.dbContext = dbContextBox.Text;
        Settings.Default.Save();
    }

    private void DbTestConnClick(object sender, EventArgs e)
    {
        try
        {
            Conn = new ConnService(connStrBox.Text, SchemaName);
            var Schema = Conn.Schema;
            var query = "select DB_NAME()";
            var result = Conn.GetValueStr(query);
            if (!string.IsNullOrEmpty(result))
            {
                errorTextBox.Text = result + "資料庫順利連線";
                Schema.SchemaName = result;
                SchemaName = result;
            }
            LoadConnHiatory(connStrBox.Text);
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void DbToolFormLoad(object sender, EventArgs e)
    {
        ThemeBinding();
        LanguageBinding();
        LoadConnHiatory();
        LoadSettings();
    }
    private void LoadConnHiatory(string conn = "")
    {
        if (Settings.Default.connHistory == null)
        {
            Settings.Default.connHistory = new System.Collections.Specialized.StringCollection();
        }
        if (!string.IsNullOrWhiteSpace(conn) &&
            Settings.Default.connHistory.Contains(conn) == false)
        {
            Settings.Default.connHistory.Add(conn);
        }
        Settings.Default.Save();
        connHiatorySelect.DataSource = null;
        connHiatorySelect.DataSource = Settings.Default.connHistory;
    }

    private void ThemeBinding()
    {
        var themeDir = Path.Combine(Directory.GetCurrentDirectory(), "CustomTheme");
        if (!Directory.Exists(themeDir))
        {
            Directory.CreateDirectory(themeDir);
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] resourceNames = assembly.GetManifestResourceNames();
            var themeResources = resourceNames.Where(name => name.StartsWith("DbTool.Template.ThemeSample") && name.EndsWith(".xlsx"));
            foreach (var resourceName in themeResources)
            {
                using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
                if (resourceStream != null)
                {
                    var fileName = resourceName.Replace("DbTool.Template.ThemeSample.", "");
                    string destinationPath = Path.Combine(themeDir, fileName);
                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                }
            }
        }
        customThemeNameSelect.DataSource = Directory.GetFiles(themeDir, "*.xlsx").Select(x => Path.GetFileName(x)).ToList();
    }
    private void LanguageBinding()
    {
        var languages = new Dictionary<int, string>();
        languages = Enum.GetValues(typeof(LanguageEnum))
              .Cast<LanguageEnum>()
              .ToDictionary(e => Convert.ToInt32(e), e => e.ToString());
        languageSelect.ValueMember = "Value";
        languageSelect.DataSource = new BindingSource(languages, null);
    }
    private void LoadSettings()
    {
        //處理所有預設值
        connStrBox.Text = Settings.Default.ConnString;

        #region  ==genModel用==
        isSummary.Checked = Settings.Default.isSummary; // true  表描述
        isDisplay.Checked = Settings.Default.IsDisplay; // false 預設
        isRequired.Checked = Settings.Default.IsRequired; // false 預設
        isKey.Checked = Settings.Default.isKey; // false 預設
        #endregion  ==genModel用==

        #region  ==genScript用==
        dalDllPathBox.Text = Settings.Default.dalDllPath;
        dbContextBox.Text = Settings.Default.dbContext;
        #endregion  ==genScript用==

        #region  ==genWorld/Excel用==
        isTableDescriptionShow.Checked = Settings.Default.IsTableDescriptionShow; // true 表描述
        isTableNameAsLink.Checked = Settings.Default.isTableNameAsLink; // true 表描述

        isSortShow.Checked = Settings.Default.IsSortShow; // true 排序
        isDataTypeShow.Checked = Settings.Default.IsDataTypeShow; // true 資料型別
        isDefaultValueShow.Checked = Settings.Default.IsDefaultValueShow; // true 預設值
        isIdentityShow.Checked = Settings.Default.IsIdentityShow; // true 識別
        isPrimaryKeyShow.Checked = Settings.Default.IsPrimaryKeyShow; // true 主鍵

        isNotNullShow.Checked = Settings.Default.IsNotNullShow; // true 必填
        isLengthShow.Checked = Settings.Default.IsLengthShow; // false 長度
        isPrecisionShow.Checked = Settings.Default.IsPrecisionShow; // false 精度
        isScaleShow.Checked = Settings.Default.IsScaleShow; // false 小位數
        isColumnDescriptionShow.Checked = Settings.Default.IsColumnDescriptionShow; // true 欄描述
        #endregion  ==genWorld/Excel用==

        #region  ==genWorld用==
        isWordWithToc.Checked = Settings.Default.isWordWithToc; //true 產製word規格是否有目錄
        #endregion  ==genWorld用==
    }
    private void demoCommBtnEvent(object sender, EventArgs e)
    {
        connStrBox.Text = "Data Source=MSI;Initial Catalog=MvcCoreTraining_Amanda;user id=sa;password=ruru;";
    }

    private void downloadExcelStyleTemplate(object sender, EventArgs e)
    {
        string resourceName = "DbTool.Template.StyleTemplate.xlsx";
        Assembly assembly = Assembly.GetExecutingAssembly();
        var ThemeDir = Path.Combine(Directory.GetCurrentDirectory(), "CustomTheme");
        if (!Directory.Exists(ThemeDir))
        {
            Directory.CreateDirectory(ThemeDir);
        }
        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"CustomTheme/CustomTheme{DateTime.Now.ToString("mmss")}.xlsx");
        using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
        if (resourceStream == null)
        {
            MessageBox.Show($"Embedded resource '{resourceName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        using (FileStream fileStream = File.Create(destinationPath))
        {
            resourceStream.CopyTo(fileStream);
        }
        Process.Start(new ProcessStartInfo
        {
            FileName = destinationPath,
            UseShellExecute = true
        });
        ThemeBinding();

        errorTextBox.Text = $"{Lan.currentLan.FileGenerationCompleted}{ThemeDir}";
    }

    /// <summary>
    /// 雙擊清除錯誤訊息
    /// </summary>
    private void ErrorTextClearDoubleClick(object sender, EventArgs e)
    {
        errorTextBox.Text = "";
    }

    /// <summary>
    /// 下載範例與下載
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void exportSchemaEvent(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        var message = string.Empty;
        var isForImportTemplate = btn != null && btn == downloadTemplateBtn;
        try
        {
            errorTextBox.Text = "檔案產製中請稍後";
            if (string.IsNullOrEmpty(connStrBox.Text))
            {
                throw new Exception("請輸入連線字串");
            }

            Conn = new ConnService(connStrBox.Text, SchemaName);
            Conn.SetTable();
            Conn.SetColumn();
            if (isForImportTemplate)
            {
                message = _exportExcelService.DownloadImportDescriptionTemplate(Conn.Schema, connStrBox.Text);
            }
            else
            {
                message = _exportExcelService.ExportExcelSchema(Conn.Schema, connStrBox.Text);
            }

            errorTextBox.Text = message;
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void exportSchemaWordBtnClick(object sender, EventArgs e)
    {

        Button btn = sender as Button;
        var isPerTable = btn != null && btn == downloadSchemaWordPerTableBtn;
        try
        {
            errorTextBox.Text = "檔案產製中請稍後";
            if (string.IsNullOrEmpty(connStrBox.Text))
            {
                throw new Exception("請輸入連線字串");
            }
            Conn = new ConnService(connStrBox.Text, SchemaName);
            Conn.SetTable();
            Conn.SetColumn();

            var destinationPath = string.Empty;
            if (isPerTable)
            { destinationPath = _exportWordService.ExportWordSchemaPerTable(Conn.Schema, connStrBox.Text); }
            else
            { destinationPath = _exportWordService.ExportWordSchema(Conn.Schema, connStrBox.Text); }
            errorTextBox.Text = $"{Lan.currentLan.FileGenerationCompleted}{destinationPath}";
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void GenerateModel(object sender, EventArgs e)
    {
        errorTextBox.Text = $"產製中請稍後";
        try
        {
            Conn.SetColumn();
            var Schema = Conn.Schema;
            var modelDir = Path.Combine(Directory.GetCurrentDirectory(),
                "Model");
            if (!Directory.Exists(modelDir))
            {
                Directory.CreateDirectory(modelDir);
            }
            for (int i = 0; i < Schema?.Tables?.Count; i++)
            {
                string tableName = Schema?.Tables[i].TableName;

                if (tableName?.Pluralize() == tableName)
                {
                    tableName = tableName.Singularize();
                }

                string destinationPath = Path.Combine(modelDir, $"{tableName}.cs");

                var content = @$"
namespace {FormControl.namespaceModel};
";
                content += @$"
/// <summary>
/// {Schema?.Tables[i].TableDescription}
/// </summary>
public class {tableName}
";
                content += "{";

                for (int j = 0; j < Schema?.Tables[i].Columns?.Count; j++)
                {
                    string csharpType = Conn.MapSqlTypeToCSharpType(Schema?.Tables[i]?.Columns[j]);
                    string defaultValue = Conn.DefaultInitialValue(Schema?.Tables[i]?.Columns[j]);
                    if (isSummary.Checked)
                    {
                        content += @$"
/// <summary>
/// {Schema?.Tables[i].Columns[j].ColumnDescription}
/// </summary>";
                    }
                    ;
                    string columnName = Schema?.Tables[i]?.Columns[j]?.ColumnName ?? string.Empty;
                    string modifiedTableName = tableName?.TrimEnd('s', 'S') ?? string.Empty;

                    if ((tableName + "id".ToLower() == columnName.ToLower() || //單數化後 +id 等於欄位名稱
                        (modifiedTableName + "id").ToLower() == columnName.ToLower()) //純去尾 s 後 +id 等於欄位名稱
                        && isKey.Checked)
                    {
                        content += @"
[Key]";
                    }
                    ;
                    if (Schema?.Tables[i].Columns[j].NotNull == "Y"
                        && isRequired.Checked)
                    {
                        content += @"
[Required]";
                    }
                    ;

                    if (Schema?.Tables[i].Columns[j].Identity == "Y"
                      && isKey.Checked) //先假設 isKey.Checked model用途用於 code first
                    {
                        content += @$"
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]";
                    }
                    ;

                    if (!string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].ColumnDescription)
                        && !string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].Length)
                        && isDisplay.Checked)
                    {
                        content += @$"
[Display(Name = ""{Schema?.Tables[i].Columns[j].ColumnDescription}""), MaxLength({Schema?.Tables[i].Columns[j].Length})]";
                    }
                    ;

                    if (!string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].ColumnDescription)
                        && string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].Length)
                        && isDisplay.Checked)
                    {
                        content += @$"
[Display(Name = ""{Schema?.Tables[i].Columns[j].ColumnDescription}"")]";
                    }
                    ;

                    content += @$"
public {csharpType} {Schema?.Tables[i].Columns[j].ColumnName} {{ get; set; }} {defaultValue}
";
                }
                content += "}";
                File.WriteAllText(destinationPath, content);
            }
            errorTextBox.Text = $"{Lan.currentLan.FileGenerationCompleted}{Directory.CreateDirectory(modelDir)}";
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }

    }

    private void ImportDescriptionClick(object sender, EventArgs e)
    {
        try
        {
            errorTextBox.Text = "描述匯入中請稍後";
            if (Conn == null)
            {
                throw new Exception("請輸入連線字串");
            }
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
            openFileDialog.Title = "請選擇匯入範本";

            _schemaForImportDescription = new Schema();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
                ExcelWorksheet worksheet = package.Workbook.Worksheets["TableLists"];

                if (openFileDialog.SafeFileName != "ImportDescription.xlsx")
                {
                    throw new Exception("請勿變更檔名，並請下載匯入描述範本以編輯");
                }
                if (worksheet == null)
                {
                    throw new Exception("找不到任何工作表，請下載匯入描述範本以編輯");
                }
                if (worksheet.Cells[1, 1].Text != "Table")
                {
                    throw new Exception("請勿變更工作表欄位名稱，請下載匯入描述範本以編輯");
                }
                if (worksheet.Cells[1, 2].Text != "Description")
                {
                    throw new Exception("請勿變更工作表欄位名稱，請下載匯入描述範本以編輯");
                }
                var checkSheet = package.Workbook.Worksheets["1"];
                if (checkSheet.Cells[2, 1].Text != "Column")
                {
                    throw new Exception("請勿變更工作表欄位名稱，請下載匯入描述範本以編輯");
                }
                if (checkSheet.Cells[2, 2].Text != "Description")
                {
                    throw new Exception("請勿變更工作表欄位名稱，請下載匯入描述範本以編輯");
                }

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    Table table = new Table
                    {
                        TableName = worksheet.Cells[row, 1].Text,
                        TableDescription = worksheet.Cells[row, 2].Text
                    };
                    // Add the table to the schema
                    _schemaForImportDescription.Tables?.Add(table);
                }

                for (int i = 0; i < _schemaForImportDescription.Tables.Count; i++)
                {
                    ExcelWorksheet tableSheet = package.Workbook.Worksheets[$"{i + 1}"];
                    if (tableSheet != null)
                    {
                        var tableName = tableSheet.Cells[1, 1].Text;
                        if (tableName != _schemaForImportDescription.Tables[i].TableName)
                        {
                            errorTextBox.Text = $"tableName: {_schemaForImportDescription.Tables[i].TableName} 匯入有異常，重新下載匯入範本";
                            continue;
                        }
                        var endMinus1 = tableSheet.Dimension.End.Row - 1;//最後一筆是目錄跳回 不要 import
                        for (int row = 3; row <= endMinus1; row++)
                        {

                            Column column = new Column
                            {
                                ColumnName = tableSheet.Cells[row, 1].Text,
                                ColumnDescription = tableSheet.Cells[row, 2].Text
                            };
                            if (!string.IsNullOrWhiteSpace(column.ColumnDescription) &&
                                column.ColumnDescription != "請輸入..." &&
                                column.ColumnDescription != "Please enter...")
                            {
                                _schemaForImportDescription.Tables[i].Columns?.Add(column);
                            }
                            else if (column.ColumnDescription != "請輸入..." ||
                                     column.ColumnDescription != "Please enter...")
                            {
                                column.ColumnDescription = string.Empty;
                                _schemaForImportDescription.Tables[i].Columns?.Add(column);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception($"沒有table {_schemaForImportDescription.Tables[i].TableName}的分頁,請使用正確匯入範本");
                    }
                }
            }
            Conn.InsertTableDescription(_schemaForImportDescription);
            Conn.InsertColumnDescription(_schemaForImportDescription);
            errorTextBox.Text = "匯入完成";
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void languageSelectChanged(object sender, EventArgs e)
    {
        var language = languageSelect.SelectedValue.ToString();
        Lan.LoadLanguage(language);
        UpdateUI();
    }

    /// <summary>
    /// 選table 建 model 事件 暫留
    /// </summary>
    private void modelToolSwitchEvent(object sender, EventArgs e)
    {
        try
        {
            Conn = new ConnService(connStrBox.Text, SchemaName);
            Conn.SetTable();
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤: {es.Message}";
        }
    }

    /// <summary>
    /// 分頁切換檢查是否有資料庫連線
    /// </summary>
    private void tabControlChanged(object sender, EventArgs e)
    {
        try
        {
            if (Conn == null)
            {
                throw new Exception("請先輸入連線字串 並執行連線測試");
            }
            if (tabControl1.SelectedTab == modelToolTab)
            {
                modelToolSwitchEvent(sender, e);
            }
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"{es.Message}";
        }
    }

    private void ReloadThemeBinding(object sender, EventArgs e)
    {
        ThemeBinding();
        FormControl.CustomThemeName = customThemeNameSelect.SelectedValue?.ToString();
    }

    private void resetAllSetting(object sender, EventArgs e)
    {
        var result = MessageBox.Show("你確定要重置所有設定嗎", "確認重置", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        var keepConnStr = connStrBox.Text;
        if (result == DialogResult.Yes)
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            LoadSettings();
        }
        connStrBox.Text = keepConnStr;//重置設定不重置連線字串
    }

    private void UpdateUI()
    {
        Text = Lan.currentLan.DbTool;

        connToolTab.Text = Lan.currentLan.DatabaseConnectionTab;
        connStrLabel.Text = Lan.currentLan.ConnectionString;
        dbTestBtn.Text = Lan.currentLan.ConnectionTest;
        demoCommBtn.Text = Lan.currentLan.ShowExample;
        connHistoryLabel.Text = Lan.currentLan.connHistoryLabel;

        schmaToolTab.Text = Lan.currentLan.DatabaseSpecTab;
        downloadSchemaBtn.Text = Lan.currentLan.DownloadDatabaseSpecExcel;
        downloadSchemaWordBtn.Text = Lan.currentLan.DownloadDatabaseSpecWord;
        downloadSchemaWordPerTableBtn.Text = Lan.currentLan.DownloadDatabaseSpecWordPerTable;
        importDescriptionBtn.Text = Lan.currentLan.ImportDescription;
        downloadTemplateBtn.Text = Lan.currentLan.DownloadImportTemplate;

        modelToolTab.Text = Lan.currentLan.ModelToolTab;
        modelGenBtn.Text = Lan.currentLan.GenerateAllModels;
        nameSpaceLabel.Text = Lan.currentLan.NamespaceLabel;

        scriptGenTab.Text = Lan.currentLan.ScriptGenTab;
        genScriptFromDllBtn.Text = Lan.currentLan.GenScriptFromDllBtn;
        sourceDbConnTestBtn.Text = Lan.currentLan.ConnectionTest;
        upDataDBSchemaBtn.Text = Lan.currentLan.UpDataDBSchemaBtn;
        dalDllLabel.Text = Lan.currentLan.DalDllLabel;
        sourceDbConnStrLabel.Text = Lan.currentLan.SourceDbConnStrLabel;

        settingTab.Text = Lan.currentLan.SettingsTab;
        downloadExcelStyleTemplateBtn.Text = Lan.currentLan.DownloadExcelStyleTemplate;
        languageTab.Text = Lan.currentLan.LanguageTab;
        modelGenBtnSettingLabel.Text = Lan.currentLan.ModelGenSettings;
        connSettingLabel.Text = Lan.currentLan.ConnSettingsLabel;

        isWordWithToc.Text = Lan.currentLan.WordWithToc;
        isScaleShow.Text = Lan.currentLan.Scale;
        isPrecisionShow.Text = Lan.currentLan.Precision;
        isLengthShow.Text = Lan.currentLan.Length;
        isNotNullShow.Text = Lan.currentLan.NotNull;
        isPrimaryKeyShow.Text = Lan.currentLan.PrimaryKey;
        isIdentityShow.Text = Lan.currentLan.Identity;
        isDefaultValueShow.Text = Lan.currentLan.DefaultValue;
        isDataTypeShow.Text = Lan.currentLan.DataType;
        isSortShow.Text = Lan.currentLan.Sort;
        isColumnDescriptionShow.Text = Lan.currentLan.ColumnDescription;
        isTableNameAsLink.Text = Lan.currentLan.TableNameAsLink;
        isTableDescriptionShow.Text = Lan.currentLan.TableDescription;

        customThemelabel.Text = Lan.currentLan.CustomExcelStyle;
        dbTypeLabel.Text = Lan.currentLan.DbTypeLabel;

        isSummary.Text = Lan.currentLan.Summary;
        isDisplay.Text = Lan.currentLan.Display;
        isRequired.Text = Lan.currentLan.Required;
        isKey.Text = Lan.currentLan.Key;
        resetBtn.Text = Lan.currentLan.ResetSettings;
        clearConnHistoryBtn.Text = Lan.currentLan.clearConnHistoryBtn;
    }
    #region ==System Default Setting event==
    private void customThemeNameSelectChanged(object sender, EventArgs e)
    {
        FormControl.CustomThemeName = customThemeNameSelect.SelectedValue.ToString();
    }

    private void IsColumnDescriptionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsColumnDescriptionShow = isColumnDescriptionShow.Checked;
        FormControl.IsColumnDescriptionShow = isColumnDescriptionShow.Checked;
        Settings.Default.Save();
    }

    private void isTableNameAsLinkChanged(object sender, EventArgs e)
    {
        Settings.Default.isTableNameAsLink = isTableNameAsLink.Checked;
        FormControl.isTableNameAsLink = isTableNameAsLink.Checked;
        Settings.Default.Save();
    }


    private void IsDataTypeShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsDataTypeShow = isDataTypeShow.Checked;
        FormControl.IsDataTypeShow = isDataTypeShow.Checked;
        Settings.Default.Save();
    }

    private void IsDefaultValueShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsDefaultValueShow = isDefaultValueShow.Checked;
        FormControl.IsDefaultValueShow = isDefaultValueShow.Checked;
        Settings.Default.Save();
    }

    private void IsDisplayChanged(object sender, EventArgs e)
    {
        Settings.Default.IsDisplay = isDisplay.Checked;
        Settings.Default.Save();
    }

    private void IsIdentityShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsIdentityShow = isIdentityShow.Checked;
        FormControl.IsIdentityShow = isIdentityShow.Checked;
        Settings.Default.Save();
    }

    private void isKeyChanged(object sender, EventArgs e)
    {
        Settings.Default.isKey = isKey.Checked;
        Settings.Default.Save();
    }

    private void IsLengthShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsLengthShow = isLengthShow.Checked;
        FormControl.IsLengthShow = isLengthShow.Checked;
        Settings.Default.Save();
    }

    private void IsNotNullShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsNotNullShow = isNotNullShow.Checked;
        FormControl.IsNotNullShow = isNotNullShow.Checked;
        Settings.Default.Save();
    }

    private void IsPrecisionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsPrecisionShow = isPrecisionShow.Checked;
        FormControl.IsPrecisionShow = isPrecisionShow.Checked;
        Settings.Default.Save();
    }

    private void IsPrimaryKeyShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsPrimaryKeyShow = isPrimaryKeyShow.Checked;
        FormControl.IsPrimaryKeyShow = isPrimaryKeyShow.Checked;
        Settings.Default.Save();
    }

    private void IsRequiredChanged(object sender, EventArgs e)
    {
        Settings.Default.IsRequired = isRequired.Checked;
        Settings.Default.Save();
    }

    private void IsScaleShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsScaleShow = isScaleShow.Checked;
        FormControl.IsScaleShow = isScaleShow.Checked;
        Settings.Default.Save();
    }

    private void IsSortShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsSortShow = isSortShow.Checked;
        FormControl.IsSortShow = isSortShow.Checked;
        Settings.Default.Save();
    }

    private void isSummaryChanged(object sender, EventArgs e)
    {
        Settings.Default.isSummary = isSummary.Checked;
        Settings.Default.Save();
    }
    private void IsTableDescriptionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsTableDescriptionShow = isTableDescriptionShow.Checked;
        FormControl.IsTableDescriptionShow = isTableDescriptionShow.Checked;
        Settings.Default.Save();
    }
    private void isWordWithTocChanged(object sender, EventArgs e)
    {
        Settings.Default.isWordWithToc = isWordWithToc.Checked;
        FormControl.isWordWithToc = isWordWithToc.Checked;
        Settings.Default.Save();
    }
    private void namespaceBoxChanged(object sender, EventArgs e)
    {
        Settings.Default.isWordWithToc = isWordWithToc.Checked;
        FormControl.namespaceModel = namespaceBox.Text;
        Settings.Default.namespaceModel = namespaceBox.Text;
        Settings.Default.Save();
    }
    #endregion ==System Default Setting event==

    private void GenScriptFromDll(object sender, EventArgs e)
    {
        var dllPath = dalDllPathBox.Text;
        var dbContext = dbContextBox.Text;

        //檢查dllPath副檔名是不是dll
        if (Path.GetExtension(dllPath) != ".dll")
        {
            errorTextBox.Text = "請輸入正確的dll路徑";
            return;
        }
        if (string.IsNullOrEmpty(dbContext))
        {
            errorTextBox.Text = "請輸入DbContext";
            return;
        }
        if (!File.Exists(dllPath) || Path.GetFileName(dllPath) != "DAL.dll")
        {
            errorTextBox.Text = "找不到 DAL.dll 檔案";
            return;
        }
        var assembly = Assembly.LoadFrom(dllPath);
        var entityType = assembly.GetType(dbContext);
        if (assembly == null || entityType == null)
        {
            errorTextBox.Text = "DAL.dll 檔案找不到指定 dbContext ";
            return;
        }
        var scriptService = new ScriptService();
        var path = scriptService.GenColumnDescScriptFromDal(entityType);
        errorTextBox.Text = $"{Lan.currentLan.FileGenerationCompleted}{path}";
    }

    private void SourceDbConnTestBtnClick(object sender, EventArgs e)
    {

    }
    private void UpDataDBSchemaBtnClick(object sender, EventArgs e)
    {

    }

    private void ClearConnHistoryBtnClick(object sender, EventArgs e)
    {
        connHiatorySelect.DataSource = null;
        Settings.Default.connHistory.Clear();
        Settings.Default.Save();
    }

    private void connHiatorySelectedIndexChanged(object sender, EventArgs e)
    {
        if (connHiatorySelect.SelectedValue != null)
        {
            connStrBox.Text = connHiatorySelect.SelectedValue?.ToString() ?? string.Empty;
        }
    }
}