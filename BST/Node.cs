namespace TestApp.BST
{
    public class Node
    {
        public Node L, R;
        public Node P;
        public ulong key;
        public Node(ulong key, Node parent)
        {
            this.key = key;
            P = parent;
        }
    }
}