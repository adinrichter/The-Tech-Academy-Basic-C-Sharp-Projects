﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                Console.WriteLine("Let's play!");
                Player player = new Player(Global.name, Global.pot);
                Game game = new Blackjack();
                game += player;
                player.isPlaying = true;
                while (player.isPlaying && player.Pot > 0)
                {
                    game.Play();
                }
                game -= player;
            }
            Console.WriteLine("See you next time!");
            Console.ReadLine();
            Environment.Exit(0);
        }
       
    }
}
