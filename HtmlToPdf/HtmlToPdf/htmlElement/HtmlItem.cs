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

namespace HtmlToPdf
{
    public class HtmlItem:IHtmlItem
    {
       
        object IHtmlItem.IHtmlElement
        {
            get { return this; }
        }

        private HtmlStyle styleItem;

        public HtmlStyle StyleItem
        {
            get { return styleItem; }
            set { styleItem = value; }
        }

        private List<IHtmlItem> listItem = new List<IHtmlItem>();

        public List<IHtmlItem> ListItem
        {
            get { return listItem; }
            set { listItem = value; }
        }

        private RenderSizeItem sizeRenderItem= new RenderSizeItem ();

        public RenderSizeItem SizeRenderItem
        {
            get { return sizeRenderItem; }
            set { sizeRenderItem = value; }
        }

    }
    public class RenderSizeItem
    {
        private decimal width=0;

        public decimal Width
        {
            get { return width; }
            set { width = value; }
        }

        private decimal height = 0;

        public decimal Height
        {
            get { return height; }
            set { height = value; }
        }
    }
}
