using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = data[0];
            int columns = data[1];
            char[,] matrix = new char[rows, columns];
            string snake = Console.ReadLine();
            Queue<char> snakeLength = new Queue<char>(snake.ToArray());
            for (int row = 0; row < rows; row++)
            {               
                for (int col = 0; col < columns; col++)
                {
                    if (row % 2 == 0)
                    {
                        char currentSymbol = snakeLength.Dequeue();
                        snakeLength.Enqueue(currentSymbol);
                        matrix[row, col] = currentSymbol;
                    }
                    else if (row % 2 != 0)
                    {
                        for (int j = columns-1; j >= 0; j--)
                        {
                            char currentSymbol = snakeLength.Dequeue();
                            snakeLength.Enqueue(currentSymbol);
                            matrix[row, j] = currentSymbol;
                        }
                        break;
                    }
                                     
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
