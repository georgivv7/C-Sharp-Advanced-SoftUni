using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                decimal grade = decimal.Parse(data[1]);

                if (grades.ContainsKey(name))
                {
                    grades[name].Add(grade);
                }
                else
                {
                    grades.Add(name, new List<decimal>() { grade });
                }
            }

            foreach (var student in grades.OrderByDescending(x => x.Value.Average()))
            {
                decimal average = student.Value.Average();
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value)} (avg: {average:f2})");
            }
        }
    }
}
