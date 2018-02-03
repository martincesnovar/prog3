using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZamenjavaElementov
{
    class ZamenjavaElementov
    {
        /// <summary>
        /// Reši nalogo Zamenjava elementov: kopira tabelo in v njej zamenja elemente.
        /// Izpiše originalno tabelo in njeno kopijo pred menjavo in po njej.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3 }; int[] b = Kopija(a);
            Console.WriteLine("Prej: "); Izpisi("a", a); Izpisi("b", b);
            a[1] = b[2]; a[2] = b[1];
            Console.WriteLine("Potem: "); Izpisi("a", a); Izpisi("b", b);

            Console.ReadLine();
        }

        /// <summary>
        /// Vrne kopijo dane tabele.
        /// </summary>
        /// <param name="t">Dana tabela</param>
        /// <returns>Kopija tabele t</returns>
        static int[] Kopija(int[] t)
        {
            int[] s = new int[t.Length];
            t.CopyTo(s,0);
            return s;
        }

        /// <summary>
        /// Izpiše ime tabele in števila v njej.
        /// </summary>
        /// <param name="ime">Ime tabele</param>
        /// <param name="t">tabela števil</param>
        static void Izpisi(string ime, int[] t) {
            string izpis = ime+":";
            foreach (int i in t)
            {
                izpis += " " + i;
            }
            Console.WriteLine(izpis);
        }
    }
}
