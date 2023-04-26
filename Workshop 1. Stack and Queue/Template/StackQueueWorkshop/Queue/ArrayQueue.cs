using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private const int InitialSize = 5;
        
        private T[] items = new T[InitialSize];

        public int headIndex = 0;
        public int tailIndex = 0;
        private int itemsCount = 0;        

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
            int maxElements = this.items.Length;
            if (this.Size == maxElements)
            {
                var doubledArray = new T[maxElements * 2];
                for (int index = 0; index < maxElements; index++)
                {
                    if (this.headIndex == maxElements)
                    {
                        this.headIndex = 0;
                    }
                    doubledArray[index] = this.items[this.headIndex++];
                }
                this.tailIndex = this.itemsCount - 1;
                this.headIndex = 0;
                this.items = doubledArray;
                maxElements = this.items.Length;
            }
            if (this.Size == 0)
            {
                this.items[headIndex] = element;                
                this.itemsCount++;                
            }
            else
            {
                this.tailIndex++;
                if (this.tailIndex == maxElements)
                {
                    this.tailIndex = 0;
                }
                this.items[this.tailIndex] = element;
                this.itemsCount++;
            }

        }

        public T Dequeue()
        {
            ValidateNonEmptyQueue();
            var dequeuedElement = this.items[headIndex];
            headIndex++;
            this.itemsCount--;
            return dequeuedElement;
        }

        public T Peek()
        {
            ValidateNonEmptyQueue();
            var dequeuedElement = this.items[headIndex];
            return dequeuedElement;
        }
        private void ValidateNonEmptyQueue()
        {
            if (this.IsEmpty == true)
            {
                string errorMessage = "The Queue is currently empty!";
                throw new InvalidOperationException(errorMessage);
            }
        }
        public override string ToString()
        {
            var output = new StringBuilder();
            for (int index = 0; index < itemsCount; index++)
            {

            }
            int printIndex = headIndex;
            for (int index = 0; index < itemsCount; index++)
            {
                int maxElements = this.items.Length;
                if (printIndex == maxElements)
                {
                    printIndex = 0;
                }
                var item = this.items[printIndex++];
                output.Append(item);
                output.Append(" ");
            }
            
            return output.ToString();   
        }
    }
}
