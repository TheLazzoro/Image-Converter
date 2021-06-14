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
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.listFileEntries = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.previewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lblResolution = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarImageQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewSplitContainer)).BeginInit();
            this.previewSplitContainer.Panel1.SuspendLayout();
            this.previewSplitContainer.Panel2.SuspendLayout();
            this.previewSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectImage
            // 
            this.lblSelectImage.AutoSize = true;
            this.lblSelectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelectImage.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblSelectImage.Location = new System.Drawing.Point(14, 47);
            this.lblSelectImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectImage.Name = "lblSelectImage";
            this.lblSelectImage.Size = new System.Drawing.Size(105, 15);
            this.lblSelectImage.TabIndex = 0;
            this.lblSelectImage.Text = "Select Image File:";
            // 
            // btnInputFile
            // 
            this.btnInputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnInputFile.FlatAppearance.BorderSize = 0;
            this.btnInputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInputFile.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInputFile.Location = new System.Drawing.Point(14, 65);
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
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFilePath.ForeColor = System.Drawing.Color.Black;
            this.lblFilePath.Location = new System.Drawing.Point(110, 71);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(278, 21);
            this.lblFilePath.TabIndex = 2;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnConvert.Enabled = false;
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConvert.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConvert.Location = new System.Drawing.Point(415, 498);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(88, 27);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(14, 398);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output Format:";
            // 
            // cmboxOutputFormat
            // 
            this.cmboxOutputFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmboxOutputFormat.BackColor = System.Drawing.Color.White;
            this.cmboxOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxOutputFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmboxOutputFormat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cmboxOutputFormat.FormattingEnabled = true;
            this.cmboxOutputFormat.Location = new System.Drawing.Point(14, 416);
            this.cmboxOutputFormat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmboxOutputFormat.Name = "cmboxOutputFormat";
            this.cmboxOutputFormat.Size = new System.Drawing.Size(101, 23);
            this.cmboxOutputFormat.TabIndex = 6;
            this.cmboxOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cmboxOutputFormat_SelectedIndexChanged);
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOutputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnOutputFile.FlatAppearance.BorderSize = 0;
            this.btnOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOutputFile.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOutputFile.Location = new System.Drawing.Point(14, 359);
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
            this.lblOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOutputDirectory.AutoEllipsis = true;
            this.lblOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOutputDirectory.ForeColor = System.Drawing.Color.Black;
            this.lblOutputDirectory.Location = new System.Drawing.Point(110, 365);
            this.lblOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(278, 21);
            this.lblOutputDirectory.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(14, 341);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Output Directory:";
            // 
            // trckbarImageQuality
            // 
            this.trckbarImageQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trckbarImageQuality.Location = new System.Drawing.Point(212, 416);
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
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(212, 398);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Image Quality:";
            // 
            // lblImageQuality
            // 
            this.lblImageQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImageQuality.AutoSize = true;
            this.lblImageQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageQuality.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblImageQuality.Location = new System.Drawing.Point(441, 416);
            this.lblImageQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImageQuality.Name = "lblImageQuality";
            this.lblImageQuality.Size = new System.Drawing.Size(14, 16);
            this.lblImageQuality.TabIndex = 12;
            this.lblImageQuality.Text = "5";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileName.BackColor = System.Drawing.Color.GhostWhite;
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFileName.Location = new System.Drawing.Point(14, 503);
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
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(14, 481);
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
            this.radBtnSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnSingle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.radBtnSingle.Location = new System.Drawing.Point(14, 14);
            this.radBtnSingle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radBtnSingle.Name = "radBtnSingle";
            this.radBtnSingle.Size = new System.Drawing.Size(98, 19);
            this.radBtnSingle.TabIndex = 13;
            this.radBtnSingle.TabStop = true;
            this.radBtnSingle.Text = "Single Image";
            this.radBtnSingle.UseVisualStyleBackColor = true;
            this.radBtnSingle.CheckedChanged += new System.EventHandler(this.radBtnSingle_CheckedChanged);
            // 
            // radBtnMulti
            // 
            this.radBtnMulti.AutoSize = true;
            this.radBtnMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnMulti.ForeColor = System.Drawing.SystemColors.InfoText;
            this.radBtnMulti.Location = new System.Drawing.Point(135, 14);
            this.radBtnMulti.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radBtnMulti.Name = "radBtnMulti";
            this.radBtnMulti.Size = new System.Drawing.Size(113, 19);
            this.radBtnMulti.TabIndex = 14;
            this.radBtnMulti.Text = "Multiple Images";
            this.radBtnMulti.UseVisualStyleBackColor = true;
            this.radBtnMulti.CheckedChanged += new System.EventHandler(this.radBtnMulti_CheckedChanged);
            this.radBtnMulti.MouseEnter += new System.EventHandler(this.radBtnMulti_MouseEnter);
            this.radBtnMulti.MouseLeave += new System.EventHandler(this.radBtnMulti_MouseLeave);
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFileFormat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblFileFormat.Location = new System.Drawing.Point(215, 506);
            this.lblFileFormat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileFormat.Name = "lblFileFormat";
            this.lblFileFormat.Size = new System.Drawing.Size(27, 15);
            this.lblFileFormat.TabIndex = 15;
            this.lblFileFormat.Text = ".jpg";
            // 
            // cmboxDDSList
            // 
            this.cmboxDDSList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmboxDDSList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboxDDSList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmboxDDSList.FormattingEnabled = true;
            this.cmboxDDSList.ItemHeight = 15;
            this.cmboxDDSList.Location = new System.Drawing.Point(215, 416);
            this.cmboxDDSList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmboxDDSList.Name = "cmboxDDSList";
            this.cmboxDDSList.Size = new System.Drawing.Size(288, 23);
            this.cmboxDDSList.TabIndex = 16;
            this.cmboxDDSList.Visible = false;
            // 
            // chkBoxKeepFilenames
            // 
            this.chkBoxKeepFilenames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxKeepFilenames.AutoSize = true;
            this.chkBoxKeepFilenames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBoxKeepFilenames.Location = new System.Drawing.Point(14, 459);
            this.chkBoxKeepFilenames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkBoxKeepFilenames.Name = "chkBoxKeepFilenames";
            this.chkBoxKeepFilenames.Size = new System.Drawing.Size(124, 19);
            this.chkBoxKeepFilenames.TabIndex = 17;
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
            this.chkBoxMipmaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkBoxMipmaps.Location = new System.Drawing.Point(215, 446);
            this.chkBoxMipmaps.Name = "chkBoxMipmaps";
            this.chkBoxMipmaps.Size = new System.Drawing.Size(132, 19);
            this.chkBoxMipmaps.TabIndex = 18;
            this.chkBoxMipmaps.Text = "Generate Mipmaps";
            this.chkBoxMipmaps.UseVisualStyleBackColor = true;
            this.chkBoxMipmaps.Visible = false;
            // 
            // imagePreview
            // 
            this.imagePreview.BackColor = System.Drawing.SystemColors.ControlLight;
            this.imagePreview.Location = new System.Drawing.Point(0, 0);
            this.imagePreview.Name = "imagePreview";
            this.imagePreview.Size = new System.Drawing.Size(322, 174);
            this.imagePreview.TabIndex = 19;
            this.imagePreview.TabStop = false;
            // 
            // listFileEntries
            // 
            this.listFileEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFileEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listFileEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listFileEntries.HideSelection = false;
            this.listFileEntries.Location = new System.Drawing.Point(3, 3);
            this.listFileEntries.Name = "listFileEntries";
            this.listFileEntries.Size = new System.Drawing.Size(154, 181);
            this.listFileEntries.TabIndex = 21;
            this.listFileEntries.UseCompatibleStateImageBehavior = false;
            this.listFileEntries.View = System.Windows.Forms.View.Details;
            this.listFileEntries.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listFileEntries_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Files";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 100;
            // 
            // previewSplitContainer
            // 
            this.previewSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.previewSplitContainer.Location = new System.Drawing.Point(14, 120);
            this.previewSplitContainer.Name = "previewSplitContainer";
            // 
            // previewSplitContainer.Panel1
            // 
            this.previewSplitContainer.Panel1.Controls.Add(this.listFileEntries);
            // 
            // previewSplitContainer.Panel2
            // 
            this.previewSplitContainer.Panel2.Controls.Add(this.imagePreview);
            this.previewSplitContainer.Size = new System.Drawing.Size(489, 189);
            this.previewSplitContainer.SplitterDistance = 162;
            this.previewSplitContainer.TabIndex = 23;
            // 
            // lblResolution
            // 
            this.lblResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResolution.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblResolution.Location = new System.Drawing.Point(181, 312);
            this.lblResolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(168, 15);
            this.lblResolution.TabIndex = 24;
            this.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileSize
            // 
            this.lblFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFileSize.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblFileSize.Location = new System.Drawing.Point(357, 312);
            this.lblFileSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(145, 15);
            this.lblFileSize.TabIndex = 25;
            this.lblFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(515, 535);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.previewSplitContainer);
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
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnInputFile);
            this.Controls.Add(this.lblSelectImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(531, 561);
            this.Name = "Main";
            this.Text = "Image Converter v0.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trckbarImageQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            this.previewSplitContainer.Panel1.ResumeLayout(false);
            this.previewSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewSplitContainer)).EndInit();
            this.previewSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectImage;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnConvert;
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
        private System.Windows.Forms.PictureBox imagePreview;
        private System.Windows.Forms.ListView listFileEntries;
        private System.Windows.Forms.SplitContainer previewSplitContainer;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

