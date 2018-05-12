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

        public SiteLauncher(Form newMain)
        {
            InitializeComponent();
            this.newMain = newMain;
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
            FormAppleInsider newApple = new FormAppleInsider();
            newApple.MdiParent = newMain;
            newApple.Show();
            Close();
        }

        private void FormLauncher_Load(object sender, EventArgs e)
        {
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.Step = 100;
            progressBar.Value = 0;
        }

        // Written by C Human - Method that disables button after site is selected, since progress can only be used for one thread!
        private void progressbarUpdate(double amount)
        {
            
                buttonArsTechnica.Enabled = false;
                buttonAppleInsider.Enabled = false;
                buttonHackaday.Enabled = false;
                progressBar_value += (int)Math.Round(amount);
                progressBar.Value = progressBar_value;
            
        }

        // Written by C Human -  Method that processes main html for information before user browse
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

            // Open Article browser
            Invoke(new MethodInvoker(delegate ()
            {
                // Download completed
                ArticleBrowser newArs = new ArticleBrowser(newMain, ArticlesDetails_Ars, "Ars Technica");
                newArs.MdiParent = newMain;
                newArs.Show();
                Close();
            }));
        }

        // Written by C Human -  Method that processes main html for information before user browse
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
                ArticlesDetails_Hack[i][7] = pathImage.downloadImage(Application.StartupPath + "\\" + "ArsTechnica" + "\\" + ArticlesDetails_Hack[i][0] + "\\" + ArticlesDetails_Hack[i][0], ArticlesDetails_Hack[i][5]);
            }

            // Update progressbar - html processed
            Invoke(new MethodInvoker(delegate () { progressbarUpdate(20.00); }));

            // Open Article browser
            Invoke(new MethodInvoker(delegate ()
            {
                // Download completed
                ArticleBrowser newHack = new ArticleBrowser(newMain, ArticlesDetails_Hack, "Hackaday");
                newHack.MdiParent = newMain;
                newHack.Show();
                Close();
            }));
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
