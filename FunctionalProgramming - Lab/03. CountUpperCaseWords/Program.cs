using System;
using System.Linq;

namespace _03._CountUpperCaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> IsUpper = x => char.IsUpper(x[0]);
            var text = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(IsUpper)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, text));

        }
    }
}
