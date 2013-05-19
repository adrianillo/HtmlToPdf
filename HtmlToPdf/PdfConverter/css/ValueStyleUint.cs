using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class ValueStyleUint:ValueStyle
    {
        private uint value;

        public uint Value
        {
            get { return this.value; }
            set { 
                this.value = value;
                base.ChangeValue(value);
            }
        }
        public override void ChangeValue(uint val)
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
