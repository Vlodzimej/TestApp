using System;
namespace TestApp.Arrays
{
    public static class Test
    {
        public static void Run()
        {

            TestArray<MatrixList<int>>();
        }

        static void TestArray<T>() where T : IDynamicArray<int>, new()
        {
            Console.WriteLine($"{typeof(T)}");
            T[] array = { new T(), new T(), new T() };

            new Tester(new Arrays.AddToEnd(array[0])).RunTest();
            new Tester(new Arrays.AddToStart(array[1])).RunTest();
            new Tester(new Arrays.AddRandom(array[2])).RunTest();

            new Tester(new Arrays.GetFromStart(array[0])).RunTest();
            new Tester(new Arrays.GetFromEnd(array[1])).RunTest();
            new Tester(new Arrays.GetRandom(array[2])).RunTest();

            new Tester(new Arrays.RemoveFromEnd(array[1])).RunTest();
            new Tester(new Arrays.RemoveFromStart(array[0])).RunTest();
            new Tester(new Arrays.RemoveRandom(array[2])).RunTest();
        }


    }
}