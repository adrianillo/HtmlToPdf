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

namespace HtmlToPdf
{
   public  enum BorderStyleValue { DashDot = 1, DashDotDot = 2, DashLargeGap = 3, DashSmallGap = 4, Dot = 5, None = 6, Single=7 }

    public static class StyleOfBorder
    {
        public static BorderStyleValue GetBorderStyle(string v)
        {
            switch (v.ToLower().Trim())
            {
                case "none":
                    return BorderStyleValue.None;
                case "hidden":
                    return BorderStyleValue.None;
                case "dotted":
                    return BorderStyleValue.Dot;
                case "solid":
                    return BorderStyleValue.Single;
                case "dashed":
                    return BorderStyleValue.DashDot;
                default:
                    return BorderStyleValue.Single;
            }           
        }
        public static MigraDoc.DocumentObjectModel.BorderStyle GetBorderStyle(BorderStyleValue v)
        {         
            switch (v)
            {
                case BorderStyleValue.None:
                    return MigraDoc.DocumentObjectModel.BorderStyle.None;
                case BorderStyleValue.DashDot:
                    return MigraDoc.DocumentObjectModel.BorderStyle.DashDot;
                case BorderStyleValue.DashLargeGap:
                    return MigraDoc.DocumentObjectModel.BorderStyle.DashDotDot;
                case BorderStyleValue.DashSmallGap:
                    return MigraDoc.DocumentObjectModel.BorderStyle.DashLargeGap;
                case BorderStyleValue.Dot:
                    return MigraDoc.DocumentObjectModel.BorderStyle.Dot;
                case BorderStyleValue.Single:
                    return MigraDoc.DocumentObjectModel.BorderStyle.Single;                    
                default:
                    return MigraDoc.DocumentObjectModel.BorderStyle.Single;
            }
        }
    }

    public class ValueStyleBorderStyle : ValueStyle
    {
        private BorderStyleValue value;

        internal BorderStyleValue Value
        {
            get { return value; }
            set
            {
               this.value = value;
               base.ChangeValue(value);

            }
        }

        public override void ChangeValue(BorderStyleValue val)
        {
            Value = val;
            base.ChangeValue(value);
        }
        public override object GetValue()
        {
            return Value;
        }
    }
}
