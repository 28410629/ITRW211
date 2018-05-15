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
        private string downloadFile(string link, string path, string filename)
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
                return text_backup;
            }
        }

        private string readFile(string link, string path, string filename)
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

        public string downloadHTML(string link, string path, string filename)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(link))
                {
                    try
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        return downloadFile(link,path,filename);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error downloading the latest article list.\n\nAre you connected to the internet?\n\nChecking for previous downloaded list.");
                        FileInfo fileInfo = new FileInfo(path + filename);
                        if (fileInfo.Exists)
                        {
                            return readFile(link, path, filename);
                        }
                        else
                        {
                            MessageBox.Show("Error no previous list found.");
                            return null;
                        }
                    }
                }
                return null;
            }
            catch (Exception err)
            {
                MessageBox.Show("Article not downloaded!" + "\n\n" + err.Message + "\n\n" + err.StackTrace);
                return null;
            }
            
        }
        public string downloadArticleHTML(string link, string path, string filename)
        {
            if (!string.IsNullOrWhiteSpace(link))
            {
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        return downloadFile(link, path, filename);
                    }
                    else
                    {
                        FileInfo fileArticleHTML = new FileInfo(path + filename);
                        if (fileArticleHTML.Exists)
                        {
                            return readFile(link, path, filename);
                        }
                        else
                        {
                            return downloadFile(link, path, filename);
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Article not downloaded!" + "\n\n" + err.Message + "\n\n" + err.StackTrace);
                    return null;
                }
            }
            return null;
        }
    }
}
