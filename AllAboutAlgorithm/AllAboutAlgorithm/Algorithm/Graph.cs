using System;
using System.Collections.Generic;

namespace AllAboutAlgorithm.Algorithm
{
    // Undirected Graph
    public class Graph<T>
    {
        // Here Key -> Current vertex
        // Key's value -> List of adjacent vertices 
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public Graph() { }

        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }
        
        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        public HashSet<T> GetAdjacentVertices(T vertex)
        {
            var vertices = new HashSet<T>();

            if (AdjacencyList.ContainsKey(vertex))
            {
                foreach (var v in AdjacencyList[vertex])
                    vertices.Add(v);
            }

            return vertices;
        }

        public bool IsAdjacent(Tuple<T, T> edge)
        {
            var isAdjacent = false;

            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                // check if any direction the vertices have connection in the given edge 
                if (AdjacencyList[edge.Item1].Contains(edge.Item2) || AdjacencyList[edge.Item2].Contains(edge.Item1))
                    isAdjacent = true;
            }

            return isAdjacent;
        }
    }
}
