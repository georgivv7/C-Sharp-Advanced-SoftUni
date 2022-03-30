using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            numbers.Reverse();
            List<int> reversed = new List<int>(numbers);
            int n = int.Parse(Console.ReadLine());
            Predicate<int> IsDivisible = num => num % n == 0;

            foreach (var num in numbers)
            {
                if (IsDivisible(num))
                {
                    reversed.Remove(num);
                }
            }

            Console.WriteLine(String.Join(" ", reversed));
        }
    }
}
