using System;

namespace Namakanje
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Vnesi predpisano tezo hlebca: ");
            double tezaPredpis = double.Parse(Console.ReadLine());
            Console.Write("Vnesi stevilo hlebcev v pekarni: ");
            int steviloHlebcev = int.Parse(Console.ReadLine());
            int stevecNapacnih = 0;
            double minTeza = tezaPredpis * 0.8;
            double maxTeza = tezaPredpis * 1.2;
            for (int i = 1; i < steviloHlebcev; i++)
            {
                Console.Write("Vnesi tezo: " + i + ". hlebca ");
                double dejanskaTeza = double.Parse(Console.ReadLine());
                //Če je teža hlebca 20% manjša od predpisa, ga štej med napačne hlebce
                if ((dejanskaTeza < minTeza) || (dejanskaTeza > maxTeza))
                    stevecNapacnih++;
            }
            //računamo ali bo pek pil vodo
            if (stevecNapacnih > steviloHlebcev * 0.15)
                Console.WriteLine("Peka v vodo takoj!!!!");
            else
                Console.WriteLine("Pek ima dobro mero");
            Console.ReadKey();
        }
    }
}
