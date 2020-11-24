using System;

namespace TestApp
{
    public class PowerC : ITask
    {
        public string Title { get => "1c. Через двоичное разложение показателя степен"; }
        public string Run(string[] data)
        {
            var a = Convert.ToDouble(data[0]);
            var n = Convert.ToInt64(data[1]);
            var p = Math.Round(1.0, 1);

            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    p *= a;
                }
                a *= a;
                n >>= 1;
            }

            return p - Math.Round(p, 0) != 0 ? p.ToString("f11") : p.ToString("f1");
        }
    }
}
