using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = data[0];
                var clothesInput = data[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (clothes.ContainsKey(colour) == false)
                {
                    clothes.Add(colour, new Dictionary<string, int>());
                    foreach (var item in clothesInput)
                    {
                        if (clothes[colour].ContainsKey(item))
                        {
                            clothes[colour][item]++;
                        }
                        else
                        {
                            clothes[colour].Add(item, 1);
                        }
                    }
                }
                else
                {
                    foreach (var currentClothing in clothesInput)
                    {
                        if (clothes[colour].ContainsKey(currentClothing))
                        {
                            clothes[colour][currentClothing]++;
                        }
                        else
                        {
                            clothes[colour].Add(currentClothing, 1);
                        }
                    }
                }

            }
            string[] neededItem = Console.ReadLine().Split();
            string color = neededItem[0];
            string clothing = neededItem[1];

            foreach (var cloth in clothes)
            {
                Console.WriteLine($"{cloth.Key} clothes:");
                foreach (var item in cloth.Value)
                {
                    if (cloth.Key == color && item.Key == clothing)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }

        }
    }
}
