using System;
using System.Linq;

namespace _03._PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                var rowValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int columns = 0; columns < n; columns++)
                {
                    matrix[row, columns] = rowValues[columns];
                }
            }

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int row = i;
                int col = i;
                sum += matrix[row, col];
            }

            Console.WriteLine(sum);
        }
    }
}
