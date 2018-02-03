using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album
{
    class Album
    {
        static Random rng;

        /// <summary>
        /// Reši nalogo Album. Uporabnik izbere velikost albuma, velikost enega paketa in število simulacij.
        /// Izpiše povprečno, maksimalno in minimalno število sličic, ki jih kupimo preden je album poln.
        /// Poleg tega izpiše čas, potreben za izvedbo simulacije.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Vnesi velikost albuma: ");
            int velikostAlbuma = int.Parse(Console.ReadLine());
            Console.Write("Vnesi velikost paketa sličic: ");
            int velikostPaketa = int.Parse(Console.ReadLine());
            Console.Write("Vnesi število simulacij polnjenja: ");
            int stSimulacij = int.Parse(Console.ReadLine());

            rng = new Random();

            var ura = new System.Diagnostics.Stopwatch();
            int max = 0;                // največ kupljenih sličic za zapolnjen album
            int min = Int32.MaxValue;   // najmanj kupljenih sličic za zapolnjen album
            int skupnoKupljenih = 0;    // skupno število kupljenih sličic
            int kupljenih;

            ura.Start();
            for (int i = 0; i < stSimulacij; i++) // simuliramo polnjenja albuma
            {
                kupljenih = NapolniAlbum(velikostAlbuma, velikostPaketa);
                max = Math.Max(kupljenih, max);
                min = Math.Min(kupljenih, min);
                skupnoKupljenih += kupljenih;
            }
            ura.Stop();
            int povprecje = skupnoKupljenih / stSimulacij;
            Console.WriteLine("Povprečno število sličič, ki jih je potrebno kupiti, da zapolnimo album je " + povprecje + ".");
            Console.WriteLine("Najmanjše število sličič, ki jih je potrebno kupiti, da zapolnimo album je " + min + ".");
            Console.WriteLine("Največje število sličič, ki jih je potrebno kupiti, da zapolnimo album je " + max + ".");
            Console.WriteLine("Čas porabljen za simulacijo (v ms): " + ura.ElapsedMilliseconds);
            Console.ReadLine();
        }

        /// <summary>
        /// Generira paket različnih sličic izbrane veikosti. Za vsak element paketa generira naključna števila,
        /// dokler ni generirano število, ki še ni v paketu. 
        /// Sličice so predstavljene s števili od 0 do (velikostAlbuma - 1). Število -1 predstavlja še prazno mesto v paketu.
        /// </summary>
        /// <param name="velikostAlbuma">Število razičnih sličic, ki se lahko pojavijo v paketu</param>
        /// <param name="velikostPaketa">Število sličic v paketu</param>
        /// <returns>Paket različnih sličic</returns>
        static int[] PaketSlicic1(int velikostAlbuma, int velikostPaketa)
        {
            int[] paket = new int[velikostPaketa];
            for (int i = 0; i < velikostPaketa; i++)
            {
                paket[i] = -1;
            }

            for (int i=0; i<velikostPaketa; i++)
            {
                int novaSlicica = rng.Next(velikostAlbuma);
                while (paket.Contains(novaSlicica))
                {
                    novaSlicica = rng.Next(velikostAlbuma);
                }
                paket[i] = novaSlicica;
            }
            return paket;
        }

        /// <summary>
        /// Generira paket različnih sličic izbrane velikosti. Paket napolni tako, da shranjuje
        /// naključna števila v množico, dokler ni njena velikost enaka velikosti paketa.
        /// Sličice so predstavljene s števili od 0 do (velikostAlbuma - 1).
        /// </summary>
        /// <param name="velikostAlbuma">Število različnih sličic, ki se lahko pojavijo v paketu</param>
        /// <param name="velikostPaketa">Število sličic v paketu</param>
        /// <returns>Paket različnih sličic</returns>
        static int[] PaketSlicic2(int velikostAlbuma, int velikostPaketa)
        {
            HashSet<int> izbrane = new HashSet<int>();
            while (izbrane.Count < velikostPaketa)
            {
                izbrane.Add(rng.Next(velikostAlbuma));
            }
            return izbrane.ToArray();
        }

        /// <summary>
        /// Generira paket različnih sličic izbrane velikosti. Sličice so predstavljene s števili od 0 do (velikostAlbuma - 1).
        /// Najprej generira seznam števil od 0 do (velikostAlbuma - 1), ga naključno premeša, in nabere prvih nekaj števil v paket.
        /// </summary>
        /// <param name="velikostAlbuma">Število različnih sličic, ki se lahko pojavijo v paketu</param>
        /// <param name="velikostPaketa">Število sličic v paketu</param>
        /// <returns>Paket različnih sličic</returns>
        static int[] PaketSlicic3(int velikostAlbuma, int velikostPaketa)
        {
            var slicice = Enumerable.Range(0, velikostAlbuma);
            var premesaneSlicice = slicice.OrderBy(x => rng.Next());
            var izbrane = premesaneSlicice.Take(velikostPaketa);
            int[] paket = izbrane.ToArray();
            return paket;

            // Krajše:
            // return Enumerable.Range(0,velikostAlbuma).OrderBy(x => rng.Next()).Take(velikostPaketa).ToArray();
        }

        /// <summary>
        /// Generira paket različnih sličic izbrane vleikosti. Sličice so predstavljene s števili od 0 do (velikostAlbuma - 1).
        /// Najprej generira seznam števil od 0 do (velikostAlbuma - 1), nato pa po vrsti zamenja prvih velikostPaketa števil z 
        /// naključnimi. Vrne prvih velikostPaketa števil v seznamu.
        /// </summary>
        /// <param name="velikostAlbuma">Število različnih sličic, ki se lahko pojavijo v paketu</param>
        /// <param name="velikostPaketa">Število sličic v paketu</param>
        /// <returns>Paket različnih sličic</returns>
        static int[] PaketSlicic4(int velikostAlbuma, int velikostPaketa)
        {
            int[] slicice = Enumerable.Range(0, velikostAlbuma).ToArray();
            int temp;
            int chosen;
            for (int i=0; i < velikostPaketa; i++)
            {
                chosen = rng.Next(i, velikostAlbuma);
                temp = slicice[i];
                slicice[i] = slicice[chosen];
                slicice[chosen] = temp;
            }

            return slicice.Take(velikostPaketa).ToArray();

        }

        /// <summary>
        /// Simulacija polnjenja albuma izbrane velikosti z izbranim številom sličic v paketih.
        /// Sličice so predstavljene s števili od 0 do (velikostAlbuma - 1).
        /// </summary>
        /// <param name="velikostAlbuma">Število sličic v albumu</param>
        /// <param name="velikostPaketa">Število sličic v vsakem paketu</param>
        /// <returns>Število sličic, ki smo jih kupili, da smo napolnili album</returns>
        static int NapolniAlbum(int velikostAlbuma, int velikostPaketa)
        {
            bool[] kupljene = new bool[velikostAlbuma];
            int manjkajocih = velikostAlbuma;
            int kupljenih = 0;

            while (manjkajocih > 0)
            {
                int[] paket = PaketSlicic4(velikostAlbuma, velikostPaketa);
                kupljenih += velikostPaketa;
                foreach (int i in paket)
                {
                    if (!kupljene[i])
                    {
                        kupljene[i] = true;
                        manjkajocih -= 1;
                    }
                }
            }
            return kupljenih;
        }
    }
}
