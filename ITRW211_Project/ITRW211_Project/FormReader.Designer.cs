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
            this.textBoxArticle = new System.Windows.Forms.TextBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonSiteLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSiteName
            // 
            this.labelSiteName.AutoSize = true;
            this.labelSiteName.Location = new System.Drawing.Point(12, 9);
            this.labelSiteName.Name = "labelSiteName";
            this.labelSiteName.Size = new System.Drawing.Size(35, 13);
            this.labelSiteName.TabIndex = 0;
            this.labelSiteName.Text = "label1";
            // 
            // textBoxArticle
            // 
            this.textBoxArticle.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxArticle.Location = new System.Drawing.Point(12, 243);
            this.textBoxArticle.Multiline = true;
            this.textBoxArticle.Name = "textBoxArticle";
            this.textBoxArticle.ReadOnly = true;
            this.textBoxArticle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxArticle.Size = new System.Drawing.Size(701, 350);
            this.textBoxArticle.TabIndex = 1;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 25);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(701, 212);
            this.pictureBoxImage.TabIndex = 2;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonSiteLink
            // 
            this.buttonSiteLink.Location = new System.Drawing.Point(12, 599);
            this.buttonSiteLink.Name = "buttonSiteLink";
            this.buttonSiteLink.Size = new System.Drawing.Size(155, 23);
            this.buttonSiteLink.TabIndex = 3;
            this.buttonSiteLink.Text = "Open Article in Browser";
            this.buttonSiteLink.UseVisualStyleBackColor = true;
            this.buttonSiteLink.Click += new System.EventHandler(this.buttonSiteLink_Click);
            // 
            // FormReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 630);
            this.Controls.Add(this.buttonSiteLink);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.textBoxArticle);
            this.Controls.Add(this.labelSiteName);
            this.Name = "FormReader";
            this.Text = "FormReader";
            this.Load += new System.EventHandler(this.FormReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSiteName;
        private System.Windows.Forms.TextBox textBoxArticle;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonSiteLink;
    }
}