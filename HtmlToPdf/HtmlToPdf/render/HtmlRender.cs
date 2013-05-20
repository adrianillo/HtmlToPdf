using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace HtmlToPdf
{
    public class HtmlRender
    {
        public HtmlRender()
        { }
        protected List<string> listTempFiles;
        public void Run(HtmlToPdf con,ref List<string> listTemFiles)
        {
            listTempFiles = listTemFiles;
            foreach (HtmlSection sec in con.ListSection)
            {
                Section section = con.Doc.AddSection();
                Paragraph prgraph = section.AddParagraph(sec.NameSection);

                var par = from p in con.ListParagraph
                          where p.OwnerHtmlSection == sec
                          select p;
                foreach (HtmlDoc prgph in par)
                {
                    Paragraph paragraph = section.AddParagraph();
                    foreach (HtmlItem it in prgph.ListItem)
                    {
                        if (it is HtmlTable || it is HtmlContent || it is HtmlDiv)
                        {
                            paragraph = section.AddParagraph();
                            if (!(it is HtmlTable))
                                RenderStyle.CreateRenderStyle(it, ref paragraph).Render();

                            renderingit(it, ref paragraph, null, null);
                            paragraph = section.AddParagraph();
                        }
                        else
                            renderingit(it, ref paragraph, null, null);

                    }
                }
            }
        }

        protected HtmlItem renderingit(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            switch (it.GetType().Name)
            {
                case "HtmlText":                   
                    return new RenderHtmlText(listTempFiles).renderingHtmlText(it, ref par, parent);
                case "HtmlDiv":                    
                    return new RenderHtmlDiv(listTempFiles).renderingHtmlDiv(it, ref par, parent);
                case "HtmlSpan":                    
                    return new RenderHtmlSpan(listTempFiles).renderingHtmlSpan(it, ref par, parent);
                case "HtmlContent":                    
                    return new RenderHtmlContent(listTempFiles).renderingHtmlContent(it, ref par, parent);
                case "HtmlImg":                    
                    return new RenderHtmlImg(listTempFiles).renderingHtmlImg(it, ref par, parent, renderparent);
                case "HtmlTable":                    
                    return new RenderHtmlTable(listTempFiles).renderingHtmlTable(it, ref par, parent, renderparent);
                case "Htmltr":                    
                    return new RenderHtmltr(listTempFiles).renderingHtmltr(it, ref par, parent, renderparent);
                case "Htmltd":                    
                    return new RenderHtmltd(listTempFiles).renderingHtmltd(it, ref par, parent, renderparent);
                case "HtmlList":
                    return new RenderHtmlList(listTempFiles).renderingHtmlList(it, ref par, parent);
                case "HtmlLi":
                    return new RenderHtmlLi(listTempFiles).renderingHtmlLi(it, ref par, parent);
                case "HtmlCode":
                    return new RenderHtmlCode(listTempFiles).renderingHtmlCode(it, ref par, parent);
                default:
                    return null;
            }              
        }

        protected  decimal calculateWithText(int length, Unit sizeText)
        {
            return length * ((int)(sizeText.Value) * 5 / 8);
        }
        protected decimal calculateHeightText(int length, Unit sizeText)
        {
             //ff.Section.PageSetup.PageWidth=59 =>>210 mm A4
            return ((length / 210) + 1) * ((int)(sizeText.Value)*10/8);
            
        }
        protected string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        protected virtual HtmlItem renderingHtmlText(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            return null;
        }

        protected  virtual  HtmlItem renderingHtmlSpan(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            return null;
        }

        protected virtual HtmlItem renderingHtmlDiv(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            return null;
        }

        protected virtual HtmlItem renderingHtmlContent(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            return null;
        }      

        protected virtual HtmlItem renderingHtmlImg(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            return null;
        }

        protected virtual HtmlItem renderingHtmlTable(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            return null;
        }

        protected virtual  HtmlItem renderingHtmltr(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            return null;
        }

        protected virtual HtmlItem renderingHtmltd(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            return null;
        }
        protected virtual HtmlItem renderingHtmlList(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            return null;
        }
        protected virtual HtmlItem renderingHtmlLi(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            return null;
        }
        protected virtual HtmlItem renderingHtmlCode(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            return null;
        }
    }
}
