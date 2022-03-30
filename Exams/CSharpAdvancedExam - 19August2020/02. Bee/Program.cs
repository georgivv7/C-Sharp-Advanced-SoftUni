using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            int currentRow = 0;
            int currentCol = 0;
            int pollinatedFlowers = 0;
            char[,] field = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        --currentRow;
                        if (currentRow >= 0 && currentRow < rows)
                        {
                            if (field[currentRow, currentCol] == 'f')
                            {
                                pollinatedFlowers++;
                                field[++currentRow, currentCol] = '.';
                                field[--currentRow, currentCol] = 'B';
                            }
                            else if (field[currentRow, currentCol] == '.')
                            {
                                field[++currentRow, currentCol] = '.';
                                field[--currentRow, currentCol] = 'B';
                            }
                            else if (field[currentRow, currentCol] == 'O')
                            {
                                field[++currentRow, currentCol] = '.';
                                field[--currentRow, currentCol] = '.';
                                if (field[--currentRow, currentCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                                field[currentRow, currentCol] = 'B';
                            }
                        }
                        else
                        {
                            field[++currentRow, currentCol] = '.';
                            Console.WriteLine("The bee got lost!");
                            if (pollinatedFlowers >= 5)
                            {
                                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
                            }
                            else
                            {
                                pollinatedFlowers = Math.Abs(pollinatedFlowers - 5);
                                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {pollinatedFlowers} flowers more");
                            }
                            PrintMatrix(field);
                            return;
                        }
                        break;
                    case "down":
                        ++currentRow;
                        if (currentRow >= 0 && currentRow < rows)
                        {
                            if (field[currentRow, currentCol] == 'f')
                            {
                                pollinatedFlowers++;
                                field[--currentRow, currentCol] = '.';
                                field[++currentRow, currentCol] = 'B';
                            }
                            else if (field[currentRow, currentCol] == '.')
                            {
                                field[--currentRow, currentCol] = '.';
                                field[++currentRow, currentCol] = 'B';
                            }
                            else if (field[currentRow, currentCol] == 'O')
                            {
                                field[--currentRow, currentCol] = '.';
                                field[++currentRow, currentCol] = '.';
                                if (field[++currentRow, currentCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                                field[currentRow, currentCol] = 'B';
                            }
                        }
                        else
                        {
                            field[--currentRow, currentCol] = '.';
                            Console.WriteLine("The bee got lost!");
                            if (pollinatedFlowers >= 5)
                            {
                                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
                            }
                            else
                            {
                                pollinatedFlowers = Math.Abs(pollinatedFlowers - 5);
                                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {pollinatedFlowers} flowers more");
                            }
                            PrintMatrix(field);
                            return;
                        }
                        break;
                    case "left":
                        --currentCol;
                        if (currentCol >= 0 && currentCol < cols)
                        {
                            if (field[currentRow, currentCol] == 'f')
                            {
                                pollinatedFlowers++;
                                field[currentRow, ++currentCol] = '.';
                                field[currentRow, --currentCol] = 'B';
                            }
                            else if (field[currentRow, currentCol] == '.')
                            {
                                field[currentRow, ++currentCol] = '.';
                                field[currentRow, --currentCol] = 'B';
                            }
                            else if (field[currentRow, currentCol] == 'O')
                            {
                                field[currentRow, ++currentCol] = '.';
                                field[currentRow, --currentCol] = '.';
                                if (field[currentRow, --currentCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                                field[currentRow, currentCol] = 'B';
                            }
                        }
                        else
                        {
                            field[currentRow, ++currentCol] = '.';
                            Console.WriteLine("The bee got lost!");
                            if (pollinatedFlowers >= 5)
                            {
                                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
                            }
                            else
                            {
                                pollinatedFlowers = Math.Abs(pollinatedFlowers - 5);
                                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {pollinatedFlowers} flowers more");
                            }
                            PrintMatrix(field);
                            return;
                        }
                        break;
                    case "right":
                        ++currentCol;
                        if (currentCol >= 0 && currentCol < cols)
                        {
                            if (field[currentRow, currentCol] == 'f')
                            {
                                pollinatedFlowers++;
                                field[currentRow, --currentCol] = '.';
                                field[currentRow, ++currentCol] = 'B';
                            }
                            else if (field[currentRow, currentCol] == '.')
                            {
                                field[currentRow, --currentCol] = '.';
                                field[currentRow, ++currentCol] = 'B';
                            }
                            else if (field[currentRow, currentCol] == 'O')
                            {
                                field[currentRow, --currentCol] = '.';
                                field[currentRow, ++currentCol] = '.';
                                if (field[currentRow, ++currentCol] == 'f')
                                {
                                    pollinatedFlowers++;
                                }
                                field[currentRow, currentCol] = 'B';
                            }
                        }
                        else
                        {
                            field[currentRow, --currentCol] = '.';
                            Console.WriteLine("The bee got lost!");
                            if (pollinatedFlowers >= 5)
                            {
                                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
                            }
                            else
                            {
                                pollinatedFlowers = Math.Abs(pollinatedFlowers - 5);
                                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {pollinatedFlowers} flowers more");
                            }
                            PrintMatrix(field);
                            return;
                        }
                        break;
                }
            }
            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                pollinatedFlowers = Math.Abs(pollinatedFlowers - 5);
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {pollinatedFlowers} flowers more");
            }
            PrintMatrix(field);

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
