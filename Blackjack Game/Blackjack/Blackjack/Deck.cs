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

            // creates a list of suits
            List<string> Suits = new List<string>() 
            { 
                "Clubs", 
                "Diamonds", 
                "Hearts",
                "Spades",
            };
            
            // creats a list of faces
            List<string> Face = new List<string>()
            {
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Jack",
                "Queen",
                "King",
                "Ace",
            };

            // creates all 52 cards
            foreach (string suit in Suits)
            {
                foreach (string face in Face)
                {
                    Card card = new Card();
                    card.Suit = suit;
                    card.Face = face;
                    Cards.Add(card);
                }
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
        public Deck Shuffle(int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (deck.Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, deck.Cards.Count);
                    TempList.Add(deck.Cards[randomIndex]);
                    deck.Cards.RemoveAt(randomIndex);
                }
                deck.Cards = TempList;
            }
            return deck;
        }
    }
}
