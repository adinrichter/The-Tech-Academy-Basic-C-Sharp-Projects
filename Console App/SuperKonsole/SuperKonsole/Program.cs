using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace SuperKonsole
{
    internal class Program
    {

        public static class Global
        {
            public static List<string> hobbies = new List<string>();
            public static List<int> ages = new List<int>();
            public static int age;
        }
        static void Main()
        {

            // adds default hobbies to the list
            Global.hobbies.Add("Hiking");
            Global.hobbies.Add("Skiing");
            Global.hobbies.Add("Fishing");
            Global.hobbies.Add("Golfing");

            // adds ages to ages list
            Global.ages.Add(21);
            Global.ages.Add(24);
            Global.ages.Add(19);
            Global.ages.Add(28);
            Global.ages.Add(25);
            Global.ages.Add(21);
            Global.ages.Add(19);

            // sets console name
            Console.Title = "SuperKonsole";

            // performs operations based on the user's input
            Match();
        }

        static void Match()
        {
            // gives the user instructions
          
            Console.WriteLine("Would you like to search the hobbies, add a hobby, or give your family a last name?");
            Console.WriteLine("Type \"search\" to search for hobbies\n\"add\" to add a hobby\n\"view\" to view all hobbies\n\"clear\" to clear history text\n\"ages\" to view a list of ages\n\"family\" to add a last name");
            Console.WriteLine("You can also type \"exit\" to exit the program.");

            // gets the user's input
            string command = Console.ReadLine();
            
            // matches it
            switch (command)
            {
                case "search":
                    Search();
                    break;
                case "add":
                    Add();
                    break;
                case "family":
                    Family();
                    break;
                case "view":
                    View();
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "ages":
                    Ages();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid command\n");
                    break;
            }
            Match();
        }
        
        static void Ages()
        {
            // prompts for action
            Console.WriteLine("Would you like to search for an age or view all the ages?");
            Console.WriteLine("Type \"search\" or \"view\"");
            string command = Console.ReadLine();

            // matches it
            switch (command)
            {
                case "search":
                    SearchAge();
                    break;
                case "view":
                    ViewAges();
                    break;
                default:
                    Console.WriteLine("Invalid command\n");
                    break;
            }
            Ages();
        }

        static void ViewAges()
        {
            // prints all the ages
            Console.WriteLine("Ages:");

            // creates a list of all duplicates in ages
            IEnumerable<int> duplicates = Global.ages.GroupBy(x => x)
                            .Where(g => g.Count() > 1)
                            .Select(x => x.Key);

            // displays all ages and says whether they are duplicate or unique
            foreach (int age in Global.ages)
            {
                if (duplicates.Contains(age))
                {
                    Console.WriteLine(age + " - duplicate");
                }
                else
                {
                    Console.WriteLine(age + " - unique");
                }
            }
            Console.WriteLine("\n");
            Match();
        }
        
        static void SearchAge()
        {
            // prompts for age
            try
            {
                Console.WriteLine("What age would you like to search for?");
                Global.age = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, must be a number\n");
                SearchAge();
            }


            // searches for age
            if (Global.ages.Contains(Global.age))
            {
                for (int i = 0; i < Global.ages.Count; i++)
                {
                    if (Global.ages[i] == Global.age)
                    {
                        Console.WriteLine("Age " + Global.age + " at index " + i);
                    }
                }
            }
            else
            {
                Console.WriteLine("The age " + Global.age + " is not in the list\n");
            }
            Console.WriteLine("\n");
            Match();
        }
        static void Search()
        {
            // asks the user what hobby they want to search for and normalizes it
            Console.WriteLine("What hobby would you like to search for?\n");
            string search = Console.ReadLine();
            search = char.ToUpper(search[0]) + search.Substring(1).ToLower();

            // checks if the hobby is in the list
            if (Global.hobbies.Contains(search))
            {
                Console.WriteLine("\nYou have the hobby " + search + "!\n");
            }
            else
            {
                Console.WriteLine("\nYou don't have that hobby!\n");
            }
            Match();
        }

        static void Add()
        {
            // asks the user what hobby they want to add
            Console.WriteLine("What hobby would you like to add?\n");
            string add = Console.ReadLine();
            add = char.ToUpper(add[0]) + add.Substring(1).ToLower();

            // adds the hobby to the list if it isn't already in the list
            if (Global.hobbies.Contains(add))
            {
                Console.WriteLine("\nYou already have that hobby!\n");
            }
            else
            {
                Global.hobbies.Add(add);
                Console.WriteLine("\nYou have added " + add + " to your hobbies!\n");
            }
            Match();
        }   

        static void View()
        {
            // prints out all the hobbies in the list
            Console.WriteLine("Your hobbies are:");
            foreach (string hobby in Global.hobbies)
            {
                Console.WriteLine(hobby);
            };
            Console.WriteLine("\n");
            Match();
        }
        static void Family()
        {
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

            // adds the suffix to the names, uses < names.Length to keep the loop from running infinitely
            for (count = 0; count < names.Length; count++)
            {
                names[count] += suffix;
            }

            // prints the names
            Console.WriteLine("\nThe names are:\n");
            for (count = 1; count <= names.Length; count++)
            {
                Console.WriteLine(names[count - 1]);
            }
            Console.WriteLine("\n");
            Match();
        }
    }
}
