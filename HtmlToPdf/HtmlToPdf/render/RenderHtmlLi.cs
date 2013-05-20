using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HtmlToPdf
{
    public class RenderHtmlLi : HtmlRender
    {
        public RenderHtmlLi(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
        protected override HtmlItem renderingHtmlLi(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            HtmlLi  l = it as HtmlLi;
            if (l != null)
            {
                foreach (HtmlItem i in it.ListItem)
                {
                 FormattedText ff = new FormattedText();
                 HtmlItem itemrendered =   renderingit(i, ref par, l, null);
                 HtmlText textitem = itemrendered as HtmlText;
                 //RenderStyle.CreateRenderStyle(it, ref ff).Render();

                 if (textitem != null)
                 {
                     ff.Add(new Text(textitem.Text));
                     par.Add(ff);
                     it.SizeRenderItem.Width = calculateWithText(textitem.Text.Length, ff.Size);
                   
                     if (it.SizeRenderItem.Width > 210)
                         it.SizeRenderItem.Width = 210;
                     it.SizeRenderItem.Height = calculateHeightText(textitem.Text.Length, ff.Size);

                 }
                }
            }

            return l;
        }
    }
}
