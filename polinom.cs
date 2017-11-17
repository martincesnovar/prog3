using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    class Polinom
    {
        private int[] p;
        public Polinom()
        {
            p = new int[0];
        }
        public Polinom(int a_0)
        {
            p = new int[1];
            p[0] = a_0;
        }
        public Polinom(int a_1, int a_0)
        {
            p = new int[1];
            p[0] = a_0;
            p[1] = a_1;
        }
        public Polinom(int[] tab)
        {
            p = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
            {
                p[i] = tab[i];
            }
        }
        public Polinom(Polinom p)
        {
            Polinom q;
            int st = p.Stopnja();
            if (st > 0)
            {
                int[] tab_q = new int[st];
                for (int i = 0; i < st; i++)
                {
                    tab_q[i] = Koeficient(i);
                }
                q = new Polinom(tab_q);
            }
            else
                 q = new Polinom();
        }

        override
        public string ToString()
        {
            string niz = "";
            if (p.Length == 0)
                return niz;
            for (int i = p.Length - 1; i > 1; i--)
            {
                if (p[i] > 0)
                {
                    niz += p[i] + "x^" + i + "+";
                }
            }
            if (p.Length > 1)
            {
                if (p[0] != 0)
                    niz += p[1] + "x" + "+";
                else
                    niz += p[1] + "x";
            }
            niz += p[0];
            return niz;
        }
        public int Koeficient(int i)
        {
            int koeficient=0;
            try
            {
                koeficient = p[i];
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            return koeficient;
        }
        public void NastaviKoeficient(int i, int a)
        {
            if (i >= p.Length)
            {
                //Moramo povečati tabelo
            }
            if (a == 0 && i - 1 == p.Length)
            {
                //Moramo zmanjšati tabelo
            }
            p[i] = a;
        }
        public int Stopnja()
        {
            if (p.Length == 0)
                return -1;
            return p.Length -1;
        }
        public int Vrednost(int x)
        {
            int horner;
            horner = p[0];
            for (int i = 1; i < p.Length; i++)
            {
                horner = horner * x + p[i];
            }
            return horner;
        }
        public bool JeEnak(Polinom p)
        {
            int st_p = p.Stopnja();
            int st = Stopnja();
            if (st_p != st)
                return false;
            for (int i = 0; i < st; i++)
            {
                if (Koeficient(i) != p.Koeficient(i))
                {
                    return false;
                }
            }return true;
        }
        public Polinom Produkt(int k)
        {
            int[] tab = new int[Stopnja()];
            for (int i=0;i < Stopnja(); i++)
            {
                tab[i] = Koeficient(i)*k;
            }
            return new Polinom(tab);
        }
    }
}
