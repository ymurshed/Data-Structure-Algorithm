using System;
using System.Collections.Generic;
using System.Linq;

namespace BfsMatrixTraverse
{
    public class BfsTraversal
    {
        private static void PrintQueue(Queue<BfsModel> q, char currentNode, string dir, char cameFrom)
        {
            var item = q.Peek();
            Console.Write($"Queue info => direction: {dir}, from: {cameFrom}, ---> r: {item.Row}, c: {item.Col}, d: {item.Distance}, current node value: {currentNode}\n");

            //foreach (var item in q)
            //{
            //    Console.Write($"Queue info => r: {item.Row}, c: {item.Col}, d: {item.Distance}, node value: {grid[item.Row, item.Col]}\n");
            //}
        }

        public static int ShortestPath(char[,] grid)
        {
            var bfsModel = new BfsModel(0, 0, 0);

            var r = grid.GetLength(0);
            var c = grid.GetLength(1);
            var visited = new bool[r, c];

            for (var i = 0; i < r; i++)
            {
                for (var j = 0; j < c; j++)
                {
                    if (grid[i, j] == '0')
                        visited[i, j] = true;
                    else
                        visited[i, j] = false;

                    // Finding source 
                    if (grid[i, j] == 's')
                    {
                        bfsModel.Row = i;
                        bfsModel.Col = j;
                    }
                }
            }

            // applying BFS on matrix cells starting from source 
            var q = new Queue<BfsModel>();
            q.Enqueue(bfsModel);
            visited[bfsModel.Row, bfsModel.Col] = true;

            while (q.Any())
            {
                var p = q.Peek();
                q.Dequeue();

                var cameFrom = grid[p.Row, p.Col];

                // Destination found; 
                if (grid[p.Row, p.Col] == 'd')
                    return p.Distance;

                // moving up 
                if (p.Row - 1 >= 0 && visited[p.Row - 1, p.Col] == false)
                {
                    q.Enqueue(new BfsModel(p.Row - 1, p.Col, p.Distance + 1));
                    visited[p.Row - 1, p.Col] = true;
                    PrintQueue(q, grid[p.Row - 1, p.Col], "up", cameFrom);
                }

                // moving down 
                if (p.Row + 1 < r && visited[p.Row + 1, p.Col] == false)
                {
                    q.Enqueue(new BfsModel(p.Row + 1, p.Col, p.Distance + 1));
                    visited[p.Row + 1, p.Col] = true;
                    PrintQueue(q, grid[p.Row + 1, p.Col], "down", cameFrom);
                }

                // moving left 
                if (p.Col - 1 >= 0 && visited[p.Row, p.Col - 1] == false)
                {
                    q.Enqueue(new BfsModel(p.Row, p.Col - 1, p.Distance + 1));
                    visited[p.Row, p.Col- 1] = true;
                    PrintQueue(q, grid[p.Row, p.Col - 1], "left", cameFrom);
                }

                // moving right 
                if (p.Col + 1 < c && visited[p.Row, p.Col + 1] == false)
                {
                    q.Enqueue(new BfsModel(p.Row, p.Col + 1, p.Distance + 1));
                    visited[p.Row, p.Col + 1] = true;
                    PrintQueue(q, grid[p.Row, p.Col + 1], "right", cameFrom);
                }
            }
            return -1;
        }
    }
}
