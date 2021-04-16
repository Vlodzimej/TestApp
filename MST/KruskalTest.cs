using System;

namespace TestApp.MST
{
    public class KruskalTest
    {
        Graph graph;
        int[,] DisjointSet { get; set; }
        long[] Edges { get; set; }
        public KruskalTest(int[,] pattern)
        {
            var count = 0;
            foreach (var edge in pattern)
            {
                if (edge > 0)
                {
                    count++;
                }
            }

            var edgesCount = count / 2;
            var verticesCount = Math.Sqrt(pattern.Length);

            graph = new Graph((int)verticesCount, edgesCount);

            count = 0;
            for (var y = 0; y < verticesCount; y++)
            {
                for (var x = y; x < verticesCount; x++)
                {
                    if (pattern[x, y] > 0)
                    {
                        graph.Edges[count++] = new Edge()
                        {
                            Vertices = new int[] { x, y },
                            Weight = pattern[x, y]
                        };
                    }
                }
            }
        }

        public Edge[] Run()
        {
            int verticesCount = graph.VerticesCount;
            Edge[] result = new Edge[verticesCount];
            int i = 0;
            int e = 0;

            Array.Sort(graph.Edges, delegate (Edge a, Edge b)
            {
                return a.Weight.CompareTo(b.Weight);
            });

            int[,] disjointSet = new int[verticesCount, 2];

            for (int v = 0; v < verticesCount; ++v)
            {
                disjointSet[v, 0] = v;
                disjointSet[v, 1] = 0;
            }

            while (e < verticesCount - 1)
            {
                Edge nextEdge = graph.Edges[i++];
                int x = find(disjointSet, nextEdge.Vertices[0]);
                int y = find(disjointSet, nextEdge.Vertices[1]);

                if (x != y)
                {
                    result[e++] = nextEdge;
                    union(disjointSet, x, y);
                }
            }
            return result;
        }

        int find(int[,] disjointSet, int i)
        {
            if (disjointSet[i, 0] != i)
                disjointSet[i, 0] = find(disjointSet, disjointSet[i, 0]);

            return disjointSet[i, 0];
        }

        void union(int[,] disjointSet, int x, int y)
        {
            int xroot = find(disjointSet, x);
            int yroot = find(disjointSet, y);

            if (disjointSet[xroot, 1] < disjointSet[yroot, 1])
                disjointSet[xroot, 0] = yroot;
            else if (disjointSet[xroot, 1] > disjointSet[yroot, 1])
                disjointSet[yroot, 0] = xroot;
            else
            {
                disjointSet[yroot, 0] = xroot;
                ++disjointSet[xroot, 1];
            }
        }
    }
}