using System;

namespace TestApp
{
    public class Power : ITask
    {
        public string Run(string[] data)
        {
            var a = Convert.ToDouble(data[0]);
            var n = Convert.ToInt64(data[1]);
            double result = 1;

            for (int i = 0; i < n; i++)
            {
                result = result * a;
            }

            return result - Math.Round(result, 0) != 0 ? Math.Round(result, 11).ToString() : result.ToString("f1");
        }
    }
}