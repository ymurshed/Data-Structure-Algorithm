using System;

namespace AllAboutAlgorithm.Clients
{
    class StackClient
    {
        public static void Client()
        {
            var stackCondition = "";

            var stk = new Algorithm.GenericStack<string>(3);

            stk.Push("A");
            stk.Push("B");
            stk.Push("C");

            stk.PrintStack();
            Console.WriteLine("Peek Element: " + stk.Peek());

            stackCondition = stk.IsStackFull() ? "Stack Full!" : "Stack Not Full!";
            Console.WriteLine(stackCondition);
            
            stk.Pop();
            stk.Pop();
            stk.Pop();

            stackCondition = stk.IsStackEmpty() ? "Stack Empty!" : "Stack Not Empty!";
            Console.WriteLine(stackCondition);
            stk.PrintStack();
        }
    }
}
