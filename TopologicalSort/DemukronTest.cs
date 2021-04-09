using System.Collections.Generic;
using System.Linq;
using TestApp.Arrays;

namespace TestApp.TopologicalSort
{
    public class DemukronTest
    {
        Graph graph;
        int[] columnSums;
        List<int> v;

        public DemukronTest()
        {
            graph = new Graph();
            columnSums = new int[graph.size];
            v = new List<int>();

            var level = Run();
        }

        public int[][] Run()
        {
            List<List<int>> level = new List<List<int>>();
            
            for (var i = 0; i < graph.size; i++)
            {
                columnSums[i] = getSumColumn(i);
                v.Add(i);
            }

            while (v.Count > 0)
            {
                level.Add(new List<int>());
                var zero = new List<int>();


                foreach (var u in v)
                {
                    if (columnSums[u] == 0)
                    {
                        zero.Add(u);
                    }
                }

                if (zero.Count == 0)
                {
                    break;
                }

                foreach (var u in zero)
                {
                    level.Last().Add(u);
                    v.Remove(u);
                    calcColumnSums(u);
                }
            }

            int[][] result = new int[level.Count][];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = level.ElementAt(i).ToArray();
            }

            return result;
        }

        private int getSumColumn(int x)
        {
            int sum = 0;

            for (var y = 0; y < graph.size; y++)
            {
                sum += graph.vertexMatrix[x, y];
            }

            return sum;
        }

        private void calcColumnSums(int y)
        {
            foreach (var x in v)
            {
                columnSums[x] -= graph.vertexMatrix[x, y];
            }
        }
    }
}