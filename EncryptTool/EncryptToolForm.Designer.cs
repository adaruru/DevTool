using System.Security.Cryptography;

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
        PaddingModeLabel = new Label();
        PaddingModeBox = new ComboBox();
        genIvBtn = new Button();
        genKeyBtn = new Button();
        CipherModeLabel = new Label();
        CipherModeBox = new ComboBox();
        resetBtn = new Button();
        ivBox = new TextBox();
        ivLabel = new Label();
        encryptWayLabel = new Label();
        encryptWayBox = new ComboBox();
        keyBox = new TextBox();
        keyLabel = new Label();
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
        tabControl1.Location = new Point(-2, -2);
        tabControl1.Margin = new Padding(2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(686, 224);
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
        encryptTab.Location = new Point(4, 24);
        encryptTab.Margin = new Padding(2);
        encryptTab.Name = "encryptTab";
        encryptTab.Padding = new Padding(2);
        encryptTab.Size = new Size(678, 196);
        encryptTab.TabIndex = 0;
        encryptTab.Text = "加密工具";
        encryptTab.UseVisualStyleBackColor = true;
        // 
        // decryptBtn
        // 
        decryptBtn.Location = new Point(366, 90);
        decryptBtn.Margin = new Padding(2);
        decryptBtn.Name = "decryptBtn";
        decryptBtn.Size = new Size(72, 22);
        decryptBtn.TabIndex = 8;
        decryptBtn.Text = "解密";
        decryptBtn.UseVisualStyleBackColor = true;
        // 
        // encryptBtn
        // 
        encryptBtn.Location = new Point(172, 90);
        encryptBtn.Margin = new Padding(2);
        encryptBtn.Name = "encryptBtn";
        encryptBtn.Size = new Size(72, 22);
        encryptBtn.TabIndex = 7;
        encryptBtn.Text = "加密";
        encryptBtn.UseVisualStyleBackColor = true;
        // 
        // afterBox
        // 
        afterBox.Location = new Point(67, 126);
        afterBox.Margin = new Padding(2);
        afterBox.Multiline = true;
        afterBox.Name = "afterBox";
        afterBox.Size = new Size(501, 63);
        afterBox.TabIndex = 4;
        // 
        // beforeBox
        // 
        beforeBox.Location = new Point(67, 12);
        beforeBox.Margin = new Padding(2);
        beforeBox.Multiline = true;
        beforeBox.Name = "beforeBox";
        beforeBox.Size = new Size(501, 63);
        beforeBox.TabIndex = 3;
        // 
        // afterLabel
        // 
        afterLabel.AutoSize = true;
        afterLabel.Location = new Point(16, 148);
        afterLabel.Margin = new Padding(2, 0, 2, 0);
        afterLabel.Name = "afterLabel";
        afterLabel.Size = new Size(43, 15);
        afterLabel.TabIndex = 1;
        afterLabel.Text = "加密後";
        // 
        // beforeLabel
        // 
        beforeLabel.AutoSize = true;
        beforeLabel.Location = new Point(16, 33);
        beforeLabel.Margin = new Padding(2, 0, 2, 0);
        beforeLabel.Name = "beforeLabel";
        beforeLabel.Size = new Size(43, 15);
        beforeLabel.TabIndex = 0;
        beforeLabel.Text = "加密前";
        // 
        // settingTab
        // 
        settingTab.Controls.Add(PaddingModeLabel);
        settingTab.Controls.Add(PaddingModeBox);
        settingTab.Controls.Add(genIvBtn);
        settingTab.Controls.Add(genKeyBtn);
        settingTab.Controls.Add(CipherModeLabel);
        settingTab.Controls.Add(CipherModeBox);
        settingTab.Controls.Add(resetBtn);
        settingTab.Controls.Add(ivBox);
        settingTab.Controls.Add(ivLabel);
        settingTab.Controls.Add(encryptWayLabel);
        settingTab.Controls.Add(encryptWayBox);
        settingTab.Controls.Add(keyBox);
        settingTab.Controls.Add(keyLabel);
        settingTab.Location = new Point(4, 24);
        settingTab.Margin = new Padding(2);
        settingTab.Name = "settingTab";
        settingTab.Padding = new Padding(2);
        settingTab.Size = new Size(678, 196);
        settingTab.TabIndex = 1;
        settingTab.Text = "加密設定";
        settingTab.UseVisualStyleBackColor = true;
        // 
        // PaddingModeLabel
        // 
        PaddingModeLabel.AutoSize = true;
        PaddingModeLabel.Location = new Point(411, 13);
        PaddingModeLabel.Margin = new Padding(2, 0, 2, 0);
        PaddingModeLabel.Name = "PaddingModeLabel";
        PaddingModeLabel.Size = new Size(77, 15);
        PaddingModeLabel.TabIndex = 17;
        PaddingModeLabel.Text = "AES填充模式";
        // 
        // PaddingModeBox
        // 
        PaddingModeBox.DisplayMember = "Value";
        PaddingModeBox.FormattingEnabled = true;
        PaddingModeBox.Location = new Point(496, 10);
        PaddingModeBox.Margin = new Padding(2);
        PaddingModeBox.Name = "PaddingModeBox";
        PaddingModeBox.Size = new Size(112, 23);
        PaddingModeBox.TabIndex = 16;
        PaddingModeBox.ValueMember = "Key";
        // 
        // genIvBtn
        // 
        genIvBtn.BackColor = SystemColors.Control;
        genIvBtn.Location = new Point(414, 102);
        genIvBtn.Margin = new Padding(2);
        genIvBtn.Name = "genIvBtn";
        genIvBtn.Size = new Size(86, 25);
        genIvBtn.TabIndex = 15;
        genIvBtn.Text = "建 Iv";
        genIvBtn.UseVisualStyleBackColor = false;
        // 
        // genKeyBtn
        // 
        genKeyBtn.BackColor = SystemColors.Control;
        genKeyBtn.Location = new Point(414, 66);
        genKeyBtn.Margin = new Padding(2);
        genKeyBtn.Name = "genKeyBtn";
        genKeyBtn.Size = new Size(86, 25);
        genKeyBtn.TabIndex = 14;
        genKeyBtn.Text = "建 Key";
        genKeyBtn.UseVisualStyleBackColor = false;
        // 
        // CipherModeLabel
        // 
        CipherModeLabel.AutoSize = true;
        CipherModeLabel.Location = new Point(203, 13);
        CipherModeLabel.Margin = new Padding(2, 0, 2, 0);
        CipherModeLabel.Name = "CipherModeLabel";
        CipherModeLabel.Size = new Size(77, 15);
        CipherModeLabel.TabIndex = 13;
        CipherModeLabel.Text = "AES加密模式";
        // 
        // CipherModeBox
        // 
        CipherModeBox.DisplayMember = "Value";
        CipherModeBox.FormattingEnabled = true;
        CipherModeBox.Location = new Point(288, 10);
        CipherModeBox.Margin = new Padding(2);
        CipherModeBox.Name = "CipherModeBox";
        CipherModeBox.Size = new Size(112, 23);
        CipherModeBox.TabIndex = 12;
        CipherModeBox.ValueMember = "Key";
        // 
        // resetBtn
        // 
        resetBtn.BackColor = SystemColors.Control;
        resetBtn.Location = new Point(18, 147);
        resetBtn.Margin = new Padding(2);
        resetBtn.Name = "resetBtn";
        resetBtn.Size = new Size(86, 25);
        resetBtn.TabIndex = 11;
        resetBtn.Text = "重置設定";
        resetBtn.UseVisualStyleBackColor = false;
        // 
        // ivBox
        // 
        ivBox.Location = new Point(87, 102);
        ivBox.Margin = new Padding(2);
        ivBox.Multiline = true;
        ivBox.Name = "ivBox";
        ivBox.Size = new Size(324, 25);
        ivBox.TabIndex = 8;
        ivBox.TextChanged += IvBox_TextChanged;
        // 
        // ivLabel
        // 
        ivLabel.AutoSize = true;
        ivLabel.Location = new Point(12, 105);
        ivLabel.Margin = new Padding(2, 0, 2, 0);
        ivLabel.Name = "ivLabel";
        ivLabel.Size = new Size(69, 15);
        ivLabel.TabIndex = 7;
        ivLabel.Text = "IV 初始向量";
        // 
        // encryptWayLabel
        // 
        encryptWayLabel.AutoSize = true;
        encryptWayLabel.Location = new Point(12, 10);
        encryptWayLabel.Margin = new Padding(2, 0, 2, 0);
        encryptWayLabel.Name = "encryptWayLabel";
        encryptWayLabel.Size = new Size(55, 15);
        encryptWayLabel.TabIndex = 6;
        encryptWayLabel.Text = "加密方式";
        // 
        // encryptWayBox
        // 
        encryptWayBox.DisplayMember = "Value";
        encryptWayBox.FormattingEnabled = true;
        encryptWayBox.Location = new Point(74, 10);
        encryptWayBox.Margin = new Padding(2);
        encryptWayBox.Name = "encryptWayBox";
        encryptWayBox.Size = new Size(118, 23);
        encryptWayBox.TabIndex = 5;
        encryptWayBox.ValueMember = "Key";
        // 
        // keyBox
        // 
        keyBox.Location = new Point(87, 67);
        keyBox.Margin = new Padding(2);
        keyBox.Multiline = true;
        keyBox.Name = "keyBox";
        keyBox.Size = new Size(324, 25);
        keyBox.TabIndex = 4;
        // 
        // keyLabel
        // 
        keyLabel.AutoSize = true;
        keyLabel.Location = new Point(12, 73);
        keyLabel.Margin = new Padding(2, 0, 2, 0);
        keyLabel.Name = "keyLabel";
        keyLabel.Size = new Size(54, 15);
        keyLabel.TabIndex = 1;
        keyLabel.Text = "Key 密鑰";
        // 
        // errorTextLbl
        // 
        errorTextLbl.BackColor = SystemColors.Control;
        errorTextLbl.BorderStyle = BorderStyle.None;
        errorTextLbl.Location = new Point(1, 223);
        errorTextLbl.Margin = new Padding(2);
        errorTextLbl.Multiline = true;
        errorTextLbl.Name = "errorTextLbl";
        errorTextLbl.ReadOnly = true;
        errorTextLbl.Size = new Size(583, 54);
        errorTextLbl.TabIndex = 10;
        // 
        // EncryptToolForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(685, 279);
        Controls.Add(errorTextLbl);
        Controls.Add(tabControl1);
        Margin = new Padding(2);
        Name = "EncryptToolForm";
        Text = "EncryptTool";
        Load += EncryptToolFormLoad;
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
    private Label keyLabel;
    private TextBox keyBox;
    private ComboBox encryptWayBox;
    private Label encryptWayLabel;
    private TextBox errorTextLbl;
    private TextBox ivBox;
    private Label ivLabel;
    private Button resetBtn;
    private ComboBox CipherModeBox;
    private Label CipherModeLabel;
    private Button genKeyBtn;
    private Button genIvBtn;
    private Label PaddingModeLabel;
    private ComboBox PaddingModeBox;
}
