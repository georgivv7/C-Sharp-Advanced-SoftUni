using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<string, int> products = new Dictionary<string, int>();
            products.Add("Bread", 0);
            products.Add("Cake", 0);
            products.Add("Pastry", 0);
            products.Add("Fruit Pie", 0);
            while (liquids.Any() && ingredients.Any())
            {
                int sum = 0;
                int currentLiquid = liquids.Peek();
                int currentIngredient = ingredients.Peek();
                sum = currentIngredient + currentLiquid;
                switch (sum)
                {
                    case 25:
                        products["Bread"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 50:
                        products["Cake"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 75:
                        products["Pastry"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 100:
                        products["Fruit Pie"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    default:
                        liquids.Dequeue();
                        ingredients.Pop();
                        currentIngredient += 3;
                        ingredients.Push(currentIngredient);
                        break;
                }
            }
            if (products.All(x => x.Value > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            foreach (var product in products.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
        }
    }
}
