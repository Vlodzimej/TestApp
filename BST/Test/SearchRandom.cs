using System;

namespace TestApp.BST
{
    public class SearchRandom : ITask
    {
        private Tree tree;
        private ulong n;
        public SearchRandom(Tree tree)
        {
            this.tree = tree;
        }
        public string Title { get => "Random searching"; }
        public string Run(string[] data)
        {
            var n = tree.count;
            var rnd = new Random();
            for (ulong i = 0; i < n / 10; i++)
            {
                var numb = (ulong)(rnd.Next((Int32)n) + (rnd.Next((Int32)n)));
                tree.SearchNode(numb);
            }

            return "Ok";
        }
    }
}