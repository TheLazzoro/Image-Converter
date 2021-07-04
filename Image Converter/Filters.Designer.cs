
namespace Image_Converter
{
    partial class Filters
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.checkBoxIsBLP2 = new System.Windows.Forms.CheckBox();
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
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(189, 233);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 27);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkBoxIsBLP2
            // 
            this.checkBoxIsBLP2.AutoSize = true;
            this.checkBoxIsBLP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsBLP2.Location = new System.Drawing.Point(12, 200);
            this.checkBoxIsBLP2.Name = "checkBoxIsBLP2";
            this.checkBoxIsBLP2.Size = new System.Drawing.Size(130, 19);
            this.checkBoxIsBLP2.TabIndex = 32;
            this.checkBoxIsBLP2.Text = "BLP2 Color Format";
            this.checkBoxIsBLP2.UseVisualStyleBackColor = true;
            this.checkBoxIsBLP2.CheckedChanged += new System.EventHandler(this.checkBoxIsBLP2_CheckedChanged);
            this.checkBoxIsBLP2.MouseHover += new System.EventHandler(this.checkBoxIsBLP2_MouseHover);
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
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(265, 172);
            this.groupBox.TabIndex = 34;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Warcraft III Icon Borders";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Enabled = false;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.lblInfo.Location = new System.Drawing.Point(7, 125);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(238, 15);
            this.lblInfo.TabIndex = 35;
            this.lblInfo.Text = "Converts image with each selected border.";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.lblInfo2.Location = new System.Drawing.Point(7, 149);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(251, 15);
            this.lblInfo2.TabIndex = 36;
            this.lblInfo2.Text = "Only applies on 256x256 or 128x128 images";
            this.lblInfo2.Visible = false;
            // 
            // radioBtnClassic
            // 
            this.radioBtnClassic.AutoSize = true;
            this.radioBtnClassic.Location = new System.Drawing.Point(91, 21);
            this.radioBtnClassic.Name = "radioBtnClassic";
            this.radioBtnClassic.Size = new System.Drawing.Size(64, 19);
            this.radioBtnClassic.TabIndex = 41;
            this.radioBtnClassic.Text = "Classic";
            this.radioBtnClassic.UseVisualStyleBackColor = true;
            this.radioBtnClassic.CheckedChanged += new System.EventHandler(this.radioBtnClassic_CheckedChanged);
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
            this.radioBtnReforged.Location = new System.Drawing.Point(183, 21);
            this.radioBtnReforged.Name = "radioBtnReforged";
            this.radioBtnReforged.Size = new System.Drawing.Size(76, 19);
            this.radioBtnReforged.TabIndex = 5;
            this.radioBtnReforged.Text = "Reforged";
            this.radioBtnReforged.UseVisualStyleBackColor = true;
            this.radioBtnReforged.CheckedChanged += new System.EventHandler(this.radioBtnReforged_CheckedChanged);
            // 
            // radioBtnNone
            // 
            this.radioBtnNone.AutoSize = true;
            this.radioBtnNone.Checked = true;
            this.radioBtnNone.Location = new System.Drawing.Point(7, 21);
            this.radioBtnNone.Name = "radioBtnNone";
            this.radioBtnNone.Size = new System.Drawing.Size(55, 19);
            this.radioBtnNone.TabIndex = 0;
            this.radioBtnNone.TabStop = true;
            this.radioBtnNone.Text = "None";
            this.radioBtnNone.UseVisualStyleBackColor = true;
            this.radioBtnNone.CheckedChanged += new System.EventHandler(this.radioBtnNone_CheckedChanged);
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 272);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.checkBoxIsBLP2);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(268, 310);
            this.Name = "Filters";
            this.ShowIcon = false;
            this.Text = "Filters";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox checkBoxIsBLP2;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton radioBtnNone;
        private System.Windows.Forms.RadioButton radioBtnReforged;
        private System.Windows.Forms.CheckBox checkBoxInfoUpgrade;
        private System.Windows.Forms.CheckBox checkBoxInfoBasic;
        private System.Windows.Forms.CheckBox checkBoxDisabled;
        private System.Windows.Forms.CheckBox checkBoxAutocast;
        private System.Windows.Forms.CheckBox checkBoxPassive;
        private System.Windows.Forms.CheckBox checkBoxButton;
        private System.Windows.Forms.RadioButton radioBtnClassic;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblInfo2;
    }
}