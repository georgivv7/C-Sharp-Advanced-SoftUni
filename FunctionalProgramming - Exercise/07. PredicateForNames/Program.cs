using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Predicate<string> nameLength = name => name.Length <= n;
            List<string> filtered = new List<string>();
            foreach (var name in names)
            {
                if (nameLength(name))
                {
                    filtered.Add(name);
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, filtered));

        }
    }
}
