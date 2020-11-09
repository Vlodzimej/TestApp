using System;

namespace TestApp
{
    public class PowerB : ITask
    {
        public string Title { get => "2b. Через степень двойки с домножением"; }
        public string Run(string[] data)
        {
            var a = Convert.ToDouble(data[0]);
            var n = Convert.ToInt64(data[1]);
            var p = a;
            var k = Math.Log(n);
            var pCount = 1;

            if (n == 0)
            {
                p = 1;
            }
            else
            {
                for (int i = 0; i <= k; i++)
                {
                    pCount *= 2;
                    p *= p;
                }

                for (int i = pCount; i < n; i++)
                {
                    p *= a;
                }
            }
            return p - Math.Round(p, 0) != 0 ? p.ToString("f11") : p.ToString("f1");
        }
    }
}
