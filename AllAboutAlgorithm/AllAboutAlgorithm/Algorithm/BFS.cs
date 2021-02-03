using System;
using System.Collections.Generic;

namespace AllAboutAlgorithm.Algorithm
{
    // Use Queue
    public class Bfs 
    {
        #region Description of BFS

        // To make sure the breadth-first search algorithm doesn't re-visit vertices, the visited HashSet keeps track of vertices already visited.
        // A Queue, called queue, keeps track of vertices found but not yet visited. Initially queue contains the starting vertex. 
        // The next vertex is dequeued from queue. If it has already been visited, it is discarded and the next vertex is dequeued from queue. 
        // If it has not been visited, it is added to the set of visited vertices and its unvisited neighbors are added to queue. 
        // This continues until there are no more vertices in queue, and the set of vertices visited is returned. 
        // The set of vertices returned is all the vertices that can be reached from the starting vertex.
        // Since all vertices can be reached by 1, all vertices are visited and returned by breadth-first search. Although the HashSet in C# doesn't guarantee an order, the order returned appears to be the exact path followed by breadth-first-search.
        // Notice that breadth-first search cautiously checks each vertex level-by-level.

        // If you want a list of the vertices as they are visited by breadth-first search, just add each vertex one-by-one to a list. 
        // Here is breadth-first search with an extra parameter, preVisit, which allows one to pass a function that gets called each time a vertex is visited.
        // Modify the client a bit to initiate a new list, called path, that gets updated each time a new vertex is visited. As you can see, the HashSet happens to be preserving the order that each vertex was inserted, but it is not guaranteed. A list is guaranteed to maintain its order.
        #endregion

        public HashSet<T> ApplyBfs<T>(Graph<T> graph, T start, Action<T> preVisit = null)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                preVisit?.Invoke(vertex);

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }

        #region Description of ShortestPathFunction

        // Breadth-first search is unique with respect to depth-first search in that you can use breadth-first search to find the shortest path between 2 vertices.
        // This assumes an unweighted graph.The shortest path in this case is defined as the path with the minimum number of edges between the two vertices.
        // In these cases it might be useful to calculate the shortest path to all vertices in the graph from the starting vertex, and provide a function that allows the client application to query for the shortest path to any other vertex.I've created a ShortestPathFunction in C# that does just this. 
        // It caculates the shortest path to all vertices from a starting vertex and then returns a function that allows one to query for the shortest path to any vertex from the original starting vertex.
        // Breadth-first search is being used to traverse the graph from the starting vertex and storing how it got to each node ( the previous node ) into a C# Dictionary, called previous. 
        // To find the shortest path to a node, the code looks up the previous node of the destination node and continues looking at all previous nodes until it arrives at the starting node. 
        // Since this will be the path in reverse, the code simply reverses the list and returns it.

        #endregion

        public Func<T, IEnumerable<T>> ShortestPathFunction<T>(Graph<T> graph, T start)
        {
            var previous = new Dictionary<T, T>();

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (previous.ContainsKey(neighbor))
                        continue;

                    previous[neighbor] = vertex;
                    queue.Enqueue(neighbor);
                }
            }

            IEnumerable<T> ShortestPath(T v)
            {
                var path = new List<T>();

                var current = v;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    current = previous[current];
                }
                
                path.Add(start);
                path.Reverse();

                return path;
            }

            return ShortestPath;
        }
    }
}
