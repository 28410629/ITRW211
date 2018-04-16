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

// This class was created by Coenraad Human 28410629

namespace ITRW211_Project
{
    public partial class FormArsTechnica : Form
    {
        // Pass main form for MDI
        Form newMain;
        //
        List<string[]> ArticlesDetails = new List<string[]>();

        public FormArsTechnica(Form newMain, List<string[]> ArticlesDetails)
        {
            InitializeComponent();
            this.newMain = newMain;
            this.ArticlesDetails = ArticlesDetails;
        }

        // Event for when form loads to process all new articles
        private void FormArsTechnica_Load(object sender, EventArgs e)
        {
            // After all articles are retrieved then add them to list box
            for (int i = 0; i < ArticlesDetails.Count; i++)
            {
                listBoxDisplay.Items.Add(ArticlesDetails[i][2]);
            }

            labelIntro.Text = "The following articles (" + ArticlesDetails.Count + ") are available from Ars Technica";
        }             
        // Event to open article in reader when item is double-clicked.
        private void listBoxDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ArticlesDetails.Count; i++)
            {
                if (ArticlesDetails[i][2] == (string)listBoxDisplay.SelectedItem)
                {
                    string data_copy = ArticlesDetails[i][6];
                    if (!string.IsNullOrWhiteSpace(data_copy) && ArticlesDetails[i][8] == "0")
                    {
                        try
                        {
                            data_copy = data_copy.Substring(data_copy.IndexOf("headline"));

                            string article = "";
                            string line = "";
                            
                            while (data_copy.Contains("<p>"))
                            {
                                line = data_copy;
                                line = line.Substring(line.IndexOf("<p>"));
                                line = line.Remove(line.IndexOf("</p>") + 4);
                                data_copy = data_copy.Replace(line, "");
                                line = line.Substring(line.IndexOf("<p>") + 3);
                                line = line.Remove(line.IndexOf("</p>"));

                                if (line.Contains("Join the Ars"))
                                {
                                    line = "";
                                }

                                while (line.Contains("<a href"))
                                {
                                    string line2 = line;
                                    try
                                    {
                                        line2 = line2.Remove(line.IndexOf("</a>") + 4);
                                        line2 = line2.Substring(line.IndexOf("<a href"));
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        // Still have an error here with minimal articals, due to not always being '<a href'
                                        MessageBox.Show(line + "\n\n" + line2);
                                        line2 = line2.Substring(line.IndexOf("<a href"));
                                    }
                                    if (line2.Contains(".jpg") || line2.Contains(".jpeg") || line2.Contains(".png"))
                                    {
                                        line = line.Replace(line2, "");
                                    }
                                    else
                                    {
                                        line = line.Replace(line2, "new_string_will_be_inserted");
                                        try
                                        {
                                            line2 = line2.Remove(line2.IndexOf("</a>"));
                                            line2 = line2.Substring(line2.LastIndexOf(">") + 1);
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            line2 = line2.Substring(line2.LastIndexOf(">") + 1);
                                        }
                                        line = line.Replace("new_string_will_be_inserted", line2);
                                    }
                                }
                                while (line.Contains("<h3>"))
                                {
                                    string line2 = line;
                                    try
                                    {
                                        line2 = line2.Remove(line.IndexOf("</h3>") + 5);
                                        line2 = line2.Substring(line.IndexOf("<h3>"));
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        line2 = line2.Substring(line.IndexOf("<h3>"));
                                    }
                                    if (line2.Contains("Further Reading"))
                                    {
                                        string line3 = line;
                                        try
                                        {
                                            line3 = line3.Remove(line3.IndexOf("</aside>") + 8);
                                            line3 = line3.Substring(line3.IndexOf("<h3>"));
                                        }
                                        catch (Exception)
                                        {
                                            line3 = line3.Substring(line3.IndexOf("<h3>"));
                                        }
                                        line = line.Replace(line3, "");
                                    }
                                    else
                                    {
                                        line = line.Replace(line2, "new_string_will_be_inserted");
                                        try
                                        {
                                            line2 = line2.Remove(line2.IndexOf("</h3>"));
                                            line2 = line2.Substring(line2.LastIndexOf(">") + 1);
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        {
                                            line2 = line2.Substring(line2.LastIndexOf(">") + 1);
                                        }
                                        line2 = line2 + "\n\n";
                                        line = line.Replace("new_string_will_be_inserted", line2);
                                    }
                                }
                                while (line.Contains("<"))
                                {
                                    string line2 = line;
                                    try
                                    {
                                        line2 = line2.Remove(line.IndexOf(">") + 1);
                                        line2 = line2.Substring(line.IndexOf("<"));
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        line2 = line2.Substring(line.IndexOf("<"));
                                    }
                                    if (line2.Contains("/aside"))
                                    {
                                        line = line.Replace(line2, ". ");
                                    }
                                    else
                                    {
                                        line = line.Replace(line2, "");
                                    }
                                }
                                if (line.Contains("h2>"))
                                {

                                }
                                if(!string.IsNullOrEmpty(line))
                                {
                                    article += (line + "\n\n");
                                }
                                
                            }
                            article = article.Remove(article.LastIndexOf("\n\n"));
                            ArticlesDetails[i][6] = article;
                            ArticlesDetails[i][8] = "1";
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message + "\n\n" + err.StackTrace);
                        }
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
                    FormReader newReader = new FormReader(newMain, "Ars Technica", ArticlesDetails[i][2], ArticlesDetails[i][3], ArticlesDetails[i][6], ArticlesDetails[i][1], loadImage(ArticlesDetails[i][7]));
                    newReader.MdiParent = newMain;
                    newReader.Show();
                }
            }
        }
        // Simple method to return image
        private Image loadImage(string imagePath)
        {
            try
            {
                FileInfo fileInfo2 = new FileInfo(imagePath);
                if (fileInfo2.Exists)
                { 
                    return Image.FromFile(imagePath);
                }
                else
                {
                    return Properties.Resources.ars_sub_thumb;
                }
            }
            catch(Exception)
            {
                return Properties.Resources.ars_sub_thumb;
            }
        }
        // Event to change specific details on form as user moves through browser
        private void listBoxDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ArticlesDetails.Count; i++)
            {
                if (ArticlesDetails[i][2] == (string)listBoxDisplay.SelectedItem)
                {
                    labelArticleInfo.Text = "Author: " + ArticlesDetails[i][3] + "\nAbstract: " + ArticlesDetails[i][4];
                    pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxPreview.Image = loadImage(ArticlesDetails[i][7]);
                }
            }
        }
    }
}
