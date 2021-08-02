using Image_Converter.Forms.New;
using Image_Converter.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Converter.Forms
{
    public partial class ExportControl : UserControl
    {
        Converter converter;

        public ExportControl()
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
        }

        public void UpdateExportSettings()
        {
            ExportSettings.fileName = txtFileName.Text;
            ExportSettings.outputDir = lblOutputDirectory.Text + @"\";
            ExportSettings.selectedFileExtension = (ImageFormats)cmboxOutputFormat.SelectedIndex;
            ExportSettings.keepFileNames = chkBoxKeepFilenames.Checked;
            ExportSettings.imageQualityJpeg = trckbarImageQuality.Value * 10;
            ExportSettings.selectedDDSCompression = cmboxDDSList.SelectedIndex;
            ExportSettings.generateMipMaps = chkBoxMipmaps.Checked;
            if (radBtnFastest.Checked)
                ExportSettings.selectedDDSCompressionQuality = 0;
            else if (radBtnBalanced.Checked)
                ExportSettings.selectedDDSCompressionQuality = 1;
            else
                ExportSettings.selectedDDSCompressionQuality = 2;
        }

        public void ExportSingle(string fileEntry)
        {
            DialogBoxResult dialog = new DialogBoxResult("Convert Single File", "This action converts '" + fileEntry + "' with specified settings to the output directory.");
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ShowDialog(this);
            if (dialog.ok == true)
            {
                converter = new Converter();
                converter.fileEntries = new string[] { fileEntry };

                bool success = converter.ConvertWithFilters();

                if (success)
                {
                    DialogBoxMessage message = new DialogBoxMessage("Success", "Conversion successful!");
                    message.StartPosition = FormStartPosition.CenterParent;
                    message.ShowDialog(this);
                }
                else
                {
                    DialogBoxMessage message = new DialogBoxMessage("Error", "Error: " + converter.errorMsg);
                    message.StartPosition = FormStartPosition.CenterParent;
                    message.ShowDialog(this);
                }
            }
        }

        public void ExportAll(List<string> fileEntries)
        {
            if (workerThread.IsBusy != true)
            {
                converter = new Converter();
                converter.fileEntries = fileEntries.ToArray();
                // Start the asynchronous operation.
                workerThread.RunWorkerAsync();
            }
        }

        private void workerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int endIndex = converter.fileEntries.Length;

            for (int i = 0; i < endIndex; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    bool isConvertSuccess = converter.ConvertWithFilters(); // convert

                    if (isConvertSuccess)
                    {
                        worker.ReportProgress(i * 10000 / endIndex);
                    }
                    else
                    {
                        Shared shared = new Shared();
                        string[] error = { shared.GetFileNameAndExtension(converter.fileEntries[i]), converter.errorMsg };
                        worker.ReportProgress(i * 10000 / endIndex, error);
                        converter.totalErrors++;
                    }
                }
            }
        }

        private void workerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblPercent.Text = ((e.ProgressPercentage / 100).ToString() + "%");
            progressBar.Value = e.ProgressPercentage / 100;
            lblProgress.Text = e.ProgressPercentage * converter.fileEntries.Length / 10000 + "/" + converter.fileEntries.Length;
            if (e.UserState != null)
            {
                object item = e.UserState;
                string[] item2 = (string[])item;
                ListViewItem listItem = new ListViewItem(item2);
                listErrors.Items.Add(listItem);
                lblErrors.Text = "Errors: " + converter.totalErrors;
                lblErrors.ForeColor = Color.FromArgb(255, 100, 100);
            }
        }

        private void workerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnExportAll.Text = "Export All";
            btnShowFolder.BackColor = Color.FromArgb(255, 124, 10);
            btnShowFolder.Enabled = true;
            if (e.Cancelled)
            {
                lblPercent.Text = "Stopped";
            }
            else
            {
                progressBar.Value = 100;
                lblPercent.Text = "Completed!";
                lblProgress.Text = converter.fileEntries.Length + "/" + converter.fileEntries.Length;
            }
        }

        public int GetExportBoxSizeX()
        {
            return groupBoxExportSettings.Size.Width;
        }

        private void trckbarImageQuality_Scroll(object sender)
        {
            lblImageQuality.Text = trckbarImageQuality.Value.ToString();
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

        private void btnOutputFile_Click(object sender, EventArgs e)
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
                    ExportSettings.outputDir = fbd.SelectedPath + @"\";
                    lblOutputDirectory.Text = fbd.SelectedPath + @"\";
                    btnExportAll.Enabled = true;
                    btnExportAll.BackColor = Color.FromArgb(255, 124, 10);
                    btnExportAll.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
                }
            }
        }

        private void chkBoxKeepFilenames_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxKeepFilenames.Checked)
            {
                txtFileName.Enabled = false;
                txtFileName.BackColor = Color.Gray;
            }
            else
            {
                txtFileName.Enabled = true;
                txtFileName.BackColor = Color.White;

            }
        }

        private void btnShowFolder_Click(object sender, EventArgs e)
        {
            string dir = ExportSettings.outputDir.Substring(0, ExportSettings.outputDir.Length - 1);
            Process.Start("explorer.exe", dir);
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks 'Export All'")]
        public event EventHandler OnExportAll;

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            if (workerThread.IsBusy != true)
            {

                DialogBoxResult dialog = new DialogBoxResult("Confirmation", "This action will overwrite any existing files with the same name in the output directory." +
                "\n\nDo you want to continue?");
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog(this);
                if (dialog.ok == true)
                {
                    btnExportAll.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 100, 100);
                    btnExportAll.Text = "Stop";
                    listErrors.Items.Clear();
                    //bubble the event up to the parent
                    if (this.OnExportAll != null)
                        this.OnExportAll(this, e);
                }
            } else
            {
                btnExportAll.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
                btnExportAll.Text = "Export All";

                // Cancel the asynchronous operation.
                workerThread.CancelAsync();
            }
        }

        private void txtFileName_MouseHover(object sender, EventArgs e)
        {
            if (chkBoxKeepFilenames.Checked == false)
            {
                CustomTooltip.DisplayTooltip("Files get number suffixes when exporting multiple files. Ex: image_1.jpg, image_2.jpg...", txtFileName, 600);
            }
        }
    }
}
