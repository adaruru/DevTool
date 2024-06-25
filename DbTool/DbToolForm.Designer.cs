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
        downloadSchemaWordPerTableBtn = new Button();
        isWordWithToc = new CheckBox();
        downloadSchemaWordBtn = new Button();
        ImportDescription = new Button();
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
        downloadTemplateBtn = new Button();
        modelToolTab = new TabPage();
        modelGenBtn = new Button();
        settingTab = new TabPage();
        isSummary = new CheckBox();
        isKey = new CheckBox();
        IsRequired = new CheckBox();
        IsDisplay = new CheckBox();
        resetBtn = new Button();
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
        demoCommBtn.Location = new Point(190, 139);
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
        downloadSchemaBtn.Location = new Point(15, 95);
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
        connStrBox.Location = new Point(79, 10);
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
        connStrLabel.Location = new Point(7, 10);
        connStrLabel.Margin = new Padding(2, 0, 2, 0);
        connStrLabel.Name = "connStrLabel";
        connStrLabel.Size = new Size(69, 19);
        connStrLabel.TabIndex = 3;
        connStrLabel.Text = "連線字串";
        // 
        // dbTestBtn
        // 
        dbTestBtn.Location = new Point(79, 139);
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
        tabControl1.Size = new Size(536, 255);
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
        connToolTab.Size = new Size(528, 223);
        connToolTab.TabIndex = 0;
        connToolTab.Text = "資料庫連線";
        connToolTab.UseVisualStyleBackColor = true;
        // 
        // schmaToolTab
        // 
        schmaToolTab.Controls.Add(downloadSchemaWordPerTableBtn);
        schmaToolTab.Controls.Add(downloadSchemaWordBtn);
        schmaToolTab.Controls.Add(ImportDescription);
        schmaToolTab.Controls.Add(downloadTemplateBtn);
        schmaToolTab.Controls.Add(downloadSchemaBtn);
        schmaToolTab.Location = new Point(4, 28);
        schmaToolTab.Margin = new Padding(2);
        schmaToolTab.Name = "schmaToolTab";
        schmaToolTab.Padding = new Padding(2);
        schmaToolTab.Size = new Size(528, 223);
        schmaToolTab.TabIndex = 1;
        schmaToolTab.Text = "資料庫規格";
        schmaToolTab.UseVisualStyleBackColor = true;
        // 
        // downloadSchemaWordPerTableBtn
        // 
        downloadSchemaWordPerTableBtn.Location = new Point(15, 157);
        downloadSchemaWordPerTableBtn.Margin = new Padding(2);
        downloadSchemaWordPerTableBtn.Name = "downloadSchemaWordPerTableBtn";
        downloadSchemaWordPerTableBtn.Size = new Size(243, 28);
        downloadSchemaWordPerTableBtn.TabIndex = 17;
        downloadSchemaWordPerTableBtn.Text = "下載資料庫規格 Word (一表一檔)";
        downloadSchemaWordPerTableBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordPerTableBtn.Click += exportSchemaWordBtnClick;
        // 
        // isWordWithToc
        // 
        isWordWithToc.AutoSize = true;
        isWordWithToc.Location = new Point(17, 189);
        isWordWithToc.Margin = new Padding(2);
        isWordWithToc.Name = "isWordWithToc";
        isWordWithToc.Size = new Size(146, 23);
        isWordWithToc.TabIndex = 16;
        isWordWithToc.Text = "Word是否有目錄";
        isWordWithToc.UseVisualStyleBackColor = true;
        isWordWithToc.CheckedChanged += isWordWithTocChanged;
        // 
        // downloadSchemaWordBtn
        // 
        downloadSchemaWordBtn.Location = new Point(16, 126);
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
        ImportDescription.Location = new Point(265, 126);
        ImportDescription.Margin = new Padding(2);
        ImportDescription.Name = "ImportDescription";
        ImportDescription.Size = new Size(92, 28);
        ImportDescription.TabIndex = 14;
        ImportDescription.Text = "匯入描述";
        ImportDescription.UseVisualStyleBackColor = true;
        ImportDescription.Click += ImportDescriptionEvent;
        // 
        // IsScaleShow
        // 
        IsScaleShow.AutoSize = true;
        IsScaleShow.Location = new Point(235, 70);
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
        IsPrecisionShow.Location = new Point(165, 70);
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
        IsLengthShow.Location = new Point(79, 70);
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
        IsNotNullShow.Location = new Point(16, 70);
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
        IsPrimaryKeyShow.Location = new Point(313, 43);
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
        IsIdentityShow.Location = new Point(235, 43);
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
        IsDefaultValueShow.Location = new Point(165, 43);
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
        IsDataTypeShow.Location = new Point(79, 43);
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
        IsSortShow.Location = new Point(16, 43);
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
        IsColumnDescriptionShow.Location = new Point(313, 70);
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
        IsTableDescriptionShow.Location = new Point(16, 16);
        IsTableDescriptionShow.Margin = new Padding(2);
        IsTableDescriptionShow.Name = "IsTableDescriptionShow";
        IsTableDescriptionShow.Size = new Size(76, 23);
        IsTableDescriptionShow.TabIndex = 3;
        IsTableDescriptionShow.Text = "表描述";
        IsTableDescriptionShow.UseVisualStyleBackColor = true;
        IsTableDescriptionShow.CheckedChanged += IsTableDescriptionShowChanged;
        // 
        // downloadTemplateBtn
        // 
        downloadTemplateBtn.Location = new Point(265, 95);
        downloadTemplateBtn.Margin = new Padding(2);
        downloadTemplateBtn.Name = "downloadTemplateBtn";
        downloadTemplateBtn.Size = new Size(155, 28);
        downloadTemplateBtn.TabIndex = 2;
        downloadTemplateBtn.Text = "下載匯入描述範本";
        downloadTemplateBtn.UseVisualStyleBackColor = true;
        downloadTemplateBtn.Click += exportSchemaEvent;
        // 
        // modelToolTab
        // 
        modelToolTab.Controls.Add(modelGenBtn);
        modelToolTab.Location = new Point(4, 28);
        modelToolTab.Margin = new Padding(2);
        modelToolTab.Name = "modelToolTab";
        modelToolTab.Padding = new Padding(2);
        modelToolTab.Size = new Size(528, 223);
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
        modelGenBtn.Click += modelGenEvent;
        // 
        // settingTab
        // 
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
        settingTab.Location = new Point(4, 28);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(3);
        settingTab.Size = new Size(528, 223);
        settingTab.TabIndex = 3;
        settingTab.Text = "設定";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // isSummary
        // 
        isSummary.AutoSize = true;
        isSummary.Location = new Point(23, 116);
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
        isKey.Location = new Point(314, 116);
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
        IsRequired.Location = new Point(216, 116);
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
        IsDisplay.Location = new Point(123, 116);
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
        resetBtn.Location = new Point(19, 179);
        resetBtn.Margin = new Padding(2);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(92, 28);
        resetBtn.TabIndex = 15;
        resetBtn.Text = "重置設定";
        resetBtn.UseVisualStyleBackColor = true;
        resetBtn.Click += resetBtnClick;
        // 
        // errorTextLbl
        // 
        errorTextLbl.BackColor = SystemColors.Control;
        errorTextLbl.BorderStyle = BorderStyle.None;
        errorTextLbl.Location = new Point(7, 255);
        errorTextLbl.Margin = new Padding(2);
        errorTextLbl.Multiline = true;
        errorTextLbl.Name = "errorTextLbl";
        errorTextLbl.ReadOnly = true;
        errorTextLbl.Size = new Size(522, 60);
        errorTextLbl.TabIndex = 8;
        errorTextLbl.DoubleClick += errorTextDoubleClick;
        // 
        // DbToolForm
        // 
        AutoScaleDimensions = new SizeF(9F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(535, 319);
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
        schmaToolTab.PerformLayout();
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
}