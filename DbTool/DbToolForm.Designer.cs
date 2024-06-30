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
        importDescriptionBtn = new Button();
        modelToolTab = new TabPage();
        modelGenBtn = new Button();
        settingTab = new TabPage();
        customThemelabel = new Label();
        customThemeNameSelect = new ComboBox();
        modelGenBtnSettingLabel = new Label();
        connSettingLabel = new Label();
        isWordWithToc = new CheckBox();
        isScaleShow = new CheckBox();
        isPrecisionShow = new CheckBox();
        isLengthShow = new CheckBox();
        isNotNullShow = new CheckBox();
        isPrimaryKeyShow = new CheckBox();
        isIdentityShow = new CheckBox();
        isDefaultValueShow = new CheckBox();
        isDataTypeShow = new CheckBox();
        isSortShow = new CheckBox();
        isColumnDescriptionShow = new CheckBox();
        isTableDescriptionShow = new CheckBox();
        isSummary = new CheckBox();
        isKey = new CheckBox();
        isRequired = new CheckBox();
        isDisplay = new CheckBox();
        resetBtn = new Button();
        downloadExcelStyleTemplateBtn = new Button();
        languageTab = new TabPage();
        errorTextBox = new TextBox();
        languageSelect = new ComboBox();
        tabControl1.SuspendLayout();
        connToolTab.SuspendLayout();
        schmaToolTab.SuspendLayout();
        modelToolTab.SuspendLayout();
        settingTab.SuspendLayout();
        languageTab.SuspendLayout();
        SuspendLayout();
        // 
        // demoCommBtn
        // 
        demoCommBtn.Location = new Point(165, 212);
        demoCommBtn.Margin = new Padding(2);
        demoCommBtn.Name = "demoCommBtn";
        demoCommBtn.Size = new Size(112, 34);
        demoCommBtn.TabIndex = 0;
        demoCommBtn.Text = "顯示範例";
        demoCommBtn.UseVisualStyleBackColor = true;
        demoCommBtn.Click += demoCommBtnEvent;
        // 
        // downloadSchemaBtn
        // 
        downloadSchemaBtn.Location = new Point(24, 21);
        downloadSchemaBtn.Margin = new Padding(2);
        downloadSchemaBtn.Name = "downloadSchemaBtn";
        downloadSchemaBtn.Size = new Size(208, 34);
        downloadSchemaBtn.TabIndex = 1;
        downloadSchemaBtn.Text = "下載資料庫規格 Excel";
        downloadSchemaBtn.UseVisualStyleBackColor = true;
        downloadSchemaBtn.Click += exportSchemaEvent;
        // 
        // connStrBox
        // 
        connStrBox.Location = new Point(29, 56);
        connStrBox.Margin = new Padding(2);
        connStrBox.Multiline = true;
        connStrBox.Name = "connStrBox";
        connStrBox.Size = new Size(530, 135);
        connStrBox.TabIndex = 2;
        connStrBox.Text = "Data Source=MSI;Initial Catalog=MvcCoreTraining_Amanda;user id=sa;password=ruru";
        connStrBox.TextChanged += connStrBoxEvent;
        // 
        // connStrLabel
        // 
        connStrLabel.AutoSize = true;
        connStrLabel.Location = new Point(24, 18);
        connStrLabel.Margin = new Padding(2, 0, 2, 0);
        connStrLabel.Name = "connStrLabel";
        connStrLabel.Size = new Size(82, 23);
        connStrLabel.TabIndex = 3;
        connStrLabel.Text = "連線字串";
        // 
        // dbTestBtn
        // 
        dbTestBtn.Location = new Point(29, 212);
        dbTestBtn.Margin = new Padding(2);
        dbTestBtn.Name = "dbTestBtn";
        dbTestBtn.Size = new Size(112, 34);
        dbTestBtn.TabIndex = 6;
        dbTestBtn.Text = "連線測試";
        dbTestBtn.UseVisualStyleBackColor = true;
        dbTestBtn.Click += DbTestConnClick;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(connToolTab);
        tabControl1.Controls.Add(schmaToolTab);
        tabControl1.Controls.Add(modelToolTab);
        tabControl1.Controls.Add(settingTab);
        tabControl1.Controls.Add(languageTab);
        tabControl1.Location = new Point(0, 2);
        tabControl1.Margin = new Padding(2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(655, 378);
        tabControl1.TabIndex = 7;
        tabControl1.SelectedIndexChanged += tabControlChanged;
        // 
        // connToolTab
        // 
        connToolTab.Controls.Add(connStrLabel);
        connToolTab.Controls.Add(dbTestBtn);
        connToolTab.Controls.Add(connStrBox);
        connToolTab.Controls.Add(demoCommBtn);
        connToolTab.Location = new Point(4, 32);
        connToolTab.Margin = new Padding(2);
        connToolTab.Name = "connToolTab";
        connToolTab.Padding = new Padding(2);
        connToolTab.Size = new Size(647, 342);
        connToolTab.TabIndex = 0;
        connToolTab.Text = "資料庫連線";
        connToolTab.UseVisualStyleBackColor = true;
        // 
        // schmaToolTab
        // 
        schmaToolTab.Controls.Add(downloadTemplateBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordPerTableBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordBtn);
        schmaToolTab.Controls.Add(importDescriptionBtn);
        schmaToolTab.Controls.Add(downloadSchemaBtn);
        schmaToolTab.Location = new Point(4, 32);
        schmaToolTab.Margin = new Padding(2);
        schmaToolTab.Name = "schmaToolTab";
        schmaToolTab.Padding = new Padding(2);
        schmaToolTab.Size = new Size(647, 342);
        schmaToolTab.TabIndex = 1;
        schmaToolTab.Text = "資料庫規格";
        schmaToolTab.UseVisualStyleBackColor = true;
        // 
        // downloadTemplateBtn
        // 
        downloadTemplateBtn.Location = new Point(26, 197);
        downloadTemplateBtn.Margin = new Padding(2);
        downloadTemplateBtn.Name = "downloadTemplateBtn";
        downloadTemplateBtn.Size = new Size(189, 34);
        downloadTemplateBtn.TabIndex = 2;
        downloadTemplateBtn.Text = "下載匯入描述範本";
        downloadTemplateBtn.UseVisualStyleBackColor = true;
        downloadTemplateBtn.Click += exportSchemaEvent;
        // 
        // downloadSchemaWordPerTableBtn
        // 
        downloadSchemaWordPerTableBtn.Location = new Point(24, 138);
        downloadSchemaWordPerTableBtn.Margin = new Padding(2);
        downloadSchemaWordPerTableBtn.Name = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.Size = new Size(297, 34);
        downloadSchemaWordPerTableBtn.TabIndex = 17;
        downloadSchemaWordPerTableBtn.Text = "下載資料庫規格 Word (一表一檔)";
        downloadSchemaWordPerTableBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordPerTableBtn.Click += exportSchemaWordBtnClick;
        // 
        // downloadSchemaWordBtn
        // 
        downloadSchemaWordBtn.Location = new Point(26, 80);
        downloadSchemaWordBtn.Margin = new Padding(2);
        downloadSchemaWordBtn.Name = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.Size = new Size(208, 34);
        downloadSchemaWordBtn.TabIndex = 15;
        downloadSchemaWordBtn.Text = "下載資料庫規格 Word";
        downloadSchemaWordBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordBtn.Click += exportSchemaWordBtnClick;
        // 
        // importDescriptionBtn
        // 
        importDescriptionBtn.Location = new Point(26, 255);
        importDescriptionBtn.Margin = new Padding(2);
        importDescriptionBtn.Name = "importDescriptionBtn";
        importDescriptionBtn.Size = new Size(112, 34);
        importDescriptionBtn.TabIndex = 14;
        importDescriptionBtn.Text = "匯入描述";
        importDescriptionBtn.UseVisualStyleBackColor = true;
        importDescriptionBtn.Click += ImportDescriptionClick;
        // 
        // modelToolTab
        // 
        modelToolTab.Controls.Add(modelGenBtn);
        modelToolTab.Location = new Point(4, 32);
        modelToolTab.Margin = new Padding(2);
        modelToolTab.Name = "modelToolTab";
        modelToolTab.Padding = new Padding(2);
        modelToolTab.Size = new Size(647, 342);
        modelToolTab.TabIndex = 2;
        modelToolTab.Text = "model產檔";
        modelToolTab.UseVisualStyleBackColor = true;
        // 
        // modelGenBtn
        // 
        modelGenBtn.Location = new Point(21, 23);
        modelGenBtn.Margin = new Padding(2);
        modelGenBtn.Name = "modelGenBtn";
        modelGenBtn.Size = new Size(152, 31);
        modelGenBtn.TabIndex = 7;
        modelGenBtn.Text = "所有model產檔";
        modelGenBtn.UseVisualStyleBackColor = true;
        modelGenBtn.Click += GenerateModel;
        // 
        // settingTab
        // 
        settingTab.Controls.Add(customThemelabel);
        settingTab.Controls.Add(customThemeNameSelect);
        settingTab.Controls.Add(modelGenBtnSettingLabel);
        settingTab.Controls.Add(connSettingLabel);
        settingTab.Controls.Add(isWordWithToc);
        settingTab.Controls.Add(isScaleShow);
        settingTab.Controls.Add(isPrecisionShow);
        settingTab.Controls.Add(isLengthShow);
        settingTab.Controls.Add(isNotNullShow);
        settingTab.Controls.Add(isPrimaryKeyShow);
        settingTab.Controls.Add(isIdentityShow);
        settingTab.Controls.Add(isDefaultValueShow);
        settingTab.Controls.Add(isDataTypeShow);
        settingTab.Controls.Add(isSortShow);
        settingTab.Controls.Add(isColumnDescriptionShow);
        settingTab.Controls.Add(isTableDescriptionShow);
        settingTab.Controls.Add(isSummary);
        settingTab.Controls.Add(isKey);
        settingTab.Controls.Add(isRequired);
        settingTab.Controls.Add(isDisplay);
        settingTab.Controls.Add(resetBtn);
        settingTab.Controls.Add(downloadExcelStyleTemplateBtn);
        settingTab.Location = new Point(4, 32);
        settingTab.Margin = new Padding(4);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(4);
        settingTab.Size = new Size(647, 342);
        settingTab.TabIndex = 3;
        settingTab.Text = "設定";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // customThemelabel
        // 
        customThemelabel.AutoSize = true;
        customThemelabel.Location = new Point(13, 182);
        customThemelabel.Margin = new Padding(2, 0, 2, 0);
        customThemelabel.Name = "customThemelabel";
        customThemelabel.Size = new Size(153, 23);
        customThemelabel.TabIndex = 21;
        customThemelabel.Text = "自定義 Excel 樣式";
        customThemelabel.DoubleClick += ReloadThemeBinding;
        // 
        // customThemeNameSelect
        // 
        customThemeNameSelect.FormattingEnabled = true;
        customThemeNameSelect.Location = new Point(170, 178);
        customThemeNameSelect.Margin = new Padding(4);
        customThemeNameSelect.Name = "customThemeNameSelect";
        customThemeNameSelect.Size = new Size(273, 31);
        customThemeNameSelect.TabIndex = 20;
        customThemeNameSelect.SelectedIndexChanged += customThemeNameSelectChanged;
        // 
        // modelGenBtnSettingLabel
        // 
        modelGenBtnSettingLabel.AutoSize = true;
        modelGenBtnSettingLabel.Location = new Point(13, 222);
        modelGenBtnSettingLabel.Margin = new Padding(2, 0, 2, 0);
        modelGenBtnSettingLabel.Name = "modelGenBtnSettingLabel";
        modelGenBtnSettingLabel.Size = new Size(226, 23);
        modelGenBtnSettingLabel.TabIndex = 19;
        modelGenBtnSettingLabel.Text = "下載 model .cs 檔顯示設置";
        // 
        // connSettingLabel
        // 
        connSettingLabel.AutoSize = true;
        connSettingLabel.Location = new Point(13, 10);
        connSettingLabel.Margin = new Padding(2, 0, 2, 0);
        connSettingLabel.Name = "connSettingLabel";
        connSettingLabel.Size = new Size(258, 23);
        connSettingLabel.TabIndex = 17;
        connSettingLabel.Text = "下載 excel/word 規格顯示欄位";
        // 
        // isWordWithToc
        // 
        isWordWithToc.AutoSize = true;
        isWordWithToc.Location = new Point(39, 138);
        isWordWithToc.Margin = new Padding(2);
        isWordWithToc.Name = "isWordWithToc";
        isWordWithToc.Size = new Size(119, 27);
        isWordWithToc.TabIndex = 16;
        isWordWithToc.Text = "Word目錄";
        isWordWithToc.UseVisualStyleBackColor = true;
        isWordWithToc.CheckedChanged += isWordWithTocChanged;
        // 
        // isScaleShow
        // 
        isScaleShow.AutoSize = true;
        isScaleShow.Location = new Point(310, 105);
        isScaleShow.Margin = new Padding(2);
        isScaleShow.Name = "isScaleShow";
        isScaleShow.Size = new Size(90, 27);
        isScaleShow.TabIndex = 13;
        isScaleShow.Text = "小位數";
        isScaleShow.UseVisualStyleBackColor = true;
        isScaleShow.CheckedChanged += IsScaleShowChanged;
        // 
        // isPrecisionShow
        // 
        isPrecisionShow.AutoSize = true;
        isPrecisionShow.Location = new Point(221, 105);
        isPrecisionShow.Margin = new Padding(2);
        isPrecisionShow.Name = "isPrecisionShow";
        isPrecisionShow.Size = new Size(72, 27);
        isPrecisionShow.TabIndex = 12;
        isPrecisionShow.Text = "精度";
        isPrecisionShow.UseVisualStyleBackColor = true;
        isPrecisionShow.CheckedChanged += IsPrecisionShowChanged;
        // 
        // isLengthShow
        // 
        isLengthShow.AutoSize = true;
        isLengthShow.Location = new Point(119, 105);
        isLengthShow.Margin = new Padding(2);
        isLengthShow.Name = "isLengthShow";
        isLengthShow.Size = new Size(72, 27);
        isLengthShow.TabIndex = 11;
        isLengthShow.Text = "長度";
        isLengthShow.UseVisualStyleBackColor = true;
        isLengthShow.CheckedChanged += IsLengthShowChanged;
        // 
        // isNotNullShow
        // 
        isNotNullShow.AutoSize = true;
        isNotNullShow.Checked = true;
        isNotNullShow.CheckState = CheckState.Checked;
        isNotNullShow.Location = new Point(39, 105);
        isNotNullShow.Margin = new Padding(2);
        isNotNullShow.Name = "isNotNullShow";
        isNotNullShow.Size = new Size(72, 27);
        isNotNullShow.TabIndex = 10;
        isNotNullShow.Text = "必填";
        isNotNullShow.UseVisualStyleBackColor = true;
        isNotNullShow.CheckedChanged += IsNotNullShowChanged;
        // 
        // isPrimaryKeyShow
        // 
        isPrimaryKeyShow.AutoSize = true;
        isPrimaryKeyShow.Checked = true;
        isPrimaryKeyShow.CheckState = CheckState.Checked;
        isPrimaryKeyShow.Location = new Point(403, 73);
        isPrimaryKeyShow.Margin = new Padding(2);
        isPrimaryKeyShow.Name = "isPrimaryKeyShow";
        isPrimaryKeyShow.Size = new Size(72, 27);
        isPrimaryKeyShow.TabIndex = 9;
        isPrimaryKeyShow.Text = "主鍵";
        isPrimaryKeyShow.UseVisualStyleBackColor = true;
        isPrimaryKeyShow.CheckedChanged += IsPrimaryKeyShowChanged;
        // 
        // isIdentityShow
        // 
        isIdentityShow.AutoSize = true;
        isIdentityShow.Checked = true;
        isIdentityShow.CheckState = CheckState.Checked;
        isIdentityShow.Location = new Point(312, 73);
        isIdentityShow.Margin = new Padding(2);
        isIdentityShow.Name = "isIdentityShow";
        isIdentityShow.Size = new Size(72, 27);
        isIdentityShow.TabIndex = 8;
        isIdentityShow.Text = "識別";
        isIdentityShow.UseVisualStyleBackColor = true;
        isIdentityShow.CheckedChanged += IsIdentityShowChanged;
        // 
        // isDefaultValueShow
        // 
        isDefaultValueShow.AutoSize = true;
        isDefaultValueShow.Checked = true;
        isDefaultValueShow.CheckState = CheckState.Checked;
        isDefaultValueShow.Location = new Point(221, 73);
        isDefaultValueShow.Margin = new Padding(2);
        isDefaultValueShow.Name = "isDefaultValueShow";
        isDefaultValueShow.Size = new Size(90, 27);
        isDefaultValueShow.TabIndex = 7;
        isDefaultValueShow.Text = "預設值";
        isDefaultValueShow.UseVisualStyleBackColor = true;
        isDefaultValueShow.CheckedChanged += IsDefaultValueShowChanged;
        // 
        // isDataTypeShow
        // 
        isDataTypeShow.AutoSize = true;
        isDataTypeShow.Checked = true;
        isDataTypeShow.CheckState = CheckState.Checked;
        isDataTypeShow.Location = new Point(119, 73);
        isDataTypeShow.Margin = new Padding(2);
        isDataTypeShow.Name = "isDataTypeShow";
        isDataTypeShow.Size = new Size(108, 27);
        isDataTypeShow.TabIndex = 6;
        isDataTypeShow.Text = "資料型別";
        isDataTypeShow.UseVisualStyleBackColor = true;
        isDataTypeShow.CheckedChanged += IsDataTypeShowChanged;
        // 
        // isSortShow
        // 
        isSortShow.AutoSize = true;
        isSortShow.Checked = true;
        isSortShow.CheckState = CheckState.Checked;
        isSortShow.Location = new Point(39, 73);
        isSortShow.Margin = new Padding(2);
        isSortShow.Name = "isSortShow";
        isSortShow.Size = new Size(72, 27);
        isSortShow.TabIndex = 5;
        isSortShow.Text = "排序";
        isSortShow.UseVisualStyleBackColor = true;
        isSortShow.CheckedChanged += IsSortShowChanged;
        // 
        // isColumnDescriptionShow
        // 
        isColumnDescriptionShow.AutoSize = true;
        isColumnDescriptionShow.Location = new Point(403, 105);
        isColumnDescriptionShow.Margin = new Padding(2);
        isColumnDescriptionShow.Name = "isColumnDescriptionShow";
        isColumnDescriptionShow.Size = new Size(90, 27);
        isColumnDescriptionShow.TabIndex = 4;
        isColumnDescriptionShow.Text = "欄描述";
        isColumnDescriptionShow.UseVisualStyleBackColor = true;
        isColumnDescriptionShow.CheckedChanged += IsColumnDescriptionShowChanged;
        // 
        // isTableDescriptionShow
        // 
        isTableDescriptionShow.AutoSize = true;
        isTableDescriptionShow.Location = new Point(39, 40);
        isTableDescriptionShow.Margin = new Padding(2);
        isTableDescriptionShow.Name = "isTableDescriptionShow";
        isTableDescriptionShow.Size = new Size(90, 27);
        isTableDescriptionShow.TabIndex = 3;
        isTableDescriptionShow.Text = "表描述";
        isTableDescriptionShow.UseVisualStyleBackColor = true;
        isTableDescriptionShow.CheckedChanged += IsTableDescriptionShowChanged;
        // 
        // isSummary
        // 
        isSummary.AutoSize = true;
        isSummary.Location = new Point(45, 258);
        isSummary.Margin = new Padding(2);
        isSummary.Name = "isSummary";
        isSummary.Size = new Size(117, 27);
        isSummary.TabIndex = 11;
        isSummary.Text = "Summary";
        isSummary.UseVisualStyleBackColor = true;
        isSummary.CheckedChanged += isSummaryChanged;
        // 
        // isKey
        // 
        isKey.AutoSize = true;
        isKey.Location = new Point(401, 258);
        isKey.Margin = new Padding(2);
        isKey.Name = "isKey";
        isKey.Size = new Size(66, 27);
        isKey.TabIndex = 10;
        isKey.Text = "Key";
        isKey.UseVisualStyleBackColor = true;
        isKey.CheckedChanged += isKeyChanged;
        // 
        // isRequired
        // 
        isRequired.AutoSize = true;
        isRequired.Location = new Point(281, 258);
        isRequired.Margin = new Padding(2);
        isRequired.Name = "isRequired";
        isRequired.Size = new Size(113, 27);
        isRequired.TabIndex = 9;
        isRequired.Text = "Required";
        isRequired.UseVisualStyleBackColor = true;
        isRequired.CheckedChanged += IsRequiredChanged;
        // 
        // isDisplay
        // 
        isDisplay.AutoSize = true;
        isDisplay.Location = new Point(167, 258);
        isDisplay.Margin = new Padding(2);
        isDisplay.Name = "isDisplay";
        isDisplay.Size = new Size(98, 27);
        isDisplay.TabIndex = 8;
        isDisplay.Text = "Display";
        isDisplay.UseVisualStyleBackColor = true;
        isDisplay.CheckedChanged += IsDisplayChanged;
        // 
        // resetBtn
        // 
        resetBtn.Location = new Point(23, 295);
        resetBtn.Margin = new Padding(2);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(112, 34);
        resetBtn.TabIndex = 15;
        resetBtn.Text = "重置設定";
        resetBtn.UseVisualStyleBackColor = true;
        resetBtn.Click += resetAllSetting;
        // 
        // downloadExcelStyleTemplateBtn
        // 
        downloadExcelStyleTemplateBtn.Location = new Point(451, 177);
        downloadExcelStyleTemplateBtn.Margin = new Padding(2);
        downloadExcelStyleTemplateBtn.Name = "downloadExcelStyleTemplateBtn";
        downloadExcelStyleTemplateBtn.Size = new Size(185, 34);
        downloadExcelStyleTemplateBtn.TabIndex = 18;
        downloadExcelStyleTemplateBtn.Text = "下載 Excel 自定樣式";
        downloadExcelStyleTemplateBtn.UseVisualStyleBackColor = true;
        downloadExcelStyleTemplateBtn.Click += downloadExcelStyleTemplate;
        // 
        // languageTab
        // 
        languageTab.Controls.Add(languageSelect);
        languageTab.Location = new Point(4, 32);
        languageTab.Name = "languageTab";
        languageTab.Padding = new Padding(3);
        languageTab.Size = new Size(647, 342);
        languageTab.TabIndex = 4;
        languageTab.Text = "語言";
        languageTab.UseVisualStyleBackColor = true;
        // 
        // errorTextBox
        // 
        errorTextBox.BackColor = SystemColors.Control;
        errorTextBox.BorderStyle = BorderStyle.None;
        errorTextBox.Location = new Point(9, 385);
        errorTextBox.Margin = new Padding(2);
        errorTextBox.Multiline = true;
        errorTextBox.Name = "errorTextBox";
        errorTextBox.ReadOnly = true;
        errorTextBox.Size = new Size(638, 88);
        errorTextBox.TabIndex = 8;
        errorTextBox.DoubleClick += ErrorTextClearDoubleClick;
        // 
        // languageSelect
        // 
        languageSelect.FormattingEnabled = true;
        languageSelect.Location = new Point(27, 20);
        languageSelect.Margin = new Padding(4);
        languageSelect.Name = "languageSelect";
        languageSelect.Size = new Size(90, 31);
        languageSelect.TabIndex = 21;
        languageSelect.SelectedIndexChanged += languageSelectChanged;
        // 
        // DbToolForm
        // 
        AutoScaleDimensions = new SizeF(11F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(654, 483);
        Controls.Add(errorTextBox);
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
        languageTab.ResumeLayout(false);
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
    private CheckBox isTableDescriptionShow;
    private CheckBox isDataTypeShow;
    private CheckBox isSortShow;
    private CheckBox isColumnDescriptionShow;
    private CheckBox isDefaultValueShow;
    private CheckBox isIdentityShow;
    private CheckBox isLengthShow;
    private CheckBox isNotNullShow;
    private CheckBox isPrimaryKeyShow;
    private CheckBox isScaleShow;
    private CheckBox isPrecisionShow;
    private Button importDescriptionBtn;
    private TextBox errorTextBox;
    private Button modelGenBtn;
    #endregion

    private CheckBox isDisplay;
    private CheckBox isRequired;
    private CheckBox isKey;
    private CheckBox isSummary;
    private Button resetBtn;
    private Button downloadSchemaWordBtn;
    private CheckBox isWordWithToc;
    private Button downloadSchemaWordPerTableBtn;
    private Label connSettingLabel;
    private Label modelGenBtnSettingLabel;
    private Button downloadExcelStyleTemplateBtn;
    private ComboBox customThemeNameSelect;
    private Label customThemelabel;
    private TabPage languageTab;
    private ComboBox languageSelect;
}