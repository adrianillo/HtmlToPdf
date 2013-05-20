using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;


namespace HtmlToPdf
{
    public class RenderHtmlDiv : HtmlRender
    {
        public RenderHtmlDiv(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }

        protected override HtmlItem renderingHtmlDiv(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            HtmlDiv div = it as HtmlDiv;
            if (div != null)
            {
                foreach (HtmlItem t in it.ListItem)
                {
                    FormattedText ff = new FormattedText();
                    RenderStyle.CreateRenderStyle(it, ref ff).Render(); //Render styles element

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
                par.AddLineBreak();
            }
            return div;
        }
    }
}
