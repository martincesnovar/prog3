using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga2
{
    class Program
    {
        /// <summary>
        /// Rešitev naloge 2: zapisovanje in branje datoteke.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string imeDatoteke = "dnevnik.txt";
            Console.WriteLine("Piši v dnevnik:");
            ZapisiDnevnik(imeDatoteke);
            Console.WriteLine();
            Console.WriteLine("Napisal si:");
            IzpisiDnevnik(imeDatoteke);
        }

        /// <summary>
        /// Uporabnika sprašuje po vhodu in ga po vrsticah zapisuje v izbrano datoteko.
        /// Ko uporabnik vnese "Konec" se pisanje konča. Niz "Konec" ni zapisan v datoteko.
        /// </summary>
        /// <param name="imeDnevnika">Ime datoteke za zapisovanje</param>
        static void ZapisiDnevnik(string imeDnevnika)
        {
            using (StreamWriter pisalo = File.CreateText(imeDnevnika))
            {
                string vnos = Console.ReadLine();
                while (!vnos.Equals("Konec"))
                {
                    pisalo.WriteLine(vnos);
                    vnos = Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Vrstice v datoteki oštevilčeno izpiše.
        /// </summary>
        /// <param name="imeDnevnika">Ime datoteke za branje</param>
        static void IzpisiDnevnik(string imeDnevnika)
        {
            using (StreamReader bralnik = File.OpenText(imeDnevnika))
            {
                int vrstica = 1;
                while (!bralnik.EndOfStream)
                {
                    Console.WriteLine(vrstica + ". "+bralnik.ReadLine());
                    vrstica++;
                }
            }
        }
    }
}
