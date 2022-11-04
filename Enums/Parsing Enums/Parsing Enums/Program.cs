using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing_Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("Please enter the current day of the week: ");
                try
                {
                    int no = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Must be a day of the week.");
                }
                catch
                {
                    try
                    {
                        Days day = (Days)Enum.Parse(typeof(Days), Console.ReadLine().ToLower());
                        Console.WriteLine("Thank you, goodbye.");
                        Console.ReadLine();
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter an actual day of the week.\n");
                    }
                }
            } while (true);

        }
        // Creates an enum with days of the week
        enum Days
        {
            monday,
            tuesday,
            wednesday,
            thursday,
            friday,
            saturday,
            sunday
        }
    }
}

