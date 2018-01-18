using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vozilo
{
    class Program
    {
        static void Main(string[] args)
        {
            Vozilo golf = new Vozilo(50, 5);
            double x = golf.PreostaliKilometri;
            Console.WriteLine(x);
        }
    }
}
