using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> bullet = new Stack<int>(bullets);
            int[] lockers = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(lockers);
            int intelligenceValue = int.Parse(Console.ReadLine());

            int numOfBullets = 0;
            int countBullets = bullet.Count;
            while (locks.Count > 0 && bullet.Count > 0)
            {
                numOfBullets++;
                if (bullet.Peek() <= locks.Peek())
                {
                    bullet.Pop();
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    bullet.Pop();
                    Console.WriteLine("Ping!");
                }
                if (bullet.Count > 0 && numOfBullets == sizeOfGunBarrel)
                {
                    numOfBullets = 0;
                    Console.WriteLine("Reloading!");
                }
            }
            countBullets -= bullet.Count;
            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int bulletCost = bulletPrice * countBullets;
                int earned = intelligenceValue - bulletCost;
                Console.WriteLine($"{bullet.Count} bullets left. Earned ${earned}");
            }
        }
    }
}
