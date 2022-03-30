using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public int Count => this.cars.Count;
        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>(this.capacity);
        }
        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public string AddCar(Car car)
        {
            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.Count == this.cars.Capacity)
            {
                return "Parking is full";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                var car = cars.First(x => x.RegistrationNumber == registrationNumber);
                this.cars.Remove(car);
                return $"Successfully removed {car.RegistrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.First(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var regNumber in RegistrationNumbers)
            {                              
                if (this.cars.Any(x => x.RegistrationNumber == regNumber))
                {
                    var car = cars.First(x => x.RegistrationNumber == regNumber);
                    this.cars.Remove(car);
                }
            }
        }

    }
}
