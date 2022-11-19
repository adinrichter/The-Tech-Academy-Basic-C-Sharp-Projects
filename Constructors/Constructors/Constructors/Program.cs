using System;

namespace Constructors
{
    internal class Program
    {
        static void Main()
        {
            const string Title = "Constructors";
            Console.Title = Title;

            var variable = "Construction";
            Console.WriteLine(variable);
            
            Construction construction = new Construction();
            Console.WriteLine("This thing was built {0} times on: {1}", construction.Count, construction.Date);

            Console.ReadLine();
        }

        public class Construction
        {
            public DateTime Date;
            public int Count = 10;

            public Construction()
            {
                Date = DateTime.Now;
            }
            public Construction(int inputCount) : this()
            {
                this.Count = inputCount;
            }
        }
    }
}
