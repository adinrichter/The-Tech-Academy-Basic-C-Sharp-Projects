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
            // instantiates employee class and gives it a name
            Employee employee = new Employee();
            employee.FirstName = "Sample";
            employee.LastName = "Student";

            // calls the sayname method to return the name
            employee.SayName();
            Console.ReadLine();
        }
        public abstract class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public abstract void SayName();
        }
        public class Employee : Person
        {
            // overrides the sayname method in the person class and returns the name
            public override void SayName()
            {
                Console.WriteLine("Name: " + FirstName + " " + LastName);
            }
        }

    }
}


