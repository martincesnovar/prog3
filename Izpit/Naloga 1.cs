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
            int[] sez2 = new int[] { 3, 2, 1, 5, 4 };
            Obrni_tabelo(sez);
            Obrni(ref sez1);
            Obrni_s_skladom(sez2);
            for(int i = 0; i < sez.Length-1; i++)
            {
                Console.Write(sez[i]+", ");
            }
            Console.WriteLine(sez[sez.Length - 1] + " ");
            
            for(int i = 0; i < sez1.Length-1; i++)
            {
                Console.Write(sez1[i]+", ");
            }
            Console.WriteLine(sez1[sez1.Length - 1] + " ");
            for(int i = 0; i < sez2.Length-1; i++)
            {
                Console.Write(sez2[i]+", ");
            }
			Console.WriteLine(sez2[sez2.Length - 1]);
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
        static void Obrni_s_skladom<T>(T[] sez)
        {
        	int i = 0;
        	Stack<T> s = new Stack<T>();
        	foreach( T el in sez)
        	{
        		s.Push(el);
        	}
        	while (s.Count>0)
        	{
        		sez[i] = s.Pop();
        		i++;
        	}
        }
    }
}
