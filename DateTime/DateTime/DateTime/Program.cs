using System;

namespace DateTime
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Date and Time";

            Console.WriteLine("The current time is [{0}]", ShowDateTime());
            GetIntInput("Enter a number of hours to offset the time by:", out double offset);
            Console.WriteLine("The time [{0}] offset by {1} hour{2} is [{3}]", ShowDateTime(), offset, (offset == 1 ? "" : "s"), ShowDateTime(offset));
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        public static double? GetIntInput(string message, out double result)
        {
            int? num = null;
            do
            {
                Console.WriteLine(message);
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            } while (num == null);
            
            result = (double)num;
            return result;
        }

        public static string ShowDateTime(double offset = 0) {
            var date = System.DateTime.Now;
            return date.AddHours(offset).ToString("hh:mm MM/dd/yyyy"); 
        }
    }
}
