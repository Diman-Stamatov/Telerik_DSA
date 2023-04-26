using System;
using System.Linq;
using System.Collections.Generic;


namespace StudentsOrder
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] initialInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int students = initialInput[0];
            int seatChanges = initialInput[1];
            var studentSeating = new LinkedList<string>(Console.ReadLine().Split(' '));
            for (int seatChange = 0; seatChange < seatChanges; seatChange++)
            {
                var newSeating = Console.ReadLine().Split(' ');
                string studentOne = newSeating[0];
                string studentTwo = newSeating[1];
                var moveBeforeNode = studentSeating.Find(studentTwo);
                studentSeating.Remove(studentOne);
                var studentOneNode = new LinkedListNode<string>(studentOne);
                studentSeating.AddBefore(moveBeforeNode, studentOneNode);

            }
            Console.WriteLine(string.Join(" ", studentSeating));
        }
    }
}