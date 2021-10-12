
namespace WarcraftImageLabGUI
{
    partial class MainNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainNew));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnAbout = new FontAwesome.Sharp.IconButton();
            this.btnFilters = new FontAwesome.Sharp.IconButton();
            this.btnImport = new FontAwesome.Sharp.IconButton();
            this.btnExport = new FontAwesome.Sharp.IconButton();
            this.iconMain = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.imagePreview = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblColorHexadecimal = new System.Windows.Forms.Label();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.lblRGBA = new System.Windows.Forms.Label();
            this.lblPreviewError = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.checkBoxTransparencyGrid = new System.Windows.Forms.CheckBox();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMain)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).BeginInit();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.groupBoxPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelMenu.Controls.Add(this.btnAbout);
            this.panelMenu.Controls.Add(this.btnFilters);
            this.panelMenu.Controls.Add(this.btnImport);
            this.panelMenu.Controls.Add(this.btnExport);
            this.panelMenu.Controls.Add(this.iconMain);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(147, 626);
            this.panelMenu.TabIndex = 0;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            this.btnAbout.IconColor = System.Drawing.Color.White;
            this.btnAbout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAbout.IconSize = 40;
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Location = new System.Drawing.Point(0, 562);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(2);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(147, 50);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "ABOUT";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnFilters
            // 
            this.btnFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilters.BackColor = System.Drawing.Color.Transparent;
            this.btnFilters.FlatAppearance.BorderSize = 0;
            this.btnFilters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnFilters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilters.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFilters.ForeColor = System.Drawing.Color.White;
            this.btnFilters.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.btnFilters.IconColor = System.Drawing.Color.White;
            this.btnFilters.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFilters.IconSize = 40;
            this.btnFilters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilters.Location = new System.Drawing.Point(0, 200);
            this.btnFilters.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(147, 50);
            this.btnFilters.TabIndex = 9;
            this.btnFilters.Text = "FILTERS";
            this.btnFilters.UseVisualStyleBackColor = false;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btnImport.IconColor = System.Drawing.Color.White;
            this.btnImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImport.IconSize = 40;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(0, 146);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(147, 50);
            this.btnImport.TabIndex = 8;
            this.btnImport.Text = "IMPORT";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExport.IconColor = System.Drawing.Color.White;
            this.btnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExport.IconSize = 40;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(0, 254);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(147, 50);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // iconMain
            // 
            this.iconMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.iconMain.Image = global::WarcraftImageLabGUI.Properties.Resources.Warcraft_W;
            this.iconMain.Location = new System.Drawing.Point(0, 0);
            this.iconMain.Margin = new System.Windows.Forms.Padding(2);
            this.iconMain.Name = "iconMain";
            this.iconMain.Size = new System.Drawing.Size(145, 142);
            this.iconMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconMain.TabIndex = 0;
            this.iconMain.TabStop = false;
            this.iconMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.iconMain_MouseDown);
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnMaximize);
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Location = new System.Drawing.Point(145, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(837, 56);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDoubleClick);
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(8, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(172, 19);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "WARCRAFT IMAGE LAB";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 20;
            this.btnMaximize.Location = new System.Drawing.Point(763, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(35, 35);
            this.btnMaximize.TabIndex = 12;
            this.btnMaximize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 20;
            this.btnMinimize.Location = new System.Drawing.Point(724, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 11;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(802, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 35);
            this.btnExit.TabIndex = 10;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // imagePreview
            // 
            this.imagePreview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imagePreview.BackColor = System.Drawing.Color.Black;
            this.imagePreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imagePreview.BackgroundImage")));
            this.imagePreview.Location = new System.Drawing.Point(31, 88);
            this.imagePreview.Name = "imagePreview";
            this.imagePreview.Size = new System.Drawing.Size(284, 266);
            this.imagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagePreview.TabIndex = 2;
            this.imagePreview.TabStop = false;
            this.imagePreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imagePreview_MouseMove);
            // 
            // panelChildForm
            // 
            this.panelChildForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChildForm.BackColor = System.Drawing.Color.DimGray;
            this.panelChildForm.Controls.Add(this.splitContainer);
            this.panelChildForm.Location = new System.Drawing.Point(153, 61);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(817, 551);
            this.panelChildForm.TabIndex = 3;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.ForeColor = System.Drawing.Color.White;
            this.splitContainer.Location = new System.Drawing.Point(3, 3);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AllowDrop = true;
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.splitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer.Panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer_Panel1_DragDrop);
            this.splitContainer.Panel1.DragOver += new System.Windows.Forms.DragEventHandler(this.splitContainer_Panel1_DragOver);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.splitContainer.Panel2.Controls.Add(this.lblColorHexadecimal);
            this.splitContainer.Panel2.Controls.Add(this.lblCoordinates);
            this.splitContainer.Panel2.Controls.Add(this.colorBox);
            this.splitContainer.Panel2.Controls.Add(this.lblRGBA);
            this.splitContainer.Panel2.Controls.Add(this.lblPreviewError);
            this.splitContainer.Panel2.Controls.Add(this.lblFileSize);
            this.splitContainer.Panel2.Controls.Add(this.lblResolution);
            this.splitContainer.Panel2.Controls.Add(this.groupBoxPreview);
            this.splitContainer.Panel2.Controls.Add(this.checkBoxTransparencyGrid);
            this.splitContainer.Size = new System.Drawing.Size(811, 545);
            this.splitContainer.SplitterDistance = 445;
            this.splitContainer.TabIndex = 16;
            // 
            // lblColorHexadecimal
            // 
            this.lblColorHexadecimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColorHexadecimal.BackColor = System.Drawing.Color.Transparent;
            this.lblColorHexadecimal.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblColorHexadecimal.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblColorHexadecimal.Location = new System.Drawing.Point(220, 11);
            this.lblColorHexadecimal.Name = "lblColorHexadecimal";
            this.lblColorHexadecimal.Size = new System.Drawing.Size(135, 16);
            this.lblColorHexadecimal.TabIndex = 37;
            this.lblColorHexadecimal.Text = "#000000";
            this.lblColorHexadecimal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCoordinates.BackColor = System.Drawing.Color.Transparent;
            this.lblCoordinates.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCoordinates.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblCoordinates.Location = new System.Drawing.Point(8, 30);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(188, 16);
            this.lblCoordinates.TabIndex = 36;
            this.lblCoordinates.Text = "X: 0 Y: 0";
            this.lblCoordinates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.Black;
            this.colorBox.Location = new System.Drawing.Point(8, 11);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(16, 16);
            this.colorBox.TabIndex = 35;
            this.colorBox.TabStop = false;
            // 
            // lblRGBA
            // 
            this.lblRGBA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRGBA.BackColor = System.Drawing.Color.Transparent;
            this.lblRGBA.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRGBA.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblRGBA.Location = new System.Drawing.Point(26, 11);
            this.lblRGBA.Name = "lblRGBA";
            this.lblRGBA.Size = new System.Drawing.Size(188, 16);
            this.lblRGBA.TabIndex = 34;
            this.lblRGBA.Text = "R:0 G:0 B:0 A:0";
            this.lblRGBA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPreviewError
            // 
            this.lblPreviewError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPreviewError.AutoSize = true;
            this.lblPreviewError.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewError.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPreviewError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblPreviewError.Location = new System.Drawing.Point(8, 515);
            this.lblPreviewError.Name = "lblPreviewError";
            this.lblPreviewError.Size = new System.Drawing.Size(0, 16);
            this.lblPreviewError.TabIndex = 33;
            this.lblPreviewError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFileSize
            // 
            this.lblFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileSize.BackColor = System.Drawing.Color.Transparent;
            this.lblFileSize.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFileSize.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblFileSize.Location = new System.Drawing.Point(260, 478);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(95, 16);
            this.lblFileSize.TabIndex = 14;
            this.lblFileSize.Text = "0 KB";
            this.lblFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblResolution
            // 
            this.lblResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResolution.AutoSize = true;
            this.lblResolution.BackColor = System.Drawing.Color.Transparent;
            this.lblResolution.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResolution.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblResolution.Location = new System.Drawing.Point(8, 478);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(96, 16);
            this.lblResolution.TabIndex = 32;
            this.lblResolution.Text = "Resolution: N/A";
            this.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPreview.Controls.Add(this.imagePreview);
            this.groupBoxPreview.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBoxPreview.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxPreview.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxPreview.Location = new System.Drawing.Point(8, 49);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(347, 426);
            this.groupBoxPreview.TabIndex = 15;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Preview";
            this.groupBoxPreview.Resize += new System.EventHandler(this.groupBoxPreview_Resize);
            // 
            // checkBoxTransparencyGrid
            // 
            this.checkBoxTransparencyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTransparencyGrid.AutoSize = true;
            this.checkBoxTransparencyGrid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxTransparencyGrid.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxTransparencyGrid.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxTransparencyGrid.Location = new System.Drawing.Point(220, 30);
            this.checkBoxTransparencyGrid.Name = "checkBoxTransparencyGrid";
            this.checkBoxTransparencyGrid.Size = new System.Drawing.Size(135, 20);
            this.checkBoxTransparencyGrid.TabIndex = 31;
            this.checkBoxTransparencyGrid.Text = "View Transparency";
            this.checkBoxTransparencyGrid.UseVisualStyleBackColor = true;
            this.checkBoxTransparencyGrid.CheckedChanged += new System.EventHandler(this.checkBoxTransparencyGrid_CheckedChanged);
            // 
            // MainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(982, 624);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(982, 624);
            this.Name = "MainNew";
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconMain)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreview)).EndInit();
            this.panelChildForm.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.groupBoxPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox iconMain;
        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnImport;
        private FontAwesome.Sharp.IconButton btnFilters;
        private System.Windows.Forms.Panel panelTop;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private System.Windows.Forms.Label lblTitle;
        private FontAwesome.Sharp.IconButton btnAbout;
        private System.Windows.Forms.PictureBox imagePreview;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.CheckBox checkBoxTransparencyGrid;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Label lblPreviewError;
        private System.Windows.Forms.Label lblRGBA;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.Label lblColorHexadecimal;
    }
}