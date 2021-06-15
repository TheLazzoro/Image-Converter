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

namespace Image_Converter
{
    public partial class Main : Form
    {
        private ToolTip tt;
        private ConvertImage converter;

        public Main()
        {
            InitializeComponent();

            converter = new ConvertImage();

            // Must be added in this order to match ImageFormat enum
            cmboxOutputFormat.Items.Add("JPG");
            cmboxOutputFormat.Items.Add("PNG");
            cmboxOutputFormat.Items.Add("BMP");
            cmboxOutputFormat.Items.Add("TGA");
            cmboxOutputFormat.Items.Add("DDS");
            cmboxOutputFormat.SelectedIndex = 0;

            cmboxDDSList.Items.Add("BC1 (DXT1), RGB | no alpha");
            cmboxDDSList.Items.Add("BC1 (DXT1), RGB | 1 bit alpha");
            cmboxDDSList.Items.Add("BC2 (DXT2 or DTX3), RGBA | explicit alpha");
            cmboxDDSList.Items.Add("BC3 (DXT4 or DTX5), RGBA | interpolated alpha");
            cmboxDDSList.SelectedIndex = 0;

            // image preview layout
            imagePreview.SizeMode = PictureBoxSizeMode.AutoSize;
            previewSplitContainer.Panel2.AutoScroll = true;

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
                DisplayPreviewImage(selectedFileName);
                btnConvert.Enabled = true;
            }

