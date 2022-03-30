using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> sameValuesCount = new Dictionary<double, int>();

            foreach (double num in numbers)
            {
                if (sameValuesCount.ContainsKey(num))
                {
                    sameValuesCount[num]++;
                }
                else
                {
                    sameValuesCount.Add(num, 1);
                }
            }

            foreach (var num in sameValuesCount)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
