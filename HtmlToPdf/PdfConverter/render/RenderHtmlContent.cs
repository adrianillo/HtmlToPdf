using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HtmlToPdf
{
    public class RenderHtmlContent : HtmlRender
    {
        public RenderHtmlContent(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
        protected override  HtmlItem renderingHtmlContent(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            HtmlContent content = it as HtmlContent;
            if (content != null)
            {
                if (parent is HtmlContent)
                    par.AddLineBreak();

                foreach (HtmlItem t in it.ListItem)
                {
                    FormattedText ff = new FormattedText();
                    if (content.Bold.hasValue())
                        ff.Bold = content.Bold.Value;
                    if (content.Size.hasValue())
                        ff.Size = content.Size.Value;

                    RenderStyle.CreateRenderStyle(it, ref ff).Render();

                    HtmlItem itemrendered = renderingit(t, ref par, it, null);
                    HtmlText textitem = itemrendered as HtmlText;
                    if (textitem != null)
                    {
                        ff.Add(new Text(textitem.Text));
                        par.Add(ff);
                        it.SizeRenderItem.Width = calculateWithText(textitem.Text.Length, ff.Size);

                        //ff.Section.PageSetup.PageWidth=59 =>>210 mm A4
                        if (it.SizeRenderItem.Width > 210)
                            it.SizeRenderItem.Width = 210;
                        it.SizeRenderItem.Height = calculateHeightText(textitem.Text.Length, ff.Size);

                    }
                }
                par.AddLineBreak();
            }
            return content;
        }
    }
}
