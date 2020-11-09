using System;
using System.Diagnostics;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Tester(new StringLength(), @"0.String/").RunTest();
            //new Tester(new Tickets(), @"1.Tickets/").RunTest();

            //new Tester(new PowerA(), @"3.Power/").RunTest();
            //new Tester(new PowerB(), @"3.Power/").RunTest();
            //new Tester(new PowerC(), @"3.Power/").RunTest();

            //new Tester(new FibonacciA(), @"4.Fibo/").RunTest();
            //new Tester(new FibonacciB(), @"4.Fibo/").RunTest();
            //new Tester(new FibonacciС(), @"4.Fibo/").RunTest();
            new Tester(new FibonacciD(), @"4.Fibo/").RunTest();
        }
    }
}
