using System;
using System.Collections.Generic;

namespace TestApp
{
    class Tickets : ITask
    {
        public string Run(string[] data)
        {
            /* Кол-во знаков */
            var digits = Convert.ToInt32(data[0]) * 2;
            /*  Кол-во совпадений */
            var count = 0;
            /* Значение номера среднего билета */
            var n = Convert.ToInt32(Math.Pow(10, digits) / 2);

            for (var i = 0; i <= n; i++)
            {
                var numbers = new List<int>() { n - i, n + i };
                numbers.ForEach(value =>
                {
                    var a = Math.Floor(value / Math.Pow(10, digits / 2));
                    var b = value % Math.Pow(10, digits / 2);
                    if (calcSum(a) == calcSum(b)) count++;
                });
            }
            return count.ToString();

            // Пример для шестизначных билетов
            // var count = 0;
            // Dictionary<int, int> map = new Dictionary<int, int>();
            // int[] arr = new int[1000];
            // for (int i = 0; i < 1000; i++)
            // {
            //     int key = i % 10 + i / 10 % 10 + i / 100;
            //     map[key] = map.GetValueOrDefault(key) + 1;
            //     arr[i] = key;
            // }
            // for (int k = 0; k < 1000; k++)
            // {
            //     count = count + map.GetValueOrDefault(arr[k]);
            // }
            // return count.ToString();
        }

        private double calcSum(double value)
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
