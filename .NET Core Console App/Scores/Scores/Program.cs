using System;

namespace Scores
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter your first name:");
            string date = DateTime.Today.ToShortDateString();
            string uName = Console.ReadLine();
            string msg = $"\nWelcome back {uName}. Today is {date}";
            Console.WriteLine(msg);

            string path = @"C:\Users\Adin\Documents\GitHub\The-Tech-Academy-Basic-C-Sharp-Projects\.NET Core Console App\Scores\Scores\studentScores.txt";
            string[] lines = System.IO.File.ReadAllLines(path);

            double tScore = 0.0;

            Console.WriteLine("\nStudent Scores:");
            foreach (string line in lines)
            {
                Console.Write(Environment.NewLine + line);
                double score = Convert.ToDouble(line);
                tScore += score;
            }

            double avgScore = tScore / lines.Length;
            Console.WriteLine($"\nTotal of {lines.Length} student scores \tAverage Score: {avgScore}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
