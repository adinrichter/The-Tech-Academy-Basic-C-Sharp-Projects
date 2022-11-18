using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        public Player(string name, int pot)
        {
            Hand = new List<Card>();
            Name = name;
            Pot = pot;
        }
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get { return _hand; } set { _hand = value; } }

        public int Pot { get; set; }
        public string Name { get; set; }
        public bool isPlaying { get; set; }
        public bool Stay { get; set; } 
        public bool Bet(int amount)
        {
            if (Pot - amount < 0)
            {
                Console.WriteLine("You do not have enough to place a bet that size.");
                return false;
            }
            else
            {
                Pot -= amount;
                return true;
            }
        }
        public static Game operator +(Game game, Player player)
        {
            game.Players.Add(player);
            return game;
        }
        public static Game operator -(Game game, Player player)
        {
            game.Players.Remove(player);
            return game;

        }
    }
}
