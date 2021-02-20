namespace WPlugins.SelectionStorage
{
    partial class SelectionExportForm
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
            System.Windows.Forms.Label label1;
            this.exportByIndexRadio = new System.Windows.Forms.RadioButton();
            this.exportByIndexGroup = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            this.exportByIndexGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportByIndexRadio
            // 
            this.exportByIndexRadio.AutoSize = true;
            this.exportByIndexRadio.Location = new System.Drawing.Point(12, 12);
            this.exportByIndexRadio.Name = "exportByIndexRadio";
            this.exportByIndexRadio.Size = new System.Drawing.Size(97, 17);
            this.exportByIndexRadio.TabIndex = 0;
            this.exportByIndexRadio.TabStop = true;
            this.exportByIndexRadio.Text = "Export by index";
            this.exportByIndexRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.Location = new System.Drawing.Point(6, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(324, 45);
            label1.TabIndex = 1;
            label1.Text = "Exporting by index stores the exact identifier of the object so that there can be" +
    " no ambiguity when importing.\r\nChanging the model\'s topology immediately invalid" +
    "ates this selection.";
            // 
            // exportByIndexGroup
            // 
            this.exportByIndexGroup.Controls.Add(label1);
            this.exportByIndexGroup.Location = new System.Drawing.Point(12, 32);
            this.exportByIndexGroup.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.exportByIndexGroup.Name = "exportByIndexGroup";
            this.exportByIndexGroup.Size = new System.Drawing.Size(336, 166);
            this.exportByIndexGroup.TabIndex = 2;
            this.exportByIndexGroup.TabStop = false;
            // 
            // SelectionExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exportByIndexGroup);
            this.Controls.Add(this.exportByIndexRadio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectionExportForm";
            this.Text = "Export Selection";
            this.exportByIndexGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton exportByIndexRadio;
        private System.Windows.Forms.GroupBox exportByIndexGroup;
    }
}