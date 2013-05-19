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
