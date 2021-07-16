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
    public partial class ImportControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler OnButtonClickSingle;

        public ImportControl()
        {
            InitializeComponent();
        }

        public void btnInputFile_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.OnButtonClickSingle != null)
                this.OnButtonClickSingle(this, e);
        }
    }
}
