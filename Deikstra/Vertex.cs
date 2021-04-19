using System.Collections.Generic;

namespace TestApp.Deikstra
{
    public class Vertex
    {
        public List<Edge> Edges { get; }

        public Vertex()
        {
            Edges = new List<Edge>();
        }

        public void AddEdge(Edge newEdge)
        {
            Edges.Add(newEdge);
        }

        public void AddEdge(Vertex vertex, int edgeWeight)
        {
            AddEdge(new Edge(vertex, edgeWeight));
        }
    }
}