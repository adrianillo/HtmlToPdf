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
    public class RenderStyleTd : RenderStyle
    {
        public RenderStyleTd(HtmlItem it, ref  MigraDoc.DocumentObjectModel.Tables.Cell cc)
        {
            Cll = cc;
            It = it;
        }
        public override void Render()
        {
            if (It.StyleItem != null)
            {

                //Font-Family   
                if (It.StyleItem.FontFamily.hasValue())
                    if (MigraDoc.DocumentObjectModel.Font.Exists(It.StyleItem.FontFamily.Value))
                        Cll.Format.Font.Name = It.StyleItem.FontFamily.Value;

                // Text color
                if (It.StyleItem.TextColor.hasValue())
                {
                    Cll.Format.Font.Color = new Color((uint)It.StyleItem.TextColor.Value.ToArgb());

                }
                //Text size
                if (It.StyleItem.TextSize.hasValue())
                    Cll.Format.Font.Size = It.StyleItem.TextSize.Value;
                // BackGround-Color
                if (It.StyleItem.BackGroundColor.hasValue())
                    Cll.Shading.Color = new Color((uint)It.StyleItem.BackGroundColor.Value.ToArgb());

                //Border Width
                if (It.StyleItem.BorderWidth.hasValue())
                    Cll.Borders.Width = (Unit)It.StyleItem.BorderWidth.Measure.Value;

                //Border Style
                if (It.StyleItem.BorderStyle.hasValue())
                    Cll.Borders.Style = StyleOfBorder.GetBorderStyle( It.StyleItem.BorderStyle.Value);

                //Border Color
                if (It.StyleItem.BorderColor.hasValue())
                    Cll.Borders.Color = new Color((uint)It.StyleItem.BorderColor.Value.ToArgb());

                //margin left
                if (It.StyleItem.MarginLeft.hasValue())
                    Cll.Format.LeftIndent = (Unit)It.StyleItem.MarginLeft.Value;

                //margin right
                if (It.StyleItem.MarginRight.hasValue())
                    Cll.Format.RightIndent = (Unit)It.StyleItem.MarginRight.Value;

                //margin top
                if (It.StyleItem.MarginTop.hasValue())
                    Cll.Format.SpaceBefore = (Unit)It.StyleItem.MarginTop.Value;

                //margin bottom
                if (It.StyleItem.MarginBottom.hasValue())
                    Cll.Format.SpaceAfter = (Unit)It.StyleItem.MarginBottom.Value;

                //Italic
                if (It.StyleItem.FontItalic.hasValue())
                    Cll.Format.Font.Italic = It.StyleItem.FontItalic.Value;

                //Underline
                if (It.StyleItem.TextDecorarion.hasValue())
                    if (It.StyleItem.TextDecorarion.Value == TextDecoration.underline)
                        Cll.Format.Font.Underline = Underline.Single;

                /*
                //Width
                if (It.StyleItem.Width != null)
                    if (It.StyleItem.Width.Measure != null)
                        try
                        {
                            foreach (MigraDoc.DocumentObjectModel.Tables.Column c in Tt.Columns)
                                c.Width = (double)(It.StyleItem.Width.Measure / (decimal)Tt.Columns.Count);
                        }
                        catch { }

                //Height
                if (It.StyleItem.High != null)
                    if (It.StyleItem.High.Measure != null)
                        try
                        {
                            foreach (MigraDoc.DocumentObjectModel.Tables.Row r in Tt.Rows)
                                r.Height = (double)(It.StyleItem.High.Measure / (decimal)Tt.Rows.Count);
                        }
                        catch { }
                 * */
            }

        }
    }
}
