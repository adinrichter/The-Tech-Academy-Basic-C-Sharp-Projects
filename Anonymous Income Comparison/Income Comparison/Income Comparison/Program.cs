using System;
using System.Globalization;


namespace Income_Comparison
{
    internal class Program
    {
        static void Main()
        {
            // gets hourly rate and weekly hours of person 1
            Console.Title = "Anonymous Income Comparison Program";
            Console.WriteLine("Person 1:");
            Console.WriteLine("Hourly Rate?");
            string hourlyRate1 = Console.ReadLine();
            Console.WriteLine("Hours worked per week?");
            string hoursWorked1 = Console.ReadLine();
            
            // gets hourly rate and weekly hours of person 2
            
            Console.WriteLine("\nPerson 2:");
            Console.WriteLine("Hourly Rate?");
            string hourlyRate2 = Console.ReadLine();
            Console.WriteLine("Hours worked per week?");
            string hoursWorked2 = Console.ReadLine();
            
            // displays both persons annual salary
            Console.WriteLine("\n\nAnnual salary of Person 1:");
            int annualSalary1 = Convert.ToInt32(hourlyRate1) * Convert.ToInt32(hoursWorked1) * 48;
            Console.WriteLine("$" + annualSalary1.ToString("N", new CultureInfo("en-US")) + "/year");
            Console.WriteLine("\nAnnual salary of Person 2:");
            int annualSalary2 = Convert.ToInt32(hourlyRate2) * Convert.ToInt32(hoursWorked2) * 48;
            Console.WriteLine("$" + annualSalary2.ToString("N", new CultureInfo("en-US")) + "/year");

            // displays whether person 1 makes more, than person 2
            Console.WriteLine("\nDoes Person 1 make more money than Person 2?");
            bool moreMoney = annualSalary1 > annualSalary2;
            Console.WriteLine(moreMoney ? "Yes" : "No");
            Console.ReadLine();
        }
    }
}
