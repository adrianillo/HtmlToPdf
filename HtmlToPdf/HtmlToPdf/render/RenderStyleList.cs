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
namespace HtmlToPdf
{
    public class RenderStyleList : RenderStyle
    {
        public RenderStyleList(HtmlItem it, ref MigraDoc.DocumentObjectModel.ListInfo lst)
        {
            Lst = lst;
            It = it;
        }

        public override   void  Render()
        {
            if (It.StyleItem != null)
            {
                //type BulletList 
                if (It.StyleItem.ListStyleType.hasValue())                
                    Lst.ListType = ListOfStyleType.GetListStyleType(It.StyleItem.ListStyleType.Value);
                
                //margin left
                if (It.StyleItem.MarginLeft.hasValue())
                    Lst.NumberPosition =(Unit) It.StyleItem.MarginLeft.Value;

          
                
            }
          
        }
    }
}
