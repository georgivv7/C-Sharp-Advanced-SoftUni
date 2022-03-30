using System;
using System.Linq;

namespace _01._DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixLenght = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixLenght, matrixLenght];

            for (int rows = 0; rows < matrixLenght; rows++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrixLenght; col++)
                {
                    matrix[rows, col] = input[col];
                }
            }
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < matrixLenght; i++)
            {
                sum1 += matrix[i, i];
            }
            for (int rows = 0; rows < matrixLenght; rows++)
            {
                for (int col = matrixLenght - 1; col >= 0; col--)
                {                   
                    sum2 += matrix[rows, col];
                    rows++;
                }
            }

            int difference = Math.Abs(sum1 - sum2);
            Console.WriteLine(difference);
        }
    }
}
