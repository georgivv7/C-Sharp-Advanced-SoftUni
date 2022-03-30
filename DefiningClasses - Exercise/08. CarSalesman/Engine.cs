using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;
        public Engine(string model, int power, int displacement=0,string efficiency="n/a")
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public string Model 
        {
            get { return this.model; }
            set { this.model = value; } 
        }
        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }
        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }
        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }
        public override string ToString()
        {
            string displacement = this.Displacement == 0 ? "n/a" : this.Displacement.ToString();
            return string.Format($"  {this.Model}:" + Environment.NewLine +
                                   $"    Power: {this.Power}" + Environment.NewLine +
                                   $"    Displacement: {displacement}" + Environment.NewLine +
                                   $"    Efficiency: {this.Efficiency}");
        }
    }
}
