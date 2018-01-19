using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vozilo
{
    class Vozilo:IComparable<Vozilo>
    {
        private double gorivo;
        private double kapaciteta;
        private double poraba;
        public Vozilo(double kapaciteta, double poraba)
        {
            gorivo = kapaciteta;
            this.kapaciteta = kapaciteta;
            this.poraba = poraba;
        }
        public double PreostaliKilometri { get { return 100*gorivo/poraba; } }

        public int CompareTo(Vozilo other)
        {
            double d = PreostaliKilometri - other.PreostaliKilometri;
            if (d < 0)
                return -1;
            if (d > 0)
                return 1;
            return 0;
        }

        public void Crpalka()
        {
            gorivo = kapaciteta;
        }
        public bool Prevozi(double km)
        {
            double rabi = poraba * km / 100;
            if (rabi > gorivo)
            {
                gorivo = 0;
                return false;
            }
            else
            {
                gorivo -= rabi;
                return true;
            }
        }
        static void UrediPoDosegu(List<Vozilo> vozila)
        {
            vozila.Sort();
        }
    }
    
}
