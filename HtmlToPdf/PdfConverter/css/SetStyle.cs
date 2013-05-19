using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class SetStyle
    {
        public SetStyle() { }

        public HtmlStyle AddPropertyValue(string name, string value, HtmlStyle style)
        {
            return new PrepareStyle().addStyleValue(name, value, style);
        }
    }
}
