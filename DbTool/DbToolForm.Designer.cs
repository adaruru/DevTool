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
        this.demoCommBtn = new System.Windows.Forms.Button();
        this.downloadSchemaBtn = new System.Windows.Forms.Button();
        this.connStrBox = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.dbTestBtn = new System.Windows.Forms.Button();
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.connTool = new System.Windows.Forms.TabPage();
        this.modelTool = new System.Windows.Forms.TabPage();
        this.isSummary = new System.Windows.Forms.CheckBox();
        this.isKey = new System.Windows.Forms.CheckBox();
        this.IsRequired = new System.Windows.Forms.CheckBox();
        this.IsDisplay = new System.Windows.Forms.CheckBox();
        this.modelGenBtn = new System.Windows.Forms.Button();
        this.schmaTool = new System.Windows.Forms.TabPage();
        this.ImportDescription = new System.Windows.Forms.Button();
        this.IsScaleShow = new System.Windows.Forms.CheckBox();
        this.IsPrecisionShow = new System.Windows.Forms.CheckBox();
        this.IsLengthShow = new System.Windows.Forms.CheckBox();
        this.IsNotNullShow = new System.Windows.Forms.CheckBox();
        this.IsPrimaryKeyShow = new System.Windows.Forms.CheckBox();
        this.IsIdentityShow = new System.Windows.Forms.CheckBox();
        this.IsDefaultValueShow = new System.Windows.Forms.CheckBox();
        this.IsDataTypeShow = new System.Windows.Forms.CheckBox();
        this.IsSortShow = new System.Windows.Forms.CheckBox();
        this.IsColumnDescriptionShow = new System.Windows.Forms.CheckBox();
        this.IsTableDescriptionShow = new System.Windows.Forms.CheckBox();
        this.downloadTemplateBtn = new System.Windows.Forms.Button();
        this.errorTextLbl = new System.Windows.Forms.TextBox();
        this.tabControl1.SuspendLayout();
        this.connTool.SuspendLayout();
        this.modelTool.SuspendLayout();
        this.schmaTool.SuspendLayout();
        this.SuspendLayout();
        // 
        // demoCommBtn
        // 
        this.demoCommBtn.Location = new System.Drawing.Point(232, 168);
        this.demoCommBtn.Name = "demoCommBtn";
        this.demoCommBtn.Size = new System.Drawing.Size(112, 34);
        this.demoCommBtn.TabIndex = 0;
        this.demoCommBtn.Text = "顯示範例";
        this.demoCommBtn.UseVisualStyleBackColor = true;
        this.demoCommBtn.Click += new System.EventHandler(this.demoCommBtnEvent);
        // 
        // downloadSchemaBtn
        // 
        this.downloadSchemaBtn.Location = new System.Drawing.Point(18, 123);
        this.downloadSchemaBtn.Name = "downloadSchemaBtn";
        this.downloadSchemaBtn.Size = new System.Drawing.Size(156, 34);
        this.downloadSchemaBtn.TabIndex = 1;
        this.downloadSchemaBtn.Text = "下載資料庫規格";
        this.downloadSchemaBtn.UseVisualStyleBackColor = true;
        this.downloadSchemaBtn.Click += new System.EventHandler(this.downloadSchemaEvent);
        // 
        // connStrBox
        // 
        this.connStrBox.Location = new System.Drawing.Point(96, 12);
        this.connStrBox.Multiline = true;
        this.connStrBox.Name = "connStrBox";
        this.connStrBox.Size = new System.Drawing.Size(530, 135);
        this.connStrBox.TabIndex = 2;
        this.connStrBox.TextChanged += new System.EventHandler(this.connStrBoxEvent);
        connStrBox.Text = Properties.Settings.Default.ConnString;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(8, 12);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(82, 23);
        this.label1.TabIndex = 3;
        this.label1.Text = "連線字串";
        this.label1.Click += new System.EventHandler(this.label1_Click);
        // 
        // dbTestBtn
        // 
        this.dbTestBtn.Location = new System.Drawing.Point(96, 168);
        this.dbTestBtn.Name = "dbTestBtn";
        this.dbTestBtn.Size = new System.Drawing.Size(112, 34);
        this.dbTestBtn.TabIndex = 6;
        this.dbTestBtn.Text = "連線測試";
        this.dbTestBtn.UseVisualStyleBackColor = true;
        this.dbTestBtn.Click += new System.EventHandler(this.dbTestEvent);
        // 
        // tabControl1
        // 
        this.tabControl1.Controls.Add(this.connTool);
        this.tabControl1.Controls.Add(this.modelTool);
        this.tabControl1.Controls.Add(this.schmaTool);
        this.tabControl1.Location = new System.Drawing.Point(0, 3);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(655, 295);
        this.tabControl1.TabIndex = 7;
        this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
        // 
        // connTool
        // 
        this.connTool.Controls.Add(this.label1);
        this.connTool.Controls.Add(this.dbTestBtn);
        this.connTool.Controls.Add(this.connStrBox);
        this.connTool.Controls.Add(this.demoCommBtn);
        this.connTool.Location = new System.Drawing.Point(4, 32);
        this.connTool.Name = "connTool";
        this.connTool.Padding = new System.Windows.Forms.Padding(3);
        this.connTool.Size = new System.Drawing.Size(647, 259);
        this.connTool.TabIndex = 0;
        this.connTool.Text = "資料庫連線";
        this.connTool.UseVisualStyleBackColor = true;
        // 
        // modelTool
        // 
        this.modelTool.Controls.Add(this.isSummary);
        this.modelTool.Controls.Add(this.isKey);
        this.modelTool.Controls.Add(this.IsRequired);
        this.modelTool.Controls.Add(this.IsDisplay);
        this.modelTool.Controls.Add(this.modelGenBtn);
        this.modelTool.Location = new System.Drawing.Point(4, 32);
        this.modelTool.Name = "modelTool";
        this.modelTool.Padding = new System.Windows.Forms.Padding(3);
        this.modelTool.Size = new System.Drawing.Size(647, 259);
        this.modelTool.TabIndex = 1;
        this.modelTool.Text = "model產檔";
        this.modelTool.UseVisualStyleBackColor = true;
        // 
        // isSummary
        // 
        this.isSummary.AutoSize = true;
        this.isSummary.Checked = true;
        this.isSummary.CheckState = System.Windows.Forms.CheckState.Checked;
        this.isSummary.Location = new System.Drawing.Point(8, 29);
        this.isSummary.Name = "isSummary";
        this.isSummary.Size = new System.Drawing.Size(117, 27);
        this.isSummary.TabIndex = 11;
        this.isSummary.Text = "Summary";
        this.isSummary.UseVisualStyleBackColor = true;
        this.isSummary.CheckedChanged += new System.EventHandler(this.isSummary_CheckedChanged);
        // 
        // isKey
        // 
        this.isKey.AutoSize = true;
        this.isKey.Location = new System.Drawing.Point(364, 29);
        this.isKey.Name = "isKey";
        this.isKey.Size = new System.Drawing.Size(66, 27);
        this.isKey.TabIndex = 10;
        this.isKey.Text = "Key";
        this.isKey.UseVisualStyleBackColor = true;
        this.isKey.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
        // 
        // IsRequired
        // 
        this.IsRequired.AutoSize = true;
        this.IsRequired.Location = new System.Drawing.Point(245, 29);
        this.IsRequired.Name = "IsRequired";
        this.IsRequired.Size = new System.Drawing.Size(113, 27);
        this.IsRequired.TabIndex = 9;
        this.IsRequired.Text = "Required";
        this.IsRequired.UseVisualStyleBackColor = true;
        this.IsRequired.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
        // 
        // IsDisplay
        // 
        this.IsDisplay.AutoSize = true;
        this.IsDisplay.Location = new System.Drawing.Point(131, 29);
        this.IsDisplay.Name = "IsDisplay";
        this.IsDisplay.Size = new System.Drawing.Size(98, 27);
        this.IsDisplay.TabIndex = 8;
        this.IsDisplay.Text = "Display";
        this.IsDisplay.UseVisualStyleBackColor = true;
        this.IsDisplay.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
        // 
        // modelGenBtn
        // 
        this.modelGenBtn.Location = new System.Drawing.Point(8, 72);
        this.modelGenBtn.Name = "modelGenBtn";
        this.modelGenBtn.Size = new System.Drawing.Size(151, 31);
        this.modelGenBtn.TabIndex = 7;
        this.modelGenBtn.Text = "所有model產檔";
        this.modelGenBtn.UseVisualStyleBackColor = true;
        this.modelGenBtn.Click += new System.EventHandler(this.modelGenEvent);
        // 
        // schmaTool
        // 
        this.schmaTool.Controls.Add(this.ImportDescription);
        this.schmaTool.Controls.Add(this.IsScaleShow);
        this.schmaTool.Controls.Add(this.IsPrecisionShow);
        this.schmaTool.Controls.Add(this.IsLengthShow);
        this.schmaTool.Controls.Add(this.IsNotNullShow);
        this.schmaTool.Controls.Add(this.IsPrimaryKeyShow);
        this.schmaTool.Controls.Add(this.IsIdentityShow);
        this.schmaTool.Controls.Add(this.IsDefaultValueShow);
        this.schmaTool.Controls.Add(this.IsDataTypeShow);
        this.schmaTool.Controls.Add(this.IsSortShow);
        this.schmaTool.Controls.Add(this.IsColumnDescriptionShow);
        this.schmaTool.Controls.Add(this.IsTableDescriptionShow);
        this.schmaTool.Controls.Add(this.downloadTemplateBtn);
        this.schmaTool.Controls.Add(this.downloadSchemaBtn);
        this.schmaTool.Location = new System.Drawing.Point(4, 32);
        this.schmaTool.Name = "schmaTool";
        this.schmaTool.Padding = new System.Windows.Forms.Padding(3);
        this.schmaTool.Size = new System.Drawing.Size(647, 259);
        this.schmaTool.TabIndex = 2;
        this.schmaTool.Text = "資料庫規格";
        this.schmaTool.UseVisualStyleBackColor = true;
        // 
        // ImportDescription
        // 
        this.ImportDescription.Location = new System.Drawing.Point(18, 203);
        this.ImportDescription.Name = "ImportDescription";
        this.ImportDescription.Size = new System.Drawing.Size(112, 34);
        this.ImportDescription.TabIndex = 14;
        this.ImportDescription.Text = "匯入描述";
        this.ImportDescription.UseVisualStyleBackColor = true;
        this.ImportDescription.Click += new System.EventHandler(this.ImportDescriptionEvent);
        // 
        // IsScaleShow
        // 
        this.IsScaleShow.AutoSize = true;
        this.IsScaleShow.Location = new System.Drawing.Point(287, 85);
        this.IsScaleShow.Name = "IsScaleShow";
        this.IsScaleShow.Size = new System.Drawing.Size(90, 27);
        this.IsScaleShow.TabIndex = 13;
        this.IsScaleShow.Text = "小位數";
        this.IsScaleShow.UseVisualStyleBackColor = true;
        this.IsScaleShow.CheckedChanged += new System.EventHandler(this.IsScaleShow_CheckedChanged);
        // 
        // IsPrecisionShow
        // 
        this.IsPrecisionShow.AutoSize = true;
        this.IsPrecisionShow.Location = new System.Drawing.Point(202, 85);
        this.IsPrecisionShow.Name = "IsPrecisionShow";
        this.IsPrecisionShow.Size = new System.Drawing.Size(72, 27);
        this.IsPrecisionShow.TabIndex = 12;
        this.IsPrecisionShow.Text = "精度";
        this.IsPrecisionShow.UseVisualStyleBackColor = true;
        // 
        // IsLengthShow
        // 
        this.IsLengthShow.AutoSize = true;
        this.IsLengthShow.Location = new System.Drawing.Point(97, 85);
        this.IsLengthShow.Name = "IsLengthShow";
        this.IsLengthShow.Size = new System.Drawing.Size(72, 27);
        this.IsLengthShow.TabIndex = 11;
        this.IsLengthShow.Text = "長度";
        this.IsLengthShow.UseVisualStyleBackColor = true;
        this.IsLengthShow.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
        // 
        // IsNotNullShow
        // 
        this.IsNotNullShow.AutoSize = true;
        this.IsNotNullShow.Checked = true;
        this.IsNotNullShow.CheckState = System.Windows.Forms.CheckState.Checked;
        this.IsNotNullShow.Location = new System.Drawing.Point(19, 85);
        this.IsNotNullShow.Name = "IsNotNullShow";
        this.IsNotNullShow.Size = new System.Drawing.Size(72, 27);
        this.IsNotNullShow.TabIndex = 10;
        this.IsNotNullShow.Text = "必填";
        this.IsNotNullShow.UseVisualStyleBackColor = true;
        // 
        // IsPrimaryKeyShow
        // 
        this.IsPrimaryKeyShow.AutoSize = true;
        this.IsPrimaryKeyShow.Checked = true;
        this.IsPrimaryKeyShow.CheckState = System.Windows.Forms.CheckState.Checked;
        this.IsPrimaryKeyShow.Location = new System.Drawing.Point(383, 52);
        this.IsPrimaryKeyShow.Name = "IsPrimaryKeyShow";
        this.IsPrimaryKeyShow.Size = new System.Drawing.Size(72, 27);
        this.IsPrimaryKeyShow.TabIndex = 9;
        this.IsPrimaryKeyShow.Text = "主鍵";
        this.IsPrimaryKeyShow.UseVisualStyleBackColor = true;
        // 
        // IsIdentityShow
        // 
        this.IsIdentityShow.AutoSize = true;
        this.IsIdentityShow.Checked = true;
        this.IsIdentityShow.CheckState = System.Windows.Forms.CheckState.Checked;
        this.IsIdentityShow.Location = new System.Drawing.Point(287, 52);
        this.IsIdentityShow.Name = "IsIdentityShow";
        this.IsIdentityShow.Size = new System.Drawing.Size(72, 27);
        this.IsIdentityShow.TabIndex = 8;
        this.IsIdentityShow.Text = "識別";
        this.IsIdentityShow.UseVisualStyleBackColor = true;
        // 
        // IsDefaultValueShow
        // 
        this.IsDefaultValueShow.AutoSize = true;
        this.IsDefaultValueShow.Checked = true;
        this.IsDefaultValueShow.CheckState = System.Windows.Forms.CheckState.Checked;
        this.IsDefaultValueShow.Location = new System.Drawing.Point(202, 52);
        this.IsDefaultValueShow.Name = "IsDefaultValueShow";
        this.IsDefaultValueShow.Size = new System.Drawing.Size(90, 27);
        this.IsDefaultValueShow.TabIndex = 7;
        this.IsDefaultValueShow.Text = "預設值";
        this.IsDefaultValueShow.UseVisualStyleBackColor = true;
        // 
        // IsDataTypeShow
        // 
        this.IsDataTypeShow.AutoSize = true;
        this.IsDataTypeShow.Checked = true;
        this.IsDataTypeShow.CheckState = System.Windows.Forms.CheckState.Checked;
        this.IsDataTypeShow.Location = new System.Drawing.Point(97, 52);
        this.IsDataTypeShow.Name = "IsDataTypeShow";
        this.IsDataTypeShow.Size = new System.Drawing.Size(108, 27);
        this.IsDataTypeShow.TabIndex = 6;
        this.IsDataTypeShow.Text = "資料型別";
        this.IsDataTypeShow.UseVisualStyleBackColor = true;
        // 
        // IsSortShow
        // 
        this.IsSortShow.AutoSize = true;
        this.IsSortShow.Checked = true;
        this.IsSortShow.CheckState = System.Windows.Forms.CheckState.Checked;
        this.IsSortShow.Location = new System.Drawing.Point(19, 52);
        this.IsSortShow.Name = "IsSortShow";
        this.IsSortShow.Size = new System.Drawing.Size(72, 27);
        this.IsSortShow.TabIndex = 5;
        this.IsSortShow.Text = "排序";
        this.IsSortShow.UseVisualStyleBackColor = true;
        // 
        // IsColumnDescriptionShow
        // 
        this.IsColumnDescriptionShow.AutoSize = true;
        this.IsColumnDescriptionShow.Checked = true;
        this.IsColumnDescriptionShow.CheckState = System.Windows.Forms.CheckState.Checked;
        this.IsColumnDescriptionShow.Location = new System.Drawing.Point(383, 85);
        this.IsColumnDescriptionShow.Name = "IsColumnDescriptionShow";
        this.IsColumnDescriptionShow.Size = new System.Drawing.Size(90, 27);
        this.IsColumnDescriptionShow.TabIndex = 4;
        this.IsColumnDescriptionShow.Text = "欄描述";
        this.IsColumnDescriptionShow.UseVisualStyleBackColor = true;
        // 
        // IsTableDescriptionShow
        // 
        this.IsTableDescriptionShow.AutoSize = true;
        this.IsTableDescriptionShow.Checked = true;
        this.IsTableDescriptionShow.CheckState = System.Windows.Forms.CheckState.Checked;
        this.IsTableDescriptionShow.Location = new System.Drawing.Point(19, 19);
        this.IsTableDescriptionShow.Name = "IsTableDescriptionShow";
        this.IsTableDescriptionShow.Size = new System.Drawing.Size(90, 27);
        this.IsTableDescriptionShow.TabIndex = 3;
        this.IsTableDescriptionShow.Text = "表描述";
        this.IsTableDescriptionShow.UseVisualStyleBackColor = true;
        this.IsTableDescriptionShow.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
        // 
        // downloadTemplateBtn
        // 
        this.downloadTemplateBtn.Location = new System.Drawing.Point(18, 163);
        this.downloadTemplateBtn.Name = "downloadTemplateBtn";
        this.downloadTemplateBtn.Size = new System.Drawing.Size(166, 34);
        this.downloadTemplateBtn.TabIndex = 2;
        this.downloadTemplateBtn.Text = "下載匯入描述範本";
        this.downloadTemplateBtn.UseVisualStyleBackColor = true;
        this.downloadTemplateBtn.Click += new System.EventHandler(this.downloadSchemaEvent);
        // 
        // errorTextLbl
        // 
        this.errorTextLbl.BackColor = System.Drawing.SystemColors.Control;
        this.errorTextLbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.errorTextLbl.Location = new System.Drawing.Point(4, 300);
        this.errorTextLbl.Multiline = true;
        this.errorTextLbl.Name = "errorTextLbl";
        this.errorTextLbl.ReadOnly = true;
        this.errorTextLbl.Size = new System.Drawing.Size(638, 73);
        this.errorTextLbl.TabIndex = 8;
        this.errorTextLbl.Click += new System.EventHandler(this.errorTextEvent);
        // 
        // DbTool
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(654, 386);
        this.Controls.Add(this.errorTextLbl);
        this.Controls.Add(this.tabControl1);
        this.Name = "DbTool";
        this.Text = "資料庫工具";
        this.Load += new System.EventHandler(this.Form1_Load);
        this.tabControl1.ResumeLayout(false);
        this.connTool.ResumeLayout(false);
        this.connTool.PerformLayout();
        this.modelTool.ResumeLayout(false);
        this.modelTool.PerformLayout();
        this.schmaTool.ResumeLayout(false);
        this.schmaTool.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

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
