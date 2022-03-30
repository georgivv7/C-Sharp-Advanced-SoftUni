using System;
using System.Linq;

namespace _10._RadioactiveMutantVampire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int rows = int.Parse(data[0]);
            int cols = int.Parse(data[1]);
            char[,] field = new char[rows, cols];
            int startRow = 0;
            int startCol = 0;
            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];
                    if (field[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            string commands = Console.ReadLine();
            currentRow = startRow;
            currentCol = startCol;
            bool isDead = false;
            bool isWinner = false;

            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'U':
                        field[currentRow, currentCol] = '.';
                        if (currentRow - 1 >= 0 && currentRow - 1 < field.GetLength(0)
                            && currentCol >= 0 && currentCol < field.GetLength(1))
                        {
                            if (field[currentRow - 1, currentCol] == 'B')
                            {
                                currentRow--;
                                isDead = true;
                            }
                            else if (field[currentRow - 1, currentCol] == '.')
                            {
                                field[currentRow - 1, currentCol] = 'P';
                                currentRow--;
                            }
                        }
                        else
                        {
                            isWinner = true;
                        }
                        break;
                    case 'D':
                        field[currentRow, currentCol] = '.';
                        if (currentRow + 1 >= 0 && currentRow + 1 < field.GetLength(0)
                            && currentCol >= 0 && currentCol < field.GetLength(1))
                        {
                            if (field[currentRow + 1, currentCol] == 'B')
                            {
                                currentRow++;
                                isDead = true;
                            }
                            else if (field[currentRow + 1, currentCol] == '.')
                            {
                                field[currentRow + 1, currentCol] = 'P';
                                currentRow++;
                            }
                        }
                        else
                        {
                            isWinner = true;
                        }
                        break;
                    case 'L':
                        field[currentRow, currentCol] = '.';
                        if (currentRow >= 0 && currentRow < field.GetLength(0)
                            && currentCol - 1 >= 0 && currentCol - 1 < field.GetLength(1))
                        {
                            if (field[currentRow, currentCol - 1] == 'B')
                            {
                                currentCol--;
                                isDead = true;
                            }
                            else if (field[currentRow, currentCol - 1] == '.')
                            {
                                field[currentRow, currentCol - 1] = 'P';
                                currentCol--;
                            }
                        }
                        else
                        {
                            isWinner = true;
                        }
                        break;
                    case 'R':
                        field[currentRow, currentCol] = '.';
                        if (currentRow >= 0 && currentRow < field.GetLength(0)
                            && currentCol + 1 >= 0 && currentCol + 1 < field.GetLength(1))
                        {
                            if (field[currentRow, currentCol + 1] == 'B')
                            {
                                isDead = true;
                                currentCol++;
                            }
                            else if (field[currentRow, currentCol + 1] == '.')
                            {
                                field[currentRow, currentCol + 1] = 'P';
                                currentCol++;
                            }
                        }
                        else
                        {
                            isWinner = true;
                        }
                        break;
                }
                int bunnyRow = 0;
                int bunnyCol = 0;
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        if (field[row, col] == 'B')
                        {
                            bunnyRow = row;
                            bunnyCol = col;
                            if (row - 1 >= 0 && row - 1 < field.GetLength(0)
                                && col >= 0 && col < field.GetLength(1))
                            {
                                if (field[bunnyRow - 1, bunnyCol] == '.')
                                {
                                    field[bunnyRow - 1, col] = 'b';
                                }
                                else if (field[bunnyRow - 1, bunnyCol] == 'P')
                                {
                                    field[bunnyRow - 1, col] = 'b';
                                    isDead = true;
                                }
                            }
                            if (row + 1 >= 0 && row + 1 < field.GetLength(0)
                                && col >= 0 && col < field.GetLength(1))
                            {
                                if (field[bunnyRow + 1, col] == '.')
                                {
                                    field[bunnyRow + 1, col] = 'b';
                                }
                                else if (field[bunnyRow + 1, col] == 'P')
                                {
                                    field[bunnyRow + 1, col] = 'b';
                                    isDead = true;
                                }
                            }
                            if (row >= 0 && row < field.GetLength(0)
                                && col - 1 >= 0 && col - 1 < field.GetLength(1))
                            {
                                if (field[row, bunnyCol - 1] == '.')
                                {
                                    field[row, bunnyCol - 1] = 'b';
                                }
                                else if (field[row, bunnyCol - 1] == 'P')
                                {
                                    field[row, bunnyCol - 1] = 'b';
                                    isDead = true;
                                }
                            }
                            if (row >= 0 && row < field.GetLength(0)
                                && col + 1 >= 0 && col + 1 < field.GetLength(1))
                            {
                                if (field[row, bunnyCol + 1] == '.')
                                {
                                    field[row, bunnyCol + 1] = 'b';
                                }
                                else if (field[row, bunnyCol + 1] == 'P')
                                {
                                    field[row, bunnyCol] = 'b';
                                    isDead = true;
                                }
                            }
                        }
                    }
                }
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        if (field[row, col] == 'b')
                        {
                            field[row, col] = 'B';
                        }
                    }
                }
                if (isWinner || isDead)
                {
                    break;
                }
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]}");
                }
                Console.WriteLine();
            }
            if (isDead)
            {
                Console.WriteLine($"dead: {currentRow} {currentCol}");
            }
            else if (isWinner)
            {
                Console.WriteLine($"won: {currentRow} {currentCol}");
            }

        }
    }
}
