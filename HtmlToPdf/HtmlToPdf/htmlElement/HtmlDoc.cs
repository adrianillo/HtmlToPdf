using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using System.Xml;
namespace HtmlToPdf
{
    public class HtmlDoc: Paragraph, IHtmlItem
    {
        private Dictionary<String, HtmlClass> listAlreadyStyleSheets;

        private Dictionary<String, HtmlClass> listofstylesheets = new Dictionary<string, HtmlClass>();

        public Dictionary<String, HtmlClass> Listofstylesheets
        {
            get { return listofstylesheets; }
            set { listofstylesheets = value; }
        }
        object IHtmlItem.IHtmlElement
        {
            get { return this; }
        }

        private HtmlStyle styleItem;

        public HtmlStyle StyleItem
        {
            get { return styleItem; }
            set { styleItem = value; }
        }

        private List<IHtmlItem> listItem = new List<IHtmlItem>();

        public List<IHtmlItem> ListItem
        {
            get { return listItem; }
            set { listItem = value; }
        }

        private string html;

        public string Html
        {
            get { return html; }
            set { html = value; }
        }
 

        private HtmlSection ownerHtmlSection;

        public HtmlSection OwnerHtmlSection
        {
            get { return ownerHtmlSection; }
            set { ownerHtmlSection = value; }
        }

        public HtmlDoc(HtmlSection sec, string html, List<HtmlClass> Listcss, string css,  Dictionary<String, HtmlClass>  ListalreadyCss)
        {
            listAlreadyStyleSheets = ListalreadyCss;
            if(Listcss!=null)
                foreach (HtmlClass c in Listcss)
                {
                    this.Listofstylesheets.Add("", c);
                }
            Run(sec, html, css);
        }
        public HtmlDoc(HtmlSection sec, string html, List<HtmlClass> Listcss)
        {
            if (Listcss != null)
                foreach (HtmlClass c in Listcss)
                {
                    this.Listofstylesheets.Add("", c);
                }            
            Run(sec, html, "");
        }

        public HtmlDoc(HtmlSection sec, string html,string css)
        {
            Run(sec, html, css);
        }
        public void Run(HtmlSection sec, string html, string css)
        {
            html = html.Replace("<%", "&lt;&#37;").Replace("%>", "&gt;&#37;");
            OwnerHtmlSection = sec;
            Html = html;
            XmlDocument doc = new XmlDocument();
            AddSheetStyle(css);
            doc.LoadXml(html);
            getnodes(doc.DocumentElement.ChildNodes, null, null);
        }

        private void getnodes(XmlNodeList nodelist,XmlNode parent,HtmlItem nodeparent)
        {
            foreach (XmlNode node in nodelist)
            {
                string valor = node.InnerText;
                string nombre = node.Name;
                XmlAttributeCollection attributes = node.Attributes;
                HtmlItem nodeprepared = preparenode(node.Name, node.InnerText, node.NodeType, attributes, nodeparent, node.ParentNode);
                if (node.HasChildNodes)
                    getnodes(node.ChildNodes, node,  nodeprepared);
            }
        }
        private HtmlItem preparenode(string node, string text, XmlNodeType type, XmlAttributeCollection attributes, HtmlItem nodeparent,XmlNode parent)
        {
            // I only make htmlText if type = Text, the others one will be text containers
            if (type == XmlNodeType.Text)
            {
                if (parent.Name.ToLower().Trim() == "style") // style tag no render
                    return null;

                HtmlText ht = new HtmlText();
                ht.Text = text;
                if (nodeparent != null)
                    nodeparent.ListItem.Add(ht);
                else
                    ListItem.Add(ht);
                return ht;
            }
         

            switch (node)
            {
                case "td":
                    Htmltd httd = new Htmltd();
                    if (attributes.Count > 0)
                        httd.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);//apply styles to elemnet
                    if (nodeparent != null)
                    {
                        httd.IndexCell=nodeparent.ListItem.Count();
                        Htmltr rowparnet = nodeparent as Htmltr;
                        if (rowparnet != null)
                        {
                            rowparnet.Cellsinrow++;
                            HtmlTable tableparnet = rowparnet.GetTableParent();
                            if (tableparnet != null)
                                if (tableparnet.Cells < rowparnet.Cellsinrow)
                                    tableparnet.Cells = rowparnet.Cellsinrow;
                        }
                        nodeparent.ListItem.Add(httd);

                    }                  
                    return httd;
                case "tr":
                    Htmltr httr = new Htmltr();
                    if (attributes.Count > 0)
                        httr.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);//apply styles to elemnet
                    if (nodeparent != null)
                    {         
                         HtmlTable tableparnet = nodeparent as HtmlTable;
                         if (tableparnet != null)
                             httr.SetTableParent(tableparnet);

                        nodeparent.ListItem.Add(httr);
                    }
                    
