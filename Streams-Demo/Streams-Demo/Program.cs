using System;
using System.IO;

namespace Streams_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("D:/C# Advanced/Streams-Demo/Streams-Demo/Program.cs"))
            {
                using (var writer = new StreamWriter("D:/C# Advanced/Streams-Demo/Streams-Demo/someText.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        for (int count = line.Length-1; count >= 0; count--)
                        {
                            writer.Write(line[count]);
                        }
                        writer.WriteLine();
                    }
                }                
            }
        }
    }
}
