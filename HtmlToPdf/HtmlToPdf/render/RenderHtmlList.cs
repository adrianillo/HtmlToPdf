using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HtmlToPdf
{
    public class RenderHtmlList : HtmlRender
    {
        public RenderHtmlList(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
        private static bool isText(IHtmlItem s)
        {
            if (s is HtmlText)
                return true;
            else
                return false;
        }

        protected override HtmlItem renderingHtmlList(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            HtmlList uol = it as HtmlList;
            
            if (uol != null)
            {
                foreach (HtmlLi l in uol.ListLi)
                {                    
                    if (l.ListItem.Exists(isText))
                    {
                        ListInfo listinfo = new ListInfo();
                        listinfo.ContinuePreviousList = true;
                        listinfo.ListType = ListType.BulletList1; // default
                        listinfo.NumberPosition = 25 * uol.Level; // BulletList margin default
                        RenderStyle.CreateRenderStyle(uol, ref listinfo).Render(); // render styles element                        
                        Paragraph newpar = par.Section.AddParagraph();
                        RenderStyle.CreateRenderStyle(uol, ref newpar).Render(); // render styles paragraph
                        newpar.Format.ListInfo = listinfo;
                        
                        renderingit(l, ref newpar, uol, null);
                    }
                    else
                        renderingit(l, ref par, uol, null);
                }            
            }
            if (!(parent is HtmlLi))
                par.Section.AddParagraph().AddLineBreak();
            return uol;
            
        }
    }
}
