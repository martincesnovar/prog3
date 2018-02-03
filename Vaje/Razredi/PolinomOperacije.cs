using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaje
{
    partial class Polinom
    {
        /// <summary>
        /// S Hornerjevim algoritmom izračuna vrednost polinoma v dani točki.
        /// </summary>
        /// <param name="x">dana točka</param>
        /// <returns>vrednost polinoma v x</returns>
        public int Vrednost(int x)
        {
            if (Stopnja < 0) return 0;
            int vrednost = Koeficienti.Last();
            for (int i = Koeficienti.Length - 2; i >= 0; i--)
            {
                vrednost = vrednost * x + Koeficienti[i];
            }
            return vrednost;
        }

        /// <summary>
        /// Vrne vsoto z danim polinomom.
        /// </summary>
        /// <param name="p">polinomski seštevanec</param>
        public Polinom Vsota(Polinom p)
        {
            int dolzina = Math.Max(p.Stopnja, Stopnja) + 1;
            int[] noviKoeficienti = new int[dolzina];
            for (int i = 0; i < Stopnja + 1; i++) noviKoeficienti[i] += Koeficient(i);
            for (int i = 0; i < p.Stopnja + 1; i++) noviKoeficienti[i] += p.Koeficient(i);
            return new Polinom(noviKoeficienti);
        }

        /// <summary>
        /// Vrne produkt z danim polinomom.
        /// </summary>
        /// <param name="p">polinomski faktor</param>
        /// <returns>rezultat množenja</returns>
        public Polinom Produkt(Polinom p)
        {
            if (Stopnja == -1 || p.Stopnja == -1) return new Polinom();

            int novaStopnja = Stopnja + p.Stopnja;
            int[] noviKoeficienti = new int[novaStopnja + 1];
            for (int i = 0; i < Stopnja + 1; i++)
            {
                for (int j = 0; j < p.Stopnja + 1; j++)
                {
                    noviKoeficienti[i + j] += Koeficient(i) * p.Koeficient(j);
                }
            }
            return new Polinom(noviKoeficienti);
        }


        /// <summary>
        /// Vrne produkt polinoma s celim številom.
        /// </summary>
        /// <param name="k">faktor</param>
        /// <returns>rezultat množenja</returns>
        public Polinom Produkt(int k)
        {
            return Produkt(new Polinom(k));
        }

        /// <summary>
        /// Vrne vsoto polinomov.
        /// </summary>
        public static Polinom operator +(Polinom p, Polinom q)
        {
            return p.Vsota(q);
        }

        /// <summary>
        /// Vrne produkt polinomov.
        /// </summary>
        public static Polinom operator *(Polinom p, Polinom q)
        {
            return p.Produkt(q);
        }

        /// <summary>
        /// Vrne produkt polinoma in celega števila.
        /// </summary>
        public static Polinom operator *(int k, Polinom p)
        {
            return p.Produkt(k);
        }

        /// <summary>
        /// Vrne produkt polinoma in celega števila.
        /// </summary>
        public static Polinom operator *(Polinom p, int k)
        {
            return k * p;
        }

    }
}
