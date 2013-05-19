using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class ValueStyleColor : ValueStyle
    {
        System.Drawing.Color value;

        public System.Drawing.Color Value
        {
            get { return this.value; }
            set { 
                this.value = value;
                base.ChangeValue();
            }
        }

        public override void ChangeValue(System.Drawing.Color val)
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
