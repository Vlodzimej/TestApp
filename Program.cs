using System;
using System.Diagnostics;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // new Tester(new StringLength(), @"0.String/").RunTest();
            // new Tester(new Tickets(), @"1.Tickets/").RunTest();

            //new Tester(new Power(), @"3.Power/").RunTest();
            new Tester(new Power2(), @"3.Power/").RunTest();
        }
    }
}
