using System;


namespace Car_Insurance
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Car Insurance Approver";
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Have you ever had a DUI? (response must be \"true\"/\"false\")");
            bool dui = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("How many speeding tickets do you have?");
            int tickets = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Qualified?");
            Console.WriteLine(age > 15 && dui == false && tickets <= 3);
            Console.ReadLine();
        }
    }
}
