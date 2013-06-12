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
    public enum modeMeasure { px = 1, percentage = 2 }
    public class StyleMeasureElement:ValueStyle
    {
        private modeMeasure nodeMeasure = modeMeasure.px;

        public modeMeasure NodeMeasure
        {
            get { return nodeMeasure; }
            set {
                nodeMeasure = value;
                base.ChangeValue();
            }
        }

        private decimal? measure;

        public decimal? Measure
        {
            get { return measure; }
            set {
                measure = value;
                base.ChangeValue();
            }
        }
        public override void ChangeValue(modeMeasure mode, decimal val)
        {
            this.Measure = val;
            this.nodeMeasure = mode;        
            base.ChangeValue(mode,val);
        }

        public override object GetValue()
        {
            return this;
        }

    }
}
