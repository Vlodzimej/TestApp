using System.Collections.Generic;
using System.Linq;
using TestApp.Arrays;

namespace TestApp.TopologicalSort
{
    public class DemukronTest
    {
        Graph graph;
        int[] columnSums;
        VectorArray<int> v;
        VectorArray<VectorArray<int>> level;
        public DemukronTest()
        {
            graph = new Graph();
            columnSums = new int[graph.size];
            v = new VectorArray<int>();
            level = new VectorArray<VectorArray<int>>();

            Run();
        }

        public void Run()
        {
            var l = 0;
            for (var i = 0; i < graph.size; i++)
            {
                columnSums[i] = getSumColumn(i);
                v.Add(i);
            }

            while (v.Size() > 0)
            {
                level.Add(new VectorArray<int>());
                var zero = new VectorArray<int>();


                for (var i = 0; i < v.Size(); i++)
                {
                    var u = v.Get(i);

                    if (columnSums[u] == 0)
                    {
                        zero.Add(u);
                    }
                }

                if (zero.Size() == 0)
                {
                    break;
                }

                for (var u = 0; u < zero.Size(); u++)
                {
                    level.GetLast().Add(u);
                    v.RemoveByValue(u);
                    calcColumnSums(u);
                }
                l++;
            }
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

        private void calcColumnSums(int x)
        {
            for (var i = 0; i < v.Size(); i++)
            {
                var y = v.Get(i);
                columnSums[y] -= graph.vertexMatrix[x, y];
            }
        }
    }
}