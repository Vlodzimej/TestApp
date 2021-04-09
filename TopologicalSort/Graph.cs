using System;

namespace TestApp.TopologicalSort
{
    public class Graph
    {
        public int[,] vertexMatrix;
        public int size;
        public Graph()
        {
            size = 14;
            vertexMatrix = new int[size, size];

            Console.Write(" n | ");
            for (var x = 0; x < size; x++)
            {
                var value = x < 10 ? $" {x}" : $"{x}";
                Console.Write(value);
            }
            Console.WriteLine();
            for (var x = 0; x < size; x++)
            {
                Console.Write($"---");
            }
            Console.WriteLine();


            for (var y = 0; y < size; y++)
            {
                var value = y < 10 ? $" 0{y}" : $" {y}";

                Console.Write(value + " | ");
                for (var x = 0; x < size; x++)
                {
                    var adjacency = new Random().Next(0, 10);
                    vertexMatrix[x, y] = x != y && adjacency > 8 ? 1 : 0;
                    Console.Write($"{vertexMatrix[x, y]} ");
                }
                Console.WriteLine();
            }
        }
    }
}