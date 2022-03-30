using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] ordersInput = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(ordersInput);
            int biggestOrder = orders.Max();
            Console.WriteLine(biggestOrder);
            while (orders.Count > 0)
            {
                foreach (var order in ordersInput)
                {
                    if (quantityFood >= order)
                    {
                        quantityFood -= order;
                        orders.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                        return;
                    }
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
