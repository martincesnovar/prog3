using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length>0)
                Console.WriteLine(vrni_najvecji_el(args[0]));
            Console.WriteLine(vrni_najvecji_el("stevila.txt"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vhod"></param>
        /// <returns>Vrne največji element v datoteki</returns>
        static string vrni_najvecji_el(string vhod)
        {
            string niz;
            List<string> niz_tab = new List<string>();
            if (!File.Exists(vhod))
                throw new Exception("Datoteka ne obstaja!");
            using (StreamReader sr = new StreamReader(vhod))
            {
                while ((niz = sr.ReadLine()) != null)
                {
                    niz_tab.Add(niz);
                }

            }
            string naj = najvecji(niz_tab);
            return naj;
        }
        /// <summary>
        /// Poišče največjega med ulomki
        /// </summary>
        /// <param name="tabela">Seznam nizov ulomkov</param>
        /// <returns></returns>
        static string najvecji (List<string> tabela)
        {
            string naj_niz = "";
            double naj = 0;
            int imenovalec;
            double stevec;
            double kolicnik;
            string[] a;
            foreach(string niz in tabela)
            {
                if (niz.Contains("/"))
                {
                    a = niz.Split('/');
                    stevec = Math.Abs(double.Parse(a[0]));
                    imenovalec = int.Parse(a[1]);
                    kolicnik = stevec / imenovalec;
                }
                else
                {
                    stevec = Math.Abs(double.Parse(niz));
                    kolicnik = stevec;
                }
                if (naj < kolicnik)
                {
                    naj = kolicnik;
                    naj_niz = niz;
                }
            }
            return naj_niz;
        }
    }
}
