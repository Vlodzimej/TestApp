using System;

namespace TestApp.BST
{
    public class InsertIncrement : ITask
    {
        private Tree tree;
        private ulong n;
        public InsertIncrement(Tree tree, ulong n)
        {
            this.tree = tree;
            this.n = n;
        }
        public string Title { get => "Increment inserting"; }
        public string Run(string[] data)
        {
            var rnd = new Random();

            for (ulong i = 0; i < n; i++)
            {
                tree.InsertNode(i);
            }

            return "Ok";
        }
    }
}
