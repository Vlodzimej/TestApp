using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Tester(new StringLength(), @"0.String/").RunTest();
            new Tester(new Tickets(), @"1.Tickets/").RunTest();

            Console.ReadKey();
        }
    }
}

