namespace TestApp.Arrays.Test
{
    public class GetFromStart : ITask
    {
        private IDynamicArray<int> array;
        public GetFromStart(IDynamicArray<int> array)
        {
            this.array = array;
        }
        public string Title { get => "Getting from start"; }
        public string Run(string[] data)
        {
            for (int j = 0; j < 100000; j++)
            {
                var a = array.Get(j);
            }
            return "Ok";
        }
    }
}
