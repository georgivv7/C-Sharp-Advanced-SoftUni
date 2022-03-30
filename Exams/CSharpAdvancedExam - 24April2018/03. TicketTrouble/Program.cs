using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._TicketTrouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();
            string pattern = @"{([^\[\]\{\}]*)\[(?<location>[A-Z]{3} [A-Z]{2})\]([^\[\]\{\}]*)\[(?<seat>[A-Z]{1}[0-9]{1,2})\]([^\[\]\{\}]*)}|\[([^\[\]\{\}]*){(?<location>[A-Z]{3} [A-Z]{2})}([^\[\]\{\}]*){(?<seat>[A-Z]{1}[0-9]{1,2})}([^\[\]\{\}]*)\]";
            string input = Console.ReadLine();
            List<string> seats = new List<string>();
            MatchCollection matches = Regex.Matches(input, pattern);
            bool isValid = false;
            foreach (Match ticket in matches)
            {
                string seat = ticket.Groups["seat"].Value;
                string currentLocation = ticket.Groups["location"].Value;
                if (currentLocation == location)
                {
                    seats.Add(seat);
                }
            }
            string firstSeat = string.Empty;
            string secondSeat = string.Empty;
            if (seats.Count == 2)
            {
                firstSeat = seats[0];
                secondSeat = seats[1];
            }
            else if (seats.Count > 2)
            {
                foreach (var seat in seats)
                {
                    foreach (var seet in seats)
                    {
                        if (seat.Substring(0, 1) != seet.Substring(0, 1)
                            && seat.Substring(1) == seet.Substring(1))
                        {
                            firstSeat = seat;
                            secondSeat = seet;
                            isValid = true;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"You are traveling to {location} on seats {firstSeat} and {secondSeat}.");
        }


    }
}
