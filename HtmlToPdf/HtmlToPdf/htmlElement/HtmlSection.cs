using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
namespace HtmlToPdf
{
    public class HtmlSection : MigraDoc.DocumentObjectModel.Section
    {
        private string nameSection;

        public string NameSection
        {
            get { return nameSection; }
            set { nameSection = value; }
        }

    }
}
