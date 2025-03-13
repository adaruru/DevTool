// DevTool 1.1 
// Copyright (C) 2024, Adaruru

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
        nameSpaceLabel = new Label();
        namespaceBox = new TextBox();
        modelGenBtn = new Button();
        scriptGenTab = new TabPage();
        dbContextLabel = new Label();
        dbContextBox = new TextBox();
        sourceDbConnTestBtn = new Button();
        upDataDBSchemaBtn = new Button();
        genScriptFromDllBtn = new Button();
        sourceDbConnStrBox = new TextBox();
        sourceDbConnStrLabel = new Label();
        dalDllPathBox = new TextBox();
        dalDllLabel = new Label();
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
        languageSelect = new ComboBox();
        errorTextBox = new TextBox();
        isTableNameAsLink = new CheckBox();
        tabControl1.SuspendLayout();
        connToolTab.SuspendLayout();
        schmaToolTab.SuspendLayout();
        modelToolTab.SuspendLayout();
        scriptGenTab.SuspendLayout();
        settingTab.SuspendLayout();
        languageTab.SuspendLayout();
        SuspendLayout();
        // 
        // demoCommBtn
        // 
        demoCommBtn.Location = new Point(200, 138);
        demoCommBtn.Margin = new Padding(2);
        demoCommBtn.Name = "demoCommBtn";
        demoCommBtn.Size = new Size(145, 22);
        demoCommBtn.TabIndex = 0;
        demoCommBtn.Text = "demoCommBtn";
        demoCommBtn.UseVisualStyleBackColor = true;
        demoCommBtn.Click += demoCommBtnEvent;
        // 
        // downloadSchemaBtn
        // 
        downloadSchemaBtn.Location = new Point(16, 13);
        downloadSchemaBtn.Margin = new Padding(2);
        downloadSchemaBtn.Name = "downloadSchemaBtn";
        downloadSchemaBtn.Size = new Size(232, 22);
        downloadSchemaBtn.TabIndex = 1;
        downloadSchemaBtn.Text = "downloadSchemaBtn";
        downloadSchemaBtn.UseVisualStyleBackColor = true;
        downloadSchemaBtn.Click += exportSchemaEvent;
        // 
        // connStrBox
        // 
        connStrBox.Location = new Point(19, 36);
        connStrBox.Margin = new Padding(2);
        connStrBox.Multiline = true;
        connStrBox.Name = "connStrBox";
        connStrBox.Size = new Size(338, 89);
        connStrBox.TabIndex = 2;
        connStrBox.Text = "Data Source=MSI;Initial Catalog=MvcCoreTraining_Amanda;user id=sa;password=ruru";
        connStrBox.TextChanged += connStrBoxEvent;
        // 
        // connStrLabel
        // 
        connStrLabel.AutoSize = true;
        connStrLabel.Location = new Point(16, 12);
        connStrLabel.Margin = new Padding(2, 0, 2, 0);
        connStrLabel.Name = "connStrLabel";
        connStrLabel.Size = new Size(81, 15);
        connStrLabel.TabIndex = 3;
        connStrLabel.Text = "connStrLabel";
        // 
        // dbTestBtn
        // 
        dbTestBtn.Location = new Point(19, 138);
        dbTestBtn.Margin = new Padding(2);
        dbTestBtn.Name = "dbTestBtn";
        dbTestBtn.Size = new Size(135, 22);
        dbTestBtn.TabIndex = 6;
        dbTestBtn.Text = "dbTestBtn";
        dbTestBtn.UseVisualStyleBackColor = true;
        dbTestBtn.Click += DbTestConnClick;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(connToolTab);
        tabControl1.Controls.Add(schmaToolTab);
        tabControl1.Controls.Add(modelToolTab);
        tabControl1.Controls.Add(scriptGenTab);
        tabControl1.Controls.Add(settingTab);
        tabControl1.Controls.Add(languageTab);
        tabControl1.Location = new Point(0, 2);
        tabControl1.Margin = new Padding(2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(614, 246);
        tabControl1.TabIndex = 7;
        tabControl1.SelectedIndexChanged += tabControlChanged;
        // 
        // connToolTab
        // 
        connToolTab.Controls.Add(connStrLabel);
        connToolTab.Controls.Add(dbTestBtn);
        connToolTab.Controls.Add(connStrBox);
        connToolTab.Controls.Add(demoCommBtn);
        connToolTab.Location = new Point(4, 24);
        connToolTab.Margin = new Padding(2);
        connToolTab.Name = "connToolTab";
        connToolTab.Padding = new Padding(2);
        connToolTab.Size = new Size(606, 218);
        connToolTab.TabIndex = 0;
        connToolTab.Text = "connToolTab";
        connToolTab.UseVisualStyleBackColor = true;
        // 
        // schmaToolTab
        // 
        schmaToolTab.Controls.Add(downloadTemplateBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordPerTableBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordBtn);
        schmaToolTab.Controls.Add(importDescriptionBtn);
        schmaToolTab.Controls.Add(downloadSchemaBtn);
        schmaToolTab.Location = new Point(4, 24);
        schmaToolTab.Margin = new Padding(2);
        schmaToolTab.Name = "schmaToolTab";
        schmaToolTab.Padding = new Padding(2);
        schmaToolTab.Size = new Size(606, 218);
        schmaToolTab.TabIndex = 1;
        schmaToolTab.Text = "schmaToolTab";
        schmaToolTab.UseVisualStyleBackColor = true;
        // 
        // downloadTemplateBtn
        // 
        downloadTemplateBtn.Location = new Point(16, 129);
        downloadTemplateBtn.Margin = new Padding(2);
        downloadTemplateBtn.Name = "downloadTemplateBtn";
        downloadTemplateBtn.Size = new Size(345, 22);
        downloadTemplateBtn.TabIndex = 2;
        downloadTemplateBtn.Text = "downloadTemplateBtn";
        downloadTemplateBtn.UseVisualStyleBackColor = true;
        downloadTemplateBtn.Click += exportSchemaEvent;
        // 
        // downloadSchemaWordPerTableBtn
        // 
        downloadSchemaWordPerTableBtn.Location = new Point(16, 90);
        downloadSchemaWordPerTableBtn.Margin = new Padding(2);
        downloadSchemaWordPerTableBtn.Name = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.Size = new Size(346, 22);
        downloadSchemaWordPerTableBtn.TabIndex = 17;
        downloadSchemaWordPerTableBtn.Text = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordPerTableBtn.Click += exportSchemaWordBtnClick;
        // 
        // downloadSchemaWordBtn
        // 
        downloadSchemaWordBtn.Location = new Point(16, 52);
        downloadSchemaWordBtn.Margin = new Padding(2);
        downloadSchemaWordBtn.Name = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.Size = new Size(231, 22);
        downloadSchemaWordBtn.TabIndex = 15;
        downloadSchemaWordBtn.Text = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordBtn.Click += exportSchemaWordBtnClick;
        // 
        // importDescriptionBtn
        // 
        importDescriptionBtn.Location = new Point(16, 167);
        importDescriptionBtn.Margin = new Padding(2);
        importDescriptionBtn.Name = "importDescriptionBtn";
        importDescriptionBtn.Size = new Size(345, 22);
        importDescriptionBtn.TabIndex = 14;
        importDescriptionBtn.Text = "importDescriptionBtn";
        importDescriptionBtn.UseVisualStyleBackColor = true;
        importDescriptionBtn.Click += ImportDescriptionClick;
        // 
        // modelToolTab
        // 
        modelToolTab.Controls.Add(nameSpaceLabel);
        modelToolTab.Controls.Add(namespaceBox);
        modelToolTab.Controls.Add(modelGenBtn);
        modelToolTab.Location = new Point(4, 24);
        modelToolTab.Margin = new Padding(2);
        modelToolTab.Name = "modelToolTab";
        modelToolTab.Padding = new Padding(2);
        modelToolTab.Size = new Size(606, 218);
        modelToolTab.TabIndex = 2;
        modelToolTab.Text = "modelToolTab";
        modelToolTab.UseVisualStyleBackColor = true;
        // 
        // nameSpaceLabel
        // 
        nameSpaceLabel.AutoSize = true;
        nameSpaceLabel.Location = new Point(17, 47);
        nameSpaceLabel.Margin = new Padding(2, 0, 2, 0);
        nameSpaceLabel.Name = "nameSpaceLabel";
        nameSpaceLabel.Size = new Size(105, 15);
        nameSpaceLabel.TabIndex = 9;
        nameSpaceLabel.Text = "nameSpaceLabel";
        // 
        // namespaceBox
        // 
        namespaceBox.Location = new Point(117, 46);
        namespaceBox.Margin = new Padding(2);
        namespaceBox.Multiline = true;
        namespaceBox.Name = "namespaceBox";
        namespaceBox.Size = new Size(228, 25);
        namespaceBox.TabIndex = 8;
        namespaceBox.TextChanged += namespaceBoxChanged;
        // 
        // modelGenBtn
        // 
        modelGenBtn.Location = new Point(13, 15);
        modelGenBtn.Margin = new Padding(2);
        modelGenBtn.Name = "modelGenBtn";
        modelGenBtn.Size = new Size(140, 21);
        modelGenBtn.TabIndex = 7;
        modelGenBtn.Text = "modelGenBtn";
        modelGenBtn.UseVisualStyleBackColor = true;
        modelGenBtn.Click += GenerateModel;
        // 
        // scriptGenTab
        // 
        scriptGenTab.Controls.Add(dbContextLabel);
        scriptGenTab.Controls.Add(dbContextBox);
        scriptGenTab.Controls.Add(sourceDbConnTestBtn);
        scriptGenTab.Controls.Add(upDataDBSchemaBtn);
        scriptGenTab.Controls.Add(genScriptFromDllBtn);
        scriptGenTab.Controls.Add(sourceDbConnStrBox);
        scriptGenTab.Controls.Add(sourceDbConnStrLabel);
        scriptGenTab.Controls.Add(dalDllPathBox);
        scriptGenTab.Controls.Add(dalDllLabel);
        scriptGenTab.Location = new Point(4, 24);
        scriptGenTab.Margin = new Padding(2, 2, 2, 2);
        scriptGenTab.Name = "scriptGenTab";
        scriptGenTab.Padding = new Padding(2, 2, 2, 2);
        scriptGenTab.Size = new Size(606, 218);
        scriptGenTab.TabIndex = 5;
        scriptGenTab.Text = "scriptGenTab";
        scriptGenTab.UseVisualStyleBackColor = true;
        // 
        // dbContextLabel
        // 
        dbContextLabel.AutoSize = true;
        dbContextLabel.Location = new Point(25, 63);
        dbContextLabel.Margin = new Padding(2, 0, 2, 0);
        dbContextLabel.Name = "dbContextLabel";
        dbContextLabel.Size = new Size(67, 15);
        dbContextLabel.TabIndex = 16;
        dbContextLabel.Text = "dbContext";
        // 
        // dbContextBox
        // 
        dbContextBox.Location = new Point(92, 61);
        dbContextBox.Margin = new Padding(2);
        dbContextBox.Multiline = true;
        dbContextBox.Name = "dbContextBox";
        dbContextBox.Size = new Size(273, 24);
        dbContextBox.TabIndex = 15;
        dbContextBox.TextChanged += dbContextBoxChanged;
        // 
        // sourceDbConnTestBtn
        // 
        sourceDbConnTestBtn.Location = new Point(398, 165);
        sourceDbConnTestBtn.Margin = new Padding(2, 2, 2, 2);
        sourceDbConnTestBtn.Name = "sourceDbConnTestBtn";
        sourceDbConnTestBtn.Size = new Size(102, 23);
        sourceDbConnTestBtn.TabIndex = 14;
        sourceDbConnTestBtn.Text = "sourceDbConnTestBtn";
        sourceDbConnTestBtn.UseVisualStyleBackColor = true;
        sourceDbConnTestBtn.Click += SourceDbConnTestBtnClick;
        // 
        // upDataDBSchemaBtn
        // 
        upDataDBSchemaBtn.Location = new Point(398, 193);
        upDataDBSchemaBtn.Margin = new Padding(2, 2, 2, 2);
        upDataDBSchemaBtn.Name = "upDataDBSchemaBtn";
        upDataDBSchemaBtn.Size = new Size(199, 23);
        upDataDBSchemaBtn.TabIndex = 13;
        upDataDBSchemaBtn.Text = "upDataDBSchemaBtn";
        upDataDBSchemaBtn.UseVisualStyleBackColor = true;
        upDataDBSchemaBtn.Click += UpDataDBSchemaBtnClick;
        // 
        // genScriptFromDllBtn
        // 
        genScriptFromDllBtn.Location = new Point(368, 59);
        genScriptFromDllBtn.Margin = new Padding(2, 2, 2, 2);
        genScriptFromDllBtn.Name = "genScriptFromDllBtn";
        genScriptFromDllBtn.Size = new Size(180, 23);
        genScriptFromDllBtn.TabIndex = 12;
        genScriptFromDllBtn.Text = "genScriptFromDllBtn";
        genScriptFromDllBtn.UseVisualStyleBackColor = true;
        genScriptFromDllBtn.Click += GenScriptFromDll;
        // 
        // sourceDbConnStrBox
        // 
        sourceDbConnStrBox.Location = new Point(6, 120);
        sourceDbConnStrBox.Margin = new Padding(2);
        sourceDbConnStrBox.Multiline = true;
        sourceDbConnStrBox.Name = "sourceDbConnStrBox";
        sourceDbConnStrBox.Size = new Size(389, 96);
        sourceDbConnStrBox.TabIndex = 11;
        // 
        // sourceDbConnStrLabel
        // 
        sourceDbConnStrLabel.AutoSize = true;
        sourceDbConnStrLabel.Location = new Point(6, 101);
        sourceDbConnStrLabel.Margin = new Padding(2, 0, 2, 0);
        sourceDbConnStrLabel.Name = "sourceDbConnStrLabel";
        sourceDbConnStrLabel.Size = new Size(137, 15);
        sourceDbConnStrLabel.TabIndex = 10;
        sourceDbConnStrLabel.Text = "sourceDbConnStrLabel";
        // 
        // dalDllPathBox
        // 
        dalDllPathBox.Location = new Point(92, 10);
        dalDllPathBox.Margin = new Padding(2);
        dalDllPathBox.Multiline = true;
        dalDllPathBox.Name = "dalDllPathBox";
        dalDllPathBox.Size = new Size(273, 41);
        dalDllPathBox.TabIndex = 9;
        dalDllPathBox.TextChanged += ModelDllPathBoxChanged;
        // 
        // dalDllLabel
        // 
        dalDllLabel.AutoSize = true;
        dalDllLabel.Location = new Point(20, 22);
        dalDllLabel.Margin = new Padding(2, 0, 2, 0);
        dalDllLabel.Name = "dalDllLabel";
        dalDllLabel.Size = new Size(71, 15);
        dalDllLabel.TabIndex = 0;
        dalDllLabel.Text = "dalDllLabel";
        // 
        // settingTab
        // 
        settingTab.Controls.Add(isTableNameAsLink);
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
        settingTab.Location = new Point(4, 24);
        settingTab.Margin = new Padding(2, 2, 2, 2);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(2, 2, 2, 2);
        settingTab.Size = new Size(606, 218);
        settingTab.TabIndex = 3;
        settingTab.Text = "settingTab";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // customThemelabel
        // 
        customThemelabel.AutoSize = true;
        customThemelabel.Location = new Point(9, 118);
        customThemelabel.Margin = new Padding(2, 0, 2, 0);
        customThemelabel.Name = "customThemelabel";
        customThemelabel.Size = new Size(115, 15);
        customThemelabel.TabIndex = 21;
        customThemelabel.Text = "customThemelabel";
        customThemelabel.DoubleClick += ReloadThemeBinding;
        // 
        // customThemeNameSelect
        // 
        customThemeNameSelect.FormattingEnabled = true;
        customThemeNameSelect.Location = new Point(139, 116);
        customThemeNameSelect.Margin = new Padding(2, 2, 2, 2);
        customThemeNameSelect.Name = "customThemeNameSelect";
        customThemeNameSelect.Size = new Size(175, 23);
        customThemeNameSelect.TabIndex = 20;
        customThemeNameSelect.SelectedIndexChanged += customThemeNameSelectChanged;
        // 
        // modelGenBtnSettingLabel
        // 
        modelGenBtnSettingLabel.AutoSize = true;
        modelGenBtnSettingLabel.Location = new Point(9, 144);
        modelGenBtnSettingLabel.Margin = new Padding(2, 0, 2, 0);
        modelGenBtnSettingLabel.Name = "modelGenBtnSettingLabel";
        modelGenBtnSettingLabel.Size = new Size(156, 15);
        modelGenBtnSettingLabel.TabIndex = 19;
        modelGenBtnSettingLabel.Text = "modelGenBtnSettingLabel";
        // 
        // connSettingLabel
        // 
        connSettingLabel.AutoSize = true;
        connSettingLabel.Location = new Point(9, 6);
        connSettingLabel.Margin = new Padding(2, 0, 2, 0);
        connSettingLabel.Name = "connSettingLabel";
        connSettingLabel.Size = new Size(106, 15);
        connSettingLabel.TabIndex = 17;
        connSettingLabel.Text = "connSettingLabel";
        // 
        // isWordWithToc
        // 
        isWordWithToc.AutoSize = true;
        isWordWithToc.Location = new Point(25, 90);
        isWordWithToc.Margin = new Padding(2);
        isWordWithToc.Name = "isWordWithToc";
        isWordWithToc.Size = new Size(113, 19);
        isWordWithToc.TabIndex = 16;
        isWordWithToc.Text = "isWordWithToc";
        isWordWithToc.UseVisualStyleBackColor = true;
        isWordWithToc.CheckedChanged += isWordWithTocChanged;
        // 
        // isScaleShow
        // 
        isScaleShow.AutoSize = true;
        isScaleShow.Location = new Point(275, 69);
        isScaleShow.Margin = new Padding(2);
        isScaleShow.Name = "isScaleShow";
        isScaleShow.Size = new Size(95, 19);
        isScaleShow.TabIndex = 13;
        isScaleShow.Text = "isScaleShow";
        isScaleShow.UseVisualStyleBackColor = true;
        isScaleShow.CheckedChanged += IsScaleShowChanged;
        // 
        // isPrecisionShow
        // 
        isPrecisionShow.AutoSize = true;
        isPrecisionShow.Location = new Point(182, 69);
        isPrecisionShow.Margin = new Padding(2);
        isPrecisionShow.Name = "isPrecisionShow";
        isPrecisionShow.Size = new Size(115, 19);
        isPrecisionShow.TabIndex = 12;
        isPrecisionShow.Text = "isPrecisionShow";
        isPrecisionShow.UseVisualStyleBackColor = true;
        isPrecisionShow.CheckedChanged += IsPrecisionShowChanged;
        // 
        // isLengthShow
        // 
        isLengthShow.AutoSize = true;
        isLengthShow.Location = new Point(103, 69);
        isLengthShow.Margin = new Padding(2);
        isLengthShow.Name = "isLengthShow";
        isLengthShow.Size = new Size(104, 19);
        isLengthShow.TabIndex = 11;
        isLengthShow.Text = "isLengthShow";
        isLengthShow.UseVisualStyleBackColor = true;
        isLengthShow.CheckedChanged += IsLengthShowChanged;
        // 
        // isNotNullShow
        // 
        isNotNullShow.AutoSize = true;
        isNotNullShow.Checked = true;
        isNotNullShow.CheckState = CheckState.Checked;
        isNotNullShow.Location = new Point(25, 69);
        isNotNullShow.Margin = new Padding(2);
        isNotNullShow.Name = "isNotNullShow";
        isNotNullShow.Size = new Size(110, 19);
        isNotNullShow.TabIndex = 10;
        isNotNullShow.Text = "isNotNullShow";
        isNotNullShow.UseVisualStyleBackColor = true;
        isNotNullShow.CheckedChanged += IsNotNullShowChanged;
        // 
        // isPrimaryKeyShow
        // 
        isPrimaryKeyShow.AutoSize = true;
        isPrimaryKeyShow.Checked = true;
        isPrimaryKeyShow.CheckState = CheckState.Checked;
        isPrimaryKeyShow.Location = new Point(352, 47);
        isPrimaryKeyShow.Margin = new Padding(2);
        isPrimaryKeyShow.Name = "isPrimaryKeyShow";
        isPrimaryKeyShow.Size = new Size(127, 19);
        isPrimaryKeyShow.TabIndex = 9;
        isPrimaryKeyShow.Text = "isPrimaryKeyShow";
        isPrimaryKeyShow.UseVisualStyleBackColor = true;
        isPrimaryKeyShow.CheckedChanged += IsPrimaryKeyShowChanged;
        // 
        // isIdentityShow
        // 
        isIdentityShow.AutoSize = true;
        isIdentityShow.Checked = true;
        isIdentityShow.CheckState = CheckState.Checked;
        isIdentityShow.Location = new Point(275, 47);
        isIdentityShow.Margin = new Padding(2);
        isIdentityShow.Name = "isIdentityShow";
        isIdentityShow.Size = new Size(107, 19);
        isIdentityShow.TabIndex = 8;
        isIdentityShow.Text = "isIdentityShow";
        isIdentityShow.UseVisualStyleBackColor = true;
        isIdentityShow.CheckedChanged += IsIdentityShowChanged;
        // 
        // isDefaultValueShow
        // 
        isDefaultValueShow.AutoSize = true;
        isDefaultValueShow.Checked = true;
        isDefaultValueShow.CheckState = CheckState.Checked;
        isDefaultValueShow.Location = new Point(182, 47);
        isDefaultValueShow.Margin = new Padding(2);
        isDefaultValueShow.Name = "isDefaultValueShow";
        isDefaultValueShow.Size = new Size(138, 19);
        isDefaultValueShow.TabIndex = 7;
        isDefaultValueShow.Text = "isDefaultValueShow";
        isDefaultValueShow.UseVisualStyleBackColor = true;
        isDefaultValueShow.CheckedChanged += IsDefaultValueShowChanged;
        // 
        // isDataTypeShow
        // 
        isDataTypeShow.AutoSize = true;
        isDataTypeShow.Checked = true;
        isDataTypeShow.CheckState = CheckState.Checked;
        isDataTypeShow.Location = new Point(103, 47);
        isDataTypeShow.Margin = new Padding(2);
        isDataTypeShow.Name = "isDataTypeShow";
        isDataTypeShow.Size = new Size(120, 19);
        isDataTypeShow.TabIndex = 6;
        isDataTypeShow.Text = "isDataTypeShow";
        isDataTypeShow.UseVisualStyleBackColor = true;
        isDataTypeShow.CheckedChanged += IsDataTypeShowChanged;
        // 
        // isSortShow
        // 
        isSortShow.AutoSize = true;
        isSortShow.Checked = true;
        isSortShow.CheckState = CheckState.Checked;
        isSortShow.Location = new Point(25, 47);
        isSortShow.Margin = new Padding(2);
        isSortShow.Name = "isSortShow";
        isSortShow.Size = new Size(88, 19);
        isSortShow.TabIndex = 5;
        isSortShow.Text = "isSortShow";
        isSortShow.UseVisualStyleBackColor = true;
        isSortShow.CheckedChanged += IsSortShowChanged;
        // 
        // isColumnDescriptionShow
        // 
        isColumnDescriptionShow.AutoSize = true;
        isColumnDescriptionShow.Location = new Point(352, 69);
        isColumnDescriptionShow.Margin = new Padding(2);
        isColumnDescriptionShow.Name = "isColumnDescriptionShow";
        isColumnDescriptionShow.Size = new Size(173, 19);
        isColumnDescriptionShow.TabIndex = 4;
        isColumnDescriptionShow.Text = "isColumnDescriptionShow";
        isColumnDescriptionShow.UseVisualStyleBackColor = true;
        isColumnDescriptionShow.CheckedChanged += IsColumnDescriptionShowChanged;
        // 
        // isTableDescriptionShow
        // 
        isTableDescriptionShow.AutoSize = true;
        isTableDescriptionShow.Location = new Point(25, 26);
        isTableDescriptionShow.Margin = new Padding(2);
        isTableDescriptionShow.Name = "isTableDescriptionShow";
        isTableDescriptionShow.Size = new Size(161, 19);
        isTableDescriptionShow.TabIndex = 3;
        isTableDescriptionShow.Text = "isTableDescriptionShow";
        isTableDescriptionShow.UseVisualStyleBackColor = true;
        isTableDescriptionShow.CheckedChanged += IsTableDescriptionShowChanged;
        // 
        // isSummary
        // 
        isSummary.AutoSize = true;
        isSummary.Location = new Point(29, 168);
        isSummary.Margin = new Padding(2);
        isSummary.Name = "isSummary";
        isSummary.Size = new Size(87, 19);
        isSummary.TabIndex = 11;
        isSummary.Text = "isSummary";
        isSummary.UseVisualStyleBackColor = true;
        isSummary.CheckedChanged += isSummaryChanged;
        // 
        // isKey
        // 
        isKey.AutoSize = true;
        isKey.Location = new Point(255, 168);
        isKey.Margin = new Padding(2);
        isKey.Name = "isKey";
        isKey.Size = new Size(54, 19);
        isKey.TabIndex = 10;
        isKey.Text = "isKey";
        isKey.UseVisualStyleBackColor = true;
        isKey.CheckedChanged += isKeyChanged;
        // 
        // isRequired
        // 
        isRequired.AutoSize = true;
        isRequired.Location = new Point(179, 168);
        isRequired.Margin = new Padding(2);
        isRequired.Name = "isRequired";
        isRequired.Size = new Size(86, 19);
        isRequired.TabIndex = 9;
        isRequired.Text = "isRequired";
        isRequired.UseVisualStyleBackColor = true;
        isRequired.CheckedChanged += IsRequiredChanged;
        // 
        // isDisplay
        // 
        isDisplay.AutoSize = true;
        isDisplay.Location = new Point(107, 168);
        isDisplay.Margin = new Padding(2);
        isDisplay.Name = "isDisplay";
        isDisplay.Size = new Size(75, 19);
        isDisplay.TabIndex = 8;
        isDisplay.Text = "isDisplay";
        isDisplay.UseVisualStyleBackColor = true;
        isDisplay.CheckedChanged += IsDisplayChanged;
        // 
        // resetBtn
        // 
        resetBtn.Location = new Point(15, 193);
        resetBtn.Margin = new Padding(2);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(72, 22);
        resetBtn.TabIndex = 15;
        resetBtn.Text = "resetBtn";
        resetBtn.UseVisualStyleBackColor = true;
        resetBtn.Click += resetAllSetting;
        // 
        // downloadExcelStyleTemplateBtn
        // 
        downloadExcelStyleTemplateBtn.Location = new Point(317, 116);
        downloadExcelStyleTemplateBtn.Margin = new Padding(2);
        downloadExcelStyleTemplateBtn.Name = "downloadExcelStyleTemplateBtn";
        downloadExcelStyleTemplateBtn.Size = new Size(205, 22);
        downloadExcelStyleTemplateBtn.TabIndex = 18;
        downloadExcelStyleTemplateBtn.Text = "downloadExcelStyleTemplateBtn";
        downloadExcelStyleTemplateBtn.UseVisualStyleBackColor = true;
        downloadExcelStyleTemplateBtn.Click += downloadExcelStyleTemplate;
        // 
        // languageTab
        // 
        languageTab.Controls.Add(languageSelect);
        languageTab.Location = new Point(4, 24);
        languageTab.Margin = new Padding(2);
        languageTab.Name = "languageTab";
        languageTab.Padding = new Padding(2);
        languageTab.Size = new Size(606, 218);
        languageTab.TabIndex = 4;
        languageTab.Text = "languageTab";
        languageTab.UseVisualStyleBackColor = true;
        // 
        // languageSelect
        // 
        languageSelect.FormattingEnabled = true;
        languageSelect.Location = new Point(17, 13);
        languageSelect.Margin = new Padding(2, 2, 2, 2);
        languageSelect.Name = "languageSelect";
        languageSelect.Size = new Size(128, 23);
        languageSelect.TabIndex = 21;
        languageSelect.SelectedIndexChanged += languageSelectChanged;
        // 
        // errorTextBox
        // 
        errorTextBox.BackColor = SystemColors.Control;
        errorTextBox.BorderStyle = BorderStyle.None;
        errorTextBox.Location = new Point(5, 251);
        errorTextBox.Margin = new Padding(2);
        errorTextBox.Multiline = true;
        errorTextBox.Name = "errorTextBox";
        errorTextBox.ReadOnly = true;
        errorTextBox.Size = new Size(406, 58);
        errorTextBox.TabIndex = 8;
        errorTextBox.DoubleClick += ErrorTextClearDoubleClick;
        // 
        // isTableNameAsLink
        // 
        isTableNameAsLink.AutoSize = true;
        isTableNameAsLink.Checked = true;
        isTableNameAsLink.CheckState = CheckState.Checked;
        isTableNameAsLink.Location = new Point(182, 26);
        isTableNameAsLink.Margin = new Padding(2);
        isTableNameAsLink.Name = "isTableNameAsLink";
        isTableNameAsLink.Size = new Size(136, 19);
        isTableNameAsLink.TabIndex = 22;
        isTableNameAsLink.Text = "isTableNameAsLink";
        isTableNameAsLink.UseVisualStyleBackColor = true;
        isTableNameAsLink.CheckedChanged += isTableNameAsLinkChanged;
        // 
        // DbToolForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(610, 315);
        Controls.Add(errorTextBox);
        Controls.Add(tabControl1);
        Margin = new Padding(2);
        Name = "DbToolForm";
        Load += DbToolFormLoad;
        tabControl1.ResumeLayout(false);
        connToolTab.ResumeLayout(false);
        connToolTab.PerformLayout();
        schmaToolTab.ResumeLayout(false);
        modelToolTab.ResumeLayout(false);
        modelToolTab.PerformLayout();
        scriptGenTab.ResumeLayout(false);
        scriptGenTab.PerformLayout();
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
    private TextBox namespaceBox;
    private Label nameSpaceLabel;
    private TabPage scriptGenTab;
    private Label dalDllLabel;
    private TextBox dalDllPathBox;
    private TextBox sourceDbConnStrBox;
    private Label sourceDbConnStrLabel;
    private Button upDataDBSchemaBtn;
    private Button genScriptFromDllBtn;
    private Button sourceDbConnTestBtn;
    private TextBox dbContextBox;
    private Label dbContextLabel;
    private CheckBox isTableNameAsLink;
}