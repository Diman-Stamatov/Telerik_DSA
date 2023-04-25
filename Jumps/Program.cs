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
            var elementsInput = new LinkedList<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToList());                       
            var outputValues = new List<int>();
            int longestSequence = 0;
            
            while (elementsInput.Count > 0)
            {
                int currentPosition = elementsInput.First();
                elementsInput.RemoveFirst();                
                int jumpSequence = 0;
                
                foreach (var element in elementsInput)
                {
                    
                    if (element > currentPosition)
                    {
                        currentPosition = element;
                        jumpSequence++;
                    }
                    
                }
                if (longestSequence < jumpSequence)
                {
                    longestSequence = jumpSequence;
                }
                outputValues.Add(jumpSequence);
            }
            Console.WriteLine(longestSequence);
            string outputString = String.Join(" ", outputValues.ToArray());
            Console.WriteLine(outputString);
        }
    }
}
