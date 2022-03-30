using System;

namespace _04._SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int rowIndex = 0;
            int columnIndex = 0;

            for (int row = 0; row < n; row++)
            {
                var symbols = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    char currentChar = matrix[rows, columns];
                    if (currentChar == symbol)
                    {
                        rowIndex = rows;
                        columnIndex = columns;
                        Console.WriteLine($"({rowIndex}, {columnIndex})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");

        }
    }
}
