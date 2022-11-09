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
            Console.WriteLine("Please enter a day of the week: ");
            do
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

