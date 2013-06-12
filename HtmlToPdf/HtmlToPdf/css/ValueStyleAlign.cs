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
    public enum StyleFloat {none=0, left = 1, right = 2, inherit = 3 }
    public enum StyleTextAlign { none = 0, left = 1, right = 2, center = 3, justify = 4, inherit = 5 }

    public static class Aling
    {
        public static StyleFloat GetAling(string v)
        {
            switch (v.ToLower().Trim())
            {
                case "left":
                    return StyleFloat.left;
                case "right":
                    return StyleFloat.right;
                case "none":
                    return StyleFloat.none;
                case "inherit":
                    return StyleFloat.inherit;
            }
            return StyleFloat.left;
        }

        public static StyleTextAlign GetTextAling(string v)
        {
            switch (v.ToLower().Trim())
            {
                case "center":
                    return StyleTextAlign.center;
                case "inherit":
                    return StyleTextAlign.inherit;
                case "justify":
                    return StyleTextAlign.justify;
                case "left":
                    return StyleTextAlign.left;
                case "right":
                    return StyleTextAlign.right;
            }
            return StyleTextAlign.left;
        }
    }

    public class ValueStyleFloat : ValueStyle
    {
        private StyleFloat value;

        public StyleFloat Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                base.ChangeValue(value);
            }
        }
        public override void ChangeValue(StyleFloat val)
        {
            Value = val;
            base.ChangeValue(value);
        }
        public override object GetValue()
        {
            return Value;
        }
    }

    public class ValueStyleTextAlign : ValueStyle
    {
        private StyleTextAlign value;

        public StyleTextAlign Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                base.ChangeValue(value);
            }
        }
        public override void ChangeValue(StyleTextAlign val)
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
