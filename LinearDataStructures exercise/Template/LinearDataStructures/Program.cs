using LinearDataStructures.Common;
using System;
using static System.Net.Mime.MediaTypeNames;
using static LinearDataStructures.LinearStructuresTasks;

namespace LinearDataStructures
{
    class Program
    {
        static void Main()
        {
            var testList = new int[] { 1, 2, 3 };
            var testList2 = new int[] { 4, 5, 6 };
            var inputList = new SinglyLinkedList<int>(testList);
            var inputList2 = new SinglyLinkedList<int>(testList2);
            var newList = LinearStructuresTasks.MergeLists(inputList, inputList2);
            int listLength = GetListLength(newList);
            
            for (int index = 0; index < listLength; index++)
            {
                
                Console.WriteLine(newList.RemoveFirst());
                
            }
        }
    }
}
