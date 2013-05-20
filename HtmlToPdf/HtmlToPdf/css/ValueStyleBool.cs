using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class ValueStyleBool : ValueStyle
    {
        private bool value;

        public bool Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                base.ChangeValue(value);
            }
        }
        public override void ChangeValue(bool val)
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
