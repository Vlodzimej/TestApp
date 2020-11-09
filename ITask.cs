namespace TestApp
{
    interface ITask
    {
        string Title { get; }
        string Run(string[] data);
    }
}