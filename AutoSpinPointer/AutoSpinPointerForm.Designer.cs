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
            components = new System.ComponentModel.Container();
            pointSpinBtn = new Button();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // pointSpinBtn
            // 
            pointSpinBtn.Location = new Point(76, 25);
            pointSpinBtn.Name = "pointSpinBtn";
            pointSpinBtn.Size = new Size(94, 29);
            pointSpinBtn.TabIndex = 0;
            pointSpinBtn.Text = "開始轉圈";
            toolTip1.SetToolTip(pointSpinBtn, " 按空白健停止轉圈或繼續");
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
            toolTip1.SetToolTip(this, "  ");
            KeyDown += AutoSpinPointerForm_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Button pointSpinBtn;
        private ToolTip toolTip1;
    }
}
