using DbTool.Properties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using OfficeOpenXml;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using Properties = DbTool.Properties;
using Settings = DbTool.Properties.Settings;
using DocumentFormat.OpenXml.Spreadsheet;

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

    /// 保留資源範本 單純下載 測試用
    private void downloadTemplateEvent(object sender, EventArgs e)
    {
        string resourceName = "DbTool.Template.Schema.xlsx";
        Assembly assembly = Assembly.GetExecutingAssembly();
        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), "Schema.xlsx");
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
    }

    private void downloadSchemaWordBtnClick(object sender, EventArgs e)
    {

        Button btn = sender as Button;
        var isPerTable = btn != null && btn == downloadSchemaWordPerTableBtn;
        try
        {
            errorTextLbl.Text = "檔案產製中請稍後";
            if (string.IsNullOrEmpty(connStrBox.Text))
            {
                throw new Exception("請輸入連線字串");
            }
            conn = new ConnService(connStrBox.Text, SchemaName);
            conn.SetTable();
            conn.SetColumn();
            SetControl(isTemplate: false);

            var destinationPath = string.Empty;
            if (isPerTable)
            { destinationPath = _exportWordService.ExportWordSchemaPerTable(conn.Schema, connStrBox.Text); }
            else
            { destinationPath = _exportWordService.ExportWordSchema(conn.Schema, connStrBox.Text); }
            errorTextLbl.Text = $"檔案產製完成儲存於{destinationPath}";
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    /// <summary>
    /// 下載範例與下載
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void downloadSchemaEvent(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        var isTemplate = btn != null && btn == downloadTemplateBtn;
        try
        {
            errorTextLbl.Text = "檔案產製中請稍後";
            if (string.IsNullOrEmpty(connStrBox.Text))
            {
                throw new Exception("請輸入連線字串");
            }

            conn = new ConnService(connStrBox.Text, SchemaName);
            conn.SetTable();
            conn.SetColumn();
            SetControl(isTemplate);//控制範本或規格 Excel 顯示欄位

            var message = _exportExcelService.ExportExcelSchema(conn.Schema, connStrBox.Text, isTemplate);

            errorTextLbl.Text = message;
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"出現其他異常錯誤:{es.Message}";
        }

        if (isTemplate)
            SetControl(false);//還原 control 來自使用者設定
    }

    private void SetControl(bool isTemplate)
    {
        if (isTemplate)
        {
            //下載匯入欄描述 必須固定描述欄的位置
            FormControl.IsTableDescriptionShow = true;
            FormControl.IsColumnDescriptionShow = true;
            FormControl.IsSortShow = false;
            FormControl.IsDataTypeShow = false;
            FormControl.IsDefaultValueShow = false;
            FormControl.IsIdentityShow = false;
            FormControl.IsPrimaryKeyShow = false;
            FormControl.IsNotNullShow = false;
            FormControl.IsLengthShow = false;
            FormControl.IsPrecisionShow = false;
            FormControl.IsScaleShow = false;
        }
        else
        {
            //下載資料庫規格 依照使用者設定
            FormControl.IsTableDescriptionShow = IsTableDescriptionShow.Checked;
            FormControl.IsColumnDescriptionShow = IsColumnDescriptionShow.Checked;
            FormControl.IsSortShow = IsSortShow.Checked;
            FormControl.IsDataTypeShow = IsDataTypeShow.Checked;
            FormControl.IsDefaultValueShow = IsDefaultValueShow.Checked;
            FormControl.IsIdentityShow = IsIdentityShow.Checked;
            FormControl.IsPrimaryKeyShow = IsPrimaryKeyShow.Checked;
            FormControl.IsNotNullShow = IsNotNullShow.Checked;
            FormControl.IsLengthShow = IsLengthShow.Checked;
            FormControl.IsPrecisionShow = IsPrecisionShow.Checked;
            FormControl.IsScaleShow = IsScaleShow.Checked;
        }
    }

    private void connStrBoxEvent(object sender, EventArgs e)
    {
        string conn = connStrBox.Text;
        Settings.Default.ConnString = conn;
        Settings.Default.Save();
    }

    private void DbToolFormLoad(object sender, EventArgs e)
    {
        LoadSettings();
    }

    private void resetBtnClick(object sender, EventArgs e)
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
        IsDisplay.Checked = Settings.Default.IsDisplay; // false 預設
        IsRequired.Checked = Settings.Default.IsRequired; // false 預設
        isKey.Checked = Settings.Default.isKey; // false 預設
        #endregion  ==genModel用==

        IsTableDescriptionShow.Checked = Settings.Default.IsTableDescriptionShow; // true 表描述

        IsSortShow.Checked = Settings.Default.IsSortShow; // true 排序
        IsDataTypeShow.Checked = Settings.Default.IsDataTypeShow; // true 資料型別
        IsDefaultValueShow.Checked = Settings.Default.IsDefaultValueShow; // true 預設值
        IsIdentityShow.Checked = Settings.Default.IsIdentityShow; // true 識別
        IsPrimaryKeyShow.Checked = Settings.Default.IsPrimaryKeyShow; // true 主鍵

        IsNotNullShow.Checked = Settings.Default.IsNotNullShow; // true 必填
        IsLengthShow.Checked = Settings.Default.IsLengthShow; // false 長度
        IsPrecisionShow.Checked = Settings.Default.IsPrecisionShow; // false 精度
        IsScaleShow.Checked = Settings.Default.IsScaleShow; // false 小位數
        IsColumnDescriptionShow.Checked = Settings.Default.IsColumnDescriptionShow; // true 欄描述

        /// genWorld用
        isWordWithToc.Checked = Settings.Default.isWordWithToc; //true 產製word規格是否有目錄
    }

    /// <summary>
    /// 雙擊清除錯誤訊息
    /// </summary>
    private void errorTextDoubleClick(object sender, EventArgs e)
    {
        errorTextLbl.Text = "";
    }

    private void dbTestEvent(object sender, EventArgs e)
    {
        try
        {
            conn = new ConnService(connStrBox.Text, SchemaName);
            var Schema = conn.Schema;
            var query = "select DB_NAME()";
            var result = conn.GetValueStr(query);
            if (!string.IsNullOrEmpty(result))
            {
                errorTextLbl.Text = result + "資料庫順利連線";
                Schema.SchemaName = result;
                SchemaName = result;
            }
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void ImportDescriptionEvent(object sender, EventArgs e)
    {
        try
        {
            errorTextLbl.Text = "描述匯入中請稍後";
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
                var checkSheet = package.Workbook.Worksheets[worksheet.Cells[2, 1].Text];
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
                    ExcelWorksheet tableSheet = package.Workbook.Worksheets[_schemaForImportDescription.Tables[i].TableName];
                    if (tableSheet != null)
                    {
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
            InsertTableDescription();
            InsertColumnDescription();
            errorTextLbl.Text = "匯入完成";
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void InsertTableDescription()
    {
        for (int i = 0; i < _schemaForImportDescription.Tables.Count; i++)
        {
            if (!string.IsNullOrEmpty(_schemaForImportDescription.Tables[i].TableDescription))
            {

                var str = @"
-- Check if the description already exists
IF EXISTS (
    SELECT *
    FROM sys.extended_properties
    WHERE major_id = OBJECT_ID(@TableName) 
      AND minor_id = 0
      AND name = 'MS_Description'
)
BEGIN
    -- Update the existing description
    EXEC sp_updateextendedproperty 
      @name = N'MS_Description',
      @value = @TableDescription,
      @level0type = N'SCHEMA', @level0name = 'dbo',
      @level1type = N'TABLE',  @level1name = @TableName;
END
ELSE
BEGIN
    -- Add a new description if it doesn't exist
    EXEC sp_addextendedproperty 
      @name = N'MS_Description',
      @value = @TableDescription,
      @level0type = N'SCHEMA', @level0name = 'dbo',
      @level1type = N'TABLE',  @level1name = @TableName;
END;";
                using SqlConnection con = new SqlConnection(connStrBox.Text);
                using SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                cmd.Parameters.AddWithValue("@TableName", _schemaForImportDescription.Tables[i].TableName);
                cmd.Parameters.AddWithValue("@TableDescription", _schemaForImportDescription.Tables[i].TableDescription);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    private void InsertColumnDescription()
    {
        for (int i = 0; i < _schemaForImportDescription.Tables.Count; i++)
        {
            for (int c = 0; c < _schemaForImportDescription.Tables[i].Columns.Count; c++)
            {
                var str = @"
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
                using SqlConnection con = new SqlConnection(connStrBox.Text);
                using SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                cmd.Parameters.AddWithValue("@TableName", _schemaForImportDescription.Tables[i].TableName);
                cmd.Parameters.AddWithValue("@ColumnName", _schemaForImportDescription.Tables[i].Columns[c].ColumnName);
                cmd.Parameters.AddWithValue("@ColumnDescription", _schemaForImportDescription.Tables[i].Columns[c].ColumnDescription);
                cmd.ExecuteNonQuery();
                con.Close();
            }
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
            if (tabControl1.SelectedTab == modelTool)
            {
                modelToolSwitchEvent(sender, e);
            }
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"{es.Message}";
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
            errorTextLbl.Text = $"出現其他異常錯誤: {es.Message}";
        }
    }
    private void modelGenEvent(object sender, EventArgs e)
    {
        errorTextLbl.Text = $"產製中請稍後";
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
                        && IsRequired.Checked)
                    {
                        content += @"
[Required]";
                    };
                    if (!string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].ColumnDescription)
                        && !string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].Length)
                        && IsDisplay.Checked)
                    {
                        content += @$"
[Display(Name = ""{Schema?.Tables[i].Columns[j].ColumnDescription}""), MaxLength({Schema?.Tables[i].Columns[j].Length})]";
                    };
                    if (!string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].ColumnDescription)
                        && string.IsNullOrEmpty(Schema?.Tables[i].Columns[j].Length)
                        && IsDisplay.Checked)
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
            errorTextLbl.Text = $"檔案產製完成儲存於{Directory.CreateDirectory(modelDir)}";
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"出現其他異常錯誤:{es.Message}";
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
        Settings.Default.IsDisplay = IsDisplay.Checked;
        Settings.Default.Save();
    }

    private void IsRequiredChanged(object sender, EventArgs e)
    {
        Settings.Default.IsRequired = IsRequired.Checked;
        Settings.Default.Save();
    }

    private void isKeyChanged(object sender, EventArgs e)
    {
        Settings.Default.isKey = isKey.Checked;
        Settings.Default.Save();
    }

    private void IsTableDescriptionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsTableDescriptionShow = IsTableDescriptionShow.Checked;
        FormControl.IsTableDescriptionShow = IsTableDescriptionShow.Checked;
        Settings.Default.Save();
    }

    private void IsSortShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsSortShow = IsSortShow.Checked;
        FormControl.IsSortShow = IsSortShow.Checked;
        Settings.Default.Save();
    }

    private void IsDataTypeShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsDataTypeShow = IsDataTypeShow.Checked;
        FormControl.IsDataTypeShow = IsDataTypeShow.Checked;
        Settings.Default.Save();
    }

    private void IsDefaultValueShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsDefaultValueShow = IsDefaultValueShow.Checked;
        FormControl.IsDefaultValueShow = IsDefaultValueShow.Checked;
        Settings.Default.Save();
    }

    private void IsIdentityShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsIdentityShow = IsIdentityShow.Checked;
        FormControl.IsIdentityShow = IsIdentityShow.Checked;
        Settings.Default.Save();
    }

    private void IsPrimaryKeyShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsPrimaryKeyShow = IsPrimaryKeyShow.Checked;
        FormControl.IsPrimaryKeyShow = IsPrimaryKeyShow.Checked;
        Settings.Default.Save();
    }

    private void IsNotNullShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsNotNullShow = IsNotNullShow.Checked;
        FormControl.IsNotNullShow = IsNotNullShow.Checked;
        Settings.Default.Save();
    }

    private void IsLengthShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsLengthShow = IsLengthShow.Checked;
        FormControl.IsLengthShow = IsLengthShow.Checked;
        Settings.Default.Save();
    }

    private void IsPrecisionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsPrecisionShow = IsPrecisionShow.Checked;
        FormControl.IsPrecisionShow = IsPrecisionShow.Checked;
        Settings.Default.Save();
    }

    private void IsScaleShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsScaleShow = IsScaleShow.Checked;
        FormControl.IsScaleShow = IsScaleShow.Checked;
        Settings.Default.Save();
    }

    private void IsColumnDescriptionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsColumnDescriptionShow = IsColumnDescriptionShow.Checked;
        FormControl.IsColumnDescriptionShow = IsColumnDescriptionShow.Checked;
        Settings.Default.Save();
    }

    private void isWordWithTocChanged(object sender, EventArgs e)
    {
        Settings.Default.isWordWithToc = isWordWithToc.Checked;
        FormControl.isWordWithToc = isWordWithToc.Checked;
        Settings.Default.Save();
    }
    #endregion ==System Default Setting event==
}