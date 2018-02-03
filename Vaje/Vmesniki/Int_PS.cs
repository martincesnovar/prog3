using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodStr
{
    interface ISklad<T>
    {
        void Vstavi(T el);
        T Vrh();
        void Odstrani();
        bool Prazen();     
    }

    interface IVrsta<T>
    {
        void Vstavi(T el);
        T Začetek();
        void Odstrani();
        bool Prazna();

    }
    interface IDvDrevo<T>
    {
        T Koren(); 
        IDvDrevo<T> LevoPoddrevo();
        IDvDrevo<T> DesnoPoddrevo();
        IDvDrevo<T> Sestavi(IDvDrevo<T> dd, T k, IDvDrevo<T> ld); // ta metoda je statična, ostale niso
                                                               // a tega v vmesniku ne povemo, 
                                                               // to povemo šele pri implementaciji
        bool Prazno();

    }
}
