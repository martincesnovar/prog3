using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ulomki
{
    class Ulomek:IComparable, IComparable<Ulomek>,IEquatable<Ulomek>
    {
        static int GCD(int n, int m)
        {
            int c;
            while (n != 0)
            {
                c = n;
                n = m % n;
                m = c;
            }
                return m;
        }
        private int st;
        private int im;
        public Ulomek()
        {
            St = 0;
            Im = 1;
        }
        public Ulomek(int stevec)
        {
            St = stevec;
            Im = 1;
        }
        public Ulomek(int stevec, int imenovalec)
        {
            int d = GCD(stevec, imenovalec);
            St = (int)((double)stevec/d);
            Im = (int)((double)imenovalec / d);
        }
        public int St
        {
            get
            {
                return st;
            }
            set
            {
                st = value;
            }
        }
        public int Im
        {
            get
            {
                return im;
            }
            set
            {
                if (value > 0) im = value;
                else if (value < 0)
                {
                    im = Math.Abs(value);
                    st = -st;
                }
                else throw new DivideByZeroException();
            }
        }
        private Ulomek ne()
        {
            return new Ulomek(-St, Im);
        }
        private Ulomek obrni()
        {
            return new Ulomek(Im, St);

        }
        public Ulomek Sestej(Ulomek a)
        {
            int d = GCD(St * a.Im + a.St * Im, Im * a.Im);
            return new Ulomek((int)((double)(St * a.Im + a.St * Im)/d), (int)((double)(Im * a.Im)/d));
        }
        public Ulomek Mnozi(Ulomek a)
        {
            int d = GCD(St * a.St, Im * a.Im);
            return new Ulomek((int)((double)(St * a.St) / d), (int)((double)(Im * a.Im) / d));
        }
        public static Ulomek operator +(Ulomek a, Ulomek b)
        {
            return a.Sestej(b);
        }
        public static Ulomek operator -(Ulomek a, Ulomek b)
        {
            return a.Sestej(b.ne());
        }
        public static Ulomek operator *(Ulomek a, Ulomek b)
        {
            return a.Mnozi(b);
        }
        public static Ulomek operator /(Ulomek a, Ulomek b)
        {
            return a.Mnozi(b.obrni());
        }
        public static bool operator >(Ulomek a, Ulomek b)
        {
            if (a.CompareTo(b)>0)
                return true;
            return false;
        }
        public static bool operator <(Ulomek a, Ulomek b)
        {
            if (a.CompareTo(b) < 0)
                return true;
            return false;
        }
        public static bool operator >=(Ulomek a, Ulomek b)
        {
            if (a.CompareTo(b) >= 0)
                return true;
            return false;
        }
        public static bool operator <=(Ulomek a, Ulomek b)
        {
            if (a.CompareTo(b) <= 0)
                return true;
            return false;
        }
        public static bool operator ==(Ulomek a, Ulomek b)
        {
            if (a.CompareTo(b) == 0)
                return true;
            return false;
        }
        public static bool operator !=(Ulomek a, Ulomek b)
        {
            if (a.CompareTo(b) != 0)
                return true;
            return false;
        }

        public override string ToString()
        {
            if (Im != 1)
                return St + "/" + Im;
            else
                return St+"";
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Ulomek other)
        {
            int a = St * other.Im;
            int b = Im * other.St;
            if (a > b) return 1;
            else if (a < b) return -1;
            else return 0;

        }
        static void Uredi(List<Ulomek> ul)
        {
            ul.Sort();
        }

        public  bool Equals(Ulomek other)
        {
            int a = St * other.Im;
            int b = Im * other.St;
            if (a == b) return true;
            return false;
        }
        public override bool Equals(Object other)
        {
            throw new NotImplementedException();
        }
    }
}
