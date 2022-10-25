using System;
using System.Collections.Generic;

namespace Arrays
{
    internal class Program
    {
        public static class Global
        {
            public static int index;
        }
        static void Main()
        {
            // sets console name
            Console.Title = "Array Selector";

            // initialize variable
            bool interaction;

            // create an array of strings and populate values
            string[] names = new string[5];
            names[0] = "John";
            names[1] = "Mary";
            names[2] = "Bob";
            names[3] = "Jane";
            names[4] = "Joe";

            // create a array of integers and populate values
            int[] ages = new int[5];
            ages[0] = 21;
            ages[1] = 18;
            ages[2] = 25;
            ages[3] = 19;
            ages[4] = 22;

            // create a list of strings and populate values
            List<string> hobbies = new List<string>();
            hobbies.Add("Fishing");
            hobbies.Add("Hiking");
            hobbies.Add("Archery");
            hobbies.Add("Rock Climbing");
            hobbies.Add("Offroading");

            // prompts user to get a value from the string name array
            do
            {
                interaction = true;
                try
                {
                    Console.WriteLine("Enter a number between 1 and 5 to get a name from the string array: ");
                    Global.index = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine("The name at index " + (Global.index + 1) + " is " + names[Global.index] + ".");
                    interaction = false;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The array does not contain an index of " + (Global.index + 1) + ".\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid character input.\n");
                }
            }
            while (interaction == true);
            

            // prompts user to get a value from the integer array
            do
            {
                interaction = true;
                try
                {
                    Console.WriteLine("\nEnter a number between 1 and 5 to get an age from the integer array: ");
                    Global.index = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine("The age at index " + (Global.index + 1) + " is " + ages[Global.index]);
                    interaction = false;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The array does not contain an index of " + (Global.index + 1) + ".\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid character input.\n");
                }
            }
            while (interaction == true);

            // prompts user to get a value from the string list
            do
            {
                interaction = true;
                try
                {
                    Console.WriteLine("\nEnter a number between 1 and 5 to get a hobby from the string list: ");
                    Global.index = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine("The hobby at index " + (Global.index + 1) + " is " + hobbies[Global.index]);
                    interaction = false;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The array does not contain an index of " + (Global.index + 1) + ".\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid character input.\n");
                }
            }
            while (interaction == true);


            // finalizes program
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
