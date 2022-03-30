using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;
        private string name;
        private int capacity;
        public int Count => this.employees.Count;
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>(capacity);
        }
        public List<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public void Add(Employee employee)
        {
            if (this.Capacity > this.Count)
            {
                this.Employees.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            if (this.Employees.Any(x => x.Name == name))
            {
                this.Employees.RemoveAll(x=>x.Name == name);
                return true;
            }
            else
            {
                return false;
            }           
        }
        public Employee GetOldestEmployee()
        {
            var oldest = this.Employees.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldest;
        }
        public Employee GetEmployee(string name)
        {
            var employee = this.Employees.FirstOrDefault(x => x.Name == name);
            return employee;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var employee in this.Employees)
            {
                sb.AppendLine($"{employee.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
