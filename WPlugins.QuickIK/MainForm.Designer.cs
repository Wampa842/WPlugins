namespace WPlugins.QuickIK
{
    partial class MainForm
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
            this.positionSelect = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editPoints = new System.Windows.Forms.CheckBox();
            this.lastPointLabel = new System.Windows.Forms.Label();
            this.firstPointLabel = new System.Windows.Forms.Label();
            this.lastPointVector = new WPlugins.Common.UI.Vector3Numeric();
            this.firstPointVector = new WPlugins.Common.UI.Vector3Numeric();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkNumberHelp = new System.Windows.Forms.LinkLabel();
            this.getFullDistanceButton = new System.Windows.Forms.Button();
            this.autoCalcDistance = new System.Windows.Forms.RadioButton();
            this.distanceNumber = new System.Windows.Forms.NumericUpDown();
            this.autoCalcCount = new System.Windows.Forms.RadioButton();
            this.autoCalcLength = new System.Windows.Forms.RadioButton();
            this.linkNumber = new System.Windows.Forms.NumericUpDown();
            this.lengthNumber = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.physicsSettingsButton = new System.Windows.Forms.Button();
            this.createPhysics = new System.Windows.Forms.CheckBox();
            this.lastBoneInvisible = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.namingEnText = new System.Windows.Forms.TextBox();
            this.namingHelpLabel = new System.Windows.Forms.LinkLabel();
            this.namingText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.parentBoneSelect = new System.Windows.Forms.ComboBox();
            this.chainTypeIK = new System.Windows.Forms.RadioButton();
            this.chainTypeRegular = new System.Windows.Forms.RadioButton();
            this.generateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pointCount = new System.Windows.Forms.NumericUpDown();
            this.positionHelpLink = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNumber)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointCount)).BeginInit();
            this.SuspendLayout();
            // 
            // positionSelect
            // 
            this.positionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.positionSelect.FormattingEnabled = true;
            this.positionSelect.Items.AddRange(new object[] {
            "Straight line (from start through target)",
            "Segmented path",
            "Bézier spline",
            "Bézier spline (even distribution)",
            "Catmull-Rom spline",
            "Catmull-Rom spline (even distribution)"});
            this.positionSelect.Location = new System.Drawing.Point(6, 19);
            this.positionSelect.Name = "positionSelect";
            this.positionSelect.Size = new System.Drawing.Size(277, 21);
            this.positionSelect.TabIndex = 1;
            this.positionSelect.SelectedIndexChanged += new System.EventHandler(this.positionSelect_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.positionHelpLink);
            this.groupBox1.Controls.Add(this.pointCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.editPoints);
            this.groupBox1.Controls.Add(this.lastPointLabel);
            this.groupBox1.Controls.Add(this.firstPointLabel);
            this.groupBox1.Controls.Add(this.lastPointVector);
            this.groupBox1.Controls.Add(this.positionSelect);
            this.groupBox1.Controls.Add(this.firstPointVector);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 151);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position";
            // 
            // editPoints
            // 
            this.editPoints.Appearance = System.Windows.Forms.Appearance.Button;
            this.editPoints.Location = new System.Drawing.Point(6, 108);
            this.editPoints.Name = "editPoints";
            this.editPoints.Size = new System.Drawing.Size(219, 38);
            this.editPoints.TabIndex = 7;
            this.editPoints.Text = "Edit points";
            this.editPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editPoints.UseVisualStyleBackColor = false;
            this.editPoints.CheckedChanged += new System.EventHandler(this.editPoints_CheckedChanged);
            // 
            // lastPointLabel
            // 
            this.lastPointLabel.AutoSize = true;
            this.lastPointLabel.Location = new System.Drawing.Point(9, 87);
            this.lastPointLabel.Name = "lastPointLabel";
            this.lastPointLabel.Size = new System.Drawing.Size(34, 13);
            this.lastPointLabel.TabIndex = 6;
            this.lastPointLabel.Text = "Angle";
            // 
            // firstPointLabel
            // 
            this.firstPointLabel.AutoSize = true;
            this.firstPointLabel.Location = new System.Drawing.Point(9, 61);
            this.firstPointLabel.Name = "firstPointLabel";
            this.firstPointLabel.Size = new System.Drawing.Size(29, 13);
            this.firstPointLabel.TabIndex = 5;
            this.firstPointLabel.Text = "Start";
            // 
            // lastPointVector
            // 
            this.lastPointVector.Location = new System.Drawing.Point(75, 79);
            this.lastPointVector.Margin = new System.Windows.Forms.Padding(0);
            this.lastPointVector.Name = "lastPointVector";
            this.lastPointVector.Size = new System.Drawing.Size(228, 26);
            this.lastPointVector.TabIndex = 4;
            this.lastPointVector.X = 0F;
            this.lastPointVector.Y = 1F;
            this.lastPointVector.Z = 0F;
            // 
            // firstPointVector
            // 
            this.firstPointVector.Location = new System.Drawing.Point(75, 53);
            this.firstPointVector.Margin = new System.Windows.Forms.Padding(0);
            this.firstPointVector.Name = "firstPointVector";
            this.firstPointVector.Size = new System.Drawing.Size(228, 26);
            this.firstPointVector.TabIndex = 3;
            this.firstPointVector.X = 0F;
            this.firstPointVector.Y = 0F;
            this.firstPointVector.Z = 0F;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.linkNumberHelp);
            this.groupBox2.Controls.Add(this.getFullDistanceButton);
            this.groupBox2.Controls.Add(this.autoCalcDistance);
            this.groupBox2.Controls.Add(this.distanceNumber);
            this.groupBox2.Controls.Add(this.autoCalcCount);
            this.groupBox2.Controls.Add(this.autoCalcLength);
            this.groupBox2.Controls.Add(this.linkNumber);
            this.groupBox2.Controls.Add(this.lengthNumber);
            this.groupBox2.Location = new System.Drawing.Point(12, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 111);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chain size";
            // 
            // linkNumberHelp
            // 
            this.linkNumberHelp.AutoSize = true;
            this.linkNumberHelp.Location = new System.Drawing.Point(276, 61);
            this.linkNumberHelp.Name = "linkNumberHelp";
            this.linkNumberHelp.Size = new System.Drawing.Size(19, 13);
            this.linkNumberHelp.TabIndex = 13;
            this.linkNumberHelp.TabStop = true;
            this.linkNumberHelp.Text = "(?)";
            this.linkNumberHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNumberHelp_LinkClicked);
            // 
            // getFullDistanceButton
            // 
            this.getFullDistanceButton.Location = new System.Drawing.Point(271, 31);
            this.getFullDistanceButton.Name = "getFullDistanceButton";
            this.getFullDistanceButton.Size = new System.Drawing.Size(34, 20);
            this.getFullDistanceButton.TabIndex = 12;
            this.getFullDistanceButton.Text = "<";
            this.mainToolTip.SetToolTip(this.getFullDistanceButton, "Set length to distance between start and target");
            this.getFullDistanceButton.UseVisualStyleBackColor = true;
            this.getFullDistanceButton.Click += new System.EventHandler(this.getFullDistanceButton_Click);
            // 
            // autoCalcDistance
            // 
            this.autoCalcDistance.AutoSize = true;
            this.autoCalcDistance.Checked = true;
            this.autoCalcDistance.Location = new System.Drawing.Point(6, 83);
            this.autoCalcDistance.Name = "autoCalcDistance";
            this.autoCalcDistance.Size = new System.Drawing.Size(135, 17);
            this.autoCalcDistance.TabIndex = 11;
            this.autoCalcDistance.TabStop = true;
            this.autoCalcDistance.Text = "Distance between links";
            this.mainToolTip.SetToolTip(this.autoCalcDistance, "Calculate the distance between links from the number of links and the overall dis" +
        "tance.");
            this.autoCalcDistance.UseVisualStyleBackColor = true;
            this.autoCalcDistance.CheckedChanged += new System.EventHandler(this.autoCalc_CheckedChanged);
            // 
            // distanceNumber
            // 
            this.distanceNumber.DecimalPlaces = 2;
            this.distanceNumber.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.distanceNumber.Location = new System.Drawing.Point(145, 83);
            this.distanceNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.distanceNumber.Name = "distanceNumber";
            this.distanceNumber.Size = new System.Drawing.Size(120, 20);
            this.distanceNumber.TabIndex = 10;
            this.distanceNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.distanceNumber.ValueChanged += new System.EventHandler(this.distanceNumber_ValueChanged);
            // 
            // autoCalcCount
            // 
            this.autoCalcCount.AutoSize = true;
            this.autoCalcCount.Location = new System.Drawing.Point(6, 57);
            this.autoCalcCount.Name = "autoCalcCount";
            this.autoCalcCount.Size = new System.Drawing.Size(98, 17);
            this.autoCalcCount.TabIndex = 9;
            this.autoCalcCount.Text = "Number of links";
            this.mainToolTip.SetToolTip(this.autoCalcCount, "Calculate the number of links from the overall length and the distance between li" +
        "nks.");
            this.autoCalcCount.UseVisualStyleBackColor = true;
            this.autoCalcCount.CheckedChanged += new System.EventHandler(this.autoCalc_CheckedChanged);
            // 
            // autoCalcLength
            // 
            this.autoCalcLength.AutoSize = true;
            this.autoCalcLength.Location = new System.Drawing.Point(6, 31);
            this.autoCalcLength.Name = "autoCalcLength";
            this.autoCalcLength.Size = new System.Drawing.Size(58, 17);
            this.autoCalcLength.TabIndex = 8;
            this.autoCalcLength.Text = "Length";
            this.mainToolTip.SetToolTip(this.autoCalcLength, "Calculate the overall length from the number of links and the distance between th" +
        "em.");
            this.autoCalcLength.UseVisualStyleBackColor = true;
            this.autoCalcLength.CheckedChanged += new System.EventHandler(this.autoCalc_CheckedChanged);
            // 
            // linkNumber
            // 
            this.linkNumber.Location = new System.Drawing.Point(145, 57);
            this.linkNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.linkNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.linkNumber.Name = "linkNumber";
            this.linkNumber.Size = new System.Drawing.Size(120, 20);
            this.linkNumber.TabIndex = 3;
            this.linkNumber.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.linkNumber.ValueChanged += new System.EventHandler(this.linkNumber_ValueChanged);
            // 
            // lengthNumber
            // 
            this.lengthNumber.DecimalPlaces = 2;
            this.lengthNumber.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.lengthNumber.Location = new System.Drawing.Point(145, 31);
            this.lengthNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.lengthNumber.Name = "lengthNumber";
            this.lengthNumber.Size = new System.Drawing.Size(120, 20);
            this.lengthNumber.TabIndex = 1;
            this.lengthNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.lengthNumber.ValueChanged += new System.EventHandler(this.lengthNumber_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.physicsSettingsButton);
            this.groupBox3.Controls.Add(this.createPhysics);
            this.groupBox3.Controls.Add(this.lastBoneInvisible);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.namingEnText);
            this.groupBox3.Controls.Add(this.namingHelpLabel);
            this.groupBox3.Controls.Add(this.namingText);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.parentBoneSelect);
            this.groupBox3.Controls.Add(this.chainTypeIK);
            this.groupBox3.Controls.Add(this.chainTypeRegular);
            this.groupBox3.Location = new System.Drawing.Point(12, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(311, 181);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chain properties";
            // 
            // physicsSettingsButton
            // 
            this.physicsSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.physicsSettingsButton.Location = new System.Drawing.Point(107, 146);
            this.physicsSettingsButton.Name = "physicsSettingsButton";
            this.physicsSettingsButton.Size = new System.Drawing.Size(56, 24);
            this.physicsSettingsButton.TabIndex = 16;
            this.physicsSettingsButton.Text = "settings";
            this.physicsSettingsButton.UseVisualStyleBackColor = true;
            this.physicsSettingsButton.Click += new System.EventHandler(this.physicsSettingsButton_Click);
            // 
            // createPhysics
            // 
            this.createPhysics.AutoSize = true;
            this.createPhysics.Location = new System.Drawing.Point(6, 151);
            this.createPhysics.Name = "createPhysics";
            this.createPhysics.Size = new System.Drawing.Size(95, 17);
            this.createPhysics.TabIndex = 15;
            this.createPhysics.Text = "Create physics";
            this.createPhysics.UseVisualStyleBackColor = true;
            // 
            // lastBoneInvisible
            // 
            this.lastBoneInvisible.AutoSize = true;
            this.lastBoneInvisible.Checked = true;
            this.lastBoneInvisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lastBoneInvisible.Location = new System.Drawing.Point(6, 128);
            this.lastBoneInvisible.Name = "lastBoneInvisible";
            this.lastBoneInvisible.Size = new System.Drawing.Size(157, 17);
            this.lastBoneInvisible.TabIndex = 14;
            this.lastBoneInvisible.Text = "Make the last bone invisible";
            this.lastBoneInvisible.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Naming (En)";
            // 
            // namingEnText
            // 
            this.namingEnText.Location = new System.Drawing.Point(90, 102);
            this.namingEnText.Name = "namingEnText";
            this.namingEnText.Size = new System.Drawing.Size(205, 20);
            this.namingEnText.TabIndex = 12;
            this.namingEnText.Text = "bone_#";
            // 
            // namingHelpLabel
            // 
            this.namingHelpLabel.AutoSize = true;
            this.namingHelpLabel.LinkArea = new System.Windows.Forms.LinkArea(12, 1);
            this.namingHelpLabel.Location = new System.Drawing.Point(6, 79);
            this.namingHelpLabel.Name = "namingHelpLabel";
            this.namingHelpLabel.Size = new System.Drawing.Size(75, 17);
            this.namingHelpLabel.TabIndex = 11;
            this.namingHelpLabel.TabStop = true;
            this.namingHelpLabel.Text = "Naming (Jp) ?";
            this.namingHelpLabel.UseCompatibleTextRendering = true;
            this.namingHelpLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.namingHelpLabel_LinkClicked);
            // 
            // namingText
            // 
            this.namingText.Location = new System.Drawing.Point(90, 76);
            this.namingText.Name = "namingText";
            this.namingText.Size = new System.Drawing.Size(205, 20);
            this.namingText.TabIndex = 9;
            this.namingText.Text = "bone_#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Parent bone";
            // 
            // parentBoneSelect
            // 
            this.parentBoneSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parentBoneSelect.FormattingEnabled = true;
            this.parentBoneSelect.Location = new System.Drawing.Point(90, 49);
            this.parentBoneSelect.Name = "parentBoneSelect";
            this.parentBoneSelect.Size = new System.Drawing.Size(205, 21);
            this.parentBoneSelect.TabIndex = 7;
            // 
            // chainTypeIK
            // 
            this.chainTypeIK.AutoSize = true;
            this.chainTypeIK.Location = new System.Drawing.Point(190, 19);
            this.chainTypeIK.Name = "chainTypeIK";
            this.chainTypeIK.Size = new System.Drawing.Size(35, 17);
            this.chainTypeIK.TabIndex = 1;
            this.chainTypeIK.Text = "IK";
            this.chainTypeIK.UseVisualStyleBackColor = true;
            // 
            // chainTypeRegular
            // 
            this.chainTypeRegular.AutoSize = true;
            this.chainTypeRegular.Checked = true;
            this.chainTypeRegular.Location = new System.Drawing.Point(19, 19);
            this.chainTypeRegular.Name = "chainTypeRegular";
            this.chainTypeRegular.Size = new System.Drawing.Size(94, 17);
            this.chainTypeRegular.TabIndex = 0;
            this.chainTypeRegular.TabStop = true;
            this.chainTypeRegular.Text = "Regular bones";
            this.chainTypeRegular.UseVisualStyleBackColor = true;
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.generateButton.Location = new System.Drawing.Point(12, 473);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(178, 34);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(196, 473);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 34);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "No. of points";
            // 
            // pointCount
            // 
            this.pointCount.Location = new System.Drawing.Point(231, 125);
            this.pointCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pointCount.Name = "pointCount";
            this.pointCount.Size = new System.Drawing.Size(74, 20);
            this.pointCount.TabIndex = 9;
            this.pointCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.pointCount.ValueChanged += new System.EventHandler(this.pointCount_ValueChanged);
            // 
            // positionHelpLink
            // 
            this.positionHelpLink.AutoSize = true;
            this.positionHelpLink.Location = new System.Drawing.Point(289, 22);
            this.positionHelpLink.Name = "positionHelpLink";
            this.positionHelpLink.Size = new System.Drawing.Size(19, 13);
            this.positionHelpLink.TabIndex = 10;
            this.positionHelpLink.TabStop = true;
            this.positionHelpLink.Text = "(?)";
            this.positionHelpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.positionHelpLink_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 519);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Quick IK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNumber)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox positionSelect;
        private Common.UI.Vector3Numeric firstPointVector;
        private System.Windows.Forms.GroupBox groupBox1;
        private Common.UI.Vector3Numeric lastPointVector;
        private System.Windows.Forms.Label lastPointLabel;
        private System.Windows.Forms.Label firstPointLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown lengthNumber;
        private System.Windows.Forms.NumericUpDown linkNumber;
        private System.Windows.Forms.RadioButton autoCalcLength;
        private System.Windows.Forms.RadioButton autoCalcCount;
        private System.Windows.Forms.RadioButton autoCalcDistance;
        private System.Windows.Forms.NumericUpDown distanceNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton chainTypeIK;
        private System.Windows.Forms.RadioButton chainTypeRegular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox parentBoneSelect;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox namingText;
        private System.Windows.Forms.LinkLabel namingHelpLabel;
        private System.Windows.Forms.Button getFullDistanceButton;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox namingEnText;
        private System.Windows.Forms.CheckBox lastBoneInvisible;
        private System.Windows.Forms.LinkLabel linkNumberHelp;
        private System.Windows.Forms.CheckBox editPoints;
        private System.Windows.Forms.CheckBox createPhysics;
        private System.Windows.Forms.Button physicsSettingsButton;
        private System.Windows.Forms.NumericUpDown pointCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel positionHelpLink;
    }
}