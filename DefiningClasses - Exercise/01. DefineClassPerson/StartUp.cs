using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person("Peter", 20);
            Person secondPerson = new Person()
            {
                Name = "George",
                Age = 18
            };
            Person thirdPerson = new Person();
            thirdPerson.Name = "Sam";
            thirdPerson.Age = 43;
        }
    }
}
