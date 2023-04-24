﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedListWorkshop
{
    public class LinkedList<T> : IList<T>
    {
        private Node head;
        private Node tail;

        public T Head
        {
            get
            {
                ValidateEmptyList();
                return this.head.Value;
            }
        }

        public T Tail
        {
            get
            {
                ValidateEmptyList();
                return this.tail.Value;
            }
        }

        public int Count
        {
            get
            {
                int elementsCount = 0;
                if (this.head == null)
                {
                    return elementsCount;
                }                
                var enumerator = new ListEnumerator(this.head);
                while (enumerator.MoveNext())
                {
                    elementsCount++;
                }
                return elementsCount;
            }
            private set
            {
                
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new Node(value);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.head.Prev = newNode;
                newNode.Next = this.head;
                this.head = newNode;
            }

        }

        public void AddLast(T value)
        {
            var newNode = new Node(value);
            if (this.tail == null)
            {
                this.head = newNode;
                this.tail = newNode;                
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }
        }

        public void Add(int index, T value)
        {
            ValidateIndex(index);
            var enumerator = new ListEnumerator(this.head);
            int currentIndex = 0;
            while (currentIndex != index)
            {
                enumerator.MoveNext();
                currentIndex++;
            }
            var newNode = new Node(value);
            var foundNode = enumerator.ReturnCurrentNode();
            newNode.Prev = foundNode.Prev;
            newNode.Next = foundNode;
        }

        public T Get(int index)
        {
            ValidateIndex(index);
            var enumerable = new ListEnumerator(this.head);
            int currentIndex = 0;
            while (currentIndex != index)
            {
                enumerable.MoveNext();
                currentIndex++;
            }
            return enumerable.Current;
        }

        public int IndexOf(T value)
        {
            ValidateEmptyList();
            var enumerator = new ListEnumerator(this.head);
            int currentIndex = 0;   
            while (enumerator.MoveNext() == true)
            {
                var currentValue = enumerator.Current;
                if (Compare(currentValue, value) == true)
                {
                    break;
                }
                currentIndex++;
            }
            return currentIndex;
        }

        public T RemoveFirst()
        {
            ValidateEmptyList();
            var removedValue = this.head.Value;
            this.head = this.head.Next;
            this.head.Prev = null;
            return removedValue;
        }

        public T RemoveLast()
        {
            ValidateEmptyList();
            this.tail.Prev.Next = null;
            var removedValue = this.tail.Value;
            this.tail = this.tail.Prev;
            return removedValue;

        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return new ListEnumerator(this.head);
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        // Use private nested class so that LinkedList users
        // don't know about the LinkedList internal structure
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value
            {
                get;
                private set;
            }

            public Node Next
            {
                get;
                set;
            }

            public Node Prev
            {
                get;
                set;
            }
        }

        // List enumerator that enables traversing all nodes of a list in a foreach loop
        private class ListEnumerator : System.Collections.Generic.IEnumerator<T>
        {
            private Node start;
            private Node current;

            internal ListEnumerator(Node head)
            {
                this.start = head;
                this.current = null;
            }

            public T Current
            {
                get
                {
                    if (this.current == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return this.current.Value;
                }
            }
            public Node ReturnCurrentNode()
            {
                return this.current;
            }
            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = this.start;
                    return true;
                }

                if (current.Next == null)
                {
                    return false;
                }

                current = current.Next;
                return true;
            }

            public void Reset()
            {
                this.current = null;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index > this.Count - 1)
            {
                string errorMessage = "The index is outside the bounds of the List!";
                throw new ArgumentOutOfRangeException(errorMessage);
            }
        }
        private void ValidateEmptyList()
        {
            if (this.head == null)
            {
                string errorMessage = "The list is currently empty!";
                throw new InvalidOperationException(errorMessage);
            }
        }
        public bool Compare<T>(T valueOne, T valueTwo)
        {
            return EqualityComparer<T>.Default.Equals(valueOne, valueTwo);
        }
    }
}