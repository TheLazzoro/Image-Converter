using Image_Converter.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Converter
{
    public partial class MultiConvertProgress : Form
    {
        public String outputDir;
        private int errors = 0;

        public MultiConvertProgress()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            start();
        }

        private void MultiConvertProgress_Load(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int endIndex = Converter.fileEntries.Length;

            for (int i = 0; i < endIndex; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    bool isConvertSuccess = Converter.ConvertWithFilters(); // convert

                    if(isConvertSuccess)
                    {
                        worker.ReportProgress(i * 10000 / endIndex);
                    } else
                    {
                        worker.ReportProgress(i * 10000 / endIndex, Converter.fileEntries[i]);
                        errors++;
                    }
                }
            }
        }

        private void start()
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblPercent.Text = ((e.ProgressPercentage / 100).ToString() + "%");
            progressBar.Value = e.ProgressPercentage / 100;
            lblProgress.Text = e.ProgressPercentage * Converter.fileEntries.Length / 10000 + "/" + Converter.fileEntries.Length;
            if (e.UserState != null)
            {
                object item = e.UserState;
                listErrors.Enabled = true;
                listErrors.Items.Add(item.ToString());
                lblErrors.Text = "Errors: " + errors;
                lblErrors.ForeColor = Color.Red;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStop.Text = "Close";
            btnShowFolder.BackColor = Color.FromArgb(0, 175, 175);
            btnShowFolder.Enabled = true;
            if (e.Cancelled)
            {
                lblPercent.Text = "Cancelled";
                this.Text = "Cancelled";
            } else
            {
                progressBar.Value = 100;
                lblPercent.Text = "Completed!";
                lblProgress.Text = Converter.fileEntries.Length + "/" + Converter.fileEntries.Length;
                this.Text = "Completed!";
            }
        }

        private void MultiConvertProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void listErrors_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listErrors.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(listErrors.SelectedItems[0].Text))
            {
                Process.Start("explorer.exe", "/select," + listErrors.SelectedItems[0].Text);
            }
        }

        private void btnShowFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", outputDir);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                if (backgroundWorker1.WorkerSupportsCancellation == true)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker1.CancelAsync();
                    btnStop.Text = "Close";
                }
            }
            else
            {
                Dispose();
            }
        }
    }
}
