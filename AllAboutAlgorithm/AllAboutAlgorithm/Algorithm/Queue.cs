using System;

namespace AllAboutAlgorithm.Algorithm
{
    public class GenericQueue<T>
    {
        public readonly int Size;
        private int _itemCount;
        private int _head, _tail;
        private readonly T[] _queue;

        public GenericQueue(int size)
        {
            Size = size;
            _itemCount = 0;
            _head = _tail = 0;
            _queue = new T[size];
        }

        public bool IsQueueFull()
        {
            return _itemCount == Size;
        }

        public bool IsQueueEmpty()
        {
            return _itemCount == 0;
        }

        public void Enqueue(T item)
        {
            if (!IsQueueFull())
            {
                if (_tail == Size)
                    _tail = 0;

                _queue[_tail++] = item;
                _itemCount++;
            }
        }

        public T Dequeue()
        {
            if (!IsQueueEmpty())
            {
                var item = _queue[_head++];
                _queue[_head - 1] = default(T);
                _itemCount--; 

                if (_head == Size)
                    _head = 0;

                return item;
            }

            return default(T);
        }

        public T Head()
        {
            if (!IsQueueEmpty())
            {
                return _queue[_head];
            }

            return default(T);
        }

        public void PrintQueue()
        {
            var items = "";

            foreach (var item in _queue)
                items += item + " ";

            Console.WriteLine(items);
        }
    }
}
