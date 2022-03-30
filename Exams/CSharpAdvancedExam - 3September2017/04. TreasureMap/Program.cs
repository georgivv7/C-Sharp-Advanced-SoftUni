using System;
using System.Text.RegularExpressions;

namespace _04._TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"#[^#!]*?(?<![A-Za-z0-9])(?<name>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<street>\d{3})-(?<pass>\d{4}|\d{6})(?!\d)[^#!]*?!|![^#!]*?(?<![A-Za-z0-9])(?<name>[a-zA-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<street>\d{3})-(?<pass>\d{4}|\d{6})(?!\d)[^#!]*?#";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = Regex.Matches(input, pattern);
                var correctMatch = matches[matches.Count / 2];

                string name = correctMatch.Groups["name"].Value;
                string street = correctMatch.Groups["street"].Value;
                string pass = correctMatch.Groups["pass"].Value;

                Console.WriteLine($"Go to str. {name} {street}. Secret pass: {pass}.");
            }
        }
    }
}
