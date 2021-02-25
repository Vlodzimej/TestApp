using System;

namespace TestApp.BST
{
    public class SearchIncrement : ITask
    {
        private Tree tree;
        private ulong n;
        public SearchIncrement(Tree tree)
        {
            this.tree = tree;
        }
        public string Title { get => "Increment searching"; }
        public string Run(string[] data)
        {
            var n = tree.Count;
            var rnd = new Random();
            for (ulong i = 0; i < n / 10; i++)
            {
                tree.SearchNode(i);
            }

            return "Ok";
        }
    }
}