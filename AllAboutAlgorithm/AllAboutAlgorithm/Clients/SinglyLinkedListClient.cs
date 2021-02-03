using AllAboutAlgorithm.Algorithm;
using System;

namespace AllAboutAlgorithm.Clients
{
    public class SinglyLinkedListClient
    {
        public static void Client()
        {
            #region insert 
            Console.WriteLine("Add First:");
            var myList1 = new SinglyLinkedList();

            // add in first position
            myList1.AddFirst("A1");
            myList1.AddFirst("B1");
            myList1.AddFirst("C1");
            myList1.PrintAllNodes();

            Console.WriteLine();

            // add in last position
            Console.WriteLine("Add Last:");
            var myList2 = new SinglyLinkedList();

            myList2.AddLast("W1");
            myList2.AddLast("X1");
            myList2.AddLast("Y1");
            myList2.AddLast("Z1");
            myList2.PrintAllNodes();

            Console.WriteLine();
            #endregion

            #region search
            // search node
            Console.WriteLine("Search Node:");
            var n = myList2.Search("V1");
            var msg = n == null ? "V1 Not found in list2! \n" : n.Data + " found list2! \n";
            Console.WriteLine(msg);
            #endregion

            #region find middle node
            // find middle node
            myList1.FindMiddleNode(myList1.GetHead());
            myList2.FindMiddleNode(myList2.GetHead());
            #endregion

            #region remove
            // remove node
            n = myList2.Search("Z1");
            msg = n == null ? "\nZ1 Not found!" : "\n" + n.Data + " found!";
            Console.WriteLine(msg);

            if (!msg.Equals("Z1 Not found!"))
            {
                myList2.Remove(n);
                Console.WriteLine("\nAfter Removal:");
                myList2.PrintAllNodes();
            }
            #endregion

            #region loop/cycle check
            myList2.AddLast("Z1");

            var n1 = myList2.Search("X1");
            var n2 = myList2.Search("Z1");

            if (n1 != null && n2 != null)
            {
                myList2.CreateLoop(n1, n2);
                Console.WriteLine("\nNew Linked List After Loop: ");
                myList2.PrintAllNodes();
            }

            var result = myList2.CheckLoopInLinkedList(myList2.GetHead());
            msg = result == false ? "\nLoop not found!" : "\nLoop found!";
            Console.WriteLine(msg);
            #endregion
        }
    }
}
