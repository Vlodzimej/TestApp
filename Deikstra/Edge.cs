namespace TestApp.Deikstra
{
    public class Edge
    {
        public Vertex Vertex { get; }
        public int Weight { get; }
        public Edge(Vertex vertex, int weight)
        {
            Vertex = vertex;
            Weight = weight;
        }
    }
}