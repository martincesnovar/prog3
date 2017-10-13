using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Vnesi spodnjo mejo");
            int spodnji = int.Parse(Console.ReadLine());
            Console.Write("Vnesi zgornjo mejo");
            int zgornji = int.Parse(Console.ReadLine());
            int trenutni = spodnji;
            while (trenutni < zgornji)
            {
                //delitelji(trenutni); //TODO
                trenutni++;
            }
        }
    }
}
