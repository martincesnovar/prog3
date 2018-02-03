using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gore
{
    class Gore
    {
        static double g = 9.8;

        /// <summary>
        /// Reši nalogo V gore. Vpraša po času padanja kamna in izpiše višino mostu.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Vnesi cas padanja kamna z mostu do tal (v sekundah): ");
            double t = Double.Parse(Console.ReadLine());
            Console.WriteLine("Visina : " + Globina(t) + " m.");

            Console.ReadLine();
        }

        /// <summary>
        /// Iz časa padanja kamna izračuna višino mostu.
        /// </summary>
        /// <param name="t">čas padanja v sekundah</param>
        /// <returns>višina mosta v metrih</returns>
        public static double Globina(double t)
        {
            //izracunamo visino 
            double h = g * Math.Pow(t, 2) / 2;
            //zaokrozimo na dve decimalki 
            h = Math.Round(h, 2);
            return h;
        }
    }
}
