using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers
              = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstVlogger = data[0];
                if (data[1] == "joined")
                {
                    if (vloggers.ContainsKey(firstVlogger) == false)
                    {
                        vloggers.Add(firstVlogger, new Dictionary<string, HashSet<string>>());
                        vloggers[firstVlogger].Add("followers", new HashSet<string>());
                        vloggers[firstVlogger].Add("following", new HashSet<string>());
                    }
                }
                else if (data[1] == "followed")
                {
                    string secondVlogger = data[2];
                    if (vloggers.ContainsKey(firstVlogger) &&
                        vloggers.ContainsKey(secondVlogger))
                    {
                        if (firstVlogger == secondVlogger)
                        {
                            continue;
                        }
                        vloggers[firstVlogger]["following"].Add(secondVlogger);
                        vloggers[secondVlogger]["followers"].Add(firstVlogger);
                    }
                }
            }
            int num = 1;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            foreach (var item in vloggers.OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(w => w.Value["following"].Count))
            {
                string vlogger = item.Key;
                int followers = item.Value["followers"].Count;
                int following = item.Value["following"].Count;
                Console.WriteLine($"{num}. {vlogger} : {followers} followers, {following} following");

                if (num == 1)
                {
                    foreach (var follower in item.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                num++;
            }
        }
    }
}
