namespace WPlugins.MorphScale
{
    partial class MorphScaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MorphScaleForm));
            this.refreshButton = new System.Windows.Forms.Button();
            this.scaleX = new System.Windows.Forms.NumericUpDown();
            this.morphList = new System.Windows.Forms.ListView();
            this.japaneseHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.englishHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scaleGroup = new System.Windows.Forms.GroupBox();
            this.inverseHelpLink = new System.Windows.Forms.LinkLabel();
            this.negativeButton = new System.Windows.Forms.Button();
            this.invertButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scaleZ = new System.Windows.Forms.NumericUpDown();
            this.scaleY = new System.Windows.Forms.NumericUpDown();
            this.uniformCheck = new System.Windows.Forms.CheckBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.typeGroup = new System.Windows.Forms.GroupBox();
            this.typeBoneTCheck = new System.Windows.Forms.RadioButton();
            this.typeUVCheck = new System.Windows.Forms.RadioButton();
            this.typeBoneRCheck = new System.Windows.Forms.RadioButton();
            this.typeVertexCheck = new System.Windows.Forms.RadioButton();
            this.inverseToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.createNewCheck = new System.Windows.Forms.CheckBox();
            this.selectedNumberLabel = new System.Windows.Forms.Label();
            this.scaleButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).BeginInit();
            this.scaleGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).BeginInit();
            this.typeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(172, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(205, 23);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh list";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // scaleX
            // 
            this.scaleX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleX.DecimalPlaces = 3;
            this.scaleX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleX.Location = new System.Drawing.Point(57, 42);
            this.scaleX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scaleX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.scaleX.Name = "scaleX";
            this.scaleX.Size = new System.Drawing.Size(85, 20);
            this.scaleX.TabIndex = 1;
            this.scaleX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleX.ValueChanged += new System.EventHandler(this.scaleValue_ValueChanged);
            // 
            // morphList
            // 
            this.morphList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.morphList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.japaneseHeader,
            this.englishHeader});
            this.morphList.FullRowSelect = true;
            this.morphList.Location = new System.Drawing.Point(172, 41);
            this.morphList.Name = "morphList";
            this.morphList.Size = new System.Drawing.Size(205, 246);
            this.morphList.TabIndex = 2;
            this.morphList.UseCompatibleStateImageBehavior = false;
            this.morphList.View = System.Windows.Forms.View.Details;
            this.morphList.SelectedIndexChanged += new System.EventHandler(this.morphList_SelectedIndexChanged);
            // 
            // japaneseHeader
            // 
            this.japaneseHeader.Text = "Japanese";
            this.japaneseHeader.Width = 89;
            // 
            // englishHeader
            // 
            this.englishHeader.Text = "English";
            this.englishHeader.Width = 98;
            // 
            // scaleGroup
            // 
            this.scaleGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scaleGroup.Controls.Add(this.inverseHelpLink);
            this.scaleGroup.Controls.Add(this.negativeButton);
            this.scaleGroup.Controls.Add(this.invertButton);
            this.scaleGroup.Controls.Add(this.label3);
            this.scaleGroup.Controls.Add(this.label2);
            this.scaleGroup.Controls.Add(this.label1);
            this.scaleGroup.Controls.Add(this.scaleZ);
            this.scaleGroup.Controls.Add(this.scaleY);
            this.scaleGroup.Controls.Add(this.uniformCheck);
            this.scaleGroup.Controls.Add(this.scaleX);
            this.scaleGroup.Location = new System.Drawing.Point(12, 107);
            this.scaleGroup.Name = "scaleGroup";
            this.scaleGroup.Size = new System.Drawing.Size(148, 181);
            this.scaleGroup.TabIndex = 3;
            this.scaleGroup.TabStop = false;
            this.scaleGroup.Text = "Scale factor";
            // 
            // inverseHelpLink
            // 
            this.inverseHelpLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inverseHelpLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inverseHelpLink.Location = new System.Drawing.Point(122, 125);
            this.inverseHelpLink.Name = "inverseHelpLink";
            this.inverseHelpLink.Size = new System.Drawing.Size(20, 50);
            this.inverseHelpLink.TabIndex = 6;
            this.inverseHelpLink.TabStop = true;
            this.inverseHelpLink.Text = "?";
            this.inverseHelpLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.inverseToolTip.SetToolTip(this.inverseHelpLink, resources.GetString("inverseHelpLink.ToolTip"));
            // 
            // negativeButton
            // 
            this.negativeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.negativeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.negativeButton.Location = new System.Drawing.Point(27, 125);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(94, 22);
            this.negativeButton.TabIndex = 8;
            this.negativeButton.Text = "Negative (-X)";
            this.negativeButton.UseVisualStyleBackColor = true;
            this.negativeButton.Click += new System.EventHandler(this.negativeButton_Click);
            // 
            // invertButton
            // 
            this.invertButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invertButton.Location = new System.Drawing.Point(27, 153);
            this.invertButton.Name = "invertButton";
            this.invertButton.Size = new System.Drawing.Size(94, 22);
            this.invertButton.TabIndex = 7;
            this.invertButton.Text = "Inverse (1/X)";
            this.invertButton.UseVisualStyleBackColor = true;
            this.invertButton.Click += new System.EventHandler(this.invertButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(34, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(34, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(34, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            // 
            // scaleZ
            // 
            this.scaleZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleZ.DecimalPlaces = 3;
            this.scaleZ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleZ.Location = new System.Drawing.Point(57, 94);
            this.scaleZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scaleZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.scaleZ.Name = "scaleZ";
            this.scaleZ.Size = new System.Drawing.Size(85, 20);
            this.scaleZ.TabIndex = 4;
            this.scaleZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleZ.ValueChanged += new System.EventHandler(this.scaleValue_ValueChanged);
            // 
            // scaleY
            // 
            this.scaleY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleY.DecimalPlaces = 3;
            this.scaleY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleY.Location = new System.Drawing.Point(57, 68);
            this.scaleY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scaleY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.scaleY.Name = "scaleY";
            this.scaleY.Size = new System.Drawing.Size(85, 20);
            this.scaleY.TabIndex = 3;
            this.scaleY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleY.ValueChanged += new System.EventHandler(this.scaleValue_ValueChanged);
            // 
            // uniformCheck
            // 
            this.uniformCheck.AutoSize = true;
            this.uniformCheck.Location = new System.Drawing.Point(6, 19);
            this.uniformCheck.Name = "uniformCheck";
            this.uniformCheck.Size = new System.Drawing.Size(62, 17);
            this.uniformCheck.TabIndex = 2;
            this.uniformCheck.Text = "Uniform";
            this.uniformCheck.UseVisualStyleBackColor = true;
            this.uniformCheck.CheckedChanged += new System.EventHandler(this.scaleValue_ValueChanged);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.Location = new System.Drawing.Point(191, 317);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(186, 45);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply to scene";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // typeGroup
            // 
            this.typeGroup.Controls.Add(this.typeBoneTCheck);
            this.typeGroup.Controls.Add(this.typeUVCheck);
            this.typeGroup.Controls.Add(this.typeBoneRCheck);
            this.typeGroup.Controls.Add(this.typeVertexCheck);
            this.typeGroup.Location = new System.Drawing.Point(12, 12);
            this.typeGroup.Name = "typeGroup";
            this.typeGroup.Size = new System.Drawing.Size(148, 89);
            this.typeGroup.TabIndex = 5;
            this.typeGroup.TabStop = false;
            this.typeGroup.Text = "Morph type";
            // 
            // typeBoneTCheck
            // 
            this.typeBoneTCheck.AutoSize = true;
            this.typeBoneTCheck.Location = new System.Drawing.Point(6, 65);
            this.typeBoneTCheck.Name = "typeBoneTCheck";
            this.typeBoneTCheck.Size = new System.Drawing.Size(107, 17);
            this.typeBoneTCheck.TabIndex = 3;
            this.typeBoneTCheck.Text = "Bone (translation)";
            this.typeBoneTCheck.UseVisualStyleBackColor = true;
            this.typeBoneTCheck.CheckedChanged += new System.EventHandler(this.typeCheck_CheckedChanged);
            // 
            // typeUVCheck
            // 
            this.typeUVCheck.AutoSize = true;
            this.typeUVCheck.Enabled = false;
            this.typeUVCheck.Location = new System.Drawing.Point(87, 19);
            this.typeUVCheck.Name = "typeUVCheck";
            this.typeUVCheck.Size = new System.Drawing.Size(40, 17);
            this.typeUVCheck.TabIndex = 2;
            this.typeUVCheck.Text = "UV";
            this.typeUVCheck.UseVisualStyleBackColor = true;
            this.typeUVCheck.CheckedChanged += new System.EventHandler(this.typeCheck_CheckedChanged);
            // 
            // typeBoneRCheck
            // 
            this.typeBoneRCheck.AutoSize = true;
            this.typeBoneRCheck.Location = new System.Drawing.Point(6, 42);
            this.typeBoneRCheck.Name = "typeBoneRCheck";
            this.typeBoneRCheck.Size = new System.Drawing.Size(94, 17);
            this.typeBoneRCheck.TabIndex = 1;
            this.typeBoneRCheck.Text = "Bone (rotation)";
            this.typeBoneRCheck.UseVisualStyleBackColor = true;
            this.typeBoneRCheck.CheckedChanged += new System.EventHandler(this.typeCheck_CheckedChanged);
            // 
            // typeVertexCheck
            // 
            this.typeVertexCheck.AutoSize = true;
            this.typeVertexCheck.Checked = true;
            this.typeVertexCheck.Location = new System.Drawing.Point(6, 19);
            this.typeVertexCheck.Name = "typeVertexCheck";
            this.typeVertexCheck.Size = new System.Drawing.Size(55, 17);
            this.typeVertexCheck.TabIndex = 0;
            this.typeVertexCheck.TabStop = true;
            this.typeVertexCheck.Text = "Vertex";
            this.typeVertexCheck.UseVisualStyleBackColor = true;
            this.typeVertexCheck.CheckedChanged += new System.EventHandler(this.typeCheck_CheckedChanged);
            // 
            // inverseToolTip
            // 
            this.inverseToolTip.AutoPopDelay = 20000;
            this.inverseToolTip.InitialDelay = 0;
            this.inverseToolTip.ReshowDelay = 0;
            this.inverseToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.inverseToolTip.ToolTipTitle = "How to use";
            // 
            // createNewCheck
            // 
            this.createNewCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createNewCheck.AutoSize = true;
            this.createNewCheck.Location = new System.Drawing.Point(13, 294);
            this.createNewCheck.Name = "createNewCheck";
            this.createNewCheck.Size = new System.Drawing.Size(126, 17);
            this.createNewCheck.TabIndex = 6;
            this.createNewCheck.Text = "Create as new morph";
            this.createNewCheck.UseVisualStyleBackColor = true;
            // 
            // selectedNumberLabel
            // 
            this.selectedNumberLabel.AutoSize = true;
            this.selectedNumberLabel.Location = new System.Drawing.Point(169, 295);
            this.selectedNumberLabel.Name = "selectedNumberLabel";
            this.selectedNumberLabel.Size = new System.Drawing.Size(61, 13);
            this.selectedNumberLabel.TabIndex = 7;
            this.selectedNumberLabel.Text = "Selected: 0";
            // 
            // scaleButton
            // 
            this.scaleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scaleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scaleButton.Location = new System.Drawing.Point(12, 317);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(154, 45);
            this.scaleButton.TabIndex = 8;
            this.scaleButton.Text = "Scale";
            this.scaleButton.UseVisualStyleBackColor = true;
            this.scaleButton.Click += new System.EventHandler(this.scaleButton_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(169, 317);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(19, 48);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "?";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.inverseToolTip.SetToolTip(this.linkLabel1, resources.GetString("linkLabel1.ToolTip"));
            // 
            // MorphScaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 374);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.scaleButton);
            this.Controls.Add(this.selectedNumberLabel);
            this.Controls.Add(this.createNewCheck);
            this.Controls.Add(this.typeGroup);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.scaleGroup);
            this.Controls.Add(this.morphList);
            this.Controls.Add(this.refreshButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MorphScaleForm";
            this.Text = "Morph Scale | WPlugins";
            this.Load += new System.EventHandler(this.MorphScaleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).EndInit();
            this.scaleGroup.ResumeLayout(false);
            this.scaleGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).EndInit();
            this.typeGroup.ResumeLayout(false);
            this.typeGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.NumericUpDown scaleX;
        private System.Windows.Forms.ListView morphList;
        private System.Windows.Forms.ColumnHeader japaneseHeader;
        private System.Windows.Forms.ColumnHeader englishHeader;
        private System.Windows.Forms.GroupBox scaleGroup;
        private System.Windows.Forms.CheckBox uniformCheck;
        private System.Windows.Forms.NumericUpDown scaleZ;
        private System.Windows.Forms.NumericUpDown scaleY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button negativeButton;
        private System.Windows.Forms.Button invertButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox typeGroup;
        private System.Windows.Forms.RadioButton typeVertexCheck;
        private System.Windows.Forms.RadioButton typeBoneRCheck;
        private System.Windows.Forms.RadioButton typeUVCheck;
        private System.Windows.Forms.RadioButton typeBoneTCheck;
        private System.Windows.Forms.LinkLabel inverseHelpLink;
        private System.Windows.Forms.ToolTip inverseToolTip;
        private System.Windows.Forms.CheckBox createNewCheck;
        private System.Windows.Forms.Label selectedNumberLabel;
        private System.Windows.Forms.Button scaleButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}