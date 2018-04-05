using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ITRW211_Project
{
    public partial class FormReader : Form
    {
        private Form newMain;
        private string Heading;
        private string Article;
        private string SiteLink;
        private Image Article_Image;
        private string SiteName;

        public FormReader(Form newMain, string SiteName, string Heading, string Article, string SiteLink, Image Article_Image)
        {
            InitializeComponent();
            this.SiteName = SiteName;
            this.newMain = newMain;
            this.Heading = Heading;
            this.Article = Article;
            this.SiteLink = SiteLink;
            this.Article_Image = Article_Image;
        }

        private void FormReader_Load(object sender, EventArgs e)
        {
            labelSiteName.Text = SiteName + " - " + Heading;
            textBoxArticle.Text = Article;
            pictureBoxImage.Image = Article_Image;
        }

        private void buttonSiteLink_Click(object sender, EventArgs e)
        {
            Process.Start(SiteLink);
        }
    }
}
