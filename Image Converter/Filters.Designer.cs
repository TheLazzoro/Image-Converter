
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
            this.radioBtnNone = new System.Windows.Forms.RadioButton();
            this.radioBtnButton = new System.Windows.Forms.RadioButton();
            this.radioBtnPassive = new System.Windows.Forms.RadioButton();
            this.radioBtnAutocast = new System.Windows.Forms.RadioButton();
            this.radioBtnDisabled = new System.Windows.Forms.RadioButton();
            this.radioBtnAll = new System.Windows.Forms.RadioButton();
            this.radioBtnInfoBasic = new System.Windows.Forms.RadioButton();
            this.radioBtnInfoUpgrade = new System.Windows.Forms.RadioButton();
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
            this.groupBox.Controls.Add(this.radioBtnInfoUpgrade);
            this.groupBox.Controls.Add(this.radioBtnInfoBasic);
            this.groupBox.Controls.Add(this.radioBtnAll);
            this.groupBox.Controls.Add(this.radioBtnDisabled);
            this.groupBox.Controls.Add(this.radioBtnAutocast);
            this.groupBox.Controls.Add(this.radioBtnPassive);
            this.groupBox.Controls.Add(this.radioBtnButton);
            this.groupBox.Controls.Add(this.radioBtnNone);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(243, 142);
            this.groupBox.TabIndex = 34;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Warcraft III Icon Borders";
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
            // radioBtnButton
            // 
            this.radioBtnButton.AutoSize = true;
            this.radioBtnButton.Location = new System.Drawing.Point(7, 65);
            this.radioBtnButton.Name = "radioBtnButton";
            this.radioBtnButton.Size = new System.Drawing.Size(60, 19);
            this.radioBtnButton.TabIndex = 1;
            this.radioBtnButton.TabStop = true;
            this.radioBtnButton.Text = "Button";
            this.radioBtnButton.UseVisualStyleBackColor = true;
            // 
            // radioBtnPassive
            // 
            this.radioBtnPassive.AutoSize = true;
            this.radioBtnPassive.Location = new System.Drawing.Point(7, 90);
            this.radioBtnPassive.Name = "radioBtnPassive";
            this.radioBtnPassive.Size = new System.Drawing.Size(67, 19);
            this.radioBtnPassive.TabIndex = 2;
            this.radioBtnPassive.TabStop = true;
            this.radioBtnPassive.Text = "Passive";
            this.radioBtnPassive.UseVisualStyleBackColor = true;
            // 
            // radioBtnAutocast
            // 
            this.radioBtnAutocast.AutoSize = true;
            this.radioBtnAutocast.Location = new System.Drawing.Point(7, 115);
            this.radioBtnAutocast.Name = "radioBtnAutocast";
            this.radioBtnAutocast.Size = new System.Drawing.Size(71, 19);
            this.radioBtnAutocast.TabIndex = 3;
            this.radioBtnAutocast.TabStop = true;
            this.radioBtnAutocast.Text = "Autocast";
            this.radioBtnAutocast.UseVisualStyleBackColor = true;
            // 
            // radioBtnDisabled
            // 
            this.radioBtnDisabled.AutoSize = true;
            this.radioBtnDisabled.Location = new System.Drawing.Point(139, 65);
            this.radioBtnDisabled.Name = "radioBtnDisabled";
            this.radioBtnDisabled.Size = new System.Drawing.Size(74, 19);
            this.radioBtnDisabled.TabIndex = 4;
            this.radioBtnDisabled.TabStop = true;
            this.radioBtnDisabled.Text = "Disabled";
            this.radioBtnDisabled.UseVisualStyleBackColor = true;
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
            // radioBtnInfoBasic
            // 
            this.radioBtnInfoBasic.AutoSize = true;
            this.radioBtnInfoBasic.Enabled = false;
            this.radioBtnInfoBasic.Location = new System.Drawing.Point(139, 90);
            this.radioBtnInfoBasic.Name = "radioBtnInfoBasic";
            this.radioBtnInfoBasic.Size = new System.Drawing.Size(79, 19);
            this.radioBtnInfoBasic.TabIndex = 6;
            this.radioBtnInfoBasic.TabStop = true;
            this.radioBtnInfoBasic.Text = "Info-Basic";
            this.radioBtnInfoBasic.UseVisualStyleBackColor = true;
            // 
            // radioBtnInfoUpgrade
            // 
            this.radioBtnInfoUpgrade.AutoSize = true;
            this.radioBtnInfoUpgrade.Enabled = false;
            this.radioBtnInfoUpgrade.Location = new System.Drawing.Point(139, 115);
            this.radioBtnInfoUpgrade.Name = "radioBtnInfoUpgrade";
            this.radioBtnInfoUpgrade.Size = new System.Drawing.Size(97, 19);
            this.radioBtnInfoUpgrade.TabIndex = 7;
            this.radioBtnInfoUpgrade.TabStop = true;
            this.radioBtnInfoUpgrade.Text = "Info-Upgrade";
            this.radioBtnInfoUpgrade.UseVisualStyleBackColor = true;
            // 
            // Filters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 271);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.checkBoxIsBLP2);
            this.Controls.Add(this.btnClose);
            this.MinimumSize = new System.Drawing.Size(268, 310);
            this.Name = "Filters";
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
        private System.Windows.Forms.RadioButton radioBtnButton;
        private System.Windows.Forms.RadioButton radioBtnNone;
        private System.Windows.Forms.RadioButton radioBtnAll;
        private System.Windows.Forms.RadioButton radioBtnDisabled;
        private System.Windows.Forms.RadioButton radioBtnAutocast;
        private System.Windows.Forms.RadioButton radioBtnPassive;
        private System.Windows.Forms.RadioButton radioBtnInfoUpgrade;
        private System.Windows.Forms.RadioButton radioBtnInfoBasic;
    }
}