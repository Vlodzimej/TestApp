using System;
using System.Globalization;
using Bits;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            switch (args[0])
            {
                case "string":
                    new Tester(new StringLength(), @"0.String/").RunTest();
                    break;
                case "tickets":
                    new Tester(new Tickets(), @"1.Tickets/").RunTest();
                    break;
                case "power":
                    new Tester(new PowerA(), @"3.Power/").RunTest();
                    new Tester(new PowerB(), @"3.Power/").RunTest();
                    new Tester(new PowerC(), @"3.Power/").RunTest();
                    break;
                case "fibonacci":
                    new Tester(new FibonacciA(), @"4.Fibo/").RunTest();
                    new Tester(new FibonacciB(), @"4.Fibo/").RunTest();
                    new Tester(new FibonacciС(), @"4.Fibo/").RunTest();
                    new Tester(new FibonacciD(), @"4.Fibo/").RunTest();
                    break;
                case "primes":
                    new Tester(new PrimesA(), @"5.Primes/").RunTest();
                    new Tester(new PrimesB(), @"5.Primes/").RunTest();
                    new Tester(new PrimesBa(), @"5.Primes/").RunTest();
                    new Tester(new PrimesC(), @"5.Primes/").RunTest();
                    break;
                case "bitboard":
                    new Tester(new Bitboard("king"), @"0.BITS/1.Bitboard - King/").RunTest();
                    new Tester(new Bitboard("knight"), @"0.BITS/2.Bitboard - Knight/").RunTest();
                    new Tester(new Bitboard("castle"), @"0.BITS/3.Bitboard - Castle/").RunTest();
                    new Tester(new Bitboard("bishop"), @"0.BITS/4.Bitboard - Bishop/").RunTest();
                    new Tester(new Bitboard("queen"), @"0.BITS/5.Bitboard - Queen/").RunTest();
                    break;
                case "arrays":
                    Arrays.Test.Run();
                    break;
                case "heapsort":
                    new Tester(new BubbleSort(), @"sorting-tests/0.random/").RunTest();
                    new Tester(new BubbleSort(), @"sorting-tests/1.digits/").RunTest();
                    new Tester(new BubbleSort(), @"sorting-tests/2.sorted/").RunTest();
                    new Tester(new BubbleSort(), @"sorting-tests/3.revers/").RunTest();

                    new Tester(new SelectionSort(), @"sorting-tests/0.random/").RunTest();
                    new Tester(new SelectionSort(), @"sorting-tests/1.digits/").RunTest();
                    new Tester(new SelectionSort(), @"sorting-tests/2.sorted/").RunTest();
                    new Tester(new SelectionSort(), @"sorting-tests/3.revers/").RunTest();

                    new Tester(new InsertionSort(), @"sorting-tests/0.random/").RunTest();
                    new Tester(new InsertionSort(), @"sorting-tests/1.digits/").RunTest();
                    new Tester(new InsertionSort(), @"sorting-tests/2.sorted/").RunTest();
                    new Tester(new InsertionSort(), @"sorting-tests/3.revers/").RunTest();

                    new Tester(new ShellSort(4), @"sorting-tests/0.random/").RunTest();
                    new Tester(new ShellSort(4), @"sorting-tests/1.digits/").RunTest();
                    new Tester(new ShellSort(4), @"sorting-tests/2.sorted/").RunTest();
                    new Tester(new ShellSort(4), @"sorting-tests/3.revers/").RunTest();
                    new Tester(new ShellSort(4), @"sorting-tests/3.revers/").RunTest();

                    new Tester(new ShellSort(8), @"sorting-tests/0.random/").RunTest();
                    new Tester(new ShellSort(8), @"sorting-tests/1.digits/").RunTest();
                    new Tester(new ShellSort(8), @"sorting-tests/2.sorted/").RunTest();
                    new Tester(new ShellSort(8), @"sorting-tests/3.revers/").RunTest();
                    new Tester(new ShellSort(8), @"sorting-tests/3.revers/").RunTest();

                    new Tester(new ShellSort(16), @"sorting-tests/0.random/").RunTest();
                    new Tester(new ShellSort(16), @"sorting-tests/1.digits/").RunTest();
                    new Tester(new ShellSort(16), @"sorting-tests/2.sorted/").RunTest();
                    new Tester(new ShellSort(16), @"sorting-tests/3.revers/").RunTest();
                    new Tester(new ShellSort(16), @"sorting-tests/3.revers/").RunTest();

                    new Tester(new HeapSort(), @"sorting-tests/0.random/").RunTest();
                    new Tester(new HeapSort(), @"sorting-tests/1.digits/").RunTest();
                    new Tester(new HeapSort(), @"sorting-tests/2.sorted/").RunTest();
                    new Tester(new HeapSort(), @"sorting-tests/3.revers/").RunTest();
                    break;
                case "countingsort":
                    Merge.Data.CreateFile();
                    new Merge.Sort().Run(null);
                    break;
                case "bst":
                    new BST.Test("random", 15000000).Run();
                    new BST.Test("increment", 100000).Run();
                    break;
                case "kosarayu":
                    var kos = new Kosarayu();
                    break;
                case "boyermoore":
                    new Tester(new BoyerMooreHorspool(), @"ab/").RunTest();
                    break;
                case "ahocorasick":
                    var words = new string[] { "abc", "bcdc", "cccb", "bcdd", "bbbc", };
                    var algo = new AhoCorasick(words);
                    Console.WriteLine(algo.IsStringInBor("bcdd"));
                    algo.Find("abcdcbcddbbbcccbbbcccbb");
                    break;


            }
        }
    }
}
