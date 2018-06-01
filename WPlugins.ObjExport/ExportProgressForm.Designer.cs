namespace WPlugins.ObjExport
{
	partial class ExportProgressForm
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
			this.exportProgressBar = new System.Windows.Forms.ProgressBar();
			this.cancelExportButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// exportProgressBar
			// 
			this.exportProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.exportProgressBar.Location = new System.Drawing.Point(0, 0);
			this.exportProgressBar.Name = "exportProgressBar";
			this.exportProgressBar.Size = new System.Drawing.Size(284, 25);
			this.exportProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.exportProgressBar.TabIndex = 0;
			// 
			// cancelExportButton
			// 
			this.cancelExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelExportButton.Location = new System.Drawing.Point(12, 31);
			this.cancelExportButton.Name = "cancelExportButton";
			this.cancelExportButton.Size = new System.Drawing.Size(260, 24);
			this.cancelExportButton.TabIndex = 1;
			this.cancelExportButton.Text = "Cancel";
			this.cancelExportButton.UseVisualStyleBackColor = true;
			// 
			// ExportProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 58);
			this.ControlBox = false;
			this.Controls.Add(this.cancelExportButton);
			this.Controls.Add(this.exportProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ExportProgressForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Export progress";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar exportProgressBar;
		private System.Windows.Forms.Button cancelExportButton;
	}
}