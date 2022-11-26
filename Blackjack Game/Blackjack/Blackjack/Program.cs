using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Remoting.Contexts;
using Casino;
using Casino.Blackjack;
using static System.Net.WebRequestMethods;

namespace Blackjack 
{
    class Program
    {
        public class Global
        {
            public static int pot;
            public static string name;
        }
        static void Main()
        {
            Console.WriteLine("Hello, and welcome to digital Blackjack, what is your name?");
            Global.name = Console.ReadLine();
            if (Global.name.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions();
                foreach (var exception in Exceptions)
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptionType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + " | ");
                    Console.Write(Environment.NewLine);
                }
                Console.Read();
                return;
            }
            do
            {
                try
                {
                    Console.WriteLine("How many chips would you like to play with? (enter a number)");
                    Global.pot = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please enter a number");
                }
            } while (true);

            Console.WriteLine("Welcome {0} to the game of Blackjack, you have {1} chips to play with.\nAre you ready to play? Type (y) if yes, anything else for no.", Global.name, Global.pot);
            string response = Console.ReadLine();

            bool ready = response == "y" ? true : false;

            if (ready)
            {
                Player player = new Player(Global.name, Global.pot);
                player.ID = Guid.NewGuid();
                using (StreamWriter file = new StreamWriter(@"..\..\logs\logs.txt", true))
                {
                    file.WriteLine(player.ID);
                }
                Game game = new BlackjackGame();
                game += player;
                player.isPlaying = true;
                while (player.isPlaying && player.Pot > 0)
                {
                    try
                    {
                        game.Play();
                    }
                    catch (FraudException ex)
                    {
                        Console.WriteLine(ex.Message);
                        AddDBException(ex);
                        Console.ReadKey();
                        return;
                    }
                    catch (Exception ex)
                    {;
                        Console.WriteLine("Error: " + ex.Message);
                        AddDBException(ex);
                        Console.ReadKey();
                        return;
                    }
                }
            }
            Console.WriteLine("See you next time!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void AddDBException(Exception ex)
        {
            string connectString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = Blackjack;Integrated Security = True;
                                  Connect Timeout = 30; Encrypt = False;TrustServerCertificate = False;
                                  ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            string queryString = @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, Timestamp) VALUES
                             (@ExceptionType, @ExceptionMessage, @TimeStamp)";

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private static List<ExceptionEntity> ReadExceptions()
        {
            string connectString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = Blackjack;Integrated Security = True;
                                  Connect Timeout = 30; Encrypt = False;TrustServerCertificate = False;
                                  ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            string queryString = @"Select Id, ExceptionType, ExceptionMessage, TimeStamp From Exceptions";

            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    ExceptionEntity exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]);
                    exception.ExceptionType = reader["ExceptionType"].ToString();
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(exception);
                }
                connection.Close();
            }
            return Exceptions;
        }
    }
}
