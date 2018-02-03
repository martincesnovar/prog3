using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaje
{
    class Program
    {
        /// <summary>
        /// Reši nalogo 1 - Polinomi.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Preverjanje implementacije razreda Polinom");
            Console.WriteLine("\n");
            PreveriPolinome();
        }


        /// <summary>
        /// Testira implementacijo razreda Polinom.
        /// </summary>
        static void PreveriPolinome()
        {
            Polinom p, q, r, s;

            p = new Polinom();
            Console.WriteLine("Ničelni polinom p = " + p);
            Console.WriteLine("\n");

            q = new Polinom(3);
            Console.WriteLine("Konstanten polinom q = " + q);
            Console.WriteLine("\n");

            s = new Polinom(0, 2);
            Console.WriteLine("Linearen polinom s = " + s);
            Console.WriteLine("\n");

            int[] koef = new int[] { 2, 1, 0, -2, 1, -3 };
            r = new Polinom(koef);
            Console.WriteLine("Polinom višje stopnje r = " + r);
            koef[0] = 0;
            Console.WriteLine("Ko spremenimo podano tabelo koeficientov, je r = " + r);
            Console.WriteLine("\n");

            p = new Polinom(new int[] { 2, 1, 0, -2, 1, -3 });
            Console.WriteLine("V  p = " + p + " je a3 = " + p.Koeficient(3));
            Console.WriteLine("V  p = " + p + " je a2 = " + p.Koeficient(2));
            Console.WriteLine("V  p = " + p + " je a0 = " + p.Koeficient(0));
            Console.WriteLine("\n");

            p = new Polinom(new int[] { 2, 1, 0, -2, 1, -3 });
            Console.WriteLine("Začnemo s p = " + p);
            p.NastaviKoeficient(2, 1);
            Console.WriteLine("Ko a2 nastavimo na 1 dobimo p = " + p);
            p.NastaviKoeficient(5, 0);
            Console.WriteLine("Ko a5 nastavimo na 0 dobimo p = " + p);
            p.NastaviKoeficient(10, 1);
            Console.WriteLine("Ko a10 nastavimo na 1 dobimo p = " + p);
            Console.WriteLine("\n");

            p = new Polinom(new int[] { 2, 1, 0, -2, 1, -3 });
            Console.WriteLine("Stopnja od " + p + " je " + p.Stopnja);
            p.NastaviKoeficient(2, 1);
            Console.WriteLine("Stopnja od " + p + " je " + p.Stopnja);
            p.NastaviKoeficient(5, 0);
            Console.WriteLine("Stopnja od " + p + " je " + p.Stopnja);
            p.NastaviKoeficient(10, 1);
            Console.WriteLine("Stopnja od " + p + " je " + p.Stopnja);
            p = new Polinom();
            Console.WriteLine("Stopnja od " + p + " je " + p.Stopnja);
            Console.WriteLine("\n");

            Console.WriteLine("Naj bo q = " + q);
            Console.WriteLine("q(2) = " + q.Vrednost(2));
            q = new Polinom();
            Console.WriteLine("Naj bo q = " + q);
            Console.WriteLine("q(2) = " + q.Vrednost(2));
            p = new Polinom(new int[] { 3, 0, 1, -2, 0, 1 });
            Console.WriteLine("Naj bo p = " + p);
            Console.WriteLine("p(0) = " + p.Vrednost(0));
            Console.WriteLine("p(2) = " + p.Vrednost(2));
            Console.WriteLine("\n");

            Console.WriteLine("Naj bo p = " + p);
            q = new Polinom(new int[] { 3, 0, 1, -2, 0 });
            Console.WriteLine("Naj bo q = " + q);
            p.NastaviKoeficient(5, 0);
            Console.WriteLine("Ko v p nastavimo a5 na 0 dobimo " + p);
            if (p.JeEnak(p) && q.JeEnak(p)) Console.WriteLine("Kar je enako q");
            else Console.WriteLine("Kar ni enako q");
            q = new Polinom();
            s = new Polinom(new int[0]);
            Console.WriteLine("Polinoma q = " + q + " in s = " + s);
            if (s.JeEnak(q) && q.JeEnak(s)) Console.WriteLine("sta enaka");
            else Console.WriteLine("nista enaka");
            Console.WriteLine("\n");

            s = new Polinom();
            Console.WriteLine("Ko " + s);
            Console.WriteLine("pomnožimo s 3 dobimo " + (3*s));
            s = new Polinom(p);
            Console.WriteLine("Ko " + s);
            Console.WriteLine("pomnožimo s 3 dobimo " + (3*s));
            Console.WriteLine("\n");

            Console.WriteLine("Ko " + q);
            Console.WriteLine("pomnožimo s " + p);
            Console.WriteLine("Dobimo " + q*p);
            Console.WriteLine("In obratno " + p*q);
            q = new Polinom(new int[] { 1, 0, -2 });
            Console.WriteLine("Ko " + q);
            Console.WriteLine("pomnožimo s " + p);
            Console.WriteLine("Dobimo " + p*q);
            Console.WriteLine("In obratno " + q*p);
            Console.WriteLine("\n");

            Console.WriteLine("Ko " + q);
            Console.WriteLine("prištejemo " + p);
            Console.WriteLine("Dobimo " + (p + q));
            Console.WriteLine("In obratno " + (q + p));
            q = p.Produkt(-1);
            Console.WriteLine("Ko " + q);
            Console.WriteLine("prištejemo " + p);
            Console.WriteLine("Dobimo " + (p + q));
            Console.WriteLine("In obratno " + (q + p));
            if (q.Vsota(p).JeEnak(new Polinom())) Console.WriteLine("Kar je enako ničelnemu polinomu");
            else Console.WriteLine("Kar ni enako ničelnemu polinomu");
        }
    }
}
