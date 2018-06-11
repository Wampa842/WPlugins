namespace WPlugins.Common
{
	partial class AboutForm
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
			this.websiteLink = new System.Windows.Forms.LinkLabel();
			this.githubLink = new System.Windows.Forms.LinkLabel();
			this.releasesLink = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.issuesLink = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.versionGroup = new System.Windows.Forms.GroupBox();
			this.updateHintLabel = new System.Windows.Forms.LinkLabel();
			this.fetchVersionButton = new System.Windows.Forms.Button();
			this.latestVersionLabel = new System.Windows.Forms.Label();
			this.currentVersionLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.licenseGroup = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.showLicenseButton = new System.Windows.Forms.Button();
			this.versionGroup.SuspendLayout();
			this.licenseGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// websiteLink
			// 
			this.websiteLink.AutoSize = true;
			this.websiteLink.Location = new System.Drawing.Point(166, 29);
			this.websiteLink.Name = "websiteLink";
			this.websiteLink.Size = new System.Drawing.Size(46, 13);
			this.websiteLink.TabIndex = 2;
			this.websiteLink.TabStop = true;
			this.websiteLink.Text = "Website";
			this.websiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLink_LinkClicked);
			// 
			// githubLink
			// 
			this.githubLink.AutoSize = true;
			this.githubLink.Location = new System.Drawing.Point(166, 9);
			this.githubLink.Name = "githubLink";
			this.githubLink.Size = new System.Drawing.Size(40, 13);
			this.githubLink.TabIndex = 2;
			this.githubLink.TabStop = true;
			this.githubLink.Text = "GitHub";
			this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
			// 
			// releasesLink
			// 
			this.releasesLink.AutoSize = true;
			this.releasesLink.Location = new System.Drawing.Point(222, 9);
			this.releasesLink.Name = "releasesLink";
			this.releasesLink.Size = new System.Drawing.Size(51, 13);
			this.releasesLink.TabIndex = 3;
			this.releasesLink.TabStop = true;
			this.releasesLink.Text = "Releases";
			this.releasesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.releasesLink_LinkClicked);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Developed by Wampa842";
			// 
			// issuesLink
			// 
			this.issuesLink.AutoSize = true;
			this.issuesLink.Location = new System.Drawing.Point(222, 29);
			this.issuesLink.Name = "issuesLink";
			this.issuesLink.Size = new System.Drawing.Size(37, 13);
			this.issuesLink.TabIndex = 3;
			this.issuesLink.TabStop = true;
			this.issuesLink.Text = "Issues";
			this.issuesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.issuesLink_LinkClicked);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "WPlugins";
			// 
			// versionGroup
			// 
			this.versionGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.versionGroup.Controls.Add(this.updateHintLabel);
			this.versionGroup.Controls.Add(this.fetchVersionButton);
			this.versionGroup.Controls.Add(this.latestVersionLabel);
			this.versionGroup.Controls.Add(this.currentVersionLabel);
			this.versionGroup.Controls.Add(this.label5);
			this.versionGroup.Controls.Add(this.label3);
			this.versionGroup.Location = new System.Drawing.Point(12, 116);
			this.versionGroup.Name = "versionGroup";
			this.versionGroup.Size = new System.Drawing.Size(308, 74);
			this.versionGroup.TabIndex = 4;
			this.versionGroup.TabStop = false;
			this.versionGroup.Text = "Version";
			// 
			// updateHintLabel
			// 
			this.updateHintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.updateHintLabel.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.updateHintLabel.Location = new System.Drawing.Point(6, 75);
			this.updateHintLabel.Name = "updateHintLabel";
			this.updateHintLabel.Size = new System.Drawing.Size(296, 15);
			this.updateHintLabel.TabIndex = 2;
			this.updateHintLabel.Text = "hidden";
			this.updateHintLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.updateHintLabel.Visible = false;
			this.updateHintLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateHintLabel_LinkClicked);
			// 
			// fetchVersionButton
			// 
			this.fetchVersionButton.Location = new System.Drawing.Point(168, 44);
			this.fetchVersionButton.Name = "fetchVersionButton";
			this.fetchVersionButton.Size = new System.Drawing.Size(134, 22);
			this.fetchVersionButton.TabIndex = 1;
			this.fetchVersionButton.Text = "Check for updates";
			this.fetchVersionButton.UseVisualStyleBackColor = true;
			this.fetchVersionButton.Click += new System.EventHandler(this.fetchVersionButton_Click);
			// 
			// latestVersionLabel
			// 
			this.latestVersionLabel.AutoSize = true;
			this.latestVersionLabel.Location = new System.Drawing.Point(91, 49);
			this.latestVersionLabel.Name = "latestVersionLabel";
			this.latestVersionLabel.Size = new System.Drawing.Size(57, 13);
			this.latestVersionLabel.TabIndex = 0;
			this.latestVersionLabel.Text = "(unknown)";
			// 
			// currentVersionLabel
			// 
			this.currentVersionLabel.AutoSize = true;
			this.currentVersionLabel.Location = new System.Drawing.Point(91, 25);
			this.currentVersionLabel.Name = "currentVersionLabel";
			this.currentVersionLabel.Size = new System.Drawing.Size(31, 13);
			this.currentVersionLabel.TabIndex = 0;
			this.currentVersionLabel.Text = "0.1.2";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(23, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Latest:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Current:";
			// 
			// licenseGroup
			// 
			this.licenseGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.licenseGroup.Controls.Add(this.label6);
			this.licenseGroup.Controls.Add(this.label4);
			this.licenseGroup.Controls.Add(this.showLicenseButton);
			this.licenseGroup.Location = new System.Drawing.Point(12, 50);
			this.licenseGroup.Name = "licenseGroup";
			this.licenseGroup.Size = new System.Drawing.Size(308, 60);
			this.licenseGroup.TabIndex = 5;
			this.licenseGroup.TabStop = false;
			this.licenseGroup.Text = "License";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 38);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(151, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "License: GNU GPL-3.0-or-later";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Copyright (C) 2018 Wampa842";
			// 
			// showLicenseButton
			// 
			this.showLicenseButton.Location = new System.Drawing.Point(168, 15);
			this.showLicenseButton.Name = "showLicenseButton";
			this.showLicenseButton.Size = new System.Drawing.Size(134, 23);
			this.showLicenseButton.TabIndex = 0;
			this.showLicenseButton.Text = "Show copyright notice";
			this.showLicenseButton.UseVisualStyleBackColor = true;
			this.showLicenseButton.Click += new System.EventHandler(this.showLicenseButton_Click);
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(332, 202);
			this.Controls.Add(this.licenseGroup);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.issuesLink);
			this.Controls.Add(this.versionGroup);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.websiteLink);
			this.Controls.Add(this.releasesLink);
			this.Controls.Add(this.githubLink);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "About & update";
			this.versionGroup.ResumeLayout(false);
			this.versionGroup.PerformLayout();
			this.licenseGroup.ResumeLayout(false);
			this.licenseGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel websiteLink;
		private System.Windows.Forms.LinkLabel githubLink;
		private System.Windows.Forms.LinkLabel releasesLink;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel issuesLink;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox versionGroup;
		private System.Windows.Forms.Label latestVersionLabel;
		private System.Windows.Forms.Label currentVersionLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button fetchVersionButton;
		private System.Windows.Forms.LinkLabel updateHintLabel;
		private System.Windows.Forms.GroupBox licenseGroup;
		private System.Windows.Forms.Button showLicenseButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
	}
}