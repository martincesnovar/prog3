using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga1
{
    class Program
    {
        /// <summary>
        /// Rešitev naloge 1: obravnavanje izjem.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Program izpiše vrednost izraza (a+b)/c, za cela števila a,b,c.");
            IzpisiVrednost();
        }

        /// <summary>
        /// Uporabnika sprašuje po številih a,b,c dokler iz vnosov ni možno izračunati izraza.
        /// Pri tem 3 izjeme obravnava posebej: če ne vnesemo celega števila, če je število 
        /// preveliko za tip int in če je c = 0.
        /// Če se zgodi kakšna druga izjema se funkcija konča in prosi, da se tudi ta obravnava ločeno.
        /// </summary>
        static void IzpisiVrednost()
        {
            try
            {
                Console.Write("Vnesi a: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Vnesi b: ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Vnesi c: ");
                int c = int.Parse(Console.ReadLine());
                Console.WriteLine("(a+b)/c = " + ((a + b) / c));
            }
            catch (System.DivideByZeroException)
            {
                Console.WriteLine("Z nič pa ne bom delil!");
                Console.WriteLine("Poskusi od začetka.");
                IzpisiVrednost();
            }
            catch (System.FormatException)
            {
                Console.WriteLine("To pa ni celo število...");
                Console.WriteLine("Poskusi od začetka.");
                IzpisiVrednost();
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("Število je preveliko za tip int");
                Console.WriteLine("Poskusi od začetka.");
                IzpisiVrednost();
            }
            catch (Exception e)
            {
                Console.WriteLine("Nekaj neznanega je šlo narobe:");
                Console.WriteLine(e.ToString());
                Console.WriteLine("Popravi program, da bo to izjemo obravnaval posebej.");
            }
        }
    }
}
