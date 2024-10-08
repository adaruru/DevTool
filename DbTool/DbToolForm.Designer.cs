﻿// DevTool 1.1 
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
        demoCommBtn.Location = new Point(257, 175);
        demoCommBtn.Margin = new Padding(2);
        demoCommBtn.Name = "demoCommBtn";
        demoCommBtn.Size = new Size(186, 28);
        demoCommBtn.TabIndex = 0;
        demoCommBtn.Text = "demoCommBtn";
        demoCommBtn.UseVisualStyleBackColor = true;
        demoCommBtn.Click += demoCommBtnEvent;
        // 
        // downloadSchemaBtn
        // 
        downloadSchemaBtn.Location = new Point(20, 17);
        downloadSchemaBtn.Margin = new Padding(2);
        downloadSchemaBtn.Name = "downloadSchemaBtn";
        downloadSchemaBtn.Size = new Size(298, 28);
        downloadSchemaBtn.TabIndex = 1;
        downloadSchemaBtn.Text = "downloadSchemaBtn";
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
        connStrLabel.Size = new Size(100, 19);
        connStrLabel.TabIndex = 3;
        connStrLabel.Text = "connStrLabel";
        // 
        // dbTestBtn
        // 
        dbTestBtn.Location = new Point(24, 175);
        dbTestBtn.Margin = new Padding(2);
        dbTestBtn.Name = "dbTestBtn";
        dbTestBtn.Size = new Size(173, 28);
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
        tabControl1.Size = new Size(790, 312);
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
        connToolTab.Size = new Size(782, 280);
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
        schmaToolTab.Location = new Point(4, 28);
        schmaToolTab.Margin = new Padding(2);
        schmaToolTab.Name = "schmaToolTab";
        schmaToolTab.Padding = new Padding(2);
        schmaToolTab.Size = new Size(782, 280);
        schmaToolTab.TabIndex = 1;
        schmaToolTab.Text = "schmaToolTab";
        schmaToolTab.UseVisualStyleBackColor = true;
        // 
        // downloadTemplateBtn
        // 
        downloadTemplateBtn.Location = new Point(21, 163);
        downloadTemplateBtn.Margin = new Padding(2);
        downloadTemplateBtn.Name = "downloadTemplateBtn";
        downloadTemplateBtn.Size = new Size(444, 28);
        downloadTemplateBtn.TabIndex = 2;
        downloadTemplateBtn.Text = "downloadTemplateBtn";
        downloadTemplateBtn.UseVisualStyleBackColor = true;
        downloadTemplateBtn.Click += exportSchemaEvent;
        // 
        // downloadSchemaWordPerTableBtn
        // 
        downloadSchemaWordPerTableBtn.Location = new Point(20, 114);
        downloadSchemaWordPerTableBtn.Margin = new Padding(2);
        downloadSchemaWordPerTableBtn.Name = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.Size = new Size(445, 28);
        downloadSchemaWordPerTableBtn.TabIndex = 17;
        downloadSchemaWordPerTableBtn.Text = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordPerTableBtn.Click += exportSchemaWordBtnClick;
        // 
        // downloadSchemaWordBtn
        // 
        downloadSchemaWordBtn.Location = new Point(21, 66);
        downloadSchemaWordBtn.Margin = new Padding(2);
        downloadSchemaWordBtn.Name = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.Size = new Size(297, 28);
        downloadSchemaWordBtn.TabIndex = 15;
        downloadSchemaWordBtn.Text = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordBtn.Click += exportSchemaWordBtnClick;
        // 
        // importDescriptionBtn
        // 
        importDescriptionBtn.Location = new Point(21, 211);
        importDescriptionBtn.Margin = new Padding(2);
        importDescriptionBtn.Name = "importDescriptionBtn";
        importDescriptionBtn.Size = new Size(444, 28);
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
        modelToolTab.Location = new Point(4, 28);
        modelToolTab.Margin = new Padding(2);
        modelToolTab.Name = "modelToolTab";
        modelToolTab.Padding = new Padding(2);
        modelToolTab.Size = new Size(782, 280);
        modelToolTab.TabIndex = 2;
        modelToolTab.Text = "modelToolTab";
        modelToolTab.UseVisualStyleBackColor = true;
        // 
        // nameSpaceLabel
        // 
        nameSpaceLabel.AutoSize = true;
        nameSpaceLabel.Location = new Point(22, 59);
        nameSpaceLabel.Name = "nameSpaceLabel";
        nameSpaceLabel.Size = new Size(126, 19);
        nameSpaceLabel.TabIndex = 9;
        nameSpaceLabel.Text = "nameSpaceLabel";
        // 
        // namespaceBox
        // 
        namespaceBox.Location = new Point(151, 58);
        namespaceBox.Margin = new Padding(2);
        namespaceBox.Multiline = true;
        namespaceBox.Name = "namespaceBox";
        namespaceBox.Size = new Size(292, 30);
        namespaceBox.TabIndex = 8;
        namespaceBox.TextChanged += namespaceBoxChanged;
        // 
        // modelGenBtn
        // 
        modelGenBtn.Location = new Point(17, 19);
        modelGenBtn.Margin = new Padding(2);
        modelGenBtn.Name = "modelGenBtn";
        modelGenBtn.Size = new Size(180, 26);
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
        scriptGenTab.Location = new Point(4, 28);
        scriptGenTab.Name = "scriptGenTab";
        scriptGenTab.Padding = new Padding(3);
        scriptGenTab.Size = new Size(782, 280);
        scriptGenTab.TabIndex = 5;
        scriptGenTab.Text = "scriptGenTab";
        scriptGenTab.UseVisualStyleBackColor = true;
        // 
        // dbContextLabel
        // 
        dbContextLabel.AutoSize = true;
        dbContextLabel.Location = new Point(32, 80);
        dbContextLabel.Name = "dbContextLabel";
        dbContextLabel.Size = new Size(81, 19);
        dbContextLabel.TabIndex = 16;
        dbContextLabel.Text = "dbContext";
        // 
        // dbContextBox
        // 
        dbContextBox.Location = new Point(118, 77);
        dbContextBox.Margin = new Padding(2);
        dbContextBox.Multiline = true;
        dbContextBox.Name = "dbContextBox";
        dbContextBox.Size = new Size(350, 29);
        dbContextBox.TabIndex = 15;
        dbContextBox.TextChanged += dbContextBoxChanged;
        // 
        // sourceDbConnTestBtn
        // 
        sourceDbConnTestBtn.Location = new Point(512, 209);
        sourceDbConnTestBtn.Name = "sourceDbConnTestBtn";
        sourceDbConnTestBtn.Size = new Size(131, 29);
        sourceDbConnTestBtn.TabIndex = 14;
        sourceDbConnTestBtn.Text = "sourceDbConnTestBtn";
        sourceDbConnTestBtn.UseVisualStyleBackColor = true;
        sourceDbConnTestBtn.Click += SourceDbConnTestBtnClick;
        // 
        // upDataDBSchemaBtn
        // 
        upDataDBSchemaBtn.Location = new Point(512, 244);
        upDataDBSchemaBtn.Name = "upDataDBSchemaBtn";
        upDataDBSchemaBtn.Size = new Size(256, 29);
        upDataDBSchemaBtn.TabIndex = 13;
        upDataDBSchemaBtn.Text = "upDataDBSchemaBtn";
        upDataDBSchemaBtn.UseVisualStyleBackColor = true;
        upDataDBSchemaBtn.Click += UpDataDBSchemaBtnClick;
        // 
        // genScriptFromDllBtn
        // 
        genScriptFromDllBtn.Location = new Point(473, 75);
        genScriptFromDllBtn.Name = "genScriptFromDllBtn";
        genScriptFromDllBtn.Size = new Size(232, 29);
        genScriptFromDllBtn.TabIndex = 12;
        genScriptFromDllBtn.Text = "genScriptFromDllBtn";
        genScriptFromDllBtn.UseVisualStyleBackColor = true;
        genScriptFromDllBtn.Click += GenScriptFromDll;
        // 
        // sourceDbConnStrBox
        // 
        sourceDbConnStrBox.Location = new Point(8, 152);
        sourceDbConnStrBox.Margin = new Padding(2);
        sourceDbConnStrBox.Multiline = true;
        sourceDbConnStrBox.Name = "sourceDbConnStrBox";
        sourceDbConnStrBox.Size = new Size(499, 121);
        sourceDbConnStrBox.TabIndex = 11;
        // 
        // sourceDbConnStrLabel
        // 
        sourceDbConnStrLabel.AutoSize = true;
        sourceDbConnStrLabel.Location = new Point(8, 128);
        sourceDbConnStrLabel.Name = "sourceDbConnStrLabel";
        sourceDbConnStrLabel.Size = new Size(169, 19);
        sourceDbConnStrLabel.TabIndex = 10;
        sourceDbConnStrLabel.Text = "sourceDbConnStrLabel";
        // 
        // dalDllPathBox
        // 
        dalDllPathBox.Location = new Point(118, 13);
        dalDllPathBox.Margin = new Padding(2);
        dalDllPathBox.Multiline = true;
        dalDllPathBox.Name = "dalDllPathBox";
        dalDllPathBox.Size = new Size(350, 51);
        dalDllPathBox.TabIndex = 9;
        dalDllPathBox.TextChanged += ModelDllPathBoxChanged;
        // 
        // dalDllLabel
        // 
        dalDllLabel.AutoSize = true;
        dalDllLabel.Location = new Point(26, 28);
        dalDllLabel.Name = "dalDllLabel";
        dalDllLabel.Size = new Size(87, 19);
        dalDllLabel.TabIndex = 0;
        dalDllLabel.Text = "dalDllLabel";
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
        settingTab.Location = new Point(4, 28);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(3);
        settingTab.Size = new Size(782, 280);
        settingTab.TabIndex = 3;
        settingTab.Text = "settingTab";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // customThemelabel
        // 
        customThemelabel.AutoSize = true;
        customThemelabel.Location = new Point(11, 150);
        customThemelabel.Margin = new Padding(2, 0, 2, 0);
        customThemelabel.Name = "customThemelabel";
        customThemelabel.Size = new Size(140, 19);
        customThemelabel.TabIndex = 21;
        customThemelabel.Text = "customThemelabel";
        customThemelabel.DoubleClick += ReloadThemeBinding;
        // 
        // customThemeNameSelect
        // 
        customThemeNameSelect.FormattingEnabled = true;
        customThemeNameSelect.Location = new Point(179, 147);
        customThemeNameSelect.Name = "customThemeNameSelect";
        customThemeNameSelect.Size = new Size(224, 27);
        customThemeNameSelect.TabIndex = 20;
        customThemeNameSelect.SelectedIndexChanged += customThemeNameSelectChanged;
        // 
        // modelGenBtnSettingLabel
        // 
        modelGenBtnSettingLabel.AutoSize = true;
        modelGenBtnSettingLabel.Location = new Point(11, 183);
        modelGenBtnSettingLabel.Margin = new Padding(2, 0, 2, 0);
        modelGenBtnSettingLabel.Name = "modelGenBtnSettingLabel";
        modelGenBtnSettingLabel.Size = new Size(192, 19);
        modelGenBtnSettingLabel.TabIndex = 19;
        modelGenBtnSettingLabel.Text = "modelGenBtnSettingLabel";
        // 
        // connSettingLabel
        // 
        connSettingLabel.AutoSize = true;
        connSettingLabel.Location = new Point(11, 8);
        connSettingLabel.Margin = new Padding(2, 0, 2, 0);
        connSettingLabel.Name = "connSettingLabel";
        connSettingLabel.Size = new Size(130, 19);
        connSettingLabel.TabIndex = 17;
        connSettingLabel.Text = "connSettingLabel";
        // 
        // isWordWithToc
        // 
        isWordWithToc.AutoSize = true;
        isWordWithToc.Location = new Point(32, 114);
        isWordWithToc.Margin = new Padding(2);
        isWordWithToc.Name = "isWordWithToc";
        isWordWithToc.Size = new Size(139, 23);
        isWordWithToc.TabIndex = 16;
        isWordWithToc.Text = "isWordWithToc";
        isWordWithToc.UseVisualStyleBackColor = true;
        isWordWithToc.CheckedChanged += isWordWithTocChanged;
        // 
        // isScaleShow
        // 
        isScaleShow.AutoSize = true;
        isScaleShow.Location = new Point(353, 87);
        isScaleShow.Margin = new Padding(2);
        isScaleShow.Name = "isScaleShow";
        isScaleShow.Size = new Size(117, 23);
        isScaleShow.TabIndex = 13;
        isScaleShow.Text = "isScaleShow";
        isScaleShow.UseVisualStyleBackColor = true;
        isScaleShow.CheckedChanged += IsScaleShowChanged;
        // 
        // isPrecisionShow
        // 
        isPrecisionShow.AutoSize = true;
        isPrecisionShow.Location = new Point(234, 87);
        isPrecisionShow.Margin = new Padding(2);
        isPrecisionShow.Name = "isPrecisionShow";
        isPrecisionShow.Size = new Size(144, 23);
        isPrecisionShow.TabIndex = 12;
        isPrecisionShow.Text = "isPrecisionShow";
        isPrecisionShow.UseVisualStyleBackColor = true;
        isPrecisionShow.CheckedChanged += IsPrecisionShowChanged;
        // 
        // isLengthShow
        // 
        isLengthShow.AutoSize = true;
        isLengthShow.Location = new Point(133, 87);
        isLengthShow.Margin = new Padding(2);
        isLengthShow.Name = "isLengthShow";
        isLengthShow.Size = new Size(130, 23);
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
        isNotNullShow.Location = new Point(32, 87);
        isNotNullShow.Margin = new Padding(2);
        isNotNullShow.Name = "isNotNullShow";
        isNotNullShow.Size = new Size(136, 23);
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
        isPrimaryKeyShow.Location = new Point(453, 60);
        isPrimaryKeyShow.Margin = new Padding(2);
        isPrimaryKeyShow.Name = "isPrimaryKeyShow";
        isPrimaryKeyShow.Size = new Size(161, 23);
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
        isIdentityShow.Location = new Point(354, 60);
        isIdentityShow.Margin = new Padding(2);
        isIdentityShow.Name = "isIdentityShow";
        isIdentityShow.Size = new Size(134, 23);
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
        isDefaultValueShow.Location = new Point(234, 60);
        isDefaultValueShow.Margin = new Padding(2);
        isDefaultValueShow.Name = "isDefaultValueShow";
        isDefaultValueShow.Size = new Size(170, 23);
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
        isDataTypeShow.Location = new Point(133, 60);
        isDataTypeShow.Margin = new Padding(2);
        isDataTypeShow.Name = "isDataTypeShow";
        isDataTypeShow.Size = new Size(146, 23);
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
        isSortShow.Location = new Point(32, 60);
        isSortShow.Margin = new Padding(2);
        isSortShow.Name = "isSortShow";
        isSortShow.Size = new Size(110, 23);
        isSortShow.TabIndex = 5;
        isSortShow.Text = "isSortShow";
        isSortShow.UseVisualStyleBackColor = true;
        isSortShow.CheckedChanged += IsSortShowChanged;
        // 
        // isColumnDescriptionShow
        // 
        isColumnDescriptionShow.AutoSize = true;
        isColumnDescriptionShow.Location = new Point(453, 87);
        isColumnDescriptionShow.Margin = new Padding(2);
        isColumnDescriptionShow.Name = "isColumnDescriptionShow";
        isColumnDescriptionShow.Size = new Size(215, 23);
        isColumnDescriptionShow.TabIndex = 4;
        isColumnDescriptionShow.Text = "isColumnDescriptionShow";
        isColumnDescriptionShow.UseVisualStyleBackColor = true;
        isColumnDescriptionShow.CheckedChanged += IsColumnDescriptionShowChanged;
        // 
        // isTableDescriptionShow
        // 
        isTableDescriptionShow.AutoSize = true;
        isTableDescriptionShow.Location = new Point(32, 33);
        isTableDescriptionShow.Margin = new Padding(2);
        isTableDescriptionShow.Name = "isTableDescriptionShow";
        isTableDescriptionShow.Size = new Size(197, 23);
        isTableDescriptionShow.TabIndex = 3;
        isTableDescriptionShow.Text = "isTableDescriptionShow";
        isTableDescriptionShow.UseVisualStyleBackColor = true;
        isTableDescriptionShow.CheckedChanged += IsTableDescriptionShowChanged;
        // 
        // isSummary
        // 
        isSummary.AutoSize = true;
        isSummary.Location = new Point(37, 213);
        isSummary.Margin = new Padding(2);
        isSummary.Name = "isSummary";
        isSummary.Size = new Size(110, 23);
        isSummary.TabIndex = 11;
        isSummary.Text = "isSummary";
        isSummary.UseVisualStyleBackColor = true;
        isSummary.CheckedChanged += isSummaryChanged;
        // 
        // isKey
        // 
        isKey.AutoSize = true;
        isKey.Location = new Point(328, 213);
        isKey.Margin = new Padding(2);
        isKey.Name = "isKey";
        isKey.Size = new Size(67, 23);
        isKey.TabIndex = 10;
        isKey.Text = "isKey";
        isKey.UseVisualStyleBackColor = true;
        isKey.CheckedChanged += isKeyChanged;
        // 
        // isRequired
        // 
        isRequired.AutoSize = true;
        isRequired.Location = new Point(230, 213);
        isRequired.Margin = new Padding(2);
        isRequired.Name = "isRequired";
        isRequired.Size = new Size(107, 23);
        isRequired.TabIndex = 9;
        isRequired.Text = "isRequired";
        isRequired.UseVisualStyleBackColor = true;
        isRequired.CheckedChanged += IsRequiredChanged;
        // 
        // isDisplay
        // 
        isDisplay.AutoSize = true;
        isDisplay.Location = new Point(137, 213);
        isDisplay.Margin = new Padding(2);
        isDisplay.Name = "isDisplay";
        isDisplay.Size = new Size(93, 23);
        isDisplay.TabIndex = 8;
        isDisplay.Text = "isDisplay";
        isDisplay.UseVisualStyleBackColor = true;
        isDisplay.CheckedChanged += IsDisplayChanged;
        // 
        // resetBtn
        // 
        resetBtn.Location = new Point(19, 244);
        resetBtn.Margin = new Padding(2);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(92, 28);
        resetBtn.TabIndex = 15;
        resetBtn.Text = "resetBtn";
        resetBtn.UseVisualStyleBackColor = true;
        resetBtn.Click += resetAllSetting;
        // 
        // downloadExcelStyleTemplateBtn
        // 
        downloadExcelStyleTemplateBtn.Location = new Point(408, 147);
        downloadExcelStyleTemplateBtn.Margin = new Padding(2);
        downloadExcelStyleTemplateBtn.Name = "downloadExcelStyleTemplateBtn";
        downloadExcelStyleTemplateBtn.Size = new Size(264, 28);
        downloadExcelStyleTemplateBtn.TabIndex = 18;
        downloadExcelStyleTemplateBtn.Text = "downloadExcelStyleTemplateBtn";
        downloadExcelStyleTemplateBtn.UseVisualStyleBackColor = true;
        downloadExcelStyleTemplateBtn.Click += downloadExcelStyleTemplate;
        // 
        // languageTab
        // 
        languageTab.Controls.Add(languageSelect);
        languageTab.Location = new Point(4, 28);
        languageTab.Margin = new Padding(2);
        languageTab.Name = "languageTab";
        languageTab.Padding = new Padding(2);
        languageTab.Size = new Size(782, 280);
        languageTab.TabIndex = 4;
        languageTab.Text = "languageTab";
        languageTab.UseVisualStyleBackColor = true;
        // 
        // languageSelect
        // 
        languageSelect.FormattingEnabled = true;
        languageSelect.Location = new Point(22, 17);
        languageSelect.Name = "languageSelect";
        languageSelect.Size = new Size(163, 27);
        languageSelect.TabIndex = 21;
        languageSelect.SelectedIndexChanged += languageSelectChanged;
        // 
        // errorTextBox
        // 
        errorTextBox.BackColor = SystemColors.Control;
        errorTextBox.BorderStyle = BorderStyle.None;
        errorTextBox.Location = new Point(7, 318);
        errorTextBox.Margin = new Padding(2);
        errorTextBox.Multiline = true;
        errorTextBox.Name = "errorTextBox";
        errorTextBox.ReadOnly = true;
        errorTextBox.Size = new Size(522, 73);
        errorTextBox.TabIndex = 8;
        errorTextBox.DoubleClick += ErrorTextClearDoubleClick;
        // 
        // DbToolForm
        // 
        AutoScaleDimensions = new SizeF(9F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 399);
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
}