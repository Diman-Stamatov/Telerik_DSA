using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] items = new T[4];

        private int headIndex;
        private int itemsCount;        

        public int Size
        {
            get
            {                
                return this.itemsCount;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.itemsCount == 0;
            }
        }

        public void Enqueue(T element)
        {
            this.itemsCount++;
            int arrayMaxSize = this.items.Length;
            if (arrayMaxSize == this.itemsCount)
            {                
                var newItemsArray = new T[arrayMaxSize * 2];
                Array.Copy(this.items, newItemsArray, arrayMaxSize);
                this.items = newItemsArray;
            }
            this.items[this.itemsCount-1] = element;

            int halfArraySize = this.items.Length/2;
            int emptyArraySpaces = Math.Abs(this.headIndex +1 - this.itemsCount);
            if (halfArraySize < emptyArraySpaces)
            {
                var newItemsArray = new T[halfArraySize];
                Array.Copy(this.items, this.headIndex, newItemsArray, 0, this.itemsCount);
                this.headIndex = 0;
            }
        }

        public T Dequeue()
        {
            ValidateEmptyQueue();
            var dequeuedElement = this.items[headIndex];
            this.items[headIndex] = default;
            this.headIndex++;
            this.itemsCount--;
            return dequeuedElement;
        }

        public T Peek()
        {
            ValidateEmptyQueue();
            return this.items[this.headIndex];
        }
        private void ValidateEmptyQueue()
        {
            if (this.IsEmpty == true)
            {
                string errorMessage = "The Queue is currently empty!";
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}
