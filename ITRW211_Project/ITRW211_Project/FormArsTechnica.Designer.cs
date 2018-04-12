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
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelStatus_Article = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
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
            this.labelIntro.ForeColor = System.Drawing.Color.Snow;
            this.labelIntro.Location = new System.Drawing.Point(12, 9);
            this.labelIntro.Name = "labelIntro";
            this.labelIntro.Size = new System.Drawing.Size(47, 15);
            this.labelIntro.TabIndex = 1;
            this.labelIntro.Text = "label1";
            // 
            // labelArticleInfo
            // 
            this.labelArticleInfo.AutoSize = true;
            this.labelArticleInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArticleInfo.ForeColor = System.Drawing.SystemColors.Control;
            this.labelArticleInfo.Location = new System.Drawing.Point(12, 437);
            this.labelArticleInfo.Name = "labelArticleInfo";
            this.labelArticleInfo.Size = new System.Drawing.Size(19, 13);
            this.labelArticleInfo.TabIndex = 2;
            this.labelArticleInfo.Text = "...";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(660, 27);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(637, 407);
            this.pictureBoxPreview.TabIndex = 3;
            this.pictureBoxPreview.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Snow;
            this.labelStatus.Location = new System.Drawing.Point(657, 437);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 4;
            // 
            // labelStatus_Article
            // 
            this.labelStatus_Article.AutoSize = true;
            this.labelStatus_Article.ForeColor = System.Drawing.Color.Snow;
            this.labelStatus_Article.Location = new System.Drawing.Point(657, 455);
            this.labelStatus_Article.Name = "labelStatus_Article";
            this.labelStatus_Article.Size = new System.Drawing.Size(0, 13);
            this.labelStatus_Article.TabIndex = 5;
            // 
            // FormArsTechnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1309, 477);
            this.Controls.Add(this.labelStatus_Article);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.labelArticleInfo);
            this.Controls.Add(this.labelIntro);
            this.Controls.Add(this.listBoxDisplay);
            this.MinimumSize = new System.Drawing.Size(682, 510);
            this.Name = "FormArsTechnica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArsTechnica Article Browser";
            this.Load += new System.EventHandler(this.FormArsTechnica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.Label labelIntro;
        private System.Windows.Forms.Label labelArticleInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelStatus_Article;
    }
}