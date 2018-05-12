using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITRW211_Project
{
    public class StringManipulationArs
    {
        private static List<string[]> ArticlesDetails_Ars = new List<string[]>();

        public string[] refineSite(string[] arr)
        {
            string data_copy = arr[6];
            if (!string.IsNullOrWhiteSpace(data_copy) && arr[8] == "0")
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
                        while (line.Contains("&amp;"))
                        {

                            line = line.Replace("&amp;", "&");

                        }
                        if (line.Contains("h2>"))
                        {

                        }
                        if (!string.IsNullOrEmpty(line))
                        {
                            article += (line + "\n\n");
                        }

                    } // while loop for paragraph elements
                    article = article.Remove(article.LastIndexOf("\n\n"));
                    arr[9]  = article;
                    return arr;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message + "\n\n" + err.StackTrace);
                }
            }
            return arr;
        }
        public List<string[]> getArticleDetails(string htmlArs)
        {
            string articleItem;
            // Get information per article
            while (htmlArs.Contains("article>"))
            {
                // Array that contains current article details
                string[] item = new string[11];

                articleItem = htmlArs.Substring(htmlArs.IndexOf("<article class"));
                articleItem = articleItem.Remove(articleItem.IndexOf("</article>") + 10);
                htmlArs = htmlArs.Replace(articleItem, "");
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
                 * 6 - Article Text
                 * 7 - Article Image Path
                 * 8 - Article Text Processed
                 * 9 - Article Refined Text
                 * 10 - Article Counter
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
                if (item[2].Contains("&amp;"))
                {
                    item[2] = item[2].Replace("&amp;", "&");
                }
                if (item[2].Contains("em>"))
                {
                    string part2 = item[2].Substring(item[2].LastIndexOf(">") + 1);
                    item[2] = item[2].Remove(item[2].LastIndexOf("em>") - 2);
                    item[2] = item[2].Substring(item[2].LastIndexOf("em>") + 3);
                    item[2] += part2;
                }
                else
                {
                    item[2] = item[2].Substring(item[2].LastIndexOf(">") + 1);
                }

                item[3] = item[3].Remove(item[3].LastIndexOf("</span>"));
                item[3] = item[3].Substring(item[3].LastIndexOf(">") + 1);

                item[4] = item[4].Remove(item[4].LastIndexOf("</p>"));
                item[4] = item[4].Substring(item[4].LastIndexOf("excerpt") + 9);

                item[8] = "0";

                item[10] = "0";
                if(!string.IsNullOrWhiteSpace(item[2]))
                {
                    ArticlesDetails_Ars.Add(item);
                }
            }
            return ArticlesDetails_Ars;
        }
        public string refineImageLink(string image_link)
        {
            try
            {
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

                return image_link;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
