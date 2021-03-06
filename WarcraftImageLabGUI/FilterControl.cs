using ImageConverter;
using ImageConverter.Image_Processing;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarcraftImageLabGUI
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

        private void radioBtnNone_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.war3IconType = War3IconType.None;
            checkBoxButton.Enabled = !radioBtnNone.Checked;
            checkBoxPassive.Enabled = !radioBtnNone.Checked;
            checkBoxAutocast.Enabled = !radioBtnNone.Checked;
            checkBoxButtonDisabled.Enabled = !radioBtnNone.Checked;
            checkBoxPassiveDisabled.Enabled = !radioBtnNone.Checked;
            checkBoxAutocastDisabled.Enabled = !radioBtnNone.Checked;
            checkBoxInfoBasic.Enabled = !radioBtnNone.Checked;
            checkBoxInfoUpgrade.Enabled = !radioBtnNone.Checked;
            lblInfo.Enabled = !radioBtnNone.Checked;
            lblInfo2.Visible = !radioBtnNone.Checked;
            InvokeFilterChange(e);
        }

        private void radioBtnClassic_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.war3IconType = War3IconType.ClassicIcon;
            lblInfo2.Text = "Only applies on 64x64 images. All other images are skipped when exporting.";
            InvokeFilterChange(e);
        }

        private void radioBtnReforged_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.war3IconType = War3IconType.ReforgedIcon;
            lblInfo2.Text = "Only applies on 256x256 images. All other images are skipped when exporting.";
            InvokeFilterChange(e);
        }

        private void checkBoxButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isIconBTN = checkBoxButton.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxPassive_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isIconPAS = checkBoxPassive.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxAutocast_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isIconATC = checkBoxAutocast.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxButtonDisabled_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isIconDISBTN = checkBoxButtonDisabled.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxPassiveDisabled_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isIconDISPAS = checkBoxPassiveDisabled.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxAutocastDisabled_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isIconDISATC = checkBoxAutocastDisabled.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxInfoBasic_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isIconATT = checkBoxInfoBasic.Checked;
            InvokeFilterChange(e);
        }

        private void checkBoxInfoUpgrade_CheckedChanged(object sender, EventArgs e)
        {
            FilterSettings.isIconUPG = checkBoxInfoUpgrade.Checked;
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

        private void checkBoxButton_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Button", checkBoxButton, 600);
        }

        private void checkBoxPassive_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Passive", checkBoxPassive, 600);
        }

        private void checkBoxAutocast_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Autocast", checkBoxAutocast, 600);
        }

        private void checkBoxButtonDisabled_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Disabled Button", checkBoxButtonDisabled, 600);
        }

        private void checkBoxPassiveDisabled_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Disabled Passive", checkBoxPassiveDisabled, 600);
        }

        private void checkBoxAutocastDisabled_MouseHover(object sender, EventArgs e)
        {
            CustomTooltip.DisplayTooltip("Disabled Autocast", checkBoxAutocastDisabled, 600);
        }
    }
}
