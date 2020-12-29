namespace TestApp.Arrays.Test
{
    public class GetFromEnd : ITask
    {
        private IDynamicArray<int> array;
        public GetFromEnd(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Getting from end"; }
        public string Run(string[] data)
        {
            for (int j = 99999; j > (-1); j--)
            {
                var a = array.Get(j);
            }
            return "Ok";
        }
    }
}
