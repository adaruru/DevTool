// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using DbTool.Properties;

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
        connHistoryLabel = new Label();
        connHiatorySelect = new ComboBox();
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
        clearConnHistoryBtn = new Button();
        isTableNameAsLink = new CheckBox();
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
        demoCommBtn.Location = new Point(314, 212);
        demoCommBtn.Name = "demoCommBtn";
        demoCommBtn.Size = new Size(228, 34);
        demoCommBtn.TabIndex = 0;
        demoCommBtn.Text = "demoCommBtn";
        demoCommBtn.UseVisualStyleBackColor = true;
        demoCommBtn.Click += demoCommBtnEvent;
        // 
        // downloadSchemaBtn
        // 
        downloadSchemaBtn.Location = new Point(25, 20);
        downloadSchemaBtn.Name = "downloadSchemaBtn";
        downloadSchemaBtn.Size = new Size(365, 34);
        downloadSchemaBtn.TabIndex = 1;
        downloadSchemaBtn.Text = "downloadSchemaBtn";
        downloadSchemaBtn.UseVisualStyleBackColor = true;
        downloadSchemaBtn.Click += exportSchemaEvent;
        // 
        // connStrBox
        // 
        connStrBox.Location = new Point(30, 55);
        connStrBox.Multiline = true;
        connStrBox.Name = "connStrBox";
        connStrBox.Size = new Size(529, 134);
        connStrBox.TabIndex = 2;
        connStrBox.Text = "Data Source=MSI;Initial Catalog=MvcCoreTraining_Amanda;user id=sa;password=ruru";
        connStrBox.TextChanged += connStrBoxEvent;
        // 
        // connStrLabel
        // 
        connStrLabel.AutoSize = true;
        connStrLabel.Location = new Point(25, 18);
        connStrLabel.Name = "connStrLabel";
        connStrLabel.Size = new Size(121, 23);
        connStrLabel.TabIndex = 3;
        connStrLabel.Text = "connStrLabel";
        // 
        // dbTestBtn
        // 
        dbTestBtn.Location = new Point(30, 212);
        dbTestBtn.Name = "dbTestBtn";
        dbTestBtn.Size = new Size(212, 34);
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
        tabControl1.Location = new Point(0, 3);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(965, 377);
        tabControl1.TabIndex = 7;
        tabControl1.SelectedIndexChanged += tabControlChanged;
        // 
        // connToolTab
        // 
        connToolTab.Controls.Add(connHistoryLabel);
        connToolTab.Controls.Add(connHiatorySelect);
        connToolTab.Controls.Add(connStrLabel);
        connToolTab.Controls.Add(dbTestBtn);
        connToolTab.Controls.Add(connStrBox);
        connToolTab.Controls.Add(demoCommBtn);
        connToolTab.Location = new Point(4, 32);
        connToolTab.Name = "connToolTab";
        connToolTab.Padding = new Padding(3);
        connToolTab.Size = new Size(957, 341);
        connToolTab.TabIndex = 0;
        connToolTab.Text = "connToolTab";
        connToolTab.UseVisualStyleBackColor = true;
        // 
        // connHistoryLabel
        // 
        connHistoryLabel.AutoSize = true;
        connHistoryLabel.Location = new Point(30, 276);
        connHistoryLabel.Name = "connHistoryLabel";
        connHistoryLabel.Size = new Size(158, 23);
        connHistoryLabel.TabIndex = 23;
        connHistoryLabel.Text = "connHistoryLabel";
        // 
        // connHiatorySelect
        // 
        connHiatorySelect.FormattingEnabled = true;
        connHiatorySelect.Location = new Point(151, 273);
        connHiatorySelect.Name = "connHiatorySelect";
        connHiatorySelect.Size = new Size(739, 31);
        connHiatorySelect.TabIndex = 22;
        connHiatorySelect.SelectedIndexChanged += connHiatorySelectedIndexChanged;
        // 
        // schmaToolTab
        // 
        schmaToolTab.Controls.Add(downloadTemplateBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordPerTableBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordBtn);
        schmaToolTab.Controls.Add(importDescriptionBtn);
        schmaToolTab.Controls.Add(downloadSchemaBtn);
        schmaToolTab.Location = new Point(4, 32);
        schmaToolTab.Name = "schmaToolTab";
        schmaToolTab.Padding = new Padding(3);
        schmaToolTab.Size = new Size(957, 341);
        schmaToolTab.TabIndex = 1;
        schmaToolTab.Text = "schmaToolTab";
        schmaToolTab.UseVisualStyleBackColor = true;
        // 
        // downloadTemplateBtn
        // 
        downloadTemplateBtn.Location = new Point(25, 198);
        downloadTemplateBtn.Name = "downloadTemplateBtn";
        downloadTemplateBtn.Size = new Size(542, 34);
        downloadTemplateBtn.TabIndex = 2;
        downloadTemplateBtn.Text = "downloadTemplateBtn";
        downloadTemplateBtn.UseVisualStyleBackColor = true;
        downloadTemplateBtn.Click += exportSchemaEvent;
        // 
        // downloadSchemaWordPerTableBtn
        // 
        downloadSchemaWordPerTableBtn.Location = new Point(25, 138);
        downloadSchemaWordPerTableBtn.Name = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.Size = new Size(544, 34);
        downloadSchemaWordPerTableBtn.TabIndex = 17;
        downloadSchemaWordPerTableBtn.Text = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordPerTableBtn.Click += exportSchemaWordBtnClick;
        // 
        // downloadSchemaWordBtn
        // 
        downloadSchemaWordBtn.Location = new Point(25, 80);
        downloadSchemaWordBtn.Name = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.Size = new Size(363, 34);
        downloadSchemaWordBtn.TabIndex = 15;
        downloadSchemaWordBtn.Text = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordBtn.Click += exportSchemaWordBtnClick;
        // 
        // importDescriptionBtn
        // 
        importDescriptionBtn.Location = new Point(25, 256);
        importDescriptionBtn.Name = "importDescriptionBtn";
        importDescriptionBtn.Size = new Size(542, 34);
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
        modelToolTab.Location = new Point(4, 32);
        modelToolTab.Name = "modelToolTab";
        modelToolTab.Padding = new Padding(3);
        modelToolTab.Size = new Size(957, 341);
        modelToolTab.TabIndex = 2;
        modelToolTab.Text = "modelToolTab";
        modelToolTab.UseVisualStyleBackColor = true;
        // 
        // nameSpaceLabel
        // 
        nameSpaceLabel.AutoSize = true;
        nameSpaceLabel.Location = new Point(27, 72);
        nameSpaceLabel.Name = "nameSpaceLabel";
        nameSpaceLabel.Size = new Size(153, 23);
        nameSpaceLabel.TabIndex = 9;
        nameSpaceLabel.Text = "nameSpaceLabel";
        // 
        // namespaceBox
        // 
        namespaceBox.Location = new Point(184, 71);
        namespaceBox.Multiline = true;
        namespaceBox.Name = "namespaceBox";
        namespaceBox.Size = new Size(356, 36);
        namespaceBox.TabIndex = 8;
        namespaceBox.TextChanged += namespaceBoxChanged;
        // 
        // modelGenBtn
        // 
        modelGenBtn.Location = new Point(20, 23);
        modelGenBtn.Name = "modelGenBtn";
        modelGenBtn.Size = new Size(220, 32);
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
        scriptGenTab.Location = new Point(4, 32);
        scriptGenTab.Name = "scriptGenTab";
        scriptGenTab.Padding = new Padding(3);
        scriptGenTab.Size = new Size(957, 341);
        scriptGenTab.TabIndex = 5;
        scriptGenTab.Text = "scriptGenTab";
        scriptGenTab.UseVisualStyleBackColor = true;
        // 
        // dbContextLabel
        // 
        dbContextLabel.AutoSize = true;
        dbContextLabel.Location = new Point(39, 97);
        dbContextLabel.Name = "dbContextLabel";
        dbContextLabel.Size = new Size(99, 23);
        dbContextLabel.TabIndex = 16;
        dbContextLabel.Text = "dbContext";
        // 
        // dbContextBox
        // 
        dbContextBox.Location = new Point(145, 94);
        dbContextBox.Multiline = true;
        dbContextBox.Name = "dbContextBox";
        dbContextBox.Size = new Size(427, 35);
        dbContextBox.TabIndex = 15;
        dbContextBox.TextChanged += dbContextBoxChanged;
        // 
        // sourceDbConnTestBtn
        // 
        sourceDbConnTestBtn.Location = new Point(625, 253);
        sourceDbConnTestBtn.Name = "sourceDbConnTestBtn";
        sourceDbConnTestBtn.Size = new Size(160, 35);
        sourceDbConnTestBtn.TabIndex = 14;
        sourceDbConnTestBtn.Text = "sourceDbConnTestBtn";
        sourceDbConnTestBtn.UseVisualStyleBackColor = true;
        sourceDbConnTestBtn.Click += SourceDbConnTestBtnClick;
        // 
        // upDataDBSchemaBtn
        // 
        upDataDBSchemaBtn.Location = new Point(625, 296);
        upDataDBSchemaBtn.Name = "upDataDBSchemaBtn";
        upDataDBSchemaBtn.Size = new Size(313, 35);
        upDataDBSchemaBtn.TabIndex = 13;
        upDataDBSchemaBtn.Text = "upDataDBSchemaBtn";
        upDataDBSchemaBtn.UseVisualStyleBackColor = true;
        upDataDBSchemaBtn.Click += UpDataDBSchemaBtnClick;
        // 
        // genScriptFromDllBtn
        // 
        genScriptFromDllBtn.Location = new Point(578, 90);
        genScriptFromDllBtn.Name = "genScriptFromDllBtn";
        genScriptFromDllBtn.Size = new Size(283, 35);
        genScriptFromDllBtn.TabIndex = 12;
        genScriptFromDllBtn.Text = "genScriptFromDllBtn";
        genScriptFromDllBtn.UseVisualStyleBackColor = true;
        genScriptFromDllBtn.Click += GenScriptFromDll;
        // 
        // sourceDbConnStrBox
        // 
        sourceDbConnStrBox.Location = new Point(9, 184);
        sourceDbConnStrBox.Multiline = true;
        sourceDbConnStrBox.Name = "sourceDbConnStrBox";
        sourceDbConnStrBox.Size = new Size(609, 145);
        sourceDbConnStrBox.TabIndex = 11;
        // 
        // sourceDbConnStrLabel
        // 
        sourceDbConnStrLabel.AutoSize = true;
        sourceDbConnStrLabel.Location = new Point(9, 155);
        sourceDbConnStrLabel.Name = "sourceDbConnStrLabel";
        sourceDbConnStrLabel.Size = new Size(205, 23);
        sourceDbConnStrLabel.TabIndex = 10;
        sourceDbConnStrLabel.Text = "sourceDbConnStrLabel";
        // 
        // dalDllPathBox
        // 
        dalDllPathBox.Location = new Point(145, 15);
        dalDllPathBox.Multiline = true;
        dalDllPathBox.Name = "dalDllPathBox";
        dalDllPathBox.Size = new Size(427, 61);
        dalDllPathBox.TabIndex = 9;
        dalDllPathBox.TextChanged += ModelDllPathBoxChanged;
        // 
        // dalDllLabel
        // 
        dalDllLabel.AutoSize = true;
        dalDllLabel.Location = new Point(31, 34);
        dalDllLabel.Name = "dalDllLabel";
        dalDllLabel.Size = new Size(105, 23);
        dalDllLabel.TabIndex = 0;
        dalDllLabel.Text = "dalDllLabel";
        // 
        // settingTab
        // 
        settingTab.Controls.Add(clearConnHistoryBtn);
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
        settingTab.Location = new Point(4, 32);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(3);
        settingTab.Size = new Size(957, 341);
        settingTab.TabIndex = 3;
        settingTab.Text = "settingTab";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // clearConnHistoryBtn
        // 
        clearConnHistoryBtn.Location = new Point(145, 296);
        clearConnHistoryBtn.Name = "clearConnHistoryBtn";
        clearConnHistoryBtn.Text = "clearConnHistoryBtn";
        clearConnHistoryBtn.Size = new Size(193, 34);
        clearConnHistoryBtn.TabIndex = 23;
        clearConnHistoryBtn.UseVisualStyleBackColor = true;
        clearConnHistoryBtn.Click += ClearConnHistoryBtnClick;
        // 
        // isTableNameAsLink
        // 
        isTableNameAsLink.AutoSize = true;
        isTableNameAsLink.Checked = true;
        isTableNameAsLink.CheckState = CheckState.Checked;
        isTableNameAsLink.Location = new Point(286, 40);
        isTableNameAsLink.Name = "isTableNameAsLink";
        isTableNameAsLink.Size = new Size(202, 27);
        isTableNameAsLink.TabIndex = 22;
        isTableNameAsLink.Text = "isTableNameAsLink";
        isTableNameAsLink.UseVisualStyleBackColor = true;
        isTableNameAsLink.CheckedChanged += isTableNameAsLinkChanged;
        // 
        // customThemelabel
        // 
        customThemelabel.AutoSize = true;
        customThemelabel.Location = new Point(14, 181);
        customThemelabel.Name = "customThemelabel";
        customThemelabel.Size = new Size(172, 23);
        customThemelabel.TabIndex = 21;
        customThemelabel.Text = "customThemelabel";
        customThemelabel.DoubleClick += ReloadThemeBinding;
        // 
        // customThemeNameSelect
        // 
        customThemeNameSelect.FormattingEnabled = true;
        customThemeNameSelect.Location = new Point(218, 178);
        customThemeNameSelect.Name = "customThemeNameSelect";
        customThemeNameSelect.Size = new Size(273, 31);
        customThemeNameSelect.TabIndex = 20;
        customThemeNameSelect.SelectedIndexChanged += customThemeNameSelectChanged;
        // 
        // modelGenBtnSettingLabel
        // 
        modelGenBtnSettingLabel.AutoSize = true;
        modelGenBtnSettingLabel.Location = new Point(14, 221);
        modelGenBtnSettingLabel.Name = "modelGenBtnSettingLabel";
        modelGenBtnSettingLabel.Size = new Size(233, 23);
        modelGenBtnSettingLabel.TabIndex = 19;
        modelGenBtnSettingLabel.Text = "modelGenBtnSettingLabel";
        // 
        // connSettingLabel
        // 
        connSettingLabel.AutoSize = true;
        connSettingLabel.Location = new Point(14, 9);
        connSettingLabel.Name = "connSettingLabel";
        connSettingLabel.Size = new Size(158, 23);
        connSettingLabel.TabIndex = 17;
        connSettingLabel.Text = "connSettingLabel";
        // 
        // isWordWithToc
        // 
        isWordWithToc.AutoSize = true;
        isWordWithToc.Location = new Point(39, 138);
        isWordWithToc.Name = "isWordWithToc";
        isWordWithToc.Size = new Size(167, 27);
        isWordWithToc.TabIndex = 16;
        isWordWithToc.Text = "isWordWithToc";
        isWordWithToc.UseVisualStyleBackColor = true;
        isWordWithToc.CheckedChanged += isWordWithTocChanged;
        // 
        // isScaleShow
        // 
        isScaleShow.AutoSize = true;
        isScaleShow.Location = new Point(432, 106);
        isScaleShow.Name = "isScaleShow";
        isScaleShow.Size = new Size(139, 27);
        isScaleShow.TabIndex = 13;
        isScaleShow.Text = "isScaleShow";
        isScaleShow.UseVisualStyleBackColor = true;
        isScaleShow.CheckedChanged += IsScaleShowChanged;
        // 
        // isPrecisionShow
        // 
        isPrecisionShow.AutoSize = true;
        isPrecisionShow.Location = new Point(286, 106);
        isPrecisionShow.Name = "isPrecisionShow";
        isPrecisionShow.Size = new Size(172, 27);
        isPrecisionShow.TabIndex = 12;
        isPrecisionShow.Text = "isPrecisionShow";
        isPrecisionShow.UseVisualStyleBackColor = true;
        isPrecisionShow.CheckedChanged += IsPrecisionShowChanged;
        // 
        // isLengthShow
        // 
        isLengthShow.AutoSize = true;
        isLengthShow.Location = new Point(162, 106);
        isLengthShow.Name = "isLengthShow";
        isLengthShow.Size = new Size(154, 27);
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
        isNotNullShow.Location = new Point(39, 106);
        isNotNullShow.Name = "isNotNullShow";
        isNotNullShow.Size = new Size(164, 27);
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
        isPrimaryKeyShow.Location = new Point(553, 72);
        isPrimaryKeyShow.Name = "isPrimaryKeyShow";
        isPrimaryKeyShow.Size = new Size(191, 27);
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
        isIdentityShow.Location = new Point(432, 72);
        isIdentityShow.Name = "isIdentityShow";
        isIdentityShow.Size = new Size(160, 27);
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
        isDefaultValueShow.Location = new Point(286, 72);
        isDefaultValueShow.Name = "isDefaultValueShow";
        isDefaultValueShow.Size = new Size(206, 27);
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
        isDataTypeShow.Location = new Point(162, 72);
        isDataTypeShow.Name = "isDataTypeShow";
        isDataTypeShow.Size = new Size(176, 27);
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
        isSortShow.Location = new Point(39, 72);
        isSortShow.Name = "isSortShow";
        isSortShow.Size = new Size(130, 27);
        isSortShow.TabIndex = 5;
        isSortShow.Text = "isSortShow";
        isSortShow.UseVisualStyleBackColor = true;
        isSortShow.CheckedChanged += IsSortShowChanged;
        // 
        // isColumnDescriptionShow
        // 
        isColumnDescriptionShow.AutoSize = true;
        isColumnDescriptionShow.Location = new Point(553, 106);
        isColumnDescriptionShow.Name = "isColumnDescriptionShow";
        isColumnDescriptionShow.Size = new Size(260, 27);
        isColumnDescriptionShow.TabIndex = 4;
        isColumnDescriptionShow.Text = "isColumnDescriptionShow";
        isColumnDescriptionShow.UseVisualStyleBackColor = true;
        isColumnDescriptionShow.CheckedChanged += IsColumnDescriptionShowChanged;
        // 
        // isTableDescriptionShow
        // 
        isTableDescriptionShow.AutoSize = true;
        isTableDescriptionShow.Location = new Point(39, 40);
        isTableDescriptionShow.Name = "isTableDescriptionShow";
        isTableDescriptionShow.Size = new Size(239, 27);
        isTableDescriptionShow.TabIndex = 3;
        isTableDescriptionShow.Text = "isTableDescriptionShow";
        isTableDescriptionShow.UseVisualStyleBackColor = true;
        isTableDescriptionShow.CheckedChanged += IsTableDescriptionShowChanged;
        // 
        // isSummary
        // 
        isSummary.AutoSize = true;
        isSummary.Location = new Point(46, 258);
        isSummary.Name = "isSummary";
        isSummary.Size = new Size(130, 27);
        isSummary.TabIndex = 11;
        isSummary.Text = "isSummary";
        isSummary.UseVisualStyleBackColor = true;
        isSummary.CheckedChanged += isSummaryChanged;
        // 
        // isKey
        // 
        isKey.AutoSize = true;
        isKey.Location = new Point(401, 258);
        isKey.Name = "isKey";
        isKey.Size = new Size(79, 27);
        isKey.TabIndex = 10;
        isKey.Text = "isKey";
        isKey.UseVisualStyleBackColor = true;
        isKey.CheckedChanged += isKeyChanged;
        // 
        // isRequired
        // 
        isRequired.AutoSize = true;
        isRequired.Location = new Point(281, 258);
        isRequired.Name = "isRequired";
        isRequired.Size = new Size(126, 27);
        isRequired.TabIndex = 9;
        isRequired.Text = "isRequired";
        isRequired.UseVisualStyleBackColor = true;
        isRequired.CheckedChanged += IsRequiredChanged;
        // 
        // isDisplay
        // 
        isDisplay.AutoSize = true;
        isDisplay.Location = new Point(168, 258);
        isDisplay.Name = "isDisplay";
        isDisplay.Size = new Size(111, 27);
        isDisplay.TabIndex = 8;
        isDisplay.Text = "isDisplay";
        isDisplay.UseVisualStyleBackColor = true;
        isDisplay.CheckedChanged += IsDisplayChanged;
        // 
        // resetBtn
        // 
        resetBtn.Location = new Point(24, 296);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(113, 34);
        resetBtn.TabIndex = 15;
        resetBtn.Text = "resetBtn";
        resetBtn.UseVisualStyleBackColor = true;
        resetBtn.Click += resetAllSetting;
        // 
        // downloadExcelStyleTemplateBtn
        // 
        downloadExcelStyleTemplateBtn.Location = new Point(498, 178);
        downloadExcelStyleTemplateBtn.Name = "downloadExcelStyleTemplateBtn";
        downloadExcelStyleTemplateBtn.Size = new Size(322, 34);
        downloadExcelStyleTemplateBtn.TabIndex = 18;
        downloadExcelStyleTemplateBtn.Text = "downloadExcelStyleTemplateBtn";
        downloadExcelStyleTemplateBtn.UseVisualStyleBackColor = true;
        downloadExcelStyleTemplateBtn.Click += downloadExcelStyleTemplate;
        // 
        // languageTab
        // 
        languageTab.Controls.Add(languageSelect);
        languageTab.Location = new Point(4, 32);
        languageTab.Name = "languageTab";
        languageTab.Padding = new Padding(3);
        languageTab.Size = new Size(957, 341);
        languageTab.TabIndex = 4;
        languageTab.Text = "languageTab";
        languageTab.UseVisualStyleBackColor = true;
        // 
        // languageSelect
        // 
        languageSelect.FormattingEnabled = true;
        languageSelect.Location = new Point(27, 20);
        languageSelect.Name = "languageSelect";
        languageSelect.Size = new Size(199, 31);
        languageSelect.TabIndex = 21;
        languageSelect.SelectedIndexChanged += languageSelectChanged;
        // 
        // errorTextBox
        // 
        errorTextBox.BackColor = SystemColors.Control;
        errorTextBox.BorderStyle = BorderStyle.None;
        errorTextBox.Location = new Point(8, 385);
        errorTextBox.Multiline = true;
        errorTextBox.Name = "errorTextBox";
        errorTextBox.ReadOnly = true;
        errorTextBox.Size = new Size(638, 89);
        errorTextBox.TabIndex = 8;
        errorTextBox.DoubleClick += ErrorTextClearDoubleClick;
        // 
        // DbToolForm
        // 
        AutoScaleDimensions = new SizeF(11F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(959, 483);
        Controls.Add(errorTextBox);
        Controls.Add(tabControl1);
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
    private Label connHistoryLabel;
    private ComboBox connHiatorySelect;
    private Button clearConnHistoryBtn;
}