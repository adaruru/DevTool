// DevTool 1.1 
// Copyright (C) 2024, Adaruru

namespace AutoSpinPointer
{
    partial class AutoSpinPointerForm
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
            pointSpinBtn = new Button();
            SuspendLayout();
            // 
            // pointSpinBtn
            // 
            pointSpinBtn.Location = new Point(36, 26);
            pointSpinBtn.Name = "pointSpinBtn";
            pointSpinBtn.Size = new Size(94, 29);
            pointSpinBtn.TabIndex = 0;
            pointSpinBtn.Text = "開始轉圈";
            pointSpinBtn.UseVisualStyleBackColor = true;
            pointSpinBtn.Click += pointSpinBtnClick;
            // 
            // AutoSpinPointerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(249, 116);
            Controls.Add(pointSpinBtn);
            KeyPreview = true;
            Name = "AutoSpinPointerForm";
            Text = "         ";
            KeyDown += AutoSpinPointerForm_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Button pointSpinBtn;
    }
}
