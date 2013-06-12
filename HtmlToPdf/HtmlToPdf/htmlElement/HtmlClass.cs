/**
 * HtmlToPdf
 * Copyright (c)2013 adrianillo
 *
 * adrianillo
 * elcorreillodeadrianillo@gmail.com
 * twitter:@adrianillo
 *
 * Licensed under the MIT license.
 * 
 * Permission is hereby granted, free of charge, to any
 * person obtaining a copy of this software and associated
 * documentation files (the "Software"), to deal in the
 * Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the
 * Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions: 
 *
 * The above copyright notice and this permission notice
 * shall be included in all copies or substantial portions of
 * the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 */
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
