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
            beforeLabel = new Label();
            settingTab = new TabPage();
            afterLabel = new Label();
            beforeBox = new TextBox();
            tabControl1.SuspendLayout();
            encryptTab.SuspendLayout();
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
            // 
            // beforeLabel
            // 
            beforeLabel.AutoSize = true;
            beforeLabel.Location = new Point(25, 21);
            beforeLabel.Name = "label1";
            beforeLabel.Size = new Size(64, 23);
            beforeLabel.TabIndex = 0;
            beforeLabel.Text = "加密前";
            beforeLabel.Click += label1_Click_1;
            // 
            // afterLabel
            // 
            afterLabel.AutoSize = true;
            afterLabel.Location = new Point(35, 201);
            afterLabel.Name = "label2";
            afterLabel.Size = new Size(64, 23);
            afterLabel.TabIndex = 1;
            afterLabel.Text = "加密後";
            // 
            // beforeBox
            // 
            beforeBox.Location = new Point(105, 18);
            beforeBox.Multiline = true;
            beforeBox.Name = "beforeBox";
            beforeBox.Size = new Size(530, 95);
            beforeBox.TabIndex = 3;
            // 
            // settingTab
            // 
            settingTab.Location = new Point(4, 32);
            settingTab.Name = "settingTab";
            settingTab.Padding = new Padding(3);
            settingTab.Size = new Size(913, 353);
            settingTab.TabIndex = 1;
            settingTab.Text = "加密設定";
            settingTab.UseVisualStyleBackColor = true;
            // 
            // EncryptTool
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 538);
            Controls.Add(tabControl1);
            Name = "EncryptTool";
            Text = "EncryptTool";
            tabControl1.ResumeLayout(false);
            encryptTab.ResumeLayout(false);
            encryptTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage encryptTab;
        private TabPage settingTab;
        private Label beforeLabel;
        private Label afterLabel;
        private TextBox beforeBox;
    }
}