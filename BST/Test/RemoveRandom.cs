using System;

namespace TestApp.BST
{
    public class RemoveRandom : ITask
    {
        private Tree tree;
        private ulong n;
        public RemoveRandom(Tree tree)
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
                var numb = (ulong)(rnd.Next((Int32)n) + (rnd.Next((Int32)n)));
                tree.RemoveNode(numb);
            }

            return "Ok";
        }
    }
}
