namespace Image_Converter.Forms
{
    partial class ImportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportControl));
            this.groupBoxImport = new System.Windows.Forms.GroupBox();
            this.panelImportContent = new System.Windows.Forms.Panel();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInputFolder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblImportOr = new System.Windows.Forms.Label();
            this.lblImportOr2 = new System.Windows.Forms.Label();
            this.checkBoxSubFolders = new System.Windows.Forms.CheckBox();
            this.groupBoxImport.SuspendLayout();
            this.panelImportContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxImport
            // 
            this.groupBoxImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImport.Controls.Add(this.panelImportContent);
            this.groupBoxImport.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxImport.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxImport.Location = new System.Drawing.Point(3, 3);
            this.groupBoxImport.Name = "groupBoxImport";
            this.groupBoxImport.Size = new System.Drawing.Size(339, 81);
            this.groupBoxImport.TabIndex = 27;
            this.groupBoxImport.TabStop = false;
            this.groupBoxImport.Text = "Import";
            // 
            // panelImportContent
            // 
            this.panelImportContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelImportContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelImportContent.Controls.Add(this.btnInputFile);
            this.panelImportContent.Controls.Add(this.label1);
            this.panelImportContent.Controls.Add(this.btnInputFolder);
            this.panelImportContent.Controls.Add(this.pictureBox1);
            this.panelImportContent.Controls.Add(this.lblImportOr);
            this.panelImportContent.Controls.Add(this.lblImportOr2);
            this.panelImportContent.Location = new System.Drawing.Point(6, 17);
            this.panelImportContent.Name = "panelImportContent";
            this.panelImportContent.Size = new System.Drawing.Size(326, 59);
            this.panelImportContent.TabIndex = 31;
            // 
            // btnInputFile
            // 
            this.btnInputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnInputFile.FlatAppearance.BorderSize = 0;
            this.btnInputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputFile.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInputFile.ForeColor = System.Drawing.Color.White;
            this.btnInputFile.Location = new System.Drawing.Point(5, 15);
            this.btnInputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(88, 27);
            this.btnInputFile.TabIndex = 1;
            this.btnInputFile.Text = "Choose File";
            this.btnInputFile.UseVisualStyleBackColor = false;
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(260, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Drop Files";
            // 
            // btnInputFolder
            // 
            this.btnInputFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnInputFolder.FlatAppearance.BorderSize = 0;
            this.btnInputFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputFolder.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInputFolder.ForeColor = System.Drawing.Color.White;
            this.btnInputFolder.Location = new System.Drawing.Point(127, 15);
            this.btnInputFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInputFolder.Name = "btnInputFolder";
            this.btnInputFolder.Size = new System.Drawing.Size(100, 27);
            this.btnInputFolder.TabIndex = 2;
            this.btnInputFolder.Text = "Choose Folder";
            this.btnInputFolder.UseVisualStyleBackColor = false;
            this.btnInputFolder.Click += new System.EventHandler(this.btnInputFolder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(260, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // lblImportOr
            // 
            this.lblImportOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImportOr.AutoSize = true;
            this.lblImportOr.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImportOr.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblImportOr.Location = new System.Drawing.Point(101, 20);
            this.lblImportOr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImportOr.Name = "lblImportOr";
            this.lblImportOr.Size = new System.Drawing.Size(20, 16);
            this.lblImportOr.TabIndex = 28;
            this.lblImportOr.Text = "or";
            // 
            // lblImportOr2
            // 
            this.lblImportOr2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImportOr2.AutoSize = true;
            this.lblImportOr2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImportOr2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblImportOr2.Location = new System.Drawing.Point(235, 20);
            this.lblImportOr2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImportOr2.Name = "lblImportOr2";
            this.lblImportOr2.Size = new System.Drawing.Size(20, 16);
            this.lblImportOr2.TabIndex = 29;
            this.lblImportOr2.Text = "or";
            // 
            // checkBoxSubFolders
            // 
            this.checkBoxSubFolders.AutoSize = true;
            this.checkBoxSubFolders.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxSubFolders.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxSubFolders.Location = new System.Drawing.Point(3, 88);
            this.checkBoxSubFolders.Name = "checkBoxSubFolders";
            this.checkBoxSubFolders.Size = new System.Drawing.Size(135, 20);
            this.checkBoxSubFolders.TabIndex = 33;
            this.checkBoxSubFolders.Text = "Include Subfolders";
            this.checkBoxSubFolders.UseVisualStyleBackColor = true;
            // 
            // ImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.checkBoxSubFolders);
            this.Controls.Add(this.groupBoxImport);
            this.Name = "ImportControl";
            this.Size = new System.Drawing.Size(351, 111);
            this.groupBoxImport.ResumeLayout(false);
            this.panelImportContent.ResumeLayout(false);
            this.panelImportContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxImport;
        private System.Windows.Forms.Panel panelImportContent;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInputFolder;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblImportOr;
        private System.Windows.Forms.Label lblImportOr2;
        private System.Windows.Forms.CheckBox checkBoxSubFolders;
    }
}
