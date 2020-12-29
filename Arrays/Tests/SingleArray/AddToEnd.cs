namespace TestApp.Arrays.Test
{
    public class AddToEnd : ITask
    {
        private IDynamicArray<int> array;
        public AddToEnd(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Adding to end"; }
        public string Run(string[] data)
        {
            for (int j = 0; j < 100000; j++)
            {
                array.Add(j);
            }
            return "Ok";
        }
    }
}