using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Interval(101, 10));
            Console.WriteLine(Interval(52, 30));
        }
        static string Interval(int a, int b)
        {
            string av = a.ToString();
            List<int> stevila = new List<int>();
            string niz="";
            string stev="";
            for(int i = b; i < b*b; i++)
            {
                if ((i-a) % (Math.Pow(10,av.Length)) == 0)
                {
                    stevila.Add(i);
                }
            }
            if (stevila.Count() == 0)
            {
                niz = String.Format("V intervalu [{0}, {1}] ni celih števil, ki bi v zapisu vsebovala število {2}.",b,Math.Pow(b,2),a);
            }
            else
            {
                foreach(int st in stevila)
                {
                    stev += st;
                    stev += ",";
                }
                niz = String.Format("Cela števila iz intervala [{0},{1}], ki v zapisu vsebujejo število {2} so: ",b,b*b,a);
                niz += stev;
            }
            return niz;
        }
    }
}
