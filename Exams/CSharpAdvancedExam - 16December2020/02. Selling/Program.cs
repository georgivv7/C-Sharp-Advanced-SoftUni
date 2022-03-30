using System;
using System.Collections.Generic;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            int currentRow = 0;
            int currentCol = 0;
            char[,] field = new char[rows, cols];
            List<int> pillars = new List<int>();
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
                    else if (input[col] == 'O')
                    {
                        pillars.Add(row);
                        pillars.Add(col);
                    }
                }
            }
            int collectedMoney = 0;
            while (true)
            {
                if (collectedMoney >= 50)
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
                            if (field[currentRow, currentCol] == 'O')
                            {
                                if (pillars[0] == currentRow && pillars[1] == currentCol)
                                {
                                    field[++currentRow, currentCol] = '-';
                                    field[--currentRow, currentCol] = '-';
                                    currentRow = pillars[2];
                                    currentCol = pillars[3];
                                    field[currentRow, currentCol] = 'S';
                                }
                                else
                                {
                                    field[++currentRow, currentCol] = '-';
                                    field[--currentRow, currentCol] = '-';
                                    currentRow = pillars[0];
                                    currentCol = pillars[1];
                                    field[currentRow, currentCol] = 'S';
                                }
                            }
                            else if (field[currentRow, currentCol] == '-')
                            {
                                field[++currentRow, currentCol] = '-';
                                field[--currentRow, currentCol] = 'S';
                            }
                            else if (char.IsDigit(field[currentRow, currentCol]))
                            {
                                collectedMoney += int.Parse(field[currentRow, currentCol].ToString());
                                field[++currentRow, currentCol] = '-';
                                field[--currentRow, currentCol] = 'S';
                            }
                        }
                        else
                        {
                            field[++currentRow, currentCol] = '-';
                            Console.WriteLine("Bad news, you are out of the bakery.");
                            Console.WriteLine($"Money: {collectedMoney}");
                            PrintMatrix(field);
                            Environment.Exit(0);
                        }
                        break;
                    case "down":
                        currentRow++;
                        if (currentRow >= 0 && currentRow < rows)
                        {
                            if (field[currentRow, currentCol] == 'O')
                            {
                                if (pillars[0] == currentRow && pillars[1] == currentCol)
                                {
                                    field[--currentRow, currentCol] = '-';
                                    field[++currentRow, currentCol] = '-';
                                    currentRow = pillars[2];
                                    currentCol = pillars[3];
                                    field[currentRow, currentCol] = 'S';
                                }
                                else
                                {
                                    field[--currentRow, currentCol] = '-';
                                    field[++currentRow, currentCol] = '-';
                                    currentRow = pillars[0];
                                    currentCol = pillars[1];
                                    field[currentRow, currentCol] = 'S';
                                }
                            }
                            else if (field[currentRow, currentCol] == '-')
                            {
                                field[--currentRow, currentCol] = '-';
                                field[++currentRow, currentCol] = 'S';
                            }
                            else if (char.IsDigit(field[currentRow, currentCol]))
                            {
                                collectedMoney += int.Parse(field[currentRow, currentCol].ToString());
                                field[--currentRow, currentCol] = '-';
                                field[++currentRow, currentCol] = 'S';
                            }
                        }
                        else
                        {
                            field[--currentRow, currentCol] = '-';
                            Console.WriteLine("Bad news, you are out of the bakery.");
                            Console.WriteLine($"Money: {collectedMoney}");
                            PrintMatrix(field);
                            Environment.Exit(0);
                        }
                        break;
                    case "left":
                        currentCol--;
                        if (currentCol >= 0 && currentCol < cols)
                        {
                            if (field[currentRow, currentCol] == 'O')
                            {
                                if (pillars[0] == currentRow && pillars[1] == currentCol)
                                {
                                    field[currentRow, ++currentCol] = '-';
                                    field[currentRow, --currentCol] = '-';
                                    currentRow = pillars[2];
                                    currentCol = pillars[3];
                                    field[currentRow, currentCol] = 'S';
                                }
                                else
                                {
                                    field[currentRow, ++currentCol] = '-';
                                    field[currentRow, --currentCol] = '-';
                                    currentRow = pillars[0];
                                    currentCol = pillars[1];
                                    field[currentRow, currentCol] = 'S';
                                }
                            }
                            else if (field[currentRow, currentCol] == '-')
                            {
                                field[currentRow, ++currentCol] = '-';
                                field[currentRow, --currentCol] = 'S';
                            }
                            else if (char.IsDigit(field[currentRow, currentCol]))
                            {
                                collectedMoney += int.Parse(field[currentRow, currentCol].ToString());
                                field[currentRow, ++currentCol] = '-';
                                field[currentRow, --currentCol] = 'S';
                            }
                        }
                        else
                        {
                            field[currentRow, ++currentCol] = '-';
                            Console.WriteLine("Bad news, you are out of the bakery.");
                            Console.WriteLine($"Money: {collectedMoney}");
                            PrintMatrix(field);
                            Environment.Exit(0);
                        }
                        break;
                    case "right":
                        currentCol++;
                        if (currentCol >= 0 && currentCol < cols)
                        {
                            if (field[currentRow, currentCol] == 'O')
                            {
                                if (pillars[0] == currentRow && pillars[1] == currentCol)
                                {
                                    field[currentRow, --currentCol] = '-';
                                    field[currentRow, ++currentCol] = '-';
                                    currentRow = pillars[2];
                                    currentCol = pillars[3];
                                    field[currentRow, currentCol] = 'S';
                                }
                                else
                                {
                                    field[currentRow, --currentCol] = '-';
                                    field[currentRow, ++currentCol] = '-';
                                    currentRow = pillars[0];
                                    currentCol = pillars[1];
                                    field[currentRow, currentCol] = 'S';
                                }
                            }
                            else if (field[currentRow, currentCol] == '-')
                            {
                                field[currentRow, --currentCol] = '-';
                                field[currentRow, ++currentCol] = 'S';
                            }
                            else if (char.IsDigit(field[currentRow, currentCol]))
                            {
                                collectedMoney += int.Parse(field[currentRow, currentCol].ToString());
                                field[currentRow, --currentCol] = '-';
                                field[currentRow, ++currentCol] = 'S';
                            }
                        }
                        else
                        {
                            field[currentRow, --currentCol] = '-';
                            Console.WriteLine("Bad news, you are out of the bakery.");
                            Console.WriteLine($"Money: {collectedMoney}");
                            PrintMatrix(field);
                            Environment.Exit(0);
                        }
                        break;
                }
            }

            Console.WriteLine("Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {collectedMoney}");
            PrintMatrix(field);
        }

        private static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
