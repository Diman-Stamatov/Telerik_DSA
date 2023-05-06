using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrooge_McDuck
{
    internal class Program
    {
        static int coins = 0;
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
            Explore(vault, startRow, startCol);
            Console.WriteLine(coins);

        }
        static void Explore(int[,] vault, int row, int col)
        {
            if (vault[row, col] != 0)
            {
                coins++;
                vault[row, col]--;
            }

            bool leftInvalid = col - 1 < 0 || vault[row, col - 1] == 0;
            bool rightInvalid = col + 1 >= vault.GetLength(1) || vault[row, col + 1] == 0;
            bool upInvalid = row - 1 < 0 || vault[row-1, col] == 0;
            bool downInvalid = row + 1 >= vault.GetLength(0) || vault[row+1, col] == 0;

            if (leftInvalid && rightInvalid && upInvalid && downInvalid)
            {
                return;
            }

            
            int highestCoins = 0;
            int left = 0;
            int right = 0;
            int up = 0;
            int down = 0;

            if (!leftInvalid)
            {
                left = vault[row,col-1];
                if (left > highestCoins)
                {
                    highestCoins = left;    
                }
            }
            if (!rightInvalid) 
            { 
                right = vault[row,col+1];
                if (right > highestCoins)
                {
                    highestCoins = right;
                }
            }
            if (!upInvalid) 
            { 
                up = vault[row-1,col];
                if (up > highestCoins)
                {
                    highestCoins = up;
                }
            }
            if (!downInvalid)
            {
                down = vault[row + 1, col];
                if (down > highestCoins)
                {
                    highestCoins = down;
                }
            }
            
            if (highestCoins == left)
            {
                Explore(vault, row, col - 1);
            }
            else if (highestCoins == right) 
            {
                Explore(vault, row, col + 1);
            }
            else if (highestCoins == up)
            {
                Explore(vault, row-1, col);
            }
            else 
            {
                Explore(vault, row + 1, col);
            }

        }
    }
}
