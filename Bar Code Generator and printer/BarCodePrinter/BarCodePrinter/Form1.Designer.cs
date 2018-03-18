namespace BarCodePrinter
{
    partial class Form1
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
            this.labelEnterEan = new System.Windows.Forms.Label();
            this.tbEan = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.pbBarCode = new System.Windows.Forms.PictureBox();
            this.cbControlSum = new System.Windows.Forms.CheckBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEnterEan
            // 
            this.labelEnterEan.AutoSize = true;
            this.labelEnterEan.Location = new System.Drawing.Point(12, 9);
            this.labelEnterEan.Name = "labelEnterEan";
            this.labelEnterEan.Size = new System.Drawing.Size(102, 13);
            this.labelEnterEan.TabIndex = 0;
            this.labelEnterEan.Text = "Enter EAN-13 code:";
            // 
            // tbEan
            // 
            this.tbEan.Location = new System.Drawing.Point(120, 6);
            this.tbEan.Name = "tbEan";
            this.tbEan.Size = new System.Drawing.Size(136, 20);
            this.tbEan.TabIndex = 1;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(15, 230);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(372, 22);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.Text = "Generate BARCODE";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // pbBarCode
            // 
            this.pbBarCode.Location = new System.Drawing.Point(12, 32);
            this.pbBarCode.Name = "pbBarCode";
            this.pbBarCode.Size = new System.Drawing.Size(377, 192);
            this.pbBarCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBarCode.TabIndex = 3;
            this.pbBarCode.TabStop = false;
            // 
            // cbControlSum
            // 
            this.cbControlSum.AutoSize = true;
            this.cbControlSum.Location = new System.Drawing.Point(262, 9);
            this.cbControlSum.Name = "cbControlSum";
            this.cbControlSum.Size = new System.Drawing.Size(127, 17);
            this.cbControlSum.TabIndex = 4;
            this.cbControlSum.Text = "Generate control sum";
            this.cbControlSum.UseVisualStyleBackColor = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(160, 258);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 287);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.cbControlSum);
            this.Controls.Add(this.pbBarCode);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.tbEan);
            this.Controls.Add(this.labelEnterEan);
            this.Name = "Form1";
            this.Text = "EAN-13 BarCode Generator & Printer";
            ((System.ComponentModel.ISupportInitialize)(this.pbBarCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEnterEan;
        private System.Windows.Forms.TextBox tbEan;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.PictureBox pbBarCode;
        private System.Windows.Forms.CheckBox cbControlSum;
        private System.Windows.Forms.Button buttonPrint;
    }
}

