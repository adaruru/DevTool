using DbTool.Properties;
using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using Properties = DbTool.Properties;


public partial class DbToolForm : Form
{
    public DbToolForm()
    {
        InitializeComponent();
    }
    public Schema Schema = new Schema();
    public Schema SchemaDescription = new Schema();
    public ConnService Conn;
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

    /// <summary>
    /// 下載範例與下載
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void downloadSchemaEvent(object sender, EventArgs e)
    {
        try
        {
            errorTextLbl.Text = "檔案產製中請稍後";
            if (string.IsNullOrEmpty(connStrBox.Text))
            {
                throw new Exception("請輸入連線字串");
            }
            Conn = new ConnService(connStrBox.Text);

            SetTable();
            SetColumn();
            Button clickedButton = sender as Button;
            var isTemplate = clickedButton != null && clickedButton == downloadTemplateBtn;

            var control = GetControl(isTemplate);//控制範本或規格 Excel 顯示欄位

            //範本或規格 Excel 檔案名稱
            string destinationPath = isTemplate ?
                Path.Combine(Directory.GetCurrentDirectory(), "ImportDescription.xlsx") :
                Path.Combine(Directory.GetCurrentDirectory(), $"{SchemaName}{DateTime.Now.ToString("yyyyMMddHHmmss")}Schema.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
       
            //use template
            string resourceName = "DbTool.Template.Schema.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
            if (resourceStream == null)
            {
                MessageBox.Show($"Embedded resource '{resourceName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using var package = new ExcelPackage(resourceStream);
            var worksheet = package.Workbook.Worksheets["TableLists"];
            for (int i = 0; i < Schema.Tables.Count; i++)
            {
                worksheet.Cells[1, 1].Value = "Table";
                worksheet.Cells[i + 2, 1].Value = Schema.Tables[i].TableName;

                if (control.IsTableDescriptionShow)
                {
                    worksheet.Cells[1, 2].Value = "Description";
                    worksheet.Cells[i + 2, 2].Value = Schema.Tables[i].TableDescription;
                }

                var tableSheet = package.Workbook.Worksheets.Copy("ColumnSample", Schema.Tables[i].TableName);
                for (int r = 0; r < Schema.Tables[i].Columns.Count(); r++)
                {
                    var column = 0;
                    tableSheet.Cells[1, 1].Value = Schema.Tables[i].TableName;
                    if (control.IsTableDescriptionShow)
                    {
                        tableSheet.Cells[1, 2].Value = Schema.Tables[i].TableDescription;
                    }

                    if (control.IsSortShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "Sort";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Sort;
                    }
                    column++;
                    tableSheet.Cells[2, column].Value = "Column";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnName;

                    if (control.IsDataTypeShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "DataType";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DataType;
                    }
                    if (control.IsDefaultValueShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "DefaultValue";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DefaultValue;
                    }
                    if (control.IsIdentityShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "Identity";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Identity;
                    }
                    if (control.IsPrimaryKeyShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "PrimaryKey";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].PrimaryKey;
                    }
                    if (control.IsNotNullShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "NotNull";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].NotNull;
                    }
                    if (control.IsLengthShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "Length";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Length;
                    }
                    if (control.IsPrecisionShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "Precision";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Precision;
                    }
                    if (control.IsScaleShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "Scale";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Scale;
                    }
                    if (control.IsColumnDescriptionShow)
                    {
                        column++;
                        tableSheet.Cells[2, column].Value = "Description";
                        tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnDescription;
                    }
                }
                tableSheet.Cells.AutoFitColumns();
                tableSheet.View.TabSelected = false;// 設置為不選取狀態
            }
            worksheet.Cells.AutoFitColumns();
            package.Workbook.Worksheets.Delete("ColumnSample");

            // 開啟時只選取TableLists
            package.Workbook.View.ActiveTab = 0;

            package.SaveAs(new FileInfo(destinationPath));
            Process.Start(new ProcessStartInfo
            {
                FileName = destinationPath,
                UseShellExecute = true
            });
            errorTextLbl.Text = $"檔案產製完成儲存於{destinationPath}";
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }

    private void SetTable()
    {
        Schema = new Schema();
        var query = @"
	SELECT st.name [TableName]
		,ISNULL(p.value, '') [TableDescription]
	FROM sys.tables st
		LEFT JOIN sys.extended_properties p ON p.major_id = st.object_id
		AND p.minor_id = 0
		AND p.name = 'MS_Description'
    WHERE st.name != 'sysdiagrams'
	ORDER BY st.name";

        var dataTable = Conn.GetDataTable(query);

        foreach (DataRow row in dataTable.Rows)
        {
            string tableName = row["TableName"]?.ToString();
            string tableDescription = row["TableDescription"]?.ToString();

            // Create a new Table instance
            Table table = new Table
            {
                TableName = tableName,
                TableDescription = tableDescription
            };
            Schema.Tables?.Add(table);
        }
    }
    private void SetColumn()
    {
        for (int i = 0; i < Schema.Tables.Count; i++)
        {
            var query = @"
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
    AND st.name = @TableName --check table
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
	,sc.name;
";

            using SqlConnection con = new SqlConnection(connStrBox.Text);
            using SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@TableName", Schema.Tables[i].TableName);
            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                Column column = new Column
                {
                    Sort = row["Sort"]?.ToString(),
                    ColumnName = row["ColumnName"]?.ToString(),
                    DataType = row["DataType"]?.ToString(),
                    DefaultValue = row["DefaultValue"]?.ToString(),
                    Identity = row["Identity"]?.ToString(),
                    PrimaryKey = row["PrimaryKey"]?.ToString(),
                    ColumnDescription = row["ColumnDescription"]?.ToString(),
                    NotNull = row["NotNull"]?.ToString(),
                    Length = row["Length"]?.ToString(),
                    Precision = row["Precision"]?.ToString(),
                    Scale = row["Scale"]?.ToString(),
                };
                Schema.Tables[i].Columns?.Add(column);
            }
        }
    }

    private ColumnControl GetControl(bool isTemplate)
    {
        if (isTemplate)
        {
            var control = new ColumnControl() //下載匯入欄描述 必須固定描述欄的位置
            {
                IsTableDescriptionShow = true,
                IsColumnDescriptionShow = true,
                IsSortShow = false,
                IsDataTypeShow = false,
                IsDefaultValueShow = false,
                IsIdentityShow = false,
                IsPrimaryKeyShow = false,
                IsNotNullShow = false,
                IsLengthShow = false,
                IsPrecisionShow = false,
                IsScaleShow = false,
            };
            return control;
        }
        else
        {
            var control = new ColumnControl() //下載資料庫規格 依照使用者設定
            {
                IsTableDescriptionShow = IsTableDescriptionShow.Checked,
                IsColumnDescriptionShow = IsColumnDescriptionShow.Checked,
                IsSortShow = IsSortShow.Checked,
                IsDataTypeShow = IsDataTypeShow.Checked,
                IsDefaultValueShow = IsDefaultValueShow.Checked,
                IsIdentityShow = IsIdentityShow.Checked,
                IsPrimaryKeyShow = IsPrimaryKeyShow.Checked,
                IsNotNullShow = IsNotNullShow.Checked,
                IsLengthShow = IsLengthShow.Checked,
                IsPrecisionShow = IsPrecisionShow.Checked,
                IsScaleShow = IsScaleShow.Checked,
            };
            return control;
        }

    }

    private void connStrBoxEvent(object sender, EventArgs e)
    {
        string conn = connStrBox.Text;
        Properties.Settings.Default.ConnString = conn;
        Properties.Settings.Default.Save();
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void DbToolForm_Load(object sender, EventArgs e)
    {
        LoadSettings();
    }

    private void resetBtn_Click(object sender, EventArgs e)
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

        isSummary.Checked = Settings.Default.isSummary; // true 表描述
        IsDisplay.Checked = Settings.Default.IsDisplay; // false 預設
        IsRequired.Checked = Settings.Default.IsRequired; // false 預設
        isKey.Checked = Settings.Default.isKey; // false 預設

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
    }



    private void errorTextEvent(object sender, EventArgs e)
    {
        errorTextLbl.Text = "";
    }

    private void dbTestEvent(object sender, EventArgs e)
    {
        try
        {
            Conn = new ConnService(connStrBox.Text);

            var query = "select DB_NAME()";
            var result = Conn.GetValueStr(query);
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
            if (Conn == null)
            {
                throw new Exception("請輸入連線字串");
            }
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
            openFileDialog.Title = "請選擇匯入範本";

            SchemaDescription = new Schema();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
                ExcelWorksheet worksheet = package.Workbook.Worksheets["TableLists"];
                if (worksheet != null)
                {
                    if (worksheet.Cells[1, 1].Text != "Table")
                    {
                        throw new Exception("請使用正確匯入範本");
                    }
                    if (worksheet.Cells[1, 2].Text != "Description")
                    {
                        throw new Exception("請使用正確匯入範本");
                    }

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        Table table = new Table
                        {
                            TableName = worksheet.Cells[row, 1].Text,
                            TableDescription = worksheet.Cells[row, 2].Text
                        };
                        // Add the table to the schema
                        SchemaDescription.Tables?.Add(table);
                    }
                }
                for (int i = 0; i < SchemaDescription.Tables.Count; i++)
                {
                    ExcelWorksheet tableSheet = package.Workbook.Worksheets[SchemaDescription.Tables[i].TableName];
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
                                SchemaDescription.Tables[i].Columns?.Add(column);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception($"沒有table {SchemaDescription.Tables[i].TableName}的分頁,請使用正確匯入範本");
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
        for (int i = 0; i < SchemaDescription.Tables.Count; i++)
        {
            if (!string.IsNullOrEmpty(SchemaDescription.Tables[i].TableDescription))
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
                cmd.Parameters.AddWithValue("@TableName", SchemaDescription.Tables[i].TableName);
                cmd.Parameters.AddWithValue("@TableDescription", SchemaDescription.Tables[i].TableDescription);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    private void InsertColumnDescription()
    {
        for (int i = 0; i < SchemaDescription.Tables.Count; i++)
        {
            for (int c = 0; c < SchemaDescription.Tables[i].Columns.Count; c++)
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
                cmd.Parameters.AddWithValue("@TableName", SchemaDescription.Tables[i].TableName);
                cmd.Parameters.AddWithValue("@ColumnName", SchemaDescription.Tables[i].Columns[c].ColumnName);
                cmd.Parameters.AddWithValue("@ColumnDescription", SchemaDescription.Tables[i].Columns[c].ColumnDescription);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Conn == null)
            {
                throw new Exception("請輸入連線字串");
            }
            if (tabControl1.SelectedTab == modelTool)
            {
                modelToolSwitchEvent(sender, e);
            }
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }


    private void modelToolSwitchEvent(object sender, EventArgs e)
    {
        try
        {
            SetTable();
        }
        catch (Exception es)
        {
            errorTextLbl.Text = $"出現其他異常錯誤:{es.Message}";
        }
    }
    private void modelGenEvent(object sender, EventArgs e)
    {
        errorTextLbl.Text = $"產製中請稍後";
        try
        {
            SetColumn();
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
                    string csharpType = Conn.MapSqlTypeToCSharpType(Schema?.Tables[i]?.Columns[j]);
                    string defaultValue = Conn.DefaultInitialValue(Schema?.Tables[i]?.Columns[j]);
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

    private void tableSelectEvent(object sender, EventArgs e)
    {
    }

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
        Settings.Default.Save();
    }

    private void IsSortShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsSortShow = IsSortShow.Checked;
        Settings.Default.Save();
    }

    private void IsDataTypeShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsDataTypeShow = IsDataTypeShow.Checked;
        Settings.Default.Save();
    }

    private void IsDefaultValueShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsDefaultValueShow = IsDefaultValueShow.Checked;
        Settings.Default.Save();
    }

    private void IsIdentityShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsIdentityShow = IsIdentityShow.Checked;
        Settings.Default.Save();
    }

    private void IsPrimaryKeyShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsPrimaryKeyShow = IsPrimaryKeyShow.Checked;
        Settings.Default.Save();
    }

    private void IsNotNullShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsNotNullShow = IsNotNullShow.Checked;
        Settings.Default.Save();
    }

    private void IsLengthShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsLengthShow = IsLengthShow.Checked;
        Settings.Default.Save();
    }

    private void IsPrecisionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsPrecisionShow = IsPrecisionShow.Checked;
        Settings.Default.Save();
    }

    private void IsScaleShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsScaleShow = IsScaleShow.Checked;
        Settings.Default.Save();
    }

    private void IsColumnDescriptionShowChanged(object sender, EventArgs e)
    {
        Settings.Default.IsColumnDescriptionShow = IsColumnDescriptionShow.Checked;
        Settings.Default.Save();
    }
}
