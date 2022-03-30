using System;

namespace _02._ReVolt
{
    class Program
    {
        static char[,] matrix;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());
            int cols = rows;
            matrix = new char[rows, cols];
            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'f')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }
            for (int turn = 1; turn <= countCommands; turn++)
            {
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        currentRow--;
                        if (currentRow < 0)
                        {
                            currentRow = matrix.GetLength(0) - 1;
                            matrix[currentRow, currentCol] = 'f';
                            matrix[0, currentCol] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == '-')
                        {
                            matrix[currentRow, currentCol] = 'f';
                            matrix[++currentRow, currentCol] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == 'B')
                        {
                            matrix[--currentRow, currentCol] = 'f';
                            matrix[currentRow + 2, currentCol] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == 'T')
                        {
                            matrix[++currentRow, currentCol] = 'f';
                        }
                        else if (matrix[currentRow, currentCol] == 'F')
                        {
                            matrix[currentRow, currentCol] = 'f';
                            matrix[++currentRow, currentCol] = '-';
                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                        break;
                    case "down":
                        currentRow++;
                        if (currentRow == matrix.GetLength(0))
                        {
                            currentRow = 0;
                            matrix[currentRow, currentCol] = 'f';
                            matrix[matrix.Length - 1, currentCol] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == '-')
                        {
                            matrix[currentRow, currentCol] = 'f';
                            matrix[--currentRow, currentCol] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == 'B')
                        {
                            matrix[++currentRow, currentCol] = 'f';
                            matrix[currentRow - 2, currentCol] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == 'T')
                        {
                            matrix[--currentRow, currentCol] = 'f';
                        }
                        else if (matrix[currentRow, currentCol] == 'F')
                        {
                            matrix[currentRow, currentCol] = 'f';
                            matrix[--currentRow, currentCol] = '-';
                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                        break;
                    case "left":
                        currentCol--;
                        bool isValid = CheckValid(matrix, currentRow, currentCol);
                        if (isValid==false)
                        {                           
                            currentCol = matrix.GetLength(1) - 1;
                            matrix[currentRow, currentCol] = 'f';
                            matrix[currentRow, 0] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == '-')
                        {
                            matrix[currentRow, currentCol] = 'f';
                            matrix[currentRow, ++currentCol] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == 'B')
                        {
                            matrix[currentRow, --currentCol] = 'f';
                            matrix[currentRow, 0] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == 'T')
                        {
                            matrix[currentRow, ++currentCol] = 'f';
                        }
                        else if (matrix[currentRow, currentCol] == 'F')
                        {
                            matrix[currentRow, currentCol] = 'f';
                            matrix[currentRow, ++currentCol] = '-';
                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                        break;
                    case "right":
                        currentCol++;
                        if (currentCol == matrix.GetLength(1))
                        {
                            currentCol = 0;
                            matrix[currentRow, currentCol] = 'f';
                            matrix[currentRow, matrix.GetLength(1) - 1] = 'f';
                        }
                        else if (matrix[currentRow, currentCol] == '-')
                        {
                            matrix[currentRow, currentCol] = 'f';
                            matrix[currentRow, --currentCol] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == 'B')
                        {
                            matrix[currentRow, ++currentCol] = 'f';
                            matrix[currentRow, currentCol-2] = '-';
                        }
                        else if (matrix[currentRow, currentCol] == 'T')
                        {
                            matrix[currentRow, --currentCol] = 'f';
                        }
                        else if (matrix[currentRow, currentCol] == 'F')
                        {
                            matrix[currentRow, currentCol] = 'f';
                            matrix[currentRow, --currentCol] = '-';
                            Console.WriteLine("Player won!");
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }                        
                        break;
                }
            }
            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
        }

        private static bool CheckValid(char[,] matrix, int currentRow, int currentCol)
        {
            return currentRow >= 0 && currentCol >= 0 && currentRow < matrix.GetLength(0)
                && currentCol < matrix.GetLength(1);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
