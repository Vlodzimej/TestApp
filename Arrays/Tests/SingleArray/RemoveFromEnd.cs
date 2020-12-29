namespace TestApp.Arrays.Test
{
    public class RemoveFromEnd : ITask
    {
        private IDynamicArray<int> array;
        public RemoveFromEnd(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Removing from end"; }
        public string Run(string[] data)
        {
            for (int j = 99999; j > (-1); j--)
            {
                array.Remove(j);
            }
            return "Ok";
        }
    }
}
