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
