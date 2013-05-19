using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class HtmlSpan : HtmlItem
    {
        public HtmlSpan()
        { }

         private ValueStyleUint size=new ValueStyleUint ();

         public ValueStyleUint Size
        {
            get { return size; }
            set { size = value; }
        }

         private ValueStyleBool bold = new ValueStyleBool ();

         public ValueStyleBool Bold
        {
            get { return bold; }
            set { bold = value; }
        }
        private bool italic=false;

        public bool Italic
        {
            get { return italic; }
            set { italic = value; }
        }

        private ValueStyleBool sub = new ValueStyleBool();

        public ValueStyleBool Sub
        {
            get { return sub; }
            set { sub = value; }
        }

        private ValueStyleBool super = new ValueStyleBool();

        public ValueStyleBool Super
        {
            get { return super; }
            set { super = value; }
        }

    }
}
