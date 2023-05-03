using System;

using System.Linq;


namespace Jumps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elements = int.Parse(Console.ReadLine());
            var elementsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var outputValues = new int[elements];
            
            for (int index = 0; index < elements; index++)
            {
                for (int previousIndex = index-1; previousIndex >=0; previousIndex--)
                {
                    int currentNumber = elementsInput[index];
                    int previousNumber = elementsInput[previousIndex];
                    if (previousNumber >= currentNumber)
                    {
                        break;
                    }
                    outputValues[previousIndex]++;
                }
            }

            Console.WriteLine(outputValues.Max());
            string output = String.Join(" ", outputValues);
            Console.WriteLine(output);
        }
    }
}