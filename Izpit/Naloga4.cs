using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Racun r = new Racun("eur", 1);
            Racun r1 = new Racun("usd", 1.12);
            Racun r2 = new Racun("coin", 10000);
            r.Polog = 1090;
            r1.Polog = 1500;
            r2.Polog = 0.5;
            Racun[] tab = new Racun[] { r, r1, r2 };
            Racun.UrediPoVrednosti(tab);
            foreach(Racun ra in tab)
            {
                Console.WriteLine(ra);
            }

        }
    }
}
