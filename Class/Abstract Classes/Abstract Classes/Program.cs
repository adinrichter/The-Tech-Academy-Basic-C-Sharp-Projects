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
            // instantiates the employee class a couple times
            Employee Joe = new Employee() { FirstName = "Joe", LastName = "Wilson", ID = 10112 };
            Employee Jonathan = new Employee() { FirstName = "Jonathan", LastName = "Smith", ID = 10112 };
            Employee Alexander = new Employee() { FirstName = "Alexander", LastName = "Michaels", ID = 39825 };

            // uses the overload operator to compare two employees
            Console.WriteLine(Joe == Jonathan);
            Console.WriteLine(Joe == Alexander);
            
            // uses readline to keep the program open for viewing
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
            public int ID { get; set; }

            // overrides the == and != operators to compare 2 employees id numbers
            public static bool operator == (Employee employee1, Employee employee2) {
                bool status = false;
                if (employee1.ID == employee2.ID)
                {
                    status = true;
                }
                return status;
            }
            public static bool operator !=(Employee employee1, Employee employee2)
            {
                bool status = false;
                if (employee1.ID != employee2.ID)
                {
                    status = true;
                }
                return status;
            }
        }
    }
}


