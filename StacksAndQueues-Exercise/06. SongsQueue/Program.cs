using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(input);
            StringBuilder songFullName = new StringBuilder();
            string song = string.Empty;
            while (true)
            {
                if (songs.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                switch (command)
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        songFullName.Clear();
                        for (int i = 1; i < commands.Length; i++)
                        {
                            songFullName.Append($"{commands[i]} ");
                        }
                        song = songFullName.ToString().Trim();
                        if (songs.Contains(song) == false)
                        {
                            songs.Enqueue(song);
                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }
                

            }
            
        }
    }
}
