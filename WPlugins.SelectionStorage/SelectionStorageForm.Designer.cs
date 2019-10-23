namespace WPlugins.SelectionStorage
{
    partial class SelectionStorageForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionStorageForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storedList = new System.Windows.Forms.ListView();
            this.indexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numberVertexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numberTriangleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numberBonesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numberBodiesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numberJointsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.storeCurrentButton = new System.Windows.Forms.Button();
            this.nameText = new System.Windows.Forms.TextBox();
            this.restoreButton = new System.Windows.Forms.Button();
            this.storedListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.storedListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 350);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 13);
            label1.TabIndex = 4;
            label1.Text = "Name:";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(484, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepOnTopToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // keepOnTopToolStripMenuItem
            // 
            this.keepOnTopToolStripMenuItem.CheckOnClick = true;
            this.keepOnTopToolStripMenuItem.Name = "keepOnTopToolStripMenuItem";
            this.keepOnTopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.keepOnTopToolStripMenuItem.Text = "Keep on top";
            this.keepOnTopToolStripMenuItem.CheckedChanged += new System.EventHandler(this.keepOnTopToolStripMenuItem_CheckedChanged);
            // 
            // storedList
            // 
            this.storedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexColumn,
            this.nameColumn,
            this.numberVertexColumn,
            this.numberTriangleColumn,
            this.numberBonesColumn,
            this.numberBodiesColumn,
            this.numberJointsColumn});
            this.storedList.FullRowSelect = true;
            this.storedList.Location = new System.Drawing.Point(12, 27);
            this.storedList.MultiSelect = false;
            this.storedList.Name = "storedList";
            this.storedList.Size = new System.Drawing.Size(460, 300);
            this.storedList.TabIndex = 1;
            this.storedList.UseCompatibleStateImageBehavior = false;
            this.storedList.View = System.Windows.Forms.View.Details;
            this.storedList.DoubleClick += new System.EventHandler(this.restoreButton_Click);
            // 
            // indexColumn
            // 
            this.indexColumn.Text = "#";
            this.indexColumn.Width = 25;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 130;
            // 
            // numberVertexColumn
            // 
            this.numberVertexColumn.Text = "Vertices";
            this.numberVertexColumn.Width = 50;
            // 
            // numberTriangleColumn
            // 
            this.numberTriangleColumn.Text = "Faces";
            this.numberTriangleColumn.Width = 50;
            // 
            // numberBonesColumn
            // 
            this.numberBonesColumn.Text = "Bones";
            this.numberBonesColumn.Width = 50;
            // 
            // numberBodiesColumn
            // 
            this.numberBodiesColumn.Text = "Rigid bodies";
            this.numberBodiesColumn.Width = 75;
            // 
            // numberJointsColumn
            // 
            this.numberJointsColumn.Text = "Joints";
            this.numberJointsColumn.Width = 50;
            // 
            // storeCurrentButton
            // 
            this.storeCurrentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storeCurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeCurrentButton.Location = new System.Drawing.Point(12, 373);
            this.storeCurrentButton.Name = "storeCurrentButton";
            this.storeCurrentButton.Size = new System.Drawing.Size(460, 35);
            this.storeCurrentButton.TabIndex = 2;
            this.storeCurrentButton.Text = "Store current selection";
            this.storeCurrentButton.UseVisualStyleBackColor = true;
            this.storeCurrentButton.Click += new System.EventHandler(this.storeCurrentButton_Click);
            // 
            // nameText
            // 
            this.nameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameText.Location = new System.Drawing.Point(56, 347);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(191, 20);
            this.nameText.TabIndex = 3;
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreButton.Location = new System.Drawing.Point(12, 414);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(460, 35);
            this.restoreButton.TabIndex = 5;
            this.restoreButton.Text = "Restore selection";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // storedListContextMenu
            // 
            this.storedListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreSelectionToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.storedListContextMenu.Name = "contextMenuStrip1";
            this.storedListContextMenu.Size = new System.Drawing.Size(164, 48);
            // 
            // restoreSelectionToolStripMenuItem
            // 
            this.restoreSelectionToolStripMenuItem.Name = "restoreSelectionToolStripMenuItem";
            this.restoreSelectionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.restoreSelectionToolStripMenuItem.Text = "Restore selection";
            this.restoreSelectionToolStripMenuItem.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.Location = new System.Drawing.Point(253, 345);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(107, 23);
            this.renameButton.TabIndex = 7;
            this.renameButton.Text = "Rename selected";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(365, 345);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(107, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete selected";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToFileToolStripMenuItem
            // 
            this.exportToFileToolStripMenuItem.Name = "exportToFileToolStripMenuItem";
            this.exportToFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToFileToolStripMenuItem.Text = "Export to file";
            this.exportToFileToolStripMenuItem.Click += new System.EventHandler(this.exportToFileToolStripMenuItem_Click);
            // 
            // SelectionStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.restoreButton);
            this.Controls.Add(label1);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.storeCurrentButton);
            this.Controls.Add(this.storedList);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "SelectionStorageForm";
            this.Text = "Selection Storage";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.storedListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepOnTopToolStripMenuItem;
        private System.Windows.Forms.ListView storedList;
        private System.Windows.Forms.Button storeCurrentButton;
        private System.Windows.Forms.ColumnHeader indexColumn;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader numberVertexColumn;
        private System.Windows.Forms.ColumnHeader numberTriangleColumn;
        private System.Windows.Forms.ColumnHeader numberBonesColumn;
        private System.Windows.Forms.ColumnHeader numberBodiesColumn;
        private System.Windows.Forms.ColumnHeader numberJointsColumn;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.ContextMenuStrip storedListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem restoreSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToFileToolStripMenuItem;
    }
}