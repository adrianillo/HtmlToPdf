using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;


namespace HtmlToPdf
{
    public class RenderHtmltd : HtmlRender
    {
        public RenderHtmltd(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
        protected override  HtmlItem renderingHtmltd(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            MigraDoc.DocumentObjectModel.Tables.Row rw = renderparent as MigraDoc.DocumentObjectModel.Tables.Row;

            Htmltd tb = it as Htmltd;
            if (tb != null)
            {
                if (rw != null)
                {
                    Htmltr tr = parent as Htmltr;
                    if (tr != null)// properties of tr
                    {
                        tb.SetTrParent(tr);
                        HtmlTable tbl = tr.GetTableParent();
                        if (tbl != null)// properties of table
                        {
                            tr.SetTableParent(tbl);
                        }
                    }
                  
                    //add paragraph to the cell
                    Paragraph paragrcell = rw[tb.IndexCell].AddParagraph();
                   
                    //render style cell content  
                   // RenderStyle.CreateRenderStyle(it, ref paragrcell).Render();
                    MigraDoc.DocumentObjectModel.Tables.Cell cc = rw[tb.IndexCell];
                    RenderStyle.CreateRenderStyle(it, ref cc).Render();
                    //reder  elements in cell
                    decimal minWidthCell = 0;
                    decimal minWidthCellpar = 0;
                    decimal minHeightCell = 0;
                    decimal minHeightCellpar = 0;
                    foreach (HtmlItem t in it.ListItem)
                    {
                        FormattedText ff = new FormattedText();

                        RenderStyle.CreateRenderStyle(it, ref ff).Render();

                        if (rw.Table.Columns.Count > tb.IndexCell)
                        {
                            renderingit(t, ref paragrcell, null, rw[tb.IndexCell]);
                            Iheight hh = t as Iheight;
                            if (hh != null)
                            {
                                if (minWidthCell < minWidthCellpar)
                                    minWidthCell = minWidthCellpar;

                                if (minHeightCell < minHeightCellpar)
                                    minHeightCell = minHeightCellpar;

                                minWidthCellpar = 0;
                            }
                            if (t.StyleItem != null)// width of style
                                if (t.StyleItem.Width != null)
                                    if (t.StyleItem.Width.Measure.HasValue)
                                        if (t.StyleItem.Width.Measure.Value > t.SizeRenderItem.Width)
                                            t.SizeRenderItem.Width = t.StyleItem.Width.Measure.Value;
                            minWidthCellpar += t.SizeRenderItem.Width;

                            if (t.StyleItem != null)// height of style
                                if (t.StyleItem.Width != null)
                                    if (t.StyleItem.High.Measure.HasValue)
                                        if (t.StyleItem.High.Measure.Value > t.SizeRenderItem.Height)
                                            t.SizeRenderItem.Height = t.StyleItem.High.Measure.Value;
                            minHeightCellpar += t.SizeRenderItem.Height;

                            if (t is HtmlTable) //Always insert a margin Migradoc when table is in a cell
                                minHeightCellpar += 25;
                        }
                    }
                    if (minWidthCellpar > minWidthCell)
                        minWidthCell = minWidthCellpar;

                    if (minHeightCellpar > minHeightCell)
                        minHeightCell = minHeightCellpar;

                    if (rw[tb.IndexCell].Column.Width < (Unit)minWidthCell)
                    {
                        rw[tb.IndexCell].Column.Width = (Unit)minWidthCell;
                        tb.SetWidth(minWidthCell);
                    }

                    if (rw[tb.IndexCell].Row.Height < (Unit)minHeightCell)
                    {
                        rw[tb.IndexCell].Row.Height = (Unit)minHeightCell;
                        tb.SetHeight(minHeightCell);
                    }

                }
            }
            return tb;
        }
    }
}
