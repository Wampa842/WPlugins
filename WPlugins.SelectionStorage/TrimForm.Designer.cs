namespace WPlugins.SelectionStorage
{
    partial class TrimForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.removeVertices = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.keepVertices = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.removeTriangles = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.keepTriangles = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.removeBones = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.keepBones = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.removeRigidbodies = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.keepRigidbodies = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.removeJoints = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.keepJoints = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.trimCloneButton = new System.Windows.Forms.Button();
            this.trimButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.removeVertices);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.keepVertices);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 77);
            this.panel1.TabIndex = 0;
            // 
            // removeVertices
            // 
            this.removeVertices.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeVertices.Location = new System.Drawing.Point(6, 45);
            this.removeVertices.Name = "removeVertices";
            this.removeVertices.Size = new System.Drawing.Size(78, 22);
            this.removeVertices.TabIndex = 2;
            this.removeVertices.Text = "Remove";
            this.removeVertices.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vertices";
            // 
            // keepVertices
            // 
            this.keepVertices.Appearance = System.Windows.Forms.Appearance.Button;
            this.keepVertices.Checked = true;
            this.keepVertices.Location = new System.Drawing.Point(6, 22);
            this.keepVertices.Name = "keepVertices";
            this.keepVertices.Size = new System.Drawing.Size(78, 22);
            this.keepVertices.TabIndex = 0;
            this.keepVertices.TabStop = true;
            this.keepVertices.Text = "Keep";
            this.keepVertices.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.removeTriangles);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.keepTriangles);
            this.panel3.Location = new System.Drawing.Point(102, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 77);
            this.panel3.TabIndex = 3;
            // 
            // removeTriangles
            // 
            this.removeTriangles.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeTriangles.Location = new System.Drawing.Point(6, 45);
            this.removeTriangles.Name = "removeTriangles";
            this.removeTriangles.Size = new System.Drawing.Size(78, 22);
            this.removeTriangles.TabIndex = 2;
            this.removeTriangles.Text = "Remove";
            this.removeTriangles.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Faces";
            // 
            // keepTriangles
            // 
            this.keepTriangles.Appearance = System.Windows.Forms.Appearance.Button;
            this.keepTriangles.Checked = true;
            this.keepTriangles.Location = new System.Drawing.Point(6, 22);
            this.keepTriangles.Name = "keepTriangles";
            this.keepTriangles.Size = new System.Drawing.Size(78, 22);
            this.keepTriangles.TabIndex = 0;
            this.keepTriangles.TabStop = true;
            this.keepTriangles.Text = "Keep";
            this.keepTriangles.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.removeBones);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.keepBones);
            this.panel4.Location = new System.Drawing.Point(192, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(90, 77);
            this.panel4.TabIndex = 3;
            // 
            // removeBones
            // 
            this.removeBones.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeBones.Location = new System.Drawing.Point(6, 45);
            this.removeBones.Name = "removeBones";
            this.removeBones.Size = new System.Drawing.Size(78, 22);
            this.removeBones.TabIndex = 2;
            this.removeBones.Text = "Remove";
            this.removeBones.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bones";
            // 
            // keepBones
            // 
            this.keepBones.Appearance = System.Windows.Forms.Appearance.Button;
            this.keepBones.Checked = true;
            this.keepBones.Location = new System.Drawing.Point(6, 22);
            this.keepBones.Name = "keepBones";
            this.keepBones.Size = new System.Drawing.Size(78, 22);
            this.keepBones.TabIndex = 0;
            this.keepBones.TabStop = true;
            this.keepBones.Text = "Keep";
            this.keepBones.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.removeRigidbodies);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.keepRigidbodies);
            this.panel5.Location = new System.Drawing.Point(282, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(90, 77);
            this.panel5.TabIndex = 3;
            // 
            // removeRigidbodies
            // 
            this.removeRigidbodies.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeRigidbodies.Location = new System.Drawing.Point(6, 45);
            this.removeRigidbodies.Name = "removeRigidbodies";
            this.removeRigidbodies.Size = new System.Drawing.Size(78, 22);
            this.removeRigidbodies.TabIndex = 2;
            this.removeRigidbodies.Text = "Remove";
            this.removeRigidbodies.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Rigid bodies";
            // 
            // keepRigidbodies
            // 
            this.keepRigidbodies.Appearance = System.Windows.Forms.Appearance.Button;
            this.keepRigidbodies.Checked = true;
            this.keepRigidbodies.Location = new System.Drawing.Point(6, 22);
            this.keepRigidbodies.Name = "keepRigidbodies";
            this.keepRigidbodies.Size = new System.Drawing.Size(78, 22);
            this.keepRigidbodies.TabIndex = 0;
            this.keepRigidbodies.TabStop = true;
            this.keepRigidbodies.Text = "Keep";
            this.keepRigidbodies.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.removeJoints);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.keepJoints);
            this.panel6.Location = new System.Drawing.Point(372, 34);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(90, 77);
            this.panel6.TabIndex = 3;
            // 
            // removeJoints
            // 
            this.removeJoints.Appearance = System.Windows.Forms.Appearance.Button;
            this.removeJoints.Location = new System.Drawing.Point(6, 45);
            this.removeJoints.Name = "removeJoints";
            this.removeJoints.Size = new System.Drawing.Size(78, 22);
            this.removeJoints.TabIndex = 2;
            this.removeJoints.Text = "Remove";
            this.removeJoints.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Joints";
            // 
            // keepJoints
            // 
            this.keepJoints.Appearance = System.Windows.Forms.Appearance.Button;
            this.keepJoints.Checked = true;
            this.keepJoints.Location = new System.Drawing.Point(6, 22);
            this.keepJoints.Name = "keepJoints";
            this.keepJoints.Size = new System.Drawing.Size(78, 22);
            this.keepJoints.TabIndex = 0;
            this.keepJoints.TabStop = true;
            this.keepJoints.Text = "Keep";
            this.keepJoints.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "By trimming the selection, you can remove unwanted object types. This cannot be u" +
    "ndone.";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(388, 118);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // trimCloneButton
            // 
            this.trimCloneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trimCloneButton.Location = new System.Drawing.Point(289, 118);
            this.trimCloneButton.Name = "trimCloneButton";
            this.trimCloneButton.Size = new System.Drawing.Size(93, 23);
            this.trimCloneButton.TabIndex = 6;
            this.trimCloneButton.Text = "Clone and trim";
            this.trimCloneButton.UseVisualStyleBackColor = true;
            this.trimCloneButton.Click += new System.EventHandler(this.trimCloneButton_Click);
            // 
            // trimButton
            // 
            this.trimButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trimButton.Location = new System.Drawing.Point(190, 118);
            this.trimButton.Name = "trimButton";
            this.trimButton.Size = new System.Drawing.Size(93, 23);
            this.trimButton.TabIndex = 7;
            this.trimButton.Text = "Trim original";
            this.trimButton.UseVisualStyleBackColor = true;
            this.trimButton.Click += new System.EventHandler(this.trimButton_Click);
            // 
            // TrimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 153);
            this.Controls.Add(this.trimButton);
            this.Controls.Add(this.trimCloneButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrimForm";
            this.Text = "Trim selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrimForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton removeVertices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton keepVertices;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton removeTriangles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton keepTriangles;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton removeBones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton keepBones;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton removeRigidbodies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton keepRigidbodies;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton removeJoints;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton keepJoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button trimCloneButton;
        private System.Windows.Forms.Button trimButton;
    }
}