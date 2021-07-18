
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.lblImageQuality = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBoxKeepFilenames = new System.Windows.Forms.CheckBox();
            this.chkBoxMipmaps = new System.Windows.Forms.CheckBox();
            this.lblOutputDirectory = new System.Windows.Forms.Label();
            this.radBtnFastest = new System.Windows.Forms.RadioButton();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.radBtnBalanced = new System.Windows.Forms.RadioButton();
            this.lblDDSQuality = new System.Windows.Forms.Label();
            this.lblOutputFormat = new System.Windows.Forms.Label();
            this.radBtnHighest = new System.Windows.Forms.RadioButton();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.lblSelectDirectory = new System.Windows.Forms.Label();
            this.groupBoxExportSettings = new System.Windows.Forms.GroupBox();
            this.cmboxDDSList = new MetroSet_UI.Controls.MetroSetComboBox();
            this.cmboxOutputFormat = new MetroSet_UI.Controls.MetroSetComboBox();
            this.trckbarImageQuality = new MetroSet_UI.Controls.MetroSetTrackBar();
            this.groupBoxExportProgress = new System.Windows.Forms.GroupBox();
            this.btnShowFolder = new System.Windows.Forms.Button();
            this.listErrors = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lblErrors = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.progressBar = new MetroSet_UI.Controls.MetroSetProgressBar();
            this.workerThread = new System.ComponentModel.BackgroundWorker();
            this.groupBoxExportSettings.SuspendLayout();
            this.groupBoxExportProgress.SuspendLayout();
            this.SuspendLayout();
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
            // lblImageQuality
            // 
            this.lblImageQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImageQuality.AutoSize = true;
            this.lblImageQuality.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageQuality.ForeColor = System.Drawing.SystemColors.Control;
            this.lblImageQuality.Location = new System.Drawing.Point(415, 107);
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
            this.label4.Location = new System.Drawing.Point(186, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Image Quality:";
            // 
            // chkBoxKeepFilenames
            // 
            this.chkBoxKeepFilenames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxKeepFilenames.AutoSize = true;
            this.chkBoxKeepFilenames.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBoxKeepFilenames.ForeColor = System.Drawing.SystemColors.Control;
            this.chkBoxKeepFilenames.Location = new System.Drawing.Point(7, 193);
            this.chkBoxKeepFilenames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkBoxKeepFilenames.Name = "chkBoxKeepFilenames";
            this.chkBoxKeepFilenames.Size = new System.Drawing.Size(126, 20);
            this.chkBoxKeepFilenames.TabIndex = 51;
            this.chkBoxKeepFilenames.Text = "Keep Filename(s)";
            this.chkBoxKeepFilenames.UseVisualStyleBackColor = true;
            this.chkBoxKeepFilenames.CheckedChanged += new System.EventHandler(this.chkBoxKeepFilenames_CheckedChanged);
            // 
            // chkBoxMipmaps
            // 
            this.chkBoxMipmaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxMipmaps.AutoSize = true;
            this.chkBoxMipmaps.Checked = true;
            this.chkBoxMipmaps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxMipmaps.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBoxMipmaps.ForeColor = System.Drawing.SystemColors.Control;
            this.chkBoxMipmaps.Location = new System.Drawing.Point(189, 129);
            this.chkBoxMipmaps.Name = "chkBoxMipmaps";
            this.chkBoxMipmaps.Size = new System.Drawing.Size(134, 20);
            this.chkBoxMipmaps.TabIndex = 52;
            this.chkBoxMipmaps.Text = "Generate Mipmaps";
            this.chkBoxMipmaps.UseVisualStyleBackColor = true;
            this.chkBoxMipmaps.Visible = false;
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutputDirectory.AutoEllipsis = true;
            this.lblOutputDirectory.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOutputDirectory.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOutputDirectory.Location = new System.Drawing.Point(103, 49);
            this.lblOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(398, 21);
            this.lblOutputDirectory.TabIndex = 45;
            // 
            // radBtnFastest
            // 
            this.radBtnFastest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnFastest.AutoSize = true;
            this.radBtnFastest.Checked = true;
            this.radBtnFastest.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnFastest.ForeColor = System.Drawing.SystemColors.Control;
            this.radBtnFastest.Location = new System.Drawing.Point(190, 183);
            this.radBtnFastest.Name = "radBtnFastest";
            this.radBtnFastest.Size = new System.Drawing.Size(68, 20);
            this.radBtnFastest.TabIndex = 53;
            this.radBtnFastest.TabStop = true;
            this.radBtnFastest.Text = "Fastest";
            this.radBtnFastest.UseVisualStyleBackColor = true;
            this.radBtnFastest.Visible = false;
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOutputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnOutputFile.FlatAppearance.BorderSize = 0;
            this.btnOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutputFile.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOutputFile.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOutputFile.Location = new System.Drawing.Point(7, 43);
            this.btnOutputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(88, 27);
            this.btnOutputFile.TabIndex = 44;
            this.btnOutputFile.Text = "Choose...";
            this.btnOutputFile.UseVisualStyleBackColor = false;
            this.btnOutputFile.Click += new System.EventHandler(this.btnOutputFile_Click);
            // 
            // radBtnBalanced
            // 
            this.radBtnBalanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnBalanced.AutoSize = true;
            this.radBtnBalanced.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnBalanced.ForeColor = System.Drawing.SystemColors.Control;
            this.radBtnBalanced.Location = new System.Drawing.Point(260, 183);
            this.radBtnBalanced.Name = "radBtnBalanced";
            this.radBtnBalanced.Size = new System.Drawing.Size(78, 20);
            this.radBtnBalanced.TabIndex = 54;
            this.radBtnBalanced.Text = "Balanced";
            this.radBtnBalanced.UseVisualStyleBackColor = true;
            this.radBtnBalanced.Visible = false;
            // 
            // lblDDSQuality
            // 
            this.lblDDSQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDDSQuality.AutoSize = true;
            this.lblDDSQuality.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDDSQuality.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDDSQuality.Location = new System.Drawing.Point(186, 166);
            this.lblDDSQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDDSQuality.Name = "lblDDSQuality";
            this.lblDDSQuality.Size = new System.Drawing.Size(129, 16);
            this.lblDDSQuality.TabIndex = 55;
            this.lblDDSQuality.Text = "Compression Quality:";
            this.lblDDSQuality.Visible = false;
            // 
            // lblOutputFormat
            // 
            this.lblOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputFormat.AutoSize = true;
            this.lblOutputFormat.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOutputFormat.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOutputFormat.Location = new System.Drawing.Point(6, 83);
            this.lblOutputFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputFormat.Name = "lblOutputFormat";
            this.lblOutputFormat.Size = new System.Drawing.Size(92, 16);
            this.lblOutputFormat.TabIndex = 41;
            this.lblOutputFormat.Text = "Output Format:";
            // 
            // radBtnHighest
            // 
            this.radBtnHighest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnHighest.AutoSize = true;
            this.radBtnHighest.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnHighest.ForeColor = System.Drawing.SystemColors.Control;
            this.radBtnHighest.Location = new System.Drawing.Point(343, 183);
            this.radBtnHighest.Name = "radBtnHighest";
            this.radBtnHighest.Size = new System.Drawing.Size(69, 20);
            this.radBtnHighest.TabIndex = 56;
            this.radBtnHighest.Text = "Highest";
            this.radBtnHighest.UseVisualStyleBackColor = true;
            this.radBtnHighest.Visible = false;
            // 
            // btnExportAll
            // 
            this.btnExportAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnExportAll.Enabled = false;
            this.btnExportAll.FlatAppearance.BorderSize = 0;
            this.btnExportAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAll.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExportAll.ForeColor = System.Drawing.SystemColors.Window;
            this.btnExportAll.Location = new System.Drawing.Point(382, 233);
            this.btnExportAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(119, 27);
            this.btnExportAll.TabIndex = 40;
            this.btnExportAll.Text = "Export All";
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // lblSelectDirectory
            // 
            this.lblSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectDirectory.AutoSize = true;
            this.lblSelectDirectory.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelectDirectory.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSelectDirectory.Location = new System.Drawing.Point(7, 25);
            this.lblSelectDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectDirectory.Name = "lblSelectDirectory";
            this.lblSelectDirectory.Size = new System.Drawing.Size(142, 16);
            this.lblSelectDirectory.TabIndex = 46;
            this.lblSelectDirectory.Text = "Select Output Directory:";
            // 
            // groupBoxExportSettings
            // 
            this.groupBoxExportSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxExportSettings.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxExportSettings.Controls.Add(this.cmboxDDSList);
            this.groupBoxExportSettings.Controls.Add(this.cmboxOutputFormat);
            this.groupBoxExportSettings.Controls.Add(this.trckbarImageQuality);
            this.groupBoxExportSettings.Controls.Add(this.lblSelectDirectory);
            this.groupBoxExportSettings.Controls.Add(this.btnExportAll);
            this.groupBoxExportSettings.Controls.Add(this.radBtnHighest);
            this.groupBoxExportSettings.Controls.Add(this.lblOutputFormat);
            this.groupBoxExportSettings.Controls.Add(this.lblDDSQuality);
            this.groupBoxExportSettings.Controls.Add(this.radBtnBalanced);
            this.groupBoxExportSettings.Controls.Add(this.btnOutputFile);
            this.groupBoxExportSettings.Controls.Add(this.radBtnFastest);
            this.groupBoxExportSettings.Controls.Add(this.lblOutputDirectory);
            this.groupBoxExportSettings.Controls.Add(this.chkBoxMipmaps);
            this.groupBoxExportSettings.Controls.Add(this.chkBoxKeepFilenames);
            this.groupBoxExportSettings.Controls.Add(this.label4);
            this.groupBoxExportSettings.Controls.Add(this.lblImageQuality);
            this.groupBoxExportSettings.Controls.Add(this.lblFileFormat);
            this.groupBoxExportSettings.Controls.Add(this.txtFileName);
            this.groupBoxExportSettings.Controls.Add(this.label5);
            this.groupBoxExportSettings.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxExportSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBoxExportSettings.Location = new System.Drawing.Point(84, 8);
            this.groupBoxExportSettings.Name = "groupBoxExportSettings";
            this.groupBoxExportSettings.Size = new System.Drawing.Size(508, 268);
            this.groupBoxExportSettings.TabIndex = 57;
            this.groupBoxExportSettings.TabStop = false;
            this.groupBoxExportSettings.Text = "Export Settings";
            // 
            // cmboxDDSList
            // 
            this.cmboxDDSList.AllowDrop = true;
            this.cmboxDDSList.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmboxDDSList.BackColor = System.Drawing.Color.Transparent;
            this.cmboxDDSList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cmboxDDSList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmboxDDSList.CausesValidation = false;
            this.cmboxDDSList.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmboxDDSList.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cmboxDDSList.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cmboxDDSList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmboxDDSList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxDDSList.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmboxDDSList.FormattingEnabled = true;
            this.cmboxDDSList.IsDerivedStyle = true;
            this.cmboxDDSList.ItemHeight = 20;
            this.cmboxDDSList.Location = new System.Drawing.Point(189, 102);
            this.cmboxDDSList.Name = "cmboxDDSList";
            this.cmboxDDSList.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmboxDDSList.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmboxDDSList.Size = new System.Drawing.Size(311, 26);
            this.cmboxDDSList.Style = MetroSet_UI.Enums.Style.Light;
            this.cmboxDDSList.StyleManager = null;
            this.cmboxDDSList.TabIndex = 59;
            this.cmboxDDSList.ThemeAuthor = "Narwin";
            this.cmboxDDSList.ThemeName = "MetroLite";
            // 
            // cmboxOutputFormat
            // 
            this.cmboxOutputFormat.AllowDrop = true;
            this.cmboxOutputFormat.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmboxOutputFormat.BackColor = System.Drawing.Color.Transparent;
            this.cmboxOutputFormat.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cmboxOutputFormat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cmboxOutputFormat.CausesValidation = false;
            this.cmboxOutputFormat.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmboxOutputFormat.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cmboxOutputFormat.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cmboxOutputFormat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmboxOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxOutputFormat.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmboxOutputFormat.FormattingEnabled = true;
            this.cmboxOutputFormat.IsDerivedStyle = true;
            this.cmboxOutputFormat.ItemHeight = 20;
            this.cmboxOutputFormat.Location = new System.Drawing.Point(6, 102);
            this.cmboxOutputFormat.Name = "cmboxOutputFormat";
            this.cmboxOutputFormat.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cmboxOutputFormat.SelectedItemForeColor = System.Drawing.Color.White;
            this.cmboxOutputFormat.Size = new System.Drawing.Size(100, 26);
            this.cmboxOutputFormat.Style = MetroSet_UI.Enums.Style.Light;
            this.cmboxOutputFormat.StyleManager = null;
            this.cmboxOutputFormat.TabIndex = 58;
            this.cmboxOutputFormat.ThemeAuthor = "Narwin";
            this.cmboxOutputFormat.ThemeName = "MetroLite";
            this.cmboxOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cmboxOutputFormat_SelectedIndexChanged);
            // 
            // trckbarImageQuality
            // 
            this.trckbarImageQuality.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.trckbarImageQuality.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trckbarImageQuality.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.trckbarImageQuality.DisabledBorderColor = System.Drawing.Color.Empty;
            this.trckbarImageQuality.DisabledHandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.trckbarImageQuality.DisabledValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.trckbarImageQuality.HandlerColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.trckbarImageQuality.IsDerivedStyle = true;
            this.trckbarImageQuality.Location = new System.Drawing.Point(189, 107);
            this.trckbarImageQuality.Maximum = 10;
            this.trckbarImageQuality.Minimum = 0;
            this.trckbarImageQuality.Name = "trckbarImageQuality";
            this.trckbarImageQuality.Size = new System.Drawing.Size(211, 16);
            this.trckbarImageQuality.Style = MetroSet_UI.Enums.Style.Light;
            this.trckbarImageQuality.StyleManager = null;
            this.trckbarImageQuality.TabIndex = 57;
            this.trckbarImageQuality.Text = "metroSetTrackBar1";
            this.trckbarImageQuality.ThemeAuthor = "Narwin";
            this.trckbarImageQuality.ThemeName = "MetroLite";
            this.trckbarImageQuality.Value = 5;
            this.trckbarImageQuality.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.trckbarImageQuality.Scroll += new MetroSet_UI.Controls.MetroSetTrackBar.ScrollEventHandler(this.trckbarImageQuality_Scroll);
            // 
            // groupBoxExportProgress
            // 
            this.groupBoxExportProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxExportProgress.Controls.Add(this.btnShowFolder);
            this.groupBoxExportProgress.Controls.Add(this.listErrors);
            this.groupBoxExportProgress.Controls.Add(this.lblErrors);
            this.groupBoxExportProgress.Controls.Add(this.lblProgress);
            this.groupBoxExportProgress.Controls.Add(this.lblPercent);
            this.groupBoxExportProgress.Controls.Add(this.progressBar);
            this.groupBoxExportProgress.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxExportProgress.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBoxExportProgress.Location = new System.Drawing.Point(84, 283);
            this.groupBoxExportProgress.Name = "groupBoxExportProgress";
            this.groupBoxExportProgress.Size = new System.Drawing.Size(508, 279);
            this.groupBoxExportProgress.TabIndex = 58;
            this.groupBoxExportProgress.TabStop = false;
            this.groupBoxExportProgress.Text = "Export Progress";
            // 
            // btnShowFolder
            // 
            this.btnShowFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnShowFolder.Enabled = false;
            this.btnShowFolder.FlatAppearance.BorderSize = 0;
            this.btnShowFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowFolder.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowFolder.ForeColor = System.Drawing.Color.White;
            this.btnShowFolder.Location = new System.Drawing.Point(387, 62);
            this.btnShowFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnShowFolder.Name = "btnShowFolder";
            this.btnShowFolder.Size = new System.Drawing.Size(113, 27);
            this.btnShowFolder.TabIndex = 18;
            this.btnShowFolder.Text = "Show Folder";
            this.btnShowFolder.UseVisualStyleBackColor = false;
            // 
            // listErrors
            // 
            this.listErrors.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listErrors.BackColor = System.Drawing.Color.Silver;
            this.listErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listErrors.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listErrors.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listErrors.HideSelection = false;
            this.listErrors.Location = new System.Drawing.Point(7, 95);
            this.listErrors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listErrors.Name = "listErrors";
            this.listErrors.Size = new System.Drawing.Size(494, 170);
            this.listErrors.TabIndex = 17;
            this.listErrors.UseCompatibleStateImageBehavior = false;
            this.listErrors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Error";
            this.columnHeader2.Width = 200;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblErrors.Location = new System.Drawing.Point(7, 76);
            this.lblErrors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(60, 16);
            this.lblErrors.TabIndex = 16;
            this.lblErrors.Text = "Errors: 0";
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProgress.Location = new System.Drawing.Point(304, 41);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(196, 27);
            this.lblProgress.TabIndex = 15;
            this.lblProgress.Text = "0/0";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPercent.Location = new System.Drawing.Point(6, 41);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(42, 16);
            this.lblPercent.TabIndex = 14;
            this.lblPercent.Text = "Ready";
            // 
            // progressBar
            // 
            this.progressBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.progressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.progressBar.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.progressBar.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.progressBar.DisabledProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.progressBar.IsDerivedStyle = true;
            this.progressBar.Location = new System.Drawing.Point(6, 22);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            this.progressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.progressBar.Size = new System.Drawing.Size(495, 15);
            this.progressBar.Style = MetroSet_UI.Enums.Style.Light;
            this.progressBar.StyleManager = null;
            this.progressBar.TabIndex = 0;
            this.progressBar.Text = "metroSetProgressBar1";
            this.progressBar.ThemeAuthor = "Narwin";
            this.progressBar.ThemeName = "MetroLite";
            this.progressBar.Value = 0;
            // 
            // workerThread
            // 
            this.workerThread.WorkerReportsProgress = true;
            this.workerThread.WorkerSupportsCancellation = true;
            this.workerThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerThread_DoWork);
            this.workerThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerThread_ProgressChanged);
            this.workerThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerThread_RunWorkerCompleted);
            // 
            // ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.Controls.Add(this.groupBoxExportProgress);
            this.Controls.Add(this.groupBoxExportSettings);
            this.Name = "ExportControl";
            this.Size = new System.Drawing.Size(602, 576);
            this.groupBoxExportSettings.ResumeLayout(false);
            this.groupBoxExportSettings.PerformLayout();
            this.groupBoxExportProgress.ResumeLayout(false);
            this.groupBoxExportProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radBtnHighest;
        private System.Windows.Forms.Label lblDDSQuality;
        private System.Windows.Forms.RadioButton radBtnBalanced;
        private System.Windows.Forms.RadioButton radBtnFastest;
        private System.Windows.Forms.CheckBox chkBoxMipmaps;
        private System.Windows.Forms.CheckBox chkBoxKeepFilenames;
        private System.Windows.Forms.Label lblFileFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblImageQuality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSelectDirectory;
        private System.Windows.Forms.Label lblOutputDirectory;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.Label lblOutputFormat;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.GroupBox groupBoxExportSettings;
        private System.Windows.Forms.ListView listView1;
        private MetroSet_UI.Controls.MetroSetTrackBar trckbarImageQuality;
        private System.Windows.Forms.GroupBox groupBoxExportProgress;
        private MetroSet_UI.Controls.MetroSetComboBox cmboxOutputFormat;
        private MetroSet_UI.Controls.MetroSetComboBox cmboxDDSList;
        private MetroSet_UI.Controls.MetroSetProgressBar progressBar;
        private System.Windows.Forms.Button btnShowFolder;
        private System.Windows.Forms.ListView listErrors;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.ComponentModel.BackgroundWorker workerThread;
    }
}
