using System;
using System.Linq;

namespace _02._SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < rowsAndColumns[1]; col++)
                {
                    matrix[rows, col] = input[col];
                }
            }
            int squareMatrix = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char firstChar = matrix[rows, col];
                    char secondChar = matrix[rows, col + 1];
                    char thirdChar = matrix[rows + 1, col];
                    char fourthChar = matrix[rows + 1, col + 1];
                    if (firstChar.Equals(secondChar) && secondChar.Equals(thirdChar) 
                        && thirdChar.Equals(fourthChar))
                    {
                        squareMatrix++;
                    }
                }
            }

            if (squareMatrix > 0)
            {
                Console.WriteLine(squareMatrix);
            }
            else
            {
                Console.WriteLine(squareMatrix);
            }
        }
    }
}
