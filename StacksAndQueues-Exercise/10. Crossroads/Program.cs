using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenSeconds = int.Parse(Console.ReadLine());
            int freeSeconds = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input = string.Empty;
            int carsPassed = 0;
            int secondsLeft = greenSeconds;
            int charsLeft = 0;
            char currentChar = ' ';
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    secondsLeft = greenSeconds;
                    while (cars.Count > 0)
                    {
                        if (secondsLeft <= 0)
                        {
                            break;
                        }
                        string currentCar = cars.Dequeue();
                        charsLeft = currentCar.Length;
                        for (int i = 0; i < currentCar.Length; i++)
                        {
                            secondsLeft--;
                            charsLeft--;
                            currentChar = currentCar[i];
                                                       
                            if (secondsLeft <= 0)
                            {
                                secondsLeft = 0;
                                break;
                            }                       
                            
                        }
                        if (secondsLeft > 0)
                        {
                            carsPassed++;
                        }
                        else if (freeSeconds >= charsLeft)
                        {
                            carsPassed++;
                        }
                        else
                        {
                            currentChar = currentCar[freeSeconds + 1];
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentChar}.");
                            Environment.Exit(0);
                        }
                    }

                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
