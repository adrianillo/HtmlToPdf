using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class HtmlLi:HtmlItem
    {
        private HtmlList parentList;

        public HtmlList ParentList
        {
            get { return parentList; }
            set { parentList = value; }
        }

    }
}
