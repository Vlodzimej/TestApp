using System;
using System.Diagnostics;
using System.Globalization;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            // new Tester(new StringLength(), @"0.String/").RunTest();
            // new Tester(new Tickets(), @"1.Tickets/").RunTest();

            //new Tester(new PowerA(), @"3.Power/").RunTest();
            // new Tester(new PowerB(), @"3.Power/").RunTest();
            // new Tester(new PowerC(), @"3.Power/").RunTest();

            // new Tester(new FibonacciA(), @"4.Fibo/").RunTest();
            // new Tester(new FibonacciB(), @"4.Fibo/").RunTest();
            // new Tester(new FibonacciС(), @"4.Fibo/").RunTest();
            // new Tester(new FibonacciD(), @"4.Fibo/").RunTest();

            // new Tester(new PrimesA(), @"5.Primes/").RunTest();
            // new Tester(new PrimesB(), @"5.Primes/").RunTest();
            // new Tester(new PrimesBa(), @"5.Primes/").RunTest();
            // new Tester(new PrimesC(), @"5.Primes/").RunTest();

            new Tester(new Bitboard(), @"0.BITS/1.Bitboard - Король/").RunTest();
        }
    }
}
