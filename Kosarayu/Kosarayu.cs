using System.Linq;
using System;

namespace TestApp
{
    public class Kosarayu
    {
        Graph graph;
        public Kosarayu()
        {
            var str = Console.ReadLine();

            if (String.IsNullOrEmpty(str))
            {
                str = "34.03.4.7..3167..";
            }

            graph = new Graph(str);
            graph.Display();
            graph.Search();

        }

        public void DisplayGraph()
        {

        }
    }
}