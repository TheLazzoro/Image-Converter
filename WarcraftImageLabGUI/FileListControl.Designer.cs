
namespace WarcraftImageLabGUI
{
    partial class FileListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblItems = new System.Windows.Forms.Label();
            this.listFileEntries = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnClear = new System.Windows.Forms.Button();
            this.contextMenuStripFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblItems.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblItems.Location = new System.Drawing.Point(3, 251);
            this.lblItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(104, 15);
            this.lblItems.TabIndex = 33;
            this.lblItems.Text = "Items: 0";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listFileEntries
            // 
            this.listFileEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFileEntries.BackColor = System.Drawing.Color.Silver;
            this.listFileEntries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listFileEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listFileEntries.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listFileEntries.HideSelection = false;
            this.listFileEntries.Location = new System.Drawing.Point(3, 3);
            this.listFileEntries.Name = "listFileEntries";
            this.listFileEntries.Size = new System.Drawing.Size(276, 245);
            this.listFileEntries.TabIndex = 32;
            this.listFileEntries.UseCompatibleStateImageBehavior = false;
            this.listFileEntries.View = System.Windows.Forms.View.Details;
            this.listFileEntries.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listFileEntries_ItemSelectionChanged);
            this.listFileEntries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listFileEntries_KeyDown);
            this.listFileEntries.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listFileEntries_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Files";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 100;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClear.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClear.Location = new System.Drawing.Point(198, 251);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(81, 27);
            this.btnClear.TabIndex = 34;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // contextMenuStripFiles
            // 
            this.contextMenuStripFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileLocationToolStripMenuItem,
            this.removeFromListToolStripMenuItem,
            this.convertToolStripMenuItem});
            this.contextMenuStripFiles.Name = "contextMenuStripFiles";
            this.contextMenuStripFiles.Size = new System.Drawing.Size(181, 92);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.AccessibleDescription = "";
            this.openFileLocationToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFileLocationToolStripMenuItem.Text = "Export";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.AccessibleDescription = "";
            this.removeFromListToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeFromListToolStripMenuItem.Text = "Open File Location";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.convertToolStripMenuItem.Text = "Remove From List";
            this.convertToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // FileListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.listFileEntries);
            this.Name = "FileListControl";
            this.Size = new System.Drawing.Size(282, 292);
            this.contextMenuStripFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.ListView listFileEntries;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFiles;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
    }
}
