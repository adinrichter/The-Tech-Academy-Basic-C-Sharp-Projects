using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_assignment
{
    internal class Program
    {
        static void Main()
        {
            // Create a new instance of the class
            Knowledge knowledge = new Knowledge();
            
            // gets number from the user and sends it to the single decimal function
            Console.WriteLine("Enter a number to be halved");
            decimal number = Convert.ToDecimal(Console.ReadLine());
            knowledge.Half(number);
            
            // gets number from the user and sends it to the double decimal function to find the halfway point between the two numbers
            Console.WriteLine("Enter the first number");
            decimal firstNumber = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the second number to get the halfway point between both of them");
            decimal secondNumber = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Halfway between " + firstNumber + " and " + secondNumber + " is " + Knowledge.Half(firstNumber, secondNumber));
            Console.ReadLine();
        }
        public class Knowledge
        {
            public void Half(decimal number)
            {
                // divides the number by 2 and displays the result
                Console.WriteLine("Half of " + number + " is " + number / 2);
            }
            public static decimal Half(decimal number, decimal number2)
            {
                // averages the numbers together and returns the result
                return (number + number2) / 2;
            }
        }
    }
}