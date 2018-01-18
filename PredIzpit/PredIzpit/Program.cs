using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PredIzpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] sez = new int[3][];
            sez[0] = new int[3];
            sez[1] = new int[2];
            sez[2] = new int[0];
            double p = Povp(sez);
            Console.WriteLine(p);
        }
        static double Povp<T>(T[][] sez)
        {
            double vsota=0;
            int vsi = sez.Length;
            if (vsi == 0)
                return -1;
            foreach(T[] s in sez)
            {
                vsota += s.Length;
            }

            return vsota/vsi;

        }
    }
}
