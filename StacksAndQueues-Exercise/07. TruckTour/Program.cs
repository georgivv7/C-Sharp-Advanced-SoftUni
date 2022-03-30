using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(info);
            }

            for (int currentStart = 0; currentStart < n - 1; currentStart++)
            {
                int fuel = 0;
                bool isFirstPoint = true;

                for (int pumpsPassed = 0; pumpsPassed < n; pumpsPassed++)
                {
                    int[] currentPump = queue.Dequeue();
                    int pumpFuel = currentPump[0];
                    int distance = currentPump[1];

                    queue.Enqueue(currentPump);

                    fuel += pumpFuel - distance;
                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        isFirstPoint = false;
                        break;
                    }
                }
                if (isFirstPoint)
                {
                    Console.WriteLine(currentStart);
                    break;
                }
            }
        }
    }
}
