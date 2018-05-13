using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITRW211_Project
{
    public class StringManipulationApple
    {
        private static List<string[]> ArticlesDetails_Apple = new List<string[]>();

        public string[] refineSite(string[] arr)
        {
            // This is where detail with '!' is manipulated:

            /* array[11] contents:
                 * 0 - Article ID
                 * 1 - Article Link
                 * 2 - Article Heading
                 * 3 - Article Author 
                 * 4 - Article Abstract
                 * 5 - Article Image Link 
                 * 6 - Article articleHTML
                 * 7 - Article Image Path 
                 * 8 - Article Text Processed  ! (this is your boolean to check if you manipulated for the paragraphs before)
                 * 9 - Article Refined Text  !   (store your refined paragraphs here)
                 * 10 - Article Counter !   (this needs 0)
                 */

            return arr;
        }

        public string[] getAuthorImage(string[] arr)
        {
            // This is where detail with '!' is manipulated:

            /* array[11] contents:
                 * 0 - Article ID
                 * 1 - Article Link
                 * 2 - Article Heading
                 * 3 - Article Author !
                 * 4 - Article Abstract
                 * 5 - Article Image Link !
                 * 6 - Article articleHTML
                 * 7 - Article Image Path
                 * 8 - Article Text Processed
                 * 9 - Article Refined Text
                 * 10 - Article Counter
                 */
            return arr;
        }
        public List<string[]> getArticleDetails(string mainHTML)
        {
            // This is where detail with '!' is manipulated:

            /* array[11] contents:
                 * 0 - Article ID !
                 * 1 - Article Link !
                 * 2 - Article Heading !
                 * 3 - Article Author
                 * 4 - Article Abstract !
                 * 5 - Article Image Link
                 * 6 - Article articleHTML
                 * 7 - Article Image Path
                 * 8 - Article Text Processed
                 * 9 - Article Refined Text
                 * 10 - Article Counter
                 */


            return ArticlesDetails_Apple;
        }

        /* private string prevDataPath = Application.StartupPath + "\\prevData";
        private List<string[]> headlinesData;
        private string GetHTMLData(string url)
        {
            using (var client = new System.Net.WebClient())
                try
                {
                    return client.DownloadString(url);
                }
                catch (Exception err)
                {
                    if (!File.Exists(prevDataPath))
                        MessageBox.Show(err.Message + "\n\n" + err.StackTrace);
                    else using (Stream str = new FileStream(prevDataPath, FileMode.Open, FileAccess.Read))
                        using (StreamReader reader = new StreamReader(str))
                            return reader.ReadToEnd();
                }
            return null;
        }
        private List<string[]> ExtractHeadlines(bool saveFile = true)
        {
            List<string[]> rList = new List<string[]>();
            string mainData;
            if ((mainData = GetHTMLData("https://appleinsider.com/")) != null)
                try
                {
                    if (saveFile)
                        using (Stream str = new FileStream(prevDataPath, FileMode.Create, FileAccess.Write))
                        using (StreamWriter writer = new StreamWriter(str))
                            writer.Write(mainData);
                    string trimmedData = mainData.Substring(mainData.IndexOf(""));
                    trimmedData = trimmedData.Remove(trimmedData.LastIndexOf(""));

                    //this is now right for the headlines
                    while (trimmedData.Contains("<h1"))
                    {
                        string line = trimmedData.Substring(trimmedData.IndexOf("<h1"));
                        trimmedData = trimmedData.Replace(line.Remove(line.IndexOf("/h1>")), "");
                        string headline = line.Remove(line.IndexOf("/h1>"));


                        if (headline.Contains("</a>"))
                        {
                            //this is perfect as is for the headline
                            headline = headline.Remove(headline.LastIndexOf("</a>"));
                            headline = headline.Substring(headline.LastIndexOf(">")+1);

                            //this works 
                            string url = "http:"+line.Substring(line.IndexOf("<a href=\"") + 10);
                            url = url.Remove(url.IndexOf("\""));

                            //this is perfect as is for articleID
                            string articleID = line.Substring(line.IndexOf("discussion/") + 11);
                            articleID = articleID.Remove(articleID.IndexOf("/\">"));

                            //works
                            string articleAbstract = line.Substring(line.IndexOf("description\">") + 13);
                            articleAbstract = articleAbstract.Remove(articleAbstract.IndexOf("</"));

                            //
                            string imageLink = "http:"+line.Substring(line.IndexOf("<img src=\"")+9);
                            imageLink = imageLink.Remove(imageLink.IndexOf("\" data"));

                            rList.Add(new string[] { headline, articleID, url, articleAbstract, imageLink });
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("AppleInsider.com has changed to a different page format; please update your software.");
                }
            else MessageBox.Show("No data was downloaded; please check your Internet connection.");
            return rList;
        }
        private string[] GetHeadlinesList(List<string[]> list)
        {
            string[] rArr = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
                rArr[i] = list[i][0];
            return rArr;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            headlinesData = ExtractHeadlines();
            listBox1.Items.AddRange(GetHeadlinesList(headlinesData));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && headlinesData != null)
                foreach (var item in headlinesData)
                    if (item[0] == (string)listBox1.SelectedItem)
                    {
                        using (Dialog dlg = new Dialog(item))
                            dlg.ShowDialog();
                        break;
                    }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }
        */

    }
}
