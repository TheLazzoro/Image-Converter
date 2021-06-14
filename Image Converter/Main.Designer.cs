namespace Image_Converter
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblSelectImage = new System.Windows.Forms.Label();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboxOutputFormat = new System.Windows.Forms.ComboBox();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.lblOutputDirectory = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trckbarImageQuality = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lblImageQuality = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radBtnSingle = new System.Windows.Forms.RadioButton();
            this.radBtnMulti = new System.Windows.Forms.RadioButton();
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.cmboxDDSList = new System.Windows.Forms.ComboBox();
            this.chkBoxKeepFilenames = new System.Windows.Forms.CheckBox();
            this.chkBoxMipmaps = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarImageQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectImage
            // 
            this.lblSelectImage.AutoSize = true;
            this.lblSelectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelectImage.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblSelectImage.Location = new System.Drawing.Point(14, 57);
            this.lblSelectImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectImage.Name = "lblSelectImage";
            this.lblSelectImage.Size = new System.Drawing.Size(114, 16);
            this.lblSelectImage.TabIndex = 0;
            this.lblSelectImage.Text = "Select Image File:";
            // 
            // btnInputFile
            // 
            this.btnInputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnInputFile.FlatAppearance.BorderSize = 0;
            this.btnInputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInputFile.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInputFile.Location = new System.Drawing.Point(14, 75);
            this.btnInputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(88, 27);
            this.btnInputFile.TabIndex = 1;
            this.btnInputFile.Text = "Choose...";
            this.btnInputFile.UseVisualStyleBackColor = false;
            this.btnInputFile.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoEllipsis = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFilePath.ForeColor = System.Drawing.Color.Black;
            this.lblFilePath.Location = new System.Drawing.Point(115, 81);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(278, 21);
            this.lblFilePath.TabIndex = 2;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnConvert.Enabled = false;
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConvert.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConvert.Location = new System.Drawing.Point(14, 383);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(88, 27);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(374, 383);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 27);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(13, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output Format:";
            // 
            // cmboxOutputFormat
            // 
            this.cmboxOutputFormat.BackColor = System.Drawing.Color.White;
            this.cmboxOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxOutputFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmboxOutputFormat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cmboxOutputFormat.FormattingEnabled = true;
            this.cmboxOutputFormat.Location = new System.Drawing.Point(14, 144);
            this.cmboxOutputFormat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmboxOutputFormat.Name = "cmboxOutputFormat";
            this.cmboxOutputFormat.Size = new System.Drawing.Size(101, 24);
            this.cmboxOutputFormat.TabIndex = 6;
            this.cmboxOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cmboxOutputFormat_SelectedIndexChanged);
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnOutputFile.FlatAppearance.BorderSize = 0;
            this.btnOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOutputFile.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOutputFile.Location = new System.Drawing.Point(18, 220);
            this.btnOutputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(88, 27);
            this.btnOutputFile.TabIndex = 7;
            this.btnOutputFile.Text = "Choose...";
            this.btnOutputFile.UseVisualStyleBackColor = false;
            this.btnOutputFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.AutoEllipsis = true;
            this.lblOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOutputDirectory.ForeColor = System.Drawing.Color.Black;
            this.lblOutputDirectory.Location = new System.Drawing.Point(117, 226);
            this.lblOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(278, 21);
            this.lblOutputDirectory.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(14, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Output Directory:";
            // 
            // trckbarImageQuality
            // 
            this.trckbarImageQuality.Location = new System.Drawing.Point(171, 144);
            this.trckbarImageQuality.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trckbarImageQuality.Minimum = 1;
            this.trckbarImageQuality.Name = "trckbarImageQuality";
            this.trckbarImageQuality.Size = new System.Drawing.Size(222, 45);
            this.trckbarImageQuality.SmallChange = 10;
            this.trckbarImageQuality.TabIndex = 5;
            this.trckbarImageQuality.Value = 5;
            this.trckbarImageQuality.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(171, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Image Quality:";
            // 
            // lblImageQuality
            // 
            this.lblImageQuality.AutoSize = true;
            this.lblImageQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageQuality.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblImageQuality.Location = new System.Drawing.Point(400, 144);
            this.lblImageQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImageQuality.Name = "lblImageQuality";
            this.lblImageQuality.Size = new System.Drawing.Size(14, 16);
            this.lblImageQuality.TabIndex = 12;
            this.lblImageQuality.Text = "5";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.GhostWhite;
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFileName.Location = new System.Drawing.Point(14, 342);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(193, 22);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileName_KeyPress);
            this.txtFileName.MouseEnter += new System.EventHandler(this.txtFileName_MouseEnter);
            this.txtFileName.MouseLeave += new System.EventHandler(this.txtFileName_MouseLeave);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(14, 320);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Filename:";
            // 
            // radBtnSingle
            // 
            this.radBtnSingle.AutoSize = true;
            this.radBtnSingle.Checked = true;
            this.radBtnSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnSingle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.radBtnSingle.Location = new System.Drawing.Point(14, 14);
            this.radBtnSingle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radBtnSingle.Name = "radBtnSingle";
            this.radBtnSingle.Size = new System.Drawing.Size(104, 20);
            this.radBtnSingle.TabIndex = 13;
            this.radBtnSingle.TabStop = true;
            this.radBtnSingle.Text = "Single Image";
            this.radBtnSingle.UseVisualStyleBackColor = true;
            this.radBtnSingle.CheckedChanged += new System.EventHandler(this.radBtnSingle_CheckedChanged);
            // 
            // radBtnMulti
            // 
            this.radBtnMulti.AutoSize = true;
            this.radBtnMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnMulti.ForeColor = System.Drawing.SystemColors.InfoText;
            this.radBtnMulti.Location = new System.Drawing.Point(135, 14);
            this.radBtnMulti.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radBtnMulti.Name = "radBtnMulti";
            this.radBtnMulti.Size = new System.Drawing.Size(119, 20);
            this.radBtnMulti.TabIndex = 14;
            this.radBtnMulti.Text = "Multiple Images";
            this.radBtnMulti.UseVisualStyleBackColor = true;
            this.radBtnMulti.CheckedChanged += new System.EventHandler(this.radBtnMulti_CheckedChanged);
            this.radBtnMulti.MouseEnter += new System.EventHandler(this.radBtnMulti_MouseEnter);
            this.radBtnMulti.MouseLeave += new System.EventHandler(this.radBtnMulti_MouseLeave);
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFileFormat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblFileFormat.Location = new System.Drawing.Point(215, 345);
            this.lblFileFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileFormat.Name = "lblFileFormat";
            this.lblFileFormat.Size = new System.Drawing.Size(29, 16);
            this.lblFileFormat.TabIndex = 15;
            this.lblFileFormat.Text = ".jpg";
            // 
            // cmboxDDSList
            // 
            this.cmboxDDSList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxDDSList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmboxDDSList.FormattingEnabled = true;
            this.cmboxDDSList.ItemHeight = 16;
            this.cmboxDDSList.Location = new System.Drawing.Point(174, 144);
            this.cmboxDDSList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmboxDDSList.Name = "cmboxDDSList";
            this.cmboxDDSList.Size = new System.Drawing.Size(288, 24);
            this.cmboxDDSList.TabIndex = 16;
            this.cmboxDDSList.Visible = false;
            // 
            // chkBoxKeepFilenames
            // 
            this.chkBoxKeepFilenames.AutoSize = true;
            this.chkBoxKeepFilenames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBoxKeepFilenames.Location = new System.Drawing.Point(18, 294);
            this.chkBoxKeepFilenames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkBoxKeepFilenames.Name = "chkBoxKeepFilenames";
            this.chkBoxKeepFilenames.Size = new System.Drawing.Size(132, 20);
            this.chkBoxKeepFilenames.TabIndex = 17;
            this.chkBoxKeepFilenames.Text = "Keep Filename(s)";
            this.chkBoxKeepFilenames.UseVisualStyleBackColor = true;
            this.chkBoxKeepFilenames.CheckedChanged += new System.EventHandler(this.chkBoxKeepFilenames_CheckedChanged);
            // 
            // chkBoxMipmaps
            // 
            this.chkBoxMipmaps.AutoSize = true;
            this.chkBoxMipmaps.Checked = true;
            this.chkBoxMipmaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxMipmaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBoxMipmaps.Location = new System.Drawing.Point(174, 174);
            this.chkBoxMipmaps.Name = "chkBoxMipmaps";
            this.chkBoxMipmaps.Size = new System.Drawing.Size(141, 20);
            this.chkBoxMipmaps.TabIndex = 18;
            this.chkBoxMipmaps.Text = "Generate Mipmaps";
            this.chkBoxMipmaps.UseVisualStyleBackColor = true;
            this.chkBoxMipmaps.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(475, 423);
            this.Controls.Add(this.chkBoxMipmaps);
            this.Controls.Add(this.chkBoxKeepFilenames);
            this.Controls.Add(this.cmboxDDSList);
            this.Controls.Add(this.lblFileFormat);
            this.Controls.Add(this.radBtnMulti);
            this.Controls.Add(this.radBtnSingle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblImageQuality);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trckbarImageQuality);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOutputDirectory);
            this.Controls.Add(this.btnOutputFile);
            this.Controls.Add(this.cmboxOutputFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnInputFile);
            this.Controls.Add(this.lblSelectImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Image Converter v0.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trckbarImageQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectImage;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmboxOutputFormat;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.Label lblOutputDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trckbarImageQuality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblImageQuality;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radBtnSingle;
        private System.Windows.Forms.RadioButton radBtnMulti;
        private System.Windows.Forms.Label lblFileFormat;
        private System.Windows.Forms.ComboBox cmboxDDSList;
        private System.Windows.Forms.CheckBox chkBoxKeepFilenames;
        private System.Windows.Forms.CheckBox chkBoxMipmaps;
    }
}

