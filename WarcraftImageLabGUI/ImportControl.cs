using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarcraftImageLabGUI
{
    public partial class ImportControl : UserControl
    {
        public ImportControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks single file button")]
        public event EventHandler OnButtonClickSingle;

        protected void btnInputFile_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.OnButtonClickSingle != null)
                this.OnButtonClickSingle(this, e);
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks multi file button")]
        public event EventHandler OnButtonClickMulti;

        private void btnInputFolder_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.OnButtonClickMulti != null)
                this.OnButtonClickMulti(this, e);
        }

        public bool isSubfoldersChecked()
        {
            return checkBoxSubFolders.Checked;
        }
    }
}
