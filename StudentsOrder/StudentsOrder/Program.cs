using System;
using System.Linq;
using System.Collections.Generic;


namespace StudentsOrder
{
    public class LinkedList<T>
    {
        public Node<T> Head
        {
            get;
            set;
        }

        /// <summary>
        /// Creates an empty list.
        /// </summary>
        public LinkedList()
        {
            this.Head = null;
        }

        /// <summary>
        /// Creates a new list and initializes its head with the given value.
        /// </summary>
        /// <param name="value">The value of the head node.</param>
        public LinkedList(T value)
        {
            this.AddFirst(value);
        }

        /// <summary>
        /// Creates a new list from the given array.
        /// </summary>
        /// <param name="array">The array to create a new list from.</param>
        public LinkedList(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentException("Cannot create a list from a null array.");
            }

            // Iterate the array from last to first
            for (int i = array.Length - 1; i >= 0; i--)
            {
                this.AddFirst(array[i]);
            }
        }


        /// <summary>
        /// Adds a new head node with the given value.
        /// </summary>
        /// <param name="value">The value of the new head node.</param>
        /// <returns>A reference to the newly created head.</returns>
        public Node<T> AddFirst(T value)
        {
            var node = new Node<T>(value);
            node.Next = this.Head;
            if (this.Head != null)
            {
                this.Head.Prev = node;
            }
            this.Head = node;

            return node;
        }

        /// <summary>
        /// Removes the head node of the list.
        /// </summary>
        /// <returns>The value of the head.</returns>
        public T RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new NullReferenceException("Cannot remove head. The list is empty.");
            }

            T value = this.Head.Value;
            this.Head = this.Head.Next;

            return value;
        }
        public Node<T> Find(T value)
        {
            Node<T> current = this.Head;
            while (current != null)
            {
                if (Compare(current.Value, value) == true)
                {
                    return current;
                }
                current = current.Next;

            }
            string errorMessage = "Value not found!";
            throw new ArgumentException(errorMessage);
        }

        public override string ToString()
        {
            string result = "";

            var current = this.Head;
            while (current != null)
            {
                result += $"{current.Value} ";
                current = current.Next;
            }

            return result.TrimEnd();
        }
        public bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
    public class Node<T>
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

        public Node<T> Next
        {
            get;
            set;
        }
        public Node<T> Prev
        {
            get;
            set;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] initialInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int students = initialInput[0];
            int seatChanges = initialInput[1];
            var studentSeating = new LinkedList<string>(Console.ReadLine().Split(' '));
            string[] commands = new string[seatChanges];
            for (int index = 0; index < seatChanges; index++)
            {
                commands[index] = Console.ReadLine();

            }
            for (int seatChange = 0; seatChange < seatChanges; seatChange++)
            {
                var newSeating = Console.ReadLine().Split(' ');
                string studentOne = newSeating[0];
                string studentTwo = newSeating[1];
                Node<string> studentOneNode = studentSeating.Find(studentOne);
                Node<string> studentTwoNode = studentSeating.Find(studentTwo);
                if (studentOneNode.Prev != null)
                {
                    studentOneNode.Prev.Next = studentOneNode.Next;
                }
                if (studentOneNode.Next != null)
                {
                    studentOneNode.Next.Prev = studentOneNode.Prev;
                }
                if (studentTwoNode.Prev != null)
                {
                    studentTwoNode.Prev.Next = studentOneNode;
                }
                studentOneNode.Prev = studentTwoNode.Prev;
                if (studentSeating.Head == studentOneNode)
                {
                    studentSeating.Head = studentOneNode.Next;
                }
                if (studentSeating.Head == studentTwoNode)
                {
                    studentSeating.Head = studentOneNode;
                }

                studentTwoNode.Prev = studentOneNode;
                studentOneNode.Next = studentTwoNode;

            }
            Console.WriteLine(studentSeating.ToString());
        }
    }
}