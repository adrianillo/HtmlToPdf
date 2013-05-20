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
