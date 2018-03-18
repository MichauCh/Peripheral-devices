namespace ScannerWIA
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
            this.buttonSearchDev = new System.Windows.Forms.Button();
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonChooseScanner = new System.Windows.Forms.Button();
            this.pbScannedImage = new System.Windows.Forms.PictureBox();
            this.labelDpi = new System.Windows.Forms.Label();
            this.textBoxDpi = new System.Windows.Forms.TextBox();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.labelContrast = new System.Windows.Forms.Label();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.radioButtonColor = new System.Windows.Forms.RadioButton();
            this.radioButtonGrayscale = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbScannedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearchDev
            // 
            this.buttonSearchDev.Location = new System.Drawing.Point(12, 12);
            this.buttonSearchDev.Name = "buttonSearchDev";
            this.buttonSearchDev.Size = new System.Drawing.Size(97, 23);
            this.buttonSearchDev.TabIndex = 0;
            this.buttonSearchDev.Text = "Search devices";
            this.buttonSearchDev.UseVisualStyleBackColor = true;
            this.buttonSearchDev.Click += new System.EventHandler(this.buttonSearchDev_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(682, 17);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 1;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonChooseScanner
            // 
            this.buttonChooseScanner.Location = new System.Drawing.Point(113, 12);
            this.buttonChooseScanner.Name = "buttonChooseScanner";
            this.buttonChooseScanner.Size = new System.Drawing.Size(92, 23);
            this.buttonChooseScanner.TabIndex = 2;
            this.buttonChooseScanner.Text = "Choose scanner";
            this.buttonChooseScanner.UseVisualStyleBackColor = true;
            this.buttonChooseScanner.Click += new System.EventHandler(this.buttonChooseScanner_Click);
            // 
            // pbScannedImage
            // 
            this.pbScannedImage.Location = new System.Drawing.Point(12, 58);
            this.pbScannedImage.Name = "pbScannedImage";
            this.pbScannedImage.Size = new System.Drawing.Size(921, 853);
            this.pbScannedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbScannedImage.TabIndex = 3;
            this.pbScannedImage.TabStop = false;
            // 
            // labelDpi
            // 
            this.labelDpi.AutoSize = true;
            this.labelDpi.Location = new System.Drawing.Point(211, 17);
            this.labelDpi.Name = "labelDpi";
            this.labelDpi.Size = new System.Drawing.Size(28, 13);
            this.labelDpi.TabIndex = 4;
            this.labelDpi.Text = "DPI:";
            // 
            // textBoxDpi
            // 
            this.textBoxDpi.Location = new System.Drawing.Point(245, 14);
            this.textBoxDpi.Name = "textBoxDpi";
            this.textBoxDpi.Size = new System.Drawing.Size(41, 20);
            this.textBoxDpi.TabIndex = 5;
            this.textBoxDpi.Text = "300";
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.Location = new System.Drawing.Point(304, 17);
            this.trackBarContrast.Maximum = 30;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(104, 45);
            this.trackBarContrast.TabIndex = 6;
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(414, 17);
            this.trackBarBrightness.Maximum = 50;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(104, 45);
            this.trackBarBrightness.TabIndex = 7;
            // 
            // labelContrast
            // 
            this.labelContrast.AutoSize = true;
            this.labelContrast.Location = new System.Drawing.Point(334, 7);
            this.labelContrast.Name = "labelContrast";
            this.labelContrast.Size = new System.Drawing.Size(46, 13);
            this.labelContrast.TabIndex = 8;
            this.labelContrast.Text = "Contrast";
            // 
            // labelBrightness
            // 
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.Location = new System.Drawing.Point(442, 7);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(56, 13);
            this.labelBrightness.TabIndex = 9;
            this.labelBrightness.Text = "Brightness";
            // 
            // radioButtonColor
            // 
            this.radioButtonColor.AutoSize = true;
            this.radioButtonColor.Checked = true;
            this.radioButtonColor.Location = new System.Drawing.Point(535, 12);
            this.radioButtonColor.Name = "radioButtonColor";
            this.radioButtonColor.Size = new System.Drawing.Size(49, 17);
            this.radioButtonColor.TabIndex = 10;
            this.radioButtonColor.TabStop = true;
            this.radioButtonColor.Text = "Color";
            this.radioButtonColor.UseVisualStyleBackColor = true;
            // 
            // radioButtonGrayscale
            // 
            this.radioButtonGrayscale.AutoSize = true;
            this.radioButtonGrayscale.Location = new System.Drawing.Point(535, 35);
            this.radioButtonGrayscale.Name = "radioButtonGrayscale";
            this.radioButtonGrayscale.Size = new System.Drawing.Size(72, 17);
            this.radioButtonGrayscale.TabIndex = 11;
            this.radioButtonGrayscale.Text = "Grayscale";
            this.radioButtonGrayscale.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(763, 17);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "image";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 923);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.radioButtonGrayscale);
            this.Controls.Add(this.radioButtonColor);
            this.Controls.Add(this.labelBrightness);
            this.Controls.Add(this.labelContrast);
            this.Controls.Add(this.trackBarBrightness);
            this.Controls.Add(this.trackBarContrast);
            this.Controls.Add(this.textBoxDpi);
            this.Controls.Add(this.labelDpi);
            this.Controls.Add(this.pbScannedImage);
            this.Controls.Add(this.buttonChooseScanner);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.buttonSearchDev);
            this.Name = "Form1";
            this.Text = "WIA Scanner App";
            ((System.ComponentModel.ISupportInitialize)(this.pbScannedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearchDev;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonChooseScanner;
        private System.Windows.Forms.PictureBox pbScannedImage;
        private System.Windows.Forms.Label labelDpi;
        private System.Windows.Forms.TextBox textBoxDpi;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.Label labelContrast;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.RadioButton radioButtonColor;
        private System.Windows.Forms.RadioButton radioButtonGrayscale;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

