using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int[] Kopija(int[] t)
        {
            int[] Kopija = new int[t.Length];
            for (int i = 0; i < t.Length; i++)
            {
                Kopija[i] = t[i];
            }
            return Kopija;
        }
        static void Izpisi(string ime, int[] t)
        {
            Console.Write(ime + "= ");
            for (int i = 0; i < t.Length-1; i++)
            {
                Console.Write(t[i]+",");
            }
            Console.Write(t[t.Length-1]+" "); //Na zadnjem ni ","
        }
        static void Main(string[] args)
        {
            int[] t = { 1, 2, 3 };
            int[] k = Kopija(t);
            Izpisi("Janez ", k);
            int[] a = { 1, 2, 3 }; int[] b = Kopija(a);
            Console.WriteLine("Prej: "); Izpisi("a", a); Izpisi("b", b);
            a[1] = b[2]; a[2] = b[1];
            Console.WriteLine("Potem: "); Izpisi("a", a); Izpisi("b", b);
        }
    }
}
