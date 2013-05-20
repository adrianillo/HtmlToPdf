using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace HtmlToPdf
{
    public class RenderStyleImage:RenderStyle
    {
        public RenderStyleImage(HtmlItem it, ref  MigraDoc.DocumentObjectModel.Shapes.Image imgt)
        {
            Imgt = imgt;
            It = it;
        }

        public override   void Render()
        {
            //Border
            if (It.StyleItem.BorderWidth.hasValue())
                Imgt.LineFormat.Width= (Unit)It.StyleItem.BorderWidth.Measure.Value;

            //Border Color
            if (It.StyleItem.BorderColor.hasValue())
                Imgt.LineFormat.Color = new Color((uint)It.StyleItem.BorderColor.Value.ToArgb());            

            if (It.StyleItem != null)
            {
                //Width
                if (It.StyleItem.Width != null)
                    if (It.StyleItem.Width.Measure != null)
                        try
                        {
                            Imgt.Width = (Unit)It.StyleItem.Width.Measure;
                        }
                        catch { }

                //Height
                if (It.StyleItem.High != null)
                    if (It.StyleItem.High.Measure != null)
                        try
                        {
                            Imgt.Height = (Unit)It.StyleItem.High.Measure;
                        }
                        catch { }
            }

            //margin left
            if (It.StyleItem.MarginLeft.hasValue())
                Imgt.WrapFormat.DistanceLeft = (Unit)It.StyleItem.MarginLeft.Value;

            //margin right
            if (It.StyleItem.MarginRight.hasValue())
                Imgt.WrapFormat.DistanceRight = (Unit)It.StyleItem.MarginRight.Value;

            //margin top
            if (It.StyleItem.MarginTop.hasValue())
                Imgt.WrapFormat.DistanceTop = (Unit)It.StyleItem.MarginTop.Value;
            //margin botton
            if (It.StyleItem.MarginBottom.hasValue())
                Imgt.WrapFormat.DistanceBottom = (Unit)It.StyleItem.MarginBottom.Value;
                
           
        }

    }
}
