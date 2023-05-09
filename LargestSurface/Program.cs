using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrooge_McDuck
{
    internal class Program
    {
        static int highestCount = 0;
        static int currentCount = 0;
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] vault = new int[rows, cols];
            
            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    vault[row, col] = values[col];
                    
                }
            }

            for (int row = 0; row < rows; row++)
            {                
                for (int col = 0; col < cols; col++)
                {
                    if (vault[row,col] == int.MinValue)
                    {
                        continue;
                    }
                    
                    Explore(vault, row, col, vault[row, col]);
                    if (currentCount > highestCount)
                    {
                        highestCount = currentCount;
                    }
                    currentCount = 0;
                }
            }


            Console.WriteLine(highestCount);

        }
        static void Explore(int[,] vault, int row, int col, int element)
        {
            if (vault[row, col] != int.MinValue)
            {
                currentCount++;
                vault[row, col] = int.MinValue;
            }

            bool leftInvalid = col - 1 < 0 || vault[row, col - 1] == 0;
            bool rightInvalid = col + 1 >= vault.GetLength(1) || vault[row, col + 1] == 0;
            bool upInvalid = row - 1 < 0 || vault[row - 1, col] == 0;
            bool downInvalid = row + 1 >= vault.GetLength(0) || vault[row + 1, col] == 0;

            if (leftInvalid && rightInvalid && upInvalid && downInvalid)
            {
                return;
            }

            if (!leftInvalid)
            {                
                if (vault[row, col - 1] == element)
                {
                    Explore(vault, row, col -1, element);
                }
            }
            if (!rightInvalid)
            {
                
                if (vault[row, col + 1] == element)
                {
                    Explore(vault, row, col + 1, element);
                }
            }
            if (!upInvalid)
            {
                if (vault[row-1, col] == element)
                {
                    Explore(vault, row-1, col, element);
                }
            }
            if (!downInvalid)
            {
                if (vault[row + 1, col] == element)
                {
                    Explore(vault, row + 1, col, element);
                }
            }

           

        }
    }
}
