using System;

namespace TestApp
{
    public class PowerA : ITask
    {
        public string Title { get => "1a. Итеративный (n умножений"; }
        public string Run(string[] data)
        {
            var a = Convert.ToDouble(data[0]);
            var n = Convert.ToInt64(data[1]);
            double p = 1;

            for (int i = 0; i < n; i++)
            {
                p = p * a;
            }

            return p - Math.Round(p, 0) != 0 ? p.ToString("f11") : p.ToString("f1");
        }
    }
}