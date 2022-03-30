using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elemToPush = nums[0];
            int elemToPop = nums[1];
            int elemToCheck = nums[2];
            Stack<int> stack = new Stack<int>();
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < elemToPush; i++)
            {
                stack.Push(inputNumbers[i]);
            }
            for (int i = 0; i < elemToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elemToCheck))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
