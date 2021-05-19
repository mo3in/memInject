using System;

namespace ConsoleApp1
{
    class Program
    {
        public static int Data = -1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter cs:");
                Data = int.Parse(Console.ReadLine() ?? "-1");
                Console.WriteLine("tnx, w8 please");
                Console.ReadKey();
                Console.WriteLine($"last data: [{Data}]");
            }
        }
    }
}