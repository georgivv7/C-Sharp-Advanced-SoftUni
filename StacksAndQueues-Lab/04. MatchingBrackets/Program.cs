using System;
using System.Collections.Generic;

namespace _04._MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    int openingBracket = stack.Pop();
                    string substring = input.Substring(openingBracket, i - openingBracket + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
