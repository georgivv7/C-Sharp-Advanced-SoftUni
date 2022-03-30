using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);
                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }
            string commands = string.Empty;
            while((commands = Console.ReadLine())!= "End")
            {
                string[] data = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[1];
                double kilometers = double.Parse(data[2]);
                var tempCar = cars.Where(x => x.Model == model).FirstOrDefault();
                tempCar.CalculateKilometers(kilometers);                
            }

            foreach (var car in cars)
            {
                car.Print();
            }
        }
    }
}
