namespace TestApp.Deikstra
{
    public class Mark
    {
        public Vertex Vertex { get; set; }

        public bool Visited { get; set; }

        public int TotalWeight { get; set; }

        public Vertex ParentVertex { get; set; }

        public Mark(Vertex vertex)
        {
            Vertex = vertex;
            Visited = false;
            TotalWeight = int.MaxValue;
            ParentVertex = null;
        }
    }
}