using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Method_2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter a number: ");
            float num = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Please enter an exponent: ");
            float exp = Convert.ToSingle(Console.ReadLine());
            // the exponent function returns the number squared by default
            Console.WriteLine(num + " squared is: " + Math.Exponent(num));
            // the exponent function returns the any desired exponent if given in the argument
            Console.WriteLine(num + " to the power " + exp + " is: " + Math.Exponent(num, exp));
            Console.ReadLine();
        }
        public class Math
        {
            public static float Exponent(float num, float exp = 2)
            {
                // multiplies the number by itself the number of times specified by the exponent
                float result = num;
                for (float i = 1; i < exp; i++)
                {
                    result *= num;
                }
                return result;
            }

        }
    }
}
