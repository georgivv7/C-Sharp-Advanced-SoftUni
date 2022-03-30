using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> firstLootbox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondLootbox = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int currentSum = 0;
            List<int> claimedItems = new List<int>();
            while (firstLootbox.Any() && secondLootbox.Any())
            {
                int firstBoxElement = firstLootbox.Peek();
                int secondBoxElement = secondLootbox.Peek();
                currentSum = firstBoxElement + secondBoxElement;

                if (currentSum % 2 == 0)
                {
                    claimedItems.Add(currentSum);
                    firstLootbox.Dequeue();
                    secondLootbox.Pop();
                }
                else
                {
                    secondLootbox.Pop();
                    firstLootbox.Enqueue(secondBoxElement);
                }
            }
            if (!firstLootbox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (!secondLootbox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }
            int sumClaimedItems = claimedItems.Sum();
            if (sumClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumClaimedItems}");
            }
        }
    }
}
