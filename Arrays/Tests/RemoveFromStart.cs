namespace TestApp.Arrays.Test
{
    public class RemoveFromStart : ITask
    {
        private IDynamicArray<int> array;
        public RemoveFromStart(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Removing from start"; }
        public string Run(string[] data)
        {
            for (int j = 0; j < 100000; j++)
            {
                array.Remove(0);
            }
            return "Ok";
        }
    }
}
