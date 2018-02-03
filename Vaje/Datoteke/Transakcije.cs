using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga3
{
    class Program
    {
        /// <summary>
        /// Reši nalogo 3: analiza transakcij v datoteki.
        /// </summary>
        /// <param name="args">Prvi argument je ime datoteke transakcij, drugi pa ime poročila.</param>
        static void Main(string[] args)
        {
            var ura = new System.Diagnostics.Stopwatch();
            string imeVhoda = args[0];
            string imeIzhoda = args[1];
            double prihodki, odhodki;
            List<int> izjeme;

            ura.Start();
            PreglejTransakcije1(imeVhoda, out prihodki, out odhodki, out izjeme);
            ura.Stop();
            Console.WriteLine("Branje po vrsticah traja: " + ura.ElapsedMilliseconds);

            ura.Restart();
            PreglejTransakcije2(imeVhoda, out prihodki, out odhodki, out izjeme);
            ura.Stop();
            Console.WriteLine("Branje cele datoteke naenkrat traja: " + ura.ElapsedMilliseconds);

            NapisiPorocilo(imeIzhoda, prihodki, odhodki, izjeme);
        }

        /// <summary>
        /// Prebere datoteko s transakcijami in vrne skupne prihodke, odhodke ter st. vrstic neprave oblike.
        /// Datoteko s transakcijami bere vrstico po vrstico.
        /// </summary>
        /// <param name="datoteka">Ime datoteke s transakcijami</param>
        /// <param name="prihodki">Skupni prihodki</param>
        /// <param name="odhodki">Skupni odhodki</param>
        /// <param name="izjeme">Številke vrstic, ki niso bile pravega formata</param>
        /// <returns></returns>
        static void PreglejTransakcije1(string datoteka, out double prihodki, out double odhodki, out List<int> izjeme)
        {
            prihodki = 0;
            odhodki = 0;
            izjeme = new List<int>();
            using (StreamReader bralnik = File.OpenText(datoteka))
            {
                int stVrstice = 0;
                while (!bralnik.EndOfStream)
                {
                    string vrstica = bralnik.ReadLine();
                    stVrstice++;
                    // Preverimo, če je prva vrstica pravilne oblike
                    if (stVrstice == 1)
                    {
                        if (!vrstica.Equals("Tip transakcije, Vrednost")) izjeme.Add(stVrstice);
                    }

                    // Prazne vrstice ignoriramo
                    else if (!vrstica.Equals(""))
                    {
                        string[] besede = vrstica.Split(',');

                        // Če po razbitju pri vejici nimamo dveh elementov, vrstica ni prave oblike
                        if (besede.Length != 2)
                        {
                            izjeme.Add(stVrstice);
                            continue;
                        }

                        //Preberemo vrednost transakcije - v primeru napačnega formata shranimo izjemo in gremo na naslednjo vrstico
                        if (!double.TryParse(besede[1], NumberStyles.Number, CultureInfo.InvariantCulture, out double vrednost))
                        {
                            izjeme.Add(stVrstice);
                            continue;
                        }

                        if (besede[0].Equals("Nakup"))
                        {
                            odhodki += vrednost;
                        }
                        else if (besede[0].Equals("Prodaja"))
                        {
                            prihodki += vrednost;
                        }
                        else
                        {
                            // Če tip transakcije ni Nakup ali Prodaja shranimo izjemo
                            izjeme.Add(stVrstice);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Prebere datoteko s transakcijami in vrne skupne prihodke, odhodke ter st. vrstic neprave oblike.
        /// Datoteko prebere naenkrat v celoti.
        /// </summary>
        /// <param name="datoteka">Ime datoteke s transakcijami</param>
        /// <param name="prihodki">Skupni prihodki</param>
        /// <param name="odhodki">Skupni odhodki</param>
        /// <param name="izjeme">Številke vrstic, ki niso bile pravega formata</param>
        /// <returns></returns>
        static void PreglejTransakcije2(string datoteka, out double prihodki, out double odhodki, out List<int> izjeme)
        {
            prihodki = 0;
            odhodki = 0;
            izjeme = new List<int>();
            string[] vrstice;
            using (StreamReader bralnik = File.OpenText(datoteka))
            {
                vrstice = bralnik.ReadToEnd().Split('\n');
            }

            int stVrstice = 0;
            foreach (string vrstica in vrstice)
            {
                stVrstice++;
                // Preverimo, če je prva vrstica pravilne oblike
                if (stVrstice == 1)
                {
                    if (!vrstica.Equals("Tip transakcije, Vrednost\r")) izjeme.Add(stVrstice);
                }

                // Prazne vrstice ignoriramo
                else if (!vrstica.Equals(""))
                {
                    string[] besede = vrstica.Split(',');

                    // Če po razbitju pri vejici nimamo dveh elementov, vrstica ni prave oblike
                    if (besede.Length != 2)
                    {
                        izjeme.Add(stVrstice);
                        continue;
                    }

                    // Preberemo vrednost transakcije - v primeru napačnega formata shranimo izjemo in gremo na naslednjo vrstico
                    if (!double.TryParse(besede[1], NumberStyles.Number, CultureInfo.InvariantCulture, out double vrednost))
                    {
                        izjeme.Add(stVrstice);
                        continue;
                    }

                    if (besede[0].Equals("Nakup"))
                    {
                        odhodki += vrednost;
                    }
                    else if (besede[0].Equals("Prodaja"))
                    {
                        prihodki += vrednost;
                    }
                    else
                    {
                        // Če tip transakcije ni Nakup ali Prodaja shranimo izjemo
                        izjeme.Add(stVrstice);
                    }
                }
            }
        }


        /// <summary>
        /// Napiše poročilo o transakcijah v izbrano datoteko.
        /// Najprej izpiše vrstice z napačnim formatom, nato pa skupne prihodke, odhodke ter dobiček.
        /// </summary>
        /// <param name="datoteka">ime datoteke s poročilom</param>
        /// <param name="prihodki">skupni prihodki</param>
        /// <param name="odhodki">skupni odhodki</param>
        /// <param name="izjeme">številke vrstic nepravilnega formata</param>
        static void NapisiPorocilo(string datoteka, double prihodki, double odhodki, List<int> izjeme)
        {
            using (StreamWriter pisalo = File.CreateText(datoteka))
            {
                pisalo.WriteLine("Izjeme:");
                foreach (int i in izjeme)
                {
                    pisalo.WriteLine("Vrstica " + i + " ni prave oblike.");
                }
                pisalo.WriteLine();
                pisalo.WriteLine("Skupni prihodki: " + prihodki);
                pisalo.WriteLine("Skupni odhodki: " + odhodki);
                pisalo.WriteLine("Dobiček: " + (prihodki - odhodki));
            }
        }
    }
}
