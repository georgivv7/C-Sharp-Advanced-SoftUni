using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> bombs = new Dictionary<string, int>();
            string daturaBomb = "Datura Bombs";
            string cherryBomb = "Cherry Bombs";
            string smokeDecoyBomb = "Smoke Decoy Bombs";
            bombs.Add(daturaBomb, 0);
            bombs.Add(cherryBomb, 0);
            bombs.Add(smokeDecoyBomb, 0);
            while (bombEffects.Any() && bombCasings.Any())
            {
                if (bombs.All(x => x.Value >= 3))
                {
                    break;
                }
                int currentEffect = bombEffects.Peek();
                int currentCasing = bombCasings.Peek();
                int sum = 0;
                while (true)
                {
                    sum = currentCasing + currentEffect;
                    if (sum == 40)
                    {
                        bombs[daturaBomb]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    }
                    else if (sum == 60)
                    {
                        bombs[cherryBomb]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    }
                    else if (sum == 120)
                    {
                        bombs[smokeDecoyBomb]++;
                        bombEffects.Dequeue();
                        bombCasings.Pop();
                        break;
                    }
                    else
                    {
                        currentCasing -= 5;
                    }
                }

            }
            if (bombs.All(x => x.Value >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (bombCasings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }


        }
    }
}
