using System;
using System.Collections.Generic;

namespace TestApp.Deikstra
{
    public class DeikstraTest
    {
        Graph graph;
        List<Mark> marks;

        public DeikstraTest(int[,] pattern)
        {
            var verticesCount = (int)Math.Sqrt(pattern.Length);
            graph = new Graph();

            for (var i = 0; i < verticesCount; i++)
            {
                graph.AddVertex();
            }

            for (var y = 0; y < verticesCount; y++)
            {
                for (var x = y; x < verticesCount; x++)
                {
                    if (pattern[x, y] > 0)
                    {
                        graph.AddEdge(x, y, pattern[x, y]);
                    }
                }
            }
        }

        public int[][] Find(int v1, int v2)
        {
            createMarks();
            var first = marks.Find(item => item.Vertex == graph.Vertices[v1]);

            first.TotalWeight = 0;
            while (true)
            {
                var current = findUnvisitedVertex();
                if (current == null)
                {
                    break;
                }

                setSumToNextVertex(current);
            }

            var result = getPath(graph.Vertices[v1], graph.Vertices[v2]);
            return result;
        }

        private void createMarks()
        {
            marks = new List<Mark>();
            foreach (var v in graph.Vertices)
            {
                marks.Add(new Mark(v));
            }
        }

        private Mark findUnvisitedVertex()
        {
            var minValue = int.MaxValue;
            Mark minVertexMark = null;
            foreach (var i in marks)
            {
                if (!i.Visited && i.TotalWeight < minValue)
                {
                    minVertexMark = i;
                    minValue = i.TotalWeight;
                }
            }
            return minVertexMark;
        }

        private void setSumToNextVertex(Mark mark)
        {
            mark.Visited = true;
            foreach (var e in mark.Vertex.Edges)
            {
                var nextMark = marks.Find(item => item.Vertex == e.Vertex);
                var sum = mark.TotalWeight + e.Weight;
                if (sum < nextMark.TotalWeight)
                {
                    nextMark.TotalWeight = sum;
                    nextMark.ParentVertex = mark.Vertex;
                }
            }
        }

        private int[][] getPath(Vertex startVertex, Vertex endVertex)
        {
            var result = new List<int[]>();
            while (startVertex != endVertex)
            {
                var v2 = graph.Vertices.IndexOf(endVertex);
                endVertex = marks.Find(item => item.Vertex == endVertex).ParentVertex;
                var v1 = graph.Vertices.IndexOf(endVertex);
                result.Add(new int[] { v1, v2 });
            }

            result.Reverse();
            return result.ToArray();
        }
    }

}