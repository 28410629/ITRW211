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

namespace ITRW211_Project
{
    public partial class FormArsTechnica : Form
    {
        Form newMain;
        private string htmlString = "";
        private List<string> linksArticle = new List<string>();

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
                    using (FileStream str = new FileStream(path, FileMode.Create, FileAccess.Write))
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
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    using (FileStream str = new FileStream(path, FileMode.Open, FileAccess.Read))
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
            htmlString = downloadHTMLstring("https://arstechnica.com/", Application.StartupPath + "\\ArsTechnica", "\\ArsTechnica-Headings.txt");
            try
            {
                if (!string.IsNullOrEmpty(htmlString))
                {
                    string editedHTML; //string that will be worked on and copy of html file
                    string getHeading; //string that will give headlines
                    string linkArticle;

                    //Remove unnecessary info at beginning of document to where indicated
                    editedHTML = htmlString.Substring(htmlString.IndexOf("First article"));
                    editedHTML = editedHTML.Remove(editedHTML.LastIndexOf("Adjust order if mobile"));
                    while (editedHTML.Contains("h2>"))
                    {
                        getHeading = editedHTML.Substring(editedHTML.IndexOf("<h2>")); //remove everything before line
                        getHeading = getHeading.Remove(getHeading.IndexOf("</h2>") + 5); //remove everything after line
                        editedHTML = editedHTML.Replace(getHeading, ""); //removes line from our copy of the html, this prevents infinite loop
                        //MessageBox.Show(getHeading);
                        linkArticle = getHeading;
                        //Refine getHeading
                        getHeading = getHeading.Remove(getHeading.IndexOf("</a>"));
                        getHeading = getHeading.Substring(getHeading.LastIndexOf(">") + 1);
                        //MessageBox.Show(getHeading);
                        //Refine link
                        linkArticle = linkArticle.Substring(linkArticle.IndexOf("ref=") + 5);
                        linkArticle = linkArticle.Remove(linkArticle.IndexOf("</a>"));
                        linkArticle = linkArticle.Remove(linkArticle.IndexOf(">") - 1);
                        //MessageBox.Show(linkArticle);
                        //Add link to list
                        if (!string.IsNullOrEmpty(getHeading))
                        {
                            listBoxDisplay.Items.Add(getHeading);
                            linksArticle.Add(linkArticle);
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

        private void ArticleInformation()
        {
            downloadHTMLstring(linksArticle[listBoxDisplay.SelectedIndex], Application.StartupPath + "\\ArsTechnica\\" + );
        }

        private void listBoxDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string Article = "";

            FormReader newReader = new FormReader(newMain,"Ars Technica", (string)listBoxDisplay.SelectedItem, Article, linksArticle[listBoxDisplay.SelectedIndex], );
        }
    }
}
