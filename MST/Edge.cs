namespace TestApp.MST
{
    public class Edge
    {
        public int[] Vertices { get; set; }
        public int Weight { get; set; }

        public Edge()
        {
            Vertices = new int[2];
        }
    }
}


