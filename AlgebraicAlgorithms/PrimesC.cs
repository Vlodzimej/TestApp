using System;
using System.Linq;

namespace TestApp
{
    public class PrimesC : ITask
    {
        public string Title { get => "3с. Через перебор делителей. Решето Эратосфена"; }
        public string Run(string[] data)
        {
            var n = Convert.ToInt64(data[0]);

            bool[] arr = new bool[n + 1];
            
            arr[0] = true;

            if (arr.Length > 1)
            {
                arr[1] = true;
            }

            for (int i = 2; Math.Pow(i, 2) <= n; i++)
            {
                if (!arr[i])
                {
                    int start = i * i;

                    for (int j = start; j <= n; j += i)
                    {
                        arr[j] = true;
                    }
                }
            }

            return arr.ToList().Count(i => !i).ToString();
        }
    }
}