using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HtmlToPdf
{
    public class RenderHtmlImg : HtmlRender
    {        
        public RenderHtmlImg(List<string> listTempFiles)
        {
            this.listTempFiles = listTempFiles;
        }
        protected override HtmlItem renderingHtmlImg(HtmlItem it, ref Paragraph par, HtmlItem parent, DocumentObject renderparent)
        {
            HtmlImg imagen = it as HtmlImg;
            MigraDoc.DocumentObjectModel.Shapes.Image img = null;
            MigraDoc.DocumentObjectModel.Shapes.TextFrame tf = null;
            if (imagen != null)
            {
                string route = AppDomain.CurrentDomain.BaseDirectory;
                string directorytem = Settings1.Default.routetem;
                string filename = RandomString(16, false) + "." + imagen.ImageType.ToString();
                string routecompleted = route + directorytem + "\\" + filename;
                imagen.Image.Save(routecompleted);

                MigraDoc.DocumentObjectModel.Tables.Cell cellparent = renderparent as MigraDoc.DocumentObjectModel.Tables.Cell;
                if (cellparent != null)
                {
                    tf = cellparent.AddTextFrame();
                    tf.WrapFormat.Style = MigraDoc.DocumentObjectModel.Shapes.WrapStyle.Through;
                }

                if (tf != null)
                    img = tf.AddImage(routecompleted);
                else
                    img = par.AddImage(routecompleted);

                RenderStyle.CreateRenderStyle(it, ref img).Render();
                listTempFiles.Add(routecompleted);
                imagen.SizeRenderItem = new RenderSizeItem() { Width = Convert.ToDecimal(img.Width), Height = Convert.ToDecimal(img.Height) };

            }

            return imagen;
        }
    }
}