            verifyListAndOutputDirectory();
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                //fbd.SelectedPath = lblFilePath.Text;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    String[] fileEntries = Directory.GetFiles(fbd.SelectedPath);
                    for (int i = 0; i < fileEntries.Length; i++)
                    {
                        using (Stream stream = new FileStream(fileEntries[i], FileMode.Open))
                        {
                            String[] row = { fileEntries[i], GetFileSizeString(stream) };
                            ListViewItem item = new ListViewItem(row);
                            listFileEntries.Items.Add(item);
                        }
                    }
                }
            }

            verifyListAndOutputDirectory();

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            List<string> fileEntries = new List<string>();
            for(int i = 0; i < listFileEntries.Items.Count; i++)
            {
                fileEntries.Add(listFileEntries.Items[i].Text);
            }
            converter.fileEntries = fileEntries.ToArray();
            converter.outputDir = lblOutputDirectory.Text + @"\";
            converter.fileName = txtFileName.Text;
            converter.keepFileNames = chkBoxKeepFilenames.Checked;
            converter.imageQualityJpeg = trckbarImageQuality.Value * 10; //calculates image quality for jpg
            converter.selectedDDSCompression = cmboxDDSList.SelectedIndex; // dds compression
            converter.generateMipMaps = chkBoxMipmaps.Checked; // dds mipmaps
            converter.Init(cmboxOutputFormat.SelectedIndex);
                    converter.isMultipleFiles = true;

                    DialogResult dialogResult = MessageBox.Show("This action will overwrite any existing files with the same name in the output directory." +
                        "\n\nDo you want to continue?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MultiConvertProgress dialog = new MultiConvertProgress(converter);
                dialog.outputDir = converter.outputDir;
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

        private void verifyListAndOutputDirectory()
        {
            if (listFileEntries.Items.Count > 0 && lblOutputDirectory.Text != null && lblOutputDirectory.Text != "")
            {
                btnConvert.Enabled = true;
                btnConvert.BackColor = Color.FromArgb(0, 175, 175);
            }
            else
            {
                btnConvert.Enabled = false;
                btnConvert.BackColor = Color.FromArgb(175, 175, 175);
            }
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
            }
            else if (cmboxOutputFormat.SelectedIndex == (int)ImageFormats.DDS)
            {
                label4.Visible = true;
                label4.Text = "Compression:";
                trckbarImageQuality.Visible = false;
                lblImageQuality.Visible = false;
                cmboxDDSList.Visible = true;
                chkBoxMipmaps.Visible = true;
            }
            else
            {
                label4.Visible = false;
                trckbarImageQuality.Visible = false;
                lblImageQuality.Visible = false;
                cmboxDDSList.Visible = false;
                chkBoxMipmaps.Visible = false;
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
                tt = new ToolTip();
                tt.InitialDelay = 0;
                tt.Show(string.Empty, txtFileName);
                tt.Show("Note: Images will be enumerated after its name. Ex: image_1.jpg, image_2.jpg...", txtFileName, 0);
            }
        }

        private void txtFileName_MouseLeave(object sender, EventArgs e)
        {
            if (chkBoxKeepFilenames.Checked == false)
            {
                tt.Dispose();
            }
        }

        private void radBtnMulti_MouseLeave(object sender, EventArgs e)
        {
            tt.Dispose();
        }

        private void chkBoxKeepFilenames_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxKeepFilenames.Checked == true)
            {
                txtFileName.Enabled = false;
                txtFileName.BackColor = Color.Silver;
            }
            else
            {
                txtFileName.Enabled = true;
                txtFileName.BackColor = Color.GhostWhite;
            }
        }

        private void listFileEntries_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                DisplayPreviewImage(listFileEntries.Items[e.ItemIndex].Text);
            }
        }

        private void DisplayPreviewImage(String filePath)
        {
            try
            {
                SixLabors.ImageSharp.Image<Rgba32> image = converter.ReadInputFile(filePath);
                if (image != null)
                {
                    Bitmap actualPreview = new Bitmap(image.Width, image.Height);
                    Rgba32 color;
                    for (int x = 0; x < image.Width; x++)
                    {
                        for (int y = 0; y < image.Height; y++)
                        {
                            color = image[x, y];
                            actualPreview.SetPixel(x, y, Color.FromArgb(color.A, color.R, color.G, color.B));
                        }
                    }
                    imagePreview.Width = actualPreview.Width;
                    imagePreview.Height = actualPreview.Height;
                    imagePreview.Image = actualPreview;

                    using (Stream stream = new FileStream(filePath, FileMode.Open))
                    {
                        lblFileSize.Text = GetFileSizeString(stream);
                    }
                    lblResolution.Text = "Resolution: " + image.Width + "x" + image.Height;

                    image.Dispose();
                }
                else
                {
                    MessageBox.Show("Unsupported format.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unsupported format.");
            }

            CenterPreviewImage();
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
            for(int i = textLength; i > 0; i--)
            {
                if(dotPlacementHelper % 3 == 0 && dotPlacementHelper != 0)
                {
                    finalText += "." + text.Substring(i-1, 1);
                } else
                {
                    finalText += text.Substring(i-1, 1);
                }
                dotPlacementHelper++;
            }

            char[] charArray = finalText.ToCharArray();
            Array.Reverse(charArray); // flips string

            return new string(charArray) + " " + howBigBytes;
        }

        private void groupBoxImport_DragDrop(object sender, DragEventArgs e)
        {
            List<string> fileEntries = new List<string>();
            foreach (var item in (string[])e.Data.GetData(DataFormats.FileDrop, false)) // loops through all selected items (files and folders)
            {
                if (Directory.Exists(item)) // checks if selected item is a folder
                {
                    string[] filesInSelectedDirectory = Directory.GetFiles(item); // grabs all files in selected directory
                    for (int i = 0; i < filesInSelectedDirectory.Length; i++)
                    {
                        fileEntries.Add(filesInSelectedDirectory[i]); // adds files from directory to the total fileEntries
                    }
                }
                else
                {
                    fileEntries.Add(item); // adds selected item to fileEntries (this is a single file)
                }
            }
            for (int i = 0; i < fileEntries.Count; i++)
            {
                using (Stream stream = new FileStream(fileEntries[i].ToString(), FileMode.Open))
                {
                    String[] row = { fileEntries[i], GetFileSizeString(stream) };
                    ListViewItem item = new ListViewItem(row);
                    listFileEntries.Items.Add(item);
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
                imagePreview.Width = 64;
                imagePreview.Height = 64;
                lblFileSize.Text = "";
                lblResolution.Text = "";
            }
        }

        private void previewSplitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            CenterPreviewImage();
            lblResolution.Location = new Point(previewSplitContainer.Location.X + previewSplitContainer.Panel1.Width, lblResolution.Location.Y);
        }

        private void CenterPreviewImage()
        {
            imagePreview.Location = new Point((previewSplitContainer.Panel2.Width / 2) - (imagePreview.Width / 2), (previewSplitContainer.Panel2.Height / 2) - (imagePreview.Height / 2));
        }
    }
}
