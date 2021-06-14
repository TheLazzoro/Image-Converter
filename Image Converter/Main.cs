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

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (radBtnSingle.Checked == true)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                if (lblFilePath.Text == "")
                {
                    openFileDialog1.InitialDirectory = "c:\\";
                }
                else
                {
                    openFileDialog1.InitialDirectory = lblFilePath.Text;
                }
                //openFileDialog1.Filter = "Image Files (*.jpg, *.png. *.tiff, *.gif, *.bmp, *.tga)|*.jpg;*.png;*.tiff;*.gif;*.bmp;.tga;*";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog1.FileName;
                    lblFilePath.Text = selectedFileName;
                    btnConvert.Enabled = true;
                }

                checkBothSelected();

                DisplayPreviewImage(lblFilePath.Text);

            }
            if (radBtnMulti.Checked == true)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    if (lblFilePath.Text != "")
                    {
                        fbd.SelectedPath = lblFilePath.Text;
                    }
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        lblFilePath.Text = fbd.SelectedPath;
                        String[] fileEntries = Directory.GetFiles(lblFilePath.Text);
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
            }
            checkBothSelected();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (chkBoxKeepFilenames.Checked || txtFileName.Text != "" && txtFileName.Text != null)
            {
                converter = new ConvertImage();
                converter.outputDir = lblOutputDirectory.Text + @"\";
                converter.fileName = txtFileName.Text;
                converter.keepFileNames = chkBoxKeepFilenames.Checked;
                converter.imageQualityJpeg = trckbarImageQuality.Value * 10; //calculates image quality for jpg
                converter.selectedDDSCompression = cmboxDDSList.SelectedIndex; // dds compression
                converter.generateMipMaps = chkBoxMipmaps.Checked; // dds mipmaps
                converter.Init(cmboxOutputFormat.SelectedIndex);


                if (radBtnSingle.Checked == true)
                {
                    String outputPath = lblOutputDirectory.Text + @"\" + txtFileName.Text + converter.outputFiletype;
                    String[] fileToConvert = new String[1];
                    fileToConvert[0] = lblFilePath.Text;
                    converter.fileEntries = fileToConvert;
                    converter.isMultipleFiles = false;

                    bool ok = true;
                    if (File.Exists(outputPath))
                    {
                        DialogResult dialogResult = MessageBox.Show("This folder already contains a file named '" + txtFileName.Text + converter.outputFiletype +
                            "'.\n\nDo you want to overwrite?", "Confirmation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            ok = false;
                        }
                    }
                    if (ok)
                    {
                        bool isConvertSuccess = converter.Convert(); // convert
                        if (isConvertSuccess)
                        {
                            MessageBox.Show("Conversion successful!");
                        }
                        else
                        {
                            MessageBox.Show(converter.errorMsg);
                        }
                    }

                }
                else
                { // multi convert
                    String[] fileEntries = Directory.GetFiles(lblFilePath.Text);
                    converter.fileEntries = fileEntries;
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
            }
            else
            {
                MessageBox.Show("Invalid file name.");
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

            checkBothSelected();
        }

        private void checkBothSelected()
        {
            if (lblFilePath.Text != null && lblFilePath.Text != "" && lblOutputDirectory.Text != null && lblOutputDirectory.Text != "")
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

        private void radBtnMulti_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectImage.Text = "Select Folder:";
            lblFilePath.Text = "";
            checkBothSelected();
        }

        private void radBtnSingle_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectImage.Text = "Select Image file:";
            lblFilePath.Text = "";
            checkBothSelected();
        }

        private void txtFileName_MouseEnter(object sender, EventArgs e)
        {
            if (radBtnMulti.Checked == true)
            {
                tt = new ToolTip();
                tt.InitialDelay = 0;
                tt.Show(string.Empty, txtFileName);
                tt.Show("Note: Images will be enumerated after its name. Ex: image_1.jpg, image_2.jpg...", txtFileName, 0);
            }
        }

        private void txtFileName_MouseLeave(object sender, EventArgs e)
        {
            if (radBtnMulti.Checked == true)
            {
                tt.Dispose();
            }
        }

        private void radBtnMulti_MouseEnter(object sender, EventArgs e)
        {
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.Show(string.Empty, txtFileName);
            tt.Show("This setting converts an entire folder of images to the specified folder.", radBtnMulti, 0);
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
        }

        private String GetFileSizeString(Stream stream)
        {
            long length;
            length = stream.Length;
            String howBigBytes = "bytes";
            if (length > 1000000)
            {
                howBigBytes = "MB";
                length = length / 1000000;
            }
            else if (length > 1000)
            {
                howBigBytes = "KB";
                length = length / 1000;
            }
            
            return length.ToString() + " " + howBigBytes;
        }
    }
}
