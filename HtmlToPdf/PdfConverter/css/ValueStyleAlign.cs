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
