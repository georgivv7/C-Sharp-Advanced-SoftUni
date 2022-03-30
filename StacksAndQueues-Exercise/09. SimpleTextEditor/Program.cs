using System;
using System.Collections.Generic;
using System.Text;

namespace _09._SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> oldText = new Stack<string>();
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split();
                int command = int.Parse(data[0]);
                switch (command)
                {
                    case 1:
                        oldText.Push(text.ToString());
                        string someString = data[1];
                        text.Append(someString);
                        break;
                    case 2:
                        oldText.Push(text.ToString());
                        int count = int.Parse(data[1]);
                        text.Remove(text.Length - count,count);
                        break;
                    case 3:
                        int index = int.Parse(data[1]);
                        char sub = text[index - 1];
                        Console.WriteLine(sub);
                        break;
                    case 4:
                        text.Clear();
                        text.Append(oldText.Pop());
                        break;
                }
            }
        }
    }
}
