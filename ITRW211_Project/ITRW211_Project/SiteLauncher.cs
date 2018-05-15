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
        // List of latest articles for Ars Technica
        private static List<string[]> ArticlesDetails_Ars = new List<string[]>();
        private static List<string[]> ArticlesDetails_Hack = new List<string[]>();
        private static List<string[]> ArticlesDetails_Apple = new List<string[]>();

        /* array[11] contents:
                 * 0 - Article ID
                 * 1 - Article Link
                 * 2 - Article Heading
                 * 3 - Article Author
                 * 4 - Article Abstract
                 * 5 - Article Image Link
                 * 6 - Article Text
                 * 7 - Article Image Path
                 * 8 - Article Text Processed
                 * 9 - Article Refined Text
                 * 10 - Article Counter
                 */

        // Main form
        private Form newMain;
        // Progress bar current value
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
            // Process HMTL, download article's html and download images
            Thread thread = new Thread(new ThreadStart(download_Ars));
            thread.Start();
        }

        private void buttonHackaday_Click(object sender, EventArgs e)
        {
            // Process HMTL, download article's html and download images
            Thread thread = new Thread(new ThreadStart(download_Hack));
            thread.Start();
        }

        private void buttonAppleInsider_Click(object sender, EventArgs e)
        {
            // Process HMTL, download article's html and download images
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
                buttonHackaday.Enabled = false;
                progressBar_value += (int)Math.Round(amount);
                progressBar.Value = progressBar_value;
        }

        private void download_Ars()
        {
            // Update progressbar - thread started
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Download HTML
            DownloadHTML html = new DownloadHTML();
            string htmlArs = html.downloadHTML("https://arstechnica.com/", Application.StartupPath + "\\ArsTechnica", "\\ArsTechnica-HTML.txt");

            // Update progressbar - html downloaded
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Get individual article details from main HTML
            if (!string.IsNullOrEmpty(htmlArs))
            {
                StringManipulationArs ars = new StringManipulationArs();
                ArticlesDetails_Ars = ars.getArticleDetails(htmlArs);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download individual articles
            DownloadHTML htmlArticle = new DownloadHTML();
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                string link = ArticlesDetails_Ars[i][1];
                string path = Application.StartupPath + "\\ArsTechnica\\" + ArticlesDetails_Ars[i][0];
                string filename = "\\" + ArticlesDetails_Ars[i][0] + "-HTML.txt";

                ArticlesDetails_Ars[i][6] = htmlArticle.downloadArticleHTML(link, path, filename);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Refine image links
            StringManipulationArs arsImage = new StringManipulationArs();
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                ArticlesDetails_Ars[i][5] = arsImage.refineImageLink(ArticlesDetails_Ars[i][6]);
                //ArticlesDetails_Appple[i] = arsImage.getImage_Author(ArticlesDetails_Apple[i])
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download images and get there file path
            DownloadIMAGE pathImage = new DownloadIMAGE();
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                ArticlesDetails_Ars[i][7] = pathImage.downloadImage(Application.StartupPath + "\\" + "ArsTechnica" + "\\" + ArticlesDetails_Ars[i][0] + "\\" + ArticlesDetails_Ars[i][0], ArticlesDetails_Ars[i][5]);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Refine image links
            StringManipulationArs arsRefine = new StringManipulationArs();
            for (int i = 0; i < ArticlesDetails_Ars.Count; i++)
            {
                try
                {
                    ArticlesDetails_Ars[i] = arsRefine.refineSite(ArticlesDetails_Ars[i]);
                    //ArticlesDetails_Appple[i] = arsImage.getImage_Author(ArticlesDetails_Apple[i])
                }
                catch(Exception)
                {
                    string[] arr = new string[11];
                    ArticlesDetails_Ars[i] = arr;
                }

            }
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

        private void download_Hack()
        {
            // Update progressbar - thread started
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Download HTML
            DownloadHTML html = new DownloadHTML();
            string htmlHack = html.downloadHTML("https://hackaday.com/", Application.StartupPath + "\\Hackaday", "\\Hackaday-HTML.txt");

            // Update progressbar - html downloaded
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Get individual article details from main HTML
            if (!string.IsNullOrEmpty(htmlHack))
            {
                StringManipulationHack hack = new StringManipulationHack();
                ArticlesDetails_Hack = hack.getArticleDetails(htmlHack);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download individual articles
            DownloadHTML htmlArticle = new DownloadHTML();
            for (int i = 0; i < ArticlesDetails_Hack.Count; i++)
            {
                string link = ArticlesDetails_Hack[i][1];
                string path = Application.StartupPath + "\\Hackaday\\" + ArticlesDetails_Hack[i][0];
                string filename = "\\" + ArticlesDetails_Hack[i][0] + "-HTML.txt";

                ArticlesDetails_Hack[i][6] = htmlArticle.downloadArticleHTML(link, path, filename);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Refine image links
            StringManipulationHack hackImage = new StringManipulationHack();
            for (int i = 0; i < ArticlesDetails_Hack.Count; i++)
            {
                ArticlesDetails_Hack[i][5] = hackImage.refineImageLink(ArticlesDetails_Hack[i][6]);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download images and get there file path
            DownloadIMAGE pathImage = new DownloadIMAGE();
            for (int i = 0; i < ArticlesDetails_Hack.Count; i++)
            {
                ArticlesDetails_Hack[i][7] = pathImage.downloadImage(Application.StartupPath + "\\" + "Hackaday" + "\\" + ArticlesDetails_Hack[i][0] + "\\" + ArticlesDetails_Hack[i][0], ArticlesDetails_Hack[i][5]);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Open Article browser
            Invoke(new MethodInvoker(delegate ()
            {
                // Download completed
                ArticleBrowser newHack = new ArticleBrowser(newMain, ArticlesDetails_Hack, "Hackaday", username);
                newHack.MdiParent = newMain;
                newHack.Show();
                Close();
            }));
        }

        private void download_Apple()
        {
            // Update progressbar - thread started
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Download mainHTML
            DownloadHTML html = new DownloadHTML();
            string htmlApple = html.downloadHTML("https://appleinsider.com/", Application.StartupPath + "\\AppleInsider", "\\AppleInsider-HTML.txt");

            // Update progressbar - html downloaded
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(10.00); }));

            // Get individual article details from main HTML
            if (!string.IsNullOrEmpty(htmlApple))
            {
                StringManipulationApple apple = new StringManipulationApple();
                ArticlesDetails_Apple = apple.getArticleDetails(htmlApple);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download individual articlesHTML
            DownloadHTML htmlArticle = new DownloadHTML();
            for (int i = 0; i < ArticlesDetails_Apple.Count; i++)
            {
                string link = ArticlesDetails_Apple[i][1];
                string path = Application.StartupPath + "\\AppleInsider\\" + ArticlesDetails_Apple[i][0];
                string filename = "\\" + ArticlesDetails_Apple[i][0] + "-HTML.txt";

                ArticlesDetails_Apple[i][6] = htmlArticle.downloadArticleHTML(link, path, filename);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Refine image links
            StringManipulationApple appleImage = new StringManipulationApple();
            for (int i = 0; i < ArticlesDetails_Apple.Count; i++)
            {
                ArticlesDetails_Apple[i] = appleImage.getAuthorImage(ArticlesDetails_Apple[i]);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Download images and get there file path
            DownloadIMAGE pathImage = new DownloadIMAGE();
            for (int i = 0; i < ArticlesDetails_Apple.Count; i++)
            {
                ArticlesDetails_Apple[i][7] = pathImage.downloadImage(Application.StartupPath + "\\" + "AppleInsider" + "\\" + ArticlesDetails_Apple[i][0] + "\\" + ArticlesDetails_Apple[i][0], ArticlesDetails_Apple[i][5]);
            }

            // Update progressbar - html processed
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
