using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovezaniSeznam
{
    /// <summary>
    /// Kratko testiranje implementacije enojno povezanega seznama.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Seznam2<int> sez = new Seznam2<int>();
            Console.WriteLine(sez);
            Console.WriteLine(sez.Dolzina);
            sez.Dodaj(0, 0);
            Console.WriteLine(sez);
            sez.Dodaj(5, 1);
            Console.WriteLine(sez);
            sez.Dodaj(2, 0);
            Console.WriteLine(sez);
            sez.Dodaj(3, 2);
            Console.WriteLine(sez);
            Console.WriteLine(sez.VrednostNaMestu(3));
            Console.WriteLine(sez.Dolzina);
            sez.Odstrani(0);
            Console.WriteLine(sez);
            sez.Odstrani(2);
            Console.WriteLine(sez);
            Console.WriteLine(sez.Dolzina);
        }
    }
}
