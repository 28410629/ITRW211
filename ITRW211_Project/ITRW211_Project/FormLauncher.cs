using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITRW211_Project
{
    public partial class FormLauncher : Form
    {
        // Progressbar value
        public double value = 0;
        // HTML string
        private string htmlString = "";
        // List of latest articles for Ars Technica
        private List<string[]> ArticlesDetails_Ars = new List<string[]>();
        // Main form
        private Form newMain;

        public FormLauncher(Form newMain)
        {
            InitializeComponent();
            this.newMain = newMain;
        }

        private void ArsTechnicaClick(object sender, EventArgs e)
        {
            FormArsTechnica newArs = new FormArsTechnica(newMain);
            newArs.MdiParent = newMain;
            newArs.Show();
            Close();
        }

        private void buttonHackaday_Click(object sender, EventArgs e)
        {
            FormHackaday newHack = new FormHackaday();
            newHack.MdiParent = newMain;
            newHack.Show();
            Close();
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
            progressBar.Maximum = 1;
            progressBar.Minimum = 0;
            progressBar.Step = 100;
            progressBar.Value = (int)value;

        }

        private void download_mainHTML_Ars()
        {
            if (!string.IsNullOrEmpty(htmlString))
            {
                string articleItem;
                // Get information per article
                while (htmlString.Contains("article>"))
                {
                    // Array that contains current article details
                    string[] item = new string[9];

                    articleItem = htmlString.Substring(htmlString.IndexOf("<article class"));
                    articleItem = articleItem.Remove(articleItem.IndexOf("</article>") + 10);
                    htmlString = htmlString.Replace(articleItem, "");
                    articleItem = articleItem.Remove(articleItem.IndexOf("</time>"));
                    articleItem = articleItem.Substring(articleItem.LastIndexOf("<header>") + 8);

                    for (int i = 0; i < item.Length; i++)
                    {
                        item[i] = articleItem;
                    }

                    /* item:
                     * 0 - Article ID
                     * 1 = Article Link
                     * 2 - Article Heading
                     * 3 - Article Author
                     * 4 - Article Abstract
                     * 5 - Article Image Link
                     * 6 - Article Text
                     * 7 - Article Image Path
                     * 8 - Article Text Processed
                     */

                    item[0] = item[0].Remove(item[0].LastIndexOf(">") - 6);
                    item[0] = item[0].Substring(item[0].LastIndexOf("datetime=") + 10);
                    item[0] = item[0].Replace(":", "");
                    item[0] = item[0].Replace("+", "");
                    item[0] = item[0].Replace("-", "");
                    item[0] = item[0].Replace("T", "");

                    item[1] = item[1].Substring(item[1].IndexOf("ref=") + 5);
                    item[1] = item[1].Remove(item[1].IndexOf("</a></h2>"));
                    item[1] = item[1].Remove(item[1].IndexOf(">") - 1);

                    item[2] = item[2].Remove(item[2].LastIndexOf("</a></h2>"));
                    if (item[2].Contains("&amp;"))
                    {
                        item[2] = item[2].Replace("&amp;", "&");
                    }
                    if (item[2].Contains("em>"))
                    {
                        string part2 = item[2].Substring(item[2].LastIndexOf(">") + 1);
                        item[2] = item[2].Remove(item[2].LastIndexOf("em>") - 2);
                        item[2] = item[2].Substring(item[2].LastIndexOf("em>") + 3);
                        item[2] += part2;
                    }
                    else
                    {
                        item[2] = item[2].Substring(item[2].LastIndexOf(">") + 1);
                    }

                    item[3] = item[3].Remove(item[3].LastIndexOf("</span>"));
                    item[3] = item[3].Substring(item[3].LastIndexOf(">") + 1);

                    item[4] = item[4].Remove(item[4].LastIndexOf("</p>"));
                    item[4] = item[4].Substring(item[4].LastIndexOf("excerpt") + 9);

                    item[8] = "0";

                    if (!string.IsNullOrWhiteSpace(item[2]))
                    {
                        ArticlesDetails.Add(item);
                    }
                }
            }
        }
    }
}
