using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sez = new int[] { 1, 2, 3, 4 };
            int[] sez1 = new int[] { 4, 2, 1, 5, 4 };
            Obrni_tabelo(sez);
            Obrni(ref sez1);
            for(int i = 0; i < sez.Length-1; i++)
            {
                Console.Write(sez[i]+", ");
            }
            Console.Write(sez[sez.Length - 1] + " ");
            
            for(int i = 0; i < sez1.Length-1; i++)
            {
                Console.Write(sez1[i]+", ");
            }
            Console.Write(sez1[sez1.Length - 1] + " ");
        }
        /// <summary>
        /// Obrne tabelo
        /// </summary>
        /// <typeparam name="T">Poljubni parameter</typeparam>
        /// <param name="sez">tabela</param>
        static void Obrni_tabelo<T>(T[] sez)
        {
            T[] zacasna = new T[sez.Length];
            for (int i = 0; i < zacasna.Length; i++)
            {
                zacasna[i] = sez[i];
            }
            for (int i = 0; i < sez.Length; i++)
            {
                sez[sez.Length - i - 1] = zacasna[i];
            }
        }
        static void Obrni<T>(ref T[] sez)
        {
        	Array.Reverse(sez);
        }
    }
}
