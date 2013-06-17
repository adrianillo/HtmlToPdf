using System;
using System.IO;
using System.Text;
using HtmlToPdf;
using System.Collections.Generic;
namespace Example1
{
    class PdfLauncher
    {        
        [STAThread]
        static void Main(string[] args)
        {
            StringWriter sb = new StringWriter();
             
            sb.WriteLine("<html>");
            sb.WriteLine("<head>");
            sb.WriteLine("<style type='text/css'>");
            sb.WriteLine("h1{color:blue;}");
            sb.WriteLine(".clas1 {font-family:'Times New Roman';color:red;font-size:20px}");
            sb.WriteLine(".clas2 {color:green;}");
            sb.WriteLine("#prf {color:yellow;font-size:12px}");
            sb.WriteLine(".punteado{ ");
            sb.WriteLine("border-style: solid; ");
            sb.WriteLine("border-width: 1px; ");
            sb.WriteLine("border-color: #660033; ");
            sb.WriteLine("background-color: #cc3366; ");
            sb.WriteLine("font-family: verdana, arial; ");
            sb.WriteLine("font-size: 18pt; ");
            sb.WriteLine("font-italic: true; ");
            sb.WriteLine("text-decoration:: underline; ");
            sb.WriteLine("color: #0B3861; ");            
            sb.WriteLine("}");
            sb.WriteLine("</style>");
            sb.WriteLine("</head>");
            sb.WriteLine("<body>");
            sb.WriteLine("<code>");
            sb.WriteLine("<%@ Page Language='C#' AutoEventWireup='true' CodeBehind='Default.aspx.cs' Inherits='WebApplication1._Default' %>");
            sb.WriteLine("</code>");
            sb.WriteLine("<p class='clas1'>Example 1</p>");
            sb.WriteLine("<table class='punteado'><tr><td> <table style='background-color:yellow;border-width: 1px;width:250px;height:200px;'>");
            sb.WriteLine("<tr><td class='class2'> Table in cell: <p>Cell one</p></td><td><img style='width:80px;height:80px;'");
            sb.WriteLine("src='http://db.tt/5v9AO20p'/> Table in cell: Cell two</td></tr></table>");
            sb.WriteLine("</td><td>1º <b>row</b> 2º col</td></tr><tr><td style='text-align:right'>2º <h2>row</h2>");
            sb.WriteLine("<span style='color:blue;'>1º</span> col</td><td>2º row 2 col</td></tr></table>");
            sb.WriteLine("<h1 id='search-box'>h1 title</h1>");
            sb.WriteLine("<h2> h2 title</h2>");
            sb.WriteLine("<br/>");
            sb.WriteLine("<h3> h3 title</h3>");
            sb.WriteLine("<h3> h3(2) title</h3>");
            sb.WriteLine("<h4> h4 title</h4>");
            sb.WriteLine("<h4> h4(2) title</h4>");
            sb.WriteLine("<h5> h5 title</h5>");
            sb.WriteLine("<h5> h5(2) title</h5>");
            sb.WriteLine("<h6> h6 title</h6>");
            sb.WriteLine("<h6> h6(2) title</h6>");
            sb.WriteLine("<h6> h6(3) title</h6>");
            sb.WriteLine("<h2> h2(2) title</h2>");
            sb.WriteLine("<h3> h3<div class='clase1'>title<div style='color:#4EE636;font-size:12px;'>in  div</div></div> </h3>");
            sb.WriteLine("<h4> h4 title</h4>");
            sb.WriteLine("<h5> h5 title</h5>");
            sb.WriteLine("<br/>");
            sb.WriteLine("<h6> h6 title<h1>h1 title 6</h1> </h6>");          
            sb.WriteLine("<p id='prf' class='punteado clas2'>p paragraph</p>");
            sb.WriteLine("<pre>pre paragraph</pre>");
            sb.WriteLine("<div style='color:blue;font-size:20px;' class=\"b\">div paragraph (class=b)</div>");  
            sb.WriteLine("<p align=\"left\">left aligned</p>");
            sb.WriteLine("<p align=\"right\">right aligned</p>");
            sb.WriteLine("<p style='color:blue;' align=\"center\">centered</p>");
            sb.WriteLine("<p style='text-align:right;width:40px;'>paragraph with <b>bold (b)</b> elements</p>");
            sb.WriteLine("<p class='clas1'>paragraph <b>with</b> emphasized (em) elements</p>");       
            sb.WriteLine("<p class='clas2'>paragraph with <tt>typewriter (tt)</tt> elements</p>");
            sb.WriteLine("<p id='prf' >paragraph with <code>code (code)</code> elements</p>");
            sb.WriteLine("<p class='alert-error'>paragraph with <span class=\"em\">span elements (class = em)</span></p>");
            sb.WriteLine("<p class='classone punteado'>paragraph <p> par 2</p> par 1-2 </p>");
            sb.WriteLine("<ul style='list-style-type: disc;'><li>Unordered 1</li><li>Unordered 2</li></ul>");
            sb.WriteLine("<ol class='classone'><li>Ordered 1</li><li>Ordered 2</li></ol>");            
            sb.WriteLine("<ol>");
            sb.WriteLine("<li>listado <sup>2</sup>con<sub>2</sub> sub</li>");
            sb.WriteLine("<li>");
            sb.WriteLine("<ul><li>sub-item 1</li><li>sub item 2</li></ul>");
            sb.WriteLine("</li>");
            sb.WriteLine("<li>ordered item</li></ol>");
            sb.WriteLine("<div><img style='width:80px;height:80px;' class='punteado   classone' src='http://icons.iconarchive.com/icons/martin-berube/animal/256/duck-icon.png'/></div>");
            sb.WriteLine("</body>");
            sb.WriteLine("</html>");

            StringWriter stl = new StringWriter();
            stl.WriteLine(".aa,.classone{");
            stl.WriteLine("color:green;");
            stl.WriteLine("font-size:18px;");
            stl.WriteLine("margin-left:80px;");
            stl.WriteLine("margin-top:40px;");
            stl.WriteLine("list-style-type: lower-latin;");
            stl.WriteLine("}");

            stl.WriteLine(".class2{");
            stl.WriteLine("color:green;");
            stl.WriteLine("font-size:12px;");           
            stl.WriteLine("margin:40px 30px    20px  10px;");
            stl.WriteLine("list-style-type: lower-latin;");
            stl.WriteLine("}");
            Console.WriteLine(sb.ToString());


            HtmlToPdf.HtmlToPdf docHtml = new HtmlToPdf.HtmlToPdf();
            try
            {
                HtmlSection sec1 = docHtml.AddSection("Section 1");      
                List<HtmlClass> ListCss = new List<HtmlClass>();
                HtmlClass c1 = new CssParser().Parser(stl.ToString());
                c1.IdHtmlClass = "sss";
                ListCss.Add(c1);
                HtmlDoc html = docHtml.AddHtml(sb.ToString(), ListCss, sec1);

                HtmlSection sec2 = docHtml.AddSection("Section 2");
                docHtml.AddHtml(sb.ToString(), sec2);

                string htmldoc = "<html><head><body><p style='color:blue;font-size:20px;' >";
                htmldoc += "Hola Mundo</p></body></head></html>";

                htmldoc = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title /></head><body><div style='clear: both'><p style='font: 13px/20.79px sans-serif, Arial, Verdana, Trebuchet MS; color: rgb(51, 51, 51); text-transform: none; text-indent: 0px; letter-spacing: normal; word-spacing: 0px; white-space: normal; font-size-adjust: none; font-stretch: normal; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;'><span style='color: rgb(0, 0, 0);'><span style='font-size: 18px;'><span style='font-family: verdana, geneva, sans-serif;'>Requirimientos</span></span></span></p>";

                htmldoc += "<p style='font: 13px/20.79px sans-serif, Arial, Verdana, Trebuchet MS; color: rgb(51, 51, 51); text-transform: none; text-indent: 0px; letter-spacing: normal; word-spacing: 0px; white-space: normal; font-size-adjust: none; font-stretch: normal; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;'> </p>";

                htmldoc += "<ul style='font: 14px/22px Open Sans, Arial Helvetica, sans-serif; margin: 0px; padding: 0px 0px 0px 1.5em; border: 0px currentColor; color: rgb(70, 70, 70); text-transform: none; text-indent: 0px; letter-spacing: normal; word-spacing: 0px; vertical-align: baseline; white-space: normal; font-size-adjust: none; font-stretch: normal; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;'>";
                htmldoc += "<li style='margin: 0px 0px 0.5em; padding: 0px; border: 0px currentColor; line-height: inherit; font-family: inherit; font-size: inherit; font-style: inherit; font-variant: inherit; vertical-align: baseline;'><span style='color: rgb(0, 0, 0);'><span style='font-size: 14px;'><span style='font-family: verdana, geneva, sans-serif;'>jQuery 1.4.x o superior</span></span></span></li>";
                htmldoc += "	<li style='margin: 0px 0px 0.5em; padding: 0px; border: 0px currentColor; line-height: inherit; font-family: inherit; font-size: inherit; font-style: inherit; font-variant: inherit; vertical-align: baseline;'><span style='color: rgb(0, 0, 0);'><span style='font-size: 14px;'><span style='font-family: verdana, geneva, sans-serif;'>Un servidor capaz de analizar PHP, ASP.Net, JSP, o un lenguaje similar del lado del servidor</span></span></span></li>";
                htmldoc += "</ul>";
                htmldoc += "</div></body></html>";

                docHtml.AddHtml(sb.ToString(), sec2);

                docHtml.Generate("e:\\test.pdf");
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
