using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sličice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lepi = Lepljenje();
            Console.WriteLine("Povprečno število sličič, ki jih je potrebno kupiti, da zapolnimo album je " + lepi[0] + " .");
            Console.WriteLine("Najmanjše število sličič, ki jih je potrebno kupiti, da zapolnimo album je " + lepi[2] + " .");
            Console.WriteLine("Največje število sličič, ki jih je potrebno kupiti, da zapolnimo album je " + lepi[1] + " .");
        }
        static int[] Lepljenje()
        {
            Console.Write("Vnesi m: ");
            int m = int.Parse(Console.ReadLine());
            int n = 50;
            int max = 0; // največ kuljenih sličič za zapolnjen album
            int min = 1000; // najmanj kuljenih sličič za zapolnjen album, predpostavimo da nam nikoli ne bo potrebno kupiti več kot 1000 sličič
            bool[] album = new bool[n]; //seznam sličic v albumu
            int skupajKupljene = 0; // štejemo koliko sličič smo kupili v vseh 1000-ih polnjenjih
            Random nakljucna = new Random();
            for (int i = 0; i < 1000; i++) // simuliramo 1000 polnitev albuma
            {
                int manjka = n; // album je prazen
                int kupili = 0; // štejemo kupljene sličiče
                int j = 0;
                while (j < n) // vse vrednosti v albumu postavimo na 'false', torej nismo še prilepili slicice
                {
                    album[j] = false;
                    j++;
                }

                while (manjka > 0) // polnimo album vse doler ne dobimo prav seh sličič 
                {
                    int koliko = 0;
                    while (koliko < m)
                    {
                        int nakljucnoSt = nakljucna.Next(n); // kupimo eno sličičo
                        kupili++;
                        if (!album[nakljucnoSt]) // če je mesto za to slicico še prosto...
                        {
                            album[nakljucnoSt] = true; // ...ga zapolnimo, tako da sličičo prilepimož
                            manjka--; // manjka ena sličiča manj
                            koliko++;
                        }
                    }
                }
                skupajKupljene = skupajKupljene + kupili;
                if (kupili > max) max = kupili;
                if (kupili < min) min = kupili;
            }
            int povprecje = skupajKupljene / 1000;
            int[] tab = {povprecje, max, min};
            return tab;
        }
    }
}
