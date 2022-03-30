using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> evenNumbers = new Queue<int>();

            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    evenNumbers.Enqueue(num);
                }
            }

            Console.WriteLine(String.Join(", ",evenNumbers));
        }
    }
}
