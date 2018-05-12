using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ITRW211_Project
{
    public class DownloadIMAGE
    {
        public string downloadImage(string path2, string image_link)
        {
            if (image_link != null)
            {
                if (image_link.Contains("png"))
                {
                    path2 += "-Image.png";
                }
                else if (image_link.Contains("jpg"))
                {
                    path2 += "-Image.jpg";
                }
                else if (image_link.Contains("jpeg"))
                {
                    path2 += "-Image.jpeg";
                }
                else
                {
                    path2 = null;
                }

                FileInfo fileInfo2 = new FileInfo(path2);

                if (!fileInfo2.Exists)
                {
                    try
                    {
                        using (var client = new WebClient())
                        {
                            client.Encoding = Encoding.UTF8;
                            client.DownloadFile(image_link, path2);
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
            return path2;
        }
    }
}
