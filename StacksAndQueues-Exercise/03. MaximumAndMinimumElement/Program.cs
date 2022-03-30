using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                switch (input[0])
                {
                    case 1:
                        int num = input[1];
                        numbers.Push(num);
                        break;
                    case 2:
                        numbers.Pop();
                        break;
                    case 3:
                        if (numbers.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine(numbers.Max());
                        break;
                    case 4:
                        if (numbers.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine(numbers.Min());
                        break;
                }
            }

            Console.WriteLine(String.Join(", ",numbers));
        }
    }
}
