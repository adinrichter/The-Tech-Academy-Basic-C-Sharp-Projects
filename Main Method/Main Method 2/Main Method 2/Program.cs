using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Main_Method_2
{
    internal class Program
    {
        public class Global
        {
            public static float exp;
        }
        static void Main()
        {
            Console.WriteLine("Please enter a number: ");
            float num = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Please enter an exponent, leave blank to square: ");
            try
            {
                Global.exp = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine(num + " to the power " + Global.exp + " is: " + Math.Exponent(num, Global.exp));
            }
            catch
            {
                Console.WriteLine(num + " squared is: " + Math.Exponent(num));
            }
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
