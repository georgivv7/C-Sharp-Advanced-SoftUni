using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> symbols = new Dictionary<char, int>();

            for (int current = 0; current < text.Length; current++)
            {
                char currentChar = text[current];
                if (symbols.ContainsKey(currentChar))
                {
                    symbols[currentChar]++;
                }
                else
                {
                    symbols.Add(currentChar, 1);
                }
            }

            foreach (var symbol in symbols.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
