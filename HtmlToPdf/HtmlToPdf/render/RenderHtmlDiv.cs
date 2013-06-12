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
