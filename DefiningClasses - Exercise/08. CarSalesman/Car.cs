using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;
        public Car(string model, Engine engine, int weight = 0, string color = "n/a")
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public string Model 
        {
            get { return this.model; }
            set { this.model = value; } 
        }
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public override string ToString()
        {
            string weight = this.Weight == 0 ? "n/a" : this.Weight.ToString();
            return string.Format($"{this.Model}:" + Environment.NewLine +
                                   $"{this.Engine}" + Environment.NewLine +
                                   $"  Weight: {weight}" + Environment.NewLine +
                                   $"  Color: {this.Color}");               
        }
    }
}
