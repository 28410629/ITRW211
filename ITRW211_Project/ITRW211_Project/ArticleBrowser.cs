﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

// This class was created by Coenraad Human 28410629

namespace ITRW211_Project
{
    public partial class ArticleBrowser : Form
    {
        // Pass main form for MDI
        Form newMain;
        string Website;
        List<string[]> ArticlesDetails = new List<string[]>();

        public ArticleBrowser(Form newMain, List<string[]> ArticlesDetails, string Website)
        {
            InitializeComponent();
            this.newMain = newMain;
            this.ArticlesDetails = ArticlesDetails;
            this.Website = Website;
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
            /* item:
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
            for (int i = 0; i < ArticlesDetails.Count; i++)
            {
                if (ArticlesDetails[i][2] == (string)listBoxDisplay.SelectedItem)
                {
                    if (Website == "Ars Technica")
                    {
                        StringManipulationArs runArticle = new StringManipulationArs();
                        ArticlesDetails[i][9] = runArticle.refineSite(ArticlesDetails[i]);
                    }
                    else
                    {
                        StringManipulationHack runArticle = new StringManipulationHack();
                        ArticlesDetails[i][9] = runArticle.refineSite(ArticlesDetails[i]);
                    }

                    if (!string.IsNullOrWhiteSpace(ArticlesDetails[i][9]))
                    {
                        if(ArticlesDetails[i][10] == "0")
                        {
                            // Create new entry in database
                            try
                            {
                                int counter = Convert.ToInt32(ArticlesDetails[i][10]);
                                counter++;
                                ArticlesDetails[i][10] = Convert.ToString(counter);
                                DatabaseCommands command = new DatabaseCommands();
                                command.add(ArticlesDetails[i], Website);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Database entry failed");
                            }
                        }
                        else
                        {
                            // Update entry in database
                            try
                            {
                                int counter = Convert.ToInt32(ArticlesDetails[i][10]);
                                counter++;
                                ArticlesDetails[i][10] = Convert.ToString(counter);
                                DatabaseCommands command = new DatabaseCommands();
                                command.update(ArticlesDetails[i], Website);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Database entry failed");
                            }
                        }

                        // Open article reader
                        FormReader newReader = new FormReader(newMain, Website, ArticlesDetails[i][2], ArticlesDetails[i][3], ArticlesDetails[i][9], ArticlesDetails[i][1], loadImage(ArticlesDetails[i][7]));
                        newReader.MdiParent = newMain;
                        newReader.Show();
                    }
                    else
                    {
                        MessageBox.Show("Article Processing Failed");
                    }
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