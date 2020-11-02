using System;
using System.Collections.Generic;

namespace TestApp
{
    class Tickets : ITask
    {
        public string Run(string[] data)
        {
            var digits = Convert.ToInt32(data[0]) * 2;
            var count = 0;

            var n = Convert.ToInt32(Math.Pow(10, digits) / 2);

            for (var i = 1; i <= n; i++)
            {
                var t = new List<int>() { n - i, n + i };
                t.ForEach(value =>
                {
                    var a = Math.Floor(value / Math.Pow(10, digits / 2));
                    var b = value % Math.Pow(10, digits / 2);
                    //Console.WriteLine($"{a} {b}");
                    if (calcSum(a) == calcSum(b)) count++;
                });
            }
            return count.ToString();
        }

        private int calcSum(double value)
        {
            double result = 0;
            while (value > 0)
            {
                result += value % 10;
                value = value / 10;
            }
            return Convert.ToInt32(result);
        }
    }
}
