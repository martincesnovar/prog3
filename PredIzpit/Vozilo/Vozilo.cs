using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vozilo
{
    class Vozilo
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
        public double PreostaliKilometri { get { return gorivo-poraba; } }
        public void Crpalka()
        {
            gorivo = kapaciteta;
        }
    }
    
}
