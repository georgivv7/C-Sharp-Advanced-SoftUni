using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double traveledDistance;
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TraveledDistance = 0;
        }
        public string Model 
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double FuelConsumption
        {
            get {return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public double TraveledDistance
        {
            get { return this.traveledDistance; }
            set { this.traveledDistance = value; }
        }
        public void CalculateKilometers(double traveledDistance)
        {
            double fuelConsumed = (traveledDistance * this.fuelConsumption);
            if (fuelConsumed <= this.fuelAmount)
            {
                this.fuelAmount -= fuelConsumed;
                this.traveledDistance += traveledDistance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public void Print()
        {
            Console.WriteLine($"{this.Model} {this.FuelAmount:F2} {this.TraveledDistance}");
        }
    }
}
