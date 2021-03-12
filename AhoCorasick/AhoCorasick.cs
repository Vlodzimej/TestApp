using System.Collections.Generic;
using System.Linq;
using System;

namespace TestApp
{
    public class AhoCorasick
    {
        public string[] keywords;
        private List<Node> bor;
        private List<string> patterns;
        public AhoCorasick(string[] keywords)
        {
            this.keywords = keywords;

            bor = new List<Node>();
            bor.Add(new Node());

            patterns = new List<string>();

            foreach (var word in keywords)
            {
                AddTemplate(word);
            }
        }
        //https://habr.com/ru/post/198682/
        public void AddTemplate(string str)
        {
            int currentIndex = 0;
            Node currentNode;

            for (int i = 0; i < str.Length; i++)
            {
                int key = str[i] - 'a';
                currentNode = bor.ElementAt(currentIndex);

                if (!bor.ElementAt(currentIndex).nextNode.ContainsKey(key))
                {
                    bor.Add(new Node());
                    currentNode.nextNode.Add(key, bor.Count() - 1);
                }

                currentIndex = bor.ElementAt(currentIndex).nextNode[key];
            }

            currentNode = bor.ElementAt(currentIndex);
            currentNode.isTerminal = true;
            patterns.Add(str);
            currentNode.patternIndex = patterns.Count() - 1;
        }

        public bool IsStringInBor(string str)
        {
            var index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int key = str[i] - 'a';
                if (!bor.ElementAt(index).nextNode.ContainsKey(key))
                {
                    return false;
                }
                index = bor.ElementAt(index).nextNode.GetValueOrDefault(key);
            }
            return true;
        }

        public void Find(string str)
        {
            var index = 0;
            for (var i = 0; i < str.Length; i++)
            {
                index = getAutoMove(index, str[i] - 'a');
                check(index, i + 1);
            }
        }

        private int getSuffixLink(int index)
        {
            var node = bor.ElementAt(index);
            if (node.suffixLink == null)
            {
                if (index == 0 || node.parentIndex == 0)
                {
                    node.suffixLink = 0;
                }
                else
                {
                    node.suffixLink = getAutoMove(getSuffixLink(node.parentIndex), node.edgeKey);
                }
            }
            return node.suffixLink.Value;
        }


        private int getAutoMove(int index, int key)
        {
            var node = bor.ElementAt(index);
            if (node.moves == null)
            {
                if (node.nextNode.ContainsKey(key))
                {
                    node.moves.Add(key, node.nextNode.GetValueOrDefault(key));
                }
                else
                {
                    if (index == 0)
                    {
                        node.moves.Add(key, 0);
                    }
                    else
                    {
                        node.moves.Add(key, getAutoMove(getSuffixLink(index), key));
                    }
                }
            }
            return node.moves.GetValueOrDefault(key);
        }

        private int getTerminalSuffixLink(int index)
        {
            var currentNode = bor.ElementAt(index);

            if (currentNode.suffixLink == null)
            {
                var i = getTerminalSuffixLink(index);
                if (i == 0)
                {
                    currentNode.terminalLink = 0;
                }
                else
                {
                    currentNode.terminalLink = bor.ElementAt(i).isTerminal ? i : getTerminalSuffixLink(i);
                }
            }
            return currentNode.terminalLink.Value;
        }

        private void check(int v, int i)
        {
            for (int u = v; u != 0; u = getTerminalSuffixLink(u))
            {
                var node = bor.ElementAt(u);
                if (node.isTerminal)
                {
                    Console.WriteLine(patterns.ElementAt(node.patternIndex));
                }
            }
        }
    }
}
