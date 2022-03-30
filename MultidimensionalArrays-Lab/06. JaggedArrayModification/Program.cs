using System;
using System.Linq;

namespace _06._JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var commands = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                double value = double.Parse(commands[3]);
                if (command == "Add")
                {
                    if ((row >= 0 && row < jaggedArray.Length) && (col >= 0 && col < jaggedArray.Length))
                    {
                        jaggedArray[row][col] += value;      
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (command == "Subtract")
                {
                    if ((row >= 0 && row < jaggedArray.Length) && (col >= 0 && col < jaggedArray.Length))
                    {
                        jaggedArray[row][col] -= value;                      
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
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
