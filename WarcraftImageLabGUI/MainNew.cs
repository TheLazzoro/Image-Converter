using Image_Converter.IO;
using MetroSet_UI.Forms;
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

namespace WarcraftImageLabGUI
{
    public partial class MainNew : Form
    {
        System.Drawing.Color colorActiveButton = System.Drawing.Color.FromArgb(255, 124, 10);
        Button currentMenuButton;
        ImportControl importControl;
        FileListControl fileListControl;
        FilterControl filterControl;
        ExportControl exportControl;

        private Bitmap currentPreviewImageBitmap;
        private System.Drawing.Image currentPreviewReferenceImage;
        private System.Drawing.Image previewBackgroundImage;

        public MainNew()
        {
            InitializeComponent();

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
            importControl.Size = new System.Drawing.Size(splitContainer.Panel1.Width - 4, importControl.Height);
            importControl.Location = new System.Drawing.Point(4, 0);
            splitContainer.Panel1.Controls.Add(importControl);
            importControl.Show();

            fileListControl = new FileListControl();
            fileListControl.Anchor = ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom));
            fileListControl.AutoSize = false;
            fileListControl.Size = new System.Drawing.Size(splitContainer.Panel1.Width, splitContainer.Panel1.Height - importControl.Height);
            fileListControl.Location = new System.Drawing.Point(0, importControl.Height);
            splitContainer.Panel1.Controls.Add(fileListControl);
            importControl.Show();

            filterControl = new FilterControl();
            filterControl.Anchor = ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top));
            filterControl.AutoSize = false;
            filterControl.Size = new System.Drawing.Size(splitContainer.Panel1.Width, filterControl.Height);
            splitContainer.Panel1.Controls.Add(filterControl);
            filterControl.Hide();

            exportControl = new ExportControl();
            exportControl.Anchor = ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom));
            exportControl.AutoSize = false;
            exportControl.Size = new System.Drawing.Size(panelChildForm.Width, panelChildForm.Height);
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
            fileListControl.OnExportSingle += new EventHandler(UserControl_ExportSingle);

            filterControl.OnFilterChanged += new EventHandler(UserControl_FilterChanged);

            exportControl.OnExportAll += new EventHandler(UserControl_ExportAll);
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
            splitContainer.Panel1.Controls.Add(fileListControl); // move file list to import view
            splitContainer.Show();
            importControl.Show();
            exportControl.Hide();
            filterControl.Hide();
            splitContainer.Panel1.Show();
            fileListControl.Location = new System.Drawing.Point(splitContainer.Panel1.Location.X, importControl.Height + 8);
            fileListControl.Size = new System.Drawing.Size(splitContainer.Panel1.Width, panelChildForm.Height - importControl.Height - 8);
            UpdateMenuButtonColor((Button)sender);
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            splitContainer.Panel1.Controls.Add(fileListControl); // move file list to filter view
            splitContainer.Show();
            filterControl.Show();
            exportControl.Hide();
            importControl.Hide();
            splitContainer.Panel1.Show();
            fileListControl.Location = new System.Drawing.Point(splitContainer.Panel1.Location.X, filterControl.Height);
            fileListControl.Size = new System.Drawing.Size(splitContainer.Panel1.Width, panelChildForm.Height - filterControl.Height);
            UpdateMenuButtonColor((Button)sender);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportControl.Controls.Add(fileListControl); // move file list to export view
            importControl.Show();
            splitContainer.Hide();
            exportControl.Show();
            fileListControl.Location = new System.Drawing.Point(4, 4);
            fileListControl.Size = new System.Drawing.Size(panelChildForm.Width - exportControl.GetExportBoxSizeX() - 20, panelChildForm.Height - 4);
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
                    fileListControl.AddFileToListSingle(item); // adds selected item to fileEntries (this is a single file)
                }
            }
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
                fileListControl.AddFileToListSingle(selectedFileName);

                DisplayPreviewImage(selectedFileName);
            }
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
        }

        protected void UserControl_ClearFileList(object sender, EventArgs e)
        {
            imagePreview.Image = null;
            currentPreviewReferenceImage = null;
            lblFileSize.Text = "0 KB";
            lblResolution.Text = "Resolution: N/A";
        }

        protected void UserControl_FilterChanged(object sender, EventArgs e)
        {
            DisplayPreviewImage(fileListControl.GetCurrentSelectedFile());
        }

        protected void UserControl_SelectItemInList(object sender, EventArgs e)
        {
            DisplayPreviewImage(fileListControl.GetCurrentSelectedFile());
        }

        protected void UserControl_ExportSingle(object sender, EventArgs e)
        {
            ExportSettings.isMultipleFiles = false;
            exportControl.UpdateExportSettings();

            string fileEntry = fileListControl.GetCurrentSelectedFile();
            exportControl.ExportSingle(fileEntry);
        }

        protected void UserControl_ExportAll(object sender, EventArgs e)
        {
            ExportSettings.isMultipleFiles = true;
            exportControl.UpdateExportSettings();

            ListView.ListViewItemCollection fileList = fileListControl.GetAllFileEntries();
            List<string> fileEntries = new List<string>();
            for (int i = 0; i < fileList.Count; i++)
            {
                fileEntries.Add(fileList[i].Tag.ToString());
            }

            exportControl.ExportAll(fileEntries);
        }

        private void groupBoxPreview_Resize(object sender, EventArgs e)
        {
            CenterAndScalePreviewImage();
        }

        private void DisplayPreviewImage(String filePath)
        {
            if (filePath != null)
            {
                Preview preview = new Preview();
                Bitmap image = preview.RenderPreview(filePath);
                lblPreviewError.Text = preview.errorMsg;

                if (imagePreview.Image != null)
                {
                    imagePreview.Image.Dispose();
                }
                if(image != null)
                {
                    lblResolution.Text = "Resolution: " + image.Width + "x" + image.Height;
                }
                imagePreview.Image = image;
                currentPreviewReferenceImage = image;

                lblFileSize.Text = preview.fileSizeString;

                CenterAndScalePreviewImage();
            }
        }

        private void CenterAndScalePreviewImage()
        {
            if (currentPreviewReferenceImage != null)
            {
                int newWindowX = groupBoxPreview.Width - 24;
                int newWindowY = groupBoxPreview.Height - 32;

                float previewWindowRatio = (float)newWindowX / (float)newWindowY;
                float sourceImgRatio = (float)currentPreviewReferenceImage.Width / (float)currentPreviewReferenceImage.Height;
                System.Drawing.Size correctedSize;

                if (previewWindowRatio > sourceImgRatio)
                {
                    correctedSize = new System.Drawing.Size((int)(newWindowY * sourceImgRatio), (int)(newWindowY));
                }
                else
                {
                    correctedSize = new System.Drawing.Size((int)(newWindowX), (int)(newWindowX / sourceImgRatio));
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
                currentPreviewImageBitmap = new Bitmap(currentPreviewReferenceImage, correctedSize);
                imagePreview.Image = currentPreviewImageBitmap;
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

        private void imagePreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (imagePreview.Image != null)
            {
                System.Drawing.Color color = currentPreviewImageBitmap.GetPixel(e.X, e.Y);
                colorBox.BackColor = color;
                lblRGBA.Text = "R:" + color.R + " G:" + color.G + " B:" + color.B + " A:" + color.A;
            }
        }
    }
}
