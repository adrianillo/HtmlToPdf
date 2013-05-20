using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class HtmlText : HtmlItem
    {
        private string text=string.Empty;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

       

        public HtmlText()
        { }
    }
}
