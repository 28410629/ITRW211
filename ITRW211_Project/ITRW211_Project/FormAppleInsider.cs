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
    public partial class FormAppleInsider : Form
    {
        public FormAppleInsider()
        {
            InitializeComponent();
        }

        private string GetHTMLData(string url)
        {
            using (var client = new System.Net.WebClient())
                try
                {
                    return client.DownloadString(url);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message + "\n\n" + err.StackTrace);
                }
            return null;
        }

        private List<string> ExtractHeadlines()
        {
            List<string> rList = new List<string>();
            string mainData;
        
            if ((mainData = GetHTMLData("https://appleinsider.com/")) != null)
                try
                {
                    string trimmedData = mainData.Substring(mainData.IndexOf("< h1 >< a href = "));
                    trimmedData = trimmedData.Remove(trimmedData.LastIndexOf("</a></h1>"));
                   
                    while (trimmedData.Contains("<h1"))
                    {
                        string line = trimmedData.Substring(trimmedData.IndexOf("<h1"));
                        line = line.Remove(line.IndexOf("<h1"));
                        trimmedData = trimmedData.Replace(line, "");
                       
                        if (line.Contains("</a>"))
                        {
                            line = line.Remove(line.LastIndexOf("</a>"));
                            line = line.Substring(line.LastIndexOf(">") + 1);
                            rList.Add(line);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("AppleInsider has changed to a different page format; please update your software.");
                }
            else MessageBox.Show("No data was downloaded; please check your Internet connection.");
            return rList;
        }

        private void FormAppleInsider_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                lstHeadlines.Items.Clear();
                lstHeadlines.Items.AddRange(ExtractHeadlines().ToArray());
            }
    }
}
