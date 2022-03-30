using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._AverageStudentGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                decimal grade = decimal.Parse(data[1]);

                if (grades.ContainsKey(name))
                {
                    grades[name].Add(grade);
                }
                else
                {
                    grades.Add(name, new List<decimal>());
                    grades[name].Add(grade);
                }
            }

            foreach (var student in grades)
            {
                decimal average = student.Value.Average();
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {average:f2})");
                Console.WriteLine();
            }
        }
    }
}
