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
    /// Rekurzivna implementacija.
    /// </remarks>
    /// <typeparam name="T">Tip elementov seznama.</typeparam>
    class Seznam2<T>
    {
        private T glava;          // Prvi element seznama
        private Seznam2<T> rep;   // Seznam preostalih elementov

        /// <summary>
        /// Lastnost, ki pove, ali je seznam prazen.
        /// </summary>
        private bool Prazen
        {
            get => rep == null;
        }

        /// <summary>
        /// Število elementov v seznamu.
        /// </summary>
        public int Dolzina
        {
            get
            {
                if (Prazen) return 0;
                else return 1 + rep.Dolzina;
            }
        }

        /// <summary>
        /// Naredi prazen seznam
        /// </summary>
        public Seznam2() { }


        /// <summary>
        /// Vrne določen element seznama.
        /// </summary>
        /// <param name="mesto">Mesto elementa v seznamu, ki nas zanima.</param>
        /// <returns>Vrednost na določenem mestu seznama.</returns>
        public T VrednostNaMestu(int mesto)
        {
            if (Prazen) throw new Exception("Prekratek seznam");
            else if (mesto == 0) return glava;
            else return rep.VrednostNaMestu(mesto - 1);
        }

        /// <summary>
        /// Na želeno mesto v seznamu doda podan element.
        /// </summary>
        /// <param name="element">Element, ki ga želimo dodati v seznam.</param>
        /// <param name="mesto">Mesto v seznamu, kamor dodajamo element.</param>
        public void Dodaj(T element, int mesto)
        {
            if (mesto == 0)
            {
                Seznam2<T> novRep = new Seznam2<T>
                {
                    glava = glava,
                    rep = rep
                };
                glava = element;
                rep = novRep;
            }
            else if (Prazen)
            {
                throw new Exception("Prekratek seznam.");
            }
            else
                rep.Dodaj(element, mesto - 1);
        }

        /// <summary>
        /// Iz seznama odstrani element na določenem mestu.
        /// </summary>
        /// <param name="mesto">Mesto v seznamu, na katerem odstranjujemo element.</param>
        public void Odstrani(int mesto)
        {
            if (Prazen) throw new Exception("Prekratek seznam.");
            else if (mesto == 0)
            {
                glava = rep.glava;
                rep = rep.rep;
            }
            else rep.Odstrani(mesto - 1);
        }


        /// <summary>
        /// Seznam predstavi z nizom oblike [e0, e1, ..., en].
        /// </summary>
        /// <returns>Predstavitev seznama z nizom.</returns>
        public override string ToString()
        {
            if (Prazen) return "[]";
            else if (rep.Prazen)
            {
                return String.Format("[{0}]", glava);
            }
            else
            {
                string ostanek = rep.ToString();
                return String.Format("[{0}, {1}", glava, ostanek.Substring(1));
            }
        }

    }
}
