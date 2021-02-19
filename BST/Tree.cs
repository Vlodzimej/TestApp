using System;

namespace TestApp.BST
{
    public class Tree
    {
        public ulong count = 0;
        Node root;

        public Tree(ulong rootKey)
        {
            InsertNode(rootKey);
        }
        public void InsertNode(ulong key)
        {
            if (count == 0)
            {
                root = new Node(key, null);
                count++;
            }
            else
            {
                insert(root, key);
            }

        }

        public bool SearchNode(ulong key)
        {
            return search(root, key) != null;
        }

        public void RemoveNode(ulong key)
        {
            remove(key);
        }

        public void Walk()
        {
            walk(root);
        }

        private void insert(Node node, ulong key)
        {
            if (key > node.key)
            {
                if (node.R == null)
                {
                    node.R = new Node(key, node);
                    count++;
                }
                else
                {
                    insert(node.R, key);
                }
            }
            else if (key < node.key)
            {
                if (node.L == null)
                {
                    node.L = new Node(key, node);
                    count++;
                }
                else
                {
                    insert(node.L, key);
                }
            }
        }

        private void remove(ulong key)
        {
            var node = search(root, key);
            if (node == null) return;

            /** Нет потомков */
            if (node.L == null && node.R == null)
            {
                if (node.P.L != null && node.P.L.key == key)
                {
                    node.P.L = null;
                }
                if (node.P.R != null && node.P.R.key == key)
                {
                    node.P.R = null;
                }
            }

            /** Только левый потомок */
            if (node.L != null && node.R == null)
            {
                if (node.P.L != null && node.P.L.key == key)
                {
                    node.P.L = node.L;
                }
                if (node.P.R != null && node.P.R.key == key)
                {
                    node.P.R = node.L;
                }
            }

            /** Только правый потомок */
            if (node.R != null && node.L == null)
            {
                if (node.P.L != null && node.P.L.key == key)
                {
                    node.P.L = node.R;
                }
                if (node.P.R != null && node.P.R.key == key)
                {
                    node.P.R = node.R;
                }
            }

            /** Если узел имеет обоих потомков */
            if (node.R != null && node.L != null)
            {
                var swapNode = searchMinimal(node.R);

                node.key = swapNode.key;
                swapNode.key = key;

                swapNode.P.R = null;
            }
        }

        private Node search(Node node, ulong key)
        {
            if (key > node.key && node.R != null)
            {
                return search(node.R, key);
            }
            else if (key < node.key && node.L != null)
            {
                return search(node.L, key);
            }
            else if (key == node.key)
            {
                return node;
            }
            return null;
        }

        private void walk(Node node)
        {
            if (node == null) return;
            walk(node.L);
            Console.WriteLine(node.key);
            walk(node.R);

        }

        private Node searchMinimal(Node node)
        {
            if (node.L != null)
            {
                return searchMinimal(node.L);
            }
            else
            {
                return node;
            }
        }
    }
}