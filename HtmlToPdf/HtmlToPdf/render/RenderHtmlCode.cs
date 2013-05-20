using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace HtmlToPdf
{
    public class RenderHtmlCode : HtmlRender
    {
        public RenderHtmlCode(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
            protected override HtmlItem renderingHtmlCode(HtmlItem it, ref Paragraph par, HtmlItem parent)
            {
                return null;
            }
        
    }
}
