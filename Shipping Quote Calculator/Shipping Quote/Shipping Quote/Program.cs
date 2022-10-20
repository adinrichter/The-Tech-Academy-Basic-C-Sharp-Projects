using System;
using System.Globalization;


namespace Shipping_Quote
{
    internal class Program
    {
        static void Main()
        {
            // sets the console title and introduction text
            Console.Title = "Package Express Shipping Interface";
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below to recieve your shipping quote.");

            // asks for the package weight and stores it in a variable
            Console.WriteLine("\nPlease enter the package weight (lbs):");
            int weight = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Entered weight: " + weight + " lbs");

            // checks if the package is too heavy
            if (weight > 50)
            {
                Console.WriteLine("Sorry, this package too heavy to be shipped via Package Express.");
                Console.ReadLine();
                return;
            }

            // asks for the package width and stores it in a variable
            Console.WriteLine("Please enter the package width (inches):");
            int width = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Entered width: " + width + " inches");

            // asks for the package height and stores it in a variable
            Console.WriteLine("Please enter the package height (inches):");
            int height = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Entered height: " + height + " inches");
            
            // asks for the package length and stores it in a variable
            Console.WriteLine("Please enter the package length (inches):");
            int length = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Entered length: " + length + " inches");

            // checks if the package is too big
            if (width + height + length > 50)
            {
                Console.WriteLine("Sorry, this package measuring " + (width + height + length) + " total inches is too big to be shipped via Package Express.");
                Console.ReadLine();
                return;
            }

            // calculates the quote and converts it into a string with two decimal places and parsed by commas
            decimal estimate = (width * height * length * weight) / 100m;
            string quote = estimate.ToString("N", new CultureInfo("en-US"));

            // returns the quoted price to the user
            Console.WriteLine("Your estimated total for shipping this package is: $" + quote);
            Console.ReadLine();
        }
    }
}
