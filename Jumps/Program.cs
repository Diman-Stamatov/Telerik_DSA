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

            int[] sortedElements = elementsInput.OrderByDescending(number => number).ToArray();
            int highestValueIndex = 0;
            int currentValue = 0;
            int jumpSequence = 0;
            int highestValue = sortedElements[highestValueIndex];
            for (int index = 0; index < elements; index++)
            {
                
                currentValue = elementsInput[index];
                if (currentValue == highestValue)
                {
                    if (highestValueIndex != elements - 1)
                    {
                        highestValueIndex++;
                    }

                    highestValue = sortedElements[highestValueIndex];
                    outputValues[index] = 0;
                    continue;
                }

                for (int element = index + 1; element < elements; element++)
                {
                    
                    if (elementsInput[element] > currentValue)
                    {
                        currentValue = elementsInput[element];
                        jumpSequence++;
                    }
                    if (currentValue == highestValue)
                    {
                        break;
                    }
                }

                outputValues[index] = jumpSequence;
                jumpSequence = 0;
            }

            Console.WriteLine(outputValues.Max());
            string output = String.Join(" ", outputValues);
            Console.WriteLine(output);
        }
    }
}