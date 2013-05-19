using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Trazas
{
    public enum Niveles { N0 = 0, N1 = 1 }
    public enum NivelesError { Error = 1, Traza = 2 }
    public class Traza
    {//aa
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
