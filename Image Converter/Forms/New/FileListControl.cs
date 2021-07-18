using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Image_Converter.Forms
{
    public partial class FileListControl : UserControl
    {
        Shared shared = new Shared();

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
                //bubble the event up to the parent
                if (this.OnClearList != null)
                    this.OnClearList(this, e);

                listFileEntries.Items.Clear();
                lblItems.Text = "Items: " + listFileEntries.Items.Count;
            }
        }

        public void AddFileToListSingle(string fileEntry, Stream stream)
        {
            string filename = shared.GetInputFileNameAndExtension(fileEntry);
            String[] row = { filename, shared.GetFileSizeString(stream) };
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
                    using (Stream stream = new FileStream(item.ToString(), FileMode.Open))
                    {
                        AddFileToListSingle(item, stream); // adds selected item to fileEntries (this is a single file)
                    }
                }
            }
            lblItems.Text = "Items: " + listFileEntries.Items.Count;
        }

        public string GetCurrentSelectedFile()
        {
            return listFileEntries.SelectedItems[0].Tag.ToString();
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
