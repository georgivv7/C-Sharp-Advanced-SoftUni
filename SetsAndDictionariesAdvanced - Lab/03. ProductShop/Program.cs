using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, Dictionary<string, double>> foodShops
                = new Dictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (foodShops.ContainsKey(name) == false)
                {
                    foodShops.Add(name, new Dictionary<string, double>() { { product, price } });
                }
                else
                {
                    foodShops[name].Add(product, price);
                }
            }

            foreach (var shop in foodShops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
