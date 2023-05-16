using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int firstNumber = int.Parse(input[0]);
            int nthNumber = int.Parse(input[1]);
            int[] numbers = new int[nthNumber];
            
            if (nthNumber == 1)
            {
                Console.WriteLine(firstNumber);
                return;
            }
            
            else if (nthNumber == 2)
            {
                Console.WriteLine(firstNumber + 1);
                return;
            }
            
            else if (nthNumber == 3)
            {
                Console.WriteLine(firstNumber * 2 + 1);
                return;
            }
            else if (nthNumber == 4)
            {
                Console.WriteLine(firstNumber + 2);
                return;
            }
            numbers[0] = firstNumber;
            numbers[1] = firstNumber + 1;
            numbers[2] = firstNumber * 2 + 1;
            numbers[3] = firstNumber + 2;
            int iterationCounter = 1;            
            int caseIndex = 1;
            for (int index = 4; index < nthNumber; index++)
            {                
                if (caseIndex == 1)
                {
                    numbers[index] = numbers[iterationCounter] + 1;
                    caseIndex++;
                }
                else if (caseIndex == 2)
                {
                    numbers[index] = numbers[iterationCounter] * 2 + 1;
                    caseIndex++;
                }
                else if (caseIndex == 3)
                {
                    numbers[index] = numbers[iterationCounter] + 2;
                    caseIndex = 1;
                    iterationCounter++;
                }
                
            }
            Console.WriteLine(numbers[nthNumber-1]);

        }
        
    }
}