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

// This class was created by Coenraad Human 28410629

namespace ITRW211_Project
{
    public partial class FormArsTechnica : Form
    {
        // Pass main form for MDI
        Form newMain;
        // Main html string file - downloaded everytime site is opened
        private string htmlString = "";
        // List of latest articles
        private List<string[]> ArticlesDetails = new List<string[]>();

        public FormArsTechnica(Form newMain)
        {
            InitializeComponent();
            this.newMain = newMain;
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

        // Event for when form loads to process all new articles
        private void FormArsTechnica_Load(object sender, EventArgs e)
        {
            htmlString = downloadHTML("https://arstechnica.com/", Application.StartupPath + "\\ArsTechnica", "\\ArsTechnica-HTML.txt");
            try
            {
                if (!string.IsNullOrEmpty(htmlString))
                {
                    string articleItem;
                    // Get information per article
                    while (htmlString.Contains("article>"))
                    {
                        // Array that contains current article details
                        string[] item = new string[8];

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
                         * 6 = Article Text
                         * 7 - Article Image Path
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
                        item[2] = item[2].Substring(item[2].LastIndexOf(">") + 1);
                        
                        item[3] = item[3].Remove(item[3].LastIndexOf("</span>"));
                        item[3] = item[3].Substring(item[3].LastIndexOf(">") + 1);
                        
                        item[4] = item[4].Remove(item[4].LastIndexOf("</p>"));
                        item[4] = item[4].Substring(item[4].LastIndexOf("excerpt") + 9);
                        
                        if (!string.IsNullOrWhiteSpace(item[2]))
                        {
                            ArticlesDetails.Add(item);
                        }
                    }

                    // After all articles are retrieved then add them to list box
                    for (int i = 0; i < ArticlesDetails.Count; i++)
                    {
                        listBoxDisplay.Items.Add(ArticlesDetails[i][2]);
                    }

                    string pathImage = Application.StartupPath + "\\ArsTechnica" + "\\ArsTechnica" + "-Image.jpg";
                    FileInfo fileInfo = new FileInfo(pathImage);
                    if (!fileInfo.Exists)
                    {
                        using (var client = new WebClient())
                        {
                            client.Encoding = Encoding.UTF8;
                            client.DownloadFile("https://raw.githubusercontent.com/coenraadhuman/ITRW211_Project/master/Resources/ars-sub-thumb.jpg", pathImage);
                        }
                    }

                    labelIntro.Text = "The following articles (" + listBoxDisplay.Items.Count + ") are available from Ars Technica";
                }
                else
                {
                    MessageBox.Show("Are you connected to the internet?\nNo backup file found either.");
                    Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "\n\n" + err.StackTrace);
                Close();
            }
        }             
        // Event to open article in reader when item is double-clicked.
        private void listBoxDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ArticlesDetails.Count; i++)
            {
                if(ArticlesDetails[i][2] == (string)listBoxDisplay.SelectedItem)
                {
                    FormReader newReader = new FormReader(newMain, "Ars Technica", ArticlesDetails[i][2], ArticlesDetails[i][3], ArticlesDetails[i][6], ArticlesDetails[i][1], loadImage(ArticlesDetails[i][7]));
                    newReader.MdiParent = newMain;
                    newReader.Show();
                }
            }
        }
        // Simple method to load download image
        private Image loadImage(string imagePath)
        {
            return Image.FromFile(imagePath); ;
        }
        // Method that downloads image and article site html for processing
        private void downloadData()
        {
            string selected = "";
            string compare = "";
            string image_link = "";
            string[] ThreadItem = new string[8];
            Invoke(new MethodInvoker(delegate
            {
                selected = (string)listBoxDisplay.SelectedItem;
            }));
            for (int i = 0; i < ArticlesDetails.Count; i++)
            {
                Invoke(new MethodInvoker(delegate
                {
                    compare = ArticlesDetails[i][2];
                }));
                if (selected == compare)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        labelArticleInfo.Text = "Author: " + ArticlesDetails[i][3] +
                                            "\nAbstract: " + ArticlesDetails[i][4];
                        ThreadItem[0] = ArticlesDetails[i][0];
                        ThreadItem[1] = ArticlesDetails[i][1];
                        ThreadItem[2] = ArticlesDetails[i][2];
                        ThreadItem[3] = ArticlesDetails[i][3];
                        ThreadItem[4] = ArticlesDetails[i][4];
                        ThreadItem[5] = ArticlesDetails[i][5];
                        ThreadItem[6] = ArticlesDetails[i][6];
                        ThreadItem[7] = ArticlesDetails[i][7];
                    }));
                    /* item:
                          * 0 - Article ID
                          * 1 = Article Link
                          * 2 - Article Heading
                          * 3 - Article Author
                          * 4 - Article Abstract
                          * 5 - Article Image Link
                          * 6 = Article Text
                          * 7 - Article Image Path
                          */
                    string filename = "\\" + ThreadItem[0] + "-HTML.txt";
                    string link = ThreadItem[1];
                    string path = Application.StartupPath + "\\ArsTechnica\\" + ThreadItem[0];
                    try
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            using (var client = new WebClient())
                            {
                                client.Encoding = Encoding.UTF8;
                                string text_backup = client.DownloadString(link);
                                ThreadItem[6] = text_backup;
                                using (FileStream str = new FileStream(path + filename, FileMode.Create, FileAccess.Write))
                                {
                                    using (StreamWriter writer = new StreamWriter(str))
                                    {
                                        writer.WriteLine(text_backup);
                                    }
                                }
                                Invoke(new MethodInvoker(delegate
                                {
                                    ArticlesDetails[i][6] = text_backup;
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
                                        while(!reader.EndOfStream)
                                        {
                                            textbackup += reader.ReadLine();
                                        }
                                    }
                                }
                                ThreadItem[6] = textbackup;
                                Invoke(new MethodInvoker(delegate
                                {
                                    ArticlesDetails[i][6] = textbackup;
                                    labelStatus_Article.Text = "Article loaded from previous downloaded file.";
                                }));
                            }
                            else
                            {
                                using (var client = new WebClient())
                                {
                                    client.Encoding = Encoding.UTF8;
                                    string text_backup = client.DownloadString(link);
                                    ThreadItem[6] = text_backup;
                                    using (FileStream str = new FileStream(path + filename, FileMode.Create, FileAccess.Write))
                                    {
                                        using (StreamWriter writer = new StreamWriter(str))
                                        {
                                            writer.WriteLine(text_backup);
                                        }
                                    }
                                    Invoke(new MethodInvoker(delegate
                                    {
                                        ArticlesDetails[i][6] = text_backup;
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
                    // Process article paragraphs to be completed still
                    /*
                        string selected_article = downloadHTML(linkArticle, Application.StartupPath + "\\ArsTechnica\\" + fileName, "\\" + fileName + "-HTML.txt");
                        
                        
                        // refine article
                        string article = "";
                        string line;
                        try
                        {
                            selected_article = selected_article.Substring(selected_article.IndexOf("<!-- cache hit"));
                            selected_article = selected_article.Substring(selected_article.IndexOf("<!-- cache hit"));
                            selected_article = selected_article.Substring(selected_article.IndexOf("<!-- cache hit"));
                            if (selected_article.Contains("Listing image"))
                            {
                                selected_article = selected_article.Remove(selected_article.IndexOf("Listing image"));
                            }
                            else
                            {
                                selected_article = selected_article.Remove(selected_article.LastIndexOf("<!-- cache hit"));
                            }
                            while (selected_article.Contains("p>"))
                            {
                                line = selected_article.Substring(selected_article.IndexOf("<p>"));
                                line = selected_article.Remove(selected_article.IndexOf("</p>") + 4);
                                selected_article = selected_article.Replace(line, "");
                                line = line.Substring(line.IndexOf("<p>") + 3);
                                line = line.Remove(line.IndexOf("</p>"));
                                article += line + "\n\n";
                            }
                            if (article.Contains("div>"))
                            {
                                article = article.Remove(article.IndexOf("div>"));
                            }
                        }
                        catch(Exception err)
                        {
                            MessageBox.Show("Error downloading article\n\n" + err.Message + "\n\n" + err.StackTrace);
                            article = null;
                        }
                        list_ArticleRead.Add(article);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Are you connected to the internet?");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "\n\n" + err.StackTrace);
            }*/
                    try
                    {
                        // Get image link
                        string selected_article = ThreadItem[6].Substring(ThreadItem[6].IndexOf("<h1"));
                        image_link = selected_article;
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
                    }
                    catch (Exception err)
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            MessageBox.Show("Image link could not be resolved." + "\n\n" + err.Message + "\n\n" + err.StackTrace);
                        }));
                    }
                    string path2 = Application.StartupPath + "\\" + "ArsTechnica" + "\\" + ThreadItem[0] + "\\" + ThreadItem[0];

                    // Download image
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
                                path2 = null;
                            }
                        }
                        else
                        {
                            Invoke(new MethodInvoker(delegate
                            {
                                labelStatus.Text = "Image loaded from previous downloaded copy.";
                            }));
                        }

                    }

                    // Load downloaded image
                    Image image;
                    try
                    {
                        image = Image.FromFile(path2);
                    }
                    catch (Exception)
                    {
                        path2 = Application.StartupPath + "\\ArsTechnica" + "\\ArsTechnica" + "-Image.jpg";
                        image = Image.FromFile(path2);
                    }

                    Invoke(new MethodInvoker(delegate
                    {
                        pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBoxPreview.Image = image;
                        ArticlesDetails[i][7] = path2;
                    }));
                }
            }
        }
        // Event to display information when highlighted item is changed on listbox
        private void listBoxDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelStatus.Text = "";
            Thread threadData = new Thread(new ThreadStart(downloadData));
            threadData.Start();
        }
    }
}
