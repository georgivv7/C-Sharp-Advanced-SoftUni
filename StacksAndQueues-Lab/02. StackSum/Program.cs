using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> nums = new Stack<int>();
            foreach (var item in numbers)
            {
                nums.Push(item);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split();
                string command = data[0].ToLower();

                switch (command)
                {
                    case "add":
                        int num = int.Parse(data[1]);
                        nums.Push(num);
                        int numTwo = int.Parse(data[2]);
                        nums.Push(numTwo);
                        break;
                    case "remove":
                        int count = int.Parse(data[1]);
                        if (nums.Count >= count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                nums.Pop();
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;
                }
            }
            int sum = nums.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
