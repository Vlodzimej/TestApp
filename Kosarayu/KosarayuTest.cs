using System.Linq;
using System;
using TestApp.Kosarayu;

namespace TestApp
{
    public class KosarayuTest
    {
        Graph graph;
        public KosarayuTest()
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