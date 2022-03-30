using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> newList = new List<int>();
            for (int num = 1; num <= end; num++)
            {
                Predicate<int> IsDivisible = n => num % n == 0;
                if (dividers.TrueForAll(IsDivisible))
                {
                    newList.Add(num);
                }
            }

            Console.WriteLine(String.Join(" ", newList));
        }
    }
}
