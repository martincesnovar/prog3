using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int k;
            Console.Write("Vnesi n ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Vnesi k ");
            k = int.Parse(Console.ReadLine());
            Console.WriteLine(nekaj(n, k));
            Console.ReadKey();

        }

        static int nekaj(int n, int k)
        {
            int vsota = 0;
            int i = 0;
            while (i < n)
            {
                i++;
                vsota = vsota + (int)Math.Pow(i,k);
            }
            return vsota;
        }
    }
}

/*def nekaj(n, k):
    return sum([i**k for i in range(1,n+1)])*/
