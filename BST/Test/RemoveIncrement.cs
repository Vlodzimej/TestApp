using System;

namespace TestApp.BST
{
    public class RemoveIncrement : ITask
    {
        private Tree tree;
        public RemoveIncrement(Tree tree)
        {
            this.tree = tree;
        }
        public string Title { get => "Random removing"; }
        public string Run(string[] data)
        {
            var n = tree.count;
            var rnd = new Random();
            for (ulong i = 0; i < n / 10; i++)
            {
                tree.RemoveNode(i);
            }

            return "Ok";
        }
    }
}
