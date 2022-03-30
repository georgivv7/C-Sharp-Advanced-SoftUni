using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<char> reversedText = new Stack<char>();
            foreach (var item in text)
            {
                reversedText.Push(item);
            }
            
            Console.WriteLine(string.Join("",reversedText));
      
        }
    }
}
