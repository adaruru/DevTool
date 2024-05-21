partial class EncryptToolForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControl1 = new TabControl();
        encryptTab = new TabPage();
        decryptBtn = new Button();
        encryptBtn = new Button();
        afterBox = new TextBox();
        beforeBox = new TextBox();
        afterLabel = new Label();
        beforeLabel = new Label();
        settingTab = new TabPage();
        DESIvBox = new TextBox();
        DESIvLabel = new Label();
        encryptWayLabel = new Label();
        encryptWay = new ComboBox();
        DESKeyBox = new TextBox();
        DESKeyLabel = new Label();
        errorTextLbl = new TextBox();
        tabControl1.SuspendLayout();
        encryptTab.SuspendLayout();
        settingTab.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(encryptTab);
        tabControl1.Controls.Add(settingTab);
        tabControl1.Location = new Point(-3, -2);
        tabControl1.Margin = new Padding(2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(754, 284);
        tabControl1.TabIndex = 9;
        // 
        // encryptTab
        // 
        encryptTab.Controls.Add(decryptBtn);
        encryptTab.Controls.Add(encryptBtn);
        encryptTab.Controls.Add(afterBox);
        encryptTab.Controls.Add(beforeBox);
        encryptTab.Controls.Add(afterLabel);
        encryptTab.Controls.Add(beforeLabel);
        encryptTab.Location = new Point(4, 28);
        encryptTab.Margin = new Padding(2);
        encryptTab.Name = "encryptTab";
        encryptTab.Padding = new Padding(2);
        encryptTab.Size = new Size(746, 252);
        encryptTab.TabIndex = 0;
        encryptTab.Text = "加密工具";
        encryptTab.UseVisualStyleBackColor = true;
        encryptTab.Click += encryptTabClick;
        // 
        // decryptBtn
        // 
        decryptBtn.Location = new Point(470, 114);
        decryptBtn.Margin = new Padding(2);
        decryptBtn.Name = "decryptBtn";
        decryptBtn.Size = new Size(92, 28);
        decryptBtn.TabIndex = 8;
        decryptBtn.Text = "解密";
        decryptBtn.UseVisualStyleBackColor = true;
        decryptBtn.Click += decryptBtnClick;
        // 
        // encryptBtn
        // 
        encryptBtn.Location = new Point(221, 114);
        encryptBtn.Margin = new Padding(2);
        encryptBtn.Name = "encryptBtn";
        encryptBtn.Size = new Size(92, 28);
        encryptBtn.TabIndex = 7;
        encryptBtn.Text = "加密";
        encryptBtn.UseVisualStyleBackColor = true;
        encryptBtn.Click += encryptClick;
        // 
        // afterBox
        // 
        afterBox.Location = new Point(86, 159);
        afterBox.Margin = new Padding(2);
        afterBox.Multiline = true;
        afterBox.Name = "afterBox";
        afterBox.Size = new Size(643, 79);
        afterBox.TabIndex = 4;
        // 
        // beforeBox
        // 
        beforeBox.Location = new Point(86, 15);
        beforeBox.Margin = new Padding(2);
        beforeBox.Multiline = true;
        beforeBox.Name = "beforeBox";
        beforeBox.Size = new Size(643, 79);
        beforeBox.TabIndex = 3;
        // 
        // afterLabel
        // 
        afterLabel.AutoSize = true;
        afterLabel.Location = new Point(20, 188);
        afterLabel.Margin = new Padding(2, 0, 2, 0);
        afterLabel.Name = "afterLabel";
        afterLabel.Size = new Size(54, 19);
        afterLabel.TabIndex = 1;
        afterLabel.Text = "加密後";
        // 
        // beforeLabel
        // 
        beforeLabel.AutoSize = true;
        beforeLabel.Location = new Point(20, 42);
        beforeLabel.Margin = new Padding(2, 0, 2, 0);
        beforeLabel.Name = "beforeLabel";
        beforeLabel.Size = new Size(54, 19);
        beforeLabel.TabIndex = 0;
        beforeLabel.Text = "加密前";
        beforeLabel.Click += beforeLabelClick;
        // 
        // settingTab
        // 
        settingTab.Controls.Add(DESIvBox);
        settingTab.Controls.Add(DESIvLabel);
        settingTab.Controls.Add(encryptWayLabel);
        settingTab.Controls.Add(encryptWay);
        settingTab.Controls.Add(DESKeyBox);
        settingTab.Controls.Add(DESKeyLabel);
        settingTab.Location = new Point(4, 28);
        settingTab.Margin = new Padding(2);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(2);
        settingTab.Size = new Size(746, 252);
        settingTab.TabIndex = 1;
        settingTab.Text = "加密設定";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // DESIvBox
        // 
        DESIvBox.Location = new Point(95, 97);
        DESIvBox.Margin = new Padding(2);
        DESIvBox.Multiline = true;
        DESIvBox.Name = "DESIvBox";
        DESIvBox.Size = new Size(314, 30);
        DESIvBox.TabIndex = 8;
        DESIvBox.Text = "0(uS6B'U";
        DESIvBox.TextChanged += DESIvBox_TextChanged;
        // 
        // DESIvLabel
        // 
        DESIvLabel.AutoSize = true;
        DESIvLabel.Location = new Point(23, 100);
        DESIvLabel.Margin = new Padding(2, 0, 2, 0);
        DESIvLabel.Name = "DESIvLabel";
        DESIvLabel.Size = new Size(49, 19);
        DESIvLabel.TabIndex = 7;
        DESIvLabel.Text = "DESIv";
        // 
        // encryptWayLabel
        // 
        encryptWayLabel.AutoSize = true;
        encryptWayLabel.Location = new Point(16, 13);
        encryptWayLabel.Margin = new Padding(2, 0, 2, 0);
        encryptWayLabel.Name = "encryptWayLabel";
        encryptWayLabel.Size = new Size(69, 19);
        encryptWayLabel.TabIndex = 6;
        encryptWayLabel.Text = "加密方式";
        // 
        // encryptWay
        // 
        encryptWay.DisplayMember = "Value";
        encryptWay.FormattingEnabled = true;
        encryptWay.Location = new Point(95, 13);
        encryptWay.Margin = new Padding(2);
        encryptWay.Name = "encryptWay";
        encryptWay.Size = new Size(314, 27);
        encryptWay.TabIndex = 5;
        encryptWay.ValueMember = "Key";
        encryptWay.SelectedIndexChanged += SelectedEncryptChanged;
        // 
        // DESKeyBox
        // 
        DESKeyBox.Location = new Point(95, 52);
        DESKeyBox.Margin = new Padding(2);
        DESKeyBox.Multiline = true;
        DESKeyBox.Name = "DESKeyBox";
        DESKeyBox.Size = new Size(314, 30);
        DESKeyBox.TabIndex = 4;
        DESKeyBox.Text = "jG6$q)n%";
        DESKeyBox.TextChanged += setting1Box_TextChanged;
        // 
        // DESKeyLabel
        // 
        DESKeyLabel.AutoSize = true;
        DESKeyLabel.Location = new Point(23, 55);
        DESKeyLabel.Margin = new Padding(2, 0, 2, 0);
        DESKeyLabel.Name = "DESKeyLabel";
        DESKeyLabel.Size = new Size(62, 19);
        DESKeyLabel.TabIndex = 1;
        DESKeyLabel.Text = "DESKey";
        // 
        // errorTextLbl
        // 
        errorTextLbl.BackColor = SystemColors.Control;
        errorTextLbl.BorderStyle = BorderStyle.None;
        errorTextLbl.Location = new Point(1, 282);
        errorTextLbl.Margin = new Padding(2);
        errorTextLbl.Multiline = true;
        errorTextLbl.Name = "errorTextLbl";
        errorTextLbl.ReadOnly = true;
        errorTextLbl.Size = new Size(750, 68);
        errorTextLbl.TabIndex = 10;
        // 
        // EncryptToolForm
        // 
        AutoScaleDimensions = new SizeF(9F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(746, 354);
        Controls.Add(errorTextLbl);
        Controls.Add(tabControl1);
        Margin = new Padding(2);
        Name = "EncryptToolForm";
        Text = "EncryptTool";
        Load += EncryptToolForm_Load;
        tabControl1.ResumeLayout(false);
        encryptTab.ResumeLayout(false);
        encryptTab.PerformLayout();
        settingTab.ResumeLayout(false);
        settingTab.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private TabControl tabControl1;
    private TabPage encryptTab;
    private TabPage settingTab;
    private Label beforeLabel;
    private Label afterLabel;
    private TextBox beforeBox;
    private TextBox afterBox;
    private Button encryptBtn;
    private Button decryptBtn;
    private Label DESKeyLabel;
    private TextBox DESKeyBox;
    private ComboBox encryptWay;
    private Label encryptWayLabel;

    private Dictionary<int, string> GetEncryptionMethods()
    {
        var encryptionMethods = new Dictionary<int, string>();
        encryptionMethods = Enum.GetValues(typeof(EncryptWayEnum))
              .Cast<EncryptWayEnum>()
              .ToDictionary(e => (int)e, e => e.ToString());
        return encryptionMethods;
    }

    private TextBox errorTextLbl;
    private TextBox DESIvBox;
    private Label DESIvLabel;
}
