using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> clients = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {

                if (input == "Paid")
                {
                    foreach (var client in clients)
                    {
                        Console.WriteLine(client);
                    }
                    clients.Clear();
                }
                else
                {
                    clients.Enqueue(input);
                }

            }

            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}
