using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericni_tipi
{
    class Element<T>
    {
        public T vsebina { get; set; }
        public Element<T> naslednji { get; set; }
        public Element(T podatek, Element<T> naslednji)
        {
            this.vsebina = podatek;
            this.naslednji = naslednji;
        }
    }

    class Verizni_seznam<T>
    {
        public Element<T> Vozel { get; set; }
        public T podatek { get; set; }
        public Element<T> naslednji { get; set; }
        public Verizni_seznam(T podatek, Element<T> naslednji)
        {
            this.Vozel = new Element<T>(podatek,  naslednji);
        }
        

        private int dolzina()
        {       
            int i = 0;
            while (Vozel != null)
            {
                i++;
                Vozel = Vozel.naslednji;
            }
             return i;
        }
        public int Dolzina
        { get { return dolzina(); } }

        public void Dodaj(T vrednost, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Vozel = Vozel.naslednji;
            }
        //private Element<T> nov_vozel = new Element<T>(T podatek,naslednji);
        //Element <T> Nov = new Element<T>(vrednost, nov_vozel);
        //Vozel.naslednji = Nov;

        }

        public void Odstrani(int n)
        {

        }
        /// <summary>
        /// Vrni n-ti element
        /// </summary>
        /// <param name="n"></param>
        public T VrednostNaMestu(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Vozel = Vozel.naslednji;
            }
            return Vozel.vsebina;
        }

        public override string ToString()
        {
            string niz = "[";
            while (Vozel != null)
            {
                niz += Vozel.vsebina;
                Vozel = Vozel.naslednji;
            }
            niz += "]";
            return niz;
        }
    }
}
