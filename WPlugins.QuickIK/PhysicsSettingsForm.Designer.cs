namespace WPlugins.QuickIK
{
    partial class PhysicsSettingsForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.shapeSelect = new System.Windows.Forms.ComboBox();
            this.widthText = new System.Windows.Forms.TextBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightText = new System.Windows.Forms.TextBox();
            this.lengthText = new System.Windows.Forms.TextBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lengthCalcSelect = new System.Windows.Forms.ComboBox();
            this.modeSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.attachParentCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(230, 219);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(149, 219);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // shapeSelect
            // 
            this.shapeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shapeSelect.FormattingEnabled = true;
            this.shapeSelect.Items.AddRange(new object[] {
            "Sphere",
            "Box",
            "Capsule"});
            this.shapeSelect.Location = new System.Drawing.Point(65, 12);
            this.shapeSelect.Name = "shapeSelect";
            this.shapeSelect.Size = new System.Drawing.Size(240, 21);
            this.shapeSelect.TabIndex = 2;
            this.shapeSelect.SelectedIndexChanged += new System.EventHandler(this.shapeSelect_SelectedIndexChanged);
            // 
            // widthText
            // 
            this.widthText.Location = new System.Drawing.Point(107, 54);
            this.widthText.Name = "widthText";
            this.widthText.Size = new System.Drawing.Size(100, 20);
            this.widthText.TabIndex = 3;
            this.widthText.Text = "0.2";
            this.widthText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(12, 57);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 4;
            this.widthLabel.Text = "Width";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(12, 83);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 6;
            this.heightLabel.Text = "Height";
            // 
            // heightText
            // 
            this.heightText.Location = new System.Drawing.Point(107, 80);
            this.heightText.Name = "heightText";
            this.heightText.Size = new System.Drawing.Size(100, 20);
            this.heightText.TabIndex = 5;
            this.heightText.Text = "0.2";
            this.heightText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lengthText
            // 
            this.lengthText.Location = new System.Drawing.Point(107, 106);
            this.lengthText.Name = "lengthText";
            this.lengthText.Size = new System.Drawing.Size(100, 20);
            this.lengthText.TabIndex = 5;
            this.lengthText.Text = "1.0";
            this.lengthText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(12, 109);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(40, 13);
            this.lengthLabel.TabIndex = 6;
            this.lengthLabel.Text = "Length";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Length calculation";
            // 
            // lengthCalcSelect
            // 
            this.lengthCalcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lengthCalcSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lengthCalcSelect.FormattingEnabled = true;
            this.lengthCalcSelect.Items.AddRange(new object[] {
            "Absolute length",
            "Relative to spacing",
            "Distance of ends from bones"});
            this.lengthCalcSelect.Location = new System.Drawing.Point(129, 132);
            this.lengthCalcSelect.Name = "lengthCalcSelect";
            this.lengthCalcSelect.Size = new System.Drawing.Size(176, 21);
            this.lengthCalcSelect.TabIndex = 2;
            this.lengthCalcSelect.SelectedIndexChanged += new System.EventHandler(this.lengthCalcSelect_SelectedIndexChanged);
            // 
            // modeSelect
            // 
            this.modeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeSelect.FormattingEnabled = true;
            this.modeSelect.Items.AddRange(new object[] {
            "Static",
            "Dynamic",
            "Dynamic (follow)"});
            this.modeSelect.Location = new System.Drawing.Point(101, 168);
            this.modeSelect.Name = "modeSelect";
            this.modeSelect.Size = new System.Drawing.Size(204, 21);
            this.modeSelect.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Shape";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mode";
            // 
            // attachParentCheck
            // 
            this.attachParentCheck.AutoSize = true;
            this.attachParentCheck.Location = new System.Drawing.Point(12, 195);
            this.attachParentCheck.Name = "attachParentCheck";
            this.attachParentCheck.Size = new System.Drawing.Size(102, 17);
            this.attachParentCheck.TabIndex = 11;
            this.attachParentCheck.Text = "Attach to parent";
            this.attachParentCheck.UseVisualStyleBackColor = true;
            // 
            // PhysicsSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 254);
            this.Controls.Add(this.attachParentCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modeSelect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.lengthText);
            this.Controls.Add(this.heightText);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.widthText);
            this.Controls.Add(this.lengthCalcSelect);
            this.Controls.Add(this.shapeSelect);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhysicsSettingsForm";
            this.Text = "Physics settings";
            this.Load += new System.EventHandler(this.PhysicsSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox shapeSelect;
        private System.Windows.Forms.TextBox widthText;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox heightText;
        private System.Windows.Forms.TextBox lengthText;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox lengthCalcSelect;
        private System.Windows.Forms.ComboBox modeSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox attachParentCheck;
    }
}