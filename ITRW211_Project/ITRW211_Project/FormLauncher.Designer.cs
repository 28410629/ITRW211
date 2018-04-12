namespace ITRW211_Project
{
    partial class FormLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLauncher));
            this.buttonArsTechnica = new System.Windows.Forms.Button();
            this.buttonBoredPanda = new System.Windows.Forms.Button();
            this.buttonHackaday = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonArsTechnica
            // 
            this.buttonArsTechnica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonArsTechnica.BackgroundImage")));
            this.buttonArsTechnica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArsTechnica.ForeColor = System.Drawing.Color.OrangeRed;
            this.buttonArsTechnica.Location = new System.Drawing.Point(12, 15);
            this.buttonArsTechnica.Name = "buttonArsTechnica";
            this.buttonArsTechnica.Size = new System.Drawing.Size(276, 114);
            this.buttonArsTechnica.TabIndex = 0;
            this.buttonArsTechnica.UseVisualStyleBackColor = true;
            this.buttonArsTechnica.Click += new System.EventHandler(this.ArsTechnicaClick);
            // 
            // buttonBoredPanda
            // 
            this.buttonBoredPanda.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonBoredPanda.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBoredPanda.BackgroundImage")));
            this.buttonBoredPanda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBoredPanda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBoredPanda.Location = new System.Drawing.Point(294, 15);
            this.buttonBoredPanda.Name = "buttonBoredPanda";
            this.buttonBoredPanda.Size = new System.Drawing.Size(276, 114);
            this.buttonBoredPanda.TabIndex = 1;
            this.buttonBoredPanda.UseVisualStyleBackColor = false;
            this.buttonBoredPanda.Click += new System.EventHandler(this.buttonBoredPanda_Click);
            // 
            // buttonHackaday
            // 
            this.buttonHackaday.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHackaday.BackgroundImage")));
            this.buttonHackaday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHackaday.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonHackaday.Location = new System.Drawing.Point(576, 15);
            this.buttonHackaday.Name = "buttonHackaday";
            this.buttonHackaday.Size = new System.Drawing.Size(276, 114);
            this.buttonHackaday.TabIndex = 2;
            this.buttonHackaday.UseVisualStyleBackColor = true;
            this.buttonHackaday.Click += new System.EventHandler(this.buttonHackaday_Click);
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(864, 144);
            this.Controls.Add(this.buttonHackaday);
            this.Controls.Add(this.buttonBoredPanda);
            this.Controls.Add(this.buttonArsTechnica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(880, 183);
            this.MinimumSize = new System.Drawing.Size(880, 183);
            this.Name = "FormLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose a site:";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonArsTechnica;
        private System.Windows.Forms.Button buttonBoredPanda;
        private System.Windows.Forms.Button buttonHackaday;
    }
}

