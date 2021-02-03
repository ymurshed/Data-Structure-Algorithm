using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedListTest
{
    public class Node
    {
        public Node next;
        public Object data;
        public int index = 0;
    }

    public class LinkedList
    {
        private Node head;
        public static int count;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public Node GetHead()
        {
            return head;
        }

        public void PrintAllNodes()
        {
            int i = 0;
            Node current = head;

            if (current.index <= 1)
            {
                while (current != null)
                {
                    if (i < current.index)
                    {
                        Console.Write("->" + current.data);
                        i = current.index;
                    }
                    else
                    {
                        Console.Write("->" + current.data);
                        break;
                    }

                    current = current.next;
                }
                Console.WriteLine();
            }
            else
            {
                while (current != null)
                {
                    Console.Write("->" + current.data);
                    current = current.next;
                }
                Console.WriteLine();
            }
        }

        public void AddFirst(Object data)
        {
            Node toAdd = new Node();

            toAdd.data = data;
            toAdd.index = ++count;
            toAdd.next = head;

            head = toAdd;
        }

        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();

                head.data = data;
                head.index = ++count;
                head.next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                toAdd.index = ++count;

                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = toAdd;
            }
        }

        public void CreateLoop(Node n1, Node n2)
        {
            n2.next = n1;
        }

        public Node Search(Object data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.data == data)
                    return current;

                current = current.next;
            }

            return null;
        }

        public void Remove(Node delete)
        {
            Node current = head;
            while (current.next != null)
            {
                if (current.next == delete)
                {
                    current.next = delete.next;
                    delete = null;
                    break;
                }

                current = current.next;
            }
        }

        public void FindMiddleNode(Node head)
        {
            int length = 0;
            Node middle = head;
            Node current = head;

            while (current.next != null)
            {
                length++;

                if (length % 2 == 0)
                    middle = middle.next; // increment after 2 iteration

                current = current.next;
            }

            if (length % 2 == 1) // if total node count == odd number of nodes
                middle = middle.next;

            Console.WriteLine("Middle node: " + middle.data);
        }

        //Floyd’s Cycle-Finding Algorithm (O(n) complexity)
        public bool CheckLoopInLinkedList(Node head)
        {
            Node slow, fast1, fast2;
            slow = fast1 = fast2 = head;

            while (slow != null && fast1 != null && fast2 != null) 
            {
                fast1 = fast2.next;
                if (fast1 == null) break;
                fast2 = fast1.next;

                if (slow == fast1 || slow == fast2)
                    return true;

                slow = slow.next;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region insert 
            Console.WriteLine("Add First:");
            LinkedList myList1 = new LinkedList();

            // add in first position
            myList1.AddFirst("A1");
            myList1.AddFirst("B1");
            myList1.AddFirst("C1");
            myList1.PrintAllNodes();

            Console.WriteLine();

            // add in last position
            Console.WriteLine("Add Last:");
            LinkedList myList2 = new LinkedList();

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
            Node n = myList2.Search("V1");
            string msg = n == null ? "V1 Not found in list2! \n" : n.data + " found list2! \n";
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
            msg = n == null ? "\nZ1 Not found!" : "\n" + n.data + " found!";
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

            Node n1 = myList2.Search("X1");
            Node n2 = myList2.Search("Z1");

            if (n1 != null && n2 != null)
            {
                myList2.CreateLoop(n1, n2);
                Console.WriteLine("\nNew Linked List After Loop: ");
                myList2.PrintAllNodes();
            }
            bool result = myList2.CheckLoopInLinkedList(myList2.GetHead());
            msg = result == false ? "\nLoop not found!" : "\nLoop found!";
            Console.WriteLine(msg);
            #endregion

            Console.ReadLine();
        }
    }
}
