namespace TestApp.MST
{
    public class Graph
    {
        public Edge[] Edges;
        public int VerticesCount { get; set; }

        public Graph(int verticesCount, int edgesCount)
        {
            VerticesCount = verticesCount;
            Edges = new Edge[edgesCount];
        }
    }
}