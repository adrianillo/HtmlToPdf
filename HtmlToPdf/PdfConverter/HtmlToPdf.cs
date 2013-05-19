﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Net;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
namespace HtmlToPdf
{    
    public class HtmlToPdf
    {
        private Document doc;
        private List<HtmlSection> listSection= new List<HtmlSection> ();
        private List<HtmlDoc> listHtmlDoc= new List<HtmlDoc> ();
        private Dictionary<String, HtmlClass> liststylesheets = new Dictionary<string, HtmlClass>();
        private List<string> listTempFiles = new List<string>();

        public Dictionary<String, HtmlClass> Liststylesheets
        {
            get { return liststylesheets; }
            set { liststylesheets = value; }
        }

        public List<HtmlDoc> ListParagraph
        {
            get { return listHtmlDoc; }
            set { listHtmlDoc = value; }
        }
        public List<HtmlSection> ListSection
        {
            get { return listSection; }
            set { listSection = value; }
        }

        public Document Doc
        {
            get { return doc; }
            set { doc = value; }
        }

        public HtmlToPdf()
        {
            doc = new Document();
        }
        ///<summary>
        ///Add section 
        ///</summary>   
        ///<param name="sec">Section name</param>
        ///<returns>HtmlSection</returns>
        public HtmlSection AddSection(string nameSection)
        {
            HtmlSection sec = new HtmlSection();
            sec.NameSection = nameSection;
            listSection.Add(sec);
            return sec;
        }
        ///<summary>
        ///Add html to section 
        ///</summary>
        ///<param name="html">Html to convert Pdf</param >
        ///<param name="listHtmlClass">List HtmlClass with different style sheets</param>
        ///<param name="css">CSS</param>
        ///<param name="sec">Section which is added the html</param>
        ///<returns>HtmlDoc</returns>
        public HtmlDoc AddHtml(string html, List<HtmlClass> listHtmlClass, string css, HtmlSection sec)
        {
            return Prepare(html, listHtmlClass, css, sec);
        }
        ///<summary>
        ///Add html to section 
        ///</summary>
        ///<param name="html">Html to convert Pdf</param >
        ///<param name="listHtmlClass">List HtmlClass with different style sheets</param> 
        ///<param name="sec">Section which is added the html</param>
        ///<returns>HtmlDoc</returns>
        public HtmlDoc AddHtml(string html,List<HtmlClass> listHtmlClass , HtmlSection sec)
        {
            return Prepare(html, listHtmlClass, "", sec);
        }
        ///<summary>
        ///Add html to section 
        ///</summary>
        ///<param name="html">Html to convert Pdf</param >
        ///<param name="sec">Section which is added the html</param>
        ///<returns>HtmlDoc</returns>
        public HtmlDoc AddHtml(string html, HtmlSection sec)
        {            
            return AddHtml(html,"", sec);
        }
        ///<summary>
        ///Add html to section 
        ///</summary>
        ///<param name="html">Html to convert Pdf</param > 
        ///<param name="css">CSS</param>
        ///<param name="sec">Section which is added the html</param>
        ///<returns>HtmlDoc</returns>
        public HtmlDoc AddHtml(string html,string css, HtmlSection sec)
        {
            return Prepare(html, null, css, sec);
        }
        private HtmlDoc Prepare(string html, List<HtmlClass> listHtmlClass, string css, HtmlSection sec)
        {     
            //Falta implementar que solo prepara una vez las hojas de Estilo, si una html lee una hoja de estilo
            //y luego otro html lee la misma, que solo lo lea una vez        
            
           try
            {
            HtmlDoc prgph = new HtmlDoc(sec, html, listHtmlClass,css,Liststylesheets);
            //Falta aqui recoger las listas de sheet  y si son src= httm... pasarsalar al nuevo paragraph 
            //para que no vuelva a leer el mimmo css y preparar la misma lista de htmlClass
            foreach (HtmlClass c in prgph.Listofstylesheets.Values)
            {
                if (!Liststylesheets.Keys.Contains(c.IdHtmlClass))
                    Liststylesheets.Add(c.IdHtmlClass, c);
 
            }

            listHtmlDoc.Add(prgph);
            return prgph;
            }
           catch (Exception ex)
           {
               Trazas.Traza.Tracea(html, Trazas.NivelesError.Traza);
               throw ex;
           }
          
        }

        public void Generate(string routepdf, string title, string subject, string author, string mdddl)
        {
            doc.Info.Title = title;
            doc.Info.Subject = subject;
            doc.Info.Author = author;
            Generate(routepdf, mdddl);
        }

        public void Generate(string routepdf,string mdddl)
        {
            try
            {
              
                new HtmlRender().Run(this, ref listTempFiles);             
                MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(doc, mdddl);               
                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);               
                renderer.Document = doc;
                renderer.RenderDocument();              
                // Save the document...
                renderer.PdfDocument.Save(routepdf);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //delete temporay files
               GC.Collect();
                GC.WaitForPendingFinalizers();
                foreach (string f in listTempFiles)
                    if (System.IO.File.Exists(f))
                        System.IO.File.Delete(f);
            }
            
        }
  
    }
}
