namespace VideoControl
{
    partial class Settings
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
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.IPAddressTextBox = new System.Windows.Forms.TextBox();
            this.PlayerTypeLabel = new System.Windows.Forms.Label();
            this.PlayerTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.Font = new System.Drawing.Font("Tribeca", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPAddressLabel.Location = new System.Drawing.Point(12, 9);
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size(142, 25);
            this.IPAddressLabel.TabIndex = 0;
            this.IPAddressLabel.Text = "IP Address:";
            // 
            // IPAddressTextBox
            // 
            this.IPAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IPAddressTextBox.Font = new System.Drawing.Font("Tribeca", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPAddressTextBox.Location = new System.Drawing.Point(17, 37);
            this.IPAddressTextBox.Name = "IPAddressTextBox";
            this.IPAddressTextBox.Size = new System.Drawing.Size(255, 28);
            this.IPAddressTextBox.TabIndex = 1;
            // 
            // PlayerTypeLabel
            // 
            this.PlayerTypeLabel.AutoSize = true;
            this.PlayerTypeLabel.Font = new System.Drawing.Font("Tribeca", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTypeLabel.Location = new System.Drawing.Point(12, 68);
            this.PlayerTypeLabel.Name = "PlayerTypeLabel";
            this.PlayerTypeLabel.Size = new System.Drawing.Size(164, 25);
            this.PlayerTypeLabel.TabIndex = 2;
            this.PlayerTypeLabel.Text = "Player Type:";
            // 
            // PlayerTypeComboBox
            // 
            this.PlayerTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayerTypeComboBox.Font = new System.Drawing.Font("Tribeca", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerTypeComboBox.FormattingEnabled = true;
            this.PlayerTypeComboBox.Items.AddRange(new object[] {
            "Gunner",
            "Driver"});
            this.PlayerTypeComboBox.Location = new System.Drawing.Point(15, 96);
            this.PlayerTypeComboBox.Name = "PlayerTypeComboBox";
            this.PlayerTypeComboBox.Size = new System.Drawing.Size(257, 28);
            this.PlayerTypeComboBox.TabIndex = 3;
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSettingsButton.Font = new System.Drawing.Font("Tribeca", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveSettingsButton.Location = new System.Drawing.Point(15, 130);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(257, 120);
            this.SaveSettingsButton.TabIndex = 4;
            this.SaveSettingsButton.Text = "Save Settings";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.PlayerTypeComboBox);
            this.Controls.Add(this.PlayerTypeLabel);
            this.Controls.Add(this.IPAddressTextBox);
            this.Controls.Add(this.IPAddressLabel);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.TextBox IPAddressTextBox;
        private System.Windows.Forms.Label PlayerTypeLabel;
        private System.Windows.Forms.ComboBox PlayerTypeComboBox;
        private System.Windows.Forms.Button SaveSettingsButton;
    }
}