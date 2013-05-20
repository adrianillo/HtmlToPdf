using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace HtmlToPdf
{
    public class PrepareStyle
    {
         private HtmlStyle styleResult = new HtmlStyle();
        private  Dictionary<String, HtmlClass> liststylesheets;
        public PrepareStyle(Dictionary<String, HtmlClass> listofstylesheets)
        {
            liststylesheets = listofstylesheets;
        }
        public PrepareStyle()
        { }
        public HtmlStyle Prepare(XmlAttributeCollection attributes,string nodetype)
        {
            List<string> elementscss = new List<string>();
            foreach (var sheet in liststylesheets)
            {
              elementscss.AddRange(sheet.Value.GetTypesElementClass().ToList());
            }

            foreach (XmlAttribute at in attributes)
            {
                if (at.Name.ToLower().Trim() == "class") //Class in css or style
                {
                    foreach (var s in liststylesheets)
                    {
                        if (s.Value is HtmlClass) 
                        {
                            string[] classnames = at.Value.Split(' ');
                            foreach (string cms in classnames)
                            {
                                if (cms.Trim() != string.Empty)
                                {
                                    HtmlStyle stclass = s.Value.GetClass(cms, classType.styleClass);
                                    if (stclass != null)
                                    {
                                        styleResult.AddStyle(stclass);
                                        break;
                                    }
                                }
                            }
                        }
                    }                   
                }
                
                if (at.Name.ToLower().Trim() == "id") // # in class o style
                {
                    foreach (var idc in liststylesheets)
                    {
                        HtmlStyle stid = idc.Value.GetClass(at.Value, classType.styleIdElement );
                        if (stid != null)
                        {
                            styleResult.AddStyle(stid); 
                            break;
                        }
                    }
                }
                
              if(elementscss.Contains(nodetype)) // type element in class o style
              {
                  foreach (var idc in liststylesheets)
                  {
                      HtmlStyle stid = idc.Value.GetClass(nodetype,classType.styleTypeElement);
                      if (stid != null)
                      {
                          styleResult.AddStyle(stid);
                          break;
                      }
                  }
              }

                if (at.Name.ToLower().Trim() == "style")
                     Prepare(at.Value);
                if (at.Name.ToLower().Trim() == "align")                
                    styleResult.TextAlign.ChangeValue(  Aling.GetTextAling(at.Value));
                
                
            }
             return styleResult;
        }

        public HtmlStyle Prepare(string  style)
        {
           
            string[] st = style.Split(';');
            foreach (string s in st)
            {
                addStyle(s);
            }
            return styleResult;            
        }
        private bool  addStyle(string style)
        {
           string[] st= style.Split(':');
            if(st.Count()==2)
                return addStyle(st[0],st[1]);
            return false;
        }
        public HtmlStyle addStyleValue(string key, string value, HtmlStyle style )
        {
            this.styleResult = style;
            addStyle(key, value);
             return styleResult;
        }

        private bool addStyle(string key, string value)
        {
            string k = key.Trim().ToLower();
            switch (k)
            {
                case "font-size":
                    addSizeText(value);
                    break;
                case "color":
                    addColorText(value);
                    break;
                case "width":
                    setwidth(value);
                    break;
                case "height":
                    sethigh(value);
                    break;
                case "background-color":
                    setbackgroundcolor(value);
                    break;
                case "font-weight":
                    setfontweight(value);
                    break;
                case "float":
                   styleResult.Align.ChangeValue( Aling.GetAling(value));
                    break;
                case "text-align":
                    styleResult.TextAlign.ChangeValue( Aling.GetTextAling(value));
                    break;
                case "font-family":
                    
                    if(value.StartsWith("'"))
                        value=value.Substring(1,value.Length-1);
                    if(value.EndsWith("'"))
                        value=value.Substring(0,value.Length-1);
                    
                    styleResult.FontFamily.ChangeValue( value);
                    break;
                case "border-width":
                    decimal? val= getValueDecimal(value);
                    if (val != null)
                    {
                        styleResult.BorderWidth.NodeMeasure = modeMeasure.px;
                        styleResult.BorderWidth.Measure = val;
                    }
                    break;
                case "border-style":
                    styleResult.BorderStyle.ChangeValue(StyleOfBorder.GetBorderStyle(value));
                    break;
                case "border-color":
                    System.Drawing.Color c = getColor(value);
                    if (c != System.Drawing.Color.Empty)
                        styleResult.BorderColor.ChangeValue(c);
                    break;
                case "list-style-type":
                    styleResult.ListStyleType.ChangeValue(ListOfStyleType.GetListStyleType(value));
                    break;
                case "margin-left":
                    decimal? valdec = getValueDecimal(value);
                    if (valdec != null)
                        styleResult.MarginLeft.ChangeValue(valdec.Value);
                    break;              
                case "margin-right":
                    decimal? valdecr = getValueDecimal(value);
                    if (valdecr != null)
                        styleResult.MarginRight.ChangeValue(valdecr.Value);
                    break;
                  case "margin-top":
                    decimal? valdect = getValueDecimal(value);
                    if (valdect != null)
                        styleResult.MarginTop.ChangeValue(valdect.Value);
                    break;
                  case "margin-bottom":
                    decimal? valdecb = getValueDecimal(value);
                    if (valdecb != null)
                        styleResult.MarginBottom.ChangeValue(valdecb.Value);
                    break;
                  case "margin":
                    setmargin(value);
                    break;
                  case "font-italic":
                    styleResult.FontItalic.ChangeValue(value.Trim().ToLower()=="true"?true:false);
                    break;
                case "text-decoration":
                    styleResult.TextDecorarion.ChangeValue(TextOfDecoration.GetTextDecoration(value.Trim().ToLower()));
                    break;
                default:
                    return false;
            }
            return true;
        }

        private void setmargin(string value)
        {
            decimal? valTop = null;
            decimal? valRight = null;
            decimal? valBotton = null;
            decimal? valLeft = null;

            string[] values = value.Split(' '.ToString().ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (values.Count() > 0)
                if (values[0] != null)
                    valTop = getValueDecimal(values[0]);
            if (values.Count() > 1)
                if (values[1] != null)
                    valRight = getValueDecimal(values[1]);
            if (values.Count() > 2)
                if (values[2] != null)
                    valBotton = getValueDecimal(values[2]);
            if (values.Count() > 3)
                if (values[3] != null)
                    valLeft = getValueDecimal(values[3]);

            if (valTop != null)
                styleResult.MarginTop.ChangeValue(valTop.Value);

            if (valRight != null)
                styleResult.MarginRight.ChangeValue(valRight.Value);

            if (valBotton != null)
                styleResult.MarginBottom.ChangeValue(valBotton.Value);

            if (valLeft != null)
                styleResult.MarginLeft.ChangeValue(valLeft.Value);

        }
        private decimal? getValueDecimal(string val)
        {
            string[] parval = val.Split(new string[] { "px" }, StringSplitOptions.None);
            if (parval.Length > 1)// px width
           {
               decimal valdec;
               if (decimal.TryParse(parval[0].Trim(), System.Globalization.NumberStyles.AllowDecimalPoint, new System.Globalization.CultureInfo("en-US"), out valdec))
                   return valdec;
           }
            return null;
        }

        private bool setfontweight(string value)
        {
            switch (value.ToLower().Trim())
            {
                case "bold":
                    styleResult.Bold.ChangeValue( true);
                    break;
                case "bolder":
                    styleResult.Bold.ChangeValue( true);
                    break;
                case "normal":
                    styleResult.Bold.ChangeValue( false);
                    break;
                case "lighter":
                    styleResult.Bold.ChangeValue( false);
                    break;   
                default:
                    try
                    {
                        if (int.Parse(value) > 599)
                            styleResult.Bold.ChangeValue( true);
                        else
                            styleResult.Bold.ChangeValue( false);
                    }
                    catch { } 
                    break;
            }
            return true;
        }

        private System.Drawing.Color getColor(string color)
        { 
            try
            {
                return System.Drawing.ColorTranslator.FromHtml(color);
            }
            catch { }
            return System.Drawing.Color.Empty;
        }

        private bool setbackgroundcolor(string color)
        {
            try
            {
                System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(color);
                styleResult.BackGroundColor.ChangeValue( c);
                return true;
            }
            catch { }

            return false;
      
        }

        private bool sethigh(string high)
        {      

            string[] parhigh = high.Split('%');
            string highhnumber = "-1";
            decimal highvalue = -1;
            if (parhigh.Length > 1)// percentage width  
            {

                highhnumber = parhigh[0];
                if (decimal.TryParse(highhnumber, out highvalue))
                {
                    styleResult.High = new StyleMeasureElement();
                    styleResult.High.NodeMeasure = modeMeasure.percentage;
                    styleResult.High.Measure = highvalue;
                }

            }
            else
            {
                parhigh = high.Split(new string[] { "px" }, StringSplitOptions.None);
                if (parhigh.Length > 1)// px width
                {
                    highhnumber = parhigh[0];
                    if (decimal.TryParse(highhnumber, out highvalue))
                    {
                        styleResult.High = new StyleMeasureElement();
                        styleResult.High.NodeMeasure = modeMeasure.px;
                        styleResult.High.Measure = highvalue;
                    }
                }
                else
                {
                    string[] unit = { ".em" };
                    parhigh = high.Split(unit, StringSplitOptions.None);
                    if (parhigh.Length > 1)//  em width 
                    {
                        highhnumber = parhigh[0];
                        if (decimal.TryParse(highhnumber, out highvalue))
                        {
                            highvalue = highvalue * 16; //pass em to px, depent of size body
                            styleResult.High = new StyleMeasureElement();
                            styleResult.High.NodeMeasure = modeMeasure.px;
                            styleResult.High.Measure = highvalue;
                        }
                    }
                }
            }


            if (highvalue > -1)
            {
                styleResult.High.Measure = highvalue;
                return true;
            }
            return false;


        }

        private bool setwidth(string width)
        {           
          string[] parwith =width.Split('%');
          string widthnumber = "-1";
            decimal widthvalue=-1;          
          if (parwith.Length > 1)// width en porcentage
          {             
              widthnumber = parwith[0];
              if (decimal.TryParse(widthnumber, out widthvalue))
              {
                  styleResult.Width = new StyleMeasureElement();
                  styleResult.Width.NodeMeasure = modeMeasure.percentage;
                  styleResult.Width.Measure = widthvalue;
              }
                  
          }
          else
          {              
              parwith = width.Split(new string[]{ "px"},StringSplitOptions.None);
              if (parwith.Length > 1)// width en px
              {                  
                  widthnumber = parwith[0];
                  if (decimal.TryParse(widthnumber, out widthvalue))
                  {
                      styleResult.Width = new StyleMeasureElement();
                      styleResult.Width.NodeMeasure = modeMeasure.px;
                      styleResult.Width.Measure = widthvalue;
                  }
              }
              else
              {
                  string[] unit = { ".em" };
                  parwith = width.Split(unit, StringSplitOptions.None);
                  if (parwith.Length > 1)// width en em
                  {
                      widthnumber = parwith[0];
                      if (decimal.TryParse(widthnumber, out widthvalue))
                      {
                          widthvalue = widthvalue * 16; //pass em to px, depent of size body
                          styleResult.Width = new StyleMeasureElement();
                          styleResult.Width.NodeMeasure = modeMeasure.px;
                          styleResult.Width.Measure = widthvalue;
                      }
                  }
              }
          }
            
          
            if (widthvalue>-1)
            {
                styleResult.Width.Measure = widthvalue;
                return true;
            }
            return false;
        }

        private bool addColorText(string color)
        {
            try
            {
                System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(color);
                styleResult.TextColor.ChangeValue( c);
                return true;
            }
            catch { }
          
            return false;
        }

        private bool addSizeText(string size)
        {
            uint valueSize = 0;
            if(size.ToLower().Contains("px"))// px
            {
                size=size.ToLower().Replace("px","");                
                if (uint.TryParse(size, out  valueSize))
                {  
                    styleResult.TextSize.Value =  valueSize;
                    return true;
                }
            }
            if (size.ToLower().Contains(".em"))// .em
            {
                size = size.ToLower().Replace(".em", "");
                if (uint.TryParse(size, out valueSize))
                {
                    valueSize= valueSize * 16; //pass to px
                    styleResult.TextSize.ChangeValue(  valueSize);
                    return true;
                }
            }

            return false;
        }
    }
}
