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
            ValidateEmptyList(list);
            int elementsCount = GetListLength<T>(list);
            if (elementsCount == 1)
            {
                return list.Head;
            }
            var currentNode = list.Head;
            int currentIndex = 0;
            int middleIndex = elementsCount / 2;
            while (currentNode.Next != null)
            {
                if (currentIndex == middleIndex)
                {
                    break;
                }
                currentIndex++;
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        public static SinglyLinkedList<T> MergeLists<T>(SinglyLinkedList<T> list1, SinglyLinkedList<T> list2) where T : IComparable
        {
            
            var mergedList = new SinglyLinkedList<T>();
            var currentNodeOne = list1.Head;
            var currentNodeTwo = list2.Head;
            int listOneLength = GetListLength(list1);
            int listTwoLength = GetListLength(list2);
            

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
        private static void ValidateEmptyList<T>(SinglyLinkedList<T> list)
        {
            int elementsCount = GetListLength(list);
            if (elementsCount == 0)
            {
                string errorMessage = "The List is empty!";
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}
