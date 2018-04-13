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
            this.buttonAppleInsider = new System.Windows.Forms.Button();
            this.buttonHackaday = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // buttonArsTechnica
            // 
            this.buttonArsTechnica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonArsTechnica.BackgroundImage")));
            this.buttonArsTechnica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArsTechnica.ForeColor = System.Drawing.Color.OrangeRed;
            this.buttonArsTechnica.Location = new System.Drawing.Point(12, 12);
            this.buttonArsTechnica.Name = "buttonArsTechnica";
            this.buttonArsTechnica.Size = new System.Drawing.Size(276, 114);
            this.buttonArsTechnica.TabIndex = 0;
            this.buttonArsTechnica.UseVisualStyleBackColor = true;
            this.buttonArsTechnica.Click += new System.EventHandler(this.ArsTechnicaClick);
            // 
            // buttonAppleInsider
            // 
            this.buttonAppleInsider.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAppleInsider.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAppleInsider.BackgroundImage")));
            this.buttonAppleInsider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAppleInsider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAppleInsider.Location = new System.Drawing.Point(294, 12);
            this.buttonAppleInsider.Name = "buttonAppleInsider";
            this.buttonAppleInsider.Size = new System.Drawing.Size(276, 114);
            this.buttonAppleInsider.TabIndex = 1;
            this.buttonAppleInsider.UseVisualStyleBackColor = false;
            this.buttonAppleInsider.Click += new System.EventHandler(this.buttonAppleInsider_Click);
            // 
            // buttonHackaday
            // 
            this.buttonHackaday.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHackaday.BackgroundImage")));
            this.buttonHackaday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHackaday.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonHackaday.Location = new System.Drawing.Point(576, 12);
            this.buttonHackaday.Name = "buttonHackaday";
            this.buttonHackaday.Size = new System.Drawing.Size(276, 114);
            this.buttonHackaday.TabIndex = 2;
            this.buttonHackaday.UseVisualStyleBackColor = true;
            this.buttonHackaday.Click += new System.EventHandler(this.buttonHackaday_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 141);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(840, 23);
            this.progressBar.TabIndex = 3;
            // 
            // FormLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(864, 180);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonHackaday);
            this.Controls.Add(this.buttonAppleInsider);
            this.Controls.Add(this.buttonArsTechnica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(880, 219);
            this.MinimumSize = new System.Drawing.Size(880, 219);
            this.Name = "FormLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose a site:";
            this.Load += new System.EventHandler(this.FormLauncher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonArsTechnica;
        private System.Windows.Forms.Button buttonAppleInsider;
        private System.Windows.Forms.Button buttonHackaday;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

