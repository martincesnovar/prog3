using System;

namespace Boris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Masa v regiji A: ");
            double masaA = double.Parse(Console.ReadLine());
            Console.Write("Masa v regiji B: ");
            double masaB = double.Parse(Console.ReadLine());
            int korak = 0;
            double iz_a_v_b;
            double iz_b_v_a;
            while ((masaA + masaB) > 0.001)
            {
                iz_a_v_b = masaA * 0.22;
                iz_b_v_a = masaB * 0.22;
                masaA = masaA * 0.12;
                masaA = masaA + iz_b_v_a;
                masaB = masaB * 0.12;
                masaB = masaB + iz_a_v_b;
                Console.WriteLine(String.Format("Korak {0} Masa A {1} Masa B {2}", korak,masaA, masaB));
                korak++;
                //Console.Write(korak);
                //Console.Write(' ');
                //Console.Write(masaA);
                //Console.Write(' ');
                //Console.Write(masaB);
                //Console.WriteLine();

            }

        }
    }
}

/*
 # Določimo število tednov, ko se ustrezno zmanjša začetna porazdelitev bakterij
masaA = float(input('Masa v regiji A: '))
masaB = float(input('Masa v regiji B: '))
korak = 0
iz_a_v_b = 0
iz_b_v_a = 0
while masaA + masaB >0.001:
    iz_a_v_b = masaA*0.22
    iz_b_v_a = masaB *0.22
    masaA = masaA * 0.12  # toliko jih ostane
    masaA = masaA + iz_b_v_a 
    masaB = masaB * 0.12
    masaB = masaB + iz_a_v_b 
    print(korak, masaA, masaB)
    korak += 1 
# NEKAJ JE NAROBE. NIČ SE NE IZPIŠE
# PA TUDI, KO SE IGRAM Z MASAMI "peš", SE IZRAČUNAJO NAROBE
     */
