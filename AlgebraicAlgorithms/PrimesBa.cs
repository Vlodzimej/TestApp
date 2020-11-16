using System;
using System.Collections.Generic;

namespace TestApp
{
    public class PrimesBa  : ITask
    {
        List<int> pArray;
        public string Title { get => "3a. Через перебор делителей. Массив"; }
        public string Run(string[] data)
        {
            var n = Convert.ToInt64(data[0]);
            int count = 0;

            this.pArray = new List<int>();

            for (int p = 2; p <= n; p++)
            {
                if (IsPrime(p))
                {
                    pArray.Add(p);
                    count++;
                }
            }
            return count.ToString();
        }

        private bool IsPrime(int p)
        {
            if (this.pArray.Contains(p) || p == 2) return true;
            if (p % 2 == 0) return false;
            int sqrt = (int)Math.Sqrt(p);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (p % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}