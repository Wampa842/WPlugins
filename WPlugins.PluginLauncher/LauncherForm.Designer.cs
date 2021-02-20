namespace WPlugins.PluginLauncher
{
    partial class LauncherForm
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
            this.pluginList = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filePathHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.launchSelectedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pluginList
            // 
            this.pluginList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.filePathHeader});
            this.pluginList.FullRowSelect = true;
            this.pluginList.HideSelection = false;
            this.pluginList.Location = new System.Drawing.Point(12, 12);
            this.pluginList.Name = "pluginList";
            this.pluginList.Size = new System.Drawing.Size(329, 443);
            this.pluginList.TabIndex = 0;
            this.pluginList.UseCompatibleStateImageBehavior = false;
            this.pluginList.View = System.Windows.Forms.View.Details;
            this.pluginList.DoubleClick += new System.EventHandler(this.pluginList_DoubleClick);
            this.pluginList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pluginList_KeyPress);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 150;
            // 
            // filePathHeader
            // 
            this.filePathHeader.Text = "Assembly path";
            this.filePathHeader.Width = 475;
            // 
            // launchSelectedButton
            // 
            this.launchSelectedButton.Location = new System.Drawing.Point(12, 461);
            this.launchSelectedButton.Name = "launchSelectedButton";
            this.launchSelectedButton.Size = new System.Drawing.Size(329, 36);
            this.launchSelectedButton.TabIndex = 1;
            this.launchSelectedButton.Text = "Launch selected";
            this.launchSelectedButton.UseVisualStyleBackColor = true;
            this.launchSelectedButton.Click += new System.EventHandler(this.launchSelectedButton_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 509);
            this.Controls.Add(this.launchSelectedButton);
            this.Controls.Add(this.pluginList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LauncherForm";
            this.ShowIcon = false;
            this.Text = "WPlugins Launcher";
            this.Load += new System.EventHandler(this.LauncherForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView pluginList;
        private System.Windows.Forms.Button launchSelectedButton;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader filePathHeader;
    }
}