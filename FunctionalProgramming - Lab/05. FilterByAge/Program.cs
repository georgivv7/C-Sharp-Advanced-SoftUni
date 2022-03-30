using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> students = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] nameAndAge = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = nameAndAge[0];
                int age = int.Parse(nameAndAge[1]);
                students.Add(name, age);
            }
            string filter = Console.ReadLine();
            int minimalAge = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            var condition = CreateFilter(filter, minimalAge);
            var printer = CreatePrinter(format);
            foreach (var student in students)
            {
                if (condition(student))
                {
                    printer(student);
                }
            }

        }
        static Func<KeyValuePair<string, int>, bool> CreateFilter(string filter, int minimalAge)
        {
            if (filter == "younger")
            {
                return x => x.Value < minimalAge;
            }
            else
            {
                return x => x.Value >= minimalAge;
            }
        }
        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
