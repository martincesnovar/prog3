using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrviOOP
{
    class Pravokotnik
    {
        private int strA;
        private int strB;

        public Pravokotnik(int aaaa, int b)
        {
            this.a = aaaa;
            this.strB = b;  //# še potrebno "zakrpati"
        }

        public int a
        {
            get { return this.strA; }
            set
            {
                int vr = value;
                if (vr <= 0)
                {
                    throw new Exception("STranica mora biti pozitivna");
                }
                this.strA = vr;
            }

        }


    }
}
