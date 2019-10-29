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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.operationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.trimButton = new System.Windows.Forms.Button();
            this.cloneButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.complementButton = new System.Windows.Forms.Button();
            this.differenceButton = new System.Windows.Forms.Button();
            this.intersectButton = new System.Windows.Forms.Button();
            this.unionButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.selectiveAllCheck = new System.Windows.Forms.CheckBox();
            this.selectiveJointCheck = new System.Windows.Forms.CheckBox();
            this.selectiveRigidbodyCheck = new System.Windows.Forms.CheckBox();
            this.selectiveTriangleCheck = new System.Windows.Forms.CheckBox();
            this.selectiveBoneCheck = new System.Windows.Forms.CheckBox();
            this.selectiveVertexCheck = new System.Windows.Forms.CheckBox();
            this.objectTypeToolTip = new System.Windows.Forms.ToolTip(this.components);
            label1 = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.storedListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 377);
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
            this.mainMenuStrip.Size = new System.Drawing.Size(464, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToFileToolStripMenuItem,
            this.importFromFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToFileToolStripMenuItem
            // 
            this.exportToFileToolStripMenuItem.Enabled = false;
            this.exportToFileToolStripMenuItem.Name = "exportToFileToolStripMenuItem";
            this.exportToFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exportToFileToolStripMenuItem.Text = "Export to file";
            this.exportToFileToolStripMenuItem.Click += new System.EventHandler(this.exportToFileToolStripMenuItem_Click);
            // 
            // importFromFileToolStripMenuItem
            // 
            this.importFromFileToolStripMenuItem.Enabled = false;
            this.importFromFileToolStripMenuItem.Name = "importFromFileToolStripMenuItem";
            this.importFromFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.importFromFileToolStripMenuItem.Text = "Import from file";
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
            this.keepOnTopToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
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
            this.storedList.Name = "storedList";
            this.storedList.Size = new System.Drawing.Size(389, 340);
            this.storedList.TabIndex = 1;
            this.storedList.UseCompatibleStateImageBehavior = false;
            this.storedList.View = System.Windows.Forms.View.Details;
            this.storedList.SelectedIndexChanged += new System.EventHandler(this.storedList_SelectedIndexChanged);
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
            this.nameColumn.Width = 129;
            // 
            // numberVertexColumn
            // 
            this.numberVertexColumn.Text = "Vertices";
            this.numberVertexColumn.Width = 55;
            // 
            // numberTriangleColumn
            // 
            this.numberTriangleColumn.Text = "Faces";
            this.numberTriangleColumn.Width = 55;
            // 
            // numberBonesColumn
            // 
            this.numberBonesColumn.Text = "Bones";
            this.numberBonesColumn.Width = 55;
            // 
            // numberBodiesColumn
            // 
            this.numberBodiesColumn.Text = "Rigid bodies";
            this.numberBodiesColumn.Width = 75;
            // 
            // numberJointsColumn
            // 
            this.numberJointsColumn.Text = "Joints";
            this.numberJointsColumn.Width = 55;
            // 
            // storeCurrentButton
            // 
            this.storeCurrentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storeCurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeCurrentButton.Location = new System.Drawing.Point(12, 429);
            this.storeCurrentButton.Name = "storeCurrentButton";
            this.storeCurrentButton.Size = new System.Drawing.Size(440, 35);
            this.storeCurrentButton.TabIndex = 2;
            this.storeCurrentButton.Text = "Store current selection";
            this.storeCurrentButton.UseVisualStyleBackColor = true;
            this.storeCurrentButton.Click += new System.EventHandler(this.storeCurrentButton_Click);
            // 
            // nameText
            // 
            this.nameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameText.Location = new System.Drawing.Point(56, 374);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(283, 20);
            this.nameText.TabIndex = 3;
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreButton.Location = new System.Drawing.Point(12, 470);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(440, 35);
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
            this.renameButton.Location = new System.Drawing.Point(345, 372);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(107, 23);
            this.renameButton.TabIndex = 7;
            this.renameButton.Text = "Rename selected";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // operationToolTip
            // 
            this.operationToolTip.AutoPopDelay = 10000;
            this.operationToolTip.InitialDelay = 500;
            this.operationToolTip.ReshowDelay = 100;
            this.operationToolTip.ToolTipTitle = "Set operations";
            // 
            // trimButton
            // 
            this.trimButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trimButton.Location = new System.Drawing.Point(352, 402);
            this.trimButton.Name = "trimButton";
            this.trimButton.Size = new System.Drawing.Size(100, 23);
            this.trimButton.TabIndex = 15;
            this.trimButton.Text = "Trim selected";
            this.operationToolTip.SetToolTip(this.trimButton, "Trimming\r\nTrims the selected items to only contain objects of the selected type. " +
        "Types that are not selected will be removed.");
            this.trimButton.UseVisualStyleBackColor = true;
            this.trimButton.Click += new System.EventHandler(this.trimButton_Click);
            // 
            // cloneButton
            // 
            this.cloneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cloneButton.Location = new System.Drawing.Point(407, 290);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(45, 26);
            this.cloneButton.TabIndex = 16;
            this.cloneButton.Text = "Clone";
            this.operationToolTip.SetToolTip(this.cloneButton, "Clone selected");
            this.cloneButton.UseVisualStyleBackColor = true;
            this.cloneButton.Click += new System.EventHandler(this.cloneButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.BackgroundImage = global::WPlugins.SelectionStorage.Properties.Resources.icon_down;
            this.moveDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveDownButton.Location = new System.Drawing.Point(407, 258);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(45, 26);
            this.moveDownButton.TabIndex = 14;
            this.operationToolTip.SetToolTip(this.moveDownButton, "Move down");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.BackgroundImage = global::WPlugins.SelectionStorage.Properties.Resources.icon_up;
            this.moveUpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveUpButton.Location = new System.Drawing.Point(407, 231);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(45, 26);
            this.moveUpButton.TabIndex = 13;
            this.operationToolTip.SetToolTip(this.moveUpButton, "Move up");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // complementButton
            // 
            this.complementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.complementButton.BackgroundImage = global::WPlugins.SelectionStorage.Properties.Resources.icon_complement;
            this.complementButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.complementButton.Enabled = false;
            this.complementButton.Location = new System.Drawing.Point(407, 180);
            this.complementButton.Name = "complementButton";
            this.complementButton.Size = new System.Drawing.Size(45, 45);
            this.complementButton.TabIndex = 12;
            this.operationToolTip.SetToolTip(this.complementButton, "Complement\r\nCreates a selection of items that are not part of any selected operan" +
        "ds.\r\n");
            this.complementButton.UseVisualStyleBackColor = true;
            this.complementButton.Click += new System.EventHandler(this.complementButton_Click);
            // 
            // differenceButton
            // 
            this.differenceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.differenceButton.BackgroundImage = global::WPlugins.SelectionStorage.Properties.Resources.icon_difference;
            this.differenceButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.differenceButton.Location = new System.Drawing.Point(407, 129);
            this.differenceButton.Name = "differenceButton";
            this.differenceButton.Size = new System.Drawing.Size(45, 45);
            this.differenceButton.TabIndex = 11;
            this.operationToolTip.SetToolTip(this.differenceButton, "Difference\r\nCreates a new selection of items that are elements of the first opera" +
        "nd, but not elements of any subsequent operands.\r\n");
            this.differenceButton.UseVisualStyleBackColor = true;
            this.differenceButton.Click += new System.EventHandler(this.differenceButton_Click);
            // 
            // intersectButton
            // 
            this.intersectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.intersectButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("intersectButton.BackgroundImage")));
            this.intersectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.intersectButton.Location = new System.Drawing.Point(407, 78);
            this.intersectButton.Name = "intersectButton";
            this.intersectButton.Size = new System.Drawing.Size(45, 45);
            this.intersectButton.TabIndex = 10;
            this.operationToolTip.SetToolTip(this.intersectButton, "Intersect\r\nCreates a new selection of items that are elements of all of the opera" +
        "nds.\r\n");
            this.intersectButton.UseVisualStyleBackColor = true;
            this.intersectButton.Click += new System.EventHandler(this.intersectButton_Click);
            // 
            // unionButton
            // 
            this.unionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unionButton.BackgroundImage = global::WPlugins.SelectionStorage.Properties.Resources.icon_union;
            this.unionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.unionButton.Location = new System.Drawing.Point(407, 27);
            this.unionButton.Name = "unionButton";
            this.unionButton.Size = new System.Drawing.Size(45, 45);
            this.unionButton.TabIndex = 9;
            this.operationToolTip.SetToolTip(this.unionButton, "Union\r\nCreates a new selection of items that are elements of any of the operands." +
        "");
            this.unionButton.UseVisualStyleBackColor = true;
            this.unionButton.Click += new System.EventHandler(this.unionButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.BackgroundImage = global::WPlugins.SelectionStorage.Properties.Resources.icon_delete;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteButton.Location = new System.Drawing.Point(407, 322);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(45, 45);
            this.deleteButton.TabIndex = 8;
            this.operationToolTip.SetToolTip(this.deleteButton, "Delete selected items");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // selectiveAllCheck
            // 
            this.selectiveAllCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectiveAllCheck.AutoSize = true;
            this.selectiveAllCheck.Checked = true;
            this.selectiveAllCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectiveAllCheck.Location = new System.Drawing.Point(12, 406);
            this.selectiveAllCheck.Name = "selectiveAllCheck";
            this.selectiveAllCheck.Size = new System.Drawing.Size(162, 17);
            this.selectiveAllCheck.TabIndex = 6;
            this.selectiveAllCheck.Text = "Select types to store/restore:";
            this.selectiveAllCheck.UseVisualStyleBackColor = true;
            this.selectiveAllCheck.Click += new System.EventHandler(this.selectiveAllCheck_Click);
            // 
            // selectiveJointCheck
            // 
            this.selectiveJointCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectiveJointCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectiveJointCheck.AutoSize = true;
            this.selectiveJointCheck.Checked = true;
            this.selectiveJointCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectiveJointCheck.Location = new System.Drawing.Point(312, 402);
            this.selectiveJointCheck.Name = "selectiveJointCheck";
            this.selectiveJointCheck.Size = new System.Drawing.Size(22, 23);
            this.selectiveJointCheck.TabIndex = 5;
            this.selectiveJointCheck.Text = "J";
            this.objectTypeToolTip.SetToolTip(this.selectiveJointCheck, "Joints");
            this.selectiveJointCheck.UseVisualStyleBackColor = true;
            this.selectiveJointCheck.CheckedChanged += new System.EventHandler(this.selectiveCheck_Click);
            // 
            // selectiveRigidbodyCheck
            // 
            this.selectiveRigidbodyCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectiveRigidbodyCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectiveRigidbodyCheck.AutoSize = true;
            this.selectiveRigidbodyCheck.Checked = true;
            this.selectiveRigidbodyCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectiveRigidbodyCheck.Location = new System.Drawing.Point(275, 402);
            this.selectiveRigidbodyCheck.Name = "selectiveRigidbodyCheck";
            this.selectiveRigidbodyCheck.Size = new System.Drawing.Size(31, 23);
            this.selectiveRigidbodyCheck.TabIndex = 4;
            this.selectiveRigidbodyCheck.Text = "Rb";
            this.objectTypeToolTip.SetToolTip(this.selectiveRigidbodyCheck, "Rigid bodies");
            this.selectiveRigidbodyCheck.UseVisualStyleBackColor = true;
            this.selectiveRigidbodyCheck.CheckedChanged += new System.EventHandler(this.selectiveCheck_Click);
            // 
            // selectiveTriangleCheck
            // 
            this.selectiveTriangleCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectiveTriangleCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectiveTriangleCheck.AutoSize = true;
            this.selectiveTriangleCheck.Checked = true;
            this.selectiveTriangleCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectiveTriangleCheck.Location = new System.Drawing.Point(216, 402);
            this.selectiveTriangleCheck.Name = "selectiveTriangleCheck";
            this.selectiveTriangleCheck.Size = new System.Drawing.Size(23, 23);
            this.selectiveTriangleCheck.TabIndex = 3;
            this.selectiveTriangleCheck.Text = "F";
            this.objectTypeToolTip.SetToolTip(this.selectiveTriangleCheck, "Faces");
            this.selectiveTriangleCheck.UseVisualStyleBackColor = true;
            this.selectiveTriangleCheck.Click += new System.EventHandler(this.selectiveCheck_Click);
            // 
            // selectiveBoneCheck
            // 
            this.selectiveBoneCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectiveBoneCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectiveBoneCheck.AutoSize = true;
            this.selectiveBoneCheck.Checked = true;
            this.selectiveBoneCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectiveBoneCheck.Location = new System.Drawing.Point(245, 402);
            this.selectiveBoneCheck.Name = "selectiveBoneCheck";
            this.selectiveBoneCheck.Size = new System.Drawing.Size(24, 23);
            this.selectiveBoneCheck.TabIndex = 2;
            this.selectiveBoneCheck.Text = "B";
            this.objectTypeToolTip.SetToolTip(this.selectiveBoneCheck, "Bones");
            this.selectiveBoneCheck.UseVisualStyleBackColor = true;
            this.selectiveBoneCheck.CheckedChanged += new System.EventHandler(this.selectiveCheck_Click);
            // 
            // selectiveVertexCheck
            // 
            this.selectiveVertexCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectiveVertexCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.selectiveVertexCheck.AutoSize = true;
            this.selectiveVertexCheck.Checked = true;
            this.selectiveVertexCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectiveVertexCheck.Location = new System.Drawing.Point(186, 402);
            this.selectiveVertexCheck.Name = "selectiveVertexCheck";
            this.selectiveVertexCheck.Size = new System.Drawing.Size(24, 23);
            this.selectiveVertexCheck.TabIndex = 2;
            this.selectiveVertexCheck.Text = "V";
            this.objectTypeToolTip.SetToolTip(this.selectiveVertexCheck, "Vertices");
            this.selectiveVertexCheck.UseVisualStyleBackColor = true;
            this.selectiveVertexCheck.CheckedChanged += new System.EventHandler(this.selectiveCheck_Click);
            // 
            // objectTypeToolTip
            // 
            this.objectTypeToolTip.AutoPopDelay = 5000;
            this.objectTypeToolTip.InitialDelay = 300;
            this.objectTypeToolTip.ReshowDelay = 100;
            // 
            // SelectionStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 517);
            this.Controls.Add(this.cloneButton);
            this.Controls.Add(this.trimButton);
            this.Controls.Add(this.selectiveAllCheck);
            this.Controls.Add(this.selectiveJointCheck);
            this.Controls.Add(this.selectiveRigidbodyCheck);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.selectiveTriangleCheck);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.selectiveBoneCheck);
            this.Controls.Add(this.complementButton);
            this.Controls.Add(this.selectiveVertexCheck);
            this.Controls.Add(this.differenceButton);
            this.Controls.Add(this.intersectButton);
            this.Controls.Add(this.unionButton);
            this.Controls.Add(this.storedList);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.restoreButton);
            this.Controls.Add(label1);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.storeCurrentButton);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Button unionButton;
        private System.Windows.Forms.Button intersectButton;
        private System.Windows.Forms.Button differenceButton;
        private System.Windows.Forms.Button complementButton;
        private System.Windows.Forms.ToolTip operationToolTip;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.CheckBox selectiveVertexCheck;
        private System.Windows.Forms.CheckBox selectiveBoneCheck;
        private System.Windows.Forms.CheckBox selectiveTriangleCheck;
        private System.Windows.Forms.CheckBox selectiveJointCheck;
        private System.Windows.Forms.CheckBox selectiveRigidbodyCheck;
        private System.Windows.Forms.CheckBox selectiveAllCheck;
        private System.Windows.Forms.ToolStripMenuItem importFromFileToolStripMenuItem;
        private System.Windows.Forms.Button trimButton;
        private System.Windows.Forms.Button cloneButton;
        private System.Windows.Forms.ToolTip objectTypeToolTip;
    }
}