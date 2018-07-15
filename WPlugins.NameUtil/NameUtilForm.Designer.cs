namespace WPlugins.NameUtil
{
	partial class NameUtilForm
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
			this.subjectGroup = new System.Windows.Forms.GroupBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.japaneseNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.englishNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.subjectMaterialRadio = new System.Windows.Forms.RadioButton();
			this.subjectMorphSelect = new System.Windows.Forms.RadioButton();
			this.subjectRigidRadio = new System.Windows.Forms.RadioButton();
			this.subjectJointRadio = new System.Windows.Forms.RadioButton();
			this.subjectGroupRadio = new System.Windows.Forms.RadioButton();
			this.subjectBoneRadio = new System.Windows.Forms.RadioButton();
			this.selectedOnlyCheck = new System.Windows.Forms.CheckBox();
			this.actionGroup = new System.Windows.Forms.GroupBox();
			this.translateGroup = new System.Windows.Forms.GroupBox();
			this.subjectGroup.SuspendLayout();
			this.actionGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// subjectGroup
			// 
			this.subjectGroup.Controls.Add(this.selectedOnlyCheck);
			this.subjectGroup.Controls.Add(this.subjectJointRadio);
			this.subjectGroup.Controls.Add(this.subjectGroupRadio);
			this.subjectGroup.Controls.Add(this.subjectBoneRadio);
			this.subjectGroup.Controls.Add(this.subjectRigidRadio);
			this.subjectGroup.Controls.Add(this.subjectMorphSelect);
			this.subjectGroup.Controls.Add(this.subjectMaterialRadio);
			this.subjectGroup.Location = new System.Drawing.Point(12, 12);
			this.subjectGroup.Name = "subjectGroup";
			this.subjectGroup.Size = new System.Drawing.Size(303, 120);
			this.subjectGroup.TabIndex = 0;
			this.subjectGroup.TabStop = false;
			this.subjectGroup.Text = "Object type";
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.japaneseNameCol,
            this.englishNameCol});
			this.listView1.Location = new System.Drawing.Point(321, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(251, 318);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// japaneseNameCol
			// 
			this.japaneseNameCol.Text = "Japanese";
			this.japaneseNameCol.Width = 101;
			// 
			// englishNameCol
			// 
			this.englishNameCol.Text = "English";
			this.englishNameCol.Width = 142;
			// 
			// subjectMaterialRadio
			// 
			this.subjectMaterialRadio.AutoSize = true;
			this.subjectMaterialRadio.Location = new System.Drawing.Point(6, 19);
			this.subjectMaterialRadio.Name = "subjectMaterialRadio";
			this.subjectMaterialRadio.Size = new System.Drawing.Size(67, 17);
			this.subjectMaterialRadio.TabIndex = 0;
			this.subjectMaterialRadio.TabStop = true;
			this.subjectMaterialRadio.Text = "Materials";
			this.subjectMaterialRadio.UseVisualStyleBackColor = true;
			// 
			// subjectMorphSelect
			// 
			this.subjectMorphSelect.AutoSize = true;
			this.subjectMorphSelect.Location = new System.Drawing.Point(6, 42);
			this.subjectMorphSelect.Name = "subjectMorphSelect";
			this.subjectMorphSelect.Size = new System.Drawing.Size(60, 17);
			this.subjectMorphSelect.TabIndex = 0;
			this.subjectMorphSelect.TabStop = true;
			this.subjectMorphSelect.Text = "Morphs";
			this.subjectMorphSelect.UseVisualStyleBackColor = true;
			// 
			// subjectRigidRadio
			// 
			this.subjectRigidRadio.AutoSize = true;
			this.subjectRigidRadio.Location = new System.Drawing.Point(6, 65);
			this.subjectRigidRadio.Name = "subjectRigidRadio";
			this.subjectRigidRadio.Size = new System.Drawing.Size(83, 17);
			this.subjectRigidRadio.TabIndex = 0;
			this.subjectRigidRadio.TabStop = true;
			this.subjectRigidRadio.Text = "Rigid bodies";
			this.subjectRigidRadio.UseVisualStyleBackColor = true;
			// 
			// subjectJointRadio
			// 
			this.subjectJointRadio.AutoSize = true;
			this.subjectJointRadio.Location = new System.Drawing.Point(158, 65);
			this.subjectJointRadio.Name = "subjectJointRadio";
			this.subjectJointRadio.Size = new System.Drawing.Size(52, 17);
			this.subjectJointRadio.TabIndex = 1;
			this.subjectJointRadio.TabStop = true;
			this.subjectJointRadio.Text = "Joints";
			this.subjectJointRadio.UseVisualStyleBackColor = true;
			// 
			// subjectGroupRadio
			// 
			this.subjectGroupRadio.AutoSize = true;
			this.subjectGroupRadio.Location = new System.Drawing.Point(158, 42);
			this.subjectGroupRadio.Name = "subjectGroupRadio";
			this.subjectGroupRadio.Size = new System.Drawing.Size(89, 17);
			this.subjectGroupRadio.TabIndex = 2;
			this.subjectGroupRadio.TabStop = true;
			this.subjectGroupRadio.Text = "Frame groups";
			this.subjectGroupRadio.UseVisualStyleBackColor = true;
			// 
			// subjectBoneRadio
			// 
			this.subjectBoneRadio.AutoSize = true;
			this.subjectBoneRadio.Location = new System.Drawing.Point(158, 19);
			this.subjectBoneRadio.Name = "subjectBoneRadio";
			this.subjectBoneRadio.Size = new System.Drawing.Size(55, 17);
			this.subjectBoneRadio.TabIndex = 3;
			this.subjectBoneRadio.TabStop = true;
			this.subjectBoneRadio.Text = "Bones";
			this.subjectBoneRadio.UseVisualStyleBackColor = true;
			// 
			// selectedOnlyCheck
			// 
			this.selectedOnlyCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.selectedOnlyCheck.AutoSize = true;
			this.selectedOnlyCheck.Location = new System.Drawing.Point(6, 97);
			this.selectedOnlyCheck.Name = "selectedOnlyCheck";
			this.selectedOnlyCheck.Size = new System.Drawing.Size(80, 17);
			this.selectedOnlyCheck.TabIndex = 4;
			this.selectedOnlyCheck.Text = "checkBox1";
			this.selectedOnlyCheck.UseVisualStyleBackColor = true;
			// 
			// actionGroup
			// 
			this.actionGroup.Controls.Add(this.translateGroup);
			this.actionGroup.Location = new System.Drawing.Point(12, 138);
			this.actionGroup.Name = "actionGroup";
			this.actionGroup.Size = new System.Drawing.Size(303, 192);
			this.actionGroup.TabIndex = 2;
			this.actionGroup.TabStop = false;
			this.actionGroup.Text = "Action";
			// 
			// translateGroup
			// 
			this.translateGroup.Location = new System.Drawing.Point(13, 19);
			this.translateGroup.Name = "translateGroup";
			this.translateGroup.Size = new System.Drawing.Size(284, 101);
			this.translateGroup.TabIndex = 0;
			this.translateGroup.TabStop = false;
			this.translateGroup.Text = "Copy && Translate";
			// 
			// NameUtilForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 378);
			this.Controls.Add(this.actionGroup);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.subjectGroup);
			this.Name = "NameUtilForm";
			this.Text = "NameUtilForm";
			this.subjectGroup.ResumeLayout(false);
			this.subjectGroup.PerformLayout();
			this.actionGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox subjectGroup;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader japaneseNameCol;
		private System.Windows.Forms.ColumnHeader englishNameCol;
		private System.Windows.Forms.RadioButton subjectRigidRadio;
		private System.Windows.Forms.RadioButton subjectMorphSelect;
		private System.Windows.Forms.RadioButton subjectMaterialRadio;
		private System.Windows.Forms.CheckBox selectedOnlyCheck;
		private System.Windows.Forms.RadioButton subjectJointRadio;
		private System.Windows.Forms.RadioButton subjectGroupRadio;
		private System.Windows.Forms.RadioButton subjectBoneRadio;
		private System.Windows.Forms.GroupBox actionGroup;
		private System.Windows.Forms.GroupBox translateGroup;
	}
}