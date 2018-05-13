using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(arr[8] == "0")
            {
                string datacopy = arr[6];
                datacopy = datacopy.Substring(datacopy.IndexOf("article, BEGIN"));
                datacopy = datacopy.Remove(datacopy.IndexOf("article, END"));


            }
            return arr;
        }

        public string[] getAuthorImage(string[] arr)
        {
            if(!string.IsNullOrWhiteSpace(arr[6]))
            {
                string datacopy = arr[6];
                datacopy = datacopy.Substring(datacopy.IndexOf("article, BEGIN"));
                datacopy = datacopy.Remove(datacopy.IndexOf("article, END"));
                arr[3] = datacopy.Substring(datacopy.IndexOf("mailto"));
                arr[3] = arr[3].Substring(arr[3].IndexOf(">") + 1);
                arr[3] = arr[3].Remove(arr[3].IndexOf("<"));
                arr[5] = datacopy.Substring(datacopy.IndexOf("data-original=") + 15);
                arr[5] = arr[5].Remove(arr[5].IndexOf(">")-1);
                arr[8] = "0";
                arr[10] = "0";
            }
            return arr;
        }
        public List<string[]> getArticleDetails(string mainHTML)
        {
            string datacopy = mainHTML;
            datacopy = datacopy.Substring(datacopy.IndexOf("content area home page, BEGIN"));
            datacopy = datacopy.Remove(datacopy.IndexOf("content area home page, END"));
            datacopy = datacopy.Substring(datacopy.IndexOf("<h1") + 3);
            while (datacopy.Contains("<h1"))
            {
                try
                {
                    string[] arr = new string[11];
                    string line = datacopy.Remove(datacopy.IndexOf("<h1") + 3);
                    datacopy = datacopy.Replace(line, "");
                    line = line.Remove(line.LastIndexOf("</a>"));
                    line = line.Remove(line.LastIndexOf(">") - 2);
                    arr[0] = line.Substring(line.LastIndexOf("/") + 1);
                    line = line.Remove(line.LastIndexOf("</p"));
                    line = line.Remove(line.LastIndexOf(".") + 1);
                    arr[4] = line.Substring(line.LastIndexOf(">") + 1).Trim();
                    if (arr[4].Length > 200)
                    {
                        arr[4] = arr[4].Remove(200);
                        arr[4] += "...";
                    }
                    line = line.Remove(line.LastIndexOf("</h1>") - 4);
                    arr[2] = line.Substring(line.LastIndexOf(">") + 1);
                    line = line.Remove(line.LastIndexOf(">") - 1);
                    arr[1] = "https:" + line.Substring(line.LastIndexOf("href") + 6);
                    if (!string.IsNullOrWhiteSpace(arr[2]))
                    {
                        if (arr[4].Contains("<") || arr[4].Contains(">"))
                        {
                            string[] arrNull = new string[11];
                            ArticlesDetails_Apple.Add(arrNull);
                        }
                        else
                        {
                            ArticlesDetails_Apple.Add(arr);
                        }  
                    }
                }
                catch (Exception)
                {
                    string[] arrNull = new string[11];
                    ArticlesDetails_Apple.Add(arrNull);
                }
            }
            return ArticlesDetails_Apple;
        }
    }
}
