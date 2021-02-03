using System;

namespace AllAboutAlgorithm.Algorithm
{
    public class GenericStack<T>
    {
        private readonly int _size;
        private int _stackPointer;
        private readonly T[] _stack;

        public GenericStack(int size)
        {
            _size = size;
            _stackPointer = 0;
            _stack = new T[size];
        }

        public bool IsStackFull()
        {
            return _stackPointer == _size;
        }

        public bool IsStackEmpty()
        {
            return _stackPointer == 0;
        }

        public void Push(T item)
        {
            if (!IsStackFull())
            {
                _stack[_stackPointer++] = item;
            }
        }

        public T Pop()
        {
            if (!IsStackEmpty())
            {
                var item = _stack[--_stackPointer];
                _stack[_stackPointer] = default(T);
                return item;
            }

            return default(T);
        }

        public T Peek()
        {
            if (!IsStackEmpty())
            {
                return _stack[_stackPointer - 1];
            }

            return default(T);
        }

        public void PrintStack()
        {
            var items = "";

            foreach (var item in _stack)
                items += item + " ";

            Console.WriteLine(items);
        }
    }
}
