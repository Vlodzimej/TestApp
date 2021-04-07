using System;
using System.Collections.Generic;

namespace TestApp
{
    public class Graph
    {
        int?[,] gVectors, hVectors;
        bool[] visited;
        List<int> vertexList;
        int?[] connectedComponent;
        int vertexNum;
        int index;
        public Graph(string str)
        {
            var vertex = str.Split('.');
            vertexNum = vertex.Length;
            visited = new bool[vertexNum];
            vertexList = new List<int>();
            connectedComponent = new int?[vertexNum];

            createVectors(vertex);
            createInvertVectors();
        }

        private void createVectors(string[] vertex)
        {
            gVectors = new int?[vertexNum, vertexNum];

            for (var v = 0; v < vertexNum; v++)
            {
                for (var a = 0; a < vertex[v].Length; a++)
                {
                    gVectors[v, a] = Int16.Parse(vertex[v][a].ToString());
                }
            }
        }

        private void createInvertVectors()
        {
            hVectors = new int?[vertexNum, vertexNum];

            for (var v = 0; v < vertexNum; v++)
            {
                for (var vi = 0; vi < vertexNum; vi++)
                {
                    var count = 0;
                    for (var ai = 0; ai < vertexNum; ai++)
                    {
                        if (v == gVectors[vi, ai])
                        {
                            hVectors[v, count] = vi;
                        }
                        count++;
                    }
                }
            }
        }

        public void Display()
        {
            for (var v = 0; v < vertexNum; v++)
            {
                Console.Write($"{v} ");
                for (var a = 0; a < vertexNum; a++)
                {
                    Console.Write($"{gVectors[v, a]} ");
                }
                Console.WriteLine();
            }
        }

        public void Search()
        {

            for (var u = 0; u < vertexNum; u++)
            {
                if (visited[u]) continue;

                DFS1(u);
            }

            index = 0;
            vertexList.Reverse();

            foreach (var u in vertexList)
            {
                if (connectedComponent[u] == null)
                {
                    DFS2(u);
                    index++;
                }
            }
        }

        private void DFS1(int v = 0, int deep = 0)
        {
            var d = deep + 1;
            Console.WriteLine($"{createTabs(d)} DFS({v})");
            visited[v] = true;

            for (var i = 0; i < vertexNum; i++)
            {
                var nextVertex = gVectors[v, i];
                if (nextVertex != null && !visited[nextVertex.Value])
                {
                    DFS1(nextVertex.Value, d);
                }
            }
            vertexList.Add(v);
        }

        private void DFS2(int v)
        {
            connectedComponent[v] = index;

            for (var i = 0; i < vertexNum; i++)
            {
                var u = hVectors[v, i];
                if (u != null && connectedComponent[u.Value] == null)
                {
                    DFS2(u.Value);
                }
            }
        }

        private string createTabs(int num)
        {
            string result = "";
            for (var i = 0; i < num; i++)
            {
                result = result + " ";
            }
            return result;
        }
    }
}