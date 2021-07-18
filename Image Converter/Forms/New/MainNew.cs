using Image_Converter.Forms;
using Image_Converter.Image_Processing;
using Image_Converter.IO;
using MetroSet_UI.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Converter
{
    public partial class MainNew : Form
    {
        System.Drawing.Color colorActiveButton = System.Drawing.Color.FromArgb(255, 124, 10);
        Button currentMenuButton;
        ImportControl importControl;
        FileListControl fileListControl;
        FilterControl filterControl;
        ExportControl exportControl;

        private Converter converter;
        private System.Drawing.Image currentPreviewReferenceImage;
        private System.Drawing.Image previewBackgroundImage;

        public MainNew()
        {
            InitializeComponent();

            converter = new Converter();

            imagePreview.SizeMode = PictureBoxSizeMode.AutoSize; // fixes scaling
            // Save background image and hide it on init.
            previewBackgroundImage = imagePreview.BackgroundImage;
            imagePreview.BackgroundImage = null;
            CenterAndScalePreviewImage();

            //this.DoubleBuffered = true;
            this.Text = string.Empty;
            this.ControlBox = false;

            // Default Control
            importControl = new ImportControl();
            importControl.Anchor = ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top));
            importControl.AutoSize = false;
            importControl.Size = new System.Drawing.Size(panelImport.Width, panelImport.Height);
            panelImport.Controls.Add(importControl);
            importControl.Show();

            fileListControl = new FileListControl();
            fileListControl.Anchor = ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom));
            fileListControl.AutoSize = false;
            fileListControl.Size = new System.Drawing.Size(panelFileList.Width, panelFileList.Height);
            panelFileList.Controls.Add(fileListControl);
            importControl.Show();

            filterControl = new FilterControl();
            filterControl.Anchor = ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom));
            filterControl.AutoSize = false;
            filterControl.Size = new System.Drawing.Size(splitContainer.Panel1.Width, splitContainer.Panel1.Height);
            splitContainer.Panel1.Controls.Add(filterControl);
            filterControl.Hide();

            exportControl = new ExportControl();
            panelChildForm.Controls.Add(exportControl);
            exportControl.Hide();

            currentMenuButton = btnImport;
            currentMenuButton.BackColor = colorActiveButton;
            currentMenuButton.FlatAppearance.MouseOverBackColor = colorActiveButton;

            // Control events
            importControl.OnButtonClickSingle += new EventHandler(UserControl_ImportSingleFile);
            importControl.OnButtonClickMulti += new EventHandler(UserControl_ImportMultipleFiles);
            fileListControl.OnSelectionChanged += new EventHandler(UserControl_SelectItemInList);
            fileListControl.OnClearList += new EventHandler(UserControl_ClearFileList);

            filterControl.OnFilterChanged += new EventHandler(UserControl_FilterChanged);
        }

        // ------- CUSTOM RESIZE ------- //

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        System.Drawing.Point screenPoint = new System.Drawing.Point(m.LParam.ToInt32());
                        System.Drawing.Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.Style |= 0x20000; // <--- use 0x20000
                //cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }


        // Drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconMain_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void panelTop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void UpdateMenuButtonColor(Button button)
        {
            if (currentMenuButton != null)
            {
                currentMenuButton.BackColor = System.Drawing.Color.Transparent;
                currentMenuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            }
            currentMenuButton = button;
            button.BackColor = colorActiveButton;
            button.FlatAppearance.MouseOverBackColor = colorActiveButton;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            panelFileList.Controls.Add(fileListControl); // move file list from export view to import view
            splitContainer.Show();
            panelImport.Show();
            panelFileList.Show();
            exportControl.Hide();
            filterControl.Hide();
            UpdateMenuButtonColor((Button)sender);
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            splitContainer.Show();
            filterControl.Show();
            exportControl.Hide();
            panelImport.Hide();
            panelFileList.Hide();
            UpdateMenuButtonColor((Button)sender);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportControl.Controls.Add(fileListControl); // move file list from import view to export view
            importControl.Show();
            splitContainer.Hide();
            exportControl.Show();
            UpdateMenuButtonColor((Button)sender);
        }

        private void splitContainer_Panel1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                DragDropEffects effects = DragDropEffects.None;
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                    if (Directory.Exists(path))
                        effects = DragDropEffects.Copy;
                }
                e.Effect = effects;
            }
        }

        private void splitContainer_Panel1_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var item in (string[])e.Data.GetData(DataFormats.FileDrop, false)) // loops through all selected items (files and directories)
            {
                if (Directory.Exists(item)) // checks if selected item is a directory
                {
                    fileListControl.AddFilesInDirectory(item, importControl.isSubfoldersChecked());
                }
                else
                {
                    using (Stream stream = new FileStream(item.ToString(), FileMode.Open))
                    {
                        fileListControl.AddFileToListSingle(item, stream); // adds selected item to fileEntries (this is a single file)
                    }
                }
            }

            //verifyListAndOutputDirectory();
        }

        protected void UserControl_ImportSingleFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "Image Files (*.jpg, *.png. *.tiff, *.gif, *.bmp, *.tga)|*.jpg;*.png;*.tiff;*.gif;*.bmp;.tga;*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                using (Stream stream = new FileStream(selectedFileName, FileMode.Open))
                {
                    fileListControl.AddFileToListSingle(selectedFileName, stream);
                }
                DisplayPreviewImage(selectedFileName);
                //btnConvert.Enabled = true;
            }

            //verifyListAndOutputDirectory();
        }

        protected void UserControl_ImportMultipleFiles(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    fileListControl.AddFilesInDirectory(fbd.SelectedPath, importControl.isSubfoldersChecked());
                }
            }

            //verifyListAndOutputDirectory();
        }

        protected void UserControl_ClearFileList(object sender, EventArgs e)
        {
            imagePreview.Image = null;
            currentPreviewReferenceImage = null;
            lblFileSize.Text = "0 KB";
            lblResolution.Text = "Resolution: N/A";

            //verifyListAndOutputDirectory();
        }

        protected void UserControl_FilterChanged(object sender, EventArgs e)
        {
            DisplayPreviewImage(fileListControl.GetCurrentSelectedFile());
        }

        protected void UserControl_SelectItemInList(object sender, EventArgs e)
        {
            DisplayPreviewImage(fileListControl.GetCurrentSelectedFile());
        }

        private void groupBoxPreview_Resize(object sender, EventArgs e)
        {
            CenterAndScalePreviewImage();
        }

        private String GetInputFileNameAndExtension(String filePath)
        {
            String fileName = "";

            char cCurrent;
            int sub = 0;
            bool start = true;
            bool end = false;
            while (!end)
            {
                cCurrent = filePath[filePath.Length - 1 - sub];
                if (start)
                {
                    if (cCurrent == '/' || cCurrent == '\\')
                    {
                        end = true;
                    }
                    if (!end)
                    {
                        fileName += cCurrent; // appends file name to the string (opposite order, but we flip it later)
                    }
                }

                sub++;
            }

            char[] charArray = fileName.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray);
        }

        private String GetFileSizeString(Stream stream)
        {
            long sizeBytes = stream.Length;
            String text = sizeBytes.ToString();
            int textLength = text.Length;
            String howBigBytes = "bytes";

            if (sizeBytes > 1000)
            {
                howBigBytes = "KB";
                sizeBytes = sizeBytes / 1000;
                text = sizeBytes.ToString();
                textLength = text.Length;
            }

            String finalText = "";
            int dotPlacementHelper = 0;
            for (int i = textLength; i > 0; i--)
            {
                if (dotPlacementHelper % 3 == 0 && dotPlacementHelper != 0)
                {
                    finalText += "." + text.Substring(i - 1, 1);
                }
                else
                {
                    finalText += text.Substring(i - 1, 1);
                }
                dotPlacementHelper++;
            }

            char[] charArray = finalText.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray) + " " + howBigBytes;
        }

        public SixLabors.ImageSharp.Image<Rgba32> RenderPreview(String filePath)
        {
            Reader reader = new Reader();
            SixLabors.ImageSharp.Image<Rgba32> image = reader.ReadFile(filePath);
            if (image != null)
            {
                ImageFilters filters = new ImageFilters();
                int iconsChecked = 0;
                if (FilterSettings.isButtonIcon) iconsChecked++;
                if (FilterSettings.isPassiveIcon) iconsChecked++;
                if (FilterSettings.isAutocastIcon) iconsChecked++;
                if (FilterSettings.isDisabledIcon) iconsChecked++;

                if (FilterSettings.war3IconType == War3IconType.ClassicIcon && iconsChecked <= 1) // Classic icons
                {
                    if (FilterSettings.isButtonIcon) image = filters.AddIconBorder(image, IconTypes.BTN);
                    if (FilterSettings.isPassiveIcon) image = filters.AddIconBorder(image, IconTypes.PAS);
                    if (FilterSettings.isAutocastIcon) image = filters.AddIconBorder(image, IconTypes.ATC);
                    if (FilterSettings.isDisabledIcon) image = filters.AddIconBorder(image, IconTypes.DIS);
                    lblPreviewError.Text = "";
                }
                else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && iconsChecked <= 1) // Reforged icons
                {
                    if (FilterSettings.isButtonIconRef) image = filters.AddIconBorder(image, IconTypes.BTN_REF);
                    if (FilterSettings.isPassiveIconRef) image = filters.AddIconBorder(image, IconTypes.PAS_REF);
                    if (FilterSettings.isAutocastIconRef) image = filters.AddIconBorder(image, IconTypes.ATC_REF);
                    if (FilterSettings.isDisabledIconRef) image = filters.AddIconBorder(image, IconTypes.DIS_REF);
                    lblPreviewError.Text = "";
                }
                else
                {
                    if (FilterSettings.war3IconType == War3IconType.ClassicIcon && image.Width == 64 && image.Height == 64)
                        lblPreviewError.Text = "Cannot display multiple icon filters";
                    else if (FilterSettings.war3IconType == War3IconType.ReforgedIcon && image.Width == 256 && image.Height == 256)
                        lblPreviewError.Text = "Cannot display multiple icon filters";
                    else
                        lblPreviewError.Text = "";
                }

                if (FilterSettings.isResized)
                {
                    image.Mutate(x => x.Resize(FilterSettings.resizeX, FilterSettings.resizeY));
                }

            }

            return image;
        }

        private void DisplayPreviewImage(String filePath)
        {
            try
            {
                SixLabors.ImageSharp.Image<Rgba32> image = RenderPreview(filePath);
                if (image != null)
                {
                    Bitmap actualPreview = new Bitmap(image.Width, image.Height);

                    Stream stream = new System.IO.MemoryStream();
                    SixLabors.ImageSharp.Formats.Bmp.BmpEncoder bmpEncoder = new SixLabors.ImageSharp.Formats.Bmp.BmpEncoder(); // we need an encoder to preserve transparency.
                    bmpEncoder.BitsPerPixel = SixLabors.ImageSharp.Formats.Bmp.BmpBitsPerPixel.Pixel32; // bitmap transparency needs 32 bits per pixel before we set transparency support.
                    bmpEncoder.SupportTransparency = true;
                    image.SaveAsBmp(stream, bmpEncoder);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                    if (imagePreview.Image != null)
                    {
                        imagePreview.Image.Dispose();
                    }
                    imagePreview.Image = img;
                    currentPreviewReferenceImage = img;
                    lblResolution.Text = "Resolution: " + image.Width + "x" + image.Height;

                    image.Dispose();
                    if (converter.errorMsg != "")
                        lblPreviewError.Text = converter.errorMsg;
                    else
                        lblPreviewError.Text = "";
                }
                else
                {
                    imagePreview.Image = null;
                    currentPreviewReferenceImage = null;
                    lblResolution.Text = "Resolution: N/A";
                    lblPreviewError.Text = "Preview unavailable";
                }
                using (Stream fs = new FileStream(filePath, FileMode.Open))
                {
                    lblFileSize.Text = GetFileSizeString(fs);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Unsupported format.");
            }

            CenterAndScalePreviewImage();
        }

        private void CenterAndScalePreviewImage()
        {
            if (currentPreviewReferenceImage != null)
            {
                float sourceImgRatio = (float)currentPreviewReferenceImage.Width / (float)currentPreviewReferenceImage.Height;
                float previewWindowRatio = (float)groupBoxPreview.Width / (float)groupBoxPreview.Height;
                int paddingY = 40;
                float paddingX = paddingY * sourceImgRatio;
                System.Drawing.Size correctedSize;
                if (previewWindowRatio > sourceImgRatio)
                {
                    correctedSize = new System.Drawing.Size((int)(groupBoxPreview.Height * sourceImgRatio - paddingX), (int)(groupBoxPreview.Height - paddingY));
                }
                else
                {
                    correctedSize = new System.Drawing.Size((int)(groupBoxPreview.Width - paddingX), (int)(groupBoxPreview.Width / sourceImgRatio - paddingY));
                }

                // Preview window size exceeds image size
                if (correctedSize.Width > currentPreviewReferenceImage.Width)
                {
                    correctedSize.Width = currentPreviewReferenceImage.Width;
                }
                if (correctedSize.Height > currentPreviewReferenceImage.Height)
                {
                    correctedSize.Height = currentPreviewReferenceImage.Height;
                }
                Bitmap bmp = new Bitmap(currentPreviewReferenceImage, correctedSize);
                imagePreview.Image = bmp;
            }
            else
            {
                imagePreview.Width = 64;
                imagePreview.Height = 64;
            }

            System.Drawing.Point previewCenter = new System.Drawing.Point((groupBoxPreview.Width / 2) - (imagePreview.Width / 2), (groupBoxPreview.Height / 2) - (imagePreview.Height / 2));
            imagePreview.Location = previewCenter;
        }

        private void checkBoxTransparencyGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTransparencyGrid.Checked == true)
            {
                imagePreview.BackgroundImage = previewBackgroundImage;
            }
            else
            {
                imagePreview.BackgroundImage = null;
            }
        }


    }
}
