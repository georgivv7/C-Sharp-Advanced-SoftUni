using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] currentTires = new Tire[input.Length / 2];
                int tireCounter = 0;

                for (int index = 0; index < input.Length; index += 2, tireCounter++)
                {
                    int tireYear = int.Parse(input[index]);
                    double tirePressure = double.Parse(input[index + 1]);
                    currentTires[tireCounter] = new Tire(tireYear, tirePressure);
                }

                tires.Add(currentTires);
            }

            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(input[0]);
                double cubicCapacity = double.Parse(input[1]);
                Engine newEngine = new Engine(horsePower, cubicCapacity);

                engines.Add(newEngine);
            }

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = input[0];
                string model = input[1];
                int year = int.Parse(input[2]);
                double fuelQuantity = double.Parse(input[3]);
                double fuelConsumption = double.Parse(input[4]);
                int engineIndex = int.Parse(input[5]);
                int tiresIndex = int.Parse(input[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));
            }

            var filterCars = cars.Where(car => car.Year >= 2017 && car.Engine.HorsePower > 330
            && car.Tires.Sum(y => y.Pressure) >= 9 && car.Tires.Sum(y => y.Pressure) <= 10).ToList();

            if (filterCars.Any())
            {

            }
            foreach (var car in filterCars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }

        }
    }
}

