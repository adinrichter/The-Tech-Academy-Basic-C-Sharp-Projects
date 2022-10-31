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
            // the exponent function returns the number squared by default
            Console.WriteLine("20 squared is: " + Math.Exponent(20f));
            // the exponent function returns the any desired exponent if given in the argument
            Console.WriteLine("20 cubed is: " + Math.Exponent(20f, 3));
            Console.WriteLine("20 to the power 6 is: " + Math.Exponent(20f, 6));
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
