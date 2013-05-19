using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HtmlToPdf
{
    public class RenderHtmlTable : HtmlRender
    {
        public RenderHtmlTable(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
        protected override  HtmlItem renderingHtmlTable(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            HtmlTable tbl = it as HtmlTable;
            MigraDoc.DocumentObjectModel.Shapes.TextFrame tf = null;
            Paragraph partf = null;
            if (tbl != null)
            {
                MigraDoc.DocumentObjectModel.Tables.Table tt = null;
                MigraDoc.DocumentObjectModel.Tables.Cell cellparent = renderparent as MigraDoc.DocumentObjectModel.Tables.Cell;
                if (cellparent != null)
                {
                    tf = cellparent.AddTextFrame();
                    tt = tf.AddTable();
                    partf = tf.AddParagraph();

                }
                else
                    tt = par.Section.AddTable();

                tbl.SizeRenderItem.Width = 0;
                for (int i = 0; i < tbl.Cells; i++)
                {
                    MigraDoc.DocumentObjectModel.Tables.Column cc = tt.AddColumn();

                }

                foreach (HtmlItem t in it.ListItem)
                {
                    FormattedText ff = new FormattedText();
                    RenderStyle.CreateRenderStyle(it, ref ff).Render();
                    if (partf != null)
                        renderingit(t, ref partf, it, tt);
                    else
                        renderingit(t, ref par, it, tt);
                }
                RenderStyle.CreateRenderStyle(it, ref tt).Render();

            }
            return tbl;
        }
    }
}
