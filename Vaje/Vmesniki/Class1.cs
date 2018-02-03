using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodStr
{
    interface Sklad<T>
    {
        void Vstavi(T el);
        T Vrh();
        void Odstrani();
        bool Prazen();     
    }

    interface Vrsta<T>
    {
        void Vstavi(T el);
        T Začetek();
        void Odstrani();
        bool Prazna();

    }
    interface DvDrevo<T>
    {
        T Koren(); 
        DvDrevo<T> LevoPoddrevo();
        DvDrevo<T> DesnoPoddrevo();
        DvDrevo<T> Sestavi(DvDrevo<T> dd, T k, DvDrevo<T> ld); // ta metoda je statična, ostale niso
                                                               // a tega v vmesniku ne povemo, 
                                                               // to povemo šele pri implementaciji
        bool Prazno();

    }
}
