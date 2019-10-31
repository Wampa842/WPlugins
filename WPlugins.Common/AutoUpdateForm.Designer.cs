namespace WPlugins.Common
{
    partial class AutoUpdateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.newVersionLabel = new System.Windows.Forms.Label();
            this.thisVersionLabel = new System.Windows.Forms.Label();
            this.visitUpdateButton = new System.Windows.Forms.Button();
            this.ignoreButton = new System.Windows.Forms.Button();
            this.skipButton = new System.Windows.Forms.Button();
            this.disableButton = new System.Windows.Forms.Button();
            this.privacyLink = new System.Windows.Forms.LinkLabel();
            this.showChangelogLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "WPlugins has found a more recent version.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Installed version:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "New version:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // newVersionLabel
            // 
            this.newVersionLabel.Location = new System.Drawing.Point(159, 49);
            this.newVersionLabel.Name = "newVersionLabel";
            this.newVersionLabel.Size = new System.Drawing.Size(87, 17);
            this.newVersionLabel.TabIndex = 4;
            this.newVersionLabel.Text = "3.2.1";
            // 
            // thisVersionLabel
            // 
            this.thisVersionLabel.Location = new System.Drawing.Point(159, 32);
            this.thisVersionLabel.Name = "thisVersionLabel";
            this.thisVersionLabel.Size = new System.Drawing.Size(87, 17);
            this.thisVersionLabel.TabIndex = 3;
            this.thisVersionLabel.Text = "1.2.3";
            // 
            // visitUpdateButton
            // 
            this.visitUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visitUpdateButton.Location = new System.Drawing.Point(12, 134);
            this.visitUpdateButton.Name = "visitUpdateButton";
            this.visitUpdateButton.Size = new System.Drawing.Size(153, 23);
            this.visitUpdateButton.TabIndex = 0;
            this.visitUpdateButton.Text = "Download from GitHub";
            this.visitUpdateButton.UseVisualStyleBackColor = true;
            this.visitUpdateButton.Click += new System.EventHandler(this.visitUpdateButton_Click);
            // 
            // ignoreButton
            // 
            this.ignoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ignoreButton.Location = new System.Drawing.Point(171, 134);
            this.ignoreButton.Name = "ignoreButton";
            this.ignoreButton.Size = new System.Drawing.Size(95, 23);
            this.ignoreButton.TabIndex = 1;
            this.ignoreButton.Text = "Later";
            this.ignoreButton.UseVisualStyleBackColor = true;
            this.ignoreButton.Click += new System.EventHandler(this.ignoreButton_Click);
            // 
            // skipButton
            // 
            this.skipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.skipButton.Location = new System.Drawing.Point(171, 163);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(95, 23);
            this.skipButton.TabIndex = 3;
            this.skipButton.Text = "Skip this version";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // disableButton
            // 
            this.disableButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disableButton.Location = new System.Drawing.Point(12, 163);
            this.disableButton.Name = "disableButton";
            this.disableButton.Size = new System.Drawing.Size(153, 23);
            this.disableButton.TabIndex = 2;
            this.disableButton.Text = "Never check for updates";
            this.disableButton.UseVisualStyleBackColor = true;
            this.disableButton.Click += new System.EventHandler(this.disableButton_Click);
            // 
            // privacyLink
            // 
            this.privacyLink.LinkArea = new System.Windows.Forms.LinkArea(66, 26);
            this.privacyLink.Location = new System.Drawing.Point(12, 101);
            this.privacyLink.Name = "privacyLink";
            this.privacyLink.Size = new System.Drawing.Size(254, 30);
            this.privacyLink.TabIndex = 5;
            this.privacyLink.TabStop = true;
            this.privacyLink.Text = "The automatic updater does some logging. For info and to opt out, see the privacy" +
    " statement.";
            this.privacyLink.UseCompatibleTextRendering = true;
            this.privacyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.privacyLink_LinkClicked);
            // 
            // showChangelogLink
            // 
            this.showChangelogLink.Location = new System.Drawing.Point(12, 66);
            this.showChangelogLink.Name = "showChangelogLink";
            this.showChangelogLink.Size = new System.Drawing.Size(254, 23);
            this.showChangelogLink.TabIndex = 6;
            this.showChangelogLink.TabStop = true;
            this.showChangelogLink.Text = "What\'s new in this version?";
            this.showChangelogLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showChangelogLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.showChangelogLink_LinkClicked);
            // 
            // AutoUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 201);
            this.Controls.Add(this.showChangelogLink);
            this.Controls.Add(this.privacyLink);
            this.Controls.Add(this.disableButton);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.ignoreButton);
            this.Controls.Add(this.visitUpdateButton);
            this.Controls.Add(this.newVersionLabel);
            this.Controls.Add(this.thisVersionLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoUpdateForm";
            this.Text = "Automatic Update";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AutoUpdateForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label newVersionLabel;
        private System.Windows.Forms.Label thisVersionLabel;
        private System.Windows.Forms.Button visitUpdateButton;
        private System.Windows.Forms.Button ignoreButton;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.Button disableButton;
        private System.Windows.Forms.LinkLabel privacyLink;
        private System.Windows.Forms.LinkLabel showChangelogLink;
    }
}