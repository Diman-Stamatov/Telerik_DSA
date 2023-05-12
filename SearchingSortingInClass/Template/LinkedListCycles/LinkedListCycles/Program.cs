using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListCycles
{
    internal class Program
    {
        public class Node
        {
            public Node(int value)
            {
                this.Value = value;
            }
            public int Value
            {
                get;
                set;
            }
            public Node Next
            {
                get;
                set;
            }
        }

        static void Main(string[] args)
        {
            var head = new Node(1);
            var current = head;
            for (int i = 0; i < 6; i++)
            {
                var newNode = new Node(i);
                current.Next = newNode;
                current = newNode;
            }
            current.Next = head;
            Console.WriteLine(CheckForLoop(head));


        }
        static bool CheckForLoop(Node head)
        {
            var uniqueSet = new HashSet<Node>();
            while (head != null)
            {
                if (!uniqueSet.Add(head))
                {
                    return true;
                }
                head = head.Next;
            }
            return false;
        }
    }
}
