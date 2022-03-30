using System;
using System.Collections.Generic;

namespace _07._HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] childrenArray = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> children = new Queue<string>(childrenArray);

            while (children.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    children.Enqueue(children.Dequeue());
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
