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
        demoCommBtn = new System.Windows.Forms.Button();
        downloadSchemaBtn = new System.Windows.Forms.Button();
        connStrBox = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        dbTestBtn = new System.Windows.Forms.Button();
        tabControl1 = new System.Windows.Forms.TabControl();
        connTool = new System.Windows.Forms.TabPage();
        modelTool = new System.Windows.Forms.TabPage();
        isSummary = new System.Windows.Forms.CheckBox();
        isKey = new System.Windows.Forms.CheckBox();
        IsRequired = new System.Windows.Forms.CheckBox();
        IsDisplay = new System.Windows.Forms.CheckBox();
        modelGenBtn = new System.Windows.Forms.Button();
        schmaTool = new System.Windows.Forms.TabPage();
        ImportDescription = new System.Windows.Forms.Button();
        IsScaleShow = new System.Windows.Forms.CheckBox();
        IsPrecisionShow = new System.Windows.Forms.CheckBox();
        IsLengthShow = new System.Windows.Forms.CheckBox();
        IsNotNullShow = new System.Windows.Forms.CheckBox();
        IsPrimaryKeyShow = new System.Windows.Forms.CheckBox();
        IsIdentityShow = new System.Windows.Forms.CheckBox();
        IsDefaultValueShow = new System.Windows.Forms.CheckBox();
        IsDataTypeShow = new System.Windows.Forms.CheckBox();
        IsSortShow = new System.Windows.Forms.CheckBox();
        IsColumnDescriptionShow = new System.Windows.Forms.CheckBox();
        IsTableDescriptionShow = new System.Windows.Forms.CheckBox();
        downloadTemplateBtn = new System.Windows.Forms.Button();
        errorTextLbl = new System.Windows.Forms.TextBox();
        tabControl1.SuspendLayout();
        connTool.SuspendLayout();
        modelTool.SuspendLayout();
        schmaTool.SuspendLayout();
        SuspendLayout();
        // 
        // demoCommBtn
        // 
        demoCommBtn.Location = new System.Drawing.Point(232, 168);
        demoCommBtn.Name = "demoCommBtn";
        demoCommBtn.Size = new System.Drawing.Size(112, 34);
        demoCommBtn.TabIndex = 0;
        demoCommBtn.Text = "顯示範例";
        demoCommBtn.UseVisualStyleBackColor = true;
        demoCommBtn.Click += new System.EventHandler(demoCommBtnEvent);
        // 
        // downloadSchemaBtn
        // 
        downloadSchemaBtn.Location = new System.Drawing.Point(18, 123);
        downloadSchemaBtn.Name = "downloadSchemaBtn";
        downloadSchemaBtn.Size = new System.Drawing.Size(156, 34);
        downloadSchemaBtn.TabIndex = 1;
        downloadSchemaBtn.Text = "下載資料庫規格";
        downloadSchemaBtn.UseVisualStyleBackColor = true;
        downloadSchemaBtn.Click += new System.EventHandler(downloadSchemaEvent);
        // 
        // connStrBox
        // 
        connStrBox.Location = new System.Drawing.Point(96, 12);
        connStrBox.Multiline = true;
        connStrBox.Name = "connStrBox";
        connStrBox.Size = new System.Drawing.Size(530, 135);
        connStrBox.TabIndex = 2;
        connStrBox.TextChanged += new System.EventHandler(connStrBoxEvent);
        connStrBox.Text = Properties.Settings.Default.ConnString;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(8, 12);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(82, 23);
        label1.TabIndex = 3;
        label1.Text = "連線字串";
        label1.Click += new System.EventHandler(label1_Click);
        // 
        // dbTestBtn
        // 
        dbTestBtn.Location = new System.Drawing.Point(96, 168);
        dbTestBtn.Name = "dbTestBtn";
        dbTestBtn.Size = new System.Drawing.Size(112, 34);
        dbTestBtn.TabIndex = 6;
        dbTestBtn.Text = "連線測試";
        dbTestBtn.UseVisualStyleBackColor = true;
        dbTestBtn.Click += new System.EventHandler(dbTestEvent);
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(connTool);
        tabControl1.Controls.Add(modelTool);
        tabControl1.Controls.Add(schmaTool);
        tabControl1.Location = new System.Drawing.Point(0, 3);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new System.Drawing.Size(655, 295);
        tabControl1.TabIndex = 7;
        tabControl1.SelectedIndexChanged += new System.EventHandler(tabControl1_SelectedIndexChanged);
        // 
        // connTool
        // 
        connTool.Controls.Add(label1);
        connTool.Controls.Add(dbTestBtn);
        connTool.Controls.Add(connStrBox);
        connTool.Controls.Add(demoCommBtn);
        connTool.Location = new System.Drawing.Point(4, 32);
        connTool.Name = "connTool";
        connTool.Padding = new System.Windows.Forms.Padding(3);
        connTool.Size = new System.Drawing.Size(647, 259);
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
        modelTool.Location = new System.Drawing.Point(4, 32);
        modelTool.Name = "modelTool";
        modelTool.Padding = new System.Windows.Forms.Padding(3);
        modelTool.Size = new System.Drawing.Size(647, 259);
        modelTool.TabIndex = 1;
        modelTool.Text = "model產檔";
        modelTool.UseVisualStyleBackColor = true;
        // 
        // isSummary
        // 
        isSummary.AutoSize = true;
        isSummary.Checked = true;
        isSummary.CheckState = System.Windows.Forms.CheckState.Checked;
        isSummary.Location = new System.Drawing.Point(8, 29);
        isSummary.Name = "isSummary";
        isSummary.Size = new System.Drawing.Size(117, 27);
        isSummary.TabIndex = 11;
        isSummary.Text = "Summary";
        isSummary.UseVisualStyleBackColor = true;
        isSummary.CheckedChanged += new System.EventHandler(isSummary_CheckedChanged);
        // 
        // isKey
        // 
        isKey.AutoSize = true;
        isKey.Location = new System.Drawing.Point(364, 29);
        isKey.Name = "isKey";
        isKey.Size = new System.Drawing.Size(66, 27);
        isKey.TabIndex = 10;
        isKey.Text = "Key";
        isKey.UseVisualStyleBackColor = true;
        isKey.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged_2);
        // 
        // IsRequired
        // 
        IsRequired.AutoSize = true;
        IsRequired.Location = new System.Drawing.Point(245, 29);
        IsRequired.Name = "IsRequired";
        IsRequired.Size = new System.Drawing.Size(113, 27);
        IsRequired.TabIndex = 9;
        IsRequired.Text = "Required";
        IsRequired.UseVisualStyleBackColor = true;
        IsRequired.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
        // 
        // IsDisplay
        // 
        IsDisplay.AutoSize = true;
        IsDisplay.Location = new System.Drawing.Point(131, 29);
        IsDisplay.Name = "IsDisplay";
        IsDisplay.Size = new System.Drawing.Size(98, 27);
        IsDisplay.TabIndex = 8;
        IsDisplay.Text = "Display";
        IsDisplay.UseVisualStyleBackColor = true;
        IsDisplay.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged_1);
        // 
        // modelGenBtn
        // 
        modelGenBtn.Location = new System.Drawing.Point(8, 72);
        modelGenBtn.Name = "modelGenBtn";
        modelGenBtn.Size = new System.Drawing.Size(151, 31);
        modelGenBtn.TabIndex = 7;
        modelGenBtn.Text = "所有model產檔";
        modelGenBtn.UseVisualStyleBackColor = true;
        modelGenBtn.Click += new System.EventHandler(modelGenEvent);
        // 
        // schmaTool
        // 
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
        schmaTool.Location = new System.Drawing.Point(4, 32);
        schmaTool.Name = "schmaTool";
        schmaTool.Padding = new System.Windows.Forms.Padding(3);
        schmaTool.Size = new System.Drawing.Size(647, 259);
        schmaTool.TabIndex = 2;
        schmaTool.Text = "資料庫規格";
        schmaTool.UseVisualStyleBackColor = true;
        // 
        // ImportDescription
        // 
        ImportDescription.Location = new System.Drawing.Point(18, 203);
        ImportDescription.Name = "ImportDescription";
        ImportDescription.Size = new System.Drawing.Size(112, 34);
        ImportDescription.TabIndex = 14;
        ImportDescription.Text = "匯入描述";
        ImportDescription.UseVisualStyleBackColor = true;
        ImportDescription.Click += new System.EventHandler(ImportDescriptionEvent);
        // 
        // IsScaleShow
        // 
        IsScaleShow.AutoSize = true;
        IsScaleShow.Location = new System.Drawing.Point(287, 85);
        IsScaleShow.Name = "IsScaleShow";
        IsScaleShow.Size = new System.Drawing.Size(90, 27);
        IsScaleShow.TabIndex = 13;
        IsScaleShow.Text = "小位數";
        IsScaleShow.UseVisualStyleBackColor = true;
        IsScaleShow.CheckedChanged += new System.EventHandler(IsScaleShow_CheckedChanged);
        // 
        // IsPrecisionShow
        // 
        IsPrecisionShow.AutoSize = true;
        IsPrecisionShow.Location = new System.Drawing.Point(202, 85);
        IsPrecisionShow.Name = "IsPrecisionShow";
        IsPrecisionShow.Size = new System.Drawing.Size(72, 27);
        IsPrecisionShow.TabIndex = 12;
        IsPrecisionShow.Text = "精度";
        IsPrecisionShow.UseVisualStyleBackColor = true;
        // 
        // IsLengthShow
        // 
        IsLengthShow.AutoSize = true;
        IsLengthShow.Location = new System.Drawing.Point(97, 85);
        IsLengthShow.Name = "IsLengthShow";
        IsLengthShow.Size = new System.Drawing.Size(72, 27);
        IsLengthShow.TabIndex = 11;
        IsLengthShow.Text = "長度";
        IsLengthShow.UseVisualStyleBackColor = true;
        IsLengthShow.CheckedChanged += new System.EventHandler(checkBox3_CheckedChanged);
        // 
        // IsNotNullShow
        // 
        IsNotNullShow.AutoSize = true;
        IsNotNullShow.Checked = true;
        IsNotNullShow.CheckState = System.Windows.Forms.CheckState.Checked;
        IsNotNullShow.Location = new System.Drawing.Point(19, 85);
        IsNotNullShow.Name = "IsNotNullShow";
        IsNotNullShow.Size = new System.Drawing.Size(72, 27);
        IsNotNullShow.TabIndex = 10;
        IsNotNullShow.Text = "必填";
        IsNotNullShow.UseVisualStyleBackColor = true;
        // 
        // IsPrimaryKeyShow
        // 
        IsPrimaryKeyShow.AutoSize = true;
        IsPrimaryKeyShow.Checked = true;
        IsPrimaryKeyShow.CheckState = System.Windows.Forms.CheckState.Checked;
        IsPrimaryKeyShow.Location = new System.Drawing.Point(383, 52);
        IsPrimaryKeyShow.Name = "IsPrimaryKeyShow";
        IsPrimaryKeyShow.Size = new System.Drawing.Size(72, 27);
        IsPrimaryKeyShow.TabIndex = 9;
        IsPrimaryKeyShow.Text = "主鍵";
        IsPrimaryKeyShow.UseVisualStyleBackColor = true;
        // 
        // IsIdentityShow
        // 
        IsIdentityShow.AutoSize = true;
        IsIdentityShow.Checked = true;
        IsIdentityShow.CheckState = System.Windows.Forms.CheckState.Checked;
        IsIdentityShow.Location = new System.Drawing.Point(287, 52);
        IsIdentityShow.Name = "IsIdentityShow";
        IsIdentityShow.Size = new System.Drawing.Size(72, 27);
        IsIdentityShow.TabIndex = 8;
        IsIdentityShow.Text = "識別";
        IsIdentityShow.UseVisualStyleBackColor = true;
        // 
        // IsDefaultValueShow
        // 
        IsDefaultValueShow.AutoSize = true;
        IsDefaultValueShow.Checked = true;
        IsDefaultValueShow.CheckState = System.Windows.Forms.CheckState.Checked;
        IsDefaultValueShow.Location = new System.Drawing.Point(202, 52);
        IsDefaultValueShow.Name = "IsDefaultValueShow";
        IsDefaultValueShow.Size = new System.Drawing.Size(90, 27);
        IsDefaultValueShow.TabIndex = 7;
        IsDefaultValueShow.Text = "預設值";
        IsDefaultValueShow.UseVisualStyleBackColor = true;
        // 
        // IsDataTypeShow
        // 
        IsDataTypeShow.AutoSize = true;
        IsDataTypeShow.Checked = true;
        IsDataTypeShow.CheckState = System.Windows.Forms.CheckState.Checked;
        IsDataTypeShow.Location = new System.Drawing.Point(97, 52);
        IsDataTypeShow.Name = "IsDataTypeShow";
        IsDataTypeShow.Size = new System.Drawing.Size(108, 27);
        IsDataTypeShow.TabIndex = 6;
        IsDataTypeShow.Text = "資料型別";
        IsDataTypeShow.UseVisualStyleBackColor = true;
        // 
        // IsSortShow
        // 
        IsSortShow.AutoSize = true;
        IsSortShow.Checked = true;
        IsSortShow.CheckState = System.Windows.Forms.CheckState.Checked;
        IsSortShow.Location = new System.Drawing.Point(19, 52);
        IsSortShow.Name = "IsSortShow";
        IsSortShow.Size = new System.Drawing.Size(72, 27);
        IsSortShow.TabIndex = 5;
        IsSortShow.Text = "排序";
        IsSortShow.UseVisualStyleBackColor = true;
        // 
        // IsColumnDescriptionShow
        // 
        IsColumnDescriptionShow.AutoSize = true;
        IsColumnDescriptionShow.Checked = true;
        IsColumnDescriptionShow.CheckState = System.Windows.Forms.CheckState.Checked;
        IsColumnDescriptionShow.Location = new System.Drawing.Point(383, 85);
        IsColumnDescriptionShow.Name = "IsColumnDescriptionShow";
        IsColumnDescriptionShow.Size = new System.Drawing.Size(90, 27);
        IsColumnDescriptionShow.TabIndex = 4;
        IsColumnDescriptionShow.Text = "欄描述";
        IsColumnDescriptionShow.UseVisualStyleBackColor = true;
        // 
        // IsTableDescriptionShow
        // 
        IsTableDescriptionShow.AutoSize = true;
        IsTableDescriptionShow.Checked = true;
        IsTableDescriptionShow.CheckState = System.Windows.Forms.CheckState.Checked;
        IsTableDescriptionShow.Location = new System.Drawing.Point(19, 19);
        IsTableDescriptionShow.Name = "IsTableDescriptionShow";
        IsTableDescriptionShow.Size = new System.Drawing.Size(90, 27);
        IsTableDescriptionShow.TabIndex = 3;
        IsTableDescriptionShow.Text = "表描述";
        IsTableDescriptionShow.UseVisualStyleBackColor = true;
        IsTableDescriptionShow.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
        // 
        // downloadTemplateBtn
        // 
        downloadTemplateBtn.Location = new System.Drawing.Point(18, 163);
        downloadTemplateBtn.Name = "downloadTemplateBtn";
        downloadTemplateBtn.Size = new System.Drawing.Size(166, 34);
        downloadTemplateBtn.TabIndex = 2;
        downloadTemplateBtn.Text = "下載匯入描述範本";
        downloadTemplateBtn.UseVisualStyleBackColor = true;
        downloadTemplateBtn.Click += new System.EventHandler(downloadSchemaEvent);
        // 
        // errorTextLbl
        // 
        errorTextLbl.BackColor = System.Drawing.SystemColors.Control;
        errorTextLbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
        errorTextLbl.Location = new System.Drawing.Point(4, 300);
        errorTextLbl.Multiline = true;
        errorTextLbl.Name = "errorTextLbl";
        errorTextLbl.ReadOnly = true;
        errorTextLbl.Size = new System.Drawing.Size(638, 73);
        errorTextLbl.TabIndex = 8;
        errorTextLbl.Click += new System.EventHandler(errorTextEvent);
        // 
        // DbTool
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(654, 386);
        Controls.Add(errorTextLbl);
        Controls.Add(tabControl1);
        Name = "DbTool";
        Text = "資料庫工具";
        Load += new System.EventHandler(Form1_Load);
        tabControl1.ResumeLayout(false);
        connTool.ResumeLayout(false);
        connTool.PerformLayout();
        modelTool.ResumeLayout(false);
        modelTool.PerformLayout();
        schmaTool.ResumeLayout(false);
        schmaTool.PerformLayout();
        ResumeLayout(false);
        PerformLayout();

    }
    #endregion

    #region tool component
    private TextBox connStrBox;
    private Label label1;
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
}
