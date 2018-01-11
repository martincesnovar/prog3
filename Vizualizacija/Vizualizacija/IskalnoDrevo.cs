using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vizualizacija
{
    /// <summary>
    /// Predstavitev iskalnega drevesa
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class IskalnoDrevo<T> : IIskalnoDrevo<T>, IComparable<T>
    {
        public IskalnoDrevo()
        {
        }
        public IskalnoDrevo(T koren)
        {
            T Koren = koren;
        }
        public IskalnoDrevo(T koren, IskalnoDrevo<T> levo, IskalnoDrevo<T> desno)
        {
            T Koren = koren;
            IskalnoDrevo<T> Levo = levo;
            IskalnoDrevo<T> Desno = desno;
        }
        public T Koren { get; set; }
        public IskalnoDrevo<T> Levo { get; set; }
        public IskalnoDrevo<T> Desno { get; set; }

        public bool Prazno {get;}

        public void Vstavi(T el)
        {

        }

        public void Izbrisi(T el)
        {

        }

        public void Isci(T el)
        {

        }

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }
}
