
namespace Image_Converter.Forms
{
    partial class ExportControl
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
            this.radBtnHighest = new System.Windows.Forms.RadioButton();
            this.lblDDSQuality = new System.Windows.Forms.Label();
            this.radBtnBalanced = new System.Windows.Forms.RadioButton();
            this.radBtnFastest = new System.Windows.Forms.RadioButton();
            this.chkBoxMipmaps = new System.Windows.Forms.CheckBox();
            this.chkBoxKeepFilenames = new System.Windows.Forms.CheckBox();
            this.cmboxDDSList = new System.Windows.Forms.ComboBox();
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblImageQuality = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trckbarImageQuality = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOutputDirectory = new System.Windows.Forms.Label();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.cmboxOutputFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBoxExportSettings = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarImageQuality)).BeginInit();
            this.groupBoxExportSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // radBtnHighest
            // 
            this.radBtnHighest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnHighest.AutoSize = true;
            this.radBtnHighest.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnHighest.Location = new System.Drawing.Point(304, 183);
            this.radBtnHighest.Name = "radBtnHighest";
            this.radBtnHighest.Size = new System.Drawing.Size(69, 20);
            this.radBtnHighest.TabIndex = 56;
            this.radBtnHighest.Text = "Highest";
            this.radBtnHighest.UseVisualStyleBackColor = true;
            this.radBtnHighest.Visible = false;
            // 
            // lblDDSQuality
            // 
            this.lblDDSQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDDSQuality.AutoSize = true;
            this.lblDDSQuality.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDDSQuality.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDDSQuality.Location = new System.Drawing.Point(147, 166);
            this.lblDDSQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDDSQuality.Name = "lblDDSQuality";
            this.lblDDSQuality.Size = new System.Drawing.Size(129, 16);
            this.lblDDSQuality.TabIndex = 55;
            this.lblDDSQuality.Text = "Compression Quality:";
            this.lblDDSQuality.Visible = false;
            // 
            // radBtnBalanced
            // 
            this.radBtnBalanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnBalanced.AutoSize = true;
            this.radBtnBalanced.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnBalanced.Location = new System.Drawing.Point(221, 183);
            this.radBtnBalanced.Name = "radBtnBalanced";
            this.radBtnBalanced.Size = new System.Drawing.Size(78, 20);
            this.radBtnBalanced.TabIndex = 54;
            this.radBtnBalanced.Text = "Balanced";
            this.radBtnBalanced.UseVisualStyleBackColor = true;
            this.radBtnBalanced.Visible = false;
            // 
            // radBtnFastest
            // 
            this.radBtnFastest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnFastest.AutoSize = true;
            this.radBtnFastest.Checked = true;
            this.radBtnFastest.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnFastest.Location = new System.Drawing.Point(151, 183);
            this.radBtnFastest.Name = "radBtnFastest";
            this.radBtnFastest.Size = new System.Drawing.Size(68, 20);
            this.radBtnFastest.TabIndex = 53;
            this.radBtnFastest.TabStop = true;
            this.radBtnFastest.Text = "Fastest";
            this.radBtnFastest.UseVisualStyleBackColor = true;
            this.radBtnFastest.Visible = false;
            // 
            // chkBoxMipmaps
            // 
            this.chkBoxMipmaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxMipmaps.AutoSize = true;
            this.chkBoxMipmaps.Checked = true;
            this.chkBoxMipmaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxMipmaps.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBoxMipmaps.Location = new System.Drawing.Point(150, 129);
            this.chkBoxMipmaps.Name = "chkBoxMipmaps";
            this.chkBoxMipmaps.Size = new System.Drawing.Size(134, 20);
            this.chkBoxMipmaps.TabIndex = 52;
            this.chkBoxMipmaps.Text = "Generate Mipmaps";
            this.chkBoxMipmaps.UseVisualStyleBackColor = true;
            this.chkBoxMipmaps.Visible = false;
            // 
            // chkBoxKeepFilenames
            // 
            this.chkBoxKeepFilenames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxKeepFilenames.AutoSize = true;
            this.chkBoxKeepFilenames.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBoxKeepFilenames.Location = new System.Drawing.Point(7, 193);
            this.chkBoxKeepFilenames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkBoxKeepFilenames.Name = "chkBoxKeepFilenames";
            this.chkBoxKeepFilenames.Size = new System.Drawing.Size(126, 20);
            this.chkBoxKeepFilenames.TabIndex = 51;
            this.chkBoxKeepFilenames.Text = "Keep Filename(s)";
            this.chkBoxKeepFilenames.UseVisualStyleBackColor = true;
            // 
            // cmboxDDSList
            // 
            this.cmboxDDSList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmboxDDSList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxDDSList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmboxDDSList.FormattingEnabled = true;
            this.cmboxDDSList.ItemHeight = 15;
            this.cmboxDDSList.Location = new System.Drawing.Point(150, 101);
            this.cmboxDDSList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmboxDDSList.Name = "cmboxDDSList";
            this.cmboxDDSList.Size = new System.Drawing.Size(288, 23);
            this.cmboxDDSList.TabIndex = 50;
            this.cmboxDDSList.Visible = false;
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFileFormat.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFileFormat.Location = new System.Drawing.Point(263, 241);
            this.lblFileFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileFormat.Name = "lblFileFormat";
            this.lblFileFormat.Size = new System.Drawing.Size(27, 16);
            this.lblFileFormat.TabIndex = 49;
            this.lblFileFormat.Text = ".jpg";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(7, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "Filename:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileName.BackColor = System.Drawing.Color.GhostWhite;
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFileName.Location = new System.Drawing.Point(7, 238);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(248, 22);
            this.txtFileName.TabIndex = 38;
            // 
            // lblImageQuality
            // 
            this.lblImageQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImageQuality.AutoSize = true;
            this.lblImageQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageQuality.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblImageQuality.Location = new System.Drawing.Point(376, 101);
            this.lblImageQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImageQuality.Name = "lblImageQuality";
            this.lblImageQuality.Size = new System.Drawing.Size(14, 16);
            this.lblImageQuality.TabIndex = 48;
            this.lblImageQuality.Text = "5";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(147, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Image Quality:";
            // 
            // trckbarImageQuality
            // 
            this.trckbarImageQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trckbarImageQuality.Location = new System.Drawing.Point(147, 101);
            this.trckbarImageQuality.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trckbarImageQuality.Minimum = 1;
            this.trckbarImageQuality.Name = "trckbarImageQuality";
            this.trckbarImageQuality.Size = new System.Drawing.Size(222, 45);
            this.trckbarImageQuality.SmallChange = 10;
            this.trckbarImageQuality.TabIndex = 42;
            this.trckbarImageQuality.Value = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "Select Output Directory:";
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutputDirectory.AutoEllipsis = true;
            this.lblOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOutputDirectory.ForeColor = System.Drawing.Color.Black;
            this.lblOutputDirectory.Location = new System.Drawing.Point(103, 49);
            this.lblOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(399, 21);
            this.lblOutputDirectory.TabIndex = 45;
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOutputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnOutputFile.FlatAppearance.BorderSize = 0;
            this.btnOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOutputFile.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOutputFile.Location = new System.Drawing.Point(7, 43);
            this.btnOutputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(88, 27);
            this.btnOutputFile.TabIndex = 44;
            this.btnOutputFile.Text = "Choose...";
            this.btnOutputFile.UseVisualStyleBackColor = false;
            // 
            // cmboxOutputFormat
            // 
            this.cmboxOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmboxOutputFormat.BackColor = System.Drawing.Color.White;
            this.cmboxOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxOutputFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmboxOutputFormat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cmboxOutputFormat.FormattingEnabled = true;
            this.cmboxOutputFormat.Location = new System.Drawing.Point(6, 101);
            this.cmboxOutputFormat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmboxOutputFormat.Name = "cmboxOutputFormat";
            this.cmboxOutputFormat.Size = new System.Drawing.Size(101, 23);
            this.cmboxOutputFormat.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "Output Format:";
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnConvert.Enabled = false;
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConvert.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConvert.Location = new System.Drawing.Point(319, 233);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(119, 27);
            this.btnConvert.TabIndex = 40;
            this.btnConvert.Text = "Convert All";
            this.btnConvert.UseVisualStyleBackColor = false;
            // 
            // groupBoxExportSettings
            // 
            this.groupBoxExportSettings.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxExportSettings.Controls.Add(this.label3);
            this.groupBoxExportSettings.Controls.Add(this.btnConvert);
            this.groupBoxExportSettings.Controls.Add(this.radBtnHighest);
            this.groupBoxExportSettings.Controls.Add(this.label2);
            this.groupBoxExportSettings.Controls.Add(this.lblDDSQuality);
            this.groupBoxExportSettings.Controls.Add(this.cmboxOutputFormat);
            this.groupBoxExportSettings.Controls.Add(this.radBtnBalanced);
            this.groupBoxExportSettings.Controls.Add(this.btnOutputFile);
            this.groupBoxExportSettings.Controls.Add(this.radBtnFastest);
            this.groupBoxExportSettings.Controls.Add(this.lblOutputDirectory);
            this.groupBoxExportSettings.Controls.Add(this.chkBoxMipmaps);
            this.groupBoxExportSettings.Controls.Add(this.trckbarImageQuality);
            this.groupBoxExportSettings.Controls.Add(this.chkBoxKeepFilenames);
            this.groupBoxExportSettings.Controls.Add(this.label4);
            this.groupBoxExportSettings.Controls.Add(this.cmboxDDSList);
            this.groupBoxExportSettings.Controls.Add(this.lblImageQuality);
            this.groupBoxExportSettings.Controls.Add(this.lblFileFormat);
            this.groupBoxExportSettings.Controls.Add(this.txtFileName);
            this.groupBoxExportSettings.Controls.Add(this.label5);
            this.groupBoxExportSettings.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxExportSettings.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxExportSettings.Location = new System.Drawing.Point(3, 230);
            this.groupBoxExportSettings.Name = "groupBoxExportSettings";
            this.groupBoxExportSettings.Size = new System.Drawing.Size(445, 268);
            this.groupBoxExportSettings.TabIndex = 57;
            this.groupBoxExportSettings.TabStop = false;
            this.groupBoxExportSettings.Text = "Export Settings";
            // 
            // ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Controls.Add(this.groupBoxExportSettings);
            this.Name = "ExportControl";
            this.Size = new System.Drawing.Size(786, 501);
            ((System.ComponentModel.ISupportInitialize)(this.trckbarImageQuality)).EndInit();
            this.groupBoxExportSettings.ResumeLayout(false);
            this.groupBoxExportSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radBtnHighest;
        private System.Windows.Forms.Label lblDDSQuality;
        private System.Windows.Forms.RadioButton radBtnBalanced;
        private System.Windows.Forms.RadioButton radBtnFastest;
        private System.Windows.Forms.CheckBox chkBoxMipmaps;
        private System.Windows.Forms.CheckBox chkBoxKeepFilenames;
        private System.Windows.Forms.ComboBox cmboxDDSList;
        private System.Windows.Forms.Label lblFileFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblImageQuality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trckbarImageQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOutputDirectory;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.ComboBox cmboxOutputFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.GroupBox groupBoxExportSettings;
    }
}
