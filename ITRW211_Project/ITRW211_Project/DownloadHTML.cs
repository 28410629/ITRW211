using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;

namespace ITRW211_Project
{
    public class DownloadHTML
    {
        public string downloadHTML(string link, string path, string filename)
        {
            if (!string.IsNullOrWhiteSpace(link))
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
                        return null;
                    }
                }
            }
            return null;
        }
        public string downloadArticleHTML(string link, string path, string filename)
        {
            if (!string.IsNullOrWhiteSpace(link))
            {
                try
                {
                    if (!Directory.Exists(path))
                    {
                        string text_backup;
                        Directory.CreateDirectory(path);
                        using (var client = new WebClient())
                        {
                            client.Encoding = Encoding.UTF8;
                            text_backup = client.DownloadString(link);
                            using (FileStream str = new FileStream(path + filename, FileMode.Create, FileAccess.Write))
                            {
                                using (StreamWriter writer = new StreamWriter(str))
                                {
                                    writer.WriteLine(text_backup);
                                }
                            }
                        }
                        return text_backup;
                    }
                    else
                    {
                        FileInfo fileArticleHTML = new FileInfo(path + filename);
                        string textbackup = "";
                        if (fileArticleHTML.Exists)
                        {
                            using (FileStream str = new FileStream(path + filename, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader reader = new StreamReader(str))
                                {
                                    while (!reader.EndOfStream)
                                    {
                                        textbackup += reader.ReadLine();
                                    }
                                }
                            }
                            return textbackup;
                        }
                        else
                        {
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
                            }
                            return textbackup;
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Article not downloaded" + "\n\n" + err.Message + "\n\n" + err.StackTrace);
                    return null;
                }
            }
            return null;
        }
    }
}
