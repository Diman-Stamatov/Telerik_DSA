using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] items = Array.Empty<T>();
        private int top;

        public int Size
        {
            get
            {
                if (this.IsEmpty == true)
                {
                    return 0;
                }
                return this.top;
            }
        }

        public bool IsEmpty
        {
            get
            {
                bool isEmpty = false;
                if (this.items == null || this.items.Length == 0)
                {
                    isEmpty = true;
                }
                return isEmpty;
            }
        }

        public void Push(T element)
        {
            this.top++;
            if (this.items == Array.Empty<T>())
            {
                this.items = new T[4];                
            }
            else if (this.top == this.items.Length)
            {
                int elementsCount = this.items.Length;
                var extendedArray = new T[elementsCount * 2];
                Array.Copy(this.items, 0, extendedArray, 0, elementsCount);
                
                this.items = extendedArray;
            }
            this.items[this.top] = element;
            

        }

        public T Pop()
        {
            ValidateEmptyStack();
            var topItem = this.items[this.top];
            this.items[this.top] = default;
            this.top--;
            return topItem;
        }

        public T Peek()
        {
            ValidateEmptyStack();
            return this.items[this.top];
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
