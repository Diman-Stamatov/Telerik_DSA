using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int elements = int.Parse(Console.ReadLine());
            var elementsInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var outputValues = new int[elements];
            int longestSequence = 0;
            int[] sortedElements = elementsInput.OrderByDescending(number => number).ToArray();
            int highestValueIndex = 0;
            int highestValue = sortedElements[highestValueIndex];
            for (int index = 0; index < elements; index++)
            {
                int currentPosition = elementsInput[index];

                if (currentPosition == highestValueIndex)
                {
                    highestValueIndex++;
                    highestValue = sortedElements[highestValueIndex];
                    outputValues[index] = 0;
                    continue;
                }



                int jumpSequence = 0;
                for (int element = index + 1; element < elements; element++)
                {


                    if (elementsInput[element] > currentPosition)
                    {
                        currentPosition = elementsInput[element];
                        jumpSequence++;
                    }
                    if (currentPosition == highestValue)
                    {
                        break;

                    }

                }
                if (longestSequence < jumpSequence)
                {
                    longestSequence = jumpSequence;
                }

                outputValues[index] = jumpSequence;



            }

            Console.WriteLine(longestSequence);
            string output = String.Join(" ", outputValues);
            Console.WriteLine(output);
        }
    }
}