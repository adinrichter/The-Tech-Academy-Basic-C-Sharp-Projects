using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_and_Objects
{
    internal class Program
    {
        static void Main()
        {
            // instantiates the employee class and gives it a name
            Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };

            // calls the SayName method on the employee object
            employee.SayName();
            Console.ReadLine();
        }
        public class Person
        {
            // creates the person class
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public void SayName()
            {
                Console.WriteLine("Name: " + FirstName + " " + LastName);
            }
        }
        public class Employee : Person
        {
            // adds an Id integer to the employee class inherited from the person class
            public int Id { get; set; }
        }   
    }
}
