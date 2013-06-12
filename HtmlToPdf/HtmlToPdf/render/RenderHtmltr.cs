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
