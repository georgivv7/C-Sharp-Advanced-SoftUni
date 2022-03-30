using System;
using System.Linq;

namespace _04._MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndColumns = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = rowsAndColumns[0];
            int columns = rowsAndColumns[1];
            string[,] matrix = new string[rows,columns];
            for (int row = 0; row < rowsAndColumns[0]; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < rowsAndColumns[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "END")
            {
                string[] data = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                if (command == "swap" && data.Length == 5)
                {
                    int row1 = int.Parse(data[1]);
                    int col1 = int.Parse(data[2]);
                    int row2 = int.Parse(data[3]);
                    int col2 = int.Parse(data[4]);

                    if (row1 >= 0 && row1 < rows  && col1 >= 0 && col1 < columns &&
                        row2 >= 0 && row2 < rows && col2 >= 0 && col2 < columns)
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
