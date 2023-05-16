using System;
using System.Collections.Generic;
using System.Linq;


namespace SmallWorld
{
    internal class Program
    {
        static int currentConquest = 0;
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int rows = int.Parse(input[0]);
            int columns = int.Parse(input[1]);
            var field = new int[rows, columns];
            List<int> conquests = new List<int>();

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int column = 0; column < columns; column++)
                {
                    field[row, column] = currentRow[column] - '0';
                }
            }
            for (int row = 0; row < rows; row++)
            {             
                
                for (int column = 0; column < columns; column++)
                {                    
                    if (field[row,column] == 0)
                    {
                        continue;
                    }
                    currentConquest = 0;
                    Search(field, row, column);
                    conquests.Add(currentConquest);
                }
                
            }
            conquests = conquests.OrderByDescending(conquest => conquest).ToList();
            foreach (var conquest in conquests)
            {
                Console.WriteLine(conquest);
            }
        }
        static void Search(int[,] field, int row, int column)
        {
            if (row <0 || row > field.GetLength(0)-1 || column < 0 || column > field.GetLength(1)-1)
            {
                return;
            }
            if (field[row,column] == 0)
            {
                return;
            }
            currentConquest++;
            field[row, column] = 0;
            Search(field, row, column-1);
            Search(field, row, column+1);
            Search(field, row-1, column);
            Search(field, row+1, column);
        }
    }
}