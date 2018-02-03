using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PodStr;
using ClassLibrary1;

namespace Primer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sklad<int> moj = new Sklad<int>();
            moj.Vstavi(5);
        }
    }
}
