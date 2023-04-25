using DoublyLinkedListWorkshop;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    public static DoublyLinkedListWorkshop.LinkedList<int> CreateTestList(IEnumerable<int> items)
    {
        DoublyLinkedListWorkshop.LinkedList<int> result = new DoublyLinkedListWorkshop.LinkedList<int>();
        foreach (int item in items)
        {
            result.AddLast(item);
        }
        return result;
    }
    static void Main()
    {
        DoublyLinkedListWorkshop.LinkedList<int> testList =CreateTestList(new int[] { 1, 2, 4, 5 });

        // Act
        

        // Assert
       
        foreach (var item in testList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        Console.WriteLine(testList.Head);
        Console.WriteLine(testList.Tail);
        Console.WriteLine();
        testList.Add(3, 9);

        foreach (var item in testList)
        {
            Console.WriteLine(item);
        }
    }
}
