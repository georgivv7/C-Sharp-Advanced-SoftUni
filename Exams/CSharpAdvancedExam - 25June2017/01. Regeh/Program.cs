using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\[[a-zA-Z]+<(?<firstNum>\d+)REGEH(?<secondNum>\d+)>[a-zA-Z]+\]";
            Regex regex = new Regex(pattern);
            List<int> numbers = new List<int>();

            foreach (Match match in regex.Matches(input))
            {
                numbers.Add(int.Parse(match.Groups["firstNum"].Value));
                numbers.Add(int.Parse(match.Groups["secondNum"].Value));
            }
            int currentIndex = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var index in numbers)
            {
                currentIndex += index;
                int charIndex = currentIndex % (input.Length - 1);
                sb.Append(input[charIndex]);
            }
            string result = sb.ToString();
            Console.WriteLine(result);
        }
    }
}
