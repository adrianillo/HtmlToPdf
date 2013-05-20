using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public interface IHtmlItem
    {
        Object IHtmlElement { get; }
        HtmlStyle StyleItem { get; set; }
        List<IHtmlItem> ListItem { get; set; }
        
    }
}


