using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjižnica
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = NakljucnaTabela(10, 10);
            int[] tab1 = NakljucnaTabela(5, 42, true);
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);

            }
            Console.WriteLine("---- ");
            for (int i = 0; i < tab1.Length; i++)
            {
                Console.WriteLine(tab1[i]);

            }
            Console.WriteLine(TabelaKotNiz(tab));
            Console.WriteLine(TabelaKotNiz(tab,"@ "));
        }
        static int[] NakljucnaTabela(int d, int m)

        {
            int[] Tabela = new int[d];
            Random nakljucna = new Random();
            for (int i = 0; i < d; i++)
            {
                int nakljucno_st = nakljucna.Next(1, m + 1);
                    Tabela[i] = nakljucno_st;
            }
            return Tabela;
        }
        /// <summary>
        /// Naključna cela tabela
        /// </summary>
        /// <param name="d">Dolžina</param>
        /// <param name="m">Do kje random</param>
        /// <param name="razlicni">Naj bodo elementi različni?</param>
        /// <returns>Naključno celo tabelo</returns>
        static int[] NakljucnaTabela(int d, int m, bool razlicni)
        {
            int[] Tabela = new int[d];
            Random nakljucna = new Random();
            for (int i = 0; i < d; i++)
            {
                int nakljucno_st = nakljucna.Next(1, m + 1);
                if (razlicni)
                {
                    bool is_in = In(nakljucno_st, Tabela);
                    while (!is_in)
                    {
                        nakljucno_st = nakljucna.Next(1, m + 1);
                        is_in = In(nakljucno_st, Tabela);
                    }
                    Tabela[i] = nakljucno_st;
                }
                else
                {
                    Tabela[i] = nakljucno_st;
                }


            }
            return Tabela;
        }
        /// <summary>
        /// Funkcija preveri, ali je število v tabeli
        /// </summary>
        /// <param name="n">Število</param>
        /// <param name="tab">Tabela</param>
        /// <returns>bool true false</returns>
        static bool In(int n, int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == n)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Pretvori tabelo celih števil v niz
        /// </summary>
        /// <param name="t">tabela celih števil</param>
        /// <returns>Vrne niz</returns>
        static string TabelaKotNiz(int[] t)
        {
            string niz = "";
            for (int i = 0; i < t.Length; i++)
            {
                niz += t[i] + " ";
            }
            return niz;

        }
        /// <summary>
        /// Pretvori tabelo celih števil v niz ločen z ločilom
        /// </summary>
        /// <param name="t">tabela celih števil</param>
        /// /// <param name="locilo">uporabljeno ločilo</param>
        /// <returns>Vrne niz</returns>
        static string TabelaKotNiz(int[]t, string locilo)
        {
            string niz = "";
            for (int i = 0; i < t.Length; i++)
            {
                niz += t[i] + locilo;
            }
            return niz;
        }
    }
}
