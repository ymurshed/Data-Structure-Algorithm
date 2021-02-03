﻿using AllAboutAlgorithm.Algorithm;
using System;
using System.Collections.Generic;

namespace AllAboutAlgorithm.Clients
{
    public class DfsClient
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

            var graph = new Graph<int>(vertices, edges);
            var dfs = new Dfs();

            var path = new List<int>();

            // Tracing DFS path
            Console.WriteLine(string.Join(", ", dfs.ApplyDfs(graph, 1, v => path.Add(v))));
            // 1, 3, 6, 5, 8, 10, 9, 7, 4, 2

            Console.WriteLine(string.Join(", ", path));
            // 1, 3, 6, 5, 8, 10, 9, 7, 4, 2
        }
    }
}
