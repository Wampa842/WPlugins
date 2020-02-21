namespace WPlugins.Common.UI
{
    partial class Vector3Numeric
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xNumber = new System.Windows.Forms.NumericUpDown();
            this.yNumber = new System.Windows.Forms.NumericUpDown();
            this.zNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.xNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // xNumber
            // 
            this.xNumber.DecimalPlaces = 4;
            this.xNumber.Location = new System.Drawing.Point(3, 3);
            this.xNumber.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.xNumber.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.xNumber.Name = "xNumber";
            this.xNumber.Size = new System.Drawing.Size(70, 20);
            this.xNumber.TabIndex = 0;
            this.xNumber.ValueChanged += new System.EventHandler(this.number_ValueChanged);
            // 
            // yNumber
            // 
            this.yNumber.DecimalPlaces = 4;
            this.yNumber.Location = new System.Drawing.Point(79, 3);
            this.yNumber.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.yNumber.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.yNumber.Name = "yNumber";
            this.yNumber.Size = new System.Drawing.Size(70, 20);
            this.yNumber.TabIndex = 1;
            this.yNumber.ValueChanged += new System.EventHandler(this.number_ValueChanged);
            // 
            // zNumber
            // 
            this.zNumber.DecimalPlaces = 4;
            this.zNumber.Location = new System.Drawing.Point(155, 3);
            this.zNumber.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.zNumber.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.zNumber.Name = "zNumber";
            this.zNumber.Size = new System.Drawing.Size(70, 20);
            this.zNumber.TabIndex = 2;
            this.zNumber.ValueChanged += new System.EventHandler(this.number_ValueChanged);
            // 
            // Vector3Numeric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.zNumber);
            this.Controls.Add(this.yNumber);
            this.Controls.Add(this.xNumber);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Vector3Numeric";
            this.Size = new System.Drawing.Size(228, 26);
            this.EnabledChanged += new System.EventHandler(this.Vector3Numeric_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.xNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown xNumber;
        private System.Windows.Forms.NumericUpDown yNumber;
        private System.Windows.Forms.NumericUpDown zNumber;
    }
}
