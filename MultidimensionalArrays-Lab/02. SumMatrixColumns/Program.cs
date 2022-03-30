using System;
using System.Linq;

namespace _02._SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsAndColumns = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int row = 0; row < rowsAndColumns[0]; row++)
            {
                var rowValue = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < rowsAndColumns[1]; col++)
                {
                    matrix[row, col] = rowValue[col];
                }
            }


            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
