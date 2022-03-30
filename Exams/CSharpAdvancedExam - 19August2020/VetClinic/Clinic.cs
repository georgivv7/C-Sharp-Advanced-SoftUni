using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;
        private int capacity;
        public int Count => this.pets.Count;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.Pets = new List<Pet>(this.Capacity);
        }
        public List<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public void Add(Pet pet)
        {
            if (this.Capacity > this.Count)
            {
                this.Pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            if (this.Pets.Any(x => x.Name == name))
            {
                var pet = this.Pets.FirstOrDefault(x => x.Name == name);
                this.Pets.Remove(pet);
                return true;
            }
            else
            {
                return false;
            }           
        }
        public Pet GetPet(string name, string owner)
        {
            var pet = this.Pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            return pet;
        }
        public Pet GetOldestPet()
        {
            var oldestPet = this.Pets.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.Pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().Trim();
        }
    }
}
