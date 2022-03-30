using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> box = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> clothes = new Stack<int>(box);
            int capacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int numOfRacks = 1;
            while (clothes.Count > 0)
            {
                sum += clothes.Peek();
                if (sum <= capacity)
                {
                    clothes.Pop();
                }
                else
                {
                    numOfRacks++;
                    sum = 0;
                }

            }
            Console.WriteLine(numOfRacks);
        }
    }
}
