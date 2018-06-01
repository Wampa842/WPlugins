namespace WPlugins.ObjExport
{
	partial class ObjExportForm
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
			this.saveJobCheck = new System.Windows.Forms.CheckBox();
			this.saveDefaultCheck = new System.Windows.Forms.CheckBox();
			this.exportButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.exportActionGroup = new System.Windows.Forms.GroupBox();
			this.flipFacesCheck = new System.Windows.Forms.CheckBox();
			this.swapAxesCheck = new System.Windows.Forms.CheckBox();
			this.bitmapActionSelect = new System.Windows.Forms.ComboBox();
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
			this.unitSystemGroup = new System.Windows.Forms.GroupBox();
			this.metricRadio = new System.Windows.Forms.RadioButton();
			this.imperialRadio = new System.Windows.Forms.RadioButton();
			this.separateSmoothingGroupCheck = new System.Windows.Forms.CheckBox();
			this.bitmapRelativePathText = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.bitmapActionHelpLink = new System.Windows.Forms.LinkLabel();
			this.saveJobHelpLink = new System.Windows.Forms.LinkLabel();
			this.exportActionGroup.SuspendLayout();
			this.scalingGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scaleVNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleUNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleZNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleYNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleXNumber)).BeginInit();
			this.unitSystemGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// saveJobCheck
			// 
			this.saveJobCheck.AutoSize = true;
			this.saveJobCheck.Location = new System.Drawing.Point(200, 238);
			this.saveJobCheck.Name = "saveJobCheck";
			this.saveJobCheck.Size = new System.Drawing.Size(141, 17);
			this.saveJobCheck.TabIndex = 13;
			this.saveJobCheck.Text = "Save settings for this job";
			this.saveJobCheck.UseVisualStyleBackColor = true;
			// 
			// saveDefaultCheck
			// 
			this.saveDefaultCheck.AutoSize = true;
			this.saveDefaultCheck.Location = new System.Drawing.Point(12, 238);
			this.saveDefaultCheck.Name = "saveDefaultCheck";
			this.saveDefaultCheck.Size = new System.Drawing.Size(139, 17);
			this.saveDefaultCheck.TabIndex = 9;
			this.saveDefaultCheck.Text = "Save settings as default";
			this.saveDefaultCheck.UseVisualStyleBackColor = true;
			// 
			// exportButton
			// 
			this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.exportButton.Location = new System.Drawing.Point(12, 261);
			this.exportButton.Name = "exportButton";
			this.exportButton.Size = new System.Drawing.Size(210, 23);
			this.exportButton.TabIndex = 12;
			this.exportButton.Text = "Export";
			this.exportButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(317, 263);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 11;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// exportActionGroup
			// 
			this.exportActionGroup.Controls.Add(this.bitmapActionHelpLink);
			this.exportActionGroup.Controls.Add(this.label6);
			this.exportActionGroup.Controls.Add(this.bitmapRelativePathText);
			this.exportActionGroup.Controls.Add(this.separateSmoothingGroupCheck);
			this.exportActionGroup.Controls.Add(this.flipFacesCheck);
			this.exportActionGroup.Controls.Add(this.swapAxesCheck);
			this.exportActionGroup.Controls.Add(this.bitmapActionSelect);
			this.exportActionGroup.Location = new System.Drawing.Point(12, 89);
			this.exportActionGroup.Name = "exportActionGroup";
			this.exportActionGroup.Size = new System.Drawing.Size(182, 143);
			this.exportActionGroup.TabIndex = 10;
			this.exportActionGroup.TabStop = false;
			this.exportActionGroup.Text = "Export actions";
			// 
			// flipFacesCheck
			// 
			this.flipFacesCheck.AutoSize = true;
			this.flipFacesCheck.Location = new System.Drawing.Point(6, 119);
			this.flipFacesCheck.Name = "flipFacesCheck";
			this.flipFacesCheck.Size = new System.Drawing.Size(71, 17);
			this.flipFacesCheck.TabIndex = 6;
			this.flipFacesCheck.Text = "Flip faces";
			this.flipFacesCheck.UseVisualStyleBackColor = true;
			// 
			// swapAxesCheck
			// 
			this.swapAxesCheck.AutoSize = true;
			this.swapAxesCheck.Location = new System.Drawing.Point(6, 96);
			this.swapAxesCheck.Name = "swapAxesCheck";
			this.swapAxesCheck.Size = new System.Drawing.Size(119, 17);
			this.swapAxesCheck.TabIndex = 4;
			this.swapAxesCheck.Text = "Swap Y and Z axes";
			this.swapAxesCheck.UseVisualStyleBackColor = true;
			// 
			// bitmapActionSelect
			// 
			this.bitmapActionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bitmapActionSelect.FormattingEnabled = true;
			this.bitmapActionSelect.Items.AddRange(new object[] {
            "Ignore  (do not copy or link)",
            "Copy  (copy and link relatively)",
            "Link  (link relatively, but do not copy)",
            "Absolute link  (link using absolute path, but do not copy)"});
			this.bitmapActionSelect.Location = new System.Drawing.Point(6, 19);
			this.bitmapActionSelect.Name = "bitmapActionSelect";
			this.bitmapActionSelect.Size = new System.Drawing.Size(170, 21);
			this.bitmapActionSelect.TabIndex = 0;
			// 
			// scalingGroup
			// 
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
			this.scalingGroup.Location = new System.Drawing.Point(200, 12);
			this.scalingGroup.Name = "scalingGroup";
			this.scalingGroup.Size = new System.Drawing.Size(191, 220);
			this.scalingGroup.TabIndex = 8;
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
			this.mirrorVCheck.AutoSize = true;
			this.mirrorVCheck.Location = new System.Drawing.Point(124, 180);
			this.mirrorVCheck.Name = "mirrorVCheck";
			this.mirrorVCheck.Size = new System.Drawing.Size(52, 17);
			this.mirrorVCheck.TabIndex = 16;
			this.mirrorVCheck.Text = "Mirror";
			this.mirrorVCheck.UseVisualStyleBackColor = true;
			// 
			// scaleVNumber
			// 
			this.scaleVNumber.DecimalPlaces = 2;
			this.scaleVNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.scaleVNumber.Location = new System.Drawing.Point(35, 179);
			this.scaleVNumber.Name = "scaleVNumber";
			this.scaleVNumber.Size = new System.Drawing.Size(69, 20);
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
			this.mirrorUCheck.AutoSize = true;
			this.mirrorUCheck.Location = new System.Drawing.Point(124, 154);
			this.mirrorUCheck.Name = "mirrorUCheck";
			this.mirrorUCheck.Size = new System.Drawing.Size(52, 17);
			this.mirrorUCheck.TabIndex = 13;
			this.mirrorUCheck.Text = "Mirror";
			this.mirrorUCheck.UseVisualStyleBackColor = true;
			// 
			// scaleUNumber
			// 
			this.scaleUNumber.DecimalPlaces = 2;
			this.scaleUNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.scaleUNumber.Location = new System.Drawing.Point(35, 153);
			this.scaleUNumber.Name = "scaleUNumber";
			this.scaleUNumber.Size = new System.Drawing.Size(69, 20);
			this.scaleUNumber.TabIndex = 12;
			this.scaleUNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
			this.mirrorZCheck.AutoSize = true;
			this.mirrorZCheck.Location = new System.Drawing.Point(124, 95);
			this.mirrorZCheck.Name = "mirrorZCheck";
			this.mirrorZCheck.Size = new System.Drawing.Size(52, 17);
			this.mirrorZCheck.TabIndex = 8;
			this.mirrorZCheck.Text = "Mirror";
			this.mirrorZCheck.UseVisualStyleBackColor = true;
			// 
			// mirrorYCheck
			// 
			this.mirrorYCheck.AutoSize = true;
			this.mirrorYCheck.Location = new System.Drawing.Point(124, 69);
			this.mirrorYCheck.Name = "mirrorYCheck";
			this.mirrorYCheck.Size = new System.Drawing.Size(52, 17);
			this.mirrorYCheck.TabIndex = 7;
			this.mirrorYCheck.Text = "Mirror";
			this.mirrorYCheck.UseVisualStyleBackColor = true;
			// 
			// mirrorXCheck
			// 
			this.mirrorXCheck.AutoSize = true;
			this.mirrorXCheck.Location = new System.Drawing.Point(124, 43);
			this.mirrorXCheck.Name = "mirrorXCheck";
			this.mirrorXCheck.Size = new System.Drawing.Size(52, 17);
			this.mirrorXCheck.TabIndex = 6;
			this.mirrorXCheck.Text = "Mirror";
			this.mirrorXCheck.UseVisualStyleBackColor = true;
			// 
			// scaleZNumber
			// 
			this.scaleZNumber.DecimalPlaces = 2;
			this.scaleZNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.scaleZNumber.Location = new System.Drawing.Point(35, 94);
			this.scaleZNumber.Name = "scaleZNumber";
			this.scaleZNumber.Size = new System.Drawing.Size(69, 20);
			this.scaleZNumber.TabIndex = 4;
			this.scaleZNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// scaleYNumber
			// 
			this.scaleYNumber.DecimalPlaces = 2;
			this.scaleYNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.scaleYNumber.Location = new System.Drawing.Point(35, 68);
			this.scaleYNumber.Name = "scaleYNumber";
			this.scaleYNumber.Size = new System.Drawing.Size(69, 20);
			this.scaleYNumber.TabIndex = 3;
			this.scaleYNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// scaleXNumber
			// 
			this.scaleXNumber.DecimalPlaces = 2;
			this.scaleXNumber.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.scaleXNumber.Location = new System.Drawing.Point(35, 42);
			this.scaleXNumber.Name = "scaleXNumber";
			this.scaleXNumber.Size = new System.Drawing.Size(69, 20);
			this.scaleXNumber.TabIndex = 2;
			this.scaleXNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
			// 
			// unitSystemGroup
			// 
			this.unitSystemGroup.Controls.Add(this.metricRadio);
			this.unitSystemGroup.Controls.Add(this.imperialRadio);
			this.unitSystemGroup.Location = new System.Drawing.Point(12, 12);
			this.unitSystemGroup.Name = "unitSystemGroup";
			this.unitSystemGroup.Size = new System.Drawing.Size(182, 71);
			this.unitSystemGroup.TabIndex = 7;
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
			// separateSmoothingGroupCheck
			// 
			this.separateSmoothingGroupCheck.AutoSize = true;
			this.separateSmoothingGroupCheck.Location = new System.Drawing.Point(6, 73);
			this.separateSmoothingGroupCheck.Name = "separateSmoothingGroupCheck";
			this.separateSmoothingGroupCheck.Size = new System.Drawing.Size(155, 17);
			this.separateSmoothingGroupCheck.TabIndex = 7;
			this.separateSmoothingGroupCheck.Text = "Separate smoothing groups";
			this.separateSmoothingGroupCheck.UseVisualStyleBackColor = true;
			// 
			// bitmapRelativePathText
			// 
			this.bitmapRelativePathText.Location = new System.Drawing.Point(44, 46);
			this.bitmapRelativePathText.Name = "bitmapRelativePathText";
			this.bitmapRelativePathText.Size = new System.Drawing.Size(100, 20);
			this.bitmapRelativePathText.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Path:";
			// 
			// bitmapActionHelpLink
			// 
			this.bitmapActionHelpLink.AutoSize = true;
			this.bitmapActionHelpLink.Location = new System.Drawing.Point(150, 49);
			this.bitmapActionHelpLink.Name = "bitmapActionHelpLink";
			this.bitmapActionHelpLink.Size = new System.Drawing.Size(19, 13);
			this.bitmapActionHelpLink.TabIndex = 10;
			this.bitmapActionHelpLink.TabStop = true;
			this.bitmapActionHelpLink.Text = "(?)";
			this.bitmapActionHelpLink.Click += new System.EventHandler(this.bitmapActionHelpLink_Click);
			// 
			// saveJobHelpLink
			// 
			this.saveJobHelpLink.AutoSize = true;
			this.saveJobHelpLink.Location = new System.Drawing.Point(337, 239);
			this.saveJobHelpLink.Name = "saveJobHelpLink";
			this.saveJobHelpLink.Size = new System.Drawing.Size(19, 13);
			this.saveJobHelpLink.TabIndex = 14;
			this.saveJobHelpLink.TabStop = true;
			this.saveJobHelpLink.Text = "(?)";
			// 
			// ObjExportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 298);
			this.Controls.Add(this.saveJobHelpLink);
			this.Controls.Add(this.saveJobCheck);
			this.Controls.Add(this.saveDefaultCheck);
			this.Controls.Add(this.exportButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.exportActionGroup);
			this.Controls.Add(this.scalingGroup);
			this.Controls.Add(this.unitSystemGroup);
			this.Name = "ObjExportForm";
			this.Text = "Export OBJ file | WPlugins";
			this.exportActionGroup.ResumeLayout(false);
			this.exportActionGroup.PerformLayout();
			this.scalingGroup.ResumeLayout(false);
			this.scalingGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.scaleVNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleUNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleZNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleYNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.scaleXNumber)).EndInit();
			this.unitSystemGroup.ResumeLayout(false);
			this.unitSystemGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox saveJobCheck;
		private System.Windows.Forms.CheckBox saveDefaultCheck;
		private System.Windows.Forms.Button exportButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.GroupBox exportActionGroup;
		private System.Windows.Forms.CheckBox flipFacesCheck;
		private System.Windows.Forms.CheckBox swapAxesCheck;
		private System.Windows.Forms.ComboBox bitmapActionSelect;
		private System.Windows.Forms.GroupBox scalingGroup;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox mirrorVCheck;
		private System.Windows.Forms.NumericUpDown scaleVNumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox mirrorUCheck;
		private System.Windows.Forms.NumericUpDown scaleUNumber;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox mirrorZCheck;
		private System.Windows.Forms.CheckBox mirrorYCheck;
		private System.Windows.Forms.CheckBox mirrorXCheck;
		private System.Windows.Forms.NumericUpDown scaleZNumber;
		private System.Windows.Forms.NumericUpDown scaleYNumber;
		private System.Windows.Forms.NumericUpDown scaleXNumber;
		private System.Windows.Forms.CheckBox uniformTextureScaleCheck;
		private System.Windows.Forms.CheckBox uniformModelScaleCheck;
		private System.Windows.Forms.GroupBox unitSystemGroup;
		private System.Windows.Forms.RadioButton metricRadio;
		private System.Windows.Forms.RadioButton imperialRadio;
		private System.Windows.Forms.CheckBox separateSmoothingGroupCheck;
		private System.Windows.Forms.LinkLabel bitmapActionHelpLink;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox bitmapRelativePathText;
		private System.Windows.Forms.LinkLabel saveJobHelpLink;
	}
}