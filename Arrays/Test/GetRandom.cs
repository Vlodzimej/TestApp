using System;

namespace TestApp.Arrays
{
    public class GetRandom : ITask
    {
        private IDynamicArray<int> array;
        public GetRandom(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Getting random"; }
        public string Run(string[] data)
        {
            var rnd = new Random();
            for (int j = 0; j < 100000; j++)
            {
                int index = rnd.Next(0, 100000);
                var a = array.Get(index);
            }
            return "Ok";
        }
    }
}
