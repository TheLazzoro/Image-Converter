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
            
            if (converter.war3IconType == 0) radioBtnNone.Checked = true;
            if (converter.war3IconType == 1) radioBtnClassic.Checked = true;
            if (converter.war3IconType == 2) radioBtnReforged.Checked = true;
            checkBoxButton.Checked = converter.isButtonIcon;
            checkBoxPassive.Checked = converter.isPassiveIcon;
            checkBoxAutocast.Checked = converter.isAutocastIcon;
            checkBoxDisabled.Checked = converter.isDisabledIcon;
            checkBoxIsBLP2.Checked = converter.isBLP2;
            checkBoxResize.Checked = converter.isResized;
            upDownSizeX.Text = converter.resizeX.ToString();
            upDownSizeY.Text = converter.resizeY.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (radioBtnNone.Checked) converter.war3IconType = 0;
            if (radioBtnClassic.Checked) converter.war3IconType = 1;
            if (radioBtnReforged.Checked) converter.war3IconType = 2;

            converter.isButtonIcon = checkBoxButton.Checked;
            converter.isPassiveIcon = checkBoxPassive.Checked;
            converter.isAutocastIcon = checkBoxAutocast.Checked;
            converter.isDisabledIcon = checkBoxDisabled.Checked;
            converter.isResized = checkBoxResize.Checked;
            converter.resizeX = int.Parse(upDownSizeX.Text);
            converter.resizeY = int.Parse(upDownSizeY.Text);

            Dispose();
        }

        private void checkBoxIsBLP2_CheckedChanged(object sender, EventArgs e)
        {
            converter.isBLP2 = checkBoxIsBLP2.Checked;
        }

        private void checkBoxIsBLP2_MouseHover(object sender, EventArgs e)
        {
            //DisplayTooltip("Toggles color format for BLP images (BLP2 = World of Warcraft)", checkBoxIsBLP2, 600);
        }

        private void radioBtnNone_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxButton.Enabled = !radioBtnNone.Checked;
            checkBoxPassive.Enabled = !radioBtnNone.Checked;
            checkBoxAutocast.Enabled = !radioBtnNone.Checked;
            checkBoxDisabled.Enabled = !radioBtnNone.Checked;
            lblInfo.Enabled = !radioBtnNone.Checked;
            lblInfo2.Visible = !radioBtnNone.Checked;
        }

        private void radioBtnClassic_CheckedChanged(object sender, EventArgs e)
        {
            lblInfo2.Text = "Only applies on 64x64 images.";
        }

        private void radioBtnReforged_CheckedChanged(object sender, EventArgs e)
        {
            lblInfo2.Text = "Only applies on 128x128 or 256x256 images.";
        }

        private void checkBoxResize_CheckedChanged(object sender, EventArgs e)
        {
            upDownSizeX.Enabled = checkBoxResize.Checked;
            upDownSizeY.Enabled = checkBoxResize.Checked;
        }
    }
}
