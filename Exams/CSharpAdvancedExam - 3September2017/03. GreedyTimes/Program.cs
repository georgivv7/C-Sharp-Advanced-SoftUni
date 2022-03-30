using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            var items = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Dictionary<string, Dictionary<string, long>> wealth
                = new Dictionary<string, Dictionary<string, long>>();
            long cashSum = 0;
            long goldSum = 0;
            long gemSum = 0;
            long totalSum = 0;
            while (items.Count > 0)
            {
                string asset = items.Dequeue();
                string toLower = asset.ToLower();
                long amount = long.Parse(items.Dequeue());
                if (totalSum + amount > capacity)
                {
                    break;
                }
                if (asset.Length == 3)
                {
                    if (cashSum + amount > gemSum)
                    {
                        continue;
                    }
                    cashSum += amount;
                    totalSum += amount;
                    if (wealth.ContainsKey("Cash") == false)
                    {
                        wealth.Add("Cash", new Dictionary<string, long> { { asset, amount } });
                    }
                    else
                    {
                        if (wealth["Cash"].ContainsKey(asset))
                        {
                            wealth["Cash"][asset] += amount;
                        }
                        else
                        {
                            wealth["Cash"].Add(asset, amount);
                        }
                    }
                }
                else if (toLower.EndsWith("gem"))
                {
                    if (gemSum + amount > goldSum)
                    {
                        continue;
                    }
                    gemSum += amount;
                    totalSum += amount;
                    if (wealth.ContainsKey("Gem") == false)
                    {
                        wealth.Add("Gem", new Dictionary<string, long> { { asset, amount } });
                    }
                    else
                    {
                        if (wealth["Gem"].ContainsKey(asset) == false)
                        {
                            wealth["Gem"].Add(asset, amount);
                        }
                        else if (wealth["Gem"].ContainsKey(asset))
                        {
                            wealth["Gem"][asset] += amount;
                        }
                    }
                }
                else if (toLower == "gold")
                {
                    goldSum += amount;
                    totalSum += amount;
                    if (wealth.ContainsKey("Gold") == false)
                    {
                        wealth.Add("Gold", new Dictionary<string, long> { { asset, amount } });
                    }
                    else
                    {
                        wealth["Gold"][asset] += amount;
                    }
                }
                else
                {
                    continue;
                }
            }

            if (wealth.Any())
            {
                foreach (var type in wealth.OrderByDescending(x => x.Value.Values.Sum()))
                {
                    if (type.Key.Any())
                    {
                        Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");
                    }
                    foreach (var item in type.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
