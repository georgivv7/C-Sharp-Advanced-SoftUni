using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .ToList();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }

        }
    }
}