                    return httr;
                case "table":
                    HtmlTable httbl = new HtmlTable();
                    if (attributes.Count > 0)
                        httbl.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);//apply styles to elemnet
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(httbl);
                    else
                        ListItem.Add(httbl);
                    return httbl;
                case "div":
                    HtmlDiv htdiv = new HtmlDiv();
                    if (attributes.Count > 0)
                        htdiv.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);//apply styles to elemnet
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(htdiv);
                    else
                        ListItem.Add(htdiv);
                    return htdiv;
                case "p":
                    HtmlDiv ht = new HtmlDiv();
                    if (attributes.Count > 0)
                        ht.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ht);
                    else
                        ListItem.Add(ht);
                    return ht;
                case "br":
                    HtmlContent br = new HtmlContent();                    
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(br);
                    else
                        ListItem.Add(br);
                    return br;
                case "b":
                    HtmlSpan htb = new HtmlSpan();                             
                    htb.Bold.ChangeValue( true);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(htb);
                    else
                        ListItem.Add(htb);
                    return htb;
                case "sub":
                    HtmlSpan hsub = new HtmlSpan();
                    hsub.Sub.ChangeValue(true);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(hsub);
                    else
                        ListItem.Add(hsub);
                    return hsub;
                case "sup":
                    HtmlSpan hsup = new HtmlSpan();
                    hsup.Super.ChangeValue(true);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(hsup);
                    else
                        ListItem.Add(hsup);
                    return hsup;
                case "span":
                    HtmlSpan hspan = new HtmlSpan();
                    if (attributes.Count > 0)
                        hspan.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(hspan);
                    else
                        ListItem.Add(hspan);
                    return hspan;
                case "h1":
                    HtmlSpan ht1 = new HtmlSpan();                 
                    ht1.Size.ChangeValue( 22);
                    ht1.Bold.ChangeValue( true);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ht1);
                    else
                        ListItem.Add(ht1);
                  
                    return ht1;
                case "h2":
                    HtmlSpan ht2 = new HtmlSpan();               
                    ht2.Size.ChangeValue( 18);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ht2);
                    else
                        ListItem.Add(ht2);
                    return ht2;
                case "h3":
                    HtmlSpan ht3 = new HtmlSpan();             
                    ht3.Size.ChangeValue( 16);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ht3);
                    else
                        ListItem.Add(ht3);
                    return ht3;
                case "h4":
                    HtmlSpan ht4 = new HtmlSpan();                   
                    ht4.Size.ChangeValue( 14);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ht4);
                    else
                        ListItem.Add(ht4);
                    return ht4;
                case "h5":
                    HtmlSpan ht5 = new HtmlSpan();                 
                    ht5.Size.ChangeValue( 12);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ht5);
                    else
                        ListItem.Add(ht5);
                    return ht5;
                case "h6":
                    HtmlSpan ht6 = new HtmlSpan();                  
                    ht6.Size.ChangeValue( 10);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ht6);
                    else
                        ListItem.Add(ht6);
                    return ht6;
                case "img":
                    HtmlImg im = new HtmlImg(attributes);
                    if (attributes.Count > 0)
                        im.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(im);
                    else
                        ListItem.Add(im);
                    break;
                case "ol":
                    HtmlList ol = new HtmlList();
                    if (attributes.Count > 0)
                        ol.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);
                    ol.HtmlListType = typeHtmlList.ol;
                    if (nodeparent is HtmlLi)
                    {
                        HtmlLi parentLi = nodeparent as HtmlLi;
                        if (parentLi != null)
                            if (parentLi.ParentList != null)
                                ol.Level = parentLi.ParentList.Level + 1;
                    }
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ol);
                    else
                        ListItem.Add(ol);
                    return ol;
                case "ul":
                    HtmlList ul = new HtmlList();
                    if (attributes.Count > 0)
                        ul.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);
                    ul.HtmlListType = typeHtmlList.ul;
                    if (nodeparent is HtmlLi)
                    {
                        HtmlLi parentLi = nodeparent as HtmlLi;
                        if (parentLi != null)
                            if (parentLi.ParentList != null)
                                ul.Level = parentLi.ParentList.Level + 1;
                    }
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(ul);
                    else
                        ListItem.Add(ul);
                    return ul;

                case "li":
                    HtmlLi li = new HtmlLi();
                    //if (attributes.Count > 0)
                    //  im.StyleItem = new PrepareStyle(listofstylesheets).Prepare(attributes, node);                   
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(li);
                    HtmlList parentli = nodeparent as HtmlList;
                    if (parentli != null)
                    {
                        li.ParentList = parentli;
                        parentli.ListLi.Add(li);
                    }
                    return li;
                case "link":
                    if (attributes.Count > 0)
                    {
                        PrepareHtmlClass newClass = new PrepareHtmlClass(attributes, ref listofstylesheets, listAlreadyStyleSheets);
                    }
                    break;
                case "style":
                    if (attributes.Count > 0)
                    {
                        PrepareHtmlClass newClass = new PrepareHtmlClass(text, ref listofstylesheets);
                    }
                    break;
                case "pre":
                    HtmlCode htcode = new HtmlCode();                   
                    if (nodeparent != null)
                        nodeparent.ListItem.Add(htcode);
                    else
                        ListItem.Add(htcode);
                    return htcode;                   
                default:                   
                    return null;
            }
            return null;
        }

        private void AddSheetStyle(string s)
        {
            if (s.Trim() != string.Empty)
                 new PrepareHtmlClass(s, ref listofstylesheets);          
        }

     
    }
}
