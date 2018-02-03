using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaje
{
    partial class Polinom
    {
        private int[] Koeficienti;

        /// <summary>
        /// Stopnja polinoma.
        /// </summary>
        public int Stopnja
        {
            get { return Koeficienti.Length - 1; }
        }

        /// <summary>
        /// Ustvari ničelni polinom.
        /// </summary>
        public Polinom() : this(new int[0])
        {
        }

        /// <summary>
        /// Ustvari konstanten polinom.
        /// </summary>
        /// <param name="a0">prosti člen</param>
        public Polinom(int a0) : this(new int[] { a0 })
        {
        }

        /// <summary>
        /// Ustvari linearen polinom.
        /// </summary>
        /// <param name="a0">prosti člen</param>
        /// <param name="a1">linearen člen</param>
        public Polinom(int a0, int a1) : this(new int[] {a0, a1 })
        {
        }

        /// <summary>
        /// Ustvari poljuben polinom. Koeficienti so podani s tabelo od a0 naprej.
        /// </summary>
        /// <param name="aji">tabela koeficientov</param>
        public Polinom(int[] aji)
        {
            Koeficienti = new int[aji.Length];
            Array.Copy(aji, Koeficienti, aji.Length);
            PobrisiPrazneKoeficiente();
        }

        /// <summary>
        /// Ustvari kopijo podanega polinoma.
        /// </summary>
        /// <param name="p">originalen polinom</param>
        public Polinom(Polinom p)
        {
            Koeficienti = new int[p.Stopnja + 1];
            for (int i=0; i < p.Stopnja+1; i++)
            {
                Koeficienti[i] = p.Koeficient(i);
            }
        }

        /// <summary>
        /// Vrne i-ti koeficient (a_i) polinoma. Če ga ni sproži izjemo.
        /// </summary>
        /// <param name="i"></param>
        public int Koeficient(int i)
        {
            return Koeficienti[i];
        }

        /// <summary>
        /// Nastavi i-ti koeficient (a_i) polinoma.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a">nova vrednost koeficienta</param>
        public void NastaviKoeficient(int i, int a)
        {
            if (i >= Koeficienti.Length)
            {
                int[] novaTabela = new int[i + 1];
                Array.Copy(Koeficienti, novaTabela, Koeficienti.Length);
                Koeficienti = novaTabela;
            }
            Koeficienti[i] = a;
            PobrisiPrazneKoeficiente();
        }

        /// <summary>
        /// Pobrise morebitne ničle na koncu tabele koeficientov.
        /// </summary>
        private void PobrisiPrazneKoeficiente()
        {
            if (Koeficienti.Length > 0 && Koeficienti.Last() == 0)
            {
                int zadnjiNenicelni = Koeficienti.Length - 2;
                while (zadnjiNenicelni>-1 && Koeficienti[zadnjiNenicelni] == 0) zadnjiNenicelni--;

                int[] novaTabela = new int[zadnjiNenicelni + 1];
                Array.Copy(Koeficienti, novaTabela, zadnjiNenicelni + 1);
                Koeficienti = novaTabela;
            }
        }

        /// <summary>
        /// Preveri, ali je polinom enak podanemu polinomu.
        /// </summary>
        /// <param name="p">podan polinom</param>
        public bool JeEnak(Polinom p)
        {
            if (Stopnja == p.Stopnja)
            {
                for (int i = 0; i < Koeficienti.Length; i++)
                {
                    if (Koeficient(i) != p.Koeficient(i))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Polinom predstavi z nizom a_n x^n + ... + a_1 x + a_0.
        /// </summary>
        public override string ToString()
        {
            if (Stopnja == -1) return "0";
            string s = "";
            int k;
            for (int i = Stopnja; i >= 0; i--)
            {
                k = Koeficient(i);
                if (k != 0)
                {
                    if (k < 0)
                    {
                        if (i == Stopnja) s += "-";
                        else s += " - ";
                    }
                    else
                    {
                        if (i < Stopnja) s += " + ";
                    }
                    if (Math.Abs(k) > 1 || i == 0) s += Math.Abs(k);
                    if (i > 0) s += "x";
                    if (i > 1) s += "^" + i;
                }
            }
            return s;
        }

    }
}
