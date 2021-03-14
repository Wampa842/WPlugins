namespace WPlugins.ObjIO
{
	partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.unitSystemGroup = new System.Windows.Forms.GroupBox();
            this.metricRadio = new System.Windows.Forms.RadioButton();
            this.imperialRadio = new System.Windows.Forms.RadioButton();
            this.scalingGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mirrorVCheck = new System.Windows.Forms.CheckBox();
            this.scaleVNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.mirrorUCheck = new System.Windows.Forms.CheckBox();
            this.scaleUNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mirrorZCheck = new System.Windows.Forms.CheckBox();
            this.mirrorYCheck = new System.Windows.Forms.CheckBox();
            this.mirrorXCheck = new System.Windows.Forms.CheckBox();
            this.scaleZNumber = new System.Windows.Forms.NumericUpDown();
            this.scaleYNumber = new System.Windows.Forms.NumericUpDown();
            this.scaleXNumber = new System.Windows.Forms.NumericUpDown();
            this.uniformTextureScaleCheck = new System.Windows.Forms.CheckBox();
            this.uniformModelScaleCheck = new System.Windows.Forms.CheckBox();
            this.importActionGroup = new System.Windows.Forms.GroupBox();
            this.makeWhiteIfTexturedCheck = new System.Windows.Forms.CheckBox();
            this.flipFacesCheck = new System.Windows.Forms.CheckBox();
            this.turnQuadsCheck = new System.Windows.Forms.CheckBox();
            this.swapAxesCheck = new System.Windows.Forms.CheckBox();
            this.materialNamingSelect = new System.Windows.Forms.ComboBox();
            this.boneActionSelect = new System.Windows.Forms.ComboBox();
            this.saveQuadPairsCheck = new System.Windows.Forms.CheckBox();
            this.saveDefaultCheck = new System.Windows.Forms.CheckBox();
            this.importButton = new System.Windows.Forms.Button();
            this.saveJobCheck = new System.Windows.Forms.CheckBox();
            this.saveJobHelpLink = new System.Windows.Forms.LinkLabel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.importProgress = new System.Windows.Forms.ProgressBar();
            this.hoverToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.userCancelButton = new System.Windows.Forms.Button();
            this.unitSystemGroup.SuspendLayout();
            this.scalingGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleVNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleZNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXNumber)).BeginInit();
            this.importActionGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // unitSystemGroup
            // 
            this.unitSystemGroup.Controls.Add(this.metricRadio);
            this.unitSystemGroup.Controls.Add(this.imperialRadio);
            this.unitSystemGroup.Location = new System.Drawing.Point(12, 12);
            this.unitSystemGroup.Name = "unitSystemGroup";
            this.unitSystemGroup.Size = new System.Drawing.Size(207, 71);
            this.unitSystemGroup.TabIndex = 0;
            this.unitSystemGroup.TabStop = false;
            this.unitSystemGroup.Text = "Unit system";
            // 
            // metricRadio
            // 
            this.metricRadio.AutoSize = true;
            this.metricRadio.Location = new System.Drawing.Point(6, 42);
            this.metricRadio.Name = "metricRadio";
            this.metricRadio.Size = new System.Drawing.Size(79, 17);
            this.metricRadio.TabIndex = 1;
            this.metricRadio.Text = "Metric units";
            this.metricRadio.UseVisualStyleBackColor = true;
            // 
            // imperialRadio
            // 
            this.imperialRadio.AutoSize = true;
            this.imperialRadio.Checked = true;
            this.imperialRadio.Location = new System.Drawing.Point(6, 19);
            this.imperialRadio.Name = "imperialRadio";
            this.imperialRadio.Size = new System.Drawing.Size(86, 17);
            this.imperialRadio.TabIndex = 0;
            this.imperialRadio.TabStop = true;
            this.imperialRadio.Text = "Imperial units";
            this.imperialRadio.UseVisualStyleBackColor = true;
            // 
            // scalingGroup
            // 
            this.scalingGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scalingGroup.Controls.Add(this.label5);
            this.scalingGroup.Controls.Add(this.mirrorVCheck);
            this.scalingGroup.Controls.Add(this.scaleVNumber);
            this.scalingGroup.Controls.Add(this.label4);
            this.scalingGroup.Controls.Add(this.mirrorUCheck);
            this.scalingGroup.Controls.Add(this.scaleUNumber);
            this.scalingGroup.Controls.Add(this.label3);
            this.scalingGroup.Controls.Add(this.label2);
            this.scalingGroup.Controls.Add(this.label1);
            this.scalingGroup.Controls.Add(this.mirrorZCheck);
            this.scalingGroup.Controls.Add(this.mirrorYCheck);
            this.scalingGroup.Controls.Add(this.mirrorXCheck);
            this.scalingGroup.Controls.Add(this.scaleZNumber);
            this.scalingGroup.Controls.Add(this.scaleYNumber);
            this.scalingGroup.Controls.Add(this.scaleXNumber);
            this.scalingGroup.Controls.Add(this.uniformTextureScaleCheck);
            this.scalingGroup.Controls.Add(this.uniformModelScaleCheck);
            this.scalingGroup.Location = new System.Drawing.Point(225, 12);
            this.scalingGroup.Name = "scalingGroup";
            this.scalingGroup.Size = new System.Drawing.Size(206, 220);
            this.scalingGroup.TabIndex = 1;
            this.scalingGroup.TabStop = false;
            this.scalingGroup.Text = "Scaling";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.MediumPurple;
            this.label5.Location = new System.Drawing.Point(10, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "V";
            // 
            // mirrorVCheck
            // 
            this.mirrorVCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mirrorVCheck.AutoSize = true;
            this.mirrorVCheck.Location = new System.Drawing.Point(139, 180);
            this.mirrorVCheck.Name = "mirrorVCheck";
            this.mirrorVCheck.Size = new System.Drawing.Size(52, 17);
            this.mirrorVCheck.TabIndex = 16;
            this.mirrorVCheck.Text = "Mirror";
            this.mirrorVCheck.UseVisualStyleBackColor = true;
            // 
            // scaleVNumber
            // 
            this.scaleVNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleVNumber.DecimalPlaces = 2;
            this.scaleVNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.scaleVNumber.Location = new System.Drawing.Point(35, 179);
            this.scaleVNumber.Name = "scaleVNumber";
            this.scaleVNumber.Size = new System.Drawing.Size(84, 20);
            this.scaleVNumber.TabIndex = 15;
            this.scaleVNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(10, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "U";
            // 
            // mirrorUCheck
            // 
            this.mirrorUCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mirrorUCheck.AutoSize = true;
            this.mirrorUCheck.Location = new System.Drawing.Point(139, 154);
            this.mirrorUCheck.Name = "mirrorUCheck";
            this.mirrorUCheck.Size = new System.Drawing.Size(52, 17);
            this.mirrorUCheck.TabIndex = 13;
            this.mirrorUCheck.Text = "Mirror";
            this.mirrorUCheck.UseVisualStyleBackColor = true;
            // 
            // scaleUNumber
            // 
            this.scaleUNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleUNumber.DecimalPlaces = 2;
            this.scaleUNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.scaleUNumber.Location = new System.Drawing.Point(35, 153);
            this.scaleUNumber.Name = "scaleUNumber";
            this.scaleUNumber.Size = new System.Drawing.Size(84, 20);
            this.scaleUNumber.TabIndex = 12;
            this.scaleUNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleUNumber.ValueChanged += new System.EventHandler(this.scaleUNumber_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "X";
            // 
            // mirrorZCheck
            // 
            this.mirrorZCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mirrorZCheck.AutoSize = true;
            this.mirrorZCheck.Location = new System.Drawing.Point(139, 95);
            this.mirrorZCheck.Name = "mirrorZCheck";
            this.mirrorZCheck.Size = new System.Drawing.Size(52, 17);
            this.mirrorZCheck.TabIndex = 8;
            this.mirrorZCheck.Text = "Mirror";
            this.mirrorZCheck.UseVisualStyleBackColor = true;
            // 
            // mirrorYCheck
            // 
            this.mirrorYCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mirrorYCheck.AutoSize = true;
            this.mirrorYCheck.Location = new System.Drawing.Point(139, 69);
            this.mirrorYCheck.Name = "mirrorYCheck";
            this.mirrorYCheck.Size = new System.Drawing.Size(52, 17);
            this.mirrorYCheck.TabIndex = 7;
            this.mirrorYCheck.Text = "Mirror";
            this.mirrorYCheck.UseVisualStyleBackColor = true;
            // 
            // mirrorXCheck
            // 
            this.mirrorXCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mirrorXCheck.AutoSize = true;
            this.mirrorXCheck.Location = new System.Drawing.Point(139, 43);
            this.mirrorXCheck.Name = "mirrorXCheck";
            this.mirrorXCheck.Size = new System.Drawing.Size(52, 17);
            this.mirrorXCheck.TabIndex = 6;
            this.mirrorXCheck.Text = "Mirror";
            this.mirrorXCheck.UseVisualStyleBackColor = true;
            // 
            // scaleZNumber
            // 
            this.scaleZNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleZNumber.DecimalPlaces = 2;
            this.scaleZNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.scaleZNumber.Location = new System.Drawing.Point(35, 94);
            this.scaleZNumber.Name = "scaleZNumber";
            this.scaleZNumber.Size = new System.Drawing.Size(84, 20);
            this.scaleZNumber.TabIndex = 4;
            this.scaleZNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // scaleYNumber
            // 
            this.scaleYNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleYNumber.DecimalPlaces = 2;
            this.scaleYNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.scaleYNumber.Location = new System.Drawing.Point(35, 68);
            this.scaleYNumber.Name = "scaleYNumber";
            this.scaleYNumber.Size = new System.Drawing.Size(84, 20);
            this.scaleYNumber.TabIndex = 3;
            this.scaleYNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // scaleXNumber
            // 
            this.scaleXNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scaleXNumber.DecimalPlaces = 2;
            this.scaleXNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.scaleXNumber.Location = new System.Drawing.Point(35, 42);
            this.scaleXNumber.Name = "scaleXNumber";
            this.scaleXNumber.Size = new System.Drawing.Size(84, 20);
            this.scaleXNumber.TabIndex = 2;
            this.scaleXNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleXNumber.ValueChanged += new System.EventHandler(this.scaleXNumber_ValueChanged);
            // 
            // uniformTextureScaleCheck
            // 
            this.uniformTextureScaleCheck.AutoSize = true;
            this.uniformTextureScaleCheck.Location = new System.Drawing.Point(6, 130);
            this.uniformTextureScaleCheck.Name = "uniformTextureScaleCheck";
            this.uniformTextureScaleCheck.Size = new System.Drawing.Size(98, 17);
            this.uniformTextureScaleCheck.TabIndex = 1;
            this.uniformTextureScaleCheck.Text = "Uniform scaling";
            this.uniformTextureScaleCheck.UseVisualStyleBackColor = true;
            this.uniformTextureScaleCheck.CheckedChanged += new System.EventHandler(this.uniformTextureScaleCheck_CheckedChanged);
            // 
            // uniformModelScaleCheck
            // 
            this.uniformModelScaleCheck.AutoSize = true;
            this.uniformModelScaleCheck.Location = new System.Drawing.Point(6, 19);
            this.uniformModelScaleCheck.Name = "uniformModelScaleCheck";
            this.uniformModelScaleCheck.Size = new System.Drawing.Size(98, 17);
            this.uniformModelScaleCheck.TabIndex = 0;
            this.uniformModelScaleCheck.Text = "Uniform scaling";
            this.uniformModelScaleCheck.UseVisualStyleBackColor = true;
            this.uniformModelScaleCheck.CheckedChanged += new System.EventHandler(this.uniformModelScaleCheck_CheckedChanged);
            // 
            // importActionGroup
            // 
            this.importActionGroup.Controls.Add(this.makeWhiteIfTexturedCheck);
            this.importActionGroup.Controls.Add(this.flipFacesCheck);
            this.importActionGroup.Controls.Add(this.turnQuadsCheck);
            this.importActionGroup.Controls.Add(this.swapAxesCheck);
            this.importActionGroup.Controls.Add(this.materialNamingSelect);
            this.importActionGroup.Controls.Add(this.boneActionSelect);
            this.importActionGroup.Location = new System.Drawing.Point(12, 89);
            this.importActionGroup.Name = "importActionGroup";
            this.importActionGroup.Size = new System.Drawing.Size(207, 168);
            this.importActionGroup.TabIndex = 3;
            this.importActionGroup.TabStop = false;
            this.importActionGroup.Text = "Import actions";
            // 
            // makeWhiteIfTexturedCheck
            // 
            this.makeWhiteIfTexturedCheck.AutoSize = true;
            this.makeWhiteIfTexturedCheck.Checked = true;
            this.makeWhiteIfTexturedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.makeWhiteIfTexturedCheck.Location = new System.Drawing.Point(6, 142);
            this.makeWhiteIfTexturedCheck.Name = "makeWhiteIfTexturedCheck";
            this.makeWhiteIfTexturedCheck.Size = new System.Drawing.Size(168, 17);
            this.makeWhiteIfTexturedCheck.TabIndex = 7;
            this.makeWhiteIfTexturedCheck.Text = "Full color for textured materials";
            this.hoverToolTip.SetToolTip(this.makeWhiteIfTexturedCheck, "When enabled, materials that have textures will be imported with white diffuse co" +
        "lor and medium gray ambient color.");
            this.makeWhiteIfTexturedCheck.UseVisualStyleBackColor = true;
            // 
            // flipFacesCheck
            // 
            this.flipFacesCheck.AutoSize = true;
            this.flipFacesCheck.Location = new System.Drawing.Point(6, 119);
            this.flipFacesCheck.Name = "flipFacesCheck";
            this.flipFacesCheck.Size = new System.Drawing.Size(71, 17);
            this.flipFacesCheck.TabIndex = 6;
            this.flipFacesCheck.Text = "Flip faces";
            this.hoverToolTip.SetToolTip(this.flipFacesCheck, "When enabled, faces will be flipped and vertex normals will be reversed.");
            this.flipFacesCheck.UseVisualStyleBackColor = true;
            // 
            // turnQuadsCheck
            // 
            this.turnQuadsCheck.AutoSize = true;
            this.turnQuadsCheck.Location = new System.Drawing.Point(6, 96);
            this.turnQuadsCheck.Name = "turnQuadsCheck";
            this.turnQuadsCheck.Size = new System.Drawing.Size(80, 17);
            this.turnQuadsCheck.TabIndex = 5;
            this.turnQuadsCheck.Text = "Turn quads";
            this.hoverToolTip.SetToolTip(this.turnQuadsCheck, "PMX does not support quadrilaterials, so when one is encountered, it is broken up" +
        " into two triangles.\r\nIf this option is enabled, the triangulation will be rever" +
        "sed.");
            this.turnQuadsCheck.UseVisualStyleBackColor = true;
            // 
            // swapAxesCheck
            // 
            this.swapAxesCheck.AutoSize = true;
            this.swapAxesCheck.Location = new System.Drawing.Point(6, 73);
            this.swapAxesCheck.Name = "swapAxesCheck";
            this.swapAxesCheck.Size = new System.Drawing.Size(119, 17);
            this.swapAxesCheck.TabIndex = 4;
            this.swapAxesCheck.Text = "Swap Y and Z axes";
            this.swapAxesCheck.UseVisualStyleBackColor = true;
            // 
            // materialNamingSelect
            // 
            this.materialNamingSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialNamingSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialNamingSelect.FormattingEnabled = true;
            this.materialNamingSelect.Items.AddRange(new object[] {
            "Numbered materials",
            "Material names from group names",
            "Material names from bitmap names"});
            this.materialNamingSelect.Location = new System.Drawing.Point(6, 46);
            this.materialNamingSelect.Name = "materialNamingSelect";
            this.materialNamingSelect.Size = new System.Drawing.Size(195, 21);
            this.materialNamingSelect.TabIndex = 1;
            // 
            // boneActionSelect
            // 
            this.boneActionSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boneActionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boneActionSelect.FormattingEnabled = true;
            this.boneActionSelect.Items.AddRange(new object[] {
            "Do not create bone",
            "Create new bone at origin",
            "Create new bone at average"});
            this.boneActionSelect.Location = new System.Drawing.Point(6, 19);
            this.boneActionSelect.Name = "boneActionSelect";
            this.boneActionSelect.Size = new System.Drawing.Size(195, 21);
            this.boneActionSelect.TabIndex = 0;
            // 
            // saveQuadPairsCheck
            // 
            this.saveQuadPairsCheck.AutoSize = true;
            this.saveQuadPairsCheck.Location = new System.Drawing.Point(225, 238);
            this.saveQuadPairsCheck.Name = "saveQuadPairsCheck";
            this.saveQuadPairsCheck.Size = new System.Drawing.Size(188, 17);
            this.saveQuadPairsCheck.TabIndex = 7;
            this.saveQuadPairsCheck.Text = "Save triangle index pairs for quads";
            this.hoverToolTip.SetToolTip(this.saveQuadPairsCheck, resources.GetString("saveQuadPairsCheck.ToolTip"));
            this.saveQuadPairsCheck.UseVisualStyleBackColor = true;
            // 
            // saveDefaultCheck
            // 
            this.saveDefaultCheck.AutoSize = true;
            this.saveDefaultCheck.Location = new System.Drawing.Point(18, 263);
            this.saveDefaultCheck.Name = "saveDefaultCheck";
            this.saveDefaultCheck.Size = new System.Drawing.Size(139, 17);
            this.saveDefaultCheck.TabIndex = 3;
            this.saveDefaultCheck.Text = "Save settings as default";
            this.saveDefaultCheck.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.importButton.Location = new System.Drawing.Point(12, 336);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(293, 23);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // saveJobCheck
            // 
            this.saveJobCheck.AutoSize = true;
            this.saveJobCheck.Location = new System.Drawing.Point(225, 263);
            this.saveJobCheck.Name = "saveJobCheck";
            this.saveJobCheck.Size = new System.Drawing.Size(141, 17);
            this.saveJobCheck.TabIndex = 6;
            this.saveJobCheck.Text = "Save settings for this job";
            this.hoverToolTip.SetToolTip(this.saveJobCheck, "When enabled, import settings will be saved in a file next to the imported OBJ fi" +
        "le. If you try to import that file again, you will be prompted to use the saved " +
        "settings.");
            this.saveJobCheck.UseVisualStyleBackColor = true;
            // 
            // saveJobHelpLink
            // 
            this.saveJobHelpLink.AutoSize = true;
            this.saveJobHelpLink.Location = new System.Drawing.Point(382, 264);
            this.saveJobHelpLink.Name = "saveJobHelpLink";
            this.saveJobHelpLink.Size = new System.Drawing.Size(19, 13);
            this.saveJobHelpLink.TabIndex = 7;
            this.saveJobHelpLink.TabStop = true;
            this.saveJobHelpLink.Text = "(?)";
            this.saveJobHelpLink.Click += new System.EventHandler(this.saveJobHelpLink_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(12, 311);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(420, 22);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // importProgress
            // 
            this.importProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importProgress.Location = new System.Drawing.Point(12, 286);
            this.importProgress.MarqueeAnimationSpeed = 5;
            this.importProgress.Name = "importProgress";
            this.importProgress.Size = new System.Drawing.Size(420, 22);
            this.importProgress.Step = 1;
            this.importProgress.TabIndex = 10;
            // 
            // userCancelButton
            // 
            this.userCancelButton.Location = new System.Drawing.Point(311, 336);
            this.userCancelButton.Name = "userCancelButton";
            this.userCancelButton.Size = new System.Drawing.Size(120, 23);
            this.userCancelButton.TabIndex = 11;
            this.userCancelButton.Text = "Cancel";
            this.userCancelButton.UseVisualStyleBackColor = true;
            this.userCancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 371);
            this.Controls.Add(this.userCancelButton);
            this.Controls.Add(this.saveQuadPairsCheck);
            this.Controls.Add(this.importProgress);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.saveJobHelpLink);
            this.Controls.Add(this.saveJobCheck);
            this.Controls.Add(this.saveDefaultCheck);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.importActionGroup);
            this.Controls.Add(this.scalingGroup);
            this.Controls.Add(this.unitSystemGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Import OBJ file | WPlugins";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportForm_FormClosing);
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.unitSystemGroup.ResumeLayout(false);
            this.unitSystemGroup.PerformLayout();
            this.scalingGroup.ResumeLayout(false);
            this.scalingGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleVNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleZNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXNumber)).EndInit();
            this.importActionGroup.ResumeLayout(false);
            this.importActionGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox unitSystemGroup;
		private System.Windows.Forms.RadioButton metricRadio;
		private System.Windows.Forms.RadioButton imperialRadio;
		private System.Windows.Forms.GroupBox scalingGroup;
		private System.Windows.Forms.CheckBox uniformTextureScaleCheck;
		private System.Windows.Forms.CheckBox uniformModelScaleCheck;
		private System.Windows.Forms.NumericUpDown scaleXNumber;
		private System.Windows.Forms.NumericUpDown scaleZNumber;
		private System.Windows.Forms.NumericUpDown scaleYNumber;
		private System.Windows.Forms.CheckBox mirrorZCheck;
		private System.Windows.Forms.CheckBox mirrorYCheck;
		private System.Windows.Forms.CheckBox mirrorXCheck;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox mirrorVCheck;
		private System.Windows.Forms.NumericUpDown scaleVNumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox mirrorUCheck;
		private System.Windows.Forms.NumericUpDown scaleUNumber;
		private System.Windows.Forms.GroupBox importActionGroup;
		private System.Windows.Forms.ComboBox boneActionSelect;
		private System.Windows.Forms.ComboBox materialNamingSelect;
		private System.Windows.Forms.CheckBox saveDefaultCheck;
		private System.Windows.Forms.Button importButton;
		private System.Windows.Forms.CheckBox turnQuadsCheck;
		private System.Windows.Forms.CheckBox swapAxesCheck;
		private System.Windows.Forms.CheckBox flipFacesCheck;
		private System.Windows.Forms.CheckBox saveJobCheck;
		private System.Windows.Forms.LinkLabel saveJobHelpLink;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar importProgress;
        private System.Windows.Forms.CheckBox saveQuadPairsCheck;
        private System.Windows.Forms.CheckBox makeWhiteIfTexturedCheck;
        private System.Windows.Forms.ToolTip hoverToolTip;
        private System.Windows.Forms.Button userCancelButton;
    }
}