using System;

namespace TestApp
{
    public class SelectionSort : ITask
    {
        public string Title { get => "Selection sort"; }
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
                long min = arr[i];
                long? minIndex = null;

                for (long j = i + 1; j < n; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }
                if (minIndex != null)
                {
                    arr[minIndex.Value] = arr[i];
                    arr[i] = min;
                }
            }
            return arr;
        }
    }
}