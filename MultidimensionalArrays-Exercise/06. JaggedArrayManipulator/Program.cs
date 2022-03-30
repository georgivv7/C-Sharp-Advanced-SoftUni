using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];

            for (int row = 0; row < n; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }
                    for (int k = 0; k < jaggedArray[i + 1].Length; k++)
                    {
                        jaggedArray[i + 1][k] /= 2;
                    }
                }
            }

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                var data = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                double value = double.Parse(data[3]);
                if (data[0] == "Add")
                {
                    if ((row >= 0 && row < jaggedArray.Length) && (col >= 0 && col < jaggedArray[row].Length))
                    {
                        jaggedArray[row][col] += value;
                    }
                }
                else if (data[0] == "Subtract")
                {
                    if ((row >= 0 && row < jaggedArray.Length) && (col >= 0 && col < jaggedArray[row].Length))
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[i]));
            }

        }
    }
}
