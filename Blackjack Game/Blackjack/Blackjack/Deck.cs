using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        public Deck()
        {
            // creates card list
            Cards = new List<Card>();
            
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;
                    card.Suit = (Suit)j;
                    Cards.Add(card);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                List<Card> templist = new List<Card>();
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomindex = random.Next(0, Cards.Count);
                    templist.Add(Cards[randomindex]);
                    Cards.RemoveAt(randomindex);
                }
                Cards = templist;
            }
        }
        public List<Card> Cards { get; set; }

        public void ListCards()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.ReadLine();
        }
    }
}
