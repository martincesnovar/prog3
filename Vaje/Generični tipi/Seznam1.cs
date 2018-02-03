using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovezaniSeznam
{
    /// <summary>
    /// Impementacija enojno povezanega seznama.
    /// </summary>
    /// <remarks>
    /// Podpira dodajanje elementa na določeno mesto, izbris elementa na določenem mestu,
    /// vračanje elementa na določenem mestu ter preprosto predstavitev seznama z nizom.
    /// Implementacija s privatnim razredom za člene.
    /// </remarks>
    /// <typeparam name="T">Tip elementov seznama.</typeparam>
    class Seznam1<T>
    {
        /// <summary>
        /// Privatni razred za predstavitev členov seznama.
        /// Vsak objekt ima vsebino in referenco do naslednjega člena.
        /// </summary>
        /// <typeparam name="T">Tip elementov seznama</typeparam>
        private class Clen
        {
            public T Vsebina { get; set; }
            public Clen Naslednik { get; set; }

            public Clen(T v)
            {
                Vsebina = v;
            }
        }

        private Clen glava;  // prvi člen seznama

        /// <summary>
        /// Število elementov v seznamu.
        /// </summary>
        public int Dolzina
        {
            get;
            private set;
        }

        /// <summary>
        /// Naredi prazen seznam.
        /// </summary>
        public Seznam1() { }

        /// <summary>
        /// Vrne člen na določenem mestu.
        /// </summary>
        /// <param name="mesto"></param>
        private Clen ClenNaMestu(int mesto)
        {
            if (glava == null) throw new Exception("Seznam je prekratek.");
            Clen kandidat = glava;
            while (mesto > 0)
            {
                kandidat = kandidat.Naslednik;
                if (kandidat == null) throw new Exception("Seznam je prekratek.");
                mesto--;
            }
            return kandidat;
        }


        /// <summary>
        /// Doda podani element na izbrano mesto v seznamu.
        /// </summary>
        /// <param name="vrednost">Element, ki ga dodajamo.</param>
        /// <param name="mesto">Mesto, kamor dodajamo element.</param>
        public void Dodaj(T vrednost, int mesto)
        {
            Dolzina++;
            Clen novi = new Clen(vrednost);
            if (mesto == 0)
            {
                novi.Naslednik = glava;
                glava = novi;
            }
            else
            {
                Clen prednik = ClenNaMestu(mesto - 1);
                novi.Naslednik = prednik.Naslednik;
                prednik.Naslednik = novi;
            }
        }


        /// <summary>
        /// Odstrani element na izbranem mestu v seznamu.
        /// </summary>
        /// <param name="mesto"></param>
        public void Odstrani(int mesto)
        {
            if (glava == null) throw new Exception("Seznam ni dovolj dolg.");
            if (mesto == 0) glava = glava.Naslednik;
            else
            {
                Clen prednik = ClenNaMestu(mesto - 1);
                if (prednik.Naslednik == null) throw new Exception("Seznam ni dovolj dolg.");
                prednik.Naslednik = prednik.Naslednik.Naslednik;
            }
            Dolzina--;
        }

        /// <summary>
        /// Vrne določen element seznama.
        /// </summary>
        /// <param name="mesto">Mesto elementa v seznamu, ki nas zanima.</param>
        /// <returns>Vrednost na določenem mestu seznama.</returns>
        public T VrednostNaMestu(int mesto)
        {
            return ClenNaMestu(mesto).Vsebina;
        }


        /// <summary>
        /// Seznam predstavi z nizom oblike [e0, e1, ..., en].
        /// </summary>
        /// <returns>Predstavitev seznama z nizom.</returns>
        public override string ToString()
        {
            if (glava == null) return "[]";
            string predstavitev = "";
            Clen trenutni = glava;
            while (trenutni != null)
            {
                predstavitev += ", " + trenutni.Vsebina.ToString();
                trenutni = trenutni.Naslednik;
            }
            return "[" + predstavitev.Substring(2) + "]";
        }
    }
}
