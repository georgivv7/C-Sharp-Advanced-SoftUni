using System;
using System.Linq;

namespace _05._SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int columns = 0; columns < rowsAndColumns[1]; columns++)
                {
                    matrix[rows, columns] = input[columns];
                }
            }

            int sum = 0;
            int currentSum = 0;
            int firstRowValue = 0;
            int secondRowValue = 0;
            int firstColumnValue = 0;
            int secondColumnValue = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currentSum = 0;
                    currentSum += matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        firstRowValue = matrix[row, col];
                        secondRowValue = matrix[row + 1, col];
                        firstColumnValue = matrix[row, col + 1];
                        secondColumnValue = matrix[row + 1, col + 1];
                    }
                }
            }

            Console.WriteLine($"{firstRowValue} {firstColumnValue}");
            Console.WriteLine($"{secondRowValue} {secondColumnValue}");
            Console.WriteLine(sum);
        }
    }
}
