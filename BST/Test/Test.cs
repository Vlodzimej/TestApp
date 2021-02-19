using System;

namespace TestApp.BST
{
    public class Test
    {
        private string action;
        private ulong n;

        public Test(string action, ulong n)
        {
            this.action = action;
            this.n = n;
        }
        public void Run()
        {
            var tree = new Tree(n / 2);
            switch (action)
            {
                case "random":
                    new Tester(new BST.InsertRandom(tree, n)).RunTest();
                    break;
                case "increment":
                    new Tester(new BST.InsertIncrement(tree, n)).RunTest();
                    break;
            }
            new Tester(new BST.SearchIncrement(tree)).RunTest();
            new Tester(new BST.SearchRandom(tree)).RunTest();
            new Tester(new BST.RemoveIncrement(tree)).RunTest();
            new Tester(new BST.RemoveRandom(tree)).RunTest();
        }
    }
}