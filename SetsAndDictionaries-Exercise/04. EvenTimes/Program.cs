using System;
using System.Collections.Generic;

namespace _04._EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(num))
                {
                    numbers[num]++;
                }
                else
                {
                    numbers.Add(num, 1);
                }
            }
            int currentNum = 0;
            foreach (var num in numbers)
            {
                if (num.Value % 2 == 0)
                {
                    currentNum = num.Key;
                }
            }

            Console.WriteLine(currentNum);
        }
    }
}
