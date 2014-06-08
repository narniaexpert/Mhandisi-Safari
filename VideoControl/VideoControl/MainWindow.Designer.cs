namespace VideoControl
{
    partial class MainWindow
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
            this.VideoStream = new System.Windows.Forms.WebBrowser();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.FireButton = new System.Windows.Forms.Button();
            this.BackgroundURLBox = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VideoStream
            // 
            this.VideoStream.Location = new System.Drawing.Point(-10, 9);
            this.VideoStream.MinimumSize = new System.Drawing.Size(20, 20);
            this.VideoStream.Name = "VideoStream";
            this.VideoStream.ScrollBarsEnabled = false;
            this.VideoStream.Size = new System.Drawing.Size(650, 495);
            this.VideoStream.TabIndex = 1;
            this.VideoStream.Url = new System.Uri("http://192.168.1.125:81/mobile.htm", System.UriKind.Absolute);
            this.VideoStream.WebBrowserShortcutsEnabled = false;
            // 
            // UpButton
            // 
            this.UpButton.Font = new System.Drawing.Font("Tribeca", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpButton.Location = new System.Drawing.Point(759, 53);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(64, 64);
            this.UpButton.TabIndex = 2;
            this.UpButton.Text = "Up";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpButton_MouseDown);
            this.UpButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UpButton_MouseUp);
            // 
            // DownButton
            // 
            this.DownButton.Font = new System.Drawing.Font("Tribeca", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownButton.Location = new System.Drawing.Point(759, 193);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(64, 64);
            this.DownButton.TabIndex = 3;
            this.DownButton.Text = "Down";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownButton_MouseDown);
            this.DownButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DownButton_MouseUp);
            // 
            // LeftButton
            // 
            this.LeftButton.Font = new System.Drawing.Font("Tribeca", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftButton.Location = new System.Drawing.Point(688, 123);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(64, 64);
            this.LeftButton.TabIndex = 4;
            this.LeftButton.Text = "Left";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButton_MouseDown);
            this.LeftButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LeftButton_MouseUp);
            // 
            // RightButton
            // 
            this.RightButton.Font = new System.Drawing.Font("Tribeca", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightButton.Location = new System.Drawing.Point(827, 123);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(64, 64);
            this.RightButton.TabIndex = 5;
            this.RightButton.Text = "Right";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RightButton_MouseDown);
            this.RightButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RightButton_MouseUp);
            // 
            // FireButton
            // 
            this.FireButton.Font = new System.Drawing.Font("Tribeca", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FireButton.Location = new System.Drawing.Point(688, 288);
            this.FireButton.Name = "FireButton";
            this.FireButton.Size = new System.Drawing.Size(203, 204);
            this.FireButton.TabIndex = 6;
            this.FireButton.Text = "Fire";
            this.FireButton.UseVisualStyleBackColor = true;
            this.FireButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FireButton_MouseDown);
            this.FireButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FireButton_MouseUp);
            // 
            // BackgroundURLBox
            // 
            this.BackgroundURLBox.Location = new System.Drawing.Point(757, 123);
            this.BackgroundURLBox.MinimumSize = new System.Drawing.Size(20, 20);
            this.BackgroundURLBox.Name = "BackgroundURLBox";
            this.BackgroundURLBox.ScrollBarsEnabled = false;
            this.BackgroundURLBox.Size = new System.Drawing.Size(64, 64);
            this.BackgroundURLBox.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tribeca", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.languagesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.中文ToolStripMenuItem,
            this.españolToolStripMenuItem});
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.languagesToolStripMenuItem.Text = "Languages";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // 中文ToolStripMenuItem
            // 
            this.中文ToolStripMenuItem.Name = "中文ToolStripMenuItem";
            this.中文ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.中文ToolStripMenuItem.Text = "中文";
            this.中文ToolStripMenuItem.Click += new System.EventHandler(this.中文ToolStripMenuItem_Click);
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.españolToolStripMenuItem.Text = "Español";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpFileToolStripMenuItem,
            this.viewHelpWebsiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpFileToolStripMenuItem
            // 
            this.viewHelpFileToolStripMenuItem.Name = "viewHelpFileToolStripMenuItem";
            this.viewHelpFileToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.viewHelpFileToolStripMenuItem.Text = "Open Help File";
            // 
            // viewHelpWebsiteToolStripMenuItem
            // 
            this.viewHelpWebsiteToolStripMenuItem.Name = "viewHelpWebsiteToolStripMenuItem";
            this.viewHelpWebsiteToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.viewHelpWebsiteToolStripMenuItem.Text = "View Help Website";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 504);
            this.Controls.Add(this.BackgroundURLBox);
            this.Controls.Add(this.FireButton);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.VideoStream);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(950, 542);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(950, 542);
            this.Name = "MainWindow";
            this.Text = "Mhandisi Safari";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser VideoStream;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button FireButton;
        private System.Windows.Forms.WebBrowser BackgroundURLBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpWebsiteToolStripMenuItem;

    }
}

