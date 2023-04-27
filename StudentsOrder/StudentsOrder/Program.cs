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
            int studentsCount = initialInput[0];
            int seatChanges = initialInput[1];
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("misho", "gosho");
            dictionary.Add("gosho", "penka");
            var byKeyvalue = dictionary.First(pair => pair.Key == "misho");
            var pair = new dicti byKeyvalue.Value = "pesho";
            var students = Console.ReadLine().Split(' ').ToArray();
            int keys = 1;
            var items = from pair in dictionary
            LinkedListNode<string> previousNode = null;
            foreach (var item in students)
            {
                var node = new LinkedListNode<string>(item);
                node.Previous = previousNode;
                dictionary.Add(keys, node);
            }
            for (int seatChange = 0; seatChange < seatChanges; seatChange++)
            {
                var newSeating = Console.ReadLine().Split(' ');
                string studentOne = newSeating[0];
                string studentTwo = newSeating[1];
                var moveBeforeNode = students.Find(studentTwo);
                students.Remove(studentOne);
                var studentOneNode = new LinkedListNode<string>(studentOne);
                students.AddBefore(moveBeforeNode, studentOneNode);

            }
            Console.WriteLine(string.Join(" ", students));
        }
    }
}