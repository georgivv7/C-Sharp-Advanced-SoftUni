using System;
using System.Collections.Generic;

namespace _06._ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> parking = new HashSet<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = data[0];
                string carNumber = data[1];

                if (direction == "IN")
                {
                    parking.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    parking.Remove(carNumber);
                }
            }

            if (parking.Count > 0)
            {
                foreach (var carNum in parking)
                {
                    Console.WriteLine(carNum);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
