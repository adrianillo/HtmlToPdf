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
using System.Xml;
using System.IO;
using System.Web;
using System.Net;


namespace HtmlToPdf
{
    public class PrepareHtmlClass
    {
        public PrepareHtmlClass(string attributes, ref Dictionary<String, HtmlClass> liststylesheets)
        {
            HtmlClass css = new CssParser().Parser(attributes);
            css.IdHtmlClass="stlyle" + liststylesheets.Count.ToString();
            liststylesheets.Add(css.IdHtmlClass, css);
        }

        public PrepareHtmlClass(XmlAttributeCollection attributes, ref Dictionary<String, HtmlClass> liststylesheets, Dictionary<String, HtmlClass> listalreadystylesheets)
        {
            string csstext = string.Empty;
            if (attributes["href"] != null)
            {
                string namefile = attributes["href"].Value;
                if (namefile.StartsWith(@"https:/") || namefile.StartsWith(@"http:/"))
                    csstext = readcssfromnet(namefile);
                else
                {
                    //falta direfenciar si viene desde http, https, o sin dirección(solo el nombre o ruta del archivo)
                }
                if (csstext != string.Empty)
                    if (!liststylesheets.Keys.Contains(namefile))
                    {
                        if (listalreadystylesheets != null)
                            if (listalreadystylesheets.Keys.Contains(namefile))//style sheet has already been read before, no need to read it again
                            {
                                liststylesheets.Add(csstext, listalreadystylesheets[namefile]);
                                return;
                            }


                        HtmlClass css = new CssParser().Parser(csstext);
                        css.IdHtmlClass = namefile;
                        liststylesheets.Add(namefile, css);

                    }
            }

        }

        private string  readcssfromnet(string src)
        {
            Stream stream = null;
            string result = string.Empty;
            try
            {
                WebRequest req = WebRequest.Create(src);
                WebResponse response = req.GetResponse();
                stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result= reader.ReadToEnd();
                reader.Close();
            }
            catch { }
            finally
            {
                try { stream.Close(); }
                catch { }
            }
            return result;
        }
      
    }
}
