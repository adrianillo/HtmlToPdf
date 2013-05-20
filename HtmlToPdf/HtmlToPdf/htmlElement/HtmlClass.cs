using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class HtmlClass
    {
        private string idHtmlClass;
        public string IdHtmlClass
        {
            get { return idHtmlClass; }
            set { idHtmlClass = value; }
        }

        public HtmlClass()
        {
            
        }
        private List<ClassCss> listClass = new List<ClassCss>();

        public List<ClassCss> ListClass
        {
            get { return listClass; }
            set { listClass = value; }
        }

        public IEnumerable <string> GetTypesElementClass()
        {
            var tyel = from te in ListClass
                       where te.TypeOfClass == classType.styleTypeElement
                       select te.Name;

            return tyel;
        }

        public HtmlStyle GetClass(string classname,classType typeclass)
        {
            var s = from st in listClass
                    where st.Name == classname && st.TypeOfClass == typeclass
                    select st.CssClass;
            if (s != null)
                if (s.Count() > 0)
                    return s.First();
            return null;
        }

        ///<summary>
        ///returns:
        /// 1 if the class already exists and has been replaced by the 2º parameter
        /// 2 if the class was successfully added
        /// 3 no class has been added
        ///</summary>
        public int SetClass(string classname,HtmlStyle style )
        {
            var s = from st in listClass
                    where st.Name == classname
                    select st;

            if (s != null)
                if (s.Count() > 0)
                {
                    s.First().CssClass = style;
                    return 1;
                }

            if (AddClass(classname, style))
                return 2;
            return 0;
        }
        public bool AddClass(string classname, HtmlStyle style, classType typeOfClass)
        {
            var s = from st in listClass
                    where st.Name == classname
                    select st;

            if (s != null)
                if (s.Count() > 0)
                    return false;

            ListClass.Add(new ClassCss() { CssClass = style, Name = classname, TypeOfClass = typeOfClass });
            return true;
        }

        public bool AddClass(string classname,HtmlStyle style)
        {
            var s = from st in listClass
                    where st.Name == classname
                    select st;

            if (s != null)
                if (s.Count() > 0)                                   
                    return false;

            ListClass.Add(new ClassCss() { CssClass = style, Name = classname });
            return true;
        }

        public bool RemoveClass(string classname, HtmlStyle style)
        {
            var s = from st in listClass
                    where st.Name == classname
                    select st;
            if (s != null)
                if (s.Count() > 0)                
                    return listClass.Remove(s.First());           
            return false;
        }

    }
    public enum classType { styleClass = 1, styleTypeElement=2, styleIdElement=3 }
    public class ClassCss
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private classType typeOfClass;

        public classType TypeOfClass
        {
            get { return typeOfClass; }
            set { typeOfClass = value; }
        }

        private HtmlStyle cssClass = new HtmlStyle();

        public HtmlStyle CssClass
        {
            get { return cssClass; }
            set { cssClass = value; }
        }  
    }
}
