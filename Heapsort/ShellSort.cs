using System;

namespace TestApp
{
    public class ShellSort : ITask
    {
        private long initialStep;
        public string Title { get => "Shell sort"; }

        public ShellSort(long step = 3)
        {
            this.initialStep = step;
        }
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
            long step = initialStep;
            while (step > 0)
            {
                for (long i = 0; i < n; i++)
                {
                    var j = i;
                    var temp = arr[i];
                    while ((j >= step) && (arr[j - step] > temp))
                    {
                        arr[j] = arr[j - step];
                        j = j - step;
                    }
                    arr[j] = temp;
                }
                if (step / 2 != 0)
                    step = step / 2;
                else if (step == 1)
                    step = 0;
                else
                    step = 1;
            }
            return arr;
        }
    }

}