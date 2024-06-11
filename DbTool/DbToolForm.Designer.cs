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
        connTool = new TabPage();
        modelTool = new TabPage();
        isSummary = new CheckBox();
        isKey = new CheckBox();
        IsRequired = new CheckBox();
        IsDisplay = new CheckBox();
        modelGenBtn = new Button();
        schmaTool = new TabPage();
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
        settingTab = new TabPage();
        resetBtn = new Button();
        errorTextLbl = new TextBox();
        tabControl1.SuspendLayout();
        connTool.SuspendLayout();
        modelTool.SuspendLayout();
        schmaTool.SuspendLayout();
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
        downloadSchemaBtn.Location = new Point(15, 102);
        downloadSchemaBtn.Margin = new Padding(2);
        downloadSchemaBtn.Name = "downloadSchemaBtn";
        downloadSchemaBtn.Size = new Size(170, 28);
        downloadSchemaBtn.TabIndex = 1;
        downloadSchemaBtn.Text = "下載資料庫規格 Excel";
        downloadSchemaBtn.UseVisualStyleBackColor = true;
        downloadSchemaBtn.Click += downloadSchemaEvent;
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
        tabControl1.Controls.Add(connTool);
        tabControl1.Controls.Add(modelTool);
        tabControl1.Controls.Add(schmaTool);
        tabControl1.Controls.Add(settingTab);
        tabControl1.Location = new Point(0, 2);
        tabControl1.Margin = new Padding(2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(536, 244);
        tabControl1.TabIndex = 7;
        tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        // 
        // connTool
        // 
        connTool.Controls.Add(connStrLabel);
        connTool.Controls.Add(dbTestBtn);
        connTool.Controls.Add(connStrBox);
        connTool.Controls.Add(demoCommBtn);
        connTool.Location = new Point(4, 28);
        connTool.Margin = new Padding(2);
        connTool.Name = "connTool";
        connTool.Padding = new Padding(2);
        connTool.Size = new Size(528, 212);
        connTool.TabIndex = 0;
        connTool.Text = "資料庫連線";
        connTool.UseVisualStyleBackColor = true;
        // 
        // modelTool
        // 
        modelTool.Controls.Add(isSummary);
        modelTool.Controls.Add(isKey);
        modelTool.Controls.Add(IsRequired);
        modelTool.Controls.Add(IsDisplay);
        modelTool.Controls.Add(modelGenBtn);
        modelTool.Location = new Point(4, 28);
        modelTool.Margin = new Padding(2);
        modelTool.Name = "modelTool";
        modelTool.Padding = new Padding(2);
        modelTool.Size = new Size(528, 212);
        modelTool.TabIndex = 1;
        modelTool.Text = "model產檔";
        modelTool.UseVisualStyleBackColor = true;
        // 
        // isSummary
        // 
        isSummary.AutoSize = true;
        isSummary.Location = new Point(7, 24);
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
        isKey.Location = new Point(298, 24);
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
        IsRequired.Location = new Point(200, 24);
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
        IsDisplay.Location = new Point(107, 24);
        IsDisplay.Margin = new Padding(2);
        IsDisplay.Name = "IsDisplay";
        IsDisplay.Size = new Size(82, 23);
        IsDisplay.TabIndex = 8;
        IsDisplay.Text = "Display";
        IsDisplay.UseVisualStyleBackColor = true;
        IsDisplay.CheckedChanged += IsDisplayChanged;
        // 
        // modelGenBtn
        // 
        modelGenBtn.Location = new Point(7, 59);
        modelGenBtn.Margin = new Padding(2);
        modelGenBtn.Name = "modelGenBtn";
        modelGenBtn.Size = new Size(124, 26);
        modelGenBtn.TabIndex = 7;
        modelGenBtn.Text = "所有model產檔";
        modelGenBtn.UseVisualStyleBackColor = true;
        modelGenBtn.Click += modelGenEvent;
        // 
        // schmaTool
        // 
        schmaTool.Controls.Add(downloadSchemaWordBtn);
        schmaTool.Controls.Add(ImportDescription);
        schmaTool.Controls.Add(IsScaleShow);
        schmaTool.Controls.Add(IsPrecisionShow);
        schmaTool.Controls.Add(IsLengthShow);
        schmaTool.Controls.Add(IsNotNullShow);
        schmaTool.Controls.Add(IsPrimaryKeyShow);
        schmaTool.Controls.Add(IsIdentityShow);
        schmaTool.Controls.Add(IsDefaultValueShow);
        schmaTool.Controls.Add(IsDataTypeShow);
        schmaTool.Controls.Add(IsSortShow);
        schmaTool.Controls.Add(IsColumnDescriptionShow);
        schmaTool.Controls.Add(IsTableDescriptionShow);
        schmaTool.Controls.Add(downloadTemplateBtn);
        schmaTool.Controls.Add(downloadSchemaBtn);
        schmaTool.Location = new Point(4, 28);
        schmaTool.Margin = new Padding(2);
        schmaTool.Name = "schmaTool";
        schmaTool.Padding = new Padding(2);
        schmaTool.Size = new Size(528, 212);
        schmaTool.TabIndex = 2;
        schmaTool.Text = "資料庫規格";
        schmaTool.UseVisualStyleBackColor = true;
        // 
        // downloadSchemaWordBtn
        // 
        downloadSchemaWordBtn.Location = new Point(16, 144);
        downloadSchemaWordBtn.Margin = new Padding(2);
        downloadSchemaWordBtn.Name = "downloadSchemaWordBtn";
        downloadSchemaWordBtn.Size = new Size(170, 28);
        downloadSchemaWordBtn.TabIndex = 15;
        downloadSchemaWordBtn.Text = "下載資料庫規格 Word";
        downloadSchemaWordBtn.UseVisualStyleBackColor = true;
        downloadSchemaWordBtn.Click += downloadSchemaWordBtnClick;
        // 
        // ImportDescription
        // 
        ImportDescription.Location = new Point(265, 144);
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
        downloadTemplateBtn.Location = new Point(265, 102);
        downloadTemplateBtn.Margin = new Padding(2);
        downloadTemplateBtn.Name = "downloadTemplateBtn";
        downloadTemplateBtn.Size = new Size(155, 28);
        downloadTemplateBtn.TabIndex = 2;
        downloadTemplateBtn.Text = "下載匯入描述範本";
        downloadTemplateBtn.UseVisualStyleBackColor = true;
        downloadTemplateBtn.Click += downloadSchemaEvent;
        // 
        // settingTab
        // 
        settingTab.Controls.Add(resetBtn);
        settingTab.Location = new Point(4, 28);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(3);
        settingTab.Size = new Size(528, 212);
        settingTab.TabIndex = 3;
        settingTab.Text = "設定";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // resetBtn
        // 
        resetBtn.Location = new Point(16, 19);
        resetBtn.Margin = new Padding(2);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(92, 28);
        resetBtn.TabIndex = 15;
        resetBtn.Text = "重置設定";
        resetBtn.UseVisualStyleBackColor = true;
        resetBtn.Click += resetBtn_Click;
        // 
        // errorTextLbl
        // 
        errorTextLbl.BackColor = SystemColors.Control;
        errorTextLbl.BorderStyle = BorderStyle.None;
        errorTextLbl.Location = new Point(3, 248);
        errorTextLbl.Margin = new Padding(2);
        errorTextLbl.Multiline = true;
        errorTextLbl.Name = "errorTextLbl";
        errorTextLbl.ReadOnly = true;
        errorTextLbl.Size = new Size(522, 60);
        errorTextLbl.TabIndex = 8;
        errorTextLbl.DoubleClick += errorTextEvent;
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
        Load += DbToolForm_Load;
        tabControl1.ResumeLayout(false);
        connTool.ResumeLayout(false);
        connTool.PerformLayout();
        modelTool.ResumeLayout(false);
        modelTool.PerformLayout();
        schmaTool.ResumeLayout(false);
        schmaTool.PerformLayout();
        settingTab.ResumeLayout(false);
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
    private TabPage connTool;
    private TabPage modelTool;
    private TabPage schmaTool;
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
    private TabPage settingTab;
    private Button resetBtn;
    private Button downloadSchemaWordBtn;
}