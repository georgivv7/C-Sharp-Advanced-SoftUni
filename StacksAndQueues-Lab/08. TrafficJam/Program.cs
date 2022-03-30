using System;
using System.Collections.Generic;

namespace _08._TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            string input = string.Empty;
            Queue<string> cars = new Queue<string>();
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    int carsToPass = Math.Min(n, cars.Count);
                    for (int i = 0; i < carsToPass; i++)
                    {
                        counter++;
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
