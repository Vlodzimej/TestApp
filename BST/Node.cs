namespace TestApp.BST
{
    public class Node
    {
        public Node L { get; set; }
        public Node R { get; set; }
        public Node P { get; set; }
        public ulong key { get; set; }
        public Node(ulong key, Node parent)
        {
            this.key = key;
            P = parent;
        }
    }
}