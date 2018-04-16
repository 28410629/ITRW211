namespace ITRW211_Project
{
    partial class FormReader
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
            this.labelSiteName = new System.Windows.Forms.Label();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonSiteLink = new System.Windows.Forms.Button();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelFocus = new System.Windows.Forms.Label();
            this.textBoxArticle = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSiteName
            // 
            this.labelSiteName.AutoSize = true;
            this.labelSiteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSiteName.Location = new System.Drawing.Point(12, 9);
            this.labelSiteName.Name = "labelSiteName";
            this.labelSiteName.Size = new System.Drawing.Size(52, 18);
            this.labelSiteName.TabIndex = 0;
            this.labelSiteName.Text = "label1";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 43);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(640, 400);
            this.pictureBoxImage.TabIndex = 2;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonSiteLink
            // 
            this.buttonSiteLink.Location = new System.Drawing.Point(12, 449);
            this.buttonSiteLink.Name = "buttonSiteLink";
            this.buttonSiteLink.Size = new System.Drawing.Size(155, 23);
            this.buttonSiteLink.TabIndex = 3;
            this.buttonSiteLink.Text = "Open Article in Browser";
            this.buttonSiteLink.UseVisualStyleBackColor = true;
            this.buttonSiteLink.Click += new System.EventHandler(this.buttonSiteLink_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(12, 27);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(35, 13);
            this.labelAuthor.TabIndex = 4;
            this.labelAuthor.Text = "label1";
            // 
            // labelFocus
            // 
            this.labelFocus.AutoSize = true;
            this.labelFocus.Location = new System.Drawing.Point(382, 622);
            this.labelFocus.Name = "labelFocus";
            this.labelFocus.Size = new System.Drawing.Size(0, 13);
            this.labelFocus.TabIndex = 5;
            // 
            // textBoxArticle
            // 
            this.textBoxArticle.Location = new System.Drawing.Point(658, 43);
            this.textBoxArticle.Name = "textBoxArticle";
            this.textBoxArticle.Size = new System.Drawing.Size(639, 400);
            this.textBoxArticle.TabIndex = 6;
            this.textBoxArticle.Text = "";
            // 
            // FormReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 482);
            this.Controls.Add(this.textBoxArticle);
            this.Controls.Add(this.labelFocus);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.buttonSiteLink);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.labelSiteName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1325, 521);
            this.MinimumSize = new System.Drawing.Size(1325, 521);
            this.Name = "FormReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReader";
            this.Load += new System.EventHandler(this.FormReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSiteName;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonSiteLink;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelFocus;
        private System.Windows.Forms.RichTextBox textBoxArticle;
    }
}