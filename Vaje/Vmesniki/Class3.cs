using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PodStr;

namespace ClassLibrary1
{
    class SkladInt : ISklad<int>
    {
        private List<int> elementi;
        private int indZad;

        public SkladInt()
        {
            this.elementi = new List<int>();
            this.indZad = 0;
        }

        public bool Prazen()
        {
            return this.indZad == -1;
        }

        public void Vstavi(int x)
        {
            this.elementi.Add(x);
            this.indZad++;
        }

        public int Vrh()
        {
            if (this.Prazen()) throw new Exception("Sklad je prazen");
            return this.elementi.Last();
        }

        public void Odstrani()
        {
            if (this.Prazen()) throw new Exception("Sklad je prazen");
            this.elementi.RemoveAt(this.indZad);
            this.indZad--;
        }
    }

    class Sklad<T> : ISklad<T>
    {
        private List<T> elementi;
        private int indZad;

        public Sklad()
        {
            this.elementi = new List<T>();
            this.indZad = 0;
        }

        public bool Prazen()
        {
            return this.indZad == -1;
        }

        public void Vstavi(T x)
        {
            this.elementi.Add(x);
            this.indZad++;
        }

        public T Vrh()
        {
            if (this.Prazen()) throw new Exception("Sklad je prazen");
            return this.elementi.Last();
        }

        public void Odstrani()
        {
            if (this.Prazen()) throw new Exception("Sklad je prazen");
            this.elementi.RemoveAt(this.indZad);
            this.indZad--;
        }
    }
}
