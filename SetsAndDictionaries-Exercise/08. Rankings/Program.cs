using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Rankings
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] data = input.Split(":");
                string contest = data[0];
                string password = data[1];

                if (contests.ContainsKey(contest) == false)
                {
                    contests.Add(contest, password);
                }
            }

            Dictionary<string, Dictionary<string, int>> users
                = new Dictionary<string, Dictionary<string, int>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] data = command.Split("=>");
                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);

                if (contests.ContainsKey(contest) && contests.ContainsValue(password))
                {
                    if (users.ContainsKey(username) == false)
                    {
                        users.Add(username, new Dictionary<string, int> { { contest, points } });
                    }
                    else
                    {
                        if (users[username].ContainsKey(contest))
                        {
                            if (points > users[username][contest])
                            {
                                users[username][contest] = points;
                            }
                        }
                        else
                        {
                            users[username].Add(contest, points);
                        }
                    }
                }
            }
            int biggestSum = 0;
            int sum = 0;
            string bestCandidate = string.Empty;
            foreach (var user in users)
            {
                foreach (var points in user.Value)
                {
                    sum += points.Value;
                }
                if (sum > biggestSum)
                {
                    biggestSum = sum;
                    bestCandidate = user.Key;
                }
                sum = 0;
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {biggestSum} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in users.OrderBy(x => x.Key))
            {

                Console.WriteLine($"{student.Key}");
                foreach (var points in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {points.Key} -> {points.Value}");
                }
            }
        }
    }
}
