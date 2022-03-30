using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            string commands = string.Empty;
            Dictionary<string, Dictionary<string, string>> peopleData = new Dictionary<string, Dictionary<string, string>>();
            while ((commands = Console.ReadLine()) != "end transmissions")
            {
                var input = commands.Split('=');
                string name = input[0];
                if (peopleData.ContainsKey(name) == false)
                {
                    peopleData.Add(name, new Dictionary<string, string>());
                }
                string[] keyValuePairs = input[1].Split(':', ';').ToArray();
                for (int i = 0; i < keyValuePairs.Length - 1; i++)
                {
                    string key = keyValuePairs[i];
                    var value = keyValuePairs[++i];

                    if (peopleData[name].ContainsKey(key) == false)
                    {
                        peopleData[name].Add(key, value);
                    }
                    else if (peopleData[name].ContainsKey(key))
                    {
                        peopleData[name][key] = value;
                    }
                }
            }
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = command[1];
            int infoIndex = 0;
            if (peopleData.ContainsKey(personName))
            {
                Console.WriteLine($"Info on {personName}:");
                foreach (var item in peopleData[personName].OrderBy(x => x.Key))
                {
                    infoIndex += item.Key.Length + item.Value.Length;
                    Console.WriteLine($"---{item.Key}: {item.Value}");
                }
            }

            Console.WriteLine($"Info index: {infoIndex}");
            if (targetInfoIndex <= infoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                targetInfoIndex -= infoIndex;
                Console.WriteLine($"Need {targetInfoIndex} more info.");
            }
        }
    }
}
