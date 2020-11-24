using System;

namespace TestApp
{
    public class FibonacciB : ITask
    {
        public string Title { get => "2b. Через итерацию"; }
        public string Run(string[] data)
        {
            var n = Convert.ToInt64(data[0]);
            ulong a = 0;
            ulong b = 1;

            for(int i = 0; i < n;i++) {
                var c = b;
                b = a + b;
                a = c;
            }
      
            return a.ToString();
        }
    }
}