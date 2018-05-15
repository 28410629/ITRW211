using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ITRW211_Project
{
    public partial class SiteLauncher : Form
    {
        private static List<string[]> ArticlesDetails_Ars = new List<string[]>();
        private static List<string[]> ArticlesDetails_Apple = new List<string[]>();

        private Form newMain;
        int progressBar_value = 0;
        string username;

        public SiteLauncher(Form newMain, string username)
        {
            InitializeComponent();
            this.newMain = newMain;
            this.username = username;
        }

        private void ArsTechnicaClick(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(download_Ars));
            thread.Start();
        }

        private void buttonAppleInsider_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(download_Apple));
            thread.Start();
        }

        private void FormLauncher_Load(object sender, EventArgs e)
        {
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.Step = 100;
            progressBar.Value = 0;
        }
        
        private void progressbarUpdate(double amount)
        {
                buttonArsTechnica.Enabled = false;
                buttonAppleInsider.Enabled = false;
                progressBar_value += (int)Math.Round(amount);
                progressBar.Value = progressBar_value;
        }

        private void download_Ars()
        {
            ArticlesDetails_Ars.Clear();

            // Update progressbar - thread started
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Main HTML - downloaded started."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Download HTML
            DownloadHTML html = new DownloadHTML();
            string htmlArs = html.downloadHTML("https://arstechnica.com/", Application.StartupPath + "\\ArsTechnica", "\\ArsTechnica-HTML.txt");

            // Update progressbar - html downloaded
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Main HTML - downloaded completed."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Get individual article details from main HTML
            if (!string.IsNullOrEmpty(htmlArs))
            {
                StringManipulationArs ars = new StringManipulationArs();
                ArticlesDetails_Ars = ars.getArticleDetails(htmlArs);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article HTML - downloadeds started (if cached, HTML will be loaded)."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download individual articles
            DownloadHTML htmlArticle = new DownloadHTML();
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                ArticlesDetails_Ars[i][6] = htmlArticle.downloadArticleHTML(ArticlesDetails_Ars[i][1], Application.StartupPath + "\\ArsTechnica\\" + ArticlesDetails_Ars[i][0], "\\" + ArticlesDetails_Ars[i][0] + "-HTML.txt");
                Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article HTML - " + (i+1) + "/" + ArticlesDetails_Ars.Count; }));
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article HTML - downloadeds completed."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Process sites
            StringManipulationArs arsRefine = new StringManipulationArs();
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                try
                {
                    ArticlesDetails_Ars[i] = arsRefine.refineSite(ArticlesDetails_Ars[i]);
                    //ArticlesDetails_Appple[i] = arsImage.getImage_Author(ArticlesDetails_Apple[i])
                }
                catch (Exception)
                {
                    string[] arr = new string[11];
                    ArticlesDetails_Ars[i] = arr;
                }
            }

            //Removes unneccessary items
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(ArticlesDetails_Ars[i][0]))
                {
                    ArticlesDetails_Ars.RemoveAt(i);
                }
            }

            // Refine image links
            StringManipulationArs arsImage = new StringManipulationArs();
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(ArticlesDetails_Ars[i][6]))
                {
                    ArticlesDetails_Ars[i][5] = arsImage.refineImageLink(ArticlesDetails_Ars[i][6]);
                }
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article Images - downloadeds started (if cached, image will be loaded)."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download images and get there file path
            DownloadIMAGE pathImage = new DownloadIMAGE();
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                ArticlesDetails_Ars[i][7] = pathImage.downloadImage(Application.StartupPath + "\\" + "ArsTechnica" + "\\" + ArticlesDetails_Ars[i][0] + "\\" + ArticlesDetails_Ars[i][0], ArticlesDetails_Ars[i][5]);
                Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article Images - " + (i + 1) + "/" + ArticlesDetails_Ars.Count; }));
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article Images - downloadeds completed."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Open Article browser
            Invoke(new MethodInvoker(delegate ()
            {
                // Download completed
                ArticleBrowser newArs = new ArticleBrowser(newMain, ArticlesDetails_Ars, "Ars Technica", username);
                newArs.MdiParent = newMain;
                newArs.Show();
                Close();
            }));
        }

        private void download_Apple()
        {
            ArticlesDetails_Apple.Clear();

            // Update progressbar - thread started
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Main HTML - downloaded started."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Download mainHTML
            DownloadHTML html = new DownloadHTML();
            string htmlApple = html.downloadHTML("https://appleinsider.com/", Application.StartupPath + "\\AppleInsider", "\\AppleInsider-HTML.txt");

            // Update progressbar - html downloaded
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Main HTML - downloaded completed."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Get individual article details from main HTML
            if (!string.IsNullOrEmpty(htmlApple))
            {
                StringManipulationApple apple = new StringManipulationApple();
                ArticlesDetails_Apple = apple.getArticleDetails(htmlApple);
            }

            //Removes unneccessary items
            for (int i = 0; i < ArticlesDetails_Apple.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(ArticlesDetails_Apple[i][0]))
                {
                    ArticlesDetails_Apple.RemoveAt(i);
                }
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article HTML - downloadeds started (if cached, HTML will be loaded)."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download individual articlesHTML
            DownloadHTML htmlArticle = new DownloadHTML();
            for (int i = 0; i < ArticlesDetails_Apple.Count; i++)
            {
                ArticlesDetails_Apple[i][6] = htmlArticle.downloadArticleHTML(ArticlesDetails_Apple[i][1], Application.StartupPath + "\\AppleInsider\\" + ArticlesDetails_Apple[i][0], "\\" + ArticlesDetails_Apple[i][0] + "-HTML.txt");
                Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article HTML - " + (i + 1) + "/" + ArticlesDetails_Apple.Count; }));
            }

            //Removes unneccessary items
            for (int i = 0; i < ArticlesDetails_Apple.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(ArticlesDetails_Apple[i][0]))
                {
                    ArticlesDetails_Apple.RemoveAt(i);
                }
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article HTML - downloadeds completed."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Refine image links
            StringManipulationApple appleImage = new StringManipulationApple();
            for (int i = 0; i < ArticlesDetails_Apple.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(ArticlesDetails_Apple[i][0]))
                {
                    ArticlesDetails_Apple[i] = appleImage.getAuthorImage(ArticlesDetails_Apple[i]);
                }
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article Images - downloadeds started (if cached, image will be loaded)."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download images and get there file path
            DownloadIMAGE pathImage = new DownloadIMAGE();
            for (int i = 0; i < ArticlesDetails_Apple.Count; i++)
            {
                ArticlesDetails_Apple[i][7] = pathImage.downloadImage(Application.StartupPath + "\\" + "AppleInsider" + "\\" + ArticlesDetails_Apple[i][0] + "\\" + ArticlesDetails_Apple[i][0], ArticlesDetails_Apple[i][5]);
                Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article Images - " + (i + 1) + "/" + ArticlesDetails_Apple.Count; }));
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { labelProgress.Text = "Article Images - downloadeds completed."; }));
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Open Article browser
            Invoke(new MethodInvoker(delegate ()
            {
                // Download completed
                ArticleBrowser newApple = new ArticleBrowser(newMain, ArticlesDetails_Apple, "Apple Insider", username);
                newApple.MdiParent = newMain;
                newApple.Show();
                Close();
            }));
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
