using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    /// <summary>
    /// Implemnentira račun
    /// </summary>
    class Racun:IComparable<Racun>
    {
        private string valuta;
        private double stanje;
        private double tecaj;
        /// <summary>
        /// Racun
        /// </summary>
        /// <param name="valuta"> "eur", "usd",...</param>
        /// <param name="tecaj">tecaj</param>
        public Racun(string valuta, double tecaj)
        {
            this.valuta = valuta;
            this.tecaj = tecaj;
            this.stanje = 0;
        }
        public double StanjeEUR => stanje * tecaj;
        public double Polog
        {
            set => stanje += value*tecaj;
        }
        public static void UrediPoVrednosti(Racun[] tabela)
        {
            Array.Sort(tabela);
        }
        /// <summary>
        /// Metoda za primerjanje
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Racun other)
        {
            if (stanje > other.stanje) return 1;
            else if (stanje < other.stanje) return -1;
            else return 0;
        }
        public override string ToString()
        {
            return String.Format("Racun({0}, {1}, {2})", valuta, tecaj, stanje);
        }
    }
}
