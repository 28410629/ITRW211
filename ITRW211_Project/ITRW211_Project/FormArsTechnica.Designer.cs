namespace ITRW211_Project
{
    partial class FormArsTechnica
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
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.labelIntro = new System.Windows.Forms.Label();
            this.labelArticleInfo = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.BackColor = System.Drawing.Color.Gray;
            this.listBoxDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDisplay.ForeColor = System.Drawing.SystemColors.Window;
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.Location = new System.Drawing.Point(12, 27);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(642, 407);
            this.listBoxDisplay.TabIndex = 0;
            this.listBoxDisplay.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplay_SelectedIndexChanged);
            this.listBoxDisplay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxDisplay_MouseDoubleClick);
            // 
            // labelIntro
            // 
            this.labelIntro.AutoSize = true;
            this.labelIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntro.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelIntro.Location = new System.Drawing.Point(12, 9);
            this.labelIntro.Name = "labelIntro";
            this.labelIntro.Size = new System.Drawing.Size(47, 15);
            this.labelIntro.TabIndex = 1;
            this.labelIntro.Text = "label1";
            // 
            // labelArticleInfo
            // 
            this.labelArticleInfo.AutoSize = true;
            this.labelArticleInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelArticleInfo.Location = new System.Drawing.Point(12, 437);
            this.labelArticleInfo.Name = "labelArticleInfo";
            this.labelArticleInfo.Size = new System.Drawing.Size(16, 13);
            this.labelArticleInfo.TabIndex = 2;
            this.labelArticleInfo.Text = "...";
            // 
            // FormArsTechnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(666, 471);
            this.Controls.Add(this.labelArticleInfo);
            this.Controls.Add(this.labelIntro);
            this.Controls.Add(this.listBoxDisplay);
            this.MinimumSize = new System.Drawing.Size(682, 510);
            this.Name = "FormArsTechnica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArsTechnica Article Browser";
            this.Load += new System.EventHandler(this.FormArsTechnica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.Label labelIntro;
        private System.Windows.Forms.Label labelArticleInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}