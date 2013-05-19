using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class ValueStyle:IValueStyle
    {
        private bool withvalue=false;  

        public bool hasValue()
        {
        return withvalue;
        }

        public virtual void ChangeValue()
        {
            withvalue = true;
        }
        public virtual void ChangeValue(modeMeasure mode, decimal val)
        {
            withvalue = true; 
        }
        public virtual void ChangeValue(uint value)
        {
            withvalue = true;
        }
        public virtual void ChangeValue(bool value)
        {
            withvalue = true;
        }
        public virtual void ChangeValue(System.Drawing.Color value)
        {
            withvalue = true;
        }
        public virtual void ChangeValue(StyleFloat value)
        {
            withvalue = true;
        }

        public virtual void ChangeValue(StyleTextAlign value)
        {
            withvalue = true;
        }
        public virtual void ChangeValue(BorderStyleValue value)
        {
            withvalue = true;
        }

        public virtual void ChangeValue(string value)
        {
            withvalue = true;
        }

        public virtual void ChangeValue(ListStyleType val)
        {
            withvalue = true;
        }
        public virtual void ChangeValue(decimal val)
        {
            withvalue = true;
        }
        public virtual void ChangeValue(TextDecoration val)
        {
            withvalue = true;
        }

        public virtual object GetValue()
        {
            return null;
        }
     
    }
}
