using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Net;
using System.Xml;
namespace HtmlToPdf
{
    public enum typeimg{jpg=1,png=2,bmp=3,gif=4}
    public class HtmlImg:HtmlItem
    {
        public HtmlImg()
        { }

        public HtmlImg(XmlAttributeCollection attr)
        {
            if (attr != null)
                if (attr.Count > 0)
                    if (attr["src"] != null)
                        if (attr["src"].Value != null)
                        {
                            Src = attr["src"].Value;
                            readimg();
                        }        
        }

        private typeimg imageType;

        public typeimg ImageType
        {
            get { return imageType; }
            set { imageType = value; }
        }

        private string src;

        public string Src
        {
            get { return src; }
            set { src = value; }
        }
        private System.Drawing.Image image;

        public System.Drawing.Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private void setyTypeImg(string imgtype)
        {
            switch (imgtype)
            {
                case "image/jpeg":
                    ImageType = typeimg.jpg;
                    break;
                case "image/png":
                    imageType = typeimg.png;
                    break;
                case "image/bmp":
                    imageType = typeimg.bmp;
                    break;
                case "image/gif":
                    imageType = typeimg.gif;
                    break;
                default:
                    imageType = typeimg.jpg;
                    break;
            }
        }

        private void  readimg()
        {
            Stream stream = null;
            try
            {
                WebRequest req = WebRequest.Create(Src);
                WebResponse response = req.GetResponse();
                setyTypeImg(response.ContentType);
                stream = response.GetResponseStream();
                Image = System.Drawing.Image.FromStream(stream);
                stream.Close();

            }
            catch { }
            finally 
            {
                try { stream.Close(); }
                catch { }
            }
 
        }
     
    }
}
