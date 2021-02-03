using System;
using System.Collections.Generic;

namespace AllAboutAlgorithm.Algorithm
{
    // Use Stack
    public class Dfs
    {
        #region Description of DFS
        
        // To make sure the depth-first search algorithm doesn't re-visit vertices, the visited HashSet keeps track of vertices already visited. 
        // A Stack, called stack, keeps track of vertices found but not yet visited. Initially stack contains the starting vertex. 
        // The next vertex is popped from stack. If it has already been visited, it is discarded and the next vertex is popped from stack. 
        // If it has not been visited, it is added to the set of visited vertices and its unvisited neighbors are added to stack. 
        // This continues until there are no more vertices in stack, and the set of vertices visited is returned. 
        // The set of vertices returned is all the vertices that can be reached from the starting vertex.
        // Notice that depth-first search aggresively follows a path until it can't go any futher and then backtracks a bit and continues to aggressively follow the next available path.

        // If you want a list of the vertices as they are visited by depth-first search, just add each vertex one-by-one to a list. 
        // Here is depth-first search with an extra parameter, preVisit, which allows one to pass a function that gets called each time a vertex is visited.
        // Modify the client a bit to initiate a new list, called path, that gets updated each time a new vertex is visited. As you can see, the HashSet happens to be preserving the order that each vertex was inserted, but I wouldn't bet on that. A list is guaranteed to maintain its order.

        #endregion

        public HashSet<T> ApplyDfs<T>(Graph<T> graph, T start, Action<T> preVisit = null)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                preVisit?.Invoke(vertex);

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }
    }
}
