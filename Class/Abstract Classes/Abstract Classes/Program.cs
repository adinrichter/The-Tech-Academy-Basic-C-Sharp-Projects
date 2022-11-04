using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Classes
{
    internal class Program
    {
        static void Main()
        {
            // instantiates employee class and gives it a name, then calls the quit method on it
            Employee employee = new Employee() { FirstName = "Joe", LastName = "Wilson" };
            employee.Quit();

            // instantiates a class of quitter from the IQuittable interface and calls the quit method on it
            Quitter quitter = new Quitter();
            quitter.Quit();

            // uses readline to keep the program open for viewing
            Console.ReadLine();
        }
        public abstract class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public abstract void SayName();
        }
        public class Employee : Person, IQuittable
        {
            // overrides the sayname method in the person class and returns the name
            public override void SayName()
            {
                Console.WriteLine("Name: " + FirstName + " " + LastName);
            }
            public void Quit()
            {
                Console.WriteLine("I, " + FirstName + " " + LastName + ", quit!");
            }
        }
        public class Quitter : IQuittable
        {
            public void Quit()
            {
                Console.WriteLine("I quit!");
            }
        }
    }
}


