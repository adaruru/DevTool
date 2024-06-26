using OfficeOpenXml;
using System.Diagnostics;
using System.Reflection;
using Settings = DbTool.Properties.Settings;

public partial class DbToolForm : Form
{
    public DbToolForm()
    {
        InitializeComponent();

    }
    private readonly ExportWordService _exportWordService = new ExportWordService();
    private readonly ExportExcelService _exportExcelService = new ExportExcelService();
    private Schema _schemaForImportDescription = new Schema();
    public ConnService conn;
    public string SchemaName = "";

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
        errorTextBox.Text = $"檔案產製完成儲存於{ThemeDir}";
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
            conn = new ConnService(connStrBox.Text, SchemaName);
            conn.SetTable();
            conn.SetColumn();

            var destinationPath = string.Empty;
            if (isPerTable)
            { destinationPath = _exportWordService.ExportWordSchemaPerTable(conn.Schema, connStrBox.Text); }
            else
            { destinationPath = _exportWordService.ExportWordSchema(conn.Schema, connStrBox.Text); }
            errorTextBox.Text = $"檔案產製完成儲存於{destinationPath}";
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }
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

            conn = new ConnService(connStrBox.Text, SchemaName);
            conn.SetTable();
            conn.SetColumn();
            if (isForImportTemplate)
            {
                message = _exportExcelService.DownloadImportDescriptionTemplate(conn.Schema, connStrBox.Text);
            }
            else
            {
                message = _exportExcelService.ExportExcelSchema(conn.Schema, connStrBox.Text);
            }


            errorTextBox.Text = message;
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void SetControl(bool isTemplate)
    {
        //下載資料庫規格 依照使用者設定
        FormControl.IsTableDescriptionShow = isTableDescriptionShow.Checked;
        FormControl.IsColumnDescriptionShow = isColumnDescriptionShow.Checked;
        FormControl.IsSortShow = isSortShow.Checked;
        FormControl.IsDataTypeShow = isDataTypeShow.Checked;
        FormControl.IsDefaultValueShow = isDefaultValueShow.Checked;
        FormControl.IsIdentityShow = isIdentityShow.Checked;
        FormControl.IsPrimaryKeyShow = isPrimaryKeyShow.Checked;
        FormControl.IsNotNullShow = isNotNullShow.Checked;
        FormControl.IsLengthShow = isLengthShow.Checked;
        FormControl.IsPrecisionShow = isPrecisionShow.Checked;
        FormControl.IsScaleShow = isScaleShow.Checked;
    }

    private void connStrBoxEvent(object sender, EventArgs e)
    {
        string conn = connStrBox.Text;
        Settings.Default.ConnString = conn;
        Settings.Default.Save();
    }

    private void DbToolFormLoad(object sender, EventArgs e)
    {
        ThemeBinding();
        LoadSettings();
    }

    private void ReloadThemeBinding(object sender, EventArgs e)
    {
        ThemeBinding();
        FormControl.CustomThemeName = CustomThemeNameSelect.SelectedValue.ToString();
    }

    private void ThemeBinding()
    {
        var themeDir = Path.Combine(Directory.GetCurrentDirectory(), "CustomTheme");
        if (!Directory.Exists(themeDir))
        {
            Directory.CreateDirectory(themeDir);
        }
        CustomThemeNameSelect.DataSource = Directory.GetFiles(themeDir, "*.xlsx").Select(x => Path.GetFileName(x)).ToList();
    }

    private void resetAllSetting(object sender, EventArgs e)
    {
        var result = MessageBox.Show("你確定要重置所有設定嗎", "確認重置", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            LoadSettings();
        }
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

        isTableDescriptionShow.Checked = Settings.Default.IsTableDescriptionShow; // true 表描述

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

        /// genWorld用
        isWordWithToc.Checked = Settings.Default.isWordWithToc; //true 產製word規格是否有目錄
    }

    /// <summary>
    /// 雙擊清除錯誤訊息
    /// </summary>
    private void ErrorTextClearDoubleClick(object sender, EventArgs e)
    {
        errorTextBox.Text = "";
    }

    private void DbTestConnClick(object sender, EventArgs e)
    {
        try
        {
            conn = new ConnService(connStrBox.Text, SchemaName);
            var Schema = conn.Schema;
            var query = "select DB_NAME()";
            var result = conn.GetValueStr(query);
            if (!string.IsNullOrEmpty(result))
            {
                errorTextBox.Text = result + "資料庫順利連線";
                Schema.SchemaName = result;
                SchemaName = result;
            }
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
            if (conn == null)
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
                    throw new Exception("請下載匯入描述範本以編輯");
                }
                if (worksheet == null)
                {
                    throw new Exception("請下載匯入描述範本以編輯");
                }
                if (worksheet.Cells[1, 1].Text != "Table")
                {
                    throw new Exception("請下載匯入描述範本以編輯");
                }
                if (worksheet.Cells[1, 2].Text != "Description")
                {
                    throw new Exception("請下載匯入描述範本以編輯");
                }
                var checkSheet = package.Workbook.Worksheets["1"];
                if (checkSheet.Cells[2, 1].Text != "Column")
                {
                    throw new Exception("請下載匯入描述範本以編輯");
                }
                if (checkSheet.Cells[2, 2].Text != "Description")
                {
                    throw new Exception("請下載匯入描述範本以編輯");
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
                        for (int row = 3; row <= tableSheet.Dimension.End.Row; row++)
                        {

                            Column column = new Column
                            {
                                ColumnName = tableSheet.Cells[row, 1].Text,
                                ColumnDescription = tableSheet.Cells[row, 2].Text
                            };
                            if (!string.IsNullOrEmpty(tableSheet.Cells[row, 2].Text))
                            {
                                // Add the table to the schema
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
            conn.InsertTableDescription(_schemaForImportDescription);
            conn.InsertColumnDescription(_schemaForImportDescription);
            errorTextBox.Text = "匯入完成";
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    /// <summary>
    /// 分頁切換檢查是否有資料庫連線
    /// </summary>
    private void tabControlChanged(object sender, EventArgs e)
    {
        try
        {
            if (conn == null)
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

    /// <summary>
    /// 選table 建 model 事件 暫留
    /// </summary>
    private void modelToolSwitchEvent(object sender, EventArgs e)
    {
        try
        {
            conn = new ConnService(connStrBox.Text, SchemaName);
            conn.SetTable();
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤: {es.Message}";
        }
    }
    private void GenerateModel(object sender, EventArgs e)
    {
        errorTextBox.Text = $"產製中請稍後";
        try
        {
            conn.SetColumn();
            var Schema = conn.Schema;
            var modelDir = Path.Combine(Directory.GetCurrentDirectory(),
                "Model");
            if (!Directory.Exists(modelDir))
            {
                Directory.CreateDirectory(modelDir);
            }
            for (int i = 0; i < Schema?.Tables?.Count; i++)
            {
                string destinationPath = Path.Combine(modelDir, $"{Schema?.Tables[i].TableName}.cs");
                var content = @$"
/// <summary>
/// {Schema?.Tables[i].TableDescription}
/// </summary>
public class {Schema?.Tables[i].TableName}
";
                content += "{";

                for (int j = 0; j < Schema?.Tables[i].Columns?.Count; j++)
                {
                    string csharpType = conn.MapSqlTypeToCSharpType(Schema?.Tables[i]?.Columns[j]);
                    string defaultValue = conn.DefaultInitialValue(Schema?.Tables[i]?.Columns[j]);
                    if (isSummary.Checked)
                    {
                        content += @$"
/// <summary>
/// {Schema?.Tables[i].Columns[j].ColumnDescription}
/// </summary>";
                    };
                    string tableName = Schema?.Tables[i].TableName;
                    string columnName = Schema?.Tables[i].Columns[j].ColumnName;
                    string modifiedTableName = tableName?.TrimEnd('s', 'S') ?? string.Empty;

                    if ((modifiedTableName + "id").ToLower() ==
                        (Schema?.Tables[i].Columns[j].ColumnName).ToLower()
                        && isKey.Checked)
                    {
                        content += @"
[Key]";
                    };
                    if (Schema?.Tables[i].Columns[j].NotNull == "Y"
                        && isRequired.Checked)
                    {
                        content += @"
[Required]";
                    };
                    if (!string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].ColumnDescription)
                        && !string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].Length)
                        && isDisplay.Checked)
                    {
                        content += @$"
[Display(Name = ""{Schema?.Tables[i].Columns[j].ColumnDescription}""), MaxLength({Schema?.Tables[i].Columns[j].Length})]";
                    };
                    if (!string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].ColumnDescription)
                        && string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].Length)
                        && isDisplay.Checked)
                    {
                        content += @$"
[Display(Name = ""{Schema?.Tables[i].Columns[j].ColumnDescription}"")]";
                    };

                    content += @$"
public {csharpType} {Schema?.Tables[i].Columns[j].ColumnName} {{ get; set; }} {defaultValue}
";
                }
                content += "}";
                File.WriteAllText(destinationPath, content);
            }
            errorTextBox.Text = $"檔案產製完成儲存於{Directory.CreateDirectory(modelDir)}";
        }
        catch (Exception es)
        {
            errorTextBox.Text = $"出現其他異常錯誤:{es.Message}";
        }

    }

    #region ==System Default Setting event==
    private void isSummaryChanged(object sender, EventArgs e)
    {
        Settings.Default.isSummary = isSummary.Checked;
        Settings.Default.Save();
    }

    private void IsDisplayChanged(object sender, EventArgs e)
    {
        Settings.Default.IsDisplay = isDisplay.Checked;
        Settings.Default.Save();
    }

    private void IsRequiredChanged(object sender, EventArgs e)
    {
        Settings.Default.IsRequired = isRequired.Checked;
        Settings.Default.Save();
    }

    private void isKeyChanged(object sender, EventArgs e)
    {
        Settings.Default.isKey = isKey.Checked;
        Settings.Default.Save();
    }

    private void IsTableDescriptionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsTableDescriptionShow = isTableDescriptionShow.Checked;
        FormControl.IsTableDescriptionShow = isTableDescriptionShow.Checked;
        Settings.Default.Save();
    }

    private void IsSortShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsSortShow = isSortShow.Checked;
        FormControl.IsSortShow = isSortShow.Checked;
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

    private void IsIdentityShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsIdentityShow = isIdentityShow.Checked;
        FormControl.IsIdentityShow = isIdentityShow.Checked;
        Settings.Default.Save();
    }

    private void IsPrimaryKeyShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsPrimaryKeyShow = isPrimaryKeyShow.Checked;
        FormControl.IsPrimaryKeyShow = isPrimaryKeyShow.Checked;
        Settings.Default.Save();
    }

    private void IsNotNullShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsNotNullShow = isNotNullShow.Checked;
        FormControl.IsNotNullShow = isNotNullShow.Checked;
        Settings.Default.Save();
    }

    private void IsLengthShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsLengthShow = isLengthShow.Checked;
        FormControl.IsLengthShow = isLengthShow.Checked;
        Settings.Default.Save();
    }

    private void IsPrecisionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsPrecisionShow = isPrecisionShow.Checked;
        FormControl.IsPrecisionShow = isPrecisionShow.Checked;
        Settings.Default.Save();
    }

    private void IsScaleShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsScaleShow = isScaleShow.Checked;
        FormControl.IsScaleShow = isScaleShow.Checked;
        Settings.Default.Save();
    }

    private void IsColumnDescriptionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsColumnDescriptionShow = isColumnDescriptionShow.Checked;
        FormControl.IsColumnDescriptionShow = isColumnDescriptionShow.Checked;
        Settings.Default.Save();
    }

    private void isWordWithTocChanged(object sender, EventArgs e)
    {
        Settings.Default.isWordWithToc = isWordWithToc.Checked;
        FormControl.isWordWithToc = isWordWithToc.Checked;
        Settings.Default.Save();
    }
    #endregion ==System Default Setting event==

    private void CustomThemeNameSelectChanged(object sender, EventArgs e)
    {
        FormControl.CustomThemeName = CustomThemeNameSelect.SelectedValue.ToString();
    }
}