using Image_Converter.Image_Processing;
using Image_Converter.IO;
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
            checkBoxButton.Checked = FilterSettings.isButtonIcon;
            checkBoxPassive.Checked = FilterSettings.isPassiveIcon;
            checkBoxAutocast.Checked = FilterSettings.isAutocastIcon;
            checkBoxDisabled.Checked = FilterSettings.isDisabledIcon;
            checkBoxIsBLP2.Checked = FilterSettings.isBLP2;
            checkBoxResize.Checked = FilterSettings.isResized;
            upDownSizeX.Text = FilterSettings.resizeX.ToString();
            upDownSizeY.Text = FilterSettings.resizeY.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (radioBtnNone.Checked) converter.war3IconType = 0;
            if (radioBtnClassic.Checked) converter.war3IconType = 1;
            if (radioBtnReforged.Checked) converter.war3IconType = 2;

            FilterSettings.isButtonIcon = checkBoxButton.Checked;
            FilterSettings.isButtonIconRef = checkBoxButton.Checked;
            FilterSettings.isPassiveIcon = checkBoxPassive.Checked;
            FilterSettings.isPassiveIconRef = checkBoxPassive.Checked;
            FilterSettings.isAutocastIcon = checkBoxAutocast.Checked;
            FilterSettings.isAutocastIconRef = checkBoxAutocast.Checked;
            FilterSettings.isDisabledIcon = checkBoxDisabled.Checked;
            FilterSettings.isDisabledIconRef = checkBoxDisabled.Checked;
            FilterSettings.isResized = checkBoxResize.Checked;
            FilterSettings.resizeX = int.Parse(upDownSizeX.Text);
            FilterSettings.resizeY = int.Parse(upDownSizeY.Text);

            Dispose();
        }

        private void checkBoxIsBLP2_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isBLP2 = checkBoxIsBLP2.Checked;
        }

        private void checkBoxIsBLP2_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Toggles color format for BLP images (BLP2 = World of Warcraft)", checkBoxIsBLP2, 600);
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
            lblInfo2.Text = "Only applies on 256x256 images.";
        }

        private void checkBoxResize_CheckedChanged(object sender, EventArgs e)
        {
            upDownSizeX.Enabled = checkBoxResize.Checked;
            upDownSizeY.Enabled = checkBoxResize.Checked;
        }
    }
}
