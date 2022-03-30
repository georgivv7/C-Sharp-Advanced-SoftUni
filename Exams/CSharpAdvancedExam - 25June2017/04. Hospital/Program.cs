using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Output")
            {
                var data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string department = data[0];
                string doctor = data[1] + " " + data[2];
                string patient = data[3];
                if (departments.ContainsKey(department) == false)
                {
                    departments.Add(department, new List<string>());
                    departments[department].Add(patient);
                }
                else
                {
                    departments[department].Add(patient);
                }
                if (doctors.ContainsKey(doctor) == false)
                {
                    doctors.Add(doctor, new List<string>());
                    doctors[doctor].Add(patient);
                }
                else
                {
                    doctors[doctor].Add(patient);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                var printingCommand = input.Split();
                if (printingCommand.Length == 1)
                {
                    foreach (var patient in departments[input])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    int roomNumber = 0;
                    if (int.TryParse(printingCommand[1], out roomNumber))
                    {
                        var skip = 3 * (roomNumber - 1);
                        foreach (var patient in departments[printingCommand[0]]
                            .Skip(skip).Take(3).OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        foreach (var patient in doctors[input].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
            }
        }
    }
}
