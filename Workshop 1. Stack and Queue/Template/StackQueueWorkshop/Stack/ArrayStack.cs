using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private const int InitialSize = 10;
        
        private T[] items = new T[InitialSize];
        private int top;

        public int Size
        {
            get
            {                
                return this.top;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.top == 0;
            }
        }

        public void Push(T element)
        {                        
            if (this.top == this.items.Length)
            {
                int elementsCount = this.items.Length;
                var extendedArray = new T[elementsCount * 2];
                Array.Copy(this.items, 0, extendedArray, 0, elementsCount);
                
                this.items = extendedArray;
            }
            this.items[this.top] = element;
            this.top++;
        }

        public T Pop()
        {
            ValidateEmptyStack();
            int topItemIndex = this.top-1;
            var topItem = this.items[topItemIndex];
            this.items[topItemIndex] = default;
            this.top--;
            return topItem;
        }

        public T Peek()
        {
            ValidateEmptyStack();
            int topItemIndex = this.top - 1;
            return this.items[topItemIndex];
        }

        private void ValidateEmptyStack()
        {
            if (this.IsEmpty == true)
            {
                string errorMessage = "There are no items stored in the Stack!";
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}
