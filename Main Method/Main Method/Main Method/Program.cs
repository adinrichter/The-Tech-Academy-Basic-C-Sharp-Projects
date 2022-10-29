using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Method
{
    internal class Program
    {
        static void Main()
        {
            // calls the different methods with different parameters
            Console.WriteLine(Math.Operate(8));
            Console.WriteLine(Math.Operate(8.0m));
            Console.WriteLine(Math.Operate("8"));
            Console.ReadLine();
        }
    }
    public class Math
    {
        // takes in an integer and returns double it
        public static int Operate(int number)
        {
            int result = number * 2;
            return result; 
        }
        // takes in a decimal and returns half of it
        public static decimal Operate(decimal number)
        {
            decimal result = number / 2;
            return result;
        }
        // takes in a string and returns the string + 2
        public static int Operate(string number)
        {
            int result = Convert.ToInt32(number) + 2;
            return result;
        }
    }
}
