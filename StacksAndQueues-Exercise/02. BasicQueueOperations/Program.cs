using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int elemToRemove = input[1];
            int numToCheck = input[2];
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> nums = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                nums.Enqueue(numbers[i]);
            }
            for (int i = 0; i < elemToRemove; i++)
            {
                nums.Dequeue();
            }
            if (nums.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else if (nums.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(nums.Min());
            }
            
        }
    }
}
