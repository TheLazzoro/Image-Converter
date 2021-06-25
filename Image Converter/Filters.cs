using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Converter
{
    public partial class Filters : Form
    {
        Converter converter;
        public Filters(Converter converter)
        {
            InitializeComponent();
            this.converter = converter;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void checkBoxButton_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxButton.Checked == true)
            {
                converter.isButtonIcon = true;
            } else
            {
                converter.isButtonIcon = false;
            }
        }

        private void checkBoxPassive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassive.Checked == true)
            {
                converter.isPassiveIcon = true;
            }
            else
            {
                converter.isPassiveIcon = false;
            }
        }

        private void checkBoxAutocast_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutocast.Checked == true)
            {
                converter.isAutocastIcon = true;
            }
            else
            {
                converter.isAutocastIcon = false;
            }
        }

        private void checkBoxDisabled_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDisabled.Checked == true)
            {
                converter.isDisabledIcon = true;
            }
            else
            {
                converter.isDisabledIcon = false;
            }
        }
    }
}
