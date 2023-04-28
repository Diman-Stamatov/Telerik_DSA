using System;
using System.Linq;
using System.Collections.Generic;


using System.Text;

namespace StudentsOrder
{
    
    internal class Program
    {
        

        static void Main(string[] args)
        {
            int[] initialInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int studentsCount = initialInput[0];
            int seatChanges = initialInput[1];
            var dictionary = new Dictionary<string, LinkedListNode<string>>();
            var list = new LinkedList<string>();
            var students = Console.ReadLine().Split(' ');
            
            for (int index = 0; index < studentsCount; index++)
            {
                string studentName = students[index];
                
                list.AddLast(studentName);                               
                dictionary.Add(studentName, list.Last);
                
            }
            for (int change = 0; change < seatChanges; change++)
            {
                var seatChange = Console.ReadLine().Split(' ');
                string studentMoving = seatChange[0];
                string moveTo = seatChange[1];

                list.Remove(dictionary[studentMoving]);
                dictionary.Remove(studentMoving);
                
                var node = list.AddBefore(dictionary[moveTo], studentMoving);
                dictionary.Add(studentMoving, node);
                
            }
            Console.WriteLine(String.Join(" ", list));
            
        }
        
    }
}