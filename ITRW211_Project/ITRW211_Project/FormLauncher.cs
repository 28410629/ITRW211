using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace ITRW211_Project
{
    public partial class FormLauncher : Form
    {
        // List of latest articles for Ars Technica
        private List<string[]> ArticlesDetails_Ars = new List<string[]>();
        // HTML for Ars Technica
        string htmlArs;
        // Main form
        private Form newMain;
        // Progressbar current value
        int progressBar_value = 0;


        public FormLauncher(Form newMain)
        {
            InitializeComponent();
            this.newMain = newMain;
        }

        private void ArsTechnicaClick(object sender, EventArgs e)
        {
            // Progressbar value
            progressBar_value += (int)Math.Round(10.00);
            progressBar.Value = progressBar_value;
            // Download HTML
            htmlArs = downloadHTML("https://arstechnica.com/", Application.StartupPath + "\\ArsTechnica", "\\ArsTechnica-HTML.txt");
            // Progressbar value
            progressBar_value += (int)Math.Round(10.00);
            progressBar.Value = progressBar_value;
            // Process HMTL, download article's html and download images
            Thread threadProcess = new Thread(new ThreadStart(process_mainHTML_Ars));
            threadProcess.Start();
            // FormArsTechnica newArs = new FormArsTechnica(newMain);
            //newArs.MdiParent = newMain;
            //newArs.Show();
            //Close();
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
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.Step = 100;
            progressBar.Value = 0;
        }

        // Method that downloads main html for latest articles
        private string downloadHTML(string link, string path, string filename)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    string text_backup = client.DownloadString(link);
                    using (FileStream str = new FileStream(path + filename, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(str))
                        {
                            writer.WriteLine(text_backup);
                        }
                    }
                    return text_backup;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "\n\n" + err.StackTrace);
                FileInfo fileInfo = new FileInfo(path + filename);
                if (fileInfo.Exists)
                {
                    using (FileStream str = new FileStream(path + filename, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader reader = new StreamReader(str))
                        {
                            string text = "";
                            while (!reader.EndOfStream)
                            {
                                text += reader.ReadLine();
                            }
                            return text;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        // Method that processes main html for articles
        private void process_mainHTML_Ars()
        {

            if (!string.IsNullOrEmpty(htmlArs))
            {
                string articleItem;
                double amountArticles = ArticlesDetails_Ars.Count;
                // Get information per article
                while (htmlArs.Contains("article>"))
                {
                    // Array that contains current article details
                    string[] item = new string[9];

                    articleItem = htmlArs.Substring(htmlArs.IndexOf("<article class"));
                    articleItem = articleItem.Remove(articleItem.IndexOf("</article>") + 10);
                    htmlArs = htmlArs.Replace(articleItem, "");
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

                    Invoke(new MethodInvoker(delegate
                    {
                        if (!string.IsNullOrWhiteSpace(item[2]))
                        {
                            ArticlesDetails_Ars.Add(item);
                        }
                    }));
                }
                Invoke(new MethodInvoker(delegate
                {
                    progressBar_value += (int)Math.Round(20.00);
                    progressBar.Value = progressBar_value;
                }));

                List<string[]> list = new List<string[]>();
                Invoke(new MethodInvoker(delegate
                {
                    list = ArticlesDetails_Ars;
                }));
                for (int i = 0; i < list.Count; i++)
                {
                    string link = list[i][1];
                    string path = Application.StartupPath + "\\ArsTechnica\\" + list[i][0];
                    string filename = "\\" + list[i][0] + "-HTML.txt";
                    try
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            using (var client = new WebClient())
                            {
                                client.Encoding = Encoding.UTF8;
                                string text_backup = client.DownloadString(link);
                                list[i][6] = text_backup;
                                using (FileStream str = new FileStream(path + filename, FileMode.Create, FileAccess.Write))
                                {
                                    using (StreamWriter writer = new StreamWriter(str))
                                    {
                                        writer.WriteLine(text_backup);
                                    }
                                }
                                Invoke(new MethodInvoker(delegate
                                {
                                    ArticlesDetails_Ars[i][6] = text_backup;
                                }));
                            }
                        }
                        else
                        {
                            FileInfo fileArticleHTML = new FileInfo(path + filename);
                            if (fileArticleHTML.Exists)
                            {
                                string textbackup = "";
                                using (FileStream str = new FileStream(path + filename, FileMode.Open, FileAccess.Read))
                                {
                                    using (StreamReader reader = new StreamReader(str))
                                    {
                                        while (!reader.EndOfStream)
                                        {
                                            textbackup += reader.ReadLine();
                                        }
                                    }
                                }
                                list[i][6] = textbackup;
                                Invoke(new MethodInvoker(delegate
                                {
                                    ArticlesDetails_Ars[i][6] = textbackup;
                                }));
                            }
                            else
                            {
                                using (var client = new WebClient())
                                {
                                    client.Encoding = Encoding.UTF8;
                                    string text_backup = client.DownloadString(link);
                                    list[i][6] = text_backup;
                                    using (FileStream str = new FileStream(path + filename, FileMode.Create, FileAccess.Write))
                                    {
                                        using (StreamWriter writer = new StreamWriter(str))
                                        {
                                            writer.WriteLine(text_backup);
                                        }
                                    }
                                    Invoke(new MethodInvoker(delegate
                                    {
                                        ArticlesDetails_Ars[i][6] = text_backup;
                                    }));
                                }
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            MessageBox.Show("Article not downloaded" + "\n\n" + err.Message + "\n\n" + err.StackTrace);
                        }));
                    }
                }
                Invoke(new MethodInvoker(delegate
                {
                    progressBar_value += (int)Math.Round(20.00);
                    progressBar.Value = progressBar_value;
                }));
                for (int i = 0; i < list.Count; i++)
                {
                    // Get image link
                    string image_link = list[i][6];
                    try
                    {
                        if (image_link.Contains("<img src="))
                        {
                            image_link = image_link.Substring(image_link.IndexOf("<img src=") + 10);
                            if (image_link.Contains("png"))
                            {
                                image_link = image_link.Remove(image_link.IndexOf("png") + 3);
                            }
                            else if (image_link.Contains("jpg"))
                            {
                                image_link = image_link.Remove(image_link.IndexOf("jpg") + 3);
                            }
                            else if (image_link.Contains("jpeg"))
                            {
                                image_link = image_link.Remove(image_link.IndexOf("jpeg") + 3);
                            }
                            else
                            {
                                image_link = null;
                            }

                            if (image_link.Length > 200)
                            {
                                List<int> small_list = new List<int>();
                                if (image_link.Contains("jpeg") & image_link.Contains("png") & image_link.Contains("jpg"))
                                {
                                    if (image_link.IndexOf("jpeg") > 0) { small_list.Add(image_link.IndexOf("jpeg")); }
                                    if (image_link.IndexOf("jpg") > 0) { small_list.Add(image_link.IndexOf("jpg")); }
                                    if (image_link.IndexOf("png") > 0) { small_list.Add(image_link.IndexOf("png")); }
                                    image_link = image_link.Remove(small_list.Min() + 4);
                                    if (!image_link.Contains("jpeg")) { image_link.Remove(image_link.Length - 1); }
                                }
                                else if (image_link.Contains("jpeg") && image_link.Contains("png"))
                                {
                                    if (image_link.IndexOf("jpeg") > 0) { small_list.Add(image_link.IndexOf("jpeg")); }
                                    if (image_link.IndexOf("png") > 0) { small_list.Add(image_link.IndexOf("png")); }
                                    image_link = image_link.Remove(small_list.Min() + 4);
                                    if (!image_link.Contains("jpeg")) { image_link.Remove(image_link.Length - 1); }
                                }
                                else if (image_link.Contains("jpg") && image_link.Contains("png"))
                                {
                                    if (image_link.IndexOf("jpg") > 0) { small_list.Add(image_link.IndexOf("jpg")); }
                                    if (image_link.IndexOf("png") > 0) { small_list.Add(image_link.IndexOf("png")); }
                                    image_link = image_link.Remove(small_list.Min() + 4);
                                }
                                else if (image_link.Contains("jpg") && image_link.Contains("jpeg"))
                                {
                                    if (image_link.IndexOf("jpeg") > 0) { small_list.Add(image_link.IndexOf("jpeg")); }
                                    if (image_link.IndexOf("jpg") > 0) { small_list.Add(image_link.IndexOf("jpg")); }
                                    image_link = image_link.Remove(small_list.Min() + 4);
                                    if (!image_link.Contains("jpeg")) { image_link.Remove(image_link.Length - 1); }
                                }
                                else
                                {
                                    image_link = null;
                                }
                            }
                        }
                        else
                        {
                            image_link = null;
                        }
                        list[i][5] = image_link;
                        Invoke(new MethodInvoker(delegate
                        {
                            ArticlesDetails_Ars[i][5] = image_link;
                        }));
                    }
                    catch (Exception err)
                    {
                        list[i][5] = null;
                        Invoke(new MethodInvoker(delegate
                        {
                            ArticlesDetails_Ars[i][5] = image_link;
                            MessageBox.Show("Image link could not be resolved." + "\n\n" + err.Message + "\n\n" + err.StackTrace);
                        }));
                    }
                }
                Invoke(new MethodInvoker(delegate
                {
                    progressBar_value += (int)Math.Round(20.00);
                    progressBar.Value = progressBar_value;
                }));
                // Download images
                for (int i = 0; i < list.Count; i++)
                {
                    string path2 = Application.StartupPath + "\\" + "ArsTechnica" + "\\" + list[i][0] + "\\" + list[i][0];
                    string image_link = list[i][5];
                    if (image_link != null)
                    {
                        if (image_link.Contains("png"))
                        {
                            path2 += "-Image.png";
                        }
                        else if (image_link.Contains("jpg"))
                        {
                            path2 += "-Image.jpg";
                        }
                        else if (image_link.Contains("jpeg"))
                        {
                            path2 += "-Image.jpeg";
                        }
                        else
                        {
                            path2 = Application.StartupPath + "\\ArsTechnica" + "\\ArsTechnica" + "-Image.jpg";
                        }
                        FileInfo fileInfo = new FileInfo(path2);
                        if (!fileInfo.Exists)
                        {
                            try
                            {
                                using (var client = new WebClient())
                                {
                                    client.Encoding = Encoding.UTF8;
                                    client.DownloadFile(image_link, path2);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
        }
    }
}
