using System;

namespace TestApp
{
    public class PrimesA : ITask
    {
        public string Title { get => "2a. Итеративный (n умножений)"; }
        public string Run(string[] data)
        {
            var n = Convert.ToInt64(data[0]);
            int count = 0;

            for (int p = 2; p <= n; p++)
            {
                if (IsPrime(p))
                {
                    count++;
                }
            }
            return count.ToString();
        }

        private bool IsPrime(int p)
        {
            int q = 0;
            for (int i = 1; i <= p; i++)
            {
                if (p % i == 0)
                {
                    q++;
                }
            }
            return q == 2;
        }
    }
}