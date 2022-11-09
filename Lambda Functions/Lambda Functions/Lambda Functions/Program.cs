using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Functions
{
    internal class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { ID = 1, FirstName = "Joe", LastName = "Smith" });
            employees.Add(new Employee() { ID = 2, FirstName = "Amanda", LastName = "Maxwell" });
            employees.Add(new Employee() { ID = 3, FirstName = "Anthony", LastName = "Reardon" });
            employees.Add(new Employee() { ID = 4, FirstName = "Jason", LastName = "Taylor" });
            employees.Add(new Employee() { ID = 5, FirstName = "Steven", LastName = "Martin" });
            employees.Add(new Employee() { ID = 6, FirstName = "Laura", LastName = "Daniels" });
            employees.Add(new Employee() { ID = 7, FirstName = "Joe", LastName = "Daniels" });
            employees.Add(new Employee() { ID = 8, FirstName = "Patricia", LastName = "Korra" });
            employees.Add(new Employee() { ID = 9, FirstName = "Andy", LastName = "Wilson" });
            employees.Add(new Employee() { ID = 10, FirstName = "Mark", LastName = "Paul" });

            // creates a list of employees with the first name "Joe"
            List<Employee> joesForeach = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.FirstName == "Joe")
                {
                    joesForeach.Add(employee);
                }
            }

            // creates a lambda function which returns a list of all items in the employees list with the FirstName of "Joe"
            List<Employee> joesLambda = employees.Where(x => x.FirstName == "Joe").ToList();

            // creates a almbda function which returns a list of all items in the employees list with an ID greater than 5
            List<Employee> idLambda = employees.Where(x => x.ID > 5).ToList();
        }
    

        public class Employee
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
