using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];
            string command = Console.ReadLine();

            Predicate<int> oddPredicate = x => x % 2 != 0;
            Predicate<int> evenPredicate = x => x % 2 == 0;
            List<int> numbers = new List<int>();

            for (int num = start; num <= end; num++)
            {
                switch (command)
                {
                    case "odd":
                        if (oddPredicate(num))
                        {
                            numbers.Add(num);
                        }
                        break;
                    case "even":
                        if (evenPredicate(num))
                        {
                            numbers.Add(num);
                        }
                        break;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
