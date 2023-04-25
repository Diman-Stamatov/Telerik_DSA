using System;
using System.Collections.Generic;
using System.Text;

using LinearDataStructures.Common;

namespace LinearDataStructures
{
    public static class LinearStructuresTasks
    {
        public static bool AreListsEqual<T>(SinglyLinkedList<T> list1, SinglyLinkedList<T> list2)
        {
            int listOneCount = GetListLength(list1);
            int listTwoCount = GetListLength(list2);
            if (listOneCount != listTwoCount)
            {
                return false;
            }
            var nodeOne = list1.Head;
            var nodeTwo = list2.Head;
            while (nodeOne != null)
            {
                if (CompareGenerics(nodeOne.Value, nodeTwo.Value) == false)
                {
                    return false;
                }
                nodeOne = nodeOne.Next;
                nodeTwo = nodeTwo.Next; 
            }
            return true;
        }

        public static Node<T> FindMiddleNode<T>(SinglyLinkedList<T> list)
        {
            // Add your implementation here.
            throw new NotImplementedException();
        }

        public static SinglyLinkedList<T> MergeLists<T>(SinglyLinkedList<T> list1, SinglyLinkedList<T> list2) where T : IComparable
        {
            // Add your implementation here.
            throw new NotImplementedException();
        }

        public static SinglyLinkedList<T> ReverseList<T>(SinglyLinkedList<T> list)
        {
            // Add your implementation here.
            throw new NotImplementedException();
        }

        public static bool AreValidParentheses(string expression)
        {
            // Add your implementation here.
            throw new NotImplementedException();
        }

        public static string RemoveBackspaces(string sequence, char backspaceChar)
        {
            // Add your implementation here.
            throw new NotImplementedException();
        }
        private static int GetListLength<T>(SinglyLinkedList<T> list)
        {
            
            if (list == null || list.Head == null)
            {
                return 0;
            }
            int count = 1;
            Node<T> currentNode = list.Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                count++;
            }
            return count;
        }
        public static bool CompareGenerics<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
}
