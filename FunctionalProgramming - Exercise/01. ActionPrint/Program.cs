using System;

namespace _01._ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Action<string> printName = name => Console.WriteLine(name);

            foreach (string name in input)
            {
                printName(name);
            }
        }
    }
}
