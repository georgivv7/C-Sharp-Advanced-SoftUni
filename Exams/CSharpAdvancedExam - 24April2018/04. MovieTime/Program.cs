using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace _04._MovieTime
{
    class Program
    {
        private const string TimeFormat = @"hh\:mm\:ss";
        static void Main(string[] args)
        {
            string favouriteGenre = Console.ReadLine();
            string favouriteDuration = Console.ReadLine();
            string command = string.Empty;
            Dictionary<string, Dictionary<string, TimeSpan>> movies
                = new Dictionary<string, Dictionary<string, TimeSpan>>();
            while ((command = Console.ReadLine()) != "POPCORN!")
            {
                string[] movieInfo = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string name = movieInfo[0];
                string genre = movieInfo[1];
                string duration = movieInfo[2];

                if (movies.ContainsKey(name) == false)
                {
                    movies.Add(name, new Dictionary<string, TimeSpan>());
                    TimeSpan movieDuration = TimeSpan.ParseExact(duration, TimeFormat, CultureInfo.InvariantCulture);
                    movies[name].Add(genre, movieDuration);
                }
            }

            Dictionary<string, TimeSpan> potentialMovies = new Dictionary<string, TimeSpan>();
            foreach (var item in movies)
            {
                foreach (var elem in item.Value)
                {
                    if (elem.Key == favouriteGenre)
                    {
                        potentialMovies.Add(item.Key, elem.Value);
                    }
                }
            }

            if (favouriteDuration == "Short")
            {
                potentialMovies = potentialMovies.OrderBy(x => x.Value).ThenBy(x => x.Key)
                    .ToDictionary(k => k.Key, x => x.Value);
            }
            else if (favouriteDuration == "Long")
            {
                potentialMovies = potentialMovies.OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                     .ToDictionary(k => k.Key, x => x.Value);
            }


            string chosenMovie = string.Empty;
            string answer = string.Empty;
            foreach (var item in potentialMovies)
            {
                chosenMovie = item.Key;
                Console.WriteLine(item.Key);
                answer = Console.ReadLine();
                if (answer == "Yes")
                {
                    break;
                }

            }
            Console.WriteLine($"We're watching {chosenMovie} - {potentialMovies[chosenMovie]}");

            TimeSpan totalPlaylistDuration = new TimeSpan();
            foreach (var item in movies)
            {
                foreach (var elem in item.Value)
                {
                    totalPlaylistDuration += elem.Value;
                }
            }
            Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration}");

        }
    }
}
