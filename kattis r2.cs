using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.None);
                long a = Int64.Parse(split[0]);
                long b = Int64.Parse(split[1]);
                long rez = 2 * b - a;
                Console.WriteLine(rez);
            }
        }
    }
}
