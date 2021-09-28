namespace ImageConverterGUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnInputFile = new System.Windows.Forms.Button();
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
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.cmboxDDSList = new System.Windows.Forms.ComboBox();
            this.chkBoxKeepFilenames = new System.Windows.Forms.CheckBox();
            this.chkBoxMipmaps = new System.Windows.Forms.CheckBox();
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.listFileEntries = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.previewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lblPreviewError = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.btnClearList = new System.Windows.Forms.Button();
            this.groupBoxImport = new System.Windows.Forms.GroupBox();
            this.panelImportContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInputFolder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblImportOr = new System.Windows.Forms.Label();
            this.lblImportOr2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblItems = new System.Windows.Forms.Label();
            this.checkBoxTransparencyGrid = new System.Windows.Forms.CheckBox();
            this.contextMenuStripFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxSubFolders = new System.Windows.Forms.CheckBox();
            this.btnFilters = new System.Windows.Forms.Button();
            this.radBtnFastest = new System.Windows.Forms.RadioButton();
            this.radBtnBalanced = new System.Windows.Forms.RadioButton();
            this.lblDDSQuality = new System.Windows.Forms.Label();
            this.radBtnHighest = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarImageQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewSplitContainer)).BeginInit();
            this.previewSplitContainer.Panel1.SuspendLayout();
            this.previewSplitContainer.Panel2.SuspendLayout();
            this.previewSplitContainer.SuspendLayout();
            this.groupBoxImport.SuspendLayout();
            this.panelImportContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStripFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInputFile
            // 
            this.btnInputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnInputFile.FlatAppearance.BorderSize = 0;
            this.btnInputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInputFile.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInputFile.Location = new System.Drawing.Point(5, 15);
            this.btnInputFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(88, 27);
            this.btnInputFile.TabIndex = 1;
            this.btnInputFile.Text = "Choose File";
            this.btnInputFile.UseVisualStyleBackColor = false;
            this.btnInputFile.Click += new System.EventHandler(this.btnChooseFile_Click);
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
            this.btnConvert.Location = new System.Drawing.Point(384, 574);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(119, 27);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert All";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(13, 424);
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
            this.cmboxOutputFormat.Location = new System.Drawing.Point(13, 442);
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
            this.btnOutputFile.Location = new System.Drawing.Point(14, 384);
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
            this.lblOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOutputDirectory.AutoEllipsis = true;
            this.lblOutputDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOutputDirectory.ForeColor = System.Drawing.Color.Black;
            this.lblOutputDirectory.Location = new System.Drawing.Point(110, 390);
            this.lblOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(392, 21);
            this.lblOutputDirectory.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(14, 366);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Output Directory:";
            // 
            // trckbarImageQuality
            // 
            this.trckbarImageQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trckbarImageQuality.Location = new System.Drawing.Point(211, 442);
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
            this.label4.Location = new System.Drawing.Point(211, 424);
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
            this.lblImageQuality.Location = new System.Drawing.Point(440, 442);
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
            this.txtFileName.Location = new System.Drawing.Point(14, 579);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(248, 22);
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
            this.label5.Location = new System.Drawing.Point(14, 557);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Filename:";
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFileFormat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblFileFormat.Location = new System.Drawing.Point(270, 582);
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
            this.cmboxDDSList.Location = new System.Drawing.Point(214, 442);
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
            this.chkBoxKeepFilenames.Location = new System.Drawing.Point(14, 535);
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
            this.chkBoxMipmaps.Location = new System.Drawing.Point(214, 471);
            this.chkBoxMipmaps.Name = "chkBoxMipmaps";
            this.chkBoxMipmaps.Size = new System.Drawing.Size(132, 19);
            this.chkBoxMipmaps.TabIndex = 18;
            this.chkBoxMipmaps.Text = "Generate Mipmaps";
            this.chkBoxMipmaps.UseVisualStyleBackColor = true;
            this.chkBoxMipmaps.Visible = false;
            // 
            // imagePreview
            // 
            this.imagePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePreview.BackColor = System.Drawing.Color.Black;
            this.imagePreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imagePreview.BackgroundImage")));
            this.imagePreview.Location = new System.Drawing.Point(3, 3);
            this.imagePreview.Name = "imagePreview";
            this.imagePreview.Size = new System.Drawing.Size(315, 176);
            this.imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.listFileEntries.Size = new System.Drawing.Size(154, 176);
            this.listFileEntries.TabIndex = 21;
            this.listFileEntries.UseCompatibleStateImageBehavior = false;
            this.listFileEntries.View = System.Windows.Forms.View.Details;
            this.listFileEntries.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listFileEntries_ItemMouseHover);
            this.listFileEntries.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listFileEntries_ItemSelectionChanged);
            this.listFileEntries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listFileEntries_KeyDown);
            this.listFileEntries.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listFileEntries_MouseClick);
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
            this.previewSplitContainer.AllowDrop = true;
            this.previewSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.previewSplitContainer.Location = new System.Drawing.Point(14, 156);
            this.previewSplitContainer.Name = "previewSplitContainer";
            // 
            // previewSplitContainer.Panel1
            // 
            this.previewSplitContainer.Panel1.Controls.Add(this.listFileEntries);
            // 
            // previewSplitContainer.Panel2
            // 
            this.previewSplitContainer.Panel2.AutoScroll = true;
            this.previewSplitContainer.Panel2.Controls.Add(this.lblPreviewError);
            this.previewSplitContainer.Panel2.Controls.Add(this.imagePreview);
            this.previewSplitContainer.Panel2.Resize += new System.EventHandler(this.previewSplitContainer_Panel2_Resize);
            this.previewSplitContainer.Size = new System.Drawing.Size(489, 184);
            this.previewSplitContainer.SplitterDistance = 162;
            this.previewSplitContainer.TabIndex = 23;
            this.previewSplitContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBoxImport_DragDrop);
            this.previewSplitContainer.DragOver += new System.Windows.Forms.DragEventHandler(this.groupBoxImport_DragOver);
            // 
            // lblPreviewError
            // 
            this.lblPreviewError.AutoSize = true;
            this.lblPreviewError.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPreviewError.ForeColor = System.Drawing.Color.Red;
            this.lblPreviewError.Location = new System.Drawing.Point(4, 3);
            this.lblPreviewError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreviewError.Name = "lblPreviewError";
            this.lblPreviewError.Size = new System.Drawing.Size(118, 15);
            this.lblPreviewError.TabIndex = 31;
            this.lblPreviewError.Text = "Preview Unavailable";
            // 
            // lblResolution
            // 
            this.lblResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResolution.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblResolution.Location = new System.Drawing.Point(180, 343);
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
            this.lblFileSize.Location = new System.Drawing.Point(383, 343);
            this.lblFileSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(118, 15);
            this.lblFileSize.TabIndex = 25;
            this.lblFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClearList
            // 
            this.btnClearList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnClearList.FlatAppearance.BorderSize = 0;
            this.btnClearList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClearList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearList.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClearList.Location = new System.Drawing.Point(14, 128);
            this.btnClearList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(47, 26);
            this.btnClearList.TabIndex = 26;
            this.btnClearList.Text = "Clear";
            this.btnClearList.UseVisualStyleBackColor = false;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // groupBoxImport
            // 
            this.groupBoxImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImport.Controls.Add(this.panelImportContent);
            this.groupBoxImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxImport.Location = new System.Drawing.Point(3, 3);
            this.groupBoxImport.Name = "groupBoxImport";
            this.groupBoxImport.Size = new System.Drawing.Size(455, 80);
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
            this.panelImportContent.Location = new System.Drawing.Point(47, 15);
            this.panelImportContent.Name = "panelImportContent";
            this.panelImportContent.Size = new System.Drawing.Size(326, 59);
            this.panelImportContent.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(260, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Drop Files";
            // 
            // btnInputFolder
            // 
            this.btnInputFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnInputFolder.FlatAppearance.BorderSize = 0;
            this.btnInputFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInputFolder.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInputFolder.Location = new System.Drawing.Point(127, 15);
            this.btnInputFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInputFolder.Name = "btnInputFolder";
            this.btnInputFolder.Size = new System.Drawing.Size(100, 27);
            this.btnInputFolder.TabIndex = 2;
            this.btnInputFolder.Text = "Choose Folder";
            this.btnInputFolder.UseVisualStyleBackColor = false;
            this.btnInputFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(260, -1);
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
            this.lblImportOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImportOr.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblImportOr.Location = new System.Drawing.Point(101, 21);
            this.lblImportOr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImportOr.Name = "lblImportOr";
            this.lblImportOr.Size = new System.Drawing.Size(18, 15);
            this.lblImportOr.TabIndex = 28;
            this.lblImportOr.Text = "or";
            // 
            // lblImportOr2
            // 
            this.lblImportOr2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImportOr2.AutoSize = true;
            this.lblImportOr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImportOr2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblImportOr2.Location = new System.Drawing.Point(235, 21);
            this.lblImportOr2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImportOr2.Name = "lblImportOr2";
            this.lblImportOr2.Size = new System.Drawing.Size(18, 15);
            this.lblImportOr2.TabIndex = 29;
            this.lblImportOr2.Text = "or";
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBoxImport);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 83);
            this.panel1.TabIndex = 28;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBoxImport_DragDrop);
            this.panel1.DragOver += new System.Windows.Forms.DragEventHandler(this.groupBoxImport_DragOver);
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblItems.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblItems.Location = new System.Drawing.Point(13, 343);
            this.lblItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(104, 15);
            this.lblItems.TabIndex = 29;
            this.lblItems.Text = "Items: 0";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxTransparencyGrid
            // 
            this.checkBoxTransparencyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTransparencyGrid.AutoSize = true;
            this.checkBoxTransparencyGrid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxTransparencyGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxTransparencyGrid.Location = new System.Drawing.Point(373, 135);
            this.checkBoxTransparencyGrid.Name = "checkBoxTransparencyGrid";
            this.checkBoxTransparencyGrid.Size = new System.Drawing.Size(129, 19);
            this.checkBoxTransparencyGrid.TabIndex = 30;
            this.checkBoxTransparencyGrid.Text = "View Transparency";
            this.checkBoxTransparencyGrid.UseVisualStyleBackColor = true;
            this.checkBoxTransparencyGrid.CheckedChanged += new System.EventHandler(this.checkBoxTransparencyGrid_CheckedChanged);
            // 
            // contextMenuStripFiles
            // 
            this.contextMenuStripFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileLocationToolStripMenuItem,
            this.removeFromListToolStripMenuItem,
            this.convertToolStripMenuItem});
            this.contextMenuStripFiles.Name = "contextMenuStripFiles";
            this.contextMenuStripFiles.Size = new System.Drawing.Size(174, 70);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openFileLocationToolStripMenuItem.Text = "Convert";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.convertToolStripMenuItem_Click);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.removeFromListToolStripMenuItem.Text = "Open File Location";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.convertToolStripMenuItem.Text = "Remove From List";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // checkBoxSubFolders
            // 
            this.checkBoxSubFolders.AutoSize = true;
            this.checkBoxSubFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxSubFolders.Location = new System.Drawing.Point(17, 95);
            this.checkBoxSubFolders.Name = "checkBoxSubFolders";
            this.checkBoxSubFolders.Size = new System.Drawing.Size(128, 19);
            this.checkBoxSubFolders.TabIndex = 32;
            this.checkBoxSubFolders.Text = "Include Subfolders";
            this.checkBoxSubFolders.UseVisualStyleBackColor = true;
            this.checkBoxSubFolders.MouseHover += new System.EventHandler(this.checkBoxSubFolders_MouseHover);
            // 
            // btnFilters
            // 
            this.btnFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnFilters.FlatAppearance.BorderSize = 0;
            this.btnFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFilters.ForeColor = System.Drawing.SystemColors.Window;
            this.btnFilters.Location = new System.Drawing.Point(181, 127);
            this.btnFilters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(59, 27);
            this.btnFilters.TabIndex = 33;
            this.btnFilters.Text = "Filters";
            this.btnFilters.UseVisualStyleBackColor = false;
            this.btnFilters.Visible = false;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // radBtnFastest
            // 
            this.radBtnFastest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnFastest.AutoSize = true;
            this.radBtnFastest.Checked = true;
            this.radBtnFastest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnFastest.Location = new System.Drawing.Point(215, 525);
            this.radBtnFastest.Name = "radBtnFastest";
            this.radBtnFastest.Size = new System.Drawing.Size(64, 19);
            this.radBtnFastest.TabIndex = 34;
            this.radBtnFastest.TabStop = true;
            this.radBtnFastest.Text = "Fastest";
            this.radBtnFastest.UseVisualStyleBackColor = true;
            this.radBtnFastest.Visible = false;
            // 
            // radBtnBalanced
            // 
            this.radBtnBalanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnBalanced.AutoSize = true;
            this.radBtnBalanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnBalanced.Location = new System.Drawing.Point(285, 525);
            this.radBtnBalanced.Name = "radBtnBalanced";
            this.radBtnBalanced.Size = new System.Drawing.Size(77, 19);
            this.radBtnBalanced.TabIndex = 35;
            this.radBtnBalanced.Text = "Balanced";
            this.radBtnBalanced.UseVisualStyleBackColor = true;
            this.radBtnBalanced.Visible = false;
            // 
            // lblDDSQuality
            // 
            this.lblDDSQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDDSQuality.AutoSize = true;
            this.lblDDSQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDDSQuality.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblDDSQuality.Location = new System.Drawing.Point(211, 507);
            this.lblDDSQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDDSQuality.Name = "lblDDSQuality";
            this.lblDDSQuality.Size = new System.Drawing.Size(123, 15);
            this.lblDDSQuality.TabIndex = 36;
            this.lblDDSQuality.Text = "Compression Quality:";
            this.lblDDSQuality.Visible = false;
            // 
            // radBtnHighest
            // 
            this.radBtnHighest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBtnHighest.AutoSize = true;
            this.radBtnHighest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radBtnHighest.Location = new System.Drawing.Point(368, 525);
            this.radBtnHighest.Name = "radBtnHighest";
            this.radBtnHighest.Size = new System.Drawing.Size(67, 19);
            this.radBtnHighest.TabIndex = 37;
            this.radBtnHighest.Text = "Highest";
            this.radBtnHighest.UseVisualStyleBackColor = true;
            this.radBtnHighest.Visible = false;
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(515, 611);
            this.Controls.Add(this.radBtnHighest);
            this.Controls.Add(this.lblDDSQuality);
            this.Controls.Add(this.radBtnBalanced);
            this.Controls.Add(this.radBtnFastest);
            this.Controls.Add(this.btnFilters);
            this.Controls.Add(this.checkBoxSubFolders);
            this.Controls.Add(this.checkBoxTransparencyGrid);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.previewSplitContainer);
            this.Controls.Add(this.chkBoxMipmaps);
            this.Controls.Add(this.chkBoxKeepFilenames);
            this.Controls.Add(this.cmboxDDSList);
            this.Controls.Add(this.lblFileFormat);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(531, 650);
            this.Name = "Main";
            this.Text = "Image Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trckbarImageQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            this.previewSplitContainer.Panel1.ResumeLayout(false);
            this.previewSplitContainer.Panel2.ResumeLayout(false);
            this.previewSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewSplitContainer)).EndInit();
            this.previewSplitContainer.ResumeLayout(false);
            this.groupBoxImport.ResumeLayout(false);
            this.panelImportContent.ResumeLayout(false);
            this.panelImportContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStripFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInputFile;
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
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.GroupBox groupBoxImport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblImportOr2;
        private System.Windows.Forms.Label lblImportOr;
        private System.Windows.Forms.Button btnInputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.CheckBox checkBoxTransparencyGrid;
        private System.Windows.Forms.Label lblPreviewError;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFiles;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.Panel panelImportContent;
        private System.Windows.Forms.CheckBox checkBoxSubFolders;
        private System.Windows.Forms.Button btnFilters;
        private System.Windows.Forms.RadioButton radBtnFastest;
        private System.Windows.Forms.RadioButton radBtnBalanced;
        private System.Windows.Forms.Label lblDDSQuality;
        private System.Windows.Forms.RadioButton radBtnHighest;
    }
}

