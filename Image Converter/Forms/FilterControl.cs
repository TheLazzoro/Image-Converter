using Image_Converter.Image_Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Image_Converter.Forms
{
    public partial class FilterControl : UserControl
    {
        public FilterControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user selects filter option")]
        public event EventHandler OnFilterChanged;

        private void InvokeFilterChange(EventArgs e)
        {
            //bubble the event up to the parent
            if (this.OnFilterChanged != null)
                this.OnFilterChanged(this, e);
        }

        private void checkBoxIsBLP2_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Toggles color format for BLP images (BLP2 = World of Warcraft)", checkBoxIsBLP2, 600);
        }

        private void radioBtnNone_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.war3IconType = War3IconType.None;
            checkBoxButton.Enabled = !radioBtnNone.Checked;
            checkBoxPassive.Enabled = !radioBtnNone.Checked;
            checkBoxAutocast.Enabled = !radioBtnNone.Checked;
            checkBoxButtonDisabled.Enabled = !radioBtnNone.Checked;
            checkBoxPassiveDisabled.Enabled = !radioBtnNone.Checked;
            checkBoxAutocastDisabled.Enabled = !radioBtnNone.Checked;
            lblInfo.Enabled = !radioBtnNone.Checked;
            lblInfo2.Visible = !radioBtnNone.Checked;
            InvokeFilterChange(e);
        }

        private void radioBtnClassic_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.war3IconType = War3IconType.ClassicIcon;
            lblInfo2.Text = "Only applies on 64x64 images.";
            InvokeFilterChange(e);
        }

        private void radioBtnReforged_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.war3IconType = War3IconType.ReforgedIcon;
            lblInfo2.Text = "Only applies on 256x256 images.";
            InvokeFilterChange(e);
        }

        private void checkBoxButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isButtonIcon = checkBoxButton.Checked;
            FilterSettings.isButtonIconRef = checkBoxButton.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxPassive_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isPassiveIcon = checkBoxPassive.Checked;
            FilterSettings.isPassiveIconRef = checkBoxPassive.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxAutocast_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isAutocastIcon = checkBoxAutocast.Checked;
            FilterSettings.isAutocastIconRef = checkBoxAutocast.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxButtonDisabled_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isDisabledIcon = checkBoxButtonDisabled.Checked;
            FilterSettings.isDisabledIconRef = checkBoxButtonDisabled.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxIsBLP2_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isBLP2 = checkBoxIsBLP2.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxResize_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isResized = checkBoxResize.Checked;
            upDownSizeX.Enabled = checkBoxResize.Checked;
            upDownSizeY.Enabled = checkBoxResize.Checked;
            InvokeFilterChange(e);
        }

        private void upDownSizeX_ValueChanged(object sender, EventArgs e)
        {
            FilterSettings.resizeX = (int)upDownSizeX.Value;
            InvokeFilterChange(e);
        }

        private void upDownSizeY_ValueChanged(object sender, EventArgs e)
        {
            FilterSettings.resizeY = (int)upDownSizeY.Value;
            InvokeFilterChange(e);
        }
    }
}
