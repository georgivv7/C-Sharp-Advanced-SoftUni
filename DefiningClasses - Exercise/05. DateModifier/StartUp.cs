﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            int difference = DateModifier.CalculateDifference(dateOne, dateTwo);
            Console.WriteLine(difference);
        }
    }
}
