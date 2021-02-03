using System;
using System.Collections.Generic;
using cl = AllAboutAlgorithm.Clients;

namespace AllAboutAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = "| 1. UF | 2. BST | 3. SLL | 4. Graph | 5. BFS | 6. DFS | 7. Stack | 8. Queue |";
            var input = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            while (true)
            {
                Console.WriteLine(inputText);
                var s = Console.ReadLine()?.Trim();
                
                if (!input.Contains(s))
                    break;

                switch (s)
                {
                    case "1":
                        cl.QuickUnionUfClient.Client();
                        break;
                    case "2":
                        cl.BstClient.Client();
                        break;
                    case "3":
                        cl.SinglyLinkedListClient.Client();
                        break;
                    case "4":
                        cl.GraphClient.Client();
                        break;
                    case "5":
                        cl.BfsClient.Client();
                        break;
                    case "6":
                        cl.DfsClient.Client();
                        break;
                    case "7":
                        cl.StackClient.Client();
                        break;
                    case "8":
                        cl.QueueClient.Client();
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
