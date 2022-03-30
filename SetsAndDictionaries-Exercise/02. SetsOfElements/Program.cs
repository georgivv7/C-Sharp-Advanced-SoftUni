using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            int n = lengths[0];
            int m = lengths[1];
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                first.Add(num);
            }
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                second.Add(number);
            }
            HashSet<int> third = new HashSet<int>();
            foreach (var num in first)
            {
                if (second.Contains(num))
                {
                    third.Add(num);
                }
            }
            Console.WriteLine(String.Join(" ", third));
        }
    }
}
