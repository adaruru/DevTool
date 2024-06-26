using Properties = DbTool.Properties;

partial class DbToolForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        demoCommBtn = new Button();
        downloadSchemaBtn = new Button();
        connStrBox = new TextBox();
        connStrLabel = new Label();
        dbTestBtn = new Button();
        tabControl1 = new TabControl();
        connToolTab = new TabPage();
        schmaToolTab = new TabPage();
        downloadTemplateBtn = new Button();
        downloadSchemaWordPerTableBtn = new Button();
        downloadSchemaWordBtn = new Button();
        ImportDescription = new Button();
        modelToolTab = new TabPage();
        modelGenBtn = new Button();
        settingTab = new TabPage();
        CustomThemelabel = new Label();
        CustomThemeNameSelect = new ComboBox();
        modelGenBtnSettingLabel = new Label();
        connSettingLabel = new Label();
        isWordWithToc = new CheckBox();
        IsScaleShow = new CheckBox();
        IsPrecisionShow = new CheckBox();
        IsLengthShow = new CheckBox();
        IsNotNullShow = new CheckBox();
        IsPrimaryKeyShow = new CheckBox();
        IsIdentityShow = new CheckBox();
        IsDefaultValueShow = new CheckBox();
        IsDataTypeShow = new CheckBox();
        IsSortShow = new CheckBox();
        IsColumnDescriptionShow = new CheckBox();
        IsTableDescriptionShow = new CheckBox();
        isSummary = new CheckBox();
        isKey = new CheckBox();
        IsRequired = new CheckBox();
        IsDisplay = new CheckBox();
        resetBtn = new Button();
        downloadExcelStyleTemplateBtn = new Button();
        errorTextLbl = new TextBox();
        tabControl1.SuspendLayout();
        connToolTab.SuspendLayout();
        schmaToolTab.SuspendLayout();
        modelToolTab.SuspendLayout();
        settingTab.SuspendLayout();
        SuspendLayout();
        // 
        // demoCommBtn
        // 
        demoCommBtn.Location = new Point(135, 175);
        demoCommBtn.Margin = new Padding(2);
        demoCommBtn.Name = "demoCommBtn";
        demoCommBtn.Size = new Size(92, 28);
        demoCommBtn.TabIndex = 0;
        demoCommBtn.Text = "顯示範例";
        demoCommBtn.UseVisualStyleBackColor = true;
        demoCommBtn.Click += demoCommBtnEvent;
        // 
        // downloadSchemaBtn
        // 
        downloadSchemaBtn.Location = new Point(20, 17);
        downloadSchemaBtn.Margin = new Padding(2);
        downloadSchemaBtn.Name = "downloadSchemaBtn";
        downloadSchemaBtn.Size = new Size(170, 28);
        downloadSchemaBtn.TabIndex = 1;
        downloadSchemaBtn.Text = "下載資料庫規格 Excel";
        downloadSchemaBtn.UseVisualStyleBackColor = true;
        downloadSchemaBtn.Click += exportSchemaEvent;
        // 
        // connStrBox
        // 
        connStrBox.Location = new Point(24, 46);
        connStrBox.Margin = new Padding(2);
        connStrBox.Multiline = true;
        connStrBox.Name = "connStrBox";
        connStrBox.Size = new Size(434, 112);
        connStrBox.TabIndex = 2;
        connStrBox.Text = "Data Source=MSI;Initial Catalog=MvcCoreTraining_Amanda;user id=sa;password=ruru";
        connStrBox.TextChanged += connStrBoxEvent;
        // 
        // connStrLabel
        // 
        connStrLabel.AutoSize = true;
        connStrLabel.Location = new Point(20, 15);
        connStrLabel.Margin = new Padding(2, 0, 2, 0);
        connStrLabel.Name = "connStrLabel";
        connStrLabel.Size = new Size(69, 19);
        connStrLabel.TabIndex = 3;
        connStrLabel.Text = "連線字串";
        // 
        // dbTestBtn
        // 
        dbTestBtn.Location = new Point(24, 175);
        dbTestBtn.Margin = new Padding(2);
        dbTestBtn.Name = "dbTestBtn";
        dbTestBtn.Size = new Size(92, 28);
        dbTestBtn.TabIndex = 6;
        dbTestBtn.Text = "連線測試";
        dbTestBtn.UseVisualStyleBackColor = true;
        dbTestBtn.Click += dbTestEvent;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(connToolTab);
        tabControl1.Controls.Add(schmaToolTab);
        tabControl1.Controls.Add(modelToolTab);
        tabControl1.Controls.Add(settingTab);
        tabControl1.Location = new Point(0, 2);
        tabControl1.Margin = new Padding(2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(536, 312);
        tabControl1.TabIndex = 7;
        tabControl1.SelectedIndexChanged += tabControlChanged;
        // 
        // connToolTab
        // 
        connToolTab.Controls.Add(connStrLabel);
        connToolTab.Controls.Add(dbTestBtn);
        connToolTab.Controls.Add(connStrBox);
        connToolTab.Controls.Add(demoCommBtn);
        connToolTab.Location = new Point(4, 28);
        connToolTab.Margin = new Padding(2);
        connToolTab.Name = "connToolTab";
        connToolTab.Padding = new Padding(2);
        connToolTab.Size = new Size(528, 280);
        connToolTab.TabIndex = 0;
        connToolTab.Text = "資料庫連線";
        connToolTab.UseVisualStyleBackColor = true;
        // 
        // schmaToolTab
        // 
        schmaToolTab.Controls.Add(downloadTemplateBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordPerTableBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordBtn);
        schmaToolTab.Controls.Add(ImportDescription);
        schmaToolTab.Controls.Add(downloadSchemaBtn);
        schmaToolTab.Location = new Point(4, 28);
        schmaToolTab.Margin = new Padding(2);
        schmaToolTab.Name = "schmaToolTab";
        schmaToolTab.Padding = new Padding(2);
        schmaToolTab.Size = new Size(528, 280);
        schmaToolTab.TabIndex = 1;
        schmaToolTab.Text = "資料庫規格";
        schmaToolTab.UseVisualStyleBackColor = true;
        // 
        // downloadTemplateBtn
        // 
        downloadTemplateBtn.Location = new Point(21, 163);
        downloadTemplateBtn.Margin = new Padding(2);
        downloadTemplateBtn.Name = "downloadTemplateBtn";
        downloadTemplateBtn.Size = new Size(155, 28);
        downloadTemplateBtn.TabIndex = 2;
        downloadTemplateBtn.Text = "下載匯入描述範本";
        downloadTemplateBtn.UseVisualStyleBackColor = true;
        downloadTemplateBtn.Click += exportSchemaEvent;
        // 
        // downloadSchemaWordPerTableBtn
        // 
        downloadSchemaWordPerTableBtn.Location = new Point(20, 114);
        downloadSchemaWordPerTableBtn.Margin = new Padding(2);
        downloadSchemaWordPerTableBtn.Name = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.Size = new Size(243, 28);
        downloadSchemaWordPerTableBtn.TabIndex = 17;
        downloadSchemaWordPerTableBtn.Text = "下載資料庫規格 Word (一表一檔)";
        downloadSchemaWordPerTableBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordPerTableBtn.Click += exportSchemaWordBtnClick;
        // 
        // downloadSchemaWordBtn
        // 
        downloadSchemaWordBtn.Location = new Point(21, 66);
        downloadSchemaWordBtn.Margin = new Padding(2);
        downloadSchemaWordBtn.Name = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.Size = new Size(170, 28);
        downloadSchemaWordBtn.TabIndex = 15;
        downloadSchemaWordBtn.Text = "下載資料庫規格 Word";
        downloadSchemaWordBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordBtn.Click += exportSchemaWordBtnClick;
        // 
        // ImportDescription
        // 
        ImportDescription.Location = new Point(21, 211);
        ImportDescription.Margin = new Padding(2);
        ImportDescription.Name = "ImportDescription";
        ImportDescription.Size = new Size(92, 28);
        ImportDescription.TabIndex = 14;
        ImportDescription.Text = "匯入描述";
        ImportDescription.UseVisualStyleBackColor = true;
        ImportDescription.Click += ImportDescriptionEvent;
        // 
        // modelToolTab
        // 
        modelToolTab.Controls.Add(modelGenBtn);
        modelToolTab.Location = new Point(4, 28);
        modelToolTab.Margin = new Padding(2);
        modelToolTab.Name = "modelToolTab";
        modelToolTab.Padding = new Padding(2);
        modelToolTab.Size = new Size(528, 280);
        modelToolTab.TabIndex = 2;
        modelToolTab.Text = "model產檔";
        modelToolTab.UseVisualStyleBackColor = true;
        // 
        // modelGenBtn
        // 
        modelGenBtn.Location = new Point(17, 19);
        modelGenBtn.Margin = new Padding(2);
        modelGenBtn.Name = "modelGenBtn";
        modelGenBtn.Size = new Size(124, 26);
        modelGenBtn.TabIndex = 7;
        modelGenBtn.Text = "所有model產檔";
        modelGenBtn.UseVisualStyleBackColor = true;
        modelGenBtn.Click += GenerateModel;
        // 
        // settingTab
        // 
        settingTab.Controls.Add(CustomThemelabel);
        settingTab.Controls.Add(CustomThemeNameSelect);
        settingTab.Controls.Add(modelGenBtnSettingLabel);
        settingTab.Controls.Add(connSettingLabel);
        settingTab.Controls.Add(isWordWithToc);
        settingTab.Controls.Add(IsScaleShow);
        settingTab.Controls.Add(IsPrecisionShow);
        settingTab.Controls.Add(IsLengthShow);
        settingTab.Controls.Add(IsNotNullShow);
        settingTab.Controls.Add(IsPrimaryKeyShow);
        settingTab.Controls.Add(IsIdentityShow);
        settingTab.Controls.Add(IsDefaultValueShow);
        settingTab.Controls.Add(IsDataTypeShow);
        settingTab.Controls.Add(IsSortShow);
        settingTab.Controls.Add(IsColumnDescriptionShow);
        settingTab.Controls.Add(IsTableDescriptionShow);
        settingTab.Controls.Add(isSummary);
        settingTab.Controls.Add(isKey);
        settingTab.Controls.Add(IsRequired);
        settingTab.Controls.Add(IsDisplay);
        settingTab.Controls.Add(resetBtn);
        settingTab.Controls.Add(downloadExcelStyleTemplateBtn);
        settingTab.Location = new Point(4, 28);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(3);
        settingTab.Size = new Size(528, 280);
        settingTab.TabIndex = 3;
        settingTab.Text = "設定";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // CustomThemelabel
        // 
        CustomThemelabel.AutoSize = true;
        CustomThemelabel.Location = new Point(11, 150);
        CustomThemelabel.Margin = new Padding(2, 0, 2, 0);
        CustomThemelabel.Name = "CustomThemelabel";
        CustomThemelabel.Size = new Size(126, 19);
        CustomThemelabel.TabIndex = 21;
        CustomThemelabel.Text = "自定義 Excel 樣式";
        CustomThemelabel.DoubleClick += ReloadThemeBinding;
        // 
        // CustomThemeNameSelect
        // 
        CustomThemeNameSelect.FormattingEnabled = true;
        CustomThemeNameSelect.Location = new Point(139, 147);
        CustomThemeNameSelect.Name = "CustomThemeNameSelect";
        CustomThemeNameSelect.Size = new Size(224, 27);
        CustomThemeNameSelect.TabIndex = 20;
        CustomThemeNameSelect.SelectedIndexChanged += CustomThemeNameSelectChanged;
        // 
        // modelGenBtnSettingLabel
        // 
        modelGenBtnSettingLabel.AutoSize = true;
        modelGenBtnSettingLabel.Location = new Point(11, 183);
        modelGenBtnSettingLabel.Margin = new Padding(2, 0, 2, 0);
        modelGenBtnSettingLabel.Name = "modelGenBtnSettingLabel";
        modelGenBtnSettingLabel.Size = new Size(188, 19);
        modelGenBtnSettingLabel.TabIndex = 19;
        modelGenBtnSettingLabel.Text = "下載 model .cs 檔顯示設置";
        // 
        // connSettingLabel
        // 
        connSettingLabel.AutoSize = true;
        connSettingLabel.Location = new Point(11, 8);
        connSettingLabel.Margin = new Padding(2, 0, 2, 0);
        connSettingLabel.Name = "connSettingLabel";
        connSettingLabel.Size = new Size(214, 19);
        connSettingLabel.TabIndex = 17;
        connSettingLabel.Text = "下載 excel/word 規格顯示欄位";
        // 
        // isWordWithToc
        // 
        isWordWithToc.AutoSize = true;
        isWordWithToc.Location = new Point(32, 114);
        isWordWithToc.Margin = new Padding(2);
        isWordWithToc.Name = "isWordWithToc";
        isWordWithToc.Size = new Size(101, 23);
        isWordWithToc.TabIndex = 16;
        isWordWithToc.Text = "Word目錄";
        isWordWithToc.UseVisualStyleBackColor = true;
        isWordWithToc.CheckedChanged += isWordWithTocChanged;
        // 
        // IsScaleShow
        // 
        IsScaleShow.AutoSize = true;
        IsScaleShow.Location = new Point(254, 87);
        IsScaleShow.Margin = new Padding(2);
        IsScaleShow.Name = "IsScaleShow";
        IsScaleShow.Size = new Size(76, 23);
        IsScaleShow.TabIndex = 13;
        IsScaleShow.Text = "小位數";
        IsScaleShow.UseVisualStyleBackColor = true;
        IsScaleShow.CheckedChanged += IsScaleShowChanged;
        // 
        // IsPrecisionShow
        // 
        IsPrecisionShow.AutoSize = true;
        IsPrecisionShow.Location = new Point(181, 87);
        IsPrecisionShow.Margin = new Padding(2);
        IsPrecisionShow.Name = "IsPrecisionShow";
        IsPrecisionShow.Size = new Size(61, 23);
        IsPrecisionShow.TabIndex = 12;
        IsPrecisionShow.Text = "精度";
        IsPrecisionShow.UseVisualStyleBackColor = true;
        IsPrecisionShow.CheckedChanged += IsPrecisionShowChanged;
        // 
        // IsLengthShow
        // 
        IsLengthShow.AutoSize = true;
        IsLengthShow.Location = new Point(97, 87);
        IsLengthShow.Margin = new Padding(2);
        IsLengthShow.Name = "IsLengthShow";
        IsLengthShow.Size = new Size(61, 23);
        IsLengthShow.TabIndex = 11;
        IsLengthShow.Text = "長度";
        IsLengthShow.UseVisualStyleBackColor = true;
        IsLengthShow.CheckedChanged += IsLengthShowChanged;
        // 
        // IsNotNullShow
        // 
        IsNotNullShow.AutoSize = true;
        IsNotNullShow.Checked = true;
        IsNotNullShow.CheckState = CheckState.Checked;
        IsNotNullShow.Location = new Point(32, 87);
        IsNotNullShow.Margin = new Padding(2);
        IsNotNullShow.Name = "IsNotNullShow";
        IsNotNullShow.Size = new Size(61, 23);
        IsNotNullShow.TabIndex = 10;
        IsNotNullShow.Text = "必填";
        IsNotNullShow.UseVisualStyleBackColor = true;
        IsNotNullShow.CheckedChanged += IsNotNullShowChanged;
        // 
        // IsPrimaryKeyShow
        // 
        IsPrimaryKeyShow.AutoSize = true;
        IsPrimaryKeyShow.Checked = true;
        IsPrimaryKeyShow.CheckState = CheckState.Checked;
        IsPrimaryKeyShow.Location = new Point(330, 60);
        IsPrimaryKeyShow.Margin = new Padding(2);
        IsPrimaryKeyShow.Name = "IsPrimaryKeyShow";
        IsPrimaryKeyShow.Size = new Size(61, 23);
        IsPrimaryKeyShow.TabIndex = 9;
        IsPrimaryKeyShow.Text = "主鍵";
        IsPrimaryKeyShow.UseVisualStyleBackColor = true;
        IsPrimaryKeyShow.CheckedChanged += IsPrimaryKeyShowChanged;
        // 
        // IsIdentityShow
        // 
        IsIdentityShow.AutoSize = true;
        IsIdentityShow.Checked = true;
        IsIdentityShow.CheckState = CheckState.Checked;
        IsIdentityShow.Location = new Point(255, 60);
        IsIdentityShow.Margin = new Padding(2);
        IsIdentityShow.Name = "IsIdentityShow";
        IsIdentityShow.Size = new Size(61, 23);
        IsIdentityShow.TabIndex = 8;
        IsIdentityShow.Text = "識別";
        IsIdentityShow.UseVisualStyleBackColor = true;
        IsIdentityShow.CheckedChanged += IsIdentityShowChanged;
        // 
        // IsDefaultValueShow
        // 
        IsDefaultValueShow.AutoSize = true;
        IsDefaultValueShow.Checked = true;
        IsDefaultValueShow.CheckState = CheckState.Checked;
        IsDefaultValueShow.Location = new Point(181, 60);
        IsDefaultValueShow.Margin = new Padding(2);
        IsDefaultValueShow.Name = "IsDefaultValueShow";
        IsDefaultValueShow.Size = new Size(76, 23);
        IsDefaultValueShow.TabIndex = 7;
        IsDefaultValueShow.Text = "預設值";
        IsDefaultValueShow.UseVisualStyleBackColor = true;
        IsDefaultValueShow.CheckedChanged += IsDefaultValueShowChanged;
        // 
        // IsDataTypeShow
        // 
        IsDataTypeShow.AutoSize = true;
        IsDataTypeShow.Checked = true;
        IsDataTypeShow.CheckState = CheckState.Checked;
        IsDataTypeShow.Location = new Point(97, 60);
        IsDataTypeShow.Margin = new Padding(2);
        IsDataTypeShow.Name = "IsDataTypeShow";
        IsDataTypeShow.Size = new Size(91, 23);
        IsDataTypeShow.TabIndex = 6;
        IsDataTypeShow.Text = "資料型別";
        IsDataTypeShow.UseVisualStyleBackColor = true;
        IsDataTypeShow.CheckedChanged += IsDataTypeShowChanged;
        // 
        // IsSortShow
        // 
        IsSortShow.AutoSize = true;
        IsSortShow.Checked = true;
        IsSortShow.CheckState = CheckState.Checked;
        IsSortShow.Location = new Point(32, 60);
        IsSortShow.Margin = new Padding(2);
        IsSortShow.Name = "IsSortShow";
        IsSortShow.Size = new Size(61, 23);
        IsSortShow.TabIndex = 5;
        IsSortShow.Text = "排序";
        IsSortShow.UseVisualStyleBackColor = true;
        IsSortShow.CheckedChanged += IsSortShowChanged;
        // 
        // IsColumnDescriptionShow
        // 
        IsColumnDescriptionShow.AutoSize = true;
        IsColumnDescriptionShow.Location = new Point(330, 87);
        IsColumnDescriptionShow.Margin = new Padding(2);
        IsColumnDescriptionShow.Name = "IsColumnDescriptionShow";
        IsColumnDescriptionShow.Size = new Size(76, 23);
        IsColumnDescriptionShow.TabIndex = 4;
        IsColumnDescriptionShow.Text = "欄描述";
        IsColumnDescriptionShow.UseVisualStyleBackColor = true;
        IsColumnDescriptionShow.CheckedChanged += IsColumnDescriptionShowChanged;
        // 
        // IsTableDescriptionShow
        // 
        IsTableDescriptionShow.AutoSize = true;
        IsTableDescriptionShow.Location = new Point(32, 33);
        IsTableDescriptionShow.Margin = new Padding(2);
        IsTableDescriptionShow.Name = "IsTableDescriptionShow";
        IsTableDescriptionShow.Size = new Size(76, 23);
        IsTableDescriptionShow.TabIndex = 3;
        IsTableDescriptionShow.Text = "表描述";
        IsTableDescriptionShow.UseVisualStyleBackColor = true;
        IsTableDescriptionShow.CheckedChanged += IsTableDescriptionShowChanged;
        // 
        // isSummary
        // 
        isSummary.AutoSize = true;
        isSummary.Location = new Point(37, 213);
        isSummary.Margin = new Padding(2);
        isSummary.Name = "isSummary";
        isSummary.Size = new Size(99, 23);
        isSummary.TabIndex = 11;
        isSummary.Text = "Summary";
        isSummary.UseVisualStyleBackColor = true;
        isSummary.CheckedChanged += isSummaryChanged;
        // 
        // isKey
        // 
        isKey.AutoSize = true;
        isKey.Location = new Point(328, 213);
        isKey.Margin = new Padding(2);
        isKey.Name = "isKey";
        isKey.Size = new Size(56, 23);
        isKey.TabIndex = 10;
        isKey.Text = "Key";
        isKey.UseVisualStyleBackColor = true;
        isKey.CheckedChanged += isKeyChanged;
        // 
        // IsRequired
        // 
        IsRequired.AutoSize = true;
        IsRequired.Location = new Point(230, 213);
        IsRequired.Margin = new Padding(2);
        IsRequired.Name = "IsRequired";
        IsRequired.Size = new Size(96, 23);
        IsRequired.TabIndex = 9;
        IsRequired.Text = "Required";
        IsRequired.UseVisualStyleBackColor = true;
        IsRequired.CheckedChanged += IsRequiredChanged;
        // 
        // IsDisplay
        // 
        IsDisplay.AutoSize = true;
        IsDisplay.Location = new Point(137, 213);
        IsDisplay.Margin = new Padding(2);
        IsDisplay.Name = "IsDisplay";
        IsDisplay.Size = new Size(82, 23);
        IsDisplay.TabIndex = 8;
        IsDisplay.Text = "Display";
        IsDisplay.UseVisualStyleBackColor = true;
        IsDisplay.CheckedChanged += IsDisplayChanged;
        // 
        // resetBtn
        // 
        resetBtn.Location = new Point(19, 244);
        resetBtn.Margin = new Padding(2);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(92, 28);
        resetBtn.TabIndex = 15;
        resetBtn.Text = "重置設定";
        resetBtn.UseVisualStyleBackColor = true;
        resetBtn.Click += resetBtnClick;
        // 
        // downloadExcelStyleTemplateBtn
        // 
        downloadExcelStyleTemplateBtn.Location = new Point(369, 146);
        downloadExcelStyleTemplateBtn.Margin = new Padding(2);
        downloadExcelStyleTemplateBtn.Name = "downloadExcelStyleTemplateBtn";
        downloadExcelStyleTemplateBtn.Size = new Size(151, 28);
        downloadExcelStyleTemplateBtn.TabIndex = 18;
        downloadExcelStyleTemplateBtn.Text = "下載 Excel 自定樣式";
        downloadExcelStyleTemplateBtn.UseVisualStyleBackColor = true;
        downloadExcelStyleTemplateBtn.Click += downloadExcelStyleTemplate;
        // 
        // errorTextLbl
        // 
        errorTextLbl.BackColor = SystemColors.Control;
        errorTextLbl.BorderStyle = BorderStyle.None;
        errorTextLbl.Location = new Point(7, 318);
        errorTextLbl.Margin = new Padding(2);
        errorTextLbl.Multiline = true;
        errorTextLbl.Name = "errorTextLbl";
        errorTextLbl.ReadOnly = true;
        errorTextLbl.Size = new Size(522, 73);
        errorTextLbl.TabIndex = 8;
        errorTextLbl.DoubleClick += errorTextDoubleClick;
        // 
        // DbToolForm
        // 
        AutoScaleDimensions = new SizeF(9F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(535, 399);
        Controls.Add(errorTextLbl);
        Controls.Add(tabControl1);
        Margin = new Padding(2);
        Name = "DbToolForm";
        Text = "資料庫工具";
        Load += DbToolFormLoad;
        tabControl1.ResumeLayout(false);
        connToolTab.ResumeLayout(false);
        connToolTab.PerformLayout();
        schmaToolTab.ResumeLayout(false);
        modelToolTab.ResumeLayout(false);
        settingTab.ResumeLayout(false);
        settingTab.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    #region tool component
    private TextBox connStrBox;
    private Label connStrLabel;
    private Button demoCommBtn;
    private Button downloadSchemaBtn;
    private Button dbTestBtn;
    private TabControl tabControl1;

    private TabPage connToolTab;
    private TabPage schmaToolTab;
    private TabPage modelToolTab;
    private TabPage settingTab;

    private Button downloadTemplateBtn;
    private CheckBox IsTableDescriptionShow;
    private CheckBox IsDataTypeShow;
    private CheckBox IsSortShow;
    private CheckBox IsColumnDescriptionShow;
    private CheckBox IsDefaultValueShow;
    private CheckBox IsIdentityShow;
    private CheckBox IsLengthShow;
    private CheckBox IsNotNullShow;
    private CheckBox IsPrimaryKeyShow;
    private CheckBox IsScaleShow;
    private CheckBox IsPrecisionShow;
    private Button ImportDescription;
    private TextBox errorTextLbl;
    private Button modelGenBtn;
    #endregion

    private CheckBox IsDisplay;
    private CheckBox IsRequired;
    private CheckBox isKey;
    private CheckBox isSummary;
    private Button resetBtn;
    private Button downloadSchemaWordBtn;
    private CheckBox isWordWithToc;
    private Button downloadSchemaWordPerTableBtn;
    private Label connSettingLabel;
    private Label modelGenBtnSettingLabel;
    private Button downloadExcelStyleTemplateBtn;
    private ComboBox CustomThemeNameSelect;
    private Label CustomThemelabel;
}