using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HtmlToPdf
{
    public class RenderHtmlText : HtmlRender
    {
        public RenderHtmlText(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }

         protected override HtmlItem renderingHtmlText(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            HtmlText te = it as HtmlText;
            if (te != null)
            {
                if (parent == null)
                {
                    par.AddText(te.Text);
                    it.SizeRenderItem.Width =calculateWithText( te.Text.Length ,8);
                    if (it.SizeRenderItem.Width > 210)
                        it.SizeRenderItem.Width = 210;
                    it.SizeRenderItem.Height = calculateHeightText(te.Text.Length, 8);
                }
            }
            
            return te;
        }
    }
}
