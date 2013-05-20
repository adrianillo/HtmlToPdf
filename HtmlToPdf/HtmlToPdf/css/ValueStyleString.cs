using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class ValueStyleString : ValueStyle
    {
        private string  value;

        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                base.ChangeValue(value);
            }
        }
        public override void ChangeValue(string val)
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
