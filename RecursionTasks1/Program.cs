using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursionTasks1
{
    internal class Program
    {
        
        
        static void Main()
        {
            int[] input = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int index=int.Parse(Console.ReadLine());
            
            string output = ElevensCount(input, index);

            Console.WriteLine(string.Join("", output));

        }
        static string ElevensCount(int[] input, int index)
        {
            if (index == input.Length-1)
            {
                return "false";
            }

            if (input[index+1] == input[index]*10)
            {
                return "true";
            }
            else
            {
                return ElevensCount(input, index + 1);
            }
        }
    }
}
