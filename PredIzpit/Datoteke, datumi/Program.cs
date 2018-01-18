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
        /// Preveri ali je datum veljaven, ne preverja prestopnih let...
        /// </summary>
        /// <param name="niz">niz, ki vsebuje datum</param>
        /// <returns>true/false</returns>
        static bool VeljavenDatum(string niz)
        {
            if (niz.Length != 12)
            {
                return false;
            }
            if (niz[2]!='.' || niz[6] != '.')
            {
                return false;
            }
            if (!(niz[0]<'4' && niz[0]>='0' && niz[4] < '2' && niz[4] >= '0'))
            {
                return false;
            }
            if(!(niz[0]=='3' && niz[1] < '2'))
            {
                //prepove 32+. dan
                return false;
            }
            if (!(niz[4] == '1' && niz[5] < '3'))
            {
                //prepove 13+. mesec
                return false;
            }
            foreach (char c in niz)
            {
                if (!(c <='9' && c>'0' || c=='.' || c==' '))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
