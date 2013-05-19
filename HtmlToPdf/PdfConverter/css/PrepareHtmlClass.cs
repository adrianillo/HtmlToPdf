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
