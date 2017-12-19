using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_StudentiObrazec
{
    class Student
    {
        public string ime {get; set;}
        public string priimek { get; set; }
        public string spol { get; set; }
        public DateTime datumRojstva { get; set; }

        public Student(string ime, string priimek, string spol, DateTime datumRojstva)
        {
            this.ime = ime;
            this.priimek = priimek;
            this.spol = spol;
            this.datumRojstva = datumRojstva;
        }

        public override string ToString()
        {
            return ime + " " + priimek + " " + spol + " " + datumRojstva;
        }
    }
}
