using System;
using System.IO;
class Program
{
    static void Main()
    {
        // Sets the name of the program
        Console.Title = "Tech Academy Course Report";
        
        // Gets user input
        Console.WriteLine("What is your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("\nWhat course are you on: ");
        string course = Console.ReadLine();
        Console.WriteLine("\nWhat page number are you on: ");
        string pagenumber = Console.ReadLine();
        Console.WriteLine("\nDo you need help with anything: ");
        string help = Console.ReadLine();
        Console.WriteLine("\nWere there any positive experiences you'd like to share: ");
        string positive = Console.ReadLine();
        Console.WriteLine("\nIs there any other feedback you'd like to provide: ");
        string feedback = Console.ReadLine();
        Console.WriteLine("\nHow many hours did you study today: ");
        string hours = Console.ReadLine();
        Console.WriteLine("\nThank you for your answers. An Instructor will respond to this shortly. Have a great day! (press Enter to close)");
        Console.ReadLine();

        // Compiles responses into one string
        string parsedResponses = "Name: " + name + "\nCourse: " + course + "\nPage Number: " + pagenumber + "\nHelp: " + help + "\nPositive: " + positive + "\nFeedback: " + feedback + "\nHours Studied: " + hours + "\n\n";

        // Gets past responses written
        string currentResponses = File.ReadAllText("./reports.txt");

        // Adds new responses to previously written ones and writes them
        // This could theoretically cause issues since I'm overwriting the entire file, but I don't care
        File.WriteAllText("./reports.txt", currentResponses + parsedResponses);
    }
}