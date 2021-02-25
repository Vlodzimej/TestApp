using System;

namespace TestApp.BST
{
    public class InsertRandom : ITask
    {
        private Tree tree;
        private ulong n;
        public InsertRandom(Tree tree, ulong n)
        {
            this.tree = tree;
            this.n = n;
        }
        public string Title { get => "Random inserting"; }
        public string Run(string[] data)
        {
            var rnd = new Random();

            while (tree.Count < n)
            {
                var numb = (ulong)(rnd.Next((Int32)n) + (rnd.Next((Int32)n)));
                tree.InsertNode(numb);
            }

            return "Ok";
        }
    }
}
