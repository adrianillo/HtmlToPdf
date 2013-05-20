using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace HtmlToPdf
{
    public class RenderStyleParagraph : RenderStyle
    {
        public RenderStyleParagraph(HtmlItem it, ref Paragraph prg)
        {
            Prg = prg;
            It = it;
        }

        public override void Render()
        {
            if (It.StyleItem != null)
            {

                //Font-Family   
                if (It.StyleItem.FontFamily.hasValue())
                    if (MigraDoc.DocumentObjectModel.Font.Exists(It.StyleItem.FontFamily.Value))
                        Prg.Format.Font.Name = It.StyleItem.FontFamily.Value;

                // TextColor
                if (It.StyleItem.TextColor.hasValue())
                {

                    Prg.Format.Font.Color = new Color((uint)It.StyleItem.TextColor.Value.ToArgb());
                }
                //Size       
                if (It.StyleItem.TextSize.hasValue())
                    Prg.Format.Font.Size = It.StyleItem.TextSize.Value;
                //Border
                if (It.StyleItem.BorderWidth.hasValue())
                    Prg.Format.Borders.Width =(Unit) It.StyleItem.BorderWidth.Measure.Value;
                //Border Style
                if (It.StyleItem.BorderStyle.hasValue())
                    Prg.Format.Borders.Style = StyleOfBorder.GetBorderStyle(It.StyleItem.BorderStyle.Value);

                //Border Color
                if (It.StyleItem.BorderColor.hasValue())
                    Prg.Format.Borders.Color = new Color((uint)It.StyleItem.BorderColor.Value.ToArgb());

                //TextAling
                if (It.StyleItem.TextAlign.hasValue())
                {
                    switch (It.StyleItem.TextAlign.Value)
                    {
                        case StyleTextAlign.left:
                            Prg.Format.Alignment = ParagraphAlignment.Left;
                            break;
                        case StyleTextAlign.inherit:
                            Prg.Format.Alignment = ParagraphAlignment.Left;
                            break;
                        case StyleTextAlign.justify:
                            Prg.Format.Alignment = ParagraphAlignment.Justify;
                            break;
                        case StyleTextAlign.right:
                            Prg.Format.Alignment = ParagraphAlignment.Right;
                            break;
                        case StyleTextAlign.center:
                            Prg.Format.Alignment = ParagraphAlignment.Center;
                            break;
                    }
                }

                //margin left
                if (It.StyleItem.MarginLeft.hasValue())
                    Prg.Format.LeftIndent = (Unit)It.StyleItem.MarginLeft.Value;

                //margin right
                if (It.StyleItem.MarginRight.hasValue())
                    Prg.Format.RightIndent = (Unit)It.StyleItem.MarginRight.Value;

                //margin top
                if (It.StyleItem.MarginTop.hasValue())
                    Prg.Format.SpaceBefore = (Unit)It.StyleItem.MarginTop.Value;

                //margin botton
                if (It.StyleItem.MarginBottom.hasValue())
                    Prg.Format.SpaceAfter = (Unit)It.StyleItem.MarginBottom.Value;

                //Italic
                if (It.StyleItem.FontItalic.hasValue())
                    Prg.Format.Font.Italic = It.StyleItem.FontItalic.Value;

                //Underline
                if (It.StyleItem.TextDecorarion.hasValue())
                    if (It.StyleItem.TextDecorarion.Value == TextDecoration.underline)
                        Prg.Format.Font.Underline = Underline.Single;

                
              
            }

        }
    }
}
