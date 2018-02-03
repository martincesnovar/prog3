using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Sklad<int> mojS = new Sklad<int>();
            mojS.Vstavi(42);
            Console.WriteLine(mojS.Vrh());
        }
    }
}
