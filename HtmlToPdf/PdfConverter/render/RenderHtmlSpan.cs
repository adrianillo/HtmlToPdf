using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HtmlToPdf
{
    public  class RenderHtmlSpan :HtmlRender
    {
        public RenderHtmlSpan(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }

        protected  override HtmlItem renderingHtmlSpan(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            HtmlSpan span = it as HtmlSpan;
            if (span != null)
            {
                foreach (HtmlItem t in it.ListItem)
                {
                    FormattedText ff = new FormattedText();
                    if (span.Size.hasValue())
                        ff.Size = span.Size.Value;
                    if (span.Bold.hasValue())
                        ff.Bold = span.Bold.Value;
                    if (span.Sub.hasValue())
                        ff.Subscript = span.Sub.Value;
                    if (span.Super.hasValue())
                        ff.Superscript = span.Super.Value;

                    RenderStyle.CreateRenderStyle(it, ref ff).Render(); // render styles element

                    HtmlItem itemrendered = renderingit(t, ref par, it, null);
                    HtmlText textitem = itemrendered as HtmlText;
                    if (textitem != null)
                    {
                        ff.Add(new Text(textitem.Text));
                        it.SizeRenderItem.Width = calculateWithText(textitem.Text.Length, ff.Size);
                        if (it.SizeRenderItem.Width > 210)
                            it.SizeRenderItem.Width = 210;
                        it.SizeRenderItem.Height = calculateHeightText(textitem.Text.Length, ff.Size);
                    }

                    par.Add(ff);

                }
            }
            return span;
        }
    }
}
