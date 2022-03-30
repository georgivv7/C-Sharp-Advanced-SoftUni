using System;
using System.Collections.Generic;

namespace _07._SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> guests = new HashSet<string>();

            while ((input = Console.ReadLine()) != "PARTY")
            {
                guests.Add(input);
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string number = command;
                if (guests.Contains(number))
                {
                    guests.Remove(number);
                }
            }

            Console.WriteLine(guests.Count);
            foreach (var guestVIP in guests)
            {
                if (char.IsDigit(guestVIP[0]))
                {
                    Console.WriteLine(guestVIP);
                }
            }
            foreach (var guest in guests)
            {
                if (char.IsLetter(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }

        }
    }
}
