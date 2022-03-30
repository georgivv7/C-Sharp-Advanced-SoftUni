using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] capacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cupsCapacity = new Queue<int>(capacity);
            int[] waterBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottlesOfWater = new Stack<int>(waterBottles);
            int wastedWater = 0;
            while (true)
            {
                if (cupsCapacity.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottlesOfWater)}");
                    break;
                }
                else if (bottlesOfWater.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
                    break;
                }

                int currentCup = cupsCapacity.Peek();
                
                while (currentCup > 0)
                {
                    int currentBottle = bottlesOfWater.Pop();
                    if (currentBottle >= currentCup)
                    {
                        wastedWater += currentBottle - currentCup;
                        currentCup -= currentBottle;
                    }
                    else if (currentCup > currentBottle)
                    {
                        currentCup -= currentBottle;
                    }
                }
                cupsCapacity.Dequeue();
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
    }
}
