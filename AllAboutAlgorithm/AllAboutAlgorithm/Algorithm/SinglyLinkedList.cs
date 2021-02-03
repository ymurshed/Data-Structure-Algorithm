using System;

namespace AllAboutAlgorithm.Algorithm
{
    public class Node
    {
        public Node Next;
        public object Data;
        public int Index = 0;
    }

    public class SinglyLinkedList
    {
        private Node _head;
        public static int Count;

        public SinglyLinkedList()
        {
            _head = null;
            Count = 0;
        }

        public Node GetHead()
        {
            return _head;
        }

        public void PrintAllNodes()
        {
            var i = 0;
            var current = _head;

            if (current.Index <= 1)
            {
                while (current != null)
                {
                    if (i < current.Index)
                    {
                        Console.Write("->" + current.Data);
                        i = current.Index;
                    }
                    else
                    {
                        Console.Write("->" + current.Data);
                        break;
                    }

                    current = current.Next;
                }
                Console.WriteLine();
            }
            else
            {
                while (current != null)
                {
                    Console.Write("->" + current.Data);
                    current = current.Next;
                }
                Console.WriteLine();
            }
        }

        public void AddFirst(object data)
        {
            var toAdd = new Node
            {
                Data = data,
                Index = ++Count,
                Next = _head
            };

            _head = toAdd;
        }

        public void AddLast(object data)
        {
            if (_head == null)
            {
                _head = new Node
                {
                    Data = data,
                    Index = ++Count,
                    Next = null
                };
            }
            else
            {
                var toAdd = new Node
                {
                    Data = data,
                    Index = ++Count
                };

                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toAdd;
            }
        }

        public void CreateLoop(Node n1, Node n2)
        {
            n2.Next = n1;
        }

        public Node Search(object data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data == data)
                    return current;

                current = current.Next;
            }

            return null;
        }

        public void Remove(Node delete)
        {
            var current = _head;
            while (current.Next != null)
            {
                if (current.Next == delete)
                {
                    current.Next = delete.Next;
                    delete = null;
                    break;
                }

                current = current.Next;
            }
        }

        public void FindMiddleNode(Node head)
        {
            var length = 0;
            var middle = head;
            var current = head;

            while (current.Next != null)
            {
                length++;

                if (length % 2 == 0)
                    middle = middle.Next; // increment after 2 iteration

                current = current.Next;
            }

            if (length % 2 == 1) // if total node count == odd number of nodes
                middle = middle.Next;

            Console.WriteLine("Middle node: " + middle.Data);
        }

        //Floyd’s Cycle-Finding Algorithm (O(n) complexity)
        public bool CheckLoopInLinkedList(Node head)
        {
            Node fast1, fast2;
            var slow = fast1 = fast2 = head;

            while (slow != null && fast1 != null && fast2 != null)
            {
                fast1 = fast2.Next;
                if (fast1 == null) break;
                fast2 = fast1.Next;

                if (slow == fast1 || slow == fast2)
                    return true;

                slow = slow.Next;
            }
            return false;
        }
    }
}
