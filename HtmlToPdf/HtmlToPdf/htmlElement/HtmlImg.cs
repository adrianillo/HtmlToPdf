/**
 * HtmlToPdf
 * Copyright (c)2013 adrianillo
 *
 * adrianillo
 * elcorreillodeadrianillo@gmail.com
 * twitter:@adrianillo
 *
 * Licensed under the MIT license.
 * 
 * Permission is hereby granted, free of charge, to any
 * person obtaining a copy of this software and associated
 * documentation files (the "Software"), to deal in the
 * Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the
 * Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions: 
 *
 * The above copyright notice and this permission notice
 * shall be included in all copies or substantial portions of
 * the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 */
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
