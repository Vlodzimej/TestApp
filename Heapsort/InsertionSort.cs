using System;

namespace TestApp
{
    public class InsertionSort : ITask
    {
        public string Title { get => "Insertion sort"; }
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
                var x = arr[i];
                var j = i - 1;
                while (j >= 0 && arr[j] > x)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = x;
            }
            return arr;
        }
    }
}