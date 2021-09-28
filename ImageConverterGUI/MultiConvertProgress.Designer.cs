namespace ImageConverterGUI
{
    partial class MultiConvertProgress
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
            this.lblPercent = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.listErrors = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowFolder = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPercent.Location = new System.Drawing.Point(14, 74);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(61, 15);
            this.lblPercent.TabIndex = 5;
            this.lblPercent.Text = "Loading...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 58);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(352, 13);
            this.progressBar.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProgress.Location = new System.Drawing.Point(170, 74);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(196, 27);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "0/0";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblErrors.Location = new System.Drawing.Point(14, 130);
            this.lblErrors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(53, 15);
            this.lblErrors.TabIndex = 10;
            this.lblErrors.Text = "Errors: 0";
            // 
            // listErrors
            // 
            this.listErrors.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listErrors.Enabled = false;
            this.listErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listErrors.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listErrors.HideSelection = false;
            this.listErrors.Location = new System.Drawing.Point(14, 149);
            this.listErrors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listErrors.Name = "listErrors";
            this.listErrors.Size = new System.Drawing.Size(352, 111);
            this.listErrors.TabIndex = 11;
            this.listErrors.UseCompatibleStateImageBehavior = false;
            this.listErrors.View = System.Windows.Forms.View.Details;
            this.listErrors.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listErrors_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Path";
            this.columnHeader1.Width = 280;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileLocationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 26);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open file location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // btnShowFolder
            // 
            this.btnShowFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnShowFolder.Enabled = false;
            this.btnShowFolder.FlatAppearance.BorderSize = 0;
            this.btnShowFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowFolder.ForeColor = System.Drawing.Color.White;
            this.btnShowFolder.Location = new System.Drawing.Point(252, 115);
            this.btnShowFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnShowFolder.Name = "btnShowFolder";
            this.btnShowFolder.Size = new System.Drawing.Size(113, 27);
            this.btnShowFolder.TabIndex = 12;
            this.btnShowFolder.Text = "Show Folder";
            this.btnShowFolder.UseVisualStyleBackColor = false;
            this.btnShowFolder.Click += new System.EventHandler(this.btnShowFolder_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(279, 285);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(88, 27);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // MultiConvertProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 325);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnShowFolder);
            this.Controls.Add(this.listErrors);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MultiConvertProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Converting...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiConvertProgress_FormClosing);
            this.Load += new System.EventHandler(this.MultiConvertProgress_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.ListView listErrors;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.Button btnShowFolder;
        private System.Windows.Forms.Button btnStop;
    }
}