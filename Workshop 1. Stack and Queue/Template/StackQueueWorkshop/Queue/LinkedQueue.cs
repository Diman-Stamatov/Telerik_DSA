using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> head, tail;
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
                bool isEmpty = false; 
                if (this.size == 0)
                {
                    isEmpty = true;
                }
                return isEmpty;
            }
        }

        public void Enqueue(T element)
        {
            var newNode = new Node<T>();
            newNode.Data = element;
            if (this.size == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }            
            this.size++;
        }

        public T Dequeue()
        {
            ValidateEmptyQueue();
            var dequeuedElement = this.head.Data;
            this.head = this.head.Next;
            size--;
            return dequeuedElement;
        }

        public T Peek()
        {
            ValidateEmptyQueue();
            return this.head.Data;
        }
        private void ValidateEmptyQueue()
        {
            if (this.size == 0)
            {
                string errorMessage = "The Queue is currently empty!";
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}
