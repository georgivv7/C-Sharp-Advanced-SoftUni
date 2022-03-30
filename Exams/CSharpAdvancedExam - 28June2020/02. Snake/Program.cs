using System;
using System.Collections.Generic;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            int currentRow = 0;
            int currentCol = 0;
            int foodQuantity = 0;
            List<int> burrowsInfo = new List<int>();
            char[,] field = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (input[col] == 'B')
                    {
                        burrowsInfo.Add(row);
                        burrowsInfo.Add(col);
                    }
                }
            }
            while (true)
            {
                if (foodQuantity == 10)
                {
                    break;
                }
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        currentRow--;
                        if (currentRow >= 0 && currentRow < rows)
                        {
                            if (field[currentRow, currentCol] == '*')
                            {
                                foodQuantity++;
                                field[++currentRow, currentCol] = '.';
                                field[--currentRow, currentCol] = 'S';
                            }
                            else if (field[currentRow, currentCol] == '-')
                            {
                                field[++currentRow, currentCol] = '.';
                                field[--currentRow, currentCol] = 'S';
                            }
                            else if (field[currentRow, currentCol] == 'B')
                            {
                                field[++currentRow, currentCol] = '.';
                                field[--currentRow, currentCol] = '.';
                                if (currentRow == burrowsInfo[0] && currentCol == burrowsInfo[1])
                                {
                                    currentRow = burrowsInfo[2];
                                    currentCol = burrowsInfo[3];
                                    field[currentRow, currentCol] = 'S';
                                }
                                else
                                {
                                    currentRow = burrowsInfo[0];
                                    currentCol = burrowsInfo[1];
                                    field[currentRow, currentCol] = 'S';
                                }
                            }

                        }
                        else
                        {
                            field[++currentRow, currentCol] = '.';
                            Console.WriteLine("Game over!");
                            Console.WriteLine($"Food eaten: {foodQuantity}");
                            PrintMatrix(field);
                            Environment.Exit(0);
                        }
                        break;
                    case "down":
                        currentRow++;
                        if (currentRow >= 0 && currentRow < rows)
                        {
                            if (field[currentRow, currentCol] == '*')
                            {
                                foodQuantity++;
                                field[--currentRow, currentCol] = '.';
                                field[++currentRow, currentCol] = 'S';
                            }
                            else if (field[currentRow, currentCol] == '-')
                            {
                                field[--currentRow, currentCol] = '.';
                                field[++currentRow, currentCol] = 'S';
                            }
                            else if (field[currentRow, currentCol] == 'B')
                            {
                                field[--currentRow, currentCol] = '.';
                                field[++currentRow, currentCol] = '.';
                                if (currentRow == burrowsInfo[0] && currentCol == burrowsInfo[1])
                                {
                                    currentRow = burrowsInfo[2];
                                    currentCol = burrowsInfo[3];
                                    field[currentRow, currentCol] = 'S';
                                }
                                else
                                {
                                    currentRow = burrowsInfo[0];
                                    currentCol = burrowsInfo[1];
                                    field[currentRow, currentCol] = 'S';
                                }
                            }
                        }
                        else
                        {
                            field[--currentRow, currentCol] = '.';
                            Console.WriteLine("Game over!");
                            Console.WriteLine($"Food eaten: {foodQuantity}");
                            PrintMatrix(field);
                            Environment.Exit(0);
                        }
                        break;
                    case "left":
                        currentCol--;
                        if (currentCol >= 0 && currentCol < cols)
                        {
                            if (field[currentRow, currentCol] == '*')
                            {
                                foodQuantity++;
                                field[currentRow, ++currentCol] = '.';
                                field[currentRow, --currentCol] = 'S';
                            }
                            else if (field[currentRow, currentCol] == '-')
                            {
                                field[currentRow, ++currentCol] = '.';
                                field[currentRow, --currentCol] = 'S';
                            }
                            else if (field[currentRow, currentCol] == 'B')
                            {
                                field[currentRow, ++currentCol] = '.';
                                field[currentRow, --currentCol] = '.';
                                if (currentRow == burrowsInfo[0] && currentCol == burrowsInfo[1])
                                {
                                    currentRow = burrowsInfo[2];
                                    currentCol = burrowsInfo[3];
                                    field[currentRow, currentCol] = 'S';
                                }
                                else
                                {
                                    currentRow = burrowsInfo[0];
                                    currentCol = burrowsInfo[1];
                                    field[currentRow, currentCol] = 'S';
                                }
                            }
                        }
                        else
                        {
                            field[currentRow, ++currentCol] = '.';
                            Console.WriteLine("Game over!");
                            Console.WriteLine($"Food eaten: {foodQuantity}");
                            PrintMatrix(field);
                            Environment.Exit(0);
                        }
                        break;
                    case "right":
                        currentCol++;
                        if (currentCol >= 0 && currentCol < cols)
                        {
                            if (field[currentRow, currentCol] == '*')
                            {
                                foodQuantity++;
                                field[currentRow, --currentCol] = '.';
                                field[currentRow, ++currentCol] = 'S';
                            }
                            else if (field[currentRow, currentCol] == '-')
                            {
                                field[currentRow, --currentCol] = '.';
                                field[currentRow, ++currentCol] = 'S';
                            }
                            else if (field[currentRow, currentCol] == 'B')
                            {
                                field[currentRow, --currentCol] = '.';
                                field[currentRow, ++currentCol] = '.';
                                if (currentRow == burrowsInfo[0] && currentCol == burrowsInfo[1])
                                {
                                    currentRow = burrowsInfo[2];
                                    currentCol = burrowsInfo[3];
                                    field[currentRow, currentCol] = 'S';
                                }
                                else
                                {
                                    currentRow = burrowsInfo[0];
                                    currentCol = burrowsInfo[1];
                                    field[currentRow, currentCol] = 'S';
                                }
                            }
                        }
                        else
                        {
                            field[currentRow, --currentCol] = '.';
                            Console.WriteLine("Game over!");
                            Console.WriteLine($"Food eaten: {foodQuantity}");
                            PrintMatrix(field);
                            Environment.Exit(0);
                        }
                        break;

                }
            }
            if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodQuantity}");
                PrintMatrix(field);
            }


            void PrintMatrix(char[,] field)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write($"{field[row, col]}");
                    }
                    Console.WriteLine();
                }
            }

        }


    }
}
