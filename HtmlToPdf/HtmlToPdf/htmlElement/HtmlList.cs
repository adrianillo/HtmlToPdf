using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public enum typeHtmlList {ol=1, ul=2 }
    public class HtmlList:HtmlItem
    {
        private typeHtmlList htmlListType;

        public  typeHtmlList HtmlListType
        {
            get { return htmlListType; }
            set { htmlListType = value; }
        }

        private List<HtmlLi> listLi= new List<HtmlLi> ();

        public List<HtmlLi> ListLi
        {
            get { return listLi; }
            set { listLi = value; }
        }

        private int level = 1;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

    }
}
