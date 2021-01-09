namespace TestApp.Arrays
{
    public class AddToStart : ITask
    {
        private IDynamicArray<int> array;
        public AddToStart(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Adding to start"; }
        public string Run(string[] data)
        {
            for (int j = 0; j < 100000; j++)
            {
                array.Add(j + 1, 0);
            }
            return "Ok";
        }
    }
}
