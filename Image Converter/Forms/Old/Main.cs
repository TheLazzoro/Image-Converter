using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using Image_Converter.IO;
using Image_Converter.Image_Processing;
using SixLabors.ImageSharp.Processing;

namespace Image_Converter
{
    public partial class Main : Form
    {
        private System.Drawing.Image currentPreviewReferenceImage;
        private System.Drawing.Image previewBackgroundImage;

        public Main()
        {
            InitializeComponent();

            // Must be added in this order to match ImageFormat enum
            cmboxOutputFormat.Items.Add("JPG");
            cmboxOutputFormat.Items.Add("PNG");
            cmboxOutputFormat.Items.Add("BMP");
            cmboxOutputFormat.Items.Add("TGA");
            cmboxOutputFormat.Items.Add("DDS");
            //cmboxOutputFormat.Items.Add("BLP");
            cmboxOutputFormat.SelectedIndex = 0;

            cmboxDDSList.Items.Add("BC1 (DXT1), RGB | no alpha");
            cmboxDDSList.Items.Add("BC1 (DXT1), RGBA | 1 bit alpha");
            cmboxDDSList.Items.Add("BC2 (DXT2 or DTX3), RGBA | explicit alpha");
            cmboxDDSList.Items.Add("BC3 (DXT4 or DTX5), RGBA | interpolated alpha");
            cmboxDDSList.SelectedIndex = 0;

            // Image preview layout
            imagePreview.SizeMode = PictureBoxSizeMode.AutoSize; // questionable?
            lblPreviewError.Text = "";

            // Save background image and hide it on init.
            previewBackgroundImage = imagePreview.BackgroundImage;
            imagePreview.BackgroundImage = null;
        }

        

