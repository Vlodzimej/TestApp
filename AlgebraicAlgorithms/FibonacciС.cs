using System;

namespace TestApp
{
    public class FibonacciС : ITask
    {
        public string Title { get => "4c. По формуле золотого сечения"; }
        public string Run(string[] data)
        {
            var n = Convert.ToInt32(data[0]);
            var f = (Math.Sqrt(5) + 1) / 2;
            var result = Math.Pow(f, n) / Math.Sqrt(5);
            return Math.Round(result).ToString();
        }
    }
}