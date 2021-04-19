using System.Collections.Generic;

namespace TestApp.Deikstra
{
    public class Graph
    {
        public List<Vertex> Vertices { get; }
        public Graph()
        {
            Vertices = new List<Vertex>();
        }
        public void AddVertex()
        {
            Vertices.Add(new Vertex());
        }

        public void AddEdge(int vIndex1, int vIndex2, int weight)
        {
            Vertices[vIndex1].AddEdge(Vertices[vIndex2], weight);
            Vertices[vIndex2].AddEdge(Vertices[vIndex1], weight);
        }

    }
}