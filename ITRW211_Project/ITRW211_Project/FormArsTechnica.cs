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
        // Event to open article in reader when item is double-clicked.
        private void listBoxDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ArticlesDetails.Count; i++)
            {
                if (ArticlesDetails[i][2] == (string)listBoxDisplay.SelectedItem)
                {
                    if (string.IsNullOrWhiteSpace(ArticlesDetails[i][6]) && ArticlesDetails[i][8] == "0")
                    {
                        string article = "";
                        ArticlesDetails[i][6] = ArticlesDetails[i][6].Substring(ArticlesDetails[i][6].IndexOf("<h1"));
                        string line;
                        ArticlesDetails[i][6] = ArticlesDetails[i][6].Substring(ArticlesDetails[i][6].IndexOf("<!-- cache hit"));
                        ArticlesDetails[i][6] = ArticlesDetails[i][6].Substring(ArticlesDetails[i][6].IndexOf("<!-- cache hit"));
                        ArticlesDetails[i][6] = ArticlesDetails[i][6].Substring(ArticlesDetails[i][6].IndexOf("<!-- cache hit"));
                        if (ArticlesDetails[i][6].Contains("Listing image"))
                        {
                            ArticlesDetails[i][6] = ArticlesDetails[i][6].Remove(ArticlesDetails[i][6].IndexOf("Listing image"));
                        }
                        else
                        {
                            ArticlesDetails[i][6] = ArticlesDetails[i][6].Remove(ArticlesDetails[i][6].LastIndexOf("<!-- cache hit"));
                        }
                        while (ArticlesDetails[i][6].Contains("p>"))
                        {
                            line = ArticlesDetails[i][6].Substring(ArticlesDetails[i][6].IndexOf("<p>"));
                            line = ArticlesDetails[i][6].Remove(ArticlesDetails[i][6].IndexOf("</p>") + 4);
                            ArticlesDetails[i][6] = ArticlesDetails[i][6].Replace(line, "");
                            line = line.Substring(line.IndexOf("<p>") + 3);
                            //line = line.Remove(line.IndexOf("</p>"));
                            article += line + "\n\n";
                        }
                        if (article.Contains("div>"))
                        {
                            article = article.Remove(article.IndexOf("div>"));
                        }
                        ArticlesDetails[i][8] = "1";
                    }
                    
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
