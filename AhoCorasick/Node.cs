using System.Collections.Generic;

namespace TestApp
{
    public class Node
    {
        public Dictionary<int, int> nextNode;
        public int patternIndex;
        public bool isTerminal;
        public int? suffixLink;
        public int? terminalLink;
        public Dictionary<int, int> moves;
        public int parentIndex;
        public char edgeKey;
        public Node(bool isTerminal = false)
        {
            this.isTerminal = isTerminal;
            this.nextNode = new Dictionary<int, int>();
            this.moves = new Dictionary<int, int>();
            this.suffixLink = null;
        }
    }
}