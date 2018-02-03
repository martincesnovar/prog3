using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrojkPaNe
{
    class TrojkPaNe
    {
        /// <summary>
        /// Reši nalogo TrojkPaNe. Rešitev preveri na enem testnem primeru, izpiše tabelo pred in po preobrazbi.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] tab1 = new int[] { 13, 2, 3, 31, 10, 33, 133, 313 };
            int[] tab2 = new int[] { 13, 2, 3, 31, 10, 33, 133, 313 };
            Console.WriteLine("Začetna tabela: " + string.Join(",", tab1));
            Console.WriteLine();

            Krajsaj(ref tab2);
            Console.WriteLine("Po Krajsaj: "+string.Join(",", tab2));

            Console.ReadLine();
        }


        /// <summary>
        /// Iz vsakega elementa tabele števil pobriše števke 3. Elemente, ki imajo samo števke 3, pobriše.
        /// </summary>
        /// <param name="t">Referenca do vhodne tabele števil.</param>
        static void Krajsaj(ref int[] t)
        {
            List<int> okrajsane = new List<int>();
            foreach (int i in t)
            {
                string zapis = i.ToString();
                string filtriran = zapis.Replace("3", "");
                if (filtriran.Length > 0) okrajsane.Add(int.Parse(filtriran));
            }
            t = okrajsane.ToArray();
        }

    }
}
