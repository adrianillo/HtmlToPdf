using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public enum TextDecoration { underline = 1, overline =2,lineThrough=3,none=4}
    public class ValueListStyleTextDecoration:ValueStyle
    {
        private TextDecoration value;

        public TextDecoration Value
        {
            get { return value; }
            set
            {
                this.value = value;
                base.ChangeValue(value);

            }
        }
        public override void ChangeValue(TextDecoration val)
        {
            Value = val;
            base.ChangeValue(value);
        }
        public override object GetValue()
        {
            return Value;
        }
    }
    public static class TextOfDecoration
    {
        public static TextDecoration GetTextDecoration(string v)
        {
            switch (v.ToLower().Trim())
            {
                case "underline":
                    return TextDecoration.underline;
                case "overline":
                    return TextDecoration.overline;
                case "line-through":
                    return TextDecoration.lineThrough;
                case "none":
                    return TextDecoration.none;               
                default:
                    return TextDecoration.underline;

            }
        }        
    }

}
