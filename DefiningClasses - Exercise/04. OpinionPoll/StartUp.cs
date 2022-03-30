using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(data[0], int.Parse(data[1]));
                people.Add(person);               
            }

            var filtered = people.Where(p => p.Age > 30).OrderBy(x => x.Name).ToList();
            filtered.ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
        }
    }
}
