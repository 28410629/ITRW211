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
        private string SiteLink;

        public FormReader(Form newMain, string SiteName, string Heading, string Author, string Article, string SiteLink, Image Article_Image)
        {
            InitializeComponent();
            labelSiteName.Text = SiteName + " - " + Heading;
            this.newMain = newMain;
            textBoxArticle.Text = Article;
            this.SiteLink = SiteLink;
            pictureBoxImage.Image = Article_Image;
            labelAuthor.Text = Author;
        }

        private void buttonSiteLink_Click(object sender, EventArgs e)
        {
            Process.Start(SiteLink);
        }
    }
}
