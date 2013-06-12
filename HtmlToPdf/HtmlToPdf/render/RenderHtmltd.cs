/**
 * HtmlToPdf
 * Copyright (c)2013 adrianillo
 *
 * adrianillo
 * elcorreillodeadrianillo@gmail.com
 * twitter:@adrianillo
 *
 * Licensed under the MIT license.
 * 
 * Permission is hereby granted, free of charge, to any
 * person obtaining a copy of this software and associated
 * documentation files (the "Software"), to deal in the
 * Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the
 * Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions: 
 *
 * The above copyright notice and this permission notice
 * shall be included in all copies or substantial portions of
 * the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 */
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
