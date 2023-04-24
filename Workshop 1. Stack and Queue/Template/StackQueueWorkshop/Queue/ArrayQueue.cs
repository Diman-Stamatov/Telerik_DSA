using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private const int InitialSize = 10;
        
        private T[] items = new T[InitialSize];

        private int headIndex;
        private int tailIndex;
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
            int halfArraySize = this.items.Length / 2;
            int emptyArraySpaces = this.headIndex + 1;
            if (halfArraySize < emptyArraySpaces && halfArraySize > InitialSize) 
            {
                var newItemsArray = new T[halfArraySize];
                Array.Copy(this.items, this.headIndex, newItemsArray, 0, this.itemsCount);
                this.headIndex = 0;
                this.tailIndex = this.itemsCount - 1;
            }

            this.itemsCount++;
            int arrayMaxSize = this.items.Length;
            if (arrayMaxSize == this.itemsCount)
            {                
                var newItemsArray = new T[arrayMaxSize * 2];
                Array.Copy(this.items, newItemsArray, this.itemsCount);
                this.items = newItemsArray;
            }
            this.items[tailIndex++] = element;
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
