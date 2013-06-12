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
 * Based on: http://www.codeproject.com/Articles/335850/CSSParser
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace HtmlToPdf
{
    public class CssParser
    {
        public const String CSSGroups = @"(?<selector>(?:(?:[^,{]+),?)*?)\{(?:(?<name>[^}:]+):?(?<value>[^};]+);?)*?\}";

        public const String CSSComments = @"(?<!"")\/\*.+?\*\/(?!"")";

        private Regex rStyles = new Regex(CSSGroups, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        ///<summary>
        ///Converts a style sheet to HtmlClass
        ///</summary>
        ///<param name="sec">Style sheet</param>
        ///<returns>HtmlClass</returns>
        public HtmlClass Parser(String CascadingStyleSheet)
        {
            HtmlClass result=null;

            if (!String.IsNullOrEmpty(CascadingStyleSheet))
            {
                 result = new HtmlClass();
                //Remove comments
                MatchCollection MatchList = rStyles.Matches(Regex.Replace(CascadingStyleSheet, CSSComments, String.Empty));
                foreach (Match item in MatchList)
                {
                    if (item != null && item.Groups != null && item.Groups["selector"] != null &&
                        item.Groups["selector"].Captures != null && item.Groups["selector"].Captures[0] != null
                        && !String.IsNullOrEmpty(item.Groups["selector"].Value))
                    {
                        String classname = item.Groups["selector"].Captures[0].Value.Trim();
                        HtmlStyle style = new HtmlStyle();

                        if (classname.Trim().Length > 0)
                        {
                            foreach (string cn in classname.Split(','))
                            {
                                string nameclass = cn;
                                nameclass = nameclass.Replace("\n", "");
                                nameclass = nameclass.Replace("\r", "");
                                classType typeOfClass = classType.styleClass;
                                if (nameclass.StartsWith("."))
                                {
                                    nameclass = nameclass.Substring(1, nameclass.Length - 1);
                                    typeOfClass = classType.styleClass;
                                }
                                else if (nameclass.StartsWith("#"))
                                {
                                    nameclass = nameclass.Substring(1, nameclass.Length - 1);
                                    typeOfClass = classType.styleIdElement;
                                }
                                else
                                    typeOfClass = classType.styleTypeElement;

                                for (int i = 0; i < item.Groups["name"].Captures.Count; i++)
                                {
                                    String styleproperty = item.Groups["name"].Captures[i].Value;
                                    String valueproperty = item.Groups["value"].Captures[i].Value;
                                    style = new SetStyle().AddPropertyValue(styleproperty, valueproperty, style);


                                }
                                result.AddClass(nameclass, style, typeOfClass);
                            }
                        }
                    }
                }
            }
            //up here are implemented styles in style tags

            //from here i implement elements what not are implemented in style tag
            //todo ...
            return result;
        }

    }

}

