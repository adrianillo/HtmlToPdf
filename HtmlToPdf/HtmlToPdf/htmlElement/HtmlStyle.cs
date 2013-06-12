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
using System.Collections;


namespace HtmlToPdf
{
    public class HtmlStyle
    {
        public HtmlStyle()
        { }

        private ValueStyleTextAlign textAlign = new ValueStyleTextAlign();

        public ValueStyleTextAlign TextAlign
        {
            get { return textAlign; }
            set { textAlign = value; }
        }

        private ValueStyleFloat align = new ValueStyleFloat();

        public ValueStyleFloat Align
        {
            get { return align; }
            set { align = value; }
        }

        private ValuesStyleDecimal marginLeft = new ValuesStyleDecimal();

        public ValuesStyleDecimal MarginLeft
        {
            get { return marginLeft; }
            set { marginLeft = value; }
        }

        private ValuesStyleDecimal marginRight = new ValuesStyleDecimal();

        public ValuesStyleDecimal MarginRight
        {
            get { return marginRight; }
            set { marginRight = value; }
        }

        private ValuesStyleDecimal marginTop = new ValuesStyleDecimal();

        public ValuesStyleDecimal MarginTop
        {
            get { return marginTop; }
            set { marginTop = value; }
        }

        private ValuesStyleDecimal marginBottom = new ValuesStyleDecimal();

        public ValuesStyleDecimal MarginBottom
        {
            get { return marginBottom; }
            set { marginBottom = value; }
        }        

        private ValueStyleUint textSize= new ValueStyleUint ();
        public ValueStyleUint TextSize
        {
            get { return textSize; }
            set { textSize = value; }
        }

        private ValueStyleString fontFamily = new ValueStyleString();

        public ValueStyleString FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; }
        }

        private ValueStyleColor textColor= new ValueStyleColor ();
        public ValueStyleColor TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        private ValueStyleColor backGroundColor= new ValueStyleColor ();
        public ValueStyleColor BackGroundColor
        {
            get { return backGroundColor; }
            set { backGroundColor = value; }
        }

        private ValueStyleBool bold= new ValueStyleBool () ; 
        public ValueStyleBool Bold
        {
            get { return bold; }
            set { bold = value; }
        }

        private ValueStyleBool fontItalic = new ValueStyleBool();
        public ValueStyleBool FontItalic
        {
            get { return fontItalic; }
            set { fontItalic = value; }
        }        

        private StyleMeasureElement width = new StyleMeasureElement();
        public StyleMeasureElement Width
        {
            get { return width; }
            set { width = value; }
        }

        private StyleMeasureElement high = new StyleMeasureElement();
        public StyleMeasureElement High
        {
            get { return high; }
            set { high = value; }
        }

        private StyleMeasureElement borderWidth = new StyleMeasureElement();
        public StyleMeasureElement BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        private ValueListStyleTextDecoration textDecorarion = new ValueListStyleTextDecoration();

        public ValueListStyleTextDecoration TextDecorarion
        {
            get { return textDecorarion; }
            set { textDecorarion = value; }
        }

        

        private ValueStyleBorderStyle borderStyle= new ValueStyleBorderStyle ();

        public ValueStyleBorderStyle BorderStyle
        {
            get { return borderStyle; }
            set { borderStyle = value; }
        }

        private ValueStyleColor borderColor = new ValueStyleColor();
        public ValueStyleColor BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        private ValueListStyleType listStyleType = new ValueListStyleType();

        public ValueListStyleType ListStyleType
        {
            get { return listStyleType; }
            set { listStyleType = value; }
        }


        public HtmlStyle AddStyle(HtmlStyle addstyle)
        {                 
            foreach (var a in addstyle.GetType().GetProperties())
            {
                var v = a.GetValue(addstyle, null);
                ValueStyle vstyle = v as ValueStyle;
                if (vstyle != null)
                {
                    if(vstyle.hasValue())
                    {
                        var vs= vstyle.GetValue();
                        if (vs != null)
                        {
                            this.GetType().GetProperty(a.Name).SetValue(this,v,null);                        
                        }
                       
                    }
                }              
               
            }
            return this;
        }


     
    }


}
