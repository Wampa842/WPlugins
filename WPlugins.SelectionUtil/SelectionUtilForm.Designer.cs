namespace WPlugins.SelectionUtil
{
	partial class SelectionUtilForm
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
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("bone1");
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("bone2");
			System.Windows.Forms.ColumnHeader japNameColumn;
			System.Windows.Forms.ColumnHeader engNameColumn;
			this.mainTabGroup = new System.Windows.Forms.TabControl();
			this.vertexTab = new System.Windows.Forms.TabPage();
			this.selectVertexButton = new System.Windows.Forms.Button();
			this.vertexByBoneGroup = new System.Windows.Forms.GroupBox();
			this.vertexByBoneEnable = new System.Windows.Forms.CheckBox();
			this.vertexByBoneAllRadio = new System.Windows.Forms.RadioButton();
			this.vertexByBoneAnyRadio = new System.Windows.Forms.RadioButton();
			this.vertexByBoneList = new System.Windows.Forms.ListView();
			japNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			engNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mainTabGroup.SuspendLayout();
			this.vertexTab.SuspendLayout();
			this.vertexByBoneGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTabGroup
			// 
			this.mainTabGroup.Controls.Add(this.vertexTab);
			this.mainTabGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTabGroup.Location = new System.Drawing.Point(0, 0);
			this.mainTabGroup.Name = "mainTabGroup";
			this.mainTabGroup.SelectedIndex = 0;
			this.mainTabGroup.Size = new System.Drawing.Size(382, 450);
			this.mainTabGroup.TabIndex = 0;
			// 
			// vertexTab
			// 
			this.vertexTab.Controls.Add(this.vertexByBoneGroup);
			this.vertexTab.Controls.Add(this.selectVertexButton);
			this.vertexTab.Location = new System.Drawing.Point(4, 22);
			this.vertexTab.Name = "vertexTab";
			this.vertexTab.Padding = new System.Windows.Forms.Padding(3);
			this.vertexTab.Size = new System.Drawing.Size(374, 424);
			this.vertexTab.TabIndex = 0;
			this.vertexTab.Text = "Vertex";
			this.vertexTab.UseVisualStyleBackColor = true;
			// 
			// selectVertexButton
			// 
			this.selectVertexButton.Location = new System.Drawing.Point(6, 395);
			this.selectVertexButton.Name = "selectVertexButton";
			this.selectVertexButton.Size = new System.Drawing.Size(362, 23);
			this.selectVertexButton.TabIndex = 0;
			this.selectVertexButton.Text = "Select";
			this.selectVertexButton.UseVisualStyleBackColor = true;
			this.selectVertexButton.Click += new System.EventHandler(this.selectVertexButton_Click);
			// 
			// vertexByBoneGroup
			// 
			this.vertexByBoneGroup.Controls.Add(this.vertexByBoneList);
			this.vertexByBoneGroup.Controls.Add(this.vertexByBoneAnyRadio);
			this.vertexByBoneGroup.Controls.Add(this.vertexByBoneEnable);
			this.vertexByBoneGroup.Controls.Add(this.vertexByBoneAllRadio);
			this.vertexByBoneGroup.Location = new System.Drawing.Point(6, 6);
			this.vertexByBoneGroup.Name = "vertexByBoneGroup";
			this.vertexByBoneGroup.Size = new System.Drawing.Size(362, 150);
			this.vertexByBoneGroup.TabIndex = 1;
			this.vertexByBoneGroup.TabStop = false;
			this.vertexByBoneGroup.Text = "By bone:";
			// 
			// vertexByBoneEnable
			// 
			this.vertexByBoneEnable.AutoSize = true;
			this.vertexByBoneEnable.Location = new System.Drawing.Point(6, 19);
			this.vertexByBoneEnable.Name = "vertexByBoneEnable";
			this.vertexByBoneEnable.Size = new System.Drawing.Size(59, 17);
			this.vertexByBoneEnable.TabIndex = 0;
			this.vertexByBoneEnable.Text = "Enable";
			this.vertexByBoneEnable.UseVisualStyleBackColor = true;
			this.vertexByBoneEnable.CheckedChanged += new System.EventHandler(this.vertexByBoneEnable_CheckedChanged);
			// 
			// vertexByBoneAllRadio
			// 
			this.vertexByBoneAllRadio.AutoSize = true;
			this.vertexByBoneAllRadio.Location = new System.Drawing.Point(19, 65);
			this.vertexByBoneAllRadio.Name = "vertexByBoneAllRadio";
			this.vertexByBoneAllRadio.Size = new System.Drawing.Size(131, 17);
			this.vertexByBoneAllRadio.TabIndex = 1;
			this.vertexByBoneAllRadio.TabStop = true;
			this.vertexByBoneAllRadio.Text = "Belongs to all selected";
			this.vertexByBoneAllRadio.UseVisualStyleBackColor = true;
			// 
			// vertexByBoneAnyRadio
			// 
			this.vertexByBoneAnyRadio.AutoSize = true;
			this.vertexByBoneAnyRadio.Location = new System.Drawing.Point(19, 42);
			this.vertexByBoneAnyRadio.Name = "vertexByBoneAnyRadio";
			this.vertexByBoneAnyRadio.Size = new System.Drawing.Size(133, 17);
			this.vertexByBoneAnyRadio.TabIndex = 2;
			this.vertexByBoneAnyRadio.TabStop = true;
			this.vertexByBoneAnyRadio.Text = "Belongs to at least one";
			this.vertexByBoneAnyRadio.UseVisualStyleBackColor = true;
			// 
			// vertexByBoneList
			// 
			this.vertexByBoneList.CheckBoxes = true;
			this.vertexByBoneList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            japNameColumn,
            engNameColumn});
			listViewItem3.StateImageIndex = 0;
			listViewItem4.StateImageIndex = 0;
			this.vertexByBoneList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
			this.vertexByBoneList.Location = new System.Drawing.Point(158, 11);
			this.vertexByBoneList.Name = "vertexByBoneList";
			this.vertexByBoneList.Size = new System.Drawing.Size(198, 133);
			this.vertexByBoneList.TabIndex = 3;
			this.vertexByBoneList.UseCompatibleStateImageBehavior = false;
			this.vertexByBoneList.View = System.Windows.Forms.View.Details;
			// 
			// japNameColumn
			// 
			japNameColumn.Text = "Japanese";
			japNameColumn.Width = 103;
			// 
			// engNameColumn
			// 
			engNameColumn.Text = "English";
			engNameColumn.Width = 87;
			// 
			// SelectionUtilForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(382, 450);
			this.Controls.Add(this.mainTabGroup);
			this.Name = "SelectionUtilForm";
			this.Text = "SelectionUtilForm";
			this.Load += new System.EventHandler(this.SelectionUtilForm_Load);
			this.mainTabGroup.ResumeLayout(false);
			this.vertexTab.ResumeLayout(false);
			this.vertexByBoneGroup.ResumeLayout(false);
			this.vertexByBoneGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl mainTabGroup;
		private System.Windows.Forms.TabPage vertexTab;
		private System.Windows.Forms.Button selectVertexButton;
		private System.Windows.Forms.GroupBox vertexByBoneGroup;
		private System.Windows.Forms.CheckBox vertexByBoneEnable;
		private System.Windows.Forms.RadioButton vertexByBoneAllRadio;
		private System.Windows.Forms.RadioButton vertexByBoneAnyRadio;
		private System.Windows.Forms.ListView vertexByBoneList;
	}
}