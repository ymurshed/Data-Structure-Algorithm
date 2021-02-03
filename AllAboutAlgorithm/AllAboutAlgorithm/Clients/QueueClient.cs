using System;

namespace AllAboutAlgorithm.Clients
{
    public class QueueClient
    {
        public static void Client()
        {
            var queueCondition = "";

            var que = new Algorithm.GenericQueue<string>(3);

            que.Enqueue("A");
            que.Enqueue("B");
            que.Enqueue("C");

            que.PrintQueue();
            Console.WriteLine("Head Element: " + que.Head());

            queueCondition = que.IsQueueFull() ? "Queue Full!" : "Queue Not Full!";
            Console.WriteLine(queueCondition);

            que.Dequeue();
            que.Dequeue();
            que.PrintQueue();

            que.Enqueue("D");
            que.Enqueue("E");
            que.PrintQueue();

            que.Dequeue();
            que.PrintQueue();

            que.Dequeue();
            que.Dequeue();
            que.PrintQueue();
            queueCondition = que.IsQueueEmpty() ? "Queue Empty!" : "Queue Not Empty!";
            Console.WriteLine(queueCondition);
        }
    }
}
