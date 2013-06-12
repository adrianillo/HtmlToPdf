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
using System.Text;
using System.IO;

namespace Trazas
{
    public enum Niveles { N0 = 0, N1 = 1 }
    public enum NivelesError { Error = 1, Traza = 2 }
    public class Traza
    {
        public static void Tracea(string mensaje, NivelesError nivelError)
        {
            int nivel = -1;
            try { nivel = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("NivelTraza").ToString()); }
            catch { }
            string ruta = AppDomain.CurrentDomain.BaseDirectory;

            Niveles Nivel;
            switch (nivel)
            {
                case 0:
                    Nivel = Niveles.N0;
                    break;
                case 1:
                    Nivel = Niveles.N1;
                    break;
                default:
                    Nivel = Niveles.N1;
                    break;
            }

            switch (Nivel)
            {
                case Niveles.N1:
                    escribeLog(mensaje, ruta);
                    break;
                case Niveles.N0:
                    if (nivelError == NivelesError.Error)
                        escribeLog(mensaje, ruta);
                    break;
            }


        }

        private static void escribeLog(string mensaje, string Ruta)
        {
            FileInfo tfile;
            StreamWriter fichero = null;
            try
            {

                tfile = new FileInfo(Ruta + "\\log.txt");
                fichero = tfile.AppendText();
                fichero.WriteLine("");
                fichero.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
                fichero.WriteLine(mensaje);
                fichero.WriteLine("");
                fichero.Close();
            }
            catch (Exception ex)
            {
                //   throw ex;
            }
            finally
            {
                try
                {
                    if (fichero != null)
                        fichero.Dispose();
                }
                catch { }
            }

        }


    }
}
