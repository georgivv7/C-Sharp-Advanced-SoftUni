using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitations = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = string.Empty;
            List<string> people = new List<string>(invitations);
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] commands = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string filterType = commands[1];
                string filterParameter = commands[2];

                Predicate<string> startsWith = n => n.StartsWith(filterParameter);
                Predicate<string> endsWith = n => n.EndsWith(filterParameter);
                Predicate<string> length = n => n.Length == int.Parse(filterParameter);
                Predicate<string> contains = n => n.Contains(filterParameter);

                if (command == "Add filter")
                {
                    switch (filterType)
                    {
                        case "Starts with":
                            invitations.RemoveAll(startsWith);
                            break;
                        case "Ends with":
                            invitations.RemoveAll(endsWith);
                            break;
                        case "Length":
                            invitations.RemoveAll(length);
                            break;
                        case "Contains":
                            invitations.RemoveAll(contains);
                            break;
                    }

                }
                else if (command == "Remove filter")
                {
                    foreach (var name in people)
                    {
                        switch (filterType)
                        {
                            case "Starts with":
                                if (startsWith(name))
                                {
                                    invitations.Add(name);
                                }
                                break;
                            case "Ends with":
                                if (endsWith(name))
                                {
                                    invitations.Add(name);
                                }
                                break;
                            case "Length":
                                if (length(name))
                                {
                                    invitations.Add(name);
                                }
                                break;
                            case "Contains":
                                if (contains(name))
                                {
                                    invitations.Add(name);
                                }
                                break;
                        }
                    }
                }
            }

            Console.WriteLine(String.Join(" ", invitations));
        }
    }
}
