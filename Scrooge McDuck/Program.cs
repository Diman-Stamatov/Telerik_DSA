using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrooge_McDuck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] vault = new int[rows, cols];
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    vault[row, col] = values[col];
                    if (values[col] == 0)
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            
        }
    }
}
