using System;

namespace _02._KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Action<string> printNames = name => Console.WriteLine($"Sir {name}");

            foreach (string name in input)
            {
                printNames(name);
            }
        }
    }
}
