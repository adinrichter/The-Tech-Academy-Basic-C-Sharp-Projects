using System;


namespace While_and_Do_While
{
    internal class Program
    {
        public static class Global
        {
            public static int guess;
            public static int num;
            public static Random rand = new Random();
        }
        static void Main()
        {
            // sets the console title
            Console.Title = "Guess the number";

            // generates a random number between 1 and 10 to be used
            Global.num = Global.rand.Next(1, 10);
            
            // prompts the user to guess the number
            Console.WriteLine("Guess the number between 1 and 10 (no hints)");

            // loops until the user guesses the correct number
            while (Global.guess != Global.num) {
                try
                {
                    Global.guess = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Global.guess = 0;
                }
                finally
                {
                    if (Global.guess != Global.num && (Global.guess >= 1 && Global.guess <= 10))
                    {
                        Console.WriteLine("Wrong, try again");
                    }
                    else if (Global.guess != Global.num && (Global.guess < 1 || Global.guess > 10))
                    {
                        Console.WriteLine("Please enter a number between 1 and 10");
                    }
                }
            }

            // congratulates the user on guessing correctly
            Console.WriteLine("You guessed correctly! Now on to something a bit harder...");
            
            // generates a larger number, but gives hints
            Global.num = Global.rand.Next(1, 100);

            // prompts the user to guess the number
            Console.WriteLine("\nGuess the number between 1 and 100 (with hints)");

            // loops until the user guesses the correct number
            do
            {
                try
                {
                    Global.guess = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Global.guess = 0;
                }
                finally
                {
                    if (Global.guess != Global.num && (Global.guess >= 1 && Global.guess <= 100))
                    {
                        if (Global.guess > Global.num)
                        {
                            Console.WriteLine("Wrong, try again (lower)");
                        }
                        else
                        {
                            Console.WriteLine("Wrong, try again (higher)");
                        }
                    }
                    else if (Global.guess != Global.num && (Global.guess < 1 || Global.guess > 100))
                    {
                        Console.WriteLine("Please enter a number between 1 and 100");
                    }
                }
            }
            while (Global.guess != Global.num);
            

            // congratulates the user on guessing correctly
            Console.WriteLine("Congratulations, you guessed the right number!");
            Console.ReadLine();
        }
    }
}
