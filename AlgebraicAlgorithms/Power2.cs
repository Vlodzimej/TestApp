using System;

namespace TestApp
{
    public class Power2 : ITask
    {
        public string Run(string[] data)
        {
            var a = Convert.ToDouble(data[0]);
            var n = Convert.ToInt64(data[1]);
            double result = 1;

            int count = 0;
            double i = a;

            do
            {
                i = i * i;
                count += 2;
            } while (count + 2 < n);

            return result - Math.Round(result, 0) != 0 ? Math.Round(result, 11).ToString() : result.ToString("f1");
        }
    }
}