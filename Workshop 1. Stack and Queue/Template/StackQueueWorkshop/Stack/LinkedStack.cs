using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Stack
{
    public class LinkedStack<T> : IStack<T>
    {
        private Node<T> top;
        private int size;

        public int Size
        {
            get
            {
               return this.size;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return size == 0;
            }
        }

        public void Push(T element)
        {
            var newTop = new Node<T>();
            newTop.Data = element;
            newTop.Next = this.top;
            this.top = newTop;
            this.size++;
        }

        public T Pop()
        {
            if (this.size == 0)
            {
                string errorMessage = "There are no more elements in the Stack!";
                throw new InvalidOperationException(errorMessage);
            }
            var popElement = this.top.Data;
            this.top = this.top.Next;
            size--;
            return popElement;

        }

        public T Peek()
        {
            if (this.size == 0)
            {
                string errorMessage = "There are no more elements in the Stack!";
                throw new InvalidOperationException(errorMessage);
            }
            return this.top.Data;
        }
    }
}
