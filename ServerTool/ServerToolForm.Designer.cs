partial class ServerToolForm
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
        instalIISBtn = new Button();
        SuspendLayout();
        // 
        // instalIISBtn
        // 
        instalIISBtn.Location = new Point(74, 60);
        instalIISBtn.Name = "instalIISBtn";
        instalIISBtn.Size = new Size(185, 34);
        instalIISBtn.TabIndex = 0;
        instalIISBtn.Text = "安裝IIS";
        instalIISBtn.UseVisualStyleBackColor = true;
        instalIISBtn.Click += instalIIS;
        // 
        // ServerToolForm
        // 
        AutoScaleDimensions = new SizeF(9F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(324, 162);
        Controls.Add(instalIISBtn);
        Name = "ServerToolForm";
        Text = "ServerToolForm";
        ResumeLayout(false);
    }

    #endregion

    private Button instalIISBtn;
}