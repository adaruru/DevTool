namespace Tool
{
    partial class EncryptTool
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
            decodeBtn = new Button();
            encryptBtn = new Button();
            afterBox = new TextBox();
            beforeBox = new TextBox();
            afterLabel = new Label();
            beforeLabel = new Label();
            settingTab = new TabPage();
            encryptWayLabel = new Label();
            encryptWay = new ComboBox();
            setting1Box = new TextBox();
            setting1 = new Label();
            tabControl1.SuspendLayout();
            encryptTab.SuspendLayout();
            settingTab.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(encryptTab);
            tabControl1.Controls.Add(settingTab);
            tabControl1.Location = new Point(-4, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(921, 389);
            tabControl1.TabIndex = 9;
            // 
            // encryptTab
            // 
            encryptTab.Controls.Add(decodeBtn);
            encryptTab.Controls.Add(encryptBtn);
            encryptTab.Controls.Add(afterBox);
            encryptTab.Controls.Add(beforeBox);
            encryptTab.Controls.Add(afterLabel);
            encryptTab.Controls.Add(beforeLabel);
            encryptTab.Location = new Point(4, 32);
            encryptTab.Name = "encryptTab";
            encryptTab.Padding = new Padding(3);
            encryptTab.Size = new Size(913, 353);
            encryptTab.TabIndex = 0;
            encryptTab.Text = "加密工具";
            encryptTab.UseVisualStyleBackColor = true;
            encryptTab.Click += encryptTabClick;
            // 
            // decodeBtn
            // 
            decodeBtn.Location = new Point(574, 138);
            decodeBtn.Name = "decodeBtn";
            decodeBtn.Size = new Size(112, 34);
            decodeBtn.TabIndex = 8;
            decodeBtn.Text = "解密";
            decodeBtn.UseVisualStyleBackColor = true;
            decodeBtn.Click += decodeBtnClick;
            // 
            // encryptBtn
            // 
            encryptBtn.Location = new Point(270, 138);
            encryptBtn.Name = "encryptBtn";
            encryptBtn.Size = new Size(112, 34);
            encryptBtn.TabIndex = 7;
            encryptBtn.Text = "加密";
            encryptBtn.UseVisualStyleBackColor = true;
            encryptBtn.Click += encryptClick;
            // 
            // afterBox
            // 
            afterBox.Location = new Point(105, 193);
            afterBox.Multiline = true;
            afterBox.Name = "afterBox";
            afterBox.Size = new Size(785, 95);
            afterBox.TabIndex = 4;
            // 
            // beforeBox
            // 
            beforeBox.Location = new Point(105, 18);
            beforeBox.Multiline = true;
            beforeBox.Name = "beforeBox";
            beforeBox.Size = new Size(785, 95);
            beforeBox.TabIndex = 3;
            // 
            // afterLabel
            // 
            afterLabel.AutoSize = true;
            afterLabel.Location = new Point(25, 228);
            afterLabel.Name = "afterLabel";
            afterLabel.Size = new Size(64, 23);
            afterLabel.TabIndex = 1;
            afterLabel.Text = "加密後";
            // 
            // beforeLabel
            // 
            beforeLabel.AutoSize = true;
            beforeLabel.Location = new Point(25, 51);
            beforeLabel.Name = "beforeLabel";
            beforeLabel.Size = new Size(64, 23);
            beforeLabel.TabIndex = 0;
            beforeLabel.Text = "加密前";
            beforeLabel.Click += label1_Click_1;
            // 
            // settingTab
            // 
            settingTab.Controls.Add(encryptWayLabel);
            settingTab.Controls.Add(encryptWay);
            settingTab.Controls.Add(setting1Box);
            settingTab.Controls.Add(setting1);
            settingTab.Location = new Point(4, 32);
            settingTab.Name = "settingTab";
            settingTab.Padding = new Padding(3);
            settingTab.Size = new Size(913, 353);
            settingTab.TabIndex = 1;
            settingTab.Text = "加密設定";
            settingTab.UseVisualStyleBackColor = true;
            // 
            // encryptWayLabel
            // 
            encryptWayLabel.AutoSize = true;
            encryptWayLabel.Location = new Point(19, 16);
            encryptWayLabel.Name = "encryptWayLabel";
            encryptWayLabel.Size = new Size(82, 23);
            encryptWayLabel.TabIndex = 6;
            encryptWayLabel.Text = "加密方式";
            // 
            // encryptWay
            // 
            encryptWay.FormattingEnabled = true;
            encryptWay.Items.AddRange(new object[] { "AES（Advanced Encryption Standard）", "DES（Data Encryption Standard）", "3DES（Triple DES）", "Blowfish", "Twofish", "RC4", "RSA（Rivest-Shamir-Adleman）", "ECC（Elliptic Curve Cryptography）", "DSA（Digital Signature Algorithm）", "PGP（Pretty Good Privacy）", "S/MIME（Secure/Multipurpose Internet Mail Extensions）" });
            encryptWay.Location = new Point(116, 16);
            encryptWay.Name = "encryptWay";
            encryptWay.Size = new Size(383, 31);
            encryptWay.TabIndex = 5;
            encryptWay.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // setting1Box
            // 
            setting1Box.Location = new Point(116, 94);
            setting1Box.Multiline = true;
            setting1Box.Name = "setting1Box";
            setting1Box.Size = new Size(539, 47);
            setting1Box.TabIndex = 4;
            // 
            // setting1
            // 
            setting1.AutoSize = true;
            setting1.Location = new Point(19, 97);
            setting1.Name = "setting1";
            setting1.Size = new Size(56, 23);
            setting1.TabIndex = 1;
            setting1.Text = "設定1";
            // 
            // EncryptTool
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 351);
            Controls.Add(tabControl1);
            Name = "EncryptTool";
            Text = "EncryptTool";
            tabControl1.ResumeLayout(false);
            encryptTab.ResumeLayout(false);
            encryptTab.PerformLayout();
            settingTab.ResumeLayout(false);
            settingTab.PerformLayout();
            ResumeLayout(false);
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
        private Button decodeBtn;
        private Label setting1;
        private TextBox setting1Box;
        private ComboBox encryptWay;
        private Label encryptWayLabel;
    }
}