using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var rowColPair in coordinates)
            {
                int[] bombsCoordinates = rowColPair.Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int currentBombRow = bombsCoordinates[0];
                int currentBombCol = bombsCoordinates[1];
                int currentBomb = matrix[currentBombRow, currentBombCol];

                for (int row = currentBombRow - 1; row <= currentBombRow + 1; row++)
                {
                    for (int col = currentBombCol - 1; col <= currentBombCol + 1; col++)
                    {
                        if ((row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)))
                        {
                            if (matrix[row, col] <= 0 || currentBomb < 0)
                            {
                                continue;
                            }
                            matrix[row, col] -= currentBomb;
                        }

                    }
                }

            }
            int aliveCells = 0;
            int sumAliveCells = 0;
            foreach (int cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sumAliveCells += cell;
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
