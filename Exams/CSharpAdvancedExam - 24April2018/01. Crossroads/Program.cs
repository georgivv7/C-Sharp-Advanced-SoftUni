using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenSeconds = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> carsInCrossroad = new Queue<string>();
            int carsPassed = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    carsInCrossroad.Enqueue(input);
                    continue;
                }

                int currentGreenLight = greenSeconds;

                string currentCar = string.Empty;
                while (currentGreenLight > 0 && carsInCrossroad.Any())
                {
                    currentCar = carsInCrossroad.Dequeue();
                    currentGreenLight -= currentCar.Length;
                    carsPassed++;
                }

                int freeWindowLeft = freeWindow + currentGreenLight;
                if (freeWindowLeft < 0)
                {
                    int symbolsThatDidntPass = Math.Abs(freeWindowLeft);
                    int indexOfHitSymbol = currentCar.Length - symbolsThatDidntPass;
                    char symbolHit = currentCar[indexOfHitSymbol];
                    Crash(currentCar, symbolHit);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");

        }

        private static void Crash(string passingCar, char symbolHit)
        {
            Console.WriteLine("A crash happened!");
            Console.WriteLine($"{passingCar} was hit at {symbolHit}.");
            Environment.Exit(0);
        }
    }
}
