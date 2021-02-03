using System;

namespace BfsMatrixTraverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new char[4, 4]
            {
                { '0', '1', '0', 's' },
                { '*', '0', '3', '2' },
                { '0', 'd', '6', '4' },
                { '5', '7', '8', '9' } 
            };

            Console.WriteLine($"Shorted path is : {BfsTraversal.ShortestPath(grid)}");
            Console.ReadLine();
        }
    }
}
