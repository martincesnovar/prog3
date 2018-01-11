using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vizualizacija
{
    interface IIskalnoDrevo<T>
    {
        void Vstavi(T el);
        void Izbrisi(T el);
        void Isci(T el);
    }
}
