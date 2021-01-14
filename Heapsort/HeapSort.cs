using System;

namespace TestApp
{
    public class HeapSort : ITask
    {
        public string Title { get => "Heap sort"; }
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
            for (long i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (long i = n - 1; i >= 0; i--)
            {
                var temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
            return arr;
        }
        void heapify(long[] arr, long n, long i)
        {
            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                var swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }
    }

}