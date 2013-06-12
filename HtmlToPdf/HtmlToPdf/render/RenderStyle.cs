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
    public  class RenderStyle
    {
        protected FormattedText Frmt;
        protected MigraDoc.DocumentObjectModel.Shapes.Image Imgt;
        protected MigraDoc.DocumentObjectModel.Tables.Table Tt;
        protected HtmlItem It;
        protected MigraDoc.DocumentObjectModel.Paragraph Prg;
        protected MigraDoc.DocumentObjectModel.Tables.Cell Cll;
        protected MigraDoc.DocumentObjectModel.ListInfo Lst;

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref FormattedText frmt)
        {
            return new RenderStyleFormattedText(it, ref frmt);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Tables.Table tt)
        {
            return new RenderStyleTable(it, ref tt);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Tables.Cell cl)
        {
            return new RenderStyleTd(it, ref cl);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it,ref MigraDoc.DocumentObjectModel.Shapes.Image imgt)
        {
            return new RenderStyleImage(it, ref imgt);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Paragraph prg)
        {
            return new RenderStyleParagraph(it, ref prg);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.ListInfo lst)
        {
            return new RenderStyleList(it, ref lst);
        }


        protected RenderStyle(HtmlItem it, ref FormattedText frmt)
        {}
        protected RenderStyle(HtmlItem it, ref  MigraDoc.DocumentObjectModel.Shapes.Image imgt)
        {}
        protected RenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Tables.Table tt)
        {}
        protected RenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Tables.Cell cl)
        { }
        public RenderStyle()
        {}
        public virtual void Render()
        {}
       
    }
}
