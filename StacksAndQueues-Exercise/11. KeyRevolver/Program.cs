using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsRecieved = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(bulletsRecieved);
            int[] locksRecieved = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(locksRecieved);
            int intelligenceValue = int.Parse(Console.ReadLine());
            int bulletsLeft = gunBarrelSize;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                if (bulletsLeft == 0 && bullets.Any())
                {
                    bulletsLeft = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
                int bullet = bullets.Pop();
                bulletsLeft--;
                int currentLock = locks.Peek();
                if (bullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
            }
            if (bulletsLeft == 0 && bullets.Any())
            {
                bulletsLeft = gunBarrelSize;
                Console.WriteLine("Reloading!");
            }

            if (locks.Count == 0 && bullets.Count >= 0)
            {
                int numOfBullets = bulletsRecieved.Length - bullets.Count;
                int bulletCost = numOfBullets * priceBullet;
                intelligenceValue -= bulletCost;

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
