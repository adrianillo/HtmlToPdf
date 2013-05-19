using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HtmlToPdf
{
    public class RenderHtmltr : HtmlRender
    {
        public RenderHtmltr(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
        protected override  HtmlItem renderingHtmltr(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            Htmltr tr = it as Htmltr;
            MigraDoc.DocumentObjectModel.Tables.Row rw = null;
            if (tr != null)
            {
                HtmlTable tb = parent as HtmlTable;
                if (tb != null)
                {
                    MigraDoc.DocumentObjectModel.Tables.Table tt = renderparent as MigraDoc.DocumentObjectModel.Tables.Table;
                    if (tt != null)
                    {
                        if (tt.Columns.Count > 0)
                            rw = tt.AddRow();

                        tr.SetTableParent(tb);
                    }

                }
                foreach (HtmlItem t in it.ListItem)
                {
                    FormattedText ff = new FormattedText();
                    RenderStyle.CreateRenderStyle(it, ref ff).Render();
                    HtmlItem itemrendered = renderingit(t, ref par, it, rw);
                }
            }
            return tr;
        }
    }
}
