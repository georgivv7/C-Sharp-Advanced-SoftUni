using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            Func<int, int> addOne = x => x + 1;
            Func<int, int> subtractOne = x => x - 1;
            Func<int, int> multiplyBy2 = x => x * 2;
            Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            while (true)
            {
                string command = Console.ReadLine();
                for (int i = 0; i < numbers.Count; i++)
                {
                    switch (command)
                    {
                        case "add":
                            numbers[i] = addOne(numbers[i]);
                            break;
                        case "multiply":
                            numbers[i] = multiplyBy2(numbers[i]);
                            break;
                        case "subtract":
                            numbers[i] = subtractOne(numbers[i]);
                            break;
                        case "print":
                            print(numbers);
                            break;
                        case "end":
                            Environment.Exit(0);
                            break;

                    }
                    if (command == "print")
                    {
                        break;
                    }
                }
            }
        }
    }
}
