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
            checkBoxButton.Checked = converter.isButtonIcon;
            checkBoxPassive.Checked = converter.isPassiveIcon;
            checkBoxAutocast.Checked = converter.isAutocastIcon;
            checkBoxDisabled.Checked = converter.isDisabledIcon;
            checkBoxIsBLP2.Checked = converter.isBLP2;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void checkBoxButton_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxButton.Checked == true)
            {
                converter.isButtonIcon = true;
            }
            else
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

        private void checkBoxIsBLP2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsBLP2.Checked == true)
            {
                converter.isBLP2 = true;
            }
            else
            {
                converter.isBLP2 = false;
            }
        }

        private void checkBoxIsBLP2_MouseHover(object sender, EventArgs e)
        {
            //DisplayTooltip("Toggles color format for BLP images (BLP2 = World of Warcraft)", checkBoxIsBLP2, 600);
        }
    }
}
