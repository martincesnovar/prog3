using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga4
{
    class Program
    {
        /// <summary>
        /// Reši nalogo 4 - brisanje praznih datotek in map.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string potDoMape = @"..\..\..\TestPrazne - Copy";
            PobrisiDatoteke(potDoMape);
            PobrisiMape(potDoMape);
        }

        /// <summary>
        /// Pobriše prazne datoteke v dani mapi in vseh njenih podmapah.
        /// </summary>
        /// <param name="pot">pot do izbrane mape</param>
        static void PobrisiDatoteke(string pot)
        {
            DirectoryInfo di = new DirectoryInfo(pot);
            FileInfo[] datoteke = di.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo datoteka in datoteke)
            {
                if (datoteka.Length == 0) File.Delete(datoteka.FullName);
            }
        }

        /// <summary>
        /// Pobriše vse prazne podmape v dani mapi.
        /// </summary>
        /// <param name="pot">pot do izbrane mape</param>
        static void PobrisiMape(string pot)
        {
            DirectoryInfo di = new DirectoryInfo(pot);
            DirectoryInfo[] mape = di.GetDirectories("*", SearchOption.AllDirectories);
            int zacetnaVelikost = mape.Length;
            int koncnaVelikost = 0;
            // Ko pobrišemo prazne mape se lahko pojavijo nove - ponavljamo dokler se število map spreminja
            while (zacetnaVelikost > koncnaVelikost)
            {
                zacetnaVelikost = mape.Length;
                foreach (DirectoryInfo mapa in mape)
                {
                    string[] datoteke = Directory.GetFiles(mapa.FullName);
                    string[] podmape = Directory.GetDirectories(mapa.FullName);

                    if (datoteke.Length + podmape.Length == 0)
                    {
                        Directory.Delete(mapa.FullName);
                    }
                }
                mape = di.GetDirectories("*", SearchOption.AllDirectories);
                koncnaVelikost = mape.Length;
            }
        }
    }
}
