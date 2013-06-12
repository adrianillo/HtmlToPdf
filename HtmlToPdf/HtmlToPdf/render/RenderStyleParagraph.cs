/**
 * HtmlToPdf
 * Copyright (c)2013 adrianillo
 *
 * adrianillo
 * elcorreillodeadrianillo@gmail.com
 * twitter:@adrianillo
 *
 * Licensed under the MIT license.
 * 
 * Permission is hereby granted, free of charge, to any
 * person obtaining a copy of this software and associated
 * documentation files (the "Software"), to deal in the
 * Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the
 * Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions: 
 *
 * The above copyright notice and this permission notice
 * shall be included in all copies or substantial portions of
 * the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 */
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
