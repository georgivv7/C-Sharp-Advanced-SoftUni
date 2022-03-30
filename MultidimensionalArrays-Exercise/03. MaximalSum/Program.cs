using System;
using System.Linq;

namespace _03._MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int columns = 0; columns < rowsAndColumns[1]; columns++)
                {
                    matrix[rows, columns] = input[columns];
                }
            }

            
            int biggestSum = 0;
            int firstRowValue = 0;
            int firstColValue = 0;
            int firstRowSecondColValue = 0;
            int secondRowValue = 0;
            int secondRowColValue = 0;
            int secondRowSecondColValue = 0;
            int thirdRowValue = 0;
            int thirdROwColValue = 0;
            int thirdROwSecondColValue = 0;


            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    int currentSum = 0;
                    currentSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row+1,col] + matrix[row+1,col+1] + matrix[row+1,col+2]
                        + matrix[row+2, col] + matrix[row+2, col+1] + matrix[row+2,col+2];

                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        firstRowValue = matrix[row, col];
                        firstColValue = matrix[row, col + 1];
                        firstRowSecondColValue = matrix[row, col + 2];
                        secondRowValue = matrix[row + 1, col];
                        secondRowColValue = matrix[row + 1, col + 1];
                        secondRowSecondColValue = matrix[row + 1, col + 2];
                        thirdRowValue = matrix[row + 2, col];
                        thirdROwColValue = matrix[row + 2, col + 1];
                        thirdROwSecondColValue = matrix[row + 2, col + 2];
                    }
                }
            }
            Console.WriteLine($"Sum = {biggestSum}");
            Console.WriteLine($"{firstRowValue} {firstColValue} {firstRowSecondColValue}");
            Console.WriteLine($"{secondRowValue} {secondRowColValue} {secondRowSecondColValue}");
            Console.WriteLine($"{thirdRowValue} {thirdROwColValue} {thirdROwSecondColValue}");
        }
    }
}
