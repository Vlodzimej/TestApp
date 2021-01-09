using System;

namespace TestApp.Arrays
{
    public class AddRandom : ITask
    {
        private IDynamicArray<int> array;
        public AddRandom(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Random adding"; }
        public string Run(string[] data)
        {
            var rnd = new Random();

            for (int j = 0; j < 100000; j++)
            {
                int index = rnd.Next(array.Size());
                array.Add(j + 1, index);
            }
            return "Ok";
        }
    }
}
