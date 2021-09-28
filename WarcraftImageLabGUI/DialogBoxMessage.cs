using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarcraftImageLabGUI
{
    public partial class DialogBoxMessage : Form
    {
        public DialogBoxMessage(string title, string message)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblMessage.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
