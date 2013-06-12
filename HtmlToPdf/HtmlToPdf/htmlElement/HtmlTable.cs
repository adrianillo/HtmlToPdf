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
    public class HtmlTable : HtmlItem
    {
        private int cells = 0;

        public int Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        private List<Htmltr> listtr = new List<Htmltr>();

        public List<Htmltr> Listtr
        {
            get { return listtr; }
            set { listtr = value; }
        }

    }

    public class Htmltr : HtmlItem
    {
     
        private HtmlTable parent;

        private int cellsinrow = 0;

        public int Cellsinrow
        {
            get { return cellsinrow; }
            set { cellsinrow = value; }
        }

        private List<Htmltd> listtd = new List<Htmltd>();

        public List<Htmltd> Listtd
        {
            get { return listtd; }
            set { listtd = value; }
        }
        public void SetWidth(decimal width)
        {
            this.SizeRenderItem.Width=width;
            if(this.SizeRenderItem.Width>tableparent.SizeRenderItem.Width)
                tableparent.SizeRenderItem.Width = this.SizeRenderItem.Width;
        }
        public void SetHeight(decimal height)
        {
            this.SizeRenderItem.Height = height;
            if (this.SizeRenderItem.Height > tableparent.SizeRenderItem.Height)
                tableparent.SizeRenderItem.Height = this.SizeRenderItem.Height;
        }
        private HtmlTable tableparent;

        public void SetTableParent(HtmlTable parenttable)
        {
            tableparent = parenttable;
        }
        public HtmlTable GetTableParent()
        {
            return tableparent ;
        }
    }

    public class Htmltd : HtmlItem
    {
        private int indexCell = 0;

        public int IndexCell
        {
            get { return indexCell; }
            set { indexCell = value; }
        }
        private Htmltr trparent;

        public void SetTrParent(Htmltr parentr)
        {
            trparent = parentr;
        }
        public Htmltr GetTrParent()
        {
            return trparent;
        }
        public void SetWidth(decimal width)
        {
            this.SizeRenderItem.Width = width;
            trparent.SetWidth(trparent.SizeRenderItem.Width + width);
        }
        public void SetHeight(decimal height)
        {
            this.SizeRenderItem.Height = height;
            if (trparent.SizeRenderItem.Height < height)
                trparent.SetHeight(height);
        }
    }
}
