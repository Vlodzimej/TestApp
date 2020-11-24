using System;

namespace TestApp
{
    public class FibonacciA : ITask
    {
        public string Title { get => "2a. Через рекурсию"; }
        public string Run(string[] data)
        {
            var n = Convert.ToUInt64(data[0]);
            var result = IncreaseValue(0, 0, n);
            return result.ToString();
        }

        private ulong IncreaseValue(ulong a, ulong b, ulong n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (b == 0)
            {
                return IncreaseValue(0, 1, n);
            }

            if (--n > 0)
            {
                return IncreaseValue(b, a + b, n);
            }
            return b;
        }
    }
}