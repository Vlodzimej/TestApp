namespace TestApp
{
    class StringLength : ITask
    {
        public string Title { get => "Кол-во символов"; }
        public string Run(string[] data)
        {
            return data[0].Length.ToString();
        }
    }
}
