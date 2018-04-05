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
using System.Diagnostics;

// Coenraad Human 28410629

namespace ITRW211_Project
{
    public partial class FormArsTechnica : Form
    {
        Form newMain;
        private string htmlString = "";
        private List<string> list_ArticleLink = new List<string>();
        private List<string> list_ArticleID = new List<string>();
        private List<string> list_ArticleImageLink = new List<string>();
        private List<string> list_ArticleAuthor = new List<string>();
        private List<string> list_ArticleAbstract = new List<string>();
        private string Selected_Article;
        private Image Selected_Image;

        public FormArsTechnica(Form newMain)
        {
            InitializeComponent();
            this.newMain = newMain;
        }

        private string downloadHTMLstring(string link, string path, string filename)
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
                    MessageBox.Show("Sorry no internet or backup file...");
                    return null;
                }
            }
        }

        private void FormArsTechnica_Load(object sender, EventArgs e)
        {
            htmlString = downloadHTMLstring("https://arstechnica.com/", Application.StartupPath + "\\ArsTechnica", "\\ArsTechnica-HTML.txt");
            try
            {
                if (!string.IsNullOrEmpty(htmlString))
                {
                    
                    string editedHTML; //string that will be worked on and copy of html file
                    string getHeading; //string that will give headlines   
                    //Remove unnecessary info at beginning of document to where indicated
                    editedHTML = htmlString.Substring(htmlString.IndexOf("First article"));
                    editedHTML = editedHTML.Remove(editedHTML.LastIndexOf("<!-- Adjust order if mobile -->"));
                    string piece1 = editedHTML.Substring(htmlString.IndexOf("<!-- Horizontal listing -->"));
                    while (editedHTML.Contains("article>"))
                    {
                        getHeading = editedHTML.Substring(editedHTML.IndexOf("<article class")); //remove everything before line
                        getHeading = getHeading.Remove(getHeading.IndexOf("</article>") + 10); //remove everything after line
                        editedHTML = editedHTML.Replace(getHeading, ""); //removes line from our copy of the html, this prevents infinite loop
                        getHeading = getHeading.Remove(getHeading.IndexOf("</time>"));
                        getHeading = getHeading.Substring(getHeading.LastIndexOf("<header>") + 8);
                        string linkArticle = getHeading;
                        string fileName = getHeading;
                        string author = getHeading;
                        string aritcle_abstract = getHeading;
                        // Refine Article ID
                        fileName = fileName.Remove(fileName.LastIndexOf(">") - 6);
                        fileName = fileName.Substring(fileName.LastIndexOf("datetime=") + 10);
                        fileName = fileName.Replace(":", "");
                        fileName = fileName.Replace("+", "");
                        fileName = fileName.Replace("-", "");
                        fileName = fileName.Replace("T", "");
                        // Refine Article Author
                        author = author.Remove(author.LastIndexOf("</span>"));
                        author = author.Substring(author.LastIndexOf(">") + 1);
                        // Refine Article Abstract
                        aritcle_abstract = aritcle_abstract.Remove(aritcle_abstract.LastIndexOf("</p>"));
                        aritcle_abstract = aritcle_abstract.Substring(aritcle_abstract.LastIndexOf("excerpt") + 9);
                        //Refine Heading
                        getHeading = getHeading.Remove(getHeading.LastIndexOf("</a></h2>"));
                        getHeading = getHeading.Substring(getHeading.LastIndexOf(">") + 1);

                        //Refine link
                        linkArticle = linkArticle.Substring(linkArticle.IndexOf("ref=") + 5);
                        linkArticle = linkArticle.Remove(linkArticle.IndexOf("</a></h2>"));
                        linkArticle = linkArticle.Remove(linkArticle.IndexOf(">") - 1);
                        //Add link to list
                        if (!string.IsNullOrEmpty(getHeading))
                        {
                            listBoxDisplay.Items.Add(getHeading);
                            list_ArticleLink.Add(linkArticle);
                            list_ArticleID.Add(fileName);
                            list_ArticleAbstract.Add(aritcle_abstract);
                            list_ArticleAuthor.Add(author);
                        }

                    }
                    labelIntro.Text = "The following articles (" + listBoxDisplay.Items.Count + ") are available from Ars Technica";
                }
                else
                {
                    MessageBox.Show("Are you connected to the internet?");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "\n\n" + err.StackTrace);
            }
        }

        private void ArticleInformation(string link, string article_id, int index)
        {
            string selected_article = downloadHTMLstring(link, Application.StartupPath + "\\ArsTechnica\\" + article_id, "\\" + article_id + "-HTML.txt");

            selected_article = selected_article.Substring(selected_article.IndexOf("<h1"));
            string image_link = selected_article.Substring(selected_article.IndexOf("<img src=") + 10);
            image_link = selected_article.Remove(selected_article.IndexOf("/>") - 1);
            MessageBox.Show(image_link);
            list_ArticleImageLink.Add(image_link);

        }

        private void ImageDownloader(string link)
        {

        }

        private void listBoxDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ArticleInformation(list_ArticleLink[listBoxDisplay.SelectedIndex], list_ArticleID[listBoxDisplay.SelectedIndex], listBoxDisplay.SelectedIndex);
            //FormReader newReader = new FormReader(newMain,"Ars Technica", (string)listBoxDisplay.SelectedItem, list_ArticleAuthor[listBoxDisplay.SelectedIndex], Selected_Article, list_ArticleLink[listBoxDisplay.SelectedIndex], );
        }

        private void listBoxDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelArticleInfo.Text = "Author: " + list_ArticleAuthor[listBoxDisplay.SelectedIndex] +
                                    "\nAbstract: " + list_ArticleAbstract[listBoxDisplay.SelectedIndex];
        }
    }
}
