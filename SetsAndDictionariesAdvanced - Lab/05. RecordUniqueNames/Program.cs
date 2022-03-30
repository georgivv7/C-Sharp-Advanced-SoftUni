﻿using System;
using System.Collections.Generic;

namespace _05._RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string inputName = Console.ReadLine();
                names.Add(inputName);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
