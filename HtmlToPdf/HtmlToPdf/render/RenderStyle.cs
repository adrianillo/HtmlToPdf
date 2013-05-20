using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace HtmlToPdf
{
    public  class RenderStyle
    {
        protected FormattedText Frmt;
        protected MigraDoc.DocumentObjectModel.Shapes.Image Imgt;
        protected MigraDoc.DocumentObjectModel.Tables.Table Tt;
        protected HtmlItem It;
        protected MigraDoc.DocumentObjectModel.Paragraph Prg;
        protected MigraDoc.DocumentObjectModel.Tables.Cell Cll;
        protected MigraDoc.DocumentObjectModel.ListInfo Lst;

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref FormattedText frmt)
        {
            return new RenderStyleFormattedText(it, ref frmt);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Tables.Table tt)
        {
            return new RenderStyleTable(it, ref tt);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Tables.Cell cl)
        {
            return new RenderStyleTd(it, ref cl);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it,ref MigraDoc.DocumentObjectModel.Shapes.Image imgt)
        {
            return new RenderStyleImage(it, ref imgt);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Paragraph prg)
        {
            return new RenderStyleParagraph(it, ref prg);
        }

        public static RenderStyle CreateRenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.ListInfo lst)
        {
            return new RenderStyleList(it, ref lst);
        }


        protected RenderStyle(HtmlItem it, ref FormattedText frmt)
        {}
        protected RenderStyle(HtmlItem it, ref  MigraDoc.DocumentObjectModel.Shapes.Image imgt)
        {}
        protected RenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Tables.Table tt)
        {}
        protected RenderStyle(HtmlItem it, ref MigraDoc.DocumentObjectModel.Tables.Cell cl)
        { }
        public RenderStyle()
        {}
        public virtual void Render()
        {}
       
    }
}
