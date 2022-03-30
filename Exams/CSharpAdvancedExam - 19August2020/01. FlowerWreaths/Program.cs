using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int flowerWreaths = 0;
            List<int> flowersForLater = new List<int>();

            while (lilies.Any() && roses.Any())
            {
                int sum = 0;
                int currentLilie = lilies.Peek();
                int currentRose = roses.Peek();
                while (sum != 15 && lilies.Any() && roses.Any())
                {
                    sum = currentLilie + currentRose;
                    if (sum == 15)
                    {
                        flowerWreaths++;
                        lilies.Pop();
                        roses.Dequeue();
                        break;
                    }
                    else if (sum > 15)
                    {
                        currentLilie -= 2;
                    }
                    else if (sum < 15)
                    {
                        lilies.Pop();
                        roses.Dequeue();
                        flowersForLater.Add(currentLilie);
                        flowersForLater.Add(currentRose);
                        break;
                    }
                }
            }


            if (flowersForLater.Any())
            {
                flowerWreaths += flowersForLater.Sum() / 15;
            }
            if (flowerWreaths == 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {flowerWreaths} wreaths!");
            }
            else
            {
                flowerWreaths = Math.Abs(flowerWreaths - 5);
                Console.WriteLine($"You didn't make it, you need {flowerWreaths} wreaths more!");
            }
        }
    }
}
