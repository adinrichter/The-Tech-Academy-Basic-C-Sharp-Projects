using System;
using System.Collections.Generic;

namespace Strings_and_Integers
{
    public static class Global
    {
        public static int input;
    }
    internal class Program
    {
        static void Main()
        {
            // declare variable
            List<int> integers = new List<int>();
            bool response = false;


            // add values to list
            integers.Add(1);
            integers.Add(2);
            integers.Add(3);
            integers.Add(4);
            integers.Add(5);
            integers.Add(6);
            integers.Add(7);
            integers.Add(8);
            integers.Add(9);
            integers.Add(10);

            // name console
            Console.Title = "Strings and Integers";

            // asks the user to enter a number that all integers in the list will be divided by
            Console.WriteLine("Enter a number to divide all integers in the list by: ");

            // converts the user's input to an integer and handles appropriate errors
            do
            {
                try
                {
                    Global.input = Convert.ToInt32(Console.ReadLine());
                    response = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Please enter a number that is not too large.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Fatal error");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            } while (!response);
            response = false;

            // loops through integers list and divides each integer by the user's input
            do
            {
                try
                {
                    // loops through the list and divides each integer by the user's input
                    foreach (int integer in integers)
                    {
                        Console.WriteLine(integer / Global.input + " mod " + integer % Global.input);
                    }
                    response = true;
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("You cannot divide by zero.");
                    Console.Read();
                    Environment.Exit(0);
                }
            } while (!response);
            Console.ReadLine();
        }
    }
}
