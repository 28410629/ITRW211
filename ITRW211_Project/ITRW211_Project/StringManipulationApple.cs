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
            /* array[11] contents:
                 * 0 - Article ID
                 * 1 - Article Link
                 * 2 - Article Heading
                 * 3 - Article Author 
                 * 4 - Article Abstract
                 * 5 - Article Image Link 
                 * 6 - Article articleHTML
                 * 7 - Article Image Path 
                 * 8 - Article Text Processed 
                 * 9 - Article Refined Text 
                 * 10 - Article Counter
                 */

            try
            {
                if (!string.IsNullOrWhiteSpace(arr[6]))
                {
                    string datacopy = arr[6];
                    datacopy = datacopy.Substring(datacopy.IndexOf("article, BEGIN"));
                    datacopy = datacopy.Remove(datacopy.IndexOf("article, END"));
                    datacopy = datacopy.Substring(datacopy.IndexOf("article-leader"));
                    string firstP = datacopy.Remove(datacopy.IndexOf("img src"));
                    datacopy = datacopy.Replace(firstP, "");
                    string header = datacopy.Remove(datacopy.IndexOf("<br>") + 3);
                    datacopy = datacopy.Replace(header, "");
                    string leftOver = datacopy.Remove(datacopy.IndexOf("<br>") + 8);
                    datacopy = datacopy.Replace(leftOver, "");

                    string article = "";
                    while (datacopy.Contains("<br>"))
                    {
                        string paragraph = datacopy;
                        paragraph = paragraph.Remove(paragraph.IndexOf("<br>") + 8);
                        datacopy = datacopy.Replace(paragraph, "");
                        paragraph = paragraph.Remove(paragraph.IndexOf("<br>"));
                        while (paragraph.Contains("h2"))
                            paragraph = "";

                        while (paragraph.Contains("img src"))
                        {
                            paragraph = paragraph.Substring(paragraph.IndexOf("<br") + 3);
                        }
                        while (paragraph.Contains("href"))
                        {
                            string refLink = paragraph.Substring(paragraph.IndexOf("<a"));
                            refLink = refLink.Remove(refLink.IndexOf(">") + 1);
                            paragraph = paragraph.Replace(refLink, "");
                            paragraph = paragraph.Replace("</a>", "");
                        }

                        while (paragraph.Contains("minor2 small gray"))
                            paragraph = "";

                        while (paragraph.Contains("</div>"))
                            paragraph = "";

                        while (paragraph.Contains("<em>") && paragraph.Contains("</em>"))
                        {
                            paragraph = paragraph.Replace("<em>", "");
                            paragraph = paragraph.Replace("</em>", "");
                        }

                        while (paragraph.Contains("<strong>") && paragraph.Contains("</strong>"))
                        {
                            paragraph = paragraph.Replace("<strong>", "");
                            paragraph = paragraph.Replace("</strong>", "");
                        }

                        while (paragraph.Contains("&amp;"))
                            paragraph = paragraph.Replace("&amp;", "&");

                        while (paragraph.Contains("<li>"))
                            paragraph = paragraph.Replace("<li>", "");

                        while (paragraph.Contains("</li>"))
                            paragraph = paragraph.Replace("</li>", "");

                        while (paragraph.Contains("<ul>"))
                            paragraph = paragraph.Replace("<ul>", "");

                        while (paragraph.Contains("</ul>"))
                            paragraph = paragraph.Replace("</ul>", "");

                        while (paragraph.Contains("&gt;"))
                            paragraph = paragraph.Replace("&gt;", "");

                        while (paragraph.Contains("<iframe"))
                        {
                            string refLink = paragraph.Substring(paragraph.IndexOf("<iframe"));
                            refLink = refLink.Remove(refLink.IndexOf("/iframe>") + 8);
                            paragraph = paragraph.Replace(refLink, "");
                        }

                        if (!string.IsNullOrWhiteSpace(paragraph))
                            article += paragraph + "\n\n";
                        //MessageBox.Show(datacopy);
                    }
                    arr[8] = "1";
                    arr[9] = article;
                    //MessageBox.Show(article);
                }
                return arr;
            }
            catch (Exception)
            {
                string[] arrNull = new string[11];
                ArticlesDetails_Apple.Add(arrNull);
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
