using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ulomki
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulomek a = new Ulomek(10, 3);
            Ulomek b = new Ulomek(-2, 5);
            Ulomek c = a + b;
            Ulomek d = a * b;
            Ulomek e = a - b;
            Ulomek f = a / b;
            List<Ulomek> ul = new List<Ulomek>
            {
                a,b,c,d,e,f
            };
            ul.Sort();
            foreach(Ulomek u in ul)
            {
                Console.WriteLine(u);
            }
        }
    }
}
