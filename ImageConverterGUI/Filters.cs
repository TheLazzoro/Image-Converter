using ImageConverter;
using ImageConverter.Image_Processing;
using ImageConverter.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageConverterGUI
{
    public partial class Filters : Form
    {
        ImageFilters imageFilters;

        public Filters()
        {
            InitializeComponent();
            this.imageFilters = new ImageFilters();
            
            if (FilterSettings.war3IconType == War3IconType.None) radioBtnNone.Checked = true;
            if (FilterSettings.war3IconType == War3IconType.ClassicIcon) radioBtnClassic.Checked = true;
            if (FilterSettings.war3IconType == War3IconType.ReforgedIcon) radioBtnReforged.Checked = true;
            checkBoxButton.Checked = FilterSettings.isIconBTN;
            checkBoxPassive.Checked = FilterSettings.isIconPAS;
            checkBoxAutocast.Checked = FilterSettings.isIconATC;
            checkBoxDisabled.Checked = FilterSettings.isIconDISBTN;
            checkBoxIsBLP2.Checked = FilterSettings.isBLP2;
            checkBoxResize.Checked = FilterSettings.isResized;
            upDownSizeX.Text = FilterSettings.resizeX.ToString();
            upDownSizeY.Text = FilterSettings.resizeY.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (radioBtnNone.Checked) FilterSettings.war3IconType = War3IconType.None;
            if (radioBtnClassic.Checked) FilterSettings.war3IconType = War3IconType.ClassicIcon;
            if (radioBtnReforged.Checked) FilterSettings.war3IconType = War3IconType.ReforgedIcon;

            FilterSettings.isIconBTN = checkBoxButton.Checked;
            FilterSettings.isIconPAS = checkBoxPassive.Checked;
            FilterSettings.isIconATC = checkBoxAutocast.Checked;
            FilterSettings.isIconDISBTN = checkBoxDisabled.Checked;
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
