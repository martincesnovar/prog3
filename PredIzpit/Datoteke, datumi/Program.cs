using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Datoteke__datumi
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        static void Datoteke(string Vhod, string Izhod)
        {
            string niz="";
            StreamReader sr = new StreamReader(Vhod);
            StreamWriter sw = new StreamWriter(Izhod);
            while (!sr.EndOfStream)
            {
                niz = sr.ReadLine();
                if (VeljavenDatum(niz))
                {
                    sw.WriteLine(niz);
                }
                
            }
            sr.Close();
            sw.Close();
        }
        /// <summary>
        /// Na izpitu ne bo datumov
        /// </summary>
        /// <param name="niz">niz, ki vsebuje datum</param>
        /// <returns>true/false</returns>
        /*static bool VeljavenDatum(string niz)
        {
            DateTime t = new DateTime();
            /// string[] besede = niz.Split(new string[] {". "}, StringSplitOptions.None);
        }*/
    }
}
