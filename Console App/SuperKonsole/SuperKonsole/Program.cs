using System;
using System.Collections.Generic;

namespace SuperKonsole
{
    internal class Program
    {
        static void Main()
        {
            // sets console name
            Console.Title = "SuperKonsole";

            // initialzes array and assigns values to it
            int count;
            string suffix;
            string[] names = new string[3];
            names[0] = "Amanda";
            names[1] = "Steve";
            names[2] = "Lorri";

            // gets a suffix from the user
            Console.WriteLine("Your family members don't have a last name! Type one now.");
            suffix = " " + Console.ReadLine();

            // adds the suffix to the names
            for (count = 0; count < names.Length; count++)
            {
                names[count] += suffix;
            }

            // prints the names
            Console.WriteLine("\nThe names are:\n");
            for (count = 0; count < names.Length; count++)
            {
                Console.WriteLine(names[count]);
            }
            Console.ReadLine();
        }
    }
}
