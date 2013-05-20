using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
namespace HtmlToPdf
{
    public class RenderStyleList : RenderStyle
    {
        public RenderStyleList(HtmlItem it, ref MigraDoc.DocumentObjectModel.ListInfo lst)
        {
            Lst = lst;
            It = it;
        }

        public override   void  Render()
        {
            if (It.StyleItem != null)
            {
                //type BulletList 
                if (It.StyleItem.ListStyleType.hasValue())                
                    Lst.ListType = ListOfStyleType.GetListStyleType(It.StyleItem.ListStyleType.Value);
                
                //margin left
                if (It.StyleItem.MarginLeft.hasValue())
                    Lst.NumberPosition =(Unit) It.StyleItem.MarginLeft.Value;

          
                
            }
          
        }
    }
}
