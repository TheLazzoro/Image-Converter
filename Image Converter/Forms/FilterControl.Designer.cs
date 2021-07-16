
namespace Image_Converter.Forms
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.radioBtnClassic = new System.Windows.Forms.RadioButton();
            this.checkBoxInfoUpgrade = new System.Windows.Forms.CheckBox();
            this.checkBoxInfoBasic = new System.Windows.Forms.CheckBox();
            this.checkBoxDisabled = new System.Windows.Forms.CheckBox();
            this.checkBoxAutocast = new System.Windows.Forms.CheckBox();
            this.checkBoxPassive = new System.Windows.Forms.CheckBox();
            this.checkBoxButton = new System.Windows.Forms.CheckBox();
            this.radioBtnReforged = new System.Windows.Forms.RadioButton();
            this.radioBtnNone = new System.Windows.Forms.RadioButton();
            this.checkBoxIsBLP2 = new System.Windows.Forms.CheckBox();
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
            this.upDownSizeY.Location = new System.Drawing.Point(204, 215);
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
            // 
            // upDownSizeX
            // 
            this.upDownSizeX.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.upDownSizeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upDownSizeX.Enabled = false;
            this.upDownSizeX.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.upDownSizeX.Location = new System.Drawing.Point(110, 216);
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
            // 
            // lblSizeY
            // 
            this.lblSizeY.AutoSize = true;
            this.lblSizeY.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSizeY.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSizeY.Location = new System.Drawing.Point(181, 217);
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
            this.lblSizeX.Location = new System.Drawing.Point(86, 217);
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
            this.checkBoxResize.Location = new System.Drawing.Point(3, 216);
            this.checkBoxResize.Name = "checkBoxResize";
            this.checkBoxResize.Size = new System.Drawing.Size(67, 20);
            this.checkBoxResize.TabIndex = 44;
            this.checkBoxResize.Text = "Resize:";
            this.checkBoxResize.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.lblInfo);
            this.groupBox.Controls.Add(this.lblInfo2);
            this.groupBox.Controls.Add(this.radioBtnClassic);
            this.groupBox.Controls.Add(this.checkBoxInfoUpgrade);
            this.groupBox.Controls.Add(this.checkBoxInfoBasic);
            this.groupBox.Controls.Add(this.checkBoxDisabled);
            this.groupBox.Controls.Add(this.checkBoxAutocast);
            this.groupBox.Controls.Add(this.checkBoxPassive);
            this.groupBox.Controls.Add(this.checkBoxButton);
            this.groupBox.Controls.Add(this.radioBtnReforged);
            this.groupBox.Controls.Add(this.radioBtnNone);
            this.groupBox.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(265, 172);
            this.groupBox.TabIndex = 43;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Warcraft III Icon Borders";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Enabled = false;
            this.lblInfo.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.lblInfo.Location = new System.Drawing.Point(7, 125);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(252, 16);
            this.lblInfo.TabIndex = 35;
            this.lblInfo.Text = "Converts image with each selected border.";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(10)))));
            this.lblInfo2.Location = new System.Drawing.Point(7, 149);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(256, 16);
            this.lblInfo2.TabIndex = 36;
            this.lblInfo2.Text = "Only applies on 256x256 or 128x128 images.";
            this.lblInfo2.Visible = false;
            // 
            // radioBtnClassic
            // 
            this.radioBtnClassic.AutoSize = true;
            this.radioBtnClassic.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioBtnClassic.Location = new System.Drawing.Point(91, 21);
            this.radioBtnClassic.Name = "radioBtnClassic";
            this.radioBtnClassic.Size = new System.Drawing.Size(67, 20);
            this.radioBtnClassic.TabIndex = 41;
            this.radioBtnClassic.Text = "Classic";
            this.radioBtnClassic.UseVisualStyleBackColor = true;
            // 
            // checkBoxInfoUpgrade
            // 
            this.checkBoxInfoUpgrade.AutoSize = true;
            this.checkBoxInfoUpgrade.Enabled = false;
            this.checkBoxInfoUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxInfoUpgrade.Location = new System.Drawing.Point(162, 96);
            this.checkBoxInfoUpgrade.Name = "checkBoxInfoUpgrade";
            this.checkBoxInfoUpgrade.Size = new System.Drawing.Size(98, 19);
            this.checkBoxInfoUpgrade.TabIndex = 40;
            this.checkBoxInfoUpgrade.Text = "Info-Upgrade";
            this.checkBoxInfoUpgrade.UseVisualStyleBackColor = true;
            // 
            // checkBoxInfoBasic
            // 
            this.checkBoxInfoBasic.AutoSize = true;
            this.checkBoxInfoBasic.Enabled = false;
            this.checkBoxInfoBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxInfoBasic.Location = new System.Drawing.Point(162, 72);
            this.checkBoxInfoBasic.Name = "checkBoxInfoBasic";
            this.checkBoxInfoBasic.Size = new System.Drawing.Size(80, 19);
            this.checkBoxInfoBasic.TabIndex = 39;
            this.checkBoxInfoBasic.Text = "Info-Basic";
            this.checkBoxInfoBasic.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisabled
            // 
            this.checkBoxDisabled.AutoSize = true;
            this.checkBoxDisabled.Enabled = false;
            this.checkBoxDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxDisabled.Location = new System.Drawing.Point(162, 46);
            this.checkBoxDisabled.Name = "checkBoxDisabled";
            this.checkBoxDisabled.Size = new System.Drawing.Size(75, 19);
            this.checkBoxDisabled.TabIndex = 38;
            this.checkBoxDisabled.Text = "Disabled";
            this.checkBoxDisabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutocast
            // 
            this.checkBoxAutocast.AutoSize = true;
            this.checkBoxAutocast.Enabled = false;
            this.checkBoxAutocast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxAutocast.Location = new System.Drawing.Point(6, 96);
            this.checkBoxAutocast.Name = "checkBoxAutocast";
            this.checkBoxAutocast.Size = new System.Drawing.Size(72, 19);
            this.checkBoxAutocast.TabIndex = 37;
            this.checkBoxAutocast.Text = "Autocast";
            this.checkBoxAutocast.UseVisualStyleBackColor = true;
            // 
            // checkBoxPassive
            // 
            this.checkBoxPassive.AutoSize = true;
            this.checkBoxPassive.Enabled = false;
            this.checkBoxPassive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPassive.Location = new System.Drawing.Point(6, 72);
            this.checkBoxPassive.Name = "checkBoxPassive";
            this.checkBoxPassive.Size = new System.Drawing.Size(68, 19);
            this.checkBoxPassive.TabIndex = 36;
            this.checkBoxPassive.Text = "Passive";
            this.checkBoxPassive.UseVisualStyleBackColor = true;
            // 
            // checkBoxButton
            // 
            this.checkBoxButton.AutoSize = true;
            this.checkBoxButton.Enabled = false;
            this.checkBoxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxButton.Location = new System.Drawing.Point(6, 46);
            this.checkBoxButton.Name = "checkBoxButton";
            this.checkBoxButton.Size = new System.Drawing.Size(61, 19);
            this.checkBoxButton.TabIndex = 35;
            this.checkBoxButton.Text = "Button";
            this.checkBoxButton.UseVisualStyleBackColor = true;
            // 
            // radioBtnReforged
            // 
            this.radioBtnReforged.AutoSize = true;
            this.radioBtnReforged.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioBtnReforged.Location = new System.Drawing.Point(183, 21);
            this.radioBtnReforged.Name = "radioBtnReforged";
            this.radioBtnReforged.Size = new System.Drawing.Size(78, 20);
            this.radioBtnReforged.TabIndex = 5;
            this.radioBtnReforged.Text = "Reforged";
            this.radioBtnReforged.UseVisualStyleBackColor = true;
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
            // 
            // checkBoxIsBLP2
            // 
            this.checkBoxIsBLP2.AutoSize = true;
            this.checkBoxIsBLP2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsBLP2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBoxIsBLP2.Location = new System.Drawing.Point(3, 191);
            this.checkBoxIsBLP2.Name = "checkBoxIsBLP2";
            this.checkBoxIsBLP2.Size = new System.Drawing.Size(136, 20);
            this.checkBoxIsBLP2.TabIndex = 42;
            this.checkBoxIsBLP2.Text = "BLP2 Color Format";
            this.checkBoxIsBLP2.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.checkBoxIsBLP2);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(444, 350);
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
        private System.Windows.Forms.CheckBox checkBoxIsBLP2;
    }
}
