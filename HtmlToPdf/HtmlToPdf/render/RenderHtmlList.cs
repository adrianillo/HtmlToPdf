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
    public class RenderHtmlList : HtmlRender
    {
        public RenderHtmlList(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
        private static bool isText(IHtmlItem s)
        {
            if (s is HtmlText)
                return true;
            else
                return false;
        }

        protected override HtmlItem renderingHtmlList(HtmlItem it, ref Paragraph par, HtmlItem parent)
        {
            HtmlList uol = it as HtmlList;
            
            if (uol != null)
            {
                foreach (HtmlLi l in uol.ListLi)
                {                    
                    if (l.ListItem.Exists(isText))
                    {
                        ListInfo listinfo = new ListInfo();
                        listinfo.ContinuePreviousList = true;
                        listinfo.ListType = ListType.BulletList1; // default
                        listinfo.NumberPosition = 25 * uol.Level; // BulletList margin default
                        RenderStyle.CreateRenderStyle(uol, ref listinfo).Render(); // render styles element                        
                        Paragraph newpar = par.Section.AddParagraph();
                        RenderStyle.CreateRenderStyle(uol, ref newpar).Render(); // render styles paragraph
                        newpar.Format.ListInfo = listinfo;
                        
                        renderingit(l, ref newpar, uol, null);
                    }
                    else
                        renderingit(l, ref par, uol, null);
                }            
            }
            if (!(parent is HtmlLi))
                par.Section.AddParagraph().AddLineBreak();
            return uol;
            
        }
    }
}
