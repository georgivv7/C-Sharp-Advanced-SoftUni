using System;
using System.Linq;

namespace _03._CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int smallest = int.MaxValue;
            Func<int, bool> smallestNum = x => x < smallest;

            foreach (var num in numbers)
            {
                if (smallestNum(num))
                {
                    smallest = num;
                }
            }

            Console.WriteLine(smallest);
        }
    }
}
