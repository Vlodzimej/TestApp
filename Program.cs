﻿using System;
using System.Diagnostics;
using System.Globalization;
using Bits;
using TestApp.Arrays;

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

            // new Tester(new Bitboard("king"), @"0.BITS/1.Bitboard - King/").RunTest();
            // new Tester(new Bitboard("knight"), @"0.BITS/2.Bitboard - Knight/").RunTest();
            // new Tester(new Bitboard("castle"), @"0.BITS/3.Bitboard - Castle/").RunTest();
            // new Tester(new Bitboard("bishop"), @"0.BITS/4.Bitboard - Bishop/").RunTest();
            // new Tester(new Bitboard("queen"), @"0.BITS/5.Bitboard - Queen/").RunTest();

            var test = new SingleArray<string>();
            test.Add("Test 1");
            test.Add("Test 2");
            test.Add("Test 3");
            test.Add("Test 1.1", 1);
            var test2 = test.Get(1);
            var removedItem = test.Remove(3);
        }
    }
}
