using Image_Converter;
using Image_Converter.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WarcraftImageLabGUI
{
    public partial class FileListControl : UserControl
    {
        public FileListControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes list selection")]
        public event EventHandler OnSelectionChanged;

        protected void listFileEntries_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                //bubble the event up to the parent
                if (this.OnSelectionChanged != null)
                    this.OnSelectionChanged(this, e);
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes list selection")]
        public event EventHandler OnClearList;

        protected void btnClear_Click(object sender, EventArgs e)
        {
            DialogBoxResult dialog = new DialogBoxResult("Confirmation", "This action will clear the list. Do you want to continue?");
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.ShowDialog(this);


            if (dialog.ok == true)
            {
                //bubble the event up to the parent
                if (this.OnClearList != null)
                    this.OnClearList(this, e);

                listFileEntries.Items.Clear();
                lblItems.Text = "Items: " + listFileEntries.Items.Count;
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks 'Export'")]
        public event EventHandler OnExportSingle;

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.OnExportSingle != null)
                this.OnExportSingle(this, e);
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

        private void listFileEntries_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listFileEntries.FocusedItem.Bounds.Contains(e.Location))
            {
                contextMenuStripFiles.Show(Cursor.Position);
                if (listFileEntries.Items.Count > 0 && ExportSettings.outputDir != "")
                {
                    contextMenuStripFiles.Items[0].Enabled = true;
                }
                else
                {
                    contextMenuStripFiles.Items[0].Enabled = false;
                }
            }
        }

        public void AddFileToListSingle(string fileEntry)
        {
            string filename = Shared.GetFileNameAndExtension(fileEntry);
            String[] row = { filename, Reader.GetFileSizeString(fileEntry) };
            ListViewItem item = new ListViewItem(row);
            item.Tag = fileEntry;
            listFileEntries.Items.Add(item);
            lblItems.Text = "Items: " + listFileEntries.Items.Count;
        }

        public void AddFilesInDirectory(string directoryPath, bool checkSubfolders)
        {
            string[] fileEntries;

            if (checkSubfolders == true)
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
                    AddFilesInDirectory(item, true); // Subfolder Recursion
                }
                else
                {
                    AddFileToListSingle(item); // adds selected item to fileEntries (this is a single file)
                }
            }
            lblItems.Text = "Items: " + listFileEntries.Items.Count;
        }

        public string GetCurrentSelectedFile()
        {
            if (listFileEntries.SelectedItems.Count > 0)
            {
                return listFileEntries.SelectedItems[0].Tag.ToString();
            }

            return null;
        }

        public ListView.ListViewItemCollection GetAllFileEntries()
        {
            return listFileEntries.Items;
        }

        private void listFileEntries_KeyDown(object sender, KeyEventArgs e)
        {
            if (listFileEntries.Items.Count == 0)
            {
                return;
            }

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
                /*
                imagePreview.Image = null;
                currentPreviewReferenceImage = null;
                lblFileSize.Text = "";
                lblResolution.Text = "";
                */
            }

            lblItems.Text = "Items: " + listFileEntries.Items.Count;
        }
    }
}
