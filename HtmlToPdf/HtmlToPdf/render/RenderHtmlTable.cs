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
