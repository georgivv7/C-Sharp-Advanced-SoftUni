using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] dataEngine = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = dataEngine[0];
                int power = int.Parse(dataEngine[1]);
                var engine = new Engine(model, power);
                if (dataEngine.Length == 3)
                {
                    if (int.TryParse(dataEngine[2],out int displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = dataEngine[2];
                    }
                }
                else if (dataEngine.Length == 4)
                {
                    int displacement = int.Parse(dataEngine[2]);
                    engine.Displacement = displacement;
                    string efficiency = dataEngine[3];
                    engine.Efficiency = efficiency;
                }
                engines.Add(engine);
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] infoCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = infoCar[0];
                string engineModel = infoCar[1];
                var engine = engines.Find(x=>x.Model == engineModel);
                var car = new Car(model, engine);
                if (infoCar.Length == 3)
                {
                    if (int.TryParse(infoCar[2], out int weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = infoCar[2];
                    }
                }
                else if (infoCar.Length == 4)
                {
                    int weight = int.Parse(infoCar[2]);
                    car.Weight = weight;
                    string color = infoCar[3];
                    car.Color = color;
                }
                cars.Add(car);
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
