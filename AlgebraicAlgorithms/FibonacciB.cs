using System;

namespace TestApp
{
    public class FibonacciB : ITask
    {
        public string Title { get => "2b. Через итерацию"; }
        public string Run(string[] data)
        {
            var n = Convert.ToInt32(data[0]);
            long a = 0;
            long b = 1;

            for(int i = 0; i < n;i++) {
                var c = b;
                b = a + b;
                a = c;
            }
      
            return a.ToString();
        }
    }
}