using System;

namespace TestApp.Arrays
{
    public class RemoveRandom : ITask
    {
        private IDynamicArray<int> array;
        public RemoveRandom(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Removing random"; }
        public string Run(string[] data)
        {
            var rnd = new Random();
            for (int j = 0; j < 100000; j++)
            {
                int index = rnd.Next(0, array.Size());
                var a = array.Remove(index);
            }
            return "Ok";
        }
    }
}
