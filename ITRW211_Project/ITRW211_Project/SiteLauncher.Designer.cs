namespace ITRW211_Project
{
    partial class SiteLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteLauncher));
            this.buttonArsTechnica = new System.Windows.Forms.Button();
            this.buttonAppleInsider = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelWindow = new System.Windows.Forms.Label();
            this.labelExit = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonArsTechnica
            // 
            this.buttonArsTechnica.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonArsTechnica.BackgroundImage")));
            this.buttonArsTechnica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArsTechnica.ForeColor = System.Drawing.Color.OrangeRed;
            this.buttonArsTechnica.Location = new System.Drawing.Point(21, 43);
            this.buttonArsTechnica.Name = "buttonArsTechnica";
            this.buttonArsTechnica.Size = new System.Drawing.Size(276, 114);
            this.buttonArsTechnica.TabIndex = 0;
            this.buttonArsTechnica.UseVisualStyleBackColor = true;
            this.buttonArsTechnica.Click += new System.EventHandler(this.ArsTechnicaClick);
            // 
            // buttonAppleInsider
            // 
            this.buttonAppleInsider.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonAppleInsider.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAppleInsider.BackgroundImage")));
            this.buttonAppleInsider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAppleInsider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAppleInsider.Location = new System.Drawing.Point(303, 43);
            this.buttonAppleInsider.Name = "buttonAppleInsider";
            this.buttonAppleInsider.Size = new System.Drawing.Size(276, 114);
            this.buttonAppleInsider.TabIndex = 1;
            this.buttonAppleInsider.UseVisualStyleBackColor = false;
            this.buttonAppleInsider.Click += new System.EventHandler(this.buttonAppleInsider_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(21, 172);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(558, 23);
            this.progressBar.TabIndex = 3;
            // 
            // labelWindow
            // 
            this.labelWindow.AutoSize = true;
            this.labelWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWindow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelWindow.Location = new System.Drawing.Point(18, 9);
            this.labelWindow.Name = "labelWindow";
            this.labelWindow.Size = new System.Drawing.Size(114, 20);
            this.labelWindow.TabIndex = 4;
            this.labelWindow.Text = "Choose a site: ";
            // 
            // labelExit
            // 
            this.labelExit.AutoSize = true;
            this.labelExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelExit.Location = new System.Drawing.Point(559, 9);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(20, 20);
            this.labelExit.TabIndex = 5;
            this.labelExit.Text = "X";
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.ForeColor = System.Drawing.Color.White;
            this.labelProgress.Location = new System.Drawing.Point(19, 212);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 15);
            this.labelProgress.TabIndex = 6;
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SiteLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(600, 236);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.labelExit);
            this.Controls.Add(this.labelWindow);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonAppleInsider);
            this.Controls.Add(this.buttonArsTechnica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(600, 236);
            this.MinimumSize = new System.Drawing.Size(600, 236);
            this.Name = "SiteLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose a site:";
            this.Load += new System.EventHandler(this.FormLauncher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonArsTechnica;
        private System.Windows.Forms.Button buttonAppleInsider;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelWindow;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Label labelProgress;
    }
}

