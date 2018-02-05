using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(vrni(20, 9));
            Console.WriteLine(vrni(4, 9));
        }
        static string vrni(int n, int k)
        {
            List<int> tabela = new List<int>();
            for(int i = n; i < 2 * n + 1; i++)
            {
                if (deljiva(i, k)) tabela.Add(i);
            }
            if (tabela.Count() == 0)
                return String.Format("V intervalu [{0}, {1}] ni celih števil, katerih vsota števk je deljiva z {2}.", n, 2 * n, k);
            string izpis = izpisi_tabelo(tabela);
            return String.Format("Cela števila iz intervala [{0}, {1}] katerih vsota števk je deljiva z {2} so: {3}.", n, 2 * n, k, izpis);
        }
        /// <summary>
        /// Preveri ali je vsota števk deljiva z k
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        static bool deljiva(int i, int k)
        {
            int vsota = 0;
            string t = i.ToString();
            foreach (char c in t)
            {
                vsota += int.Parse(c.ToString());
            }
            if (vsota % k == 0) return true;
            return false;
        }
        /// <summary>
        /// Izpiše elemente tabele v niz
        /// </summary>
        /// <param name="tabela"></param>
        /// <returns></returns>
        static string izpisi_tabelo(List<int> tabela)
        {
            string niz = "";
            foreach(int el in tabela)
            {
                niz += el + ",";
            }
            return niz.Remove(niz.Length - 1);
        }
    }
}
