using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Converter.Forms.New
{
    public partial class DialogBoxResult : Form
    {
        public bool ok = false;

        public DialogBoxResult(string title, string message)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblMessage.Text = message;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ok = true;
            Dispose();
        }
    }
}
