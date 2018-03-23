namespace ITRW211_Project
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonArsTechnica = new System.Windows.Forms.Button();
            this.buttonBoredPanda = new System.Windows.Forms.Button();
            this.buttonHackaday = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonArsTechnica
            // 
            this.buttonArsTechnica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonArsTechnica.BackgroundImage")));
            this.buttonArsTechnica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArsTechnica.ForeColor = System.Drawing.Color.OrangeRed;
            this.buttonArsTechnica.Location = new System.Drawing.Point(12, 37);
            this.buttonArsTechnica.Name = "buttonArsTechnica";
            this.buttonArsTechnica.Size = new System.Drawing.Size(276, 114);
            this.buttonArsTechnica.TabIndex = 0;
            this.buttonArsTechnica.UseVisualStyleBackColor = true;
            this.buttonArsTechnica.Click += new System.EventHandler(this.ArsTechnicaClick);
            // 
            // buttonBoredPanda
            // 
            this.buttonBoredPanda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBoredPanda.BackgroundImage")));
            this.buttonBoredPanda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBoredPanda.Location = new System.Drawing.Point(294, 37);
            this.buttonBoredPanda.Name = "buttonBoredPanda";
            this.buttonBoredPanda.Size = new System.Drawing.Size(276, 114);
            this.buttonBoredPanda.TabIndex = 1;
            this.buttonBoredPanda.UseVisualStyleBackColor = true;
            this.buttonBoredPanda.Click += new System.EventHandler(this.buttonBoredPanda_Click);
            // 
            // buttonHackaday
            // 
            this.buttonHackaday.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHackaday.BackgroundImage")));
            this.buttonHackaday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHackaday.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonHackaday.Location = new System.Drawing.Point(576, 37);
            this.buttonHackaday.Name = "buttonHackaday";
            this.buttonHackaday.Size = new System.Drawing.Size(276, 114);
            this.buttonHackaday.TabIndex = 2;
            this.buttonHackaday.UseVisualStyleBackColor = true;
            this.buttonHackaday.Click += new System.EventHandler(this.buttonHackaday_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 833);
            this.Controls.Add(this.buttonHackaday);
            this.Controls.Add(this.buttonBoredPanda);
            this.Controls.Add(this.buttonArsTechnica);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "ITRW211_Project - Article Reader (28410629, 29158710 and 28633512)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonArsTechnica;
        private System.Windows.Forms.Button buttonBoredPanda;
        private System.Windows.Forms.Button buttonHackaday;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
    }
}

