using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superclasses
{
    internal class Program
    {
        static void Main()
        {
            Employee employee = new Employee();
            employee.FirstName = "Sample";
            employee.LastName = "Student";
            employee.SayName();
            Console.ReadLine();
        }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public void SayName()
            {
                Console.WriteLine("Name: " + FirstName + " " + LastName);
            }
        }
        public class Employee : Person
        {
            public int Id { get; set; }
        }
  
    }
}
