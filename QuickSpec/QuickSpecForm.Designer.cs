namespace QuickSpec
{
    partial class QuickSpecForm
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
            GenQuickSpecBtn = new Button();
            SuspendLayout();
            // 
            // GenQuickSpecBtn
            // 
            GenQuickSpecBtn.Location = new Point(76, 12);
            GenQuickSpecBtn.Name = "GenQuickSpecBtn";
            GenQuickSpecBtn.Size = new Size(131, 29);
            GenQuickSpecBtn.TabIndex = 0;
            GenQuickSpecBtn.Text = "GenQuickSpec";
            GenQuickSpecBtn.UseVisualStyleBackColor = true;
            GenQuickSpecBtn.Click += GenQuickSpecClick;
            // 
            // QuickSpecForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 52);
            Controls.Add(GenQuickSpecBtn);
            Name = "QuickSpecForm";
            Text = "QuickSpec";
            ResumeLayout(false);
        }

        #endregion

        private Button GenQuickSpecBtn;
    }
}
