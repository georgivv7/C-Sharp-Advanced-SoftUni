using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> dimensions = new List<int>();
            var coordinates = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = coordinates[0];
            int cols = coordinates[1];
            int[,] garden = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    garden[row, col] = 0;
                }
            }
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                var info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (info[0] >= 0 && info[0] < rows && info[1] >= 0 && info[1] < cols)
                {
                    dimensions.Add(info[0]);
                    dimensions.Add(info[1]);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int index = 0; index < dimensions.Count; index++)
            {
                if (index % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (col == dimensions[index + 1])
                        {
                            garden[dimensions[index], col] = 1;
                            continue;
                        }
                        garden[dimensions[index], col] += 1;
                    }
                }
                else
                {
                    for (int row = 0; row < rows; row++)
                    {
                        if (row == dimensions[index])
                        {
                            garden[row, dimensions[index]] = 1;
                            continue;
                        }
                        garden[row, dimensions[index]] += 1;
                    }
                }
            }
            for (int index = 0; index < dimensions.Count; index += 2)
            {

            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }
                Console.WriteLine();
            }


        }
    }
}
