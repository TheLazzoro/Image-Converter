
namespace WarcraftImageLabGUI
{
    partial class FilterControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.upDownSizeY = new System.Windows.Forms.NumericUpDown();
            this.upDownSizeX = new System.Windows.Forms.NumericUpDown();
            this.lblSizeY = new System.Windows.Forms.Label();
            this.lblSizeX = new System.Windows.Forms.Label();
            this.checkBoxResize = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.checkBoxAutocastDisabled = new System.Windows.Forms.CheckBox();
            this.checkBoxPassiveDisabled = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.radioBtnClassic = new System.Windows.Forms.RadioButton();
            this.checkBoxInfoUpgrade = new System.Windows.Forms.CheckBox();
            this.checkBoxInfoBasic = new System.Windows.Forms.CheckBox();
            this.checkBoxButtonDisabled = new System.Windows.Forms.CheckBox();
            this.checkBoxAutocast = new System.Windows.Forms.CheckBox();
            this.checkBoxPassive = new System.Windows.Forms.CheckBox();
            this.checkBoxButton = new System.Windows.Forms.CheckBox();
            this.radioBtnReforged = new System.Windows.Forms.RadioButton();
            this.radioBtnNone = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSizeX)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // upDownSizeY
            // 
            this.upDownSizeY.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.upDownSizeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upDownSizeY.Enabled = false;
            this.upDownSizeY.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.upDownSizeY.Location = new System.Drawing.Point(208, 290);
            this.upDownSizeY.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.upDownSizeY.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.upDownSizeY.Name = "upDownSizeY";
            this.upDownSizeY.Size = new System.Drawing.Size(57, 23);
            this.upDownSizeY.TabIndex = 48;
            this.upDownSizeY.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.upDownSizeY.ValueChanged += new System.EventHandler(this.upDownSizeY_ValueChanged);
            // 
            // upDownSizeX
            // 
            this.upDownSizeX.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.upDownSizeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upDownSizeX.Enabled = false;
            this.upDownSizeX.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.upDownSizeX.Location = new System.Drawing.Point(114, 291);
            this.upDownSizeX.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.upDownSizeX.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.upDownSizeX.Name = "upDownSizeX";
            this.upDownSizeX.Size = new System.Drawing.Size(57, 23);
            this.upDownSizeX.TabIndex = 47;
            this.upDownSizeX.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.upDownSizeX.ValueChanged += new System.EventHandler(this.upDownSizeX_ValueChanged);
            // 
            // lblSizeY
            // 
            this.lblSizeY.AutoSize = true;
            this.lblSizeY.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSizeY.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSizeY.Location = new System.Drawing.Point(185, 292);
            this.lblSizeY.Name = "lblSizeY";
            this.lblSizeY.Size = new System.Drawing.Size(16, 16);
            this.lblSizeY.TabIndex = 46;
            this.lblSizeY.Text = "Y:";
            // 
            // lblSizeX
            // 
            this.lblSizeX.AutoSize = true;
            this.lblSizeX.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSizeX.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSizeX.Location = new System.Drawing.Point(90, 292);
            this.lblSizeX.Name = "lblSizeX";
            this.lblSizeX.Size = new System.Drawing.Size(17, 16);
            this.lblSizeX.TabIndex = 45;
            this.lblSizeX.Text = "X:";
            // 
            // checkBoxResize
            // 
            this.checkBoxResize.AutoSize = true;
            this.checkBoxResize.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxResize.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxResize.Location = new System.Drawing.Point(7, 291);
            this.checkBoxResize.Name = "checkBoxResize";
            this.checkBoxResize.Size = new System.Drawing.Size(67, 20);
            this.checkBoxResize.TabIndex = 44;
            this.checkBoxResize.Text = "Resize:";
            this.checkBoxResize.UseVisualStyleBackColor = true;
            this.checkBoxResize.CheckedChanged += new System.EventHandler(this.checkBoxResize_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.checkBoxAutocastDisabled);
            this.groupBox.Controls.Add(this.checkBoxPassiveDisabled);
            this.groupBox.Controls.Add(this.lblInfo);
            this.groupBox.Controls.Add(this.lblInfo2);
            this.groupBox.Controls.Add(this.radioBtnClassic);
            this.groupBox.Controls.Add(this.checkBoxInfoUpgrade);
            this.groupBox.Controls.Add(this.checkBoxInfoBasic);
            this.groupBox.Controls.Add(this.checkBoxButtonDisabled);
            this.groupBox.Controls.Add(this.checkBoxAutocast);
            this.groupBox.Controls.Add(this.checkBoxPassive);
            this.groupBox.Controls.Add(this.checkBoxButton);
            this.groupBox.Controls.Add(this.radioBtnReforged);
            this.groupBox.Controls.Add(this.radioBtnNone);
            this.groupBox.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox.Location = new System.Drawing.Point(7, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(382, 257);
            this.groupBox.TabIndex = 43;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Warcraft III Icons";
            // 
            // checkBoxAutocastDisabled
            // 
            this.checkBoxAutocastDisabled.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxAutocastDisabled.AutoSize = true;
            this.checkBoxAutocastDisabled.Enabled = false;
            this.checkBoxAutocastDisabled.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxAutocastDisabled.Location = new System.Drawing.Point(158, 107);
            this.checkBoxAutocastDisabled.Name = "checkBoxAutocastDisabled";
            this.checkBoxAutocastDisabled.Size = new System.Drawing.Size(69, 20);
            this.checkBoxAutocastDisabled.TabIndex = 43;
            this.checkBoxAutocastDisabled.Text = "DISATC";
            this.checkBoxAutocastDisabled.UseVisualStyleBackColor = true;
            this.checkBoxAutocastDisabled.CheckedChanged += new System.EventHandler(this.checkBoxAutocastDisabled_CheckedChanged);
            this.checkBoxAutocastDisabled.MouseHover += new System.EventHandler(this.checkBoxAutocastDisabled_MouseHover);
            // 
            // checkBoxPassiveDisabled
            // 
            this.checkBoxPassiveDisabled.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxPassiveDisabled.AutoSize = true;
            this.checkBoxPassiveDisabled.Enabled = false;
            this.checkBoxPassiveDisabled.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPassiveDisabled.Location = new System.Drawing.Point(158, 83);
            this.checkBoxPassiveDisabled.Name = "checkBoxPassiveDisabled";
            this.checkBoxPassiveDisabled.Size = new System.Drawing.Size(69, 20);
            this.checkBoxPassiveDisabled.TabIndex = 42;
            this.checkBoxPassiveDisabled.Text = "DISPAS";
            this.checkBoxPassiveDisabled.UseVisualStyleBackColor = true;
            this.checkBoxPassiveDisabled.CheckedChanged += new System.EventHandler(this.checkBoxPassiveDisabled_CheckedChanged);
            this.checkBoxPassiveDisabled.MouseHover += new System.EventHandler(this.checkBoxPassiveDisabled_MouseHover);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Enabled = false;
            this.lblInfo.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.lblInfo.Location = new System.Drawing.Point(7, 194);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(259, 16);
            this.lblInfo.TabIndex = 35;
            this.lblInfo.Text = "Exports image with each selected icon filter.";
            // 
            // lblInfo2
            // 
            this.lblInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.lblInfo2.Location = new System.Drawing.Point(7, 218);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(369, 36);
            this.lblInfo2.TabIndex = 36;
            this.lblInfo2.Text = "Only applies on 256x256 or 128x128 images.";
            this.lblInfo2.Visible = false;
            // 
            // radioBtnClassic
            // 
            this.radioBtnClassic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioBtnClassic.AutoSize = true;
            this.radioBtnClassic.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioBtnClassic.Location = new System.Drawing.Point(158, 20);
            this.radioBtnClassic.Name = "radioBtnClassic";
            this.radioBtnClassic.Size = new System.Drawing.Size(67, 20);
            this.radioBtnClassic.TabIndex = 41;
            this.radioBtnClassic.Text = "Classic";
            this.radioBtnClassic.UseVisualStyleBackColor = true;
            this.radioBtnClassic.CheckedChanged += new System.EventHandler(this.radioBtnClassic_CheckedChanged);
            // 
            // checkBoxInfoUpgrade
            // 
            this.checkBoxInfoUpgrade.AutoSize = true;
            this.checkBoxInfoUpgrade.Enabled = false;
            this.checkBoxInfoUpgrade.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxInfoUpgrade.Location = new System.Drawing.Point(6, 157);
            this.checkBoxInfoUpgrade.Name = "checkBoxInfoUpgrade";
            this.checkBoxInfoUpgrade.Size = new System.Drawing.Size(130, 20);
            this.checkBoxInfoUpgrade.TabIndex = 40;
            this.checkBoxInfoUpgrade.Text = "Infocard-Upgrade";
            this.checkBoxInfoUpgrade.UseVisualStyleBackColor = true;
            this.checkBoxInfoUpgrade.CheckedChanged += new System.EventHandler(this.checkBoxInfoUpgrade_CheckedChanged);
            // 
            // checkBoxInfoBasic
            // 
            this.checkBoxInfoBasic.AutoSize = true;
            this.checkBoxInfoBasic.Enabled = false;
            this.checkBoxInfoBasic.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxInfoBasic.Location = new System.Drawing.Point(6, 132);
            this.checkBoxInfoBasic.Name = "checkBoxInfoBasic";
            this.checkBoxInfoBasic.Size = new System.Drawing.Size(74, 20);
            this.checkBoxInfoBasic.TabIndex = 39;
            this.checkBoxInfoBasic.Text = "Infocard";
            this.checkBoxInfoBasic.UseVisualStyleBackColor = true;
            this.checkBoxInfoBasic.CheckedChanged += new System.EventHandler(this.checkBoxInfoBasic_CheckedChanged);
            // 
            // checkBoxButtonDisabled
            // 
            this.checkBoxButtonDisabled.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxButtonDisabled.AutoSize = true;
            this.checkBoxButtonDisabled.Enabled = false;
            this.checkBoxButtonDisabled.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxButtonDisabled.Location = new System.Drawing.Point(158, 57);
            this.checkBoxButtonDisabled.Name = "checkBoxButtonDisabled";
            this.checkBoxButtonDisabled.Size = new System.Drawing.Size(70, 20);
            this.checkBoxButtonDisabled.TabIndex = 38;
            this.checkBoxButtonDisabled.Text = "DISBTN";
            this.checkBoxButtonDisabled.UseVisualStyleBackColor = true;
            this.checkBoxButtonDisabled.CheckedChanged += new System.EventHandler(this.checkBoxButtonDisabled_CheckedChanged);
            this.checkBoxButtonDisabled.MouseHover += new System.EventHandler(this.checkBoxButtonDisabled_MouseHover);
            // 
            // checkBoxAutocast
            // 
            this.checkBoxAutocast.AutoSize = true;
            this.checkBoxAutocast.Enabled = false;
            this.checkBoxAutocast.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxAutocast.Location = new System.Drawing.Point(6, 107);
            this.checkBoxAutocast.Name = "checkBoxAutocast";
            this.checkBoxAutocast.Size = new System.Drawing.Size(48, 20);
            this.checkBoxAutocast.TabIndex = 37;
            this.checkBoxAutocast.Text = "ATC";
            this.checkBoxAutocast.UseVisualStyleBackColor = true;
            this.checkBoxAutocast.CheckedChanged += new System.EventHandler(this.checkBoxAutocast_CheckedChanged);
            this.checkBoxAutocast.MouseHover += new System.EventHandler(this.checkBoxAutocast_MouseHover);
            // 
            // checkBoxPassive
            // 
            this.checkBoxPassive.AutoSize = true;
            this.checkBoxPassive.Enabled = false;
            this.checkBoxPassive.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPassive.Location = new System.Drawing.Point(6, 83);
            this.checkBoxPassive.Name = "checkBoxPassive";
            this.checkBoxPassive.Size = new System.Drawing.Size(48, 20);
            this.checkBoxPassive.TabIndex = 36;
            this.checkBoxPassive.Text = "PAS";
            this.checkBoxPassive.UseVisualStyleBackColor = true;
            this.checkBoxPassive.CheckedChanged += new System.EventHandler(this.checkBoxPassive_CheckedChanged);
            this.checkBoxPassive.MouseHover += new System.EventHandler(this.checkBoxPassive_MouseHover);
            // 
            // checkBoxButton
            // 
            this.checkBoxButton.AutoSize = true;
            this.checkBoxButton.Enabled = false;
            this.checkBoxButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxButton.Location = new System.Drawing.Point(6, 57);
            this.checkBoxButton.Name = "checkBoxButton";
            this.checkBoxButton.Size = new System.Drawing.Size(49, 20);
            this.checkBoxButton.TabIndex = 35;
            this.checkBoxButton.Text = "BTN";
            this.checkBoxButton.UseVisualStyleBackColor = true;
            this.checkBoxButton.CheckedChanged += new System.EventHandler(this.checkBoxButton_CheckedChanged);
            this.checkBoxButton.MouseHover += new System.EventHandler(this.checkBoxButton_MouseHover);
            // 
            // radioBtnReforged
            // 
            this.radioBtnReforged.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnReforged.AutoSize = true;
            this.radioBtnReforged.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioBtnReforged.Location = new System.Drawing.Point(298, 21);
            this.radioBtnReforged.Name = "radioBtnReforged";
            this.radioBtnReforged.Size = new System.Drawing.Size(78, 20);
            this.radioBtnReforged.TabIndex = 5;
            this.radioBtnReforged.Text = "Reforged";
            this.radioBtnReforged.UseVisualStyleBackColor = true;
            this.radioBtnReforged.CheckedChanged += new System.EventHandler(this.radioBtnReforged_CheckedChanged);
            // 
            // radioBtnNone
            // 
            this.radioBtnNone.AutoSize = true;
            this.radioBtnNone.Checked = true;
            this.radioBtnNone.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioBtnNone.Location = new System.Drawing.Point(7, 21);
            this.radioBtnNone.Name = "radioBtnNone";
            this.radioBtnNone.Size = new System.Drawing.Size(55, 20);
            this.radioBtnNone.TabIndex = 0;
            this.radioBtnNone.TabStop = true;
            this.radioBtnNone.Text = "None";
            this.radioBtnNone.UseVisualStyleBackColor = true;
            this.radioBtnNone.CheckedChanged += new System.EventHandler(this.radioBtnNone_CheckedChanged);
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.upDownSizeY);
            this.Controls.Add(this.upDownSizeX);
            this.Controls.Add(this.lblSizeY);
            this.Controls.Add(this.lblSizeX);
            this.Controls.Add(this.checkBoxResize);
            this.Controls.Add(this.groupBox);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(396, 342);
            ((System.ComponentModel.ISupportInitialize)(this.upDownSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownSizeX)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown upDownSizeY;
        private System.Windows.Forms.NumericUpDown upDownSizeX;
        private System.Windows.Forms.Label lblSizeY;
        private System.Windows.Forms.Label lblSizeX;
        private System.Windows.Forms.CheckBox checkBoxResize;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.RadioButton radioBtnClassic;
        private System.Windows.Forms.CheckBox checkBoxInfoUpgrade;
        private System.Windows.Forms.CheckBox checkBoxInfoBasic;
        private System.Windows.Forms.CheckBox checkBoxDisabled;
        private System.Windows.Forms.CheckBox checkBoxAutocast;
        private System.Windows.Forms.CheckBox checkBoxPassive;
        private System.Windows.Forms.CheckBox checkBoxButton;
        private System.Windows.Forms.RadioButton radioBtnReforged;
        private System.Windows.Forms.RadioButton radioBtnNone;
        private System.Windows.Forms.CheckBox checkBoxPassiveDisabled;
        private System.Windows.Forms.CheckBox checkBoxButtonDisabled;
        private System.Windows.Forms.CheckBox checkBoxAutocastDisabled;
    }
}
