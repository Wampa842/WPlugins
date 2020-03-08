namespace WPlugins.ViewSettingsStorage
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
            this.storedList = new System.Windows.Forms.ListView();
            this.storeButton = new System.Windows.Forms.Button();
            this.restoreButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.getCurrentButton = new System.Windows.Forms.Button();
            this.applyCurrentButton = new System.Windows.Forms.Button();
            this.cameraEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cameraPerspective = new System.Windows.Forms.CheckBox();
            this.cameraGroup = new System.Windows.Forms.GroupBox();
            this.cameraUp = new WPlugins.Common.UI.Vector3Numeric();
            this.cameraTarget = new WPlugins.Common.UI.Vector3Numeric();
            this.cameraPosition = new WPlugins.Common.UI.Vector3Numeric();
            this.orbitEnable = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orbitCenter = new WPlugins.Common.UI.Vector3Numeric();
            this.backgroundEnable = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundColor = new WPlugins.Common.UI.ColorSwatchNumeric();
            this.lightEnable = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lightDirection = new WPlugins.Common.UI.Vector3Numeric();
            this.lightColor = new WPlugins.Common.UI.ColorSwatchNumeric();
            this.ambientColor = new WPlugins.Common.UI.ColorSwatchNumeric();
            this.floorGrid = new System.Windows.Forms.CheckBox();
            this.cameraGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // storedList
            // 
            this.storedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storedList.Location = new System.Drawing.Point(12, 12);
            this.storedList.Name = "storedList";
            this.storedList.Size = new System.Drawing.Size(177, 540);
            this.storedList.TabIndex = 0;
            this.storedList.UseCompatibleStateImageBehavior = false;
            // 
            // storeButton
            // 
            this.storeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.storeButton.Location = new System.Drawing.Point(73, 558);
            this.storeButton.Name = "storeButton";
            this.storeButton.Size = new System.Drawing.Size(55, 23);
            this.storeButton.TabIndex = 1;
            this.storeButton.Text = "Store";
            this.storeButton.UseVisualStyleBackColor = true;
            this.storeButton.Click += new System.EventHandler(this.storeButton_Click);
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.restoreButton.Location = new System.Drawing.Point(12, 558);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(55, 23);
            this.restoreButton.TabIndex = 2;
            this.restoreButton.Text = "Load";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(134, 558);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(55, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // getCurrentButton
            // 
            this.getCurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getCurrentButton.Location = new System.Drawing.Point(195, 12);
            this.getCurrentButton.Name = "getCurrentButton";
            this.getCurrentButton.Size = new System.Drawing.Size(409, 32);
            this.getCurrentButton.TabIndex = 5;
            this.getCurrentButton.Text = "Get current view settings";
            this.getCurrentButton.UseVisualStyleBackColor = true;
            this.getCurrentButton.Click += new System.EventHandler(this.getCurrentButton_Click);
            // 
            // applyCurrentButton
            // 
            this.applyCurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyCurrentButton.Location = new System.Drawing.Point(195, 549);
            this.applyCurrentButton.Name = "applyCurrentButton";
            this.applyCurrentButton.Size = new System.Drawing.Size(409, 32);
            this.applyCurrentButton.TabIndex = 14;
            this.applyCurrentButton.Text = "Apply to current view";
            this.applyCurrentButton.UseVisualStyleBackColor = true;
            this.applyCurrentButton.Click += new System.EventHandler(this.applyCurrentButton_Click);
            // 
            // cameraEnable
            // 
            this.cameraEnable.AutoSize = true;
            this.cameraEnable.Checked = true;
            this.cameraEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cameraEnable.Location = new System.Drawing.Point(100, 0);
            this.cameraEnable.Name = "cameraEnable";
            this.cameraEnable.Size = new System.Drawing.Size(59, 17);
            this.cameraEnable.TabIndex = 6;
            this.cameraEnable.Text = "Enable";
            this.cameraEnable.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Target";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Up vector";
            // 
            // cameraPerspective
            // 
            this.cameraPerspective.AutoSize = true;
            this.cameraPerspective.Enabled = false;
            this.cameraPerspective.Location = new System.Drawing.Point(18, 102);
            this.cameraPerspective.Name = "cameraPerspective";
            this.cameraPerspective.Size = new System.Drawing.Size(82, 17);
            this.cameraPerspective.TabIndex = 10;
            this.cameraPerspective.Text = "Perspective";
            this.cameraPerspective.UseVisualStyleBackColor = true;
            // 
            // cameraGroup
            // 
            this.cameraGroup.Controls.Add(this.cameraUp);
            this.cameraGroup.Controls.Add(this.cameraTarget);
            this.cameraGroup.Controls.Add(this.cameraPosition);
            this.cameraGroup.Controls.Add(this.cameraPerspective);
            this.cameraGroup.Controls.Add(this.label3);
            this.cameraGroup.Controls.Add(this.label2);
            this.cameraGroup.Controls.Add(this.label1);
            this.cameraGroup.Controls.Add(this.cameraEnable);
            this.cameraGroup.Location = new System.Drawing.Point(195, 50);
            this.cameraGroup.Name = "cameraGroup";
            this.cameraGroup.Size = new System.Drawing.Size(409, 125);
            this.cameraGroup.TabIndex = 4;
            this.cameraGroup.TabStop = false;
            this.cameraGroup.Text = "Camera";
            // 
            // cameraUp
            // 
            this.cameraUp.Location = new System.Drawing.Point(178, 68);
            this.cameraUp.Margin = new System.Windows.Forms.Padding(0);
            this.cameraUp.Name = "cameraUp";
            this.cameraUp.Size = new System.Drawing.Size(228, 26);
            this.cameraUp.TabIndex = 18;
            this.cameraUp.X = 0F;
            this.cameraUp.Y = 0F;
            this.cameraUp.Z = 0F;
            // 
            // cameraTarget
            // 
            this.cameraTarget.Location = new System.Drawing.Point(178, 42);
            this.cameraTarget.Margin = new System.Windows.Forms.Padding(0);
            this.cameraTarget.Name = "cameraTarget";
            this.cameraTarget.Size = new System.Drawing.Size(228, 26);
            this.cameraTarget.TabIndex = 17;
            this.cameraTarget.X = 0F;
            this.cameraTarget.Y = 0F;
            this.cameraTarget.Z = 0F;
            // 
            // cameraPosition
            // 
            this.cameraPosition.Location = new System.Drawing.Point(178, 16);
            this.cameraPosition.Margin = new System.Windows.Forms.Padding(0);
            this.cameraPosition.Name = "cameraPosition";
            this.cameraPosition.Size = new System.Drawing.Size(228, 26);
            this.cameraPosition.TabIndex = 16;
            this.cameraPosition.X = 5F;
            this.cameraPosition.Y = 0F;
            this.cameraPosition.Z = 0F;
            // 
            // orbitEnable
            // 
            this.orbitEnable.AutoSize = true;
            this.orbitEnable.Checked = true;
            this.orbitEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.orbitEnable.Location = new System.Drawing.Point(100, 0);
            this.orbitEnable.Name = "orbitEnable";
            this.orbitEnable.Size = new System.Drawing.Size(59, 17);
            this.orbitEnable.TabIndex = 6;
            this.orbitEnable.Text = "Enable";
            this.orbitEnable.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Center";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.orbitCenter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.orbitEnable);
            this.groupBox1.Location = new System.Drawing.Point(195, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 52);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orbit";
            // 
            // orbitCenter
            // 
            this.orbitCenter.Location = new System.Drawing.Point(178, 16);
            this.orbitCenter.Margin = new System.Windows.Forms.Padding(0);
            this.orbitCenter.Name = "orbitCenter";
            this.orbitCenter.Size = new System.Drawing.Size(228, 26);
            this.orbitCenter.TabIndex = 19;
            this.orbitCenter.X = 0F;
            this.orbitCenter.Y = 0F;
            this.orbitCenter.Z = 0F;
            // 
            // backgroundEnable
            // 
            this.backgroundEnable.AutoSize = true;
            this.backgroundEnable.Checked = true;
            this.backgroundEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backgroundEnable.Location = new System.Drawing.Point(100, 0);
            this.backgroundEnable.Name = "backgroundEnable";
            this.backgroundEnable.Size = new System.Drawing.Size(59, 17);
            this.backgroundEnable.TabIndex = 6;
            this.backgroundEnable.Text = "Enable";
            this.backgroundEnable.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Background color";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.backgroundColor);
            this.groupBox3.Controls.Add(this.floorGrid);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.backgroundEnable);
            this.groupBox3.Location = new System.Drawing.Point(195, 351);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 73);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Background";
            // 
            // backgroundColor
            // 
            this.backgroundColor.Color = System.Drawing.Color.White;
            this.backgroundColor.Location = new System.Drawing.Point(190, 16);
            this.backgroundColor.Margin = new System.Windows.Forms.Padding(0);
            this.backgroundColor.Name = "backgroundColor";
            this.backgroundColor.Size = new System.Drawing.Size(216, 26);
            this.backgroundColor.TabIndex = 21;
            // 
            // lightEnable
            // 
            this.lightEnable.AutoSize = true;
            this.lightEnable.Checked = true;
            this.lightEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lightEnable.Location = new System.Drawing.Point(100, 0);
            this.lightEnable.Name = "lightEnable";
            this.lightEnable.Size = new System.Drawing.Size(59, 17);
            this.lightEnable.TabIndex = 6;
            this.lightEnable.Text = "Enable";
            this.lightEnable.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ambient color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Light color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Direction";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lightDirection);
            this.groupBox2.Controls.Add(this.lightColor);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ambientColor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lightEnable);
            this.groupBox2.Location = new System.Drawing.Point(195, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 106);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light";
            // 
            // lightDirection
            // 
            this.lightDirection.Location = new System.Drawing.Point(178, 68);
            this.lightDirection.Margin = new System.Windows.Forms.Padding(0);
            this.lightDirection.Name = "lightDirection";
            this.lightDirection.Size = new System.Drawing.Size(228, 26);
            this.lightDirection.TabIndex = 20;
            this.lightDirection.X = 0F;
            this.lightDirection.Y = 0F;
            this.lightDirection.Z = 0F;
            // 
            // lightColor
            // 
            this.lightColor.Color = System.Drawing.Color.White;
            this.lightColor.Location = new System.Drawing.Point(190, 42);
            this.lightColor.Margin = new System.Windows.Forms.Padding(0);
            this.lightColor.Name = "lightColor";
            this.lightColor.Size = new System.Drawing.Size(216, 26);
            this.lightColor.TabIndex = 16;
            // 
            // ambientColor
            // 
            this.ambientColor.Color = System.Drawing.Color.White;
            this.ambientColor.Location = new System.Drawing.Point(190, 16);
            this.ambientColor.Margin = new System.Windows.Forms.Padding(0);
            this.ambientColor.Name = "ambientColor";
            this.ambientColor.Size = new System.Drawing.Size(216, 26);
            this.ambientColor.TabIndex = 15;
            // 
            // floorGrid
            // 
            this.floorGrid.AutoSize = true;
            this.floorGrid.Enabled = false;
            this.floorGrid.Location = new System.Drawing.Point(18, 50);
            this.floorGrid.Name = "floorGrid";
            this.floorGrid.Size = new System.Drawing.Size(69, 17);
            this.floorGrid.TabIndex = 11;
            this.floorGrid.Text = "Floor grid";
            this.floorGrid.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 593);
            this.Controls.Add(this.applyCurrentButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.getCurrentButton);
            this.Controls.Add(this.cameraGroup);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.restoreButton);
            this.Controls.Add(this.storeButton);
            this.Controls.Add(this.storedList);
            this.Name = "MainForm";
            this.Text = "View Settings";
            this.cameraGroup.ResumeLayout(false);
            this.cameraGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView storedList;
        private System.Windows.Forms.Button storeButton;
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button getCurrentButton;
        private System.Windows.Forms.Button applyCurrentButton;
        private System.Windows.Forms.CheckBox cameraEnable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cameraPerspective;
        private System.Windows.Forms.GroupBox cameraGroup;
        private System.Windows.Forms.CheckBox orbitEnable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox backgroundEnable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox lightEnable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private Common.UI.ColorSwatchNumeric ambientColor;
        private Common.UI.ColorSwatchNumeric lightColor;
        private Common.UI.ColorSwatchNumeric backgroundColor;
        private Common.UI.Vector3Numeric cameraUp;
        private Common.UI.Vector3Numeric cameraTarget;
        private Common.UI.Vector3Numeric cameraPosition;
        private Common.UI.Vector3Numeric orbitCenter;
        private Common.UI.Vector3Numeric lightDirection;
        private System.Windows.Forms.CheckBox floorGrid;
    }
}