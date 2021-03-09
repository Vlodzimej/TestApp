using System.Linq;

namespace TestApp
{
    public class Kosarayu
    {
        public Kosarayu()
        {
            string graph = "206701900090450805600";
            int[,] a = GetGraph(graph);

        }
        private static int[,] GetGraph(string graph)
        {
            int n = graph.Count(x => x == '0');
 
            int[,] result = new int[n, n];
            int row = 0;
            foreach (char c in graph)
            {
                if (c == '0')
                    row++;
                else
                    result[row, c - '1'] = 1;
            }
            return result;
        }

        public void Test() {
            
        }
    }
}