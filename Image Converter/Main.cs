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

namespace Image_Converter
{
    public partial class Main : Form
    {
        private ToolTip tt;

        public Main()
        {
            InitializeComponent();
            cmboxOutputFormat.Items.Add("JPG");
            cmboxOutputFormat.Items.Add("PNG");
            cmboxOutputFormat.Items.Add("TIFF");
            cmboxOutputFormat.Items.Add("GIF");
            cmboxOutputFormat.Items.Add("BMP");
            cmboxOutputFormat.Items.Add("DDS");
            cmboxOutputFormat.SelectedIndex = 0;

            cmboxDDSList.Items.Add("DXT1");
            cmboxDDSList.SelectedIndex = 0;
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
                openFileDialog1.Filter = "Image Files (*.jpg, *.png. *.tiff, *.gif, *.bmp, *.tga)|*.jpg;*.png;*.tiff;*.gif;*.bmp;.tga;*";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog1.FileName;
                    lblFilePath.Text = selectedFileName;
                    btnConvert.Enabled = true;
                }

                checkBothSelected();
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
            if (txtFileName.Text != "" && txtFileName.Text != null)
            {
                ConvertImage converter = new ConvertImage();
                converter.outputDir = lblOutputDirectory.Text + @"\";
                converter.fileName = txtFileName.Text;
                converter.imageQualityJpeg = trckbarImageQuality.Value * 10L; //calculates image quality if selected file type is .jpg.
                converter.Init(cmboxOutputFormat.SelectedIndex);

                if (cmboxOutputFormat.SelectedIndex == 5) // DDS selected
                {
                    converter.selectedDDSCompression = cmboxDDSList.SelectedIndex;
                }

                if (radBtnSingle.Checked == true)
                {
                    String outputPath = lblOutputDirectory.Text + @"\" + txtFileName.Text + converter.outputFiletype;
                    String[] fileToConvert = new String[1];
                    fileToConvert[0] = lblFilePath.Text;
                    converter.fileEntries = fileToConvert;

                    bool ok = true;
                    if (File.Exists(outputPath))
                    {
                        DialogResult dialogResult = MessageBox.Show("This folder already contains a file named '" + txtFileName.Text + converter.outputFiletype +
                            "'.\n\nDo you want to override?", "Confirmation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            ok = false;
                        }
                    }
                    if (ok)
                    {
                        bool isConvertSuccess = converter.Convert(false); // convert
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

                    DialogResult dialogResult = MessageBox.Show("This action will override any existing files with the same name in the output directory." +
                        "\n\nDo you want to continue?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MultiConvertProgress dialog = new MultiConvertProgress(converter);
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
            if (cmboxOutputFormat.SelectedIndex == 0)
            {
                label4.Visible = true;
                trckbarImageQuality.Visible = true;
                lblImageQuality.Visible = true;
                cmboxDDSList.Visible = false;

            }
            else if (cmboxOutputFormat.SelectedIndex == 5)
            {
                label4.Visible = false;
                trckbarImageQuality.Visible = false;
                lblImageQuality.Visible = false;
                cmboxDDSList.Visible = true;
            }
            else
            {
                label4.Visible = false;
                trckbarImageQuality.Visible = false;
                lblImageQuality.Visible = false;
                cmboxDDSList.Visible = false;
            }

            switch (cmboxOutputFormat.SelectedIndex)
            {
                case 0:
                    lblFileFormat.Text = ".jpg";
                    break;
                case 1:
                    lblFileFormat.Text = ".png";
                    break;
                case 2:
                    lblFileFormat.Text = ".tiff";
                    break;
                case 3:
                    lblFileFormat.Text = ".gif";
                    break;
                case 4:
                    lblFileFormat.Text = ".bmp";
                    break;
                case 5:
                    lblFileFormat.Text = ".dds";
                    break;
            }
        }

        private void radBtnMulti_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectImage.Text = "Select folder:";
            lblFilePath.Text = "";
            checkBothSelected();
        }

        private void radBtnSingle_CheckedChanged(object sender, EventArgs e)
        {
            lblSelectImage.Text = "Select image file:";
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
    }
}
