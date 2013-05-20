using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace HtmlToPdf
{
    public class RenderStyleTable : RenderStyle
    {
        public RenderStyleTable(HtmlItem it, ref  MigraDoc.DocumentObjectModel.Tables.Table tt)
        {
            Tt = tt;
            It = it;
        }
        public override  void Render()
        {
            if (It.StyleItem != null)
            {

                //Font-Family   
                if (It.StyleItem.FontFamily.hasValue())
                    if (MigraDoc.DocumentObjectModel.Font.Exists(It.StyleItem.FontFamily.Value))
                        Tt.Format.Font.Name = It.StyleItem.FontFamily.Value;

                // Text color
                if (It.StyleItem.TextColor.hasValue())
                {
                    Tt.Format.Font.Color = new Color((uint)It.StyleItem.TextColor.Value.ToArgb());

                }
                //Text size
                if (It.StyleItem.TextSize.hasValue())
                    Tt.Format.Font.Size = It.StyleItem.TextSize.Value;
                // BackGround-Color
                if (It.StyleItem.BackGroundColor.hasValue())
                    Tt.Shading.Color= new Color((uint)It.StyleItem.BackGroundColor.Value.ToArgb());

                 //Text size
                //Border
                if (It.StyleItem.BorderWidth.hasValue())
                    Tt.Borders.Width = (Unit)It.StyleItem.BorderWidth.Measure.Value;
                //Border Style
                if (It.StyleItem.BorderStyle.hasValue())
                    Tt.Borders.Style = StyleOfBorder.GetBorderStyle(It.StyleItem.BorderStyle.Value);

                //Border Color
                if (It.StyleItem.BorderColor.hasValue())
                    Tt.Borders.Color = new Color((uint)It.StyleItem.BorderColor.Value.ToArgb());

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

                //margin left
                if (It.StyleItem.MarginLeft.hasValue())
                    Tt.LeftPadding = (Unit)It.StyleItem.MarginLeft.Value;

                //margin right
                if (It.StyleItem.MarginRight.hasValue())
                    Tt.RightPadding = (Unit)It.StyleItem.MarginRight.Value;

                //margin top
                if (It.StyleItem.MarginTop.hasValue())
                    Tt.TopPadding = (Unit)It.StyleItem.MarginTop.Value;

                //margin botton
                if (It.StyleItem.MarginBottom.hasValue())
                    Tt.BottomPadding = (Unit)It.StyleItem.MarginBottom.Value;

                //Italic
                if (It.StyleItem.FontItalic.hasValue())
                    Tt.Format.Font.Italic = It.StyleItem.FontItalic.Value;
                //Underline
                if (It.StyleItem.TextDecorarion.hasValue())
                    if (It.StyleItem.TextDecorarion.Value == TextDecoration.underline)
                        Tt.Format.Font.Underline = Underline.Single;
            }
            
        }
    }
}