using AllAboutAlgorithm.Algorithm;
using System;

namespace AllAboutAlgorithm.Clients
{
    public class GraphClient
    {
        public static void Client()
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var edges = new[]
            {
                Tuple.Create(1,2), Tuple.Create(1,3), Tuple.Create(2,4),
                Tuple.Create(3,5), Tuple.Create(3,6), Tuple.Create(4,7),
                Tuple.Create(5,7), Tuple.Create(5,8), Tuple.Create(5,6),
                Tuple.Create(8,9), Tuple.Create(9,10), Tuple.Create(8,10),
            };

            // Create graph
            var graph = new Graph<int>(vertices, edges);

            // Test graph
            var items = new Tuple<int, int>(8, 9);

            if (graph.IsAdjacent(items))
            {
                var results = "";
                var adjacentVertices = graph.GetAdjacentVertices(items.Item1);
                Console.WriteLine("Adjacent vertices of " + items.Item1 + " are: ");

                foreach (var v in adjacentVertices)
                {
                    results += v + " ";
                }
                Console.WriteLine(results);

                results = "";
                adjacentVertices = graph.GetAdjacentVertices(items.Item2);
                Console.WriteLine("Adjacent vertices of " + items.Item2 + " are: ");

                foreach (var v in adjacentVertices)
                {
                    results += v + " ";
                }
                Console.WriteLine(results);
            }
            else
            {
                Console.WriteLine(items.Item1 + " and " + items.Item2 + " are not adjacent!");
            }
        }
    }
}
