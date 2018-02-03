using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga5
{
    class Program
    {
        /// <summary>
        /// Reši nalogo 5 - štetje datotek
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string potDoMape = @"..\..\..\TestStetje";
            int stDatotek = PrestejDatoteke(new DirectoryInfo(potDoMape));
            Console.Write("Stevilo iskanih datotek: ");
            Console.WriteLine(stDatotek);
        }

        /// <summary>
        /// Vrne število datotek v mapah, ki se ne začnejo s števko.
        /// Iskanje začne v izbrani mapi, in nadaljuje v njenih podmapah...
        /// </summary>
        /// <param name="pot">pot do začetne mape</param>
        /// <returns></returns>
        static int PrestejDatoteke(DirectoryInfo mapa)
        {
            int stDatotek = 0;

            if (PrimernoIme(mapa))
            {
                stDatotek += mapa.GetFiles("*").Length;
                DirectoryInfo[] podmape = mapa.GetDirectories();
                foreach (DirectoryInfo m in podmape)
                {
                    stDatotek += PrestejDatoteke(m);
                }
            }
            return stDatotek;

        }

        /// <summary>
        /// Preveri, ali ima dana mapa primerno ime - se ne začne s števko
        /// </summary>
        /// <param name="mapa">informacije o mapi</param>
        /// <returns></returns>
        static bool PrimernoIme(DirectoryInfo mapa)
        {
            char prviZnak = mapa.FullName.Split('\\').Last()[0];
            if (char.IsDigit(prviZnak)) return false;
            else return true;
        }
    }
}
