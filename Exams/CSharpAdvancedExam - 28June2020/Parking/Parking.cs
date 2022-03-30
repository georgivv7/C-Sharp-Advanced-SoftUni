using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;
        private string type;
        private int capacity;

        public int Count => this.cars.Count;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Cars = new List<Car>(this.Capacity);
        }
        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }
        public void Add(Car car)
        {
            if (this.Capacity > this.Cars.Count)
            {
                this.Cars.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (this.Cars.Any(x => x.Manufacturer == manufacturer) && this.Cars.Any(x => x.Model == model))
            {
                var car = this.Cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
                this.Cars.Remove(car);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Car GetLatestCar()
        {
            var latestCar = this.Cars.OrderByDescending(x => x.Year).FirstOrDefault();
            return latestCar;
        }
        public Car GetCar(string manufacturer, string model)
        {
            var car = this.Cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return car;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.Cars)
            {
                sb.AppendLine($"{car.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
