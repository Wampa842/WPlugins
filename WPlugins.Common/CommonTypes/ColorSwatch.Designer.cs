namespace WPlugins.Common.UI
{
    partial class ColorSwatch
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.swatchContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastePToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swatchContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // swatchContextMenu
            // 
            this.swatchContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCToolStripMenuItem,
            this.pastePToolStripMenuItem});
            this.swatchContextMenu.Name = "swatchContextMenu";
            this.swatchContextMenu.Size = new System.Drawing.Size(122, 48);
            // 
            // copyCToolStripMenuItem
            // 
            this.copyCToolStripMenuItem.Name = "copyCToolStripMenuItem";
            this.copyCToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyCToolStripMenuItem.Text = "Copy (&C)";
            this.copyCToolStripMenuItem.Click += new System.EventHandler(this.copyCToolStripMenuItem_Click);
            // 
            // pastePToolStripMenuItem
            // 
            this.pastePToolStripMenuItem.Name = "pastePToolStripMenuItem";
            this.pastePToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pastePToolStripMenuItem.Text = "Paste (&P)";
            this.pastePToolStripMenuItem.Click += new System.EventHandler(this.pastePToolStripMenuItem_Click);
            // 
            // ColorSwatch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "ColorSwatch";
            this.Size = new System.Drawing.Size(40, 20);
            this.Click += new System.EventHandler(this.ColorSwatch_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColorSwatch_MouseClick);
            this.swatchContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip swatchContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastePToolStripMenuItem;
    }
}
