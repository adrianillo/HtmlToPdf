using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace HtmlToPdf
{
    public class RenderStyleFormattedText : RenderStyle
    {
        public RenderStyleFormattedText(HtmlItem it, ref FormattedText frmt)
        {
            Frmt = frmt;
            It = it;
        }

        public override   void  Render()
        {
            if (It.StyleItem != null)
            {
                // TextColor
                if (It.StyleItem.TextColor.hasValue())
                {
                    Frmt.Color = new Color((uint)It.StyleItem.TextColor.Value.ToArgb());
                }
                //Size   
                if (It.StyleItem.TextSize.hasValue() )
                    Frmt.Size = It.StyleItem.TextSize.Value;
                //Font-Family   
                if (It.StyleItem.FontFamily.hasValue())
                    if (MigraDoc.DocumentObjectModel.Font.Exists(It.StyleItem.FontFamily.Value))
                        Frmt.Font.Name = It.StyleItem.FontFamily.Value;

                //Italic
                if (It.StyleItem.FontItalic.hasValue())
                    Frmt.Font.Italic = It.StyleItem.FontItalic.Value;

                //Underline
                if (It.StyleItem.TextDecorarion.hasValue())
                    if (It.StyleItem.TextDecorarion.Value == TextDecoration.underline)
                        Frmt.Font.Underline = Underline.Single;
          
            }
          
        }
    }
}
