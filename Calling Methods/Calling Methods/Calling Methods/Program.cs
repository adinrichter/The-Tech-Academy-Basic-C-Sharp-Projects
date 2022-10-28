using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calling_Methods
{
    internal class Program
    {
        static void Main()
        {
            // creates variable
            float num;
            bool answered = false;
           
            // sets console title
            Console.Title = "Calling Methods";

            // prompts the user to enter a number
            Console.Write("Enter a number: ");
            do
            {
                try
                {
                    num = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("\n{0} doubled is {1}", num, Math.Double(num));
                    Console.WriteLine("{0} halved is {1}", num, Math.Halve(num));
                    Console.WriteLine("The approximate inverse square root of {0} is {1}", num, Math.ApproxInverseSQRT(num));
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            } while (!answered) ;


            }
        public class Math
        {
            public static float Double(float number)
            {
                return number * 2;
            }
            
            public static float Halve(float number)
            {
                return number / 2;
            }
            
            public static float ApproxInverseSQRT(float number)
            {
                float threehalfs = 0.5f * number;
                int i = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
                i = 0x5f3759df - (i >> 1);
                number = BitConverter.ToSingle(BitConverter.GetBytes(i), 0);
                number = number * (1.5f - threehalfs * number * number);
                return number;
            }
        }
    }
}
