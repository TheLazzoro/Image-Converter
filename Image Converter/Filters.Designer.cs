
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
            this.checkBoxInfoUpgrade = new System.Windows.Forms.CheckBox();
            this.checkBoxInfoBasic = new System.Windows.Forms.CheckBox();
            this.checkBoxDisabled = new System.Windows.Forms.CheckBox();
            this.checkBoxAutocast = new System.Windows.Forms.CheckBox();
            this.checkBoxPassive = new System.Windows.Forms.CheckBox();
            this.checkBoxButton = new System.Windows.Forms.CheckBox();
            this.radioBtnAll = new System.Windows.Forms.RadioButton();
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
            this.btnClose.Location = new System.Drawing.Point(167, 232);
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
            this.checkBoxIsBLP2.Location = new System.Drawing.Point(12, 160);
            this.checkBoxIsBLP2.Name = "checkBoxIsBLP2";
            this.checkBoxIsBLP2.Size = new System.Drawing.Size(130, 19);
            this.checkBoxIsBLP2.TabIndex = 32;
            this.checkBoxIsBLP2.Text = "BLP2 Color Format";
            this.checkBoxIsBLP2.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.checkBoxInfoUpgrade);
            this.groupBox.Controls.Add(this.checkBoxInfoBasic);
            this.groupBox.Controls.Add(this.checkBoxDisabled);
            this.groupBox.Controls.Add(this.checkBoxAutocast);
            this.groupBox.Controls.Add(this.checkBoxPassive);
            this.groupBox.Controls.Add(this.checkBoxButton);
            this.groupBox.Controls.Add(this.radioBtnAll);
            this.groupBox.Controls.Add(this.radioBtnNone);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(243, 142);
            this.groupBox.TabIndex = 34;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Warcraft III Icon Borders";
            // 
            // checkBoxInfoUpgrade
            // 
            this.checkBoxInfoUpgrade.AutoSize = true;
            this.checkBoxInfoUpgrade.Enabled = false;
            this.checkBoxInfoUpgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxInfoUpgrade.Location = new System.Drawing.Point(139, 115);
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
            this.checkBoxInfoBasic.Location = new System.Drawing.Point(139, 91);
            this.checkBoxInfoBasic.Name = "checkBoxInfoBasic";
            this.checkBoxInfoBasic.Size = new System.Drawing.Size(80, 19);
            this.checkBoxInfoBasic.TabIndex = 39;
            this.checkBoxInfoBasic.Text = "Info-Basic";
            this.checkBoxInfoBasic.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisabled
            // 
            this.checkBoxDisabled.AutoSize = true;
            this.checkBoxDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxDisabled.Location = new System.Drawing.Point(139, 65);
            this.checkBoxDisabled.Name = "checkBoxDisabled";
            this.checkBoxDisabled.Size = new System.Drawing.Size(75, 19);
            this.checkBoxDisabled.TabIndex = 38;
            this.checkBoxDisabled.Text = "Disabled";
            this.checkBoxDisabled.UseVisualStyleBackColor = true;
            this.checkBoxDisabled.CheckedChanged += new System.EventHandler(this.checkBoxDisabled_CheckedChanged);
            // 
            // checkBoxAutocast
            // 
            this.checkBoxAutocast.AutoSize = true;
            this.checkBoxAutocast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxAutocast.Location = new System.Drawing.Point(7, 115);
            this.checkBoxAutocast.Name = "checkBoxAutocast";
            this.checkBoxAutocast.Size = new System.Drawing.Size(72, 19);
            this.checkBoxAutocast.TabIndex = 37;
            this.checkBoxAutocast.Text = "Autocast";
            this.checkBoxAutocast.UseVisualStyleBackColor = true;
            this.checkBoxAutocast.CheckedChanged += new System.EventHandler(this.checkBoxAutocast_CheckedChanged);
            // 
            // checkBoxPassive
            // 
            this.checkBoxPassive.AutoSize = true;
            this.checkBoxPassive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPassive.Location = new System.Drawing.Point(7, 91);
            this.checkBoxPassive.Name = "checkBoxPassive";
            this.checkBoxPassive.Size = new System.Drawing.Size(68, 19);
            this.checkBoxPassive.TabIndex = 36;
            this.checkBoxPassive.Text = "Passive";
            this.checkBoxPassive.UseVisualStyleBackColor = true;
            this.checkBoxPassive.CheckedChanged += new System.EventHandler(this.checkBoxPassive_CheckedChanged);
            // 
            // checkBoxButton
            // 
            this.checkBoxButton.AutoSize = true;
            this.checkBoxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxButton.Location = new System.Drawing.Point(7, 65);
            this.checkBoxButton.Name = "checkBoxButton";
            this.checkBoxButton.Size = new System.Drawing.Size(61, 19);
            this.checkBoxButton.TabIndex = 35;
            this.checkBoxButton.Text = "Button";
            this.checkBoxButton.UseVisualStyleBackColor = true;
            this.checkBoxButton.CheckedChanged += new System.EventHandler(this.checkBoxButton_CheckedChanged);
            // 
            // radioBtnAll
            // 
            this.radioBtnAll.AutoSize = true;
            this.radioBtnAll.Location = new System.Drawing.Point(139, 20);
            this.radioBtnAll.Name = "radioBtnAll";
            this.radioBtnAll.Size = new System.Drawing.Size(38, 19);
            this.radioBtnAll.TabIndex = 5;
            this.radioBtnAll.TabStop = true;
            this.radioBtnAll.Text = "All";
            this.radioBtnAll.UseVisualStyleBackColor = true;
            // 
            // radioBtnNone
            // 
            this.radioBtnNone.AutoSize = true;
            this.radioBtnNone.Location = new System.Drawing.Point(7, 21);
            this.radioBtnNone.Name = "radioBtnNone";
            this.radioBtnNone.Size = new System.Drawing.Size(55, 19);
            this.radioBtnNone.TabIndex = 0;
            this.radioBtnNone.TabStop = true;
            this.radioBtnNone.Text = "None";
            this.radioBtnNone.UseVisualStyleBackColor = true;
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 271);
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
        private System.Windows.Forms.RadioButton radioBtnAll;
        private System.Windows.Forms.CheckBox checkBoxInfoUpgrade;
        private System.Windows.Forms.CheckBox checkBoxInfoBasic;
        private System.Windows.Forms.CheckBox checkBoxDisabled;
        private System.Windows.Forms.CheckBox checkBoxAutocast;
        private System.Windows.Forms.CheckBox checkBoxPassive;
        private System.Windows.Forms.CheckBox checkBoxButton;
    }
}