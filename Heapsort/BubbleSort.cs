using System;

namespace TestApp
{
    public class BubbleSort : ITask
    {
        public string Title { get => "Bubble sort"; }
        public string Run(string[] data)
        {
            var n = Convert.ToInt64(data[0]);
            var a = data[1].Split(" ");
            var arr = new long[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt64(a[i]);
            }

            var result = String.Join(" ", Sort(n, arr));
            return result;
        }
        long[] Sort(long n, long[] arr)
        {
            for (long i = 0; i < n; i++)
            {
                for (long j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        long z = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = z;
                    }
                }
            }
            return arr;
        }
    }
}