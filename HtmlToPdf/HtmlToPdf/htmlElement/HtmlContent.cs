using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class HtmlContent:HtmlItem ,Iheight
    {     
        
         private ValueStyleUint size=new ValueStyleUint ();

         public ValueStyleUint Size
        {
            get { return size; }
            set { size = value; }
        }

         private ValueStyleBool bold= new ValueStyleBool ();

         public ValueStyleBool Bold
        {
            get { return bold; }
            set { bold = value; }
        }
        private bool italic;

        public bool Italic
        {
            get { return italic; }
            set { italic = value; }
        }

        public HtmlContent()
        { }
    }
}
