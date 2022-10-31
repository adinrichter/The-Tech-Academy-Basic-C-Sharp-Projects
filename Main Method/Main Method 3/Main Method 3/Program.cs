using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Method_3
{
    internal class Program
    {
        static void Main()
        {
            Math.Operation(1, 2);
            Math.Operation(in1: 8, in2: 41);
            Console.ReadLine();
        }
        public class Math
        {
            public static void Operation(int in1, int in2)
            {
                string result = in1 * 2 + " " + in2;
                Console.WriteLine(result);
            }
        }
    }
}
