using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Blackjack : Game, IQuit
    {
        public override void Play()
        {
            throw new NotImplementedException();
        }
        public override void ListPlayers()
        {
            Console.WriteLine("Blackjack players: ");
            base.ListPlayers();
        }
        public void Quit(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
