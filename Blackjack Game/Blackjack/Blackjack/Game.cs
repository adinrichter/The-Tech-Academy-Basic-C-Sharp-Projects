
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public abstract class Game
    {
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>();
        private List<Player> _players = new List<Player>();

        public List<Player> Players { get { return _players; } set { _players = value; } }
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } }

        public string Name { get; set; }
        public string Dealer { get; set; }

     
        public abstract void Play();
        
        public virtual void ListPlayers()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player);
            }
        }
    }
}
