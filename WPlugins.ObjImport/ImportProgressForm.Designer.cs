namespace WPlugins.ObjImport
{
	partial class ImportProgressForm
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
            this.totalProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelProcessButton = new System.Windows.Forms.Button();
            this.overlayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // totalProgressBar
            // 
            this.totalProgressBar.Location = new System.Drawing.Point(12, 30);
            this.totalProgressBar.Name = "totalProgressBar";
            this.totalProgressBar.Size = new System.Drawing.Size(373, 27);
            this.totalProgressBar.Step = 1;
            this.totalProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.totalProgressBar.TabIndex = 1;
            // 
            // cancelProcessButton
            // 
            this.cancelProcessButton.Location = new System.Drawing.Point(77, 63);
            this.cancelProcessButton.Name = "cancelProcessButton";
            this.cancelProcessButton.Size = new System.Drawing.Size(243, 23);
            this.cancelProcessButton.TabIndex = 7;
            this.cancelProcessButton.Text = "Cancel";
            this.cancelProcessButton.UseVisualStyleBackColor = true;
            this.cancelProcessButton.Click += new System.EventHandler(this.cancelProcessButton_Click);
            // 
            // overlayLabel
            // 
            this.overlayLabel.BackColor = System.Drawing.Color.Transparent;
            this.overlayLabel.Location = new System.Drawing.Point(148, 9);
            this.overlayLabel.Name = "overlayLabel";
            this.overlayLabel.Size = new System.Drawing.Size(100, 18);
            this.overlayLabel.TabIndex = 8;
            this.overlayLabel.Text = "Please wait...";
            this.overlayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImportProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 98);
            this.ControlBox = false;
            this.Controls.Add(this.overlayLabel);
            this.Controls.Add(this.cancelProcessButton);
            this.Controls.Add(this.totalProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportProgressForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import progress";
            this.TopMost = true;
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button cancelProcessButton;
		private System.Windows.Forms.Label overlayLabel;
		private System.Windows.Forms.ProgressBar totalProgressBar;
	}
}