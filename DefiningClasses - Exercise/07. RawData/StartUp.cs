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
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                double tirePressure1 = double.Parse(data[5]);
                int tireAge1 = int.Parse(data[6]);
                double tirePressure2 = double.Parse(data[7]);
                int tireAge2 = int.Parse(data[8]);
                double tirePressure3 = double.Parse(data[9]);
                int tireAge3 = int.Parse(data[10]);
                double tirePressure4 = double.Parse(data[11]);
                int tireAge4 = int.Parse(data[12]);

                Engine engine = new Engine(engineSpeed,enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                var tires = new Tires[]
                {
                    new Tires(tireAge1,tirePressure1),
                    new Tires(tireAge2,tirePressure2),
                    new Tires(tireAge3,tirePressure3),
                    new Tires(tireAge4,tirePressure4)
                };
                cars.Add(new Car(model, engine, cargo, tires));

            }
            string typeOfCargo = Console.ReadLine();
            switch (typeOfCargo)
            {
                case"fragile":
                    cars.Where(x => x.Cargo.CargoType == typeOfCargo)
                        .Where(x => x.Tires.Any(p => p.Pressure < 1))
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.Model));
                    break;
                case "flamable":
                    cars.Where(x => x.Cargo.CargoType == typeOfCargo)
                        .Where(x => x.Engine.EnginePower > 250)
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.Model));
                    break;
            }
        }
    }
}
