using System;
using System.Collections.Specialized;
using System.IO;

// defines global variables
public static class Global
{
    // response boolean for while loops
    public static bool response;

    // output to be used in loops
    public static int page;
    public static bool needsHelp;
    public static int hours;
}

class Program
{
    static void Main()
    {
        // defines local variables
        string name;
        string course;
        string positive;
        string feedback;

        // sets the name of the console window
        Console.Title = "Tech Academy Course Report";
        
        // gets user's full name
        Console.WriteLine("What is your full name?");
        name = Console.ReadLine();

        // gets course name
        Console.WriteLine("\nWhat course are you on?");
        course = Console.ReadLine();
        
        // Gets user's page number and verifies that it is a number
        Console.WriteLine("\nWhat page number are you on? (must be a number)");
        Global.response = false;
        while (Global.response == false)
        {
            try
            {
                Global.page = Convert.ToInt32(Console.ReadLine());
                Global.response = true;
            }
            catch
            {
                Console.WriteLine("\nThe response must be a number\nWhat page number are you on?");
            }
        }

        // gets true/false response to whether or not the user needs help
        Console.WriteLine("\nDo you need help with anything? (y/n)");
        Global.response = false;
        while (Global.response == false)
        {
            switch (Console.ReadLine())
            {
                case "y": Global.needsHelp = true; Global.response = true; break;
                case "n": Global.needsHelp = false; Global.response = true; ; break;
                default: Console.WriteLine("\nPlease enter 'y' or 'n'\nDo you need help with anything?"); break;
            }
        }
        
        // gets user's positive feedback
        Console.WriteLine("\nWere there any positive experiences you'd like to share?");
        positive = Console.ReadLine();

        // gets additional feedback
        Console.WriteLine("\nIs there any other feedback you'd like to provide?");
        feedback = Console.ReadLine();

        // gets number of hours spent on the course
        Console.WriteLine("\nHow many hours did you study today? (must be a number)");
        Global.response = false;
        while (Global.response == false)
        {
            try
            {
                Global.hours = Convert.ToInt16(Console.ReadLine());
                Global.response = true;
            }
            catch
            {
                Console.WriteLine("\nThe response must be a number\nHow many hours did you study today?");
            }
        }

        // tells user that the report is being saved
        Console.WriteLine("\nThank you for your answers. An Instructor will respond to this shortly. Have a great day!");

        // compiles responses into one string
        string parsedResponses = 
            "Name: " + name + 
            "\nCourse Name: " + course + 
            "\nPage Number: " + Global.page + 
            "\nDoes the user need help: " + Global.needsHelp + 
            "\nPositive: " + positive + 
            "\nFeedback: " + feedback + 
            "\nHours Studied: " + Global.hours + 
            "\n\n";

        // gets past responses
        string currentResponses = File.ReadAllText("./reports.txt");

        // adds new responses to previously written ones and writes them
        // this could theoretically cause issues if corruption occurs but I don't care
        File.WriteAllText("./reports.txt", currentResponses + parsedResponses);
    }
}