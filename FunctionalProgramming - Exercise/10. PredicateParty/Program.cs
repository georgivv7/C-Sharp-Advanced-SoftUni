using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "Party!")
            {
                var data = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string criteria = data[1];
                string givenString = data[2];

                Predicate<string> starting = x => x.StartsWith(givenString);
                Predicate<string> ending = x => x.EndsWith(givenString);
                Predicate<string> nameLength = x => x.Length == int.Parse(givenString);

                switch (command)
                {
                    case "Remove":
                        if (criteria == "StartsWith")
                        {
                            people.RemoveAll(starting);
                        }
                        else if (criteria == "EndsWith")
                        {
                            people.RemoveAll(ending);
                        }
                        else if (criteria == "Length")
                        {
                            people.RemoveAll(nameLength);
                        }
                        break;
                    case "Double":
                        List<string> peopleComing = new List<string>(people);
                        foreach (var name in peopleComing)
                        {
                            if (criteria == "Length")
                            {
                                if (nameLength(name))
                                {
                                    people.Add(name);
                                }
                            }
                            else if (criteria == "StartsWith")
                            {
                                if (starting(name))
                                {
                                    people.Add(name);
                                }
                            }
                            else if (criteria == "EndsWith")
                            {
                                if (ending(name))
                                {
                                    people.Add(name);
                                }
                            }
                        }
                        break;
                }
            }

            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
