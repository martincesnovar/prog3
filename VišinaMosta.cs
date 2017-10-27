using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visina_mosta
{
    class Program
    {
            

            static void Main(string[] args)
            {
                Console.WriteLine("Visina : " + Globina() + " m.");
            }

            public static double Globina()
            {
                Console.Write("Vnesi cas padanja kamna z mostu do tal (v sekundah): ");
                double t = Double.Parse(Console.ReadLine());
            //izracunamo visino 
            double g = 9.8;
            double h = g * Math.Pow(t,2) / 2;
                //zaokrozimo na dve decimalki 
                h = Math.Round(h);
                return h;
        }
    }
}
