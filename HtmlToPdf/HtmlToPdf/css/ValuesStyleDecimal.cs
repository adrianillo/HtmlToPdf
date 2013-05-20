using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class ValuesStyleDecimal : ValueStyle
    {
        private decimal value;

        public decimal Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                base.ChangeValue(value);
            }
        }
        public override void ChangeValue(decimal val)
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