        private void btnChooseFile_Click(object sender, EventArgs e)
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
                    AddItemToList(selectedFileName, stream);
                }
                DisplayPreviewImage(selectedFileName);
                btnConvert.Enabled = true;
            }

            verifyListAndOutputDirectory();
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    AddFilesInDirectory(fbd.SelectedPath);
                }
            }

            verifyListAndOutputDirectory();
        }

        private void groupBoxImport_DragDrop(object sender, DragEventArgs e)
        {
            foreach (var item in (string[])e.Data.GetData(DataFormats.FileDrop, false)) // loops through all selected items (files and directories)
            {
                if (Directory.Exists(item)) // checks if selected item is a directory
                {
                    AddFilesInDirectory(item);
                }
                else
                {
                    using (Stream stream = new FileStream(item.ToString(), FileMode.Open))
                    {
                        AddItemToList(item, stream); // adds selected item to fileEntries (this is a single file)
                    }
                }
            }

            verifyListAndOutputDirectory();
        }

        private void groupBoxImport_DragOver(object sender, DragEventArgs e)
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

        private void AddFilesInDirectory(string directoryPath)
        {
            string[] fileEntries;

            if (checkBoxSubFolders.Checked == true)
            {
                fileEntries = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);
            }
            else
            {
                fileEntries = Directory.GetFiles(directoryPath);
            }

            foreach (var item in fileEntries) // loops through all selected items (files and directories)
            {
                if (Directory.Exists(item)) // checks if item in directory is a directory
                {
                    AddFilesInDirectory(item); // Subfolder Recursion
                }
                else
                {
                    using (Stream stream = new FileStream(item.ToString(), FileMode.Open))
                    {
                        AddItemToList(item, stream); // adds selected item to fileEntries (this is a single file)
                    }
                }
            }
        }

        private void AddItemToList(string fileEntry, Stream stream)
        {
            string filename = GetInputFileNameAndExtension(fileEntry);
            String[] row = { filename, GetFileSizeString(stream) };
            ListViewItem item = new ListViewItem(row);
            item.Tag = fileEntry;
            listFileEntries.Items.Add(item);
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

        private void listFileEntries_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listFileEntries.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStripFiles.Show(Cursor.Position);
                    if (verifyListAndOutputDirectory())
                    {
                        contextMenuStripFiles.Items[0].Enabled = true;
                    }
                    else
                    {
                        contextMenuStripFiles.Items[0].Enabled = false;
                    }
                }
            }
        }


        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(listFileEntries.SelectedItems[0].Tag.ToString()))
            {
                Process.Start("explorer.exe", "/select," + listFileEntries.SelectedItems[0].Tag.ToString());
            }
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRowsInList();
        }

        private void listFileEntries_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            CustomTooltip.DisplayTooltip(e.Item.Tag.ToString(), listFileEntries, 600);
        }


        private void convertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSettings.fileName = txtFileName.Text;
            ExportSettings.selectedFileExtension = (ImageFormats)cmboxOutputFormat.SelectedIndex;
            ExportSettings.outputDir = lblOutputDirectory.Text;
            ExportSettings.keepFileNames = chkBoxKeepFilenames.Checked;
            ExportSettings.imageQualityJpeg = trckbarImageQuality.Value * 10; //calculates image quality for jpg
            ExportSettings.selectedDDSCompression = cmboxDDSList.SelectedIndex; // dds compression
            ExportSettings.generateMipMaps = chkBoxMipmaps.Checked; // dds mipmaps
            ExportSettings.isMultipleFiles = false;
            if(radBtnFastest.Checked) { // compression quality
                ExportSettings.selectedDDSCompressionQuality = 0;
            } else if(radBtnBalanced.Checked) {
                ExportSettings.selectedDDSCompressionQuality = 1;
            } else {
                ExportSettings.selectedDDSCompressionQuality = 2;
            }
            
            Converter converter = new Converter();

            string[] fileEntry = new string[1];
            fileEntry[0] = listFileEntries.SelectedItems[0].Tag.ToString();
            converter.fileEntries = fileEntry;

            DialogResult dialogResult = MessageBox.Show("This action converts '" + listFileEntries.SelectedItems[0].Text + "' with specified settings to the output directory.", "Convert Single File", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                bool success = converter.ConvertWithFilters();

                if (success)
                {
                    MessageBox.Show("Conversion successful!");
                }
                else
                {
                    MessageBox.Show("Error: " + converter.errorMsg);
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ExportSettings.selectedFileExtension = (ImageFormats)cmboxOutputFormat.SelectedIndex;
            ExportSettings.outputDir = lblOutputDirectory.Text;
            ExportSettings.fileName = txtFileName.Text;
            ExportSettings.keepFileNames = chkBoxKeepFilenames.Checked;
            ExportSettings.imageQualityJpeg = trckbarImageQuality.Value * 10; //calculates image quality for jpg
            ExportSettings.selectedDDSCompression = cmboxDDSList.SelectedIndex; // dds compression
            ExportSettings.generateMipMaps = chkBoxMipmaps.Checked; // dds mipmaps
            ExportSettings.isMultipleFiles = true;
            if(radBtnFastest.Checked) { // compression quality
                ExportSettings.selectedDDSCompressionQuality = 0;
            } else if(radBtnBalanced.Checked) {
                ExportSettings.selectedDDSCompressionQuality = 1;
            } else {
                ExportSettings.selectedDDSCompressionQuality = 2;
            }

            Converter converter = new Converter();

            List<string> fileEntries = new List<string>();
            for (int i = 0; i < listFileEntries.Items.Count; i++)
            {
                fileEntries.Add(listFileEntries.Items[i].Tag.ToString());
            }
            converter.fileEntries = fileEntries.ToArray();

            DialogResult dialogResult = MessageBox.Show("This action will overwrite any existing files with the same name in the output directory." +
                "\n\nDo you want to continue?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MultiConvertProgress dialog = new MultiConvertProgress(converter);
                dialog.outputDir = ExportSettings.outputDir;
                dialog.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (lblOutputDirectory.Text != "")
                {
                    fbd.SelectedPath = lblOutputDirectory.Text;
                }

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    lblOutputDirectory.Text = fbd.SelectedPath;
                }
            }

            verifyListAndOutputDirectory();
        }

        private bool verifyListAndOutputDirectory()
        {
            bool ok = false;
            if (listFileEntries.Items.Count > 0 && lblOutputDirectory.Text != null && lblOutputDirectory.Text != "")
            {
                btnConvert.Enabled = true;
                btnConvert.BackColor = System.Drawing.Color.FromArgb(0, 175, 175);
                ok = true;
            }
            else
            {
                btnConvert.Enabled = false;
                btnConvert.BackColor = System.Drawing.Color.FromArgb(175, 175, 175);
            }
            lblItems.Text = "Items: " + listFileEntries.Items.Count;

            return ok;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblImageQuality.Text = trckbarImageQuality.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^?:\\/:*?\""<>|]"))
            {
                e.Handled = true;
            }
        }

        private void cmboxOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboxOutputFormat.SelectedIndex == (int)ImageFormats.JPG)
            {
                label4.Visible = true;
                label4.Text = "Image Quality:";
                trckbarImageQuality.Visible = true;
                lblImageQuality.Visible = true;
                cmboxDDSList.Visible = false;
                chkBoxMipmaps.Visible = false;
                lblDDSQuality.Visible = false;
                radBtnFastest.Visible = false;
                radBtnBalanced.Visible = false;
                radBtnHighest.Visible = false;
            }
            else if (cmboxOutputFormat.SelectedIndex == (int)ImageFormats.DDS)
            {
                label4.Visible = true;
                label4.Text = "Compression:";
                trckbarImageQuality.Visible = false;
                lblImageQuality.Visible = false;
                cmboxDDSList.Visible = true;
                chkBoxMipmaps.Visible = true;
                lblDDSQuality.Visible = true;
                radBtnFastest.Visible = true;
                radBtnBalanced.Visible = true;
                radBtnHighest.Visible = true;
            }
            else
            {
                label4.Visible = false;
                trckbarImageQuality.Visible = false;
                lblImageQuality.Visible = false;
                cmboxDDSList.Visible = false;
                chkBoxMipmaps.Visible = false;
                lblDDSQuality.Visible = false;
                radBtnFastest.Visible = false;
                radBtnBalanced.Visible = false;
                radBtnHighest.Visible = false;
            }

            switch (cmboxOutputFormat.SelectedIndex)
            {
                case (int)ImageFormats.JPG:
                    lblFileFormat.Text = ".jpg";
                    break;
                case (int)ImageFormats.PNG:
                    lblFileFormat.Text = ".png";
                    break;
                case (int)ImageFormats.BMP:
                    lblFileFormat.Text = ".bmp";
                    break;
                case (int)ImageFormats.TGA:
                    lblFileFormat.Text = ".tga";
                    break;
                case (int)ImageFormats.DDS:
                    lblFileFormat.Text = ".dds";
                    break;
            }
        }

        private void txtFileName_MouseEnter(object sender, EventArgs e)
        {
            if (chkBoxKeepFilenames.Checked == false)
            {
                CustomTooltip.DisplayTooltip("Image files get number suffixes if multiple files get converted. Ex: image_1.jpg, image_2.jpg...", txtFileName, 600);
            }
        }

        private void txtFileName_MouseLeave(object sender, EventArgs e)
        {
            if (chkBoxKeepFilenames.Checked == false)
            {
                CustomTooltip.Dispose();
            }
        }

        private void chkBoxKeepFilenames_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxKeepFilenames.Checked == true)
            {
                txtFileName.Enabled = false;
                txtFileName.BackColor = System.Drawing.Color.Silver;
            }
            else
            {
                txtFileName.Enabled = true;
                txtFileName.BackColor = System.Drawing.Color.GhostWhite;
            }
        }

        private void listFileEntries_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                DisplayPreviewImage(listFileEntries.Items[e.ItemIndex].Tag.ToString());
            }
        }

        public SixLabors.ImageSharp.Image<Rgba32> RenderPreview(String filePath)
        {
            Reader reader = new Reader();
            SixLabors.ImageSharp.Image<Rgba32> image = reader.ReadFile(filePath);
            if (image != null)
            {
                ImageFilters filters = new ImageFilters();
                int iconsChecked = 0;
                if (FilterSettings.isIconBTN) iconsChecked++;
                if (FilterSettings.isIconPAS) iconsChecked++;
                if (FilterSettings.isIconATC) iconsChecked++;
                if (FilterSettings.isIconDISBTN) iconsChecked++;

                if (iconsChecked <= 1) // Classic icons
                {
                    if (FilterSettings.isIconBTN) image = filters.AddIconBorder(image, IconTypes.BTN);
                    if (FilterSettings.isIconPAS) image = filters.AddIconBorder(image, IconTypes.PAS);
                    if (FilterSettings.isIconATC) image = filters.AddIconBorder(image, IconTypes.ATC);
                    if (FilterSettings.isIconDISBTN) image = filters.AddIconBorder(image, IconTypes.DISBTN);
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

        private void listFileEntries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteRowsInList();
            }
        }

        private void DeleteRowsInList()
        {
            int indexFirstSelected = listFileEntries.SelectedItems[0].Index;
            int count = listFileEntries.SelectedItems.Count;
            for (int i = 0; i < count; i++)
            {
                listFileEntries.Items.Remove(listFileEntries.SelectedItems[0]);
            }

            if (listFileEntries.Items.Count > indexFirstSelected)
            {
                listFileEntries.Items[indexFirstSelected].Selected = true;
            }
            else if (listFileEntries.Items.Count > 0)
            {
                listFileEntries.Items[indexFirstSelected - 1].Selected = true;
            }
            else
            {
                imagePreview.Image = null;
                currentPreviewReferenceImage = null;
                lblFileSize.Text = "";
                lblResolution.Text = "";
            }

            lblItems.Text = "Items: " + listFileEntries.Items.Count;
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            bool ok = false;
            DialogResult dialogResult = MessageBox.Show("This action will clear the list. Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                ok = false;
            }
            else
            {
                ok = true;
            }
            if (ok)
            {
                listFileEntries.Items.Clear();
                verifyListAndOutputDirectory();
                imagePreview.Image = null;
                currentPreviewReferenceImage = null;
                lblFileSize.Text = "";
                lblResolution.Text = "";
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            panelImportContent.Location = new System.Drawing.Point((int)((groupBoxImport.Width * 0.5) - (panelImportContent.Width * 0.5)), panelImportContent.Location.Y);
        }

        private void previewSplitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            CenterAndScalePreviewImage();
            lblResolution.Location = new System.Drawing.Point(previewSplitContainer.Location.X + previewSplitContainer.Panel1.Width, previewSplitContainer.Location.Y + previewSplitContainer.Panel2.Height);
            btnFilters.Location = new System.Drawing.Point(previewSplitContainer.Location.X + previewSplitContainer.Panel1.Width + 4, previewSplitContainer.Location.Y - btnFilters.Height - 2);
            lblItems.Location = new System.Drawing.Point(previewSplitContainer.Location.X, previewSplitContainer.Location.Y + previewSplitContainer.Panel1.Height);
        }

        private void CenterAndScalePreviewImage()
        {
            if (currentPreviewReferenceImage != null)
            {
                float sourceImgRatio = (float)currentPreviewReferenceImage.Width / (float)currentPreviewReferenceImage.Height;
                float previewWindowRatio = (float)previewSplitContainer.Panel2.Width / (float)previewSplitContainer.Panel2.Height;
                System.Drawing.Size correctedSize;
                if (previewWindowRatio > sourceImgRatio)
                {
                    correctedSize = new System.Drawing.Size((int)(previewSplitContainer.Panel2.Height * sourceImgRatio), (int)previewSplitContainer.Panel2.Height);
                }
                else
                {
                    correctedSize = new System.Drawing.Size((int)previewSplitContainer.Panel2.Width, (int)(previewSplitContainer.Panel2.Width / sourceImgRatio));
                }

                // Preview size exceeds image size
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

            System.Drawing.Point previewCenter = new System.Drawing.Point((previewSplitContainer.Panel2.Width / 2) - (imagePreview.Width / 2), (previewSplitContainer.Panel2.Height / 2) - (imagePreview.Height / 2));
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

        private void checkBoxSubFolders_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Scans all subfolders when importing a folder.", checkBoxSubFolders, 600);
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            Converter converter = new Converter(); // filtering will not work because of the new systems
            Filters dialog = new Filters(converter);
            dialog.StartPosition = FormStartPosition.Manual;
            dialog.Location = this.Location;
            dialog.ShowDialog();

            // Reload preview image when dialog window closes.
            if (listFileEntries.SelectedItems.Count > 0)
            {
                
                DisplayPreviewImage(listFileEntries.SelectedItems[0].Tag.ToString());
            }
        }
    }
}