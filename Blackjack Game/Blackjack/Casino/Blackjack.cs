using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Blackjack
{
    public class BlackjackGame : Game
    {
        public BlackjackDealer Dealer { get; set; }
        
        public override void Play()
        {
            Dealer = new BlackjackDealer();
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>();
                player.Stay = false;
            }
            Dealer.Hand = new List<Card>();
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
 
            foreach (Player player in Players)
            {
                bool validAnswer = false;
                int bet = 0;
                while (!validAnswer)
                {
                    Console.WriteLine("Place your bet, you have: {0}:", Players[0].Pot);
                    validAnswer = int.TryParse(Console.ReadLine(), out bet);
                }
                if (bet < 0)
                {
                    throw new FraudException("Invalid entry. You have been removed from the game.");
                }
                bool successfullyBet = player.Bet(bet);
                if (!successfullyBet)
                {
                    return;

                }
                Bets[player] = bet;
            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...");
                foreach (Player player in Players)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand);
                    if (i == 1)
                    {
                        bool isBlackjack = BlackjackRules.isBlackjack(player.Hand); 
                        if (isBlackjack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}!", player.Name, (Bets[player] * 1.5));
                            player.Pot += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]);
                            Console.Write("Balance: {0}\n", player.Pot);
                            return;
                        }
                    }
                }
                Console.WriteLine("Dealer");
                Dealer.Deal(Dealer.Hand);
                if (i == 1)
                {
                    bool isBlackjack = BlackjackRules.isBlackjack(Dealer.Hand);
                    if (isBlackjack)
                    {
                        Console.WriteLine("Dealer has Blackjack, everyone loses!");
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        {
                            Dealer.Pot += entry.Value;
                        }
                        return;
                    }
                }
            }
            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.WriteLine("Your cards are: ");
                    foreach (Card card in player.Hand)
                    {
                        Console.Write("{0}\n", card.ToString());
                    }
                    
                    Console.Write("\n{0}'s Points:", player.Name);
                    for (int i = 0; i < BlackjackRules.getHandValues(player.Hand).Count(); i++)
                    {
                        Console.Write(BlackjackRules.getHandValues(player.Hand)[i] + " ");
                    }
                    Console.Write("\nDealer's Points:");
                    for (int i = 0; i < BlackjackRules.getHandValues(Dealer.Hand).Count(); i++)
                    {
                        Console.Write(BlackjackRules.getHandValues(Dealer.Hand)[i] + " ");
                    }

                    Console.WriteLine("\n\nWould you like to \n(Hit), or (Stay)?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                    }
                    else if (answer == "hit")
                    {
                        Dealer.Deal(player.Hand);
                    }

                    bool busted = BlackjackRules.isBusted(player.Hand);
                    if (busted)
                    {
                        Dealer.Pot += Bets[player];
                        Console.WriteLine("{0} busted! You lose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Pot);

                        Console.WriteLine("Do you want to play again? Type (y) for yes, anything else for no.");
                        answer = Console.ReadLine().ToLower();
                        if (answer == "y")
                        {
                            player.isPlaying = true;
                            return;
                        }
                        else
                        {
                            player.isPlaying = false;
                            return;
                        }
                    }
                }
            }
            Dealer.isBusted = BlackjackRules.isBusted(Dealer.Hand);
            Dealer.Stay = BlackjackRules.dealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("Dealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = BlackjackRules.isBusted(Dealer.Hand);
                Dealer.Stay = BlackjackRules.dealerStay(Dealer.Hand);
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staying...");
            }
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won {1}!", entry.Key.Name, entry.Value);
                    Players.Where(x => x.Name == entry.Key.Name).First().Pot += (entry.Value * 2);
                }
                return;
            }
            foreach (Player player in Players)
            {
                bool? playerWon = BlackjackRules.compareHands(player.Hand, Dealer.Hand);
                if (playerWon == null)
                {
                    Console.WriteLine("Push! No one wins!");
                    player.Pot += Bets[player];
                }
                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Pot += (Bets[player] * 2);
                    Dealer.Pot -= Bets[player];
                }
                else
                {
                    Console.WriteLine("Dealer wins {0}", Bets[player]);
                    Dealer.Pot += Bets[player];
                }
                Console.WriteLine("{0}'s balance: {1}, Dealer's balance: {2}", player.Name, player.Pot, Dealer.Pot);
                Console.WriteLine("Play again? type (y) for yes, anything else for no.");
                bool answer = Console.ReadLine().ToLower() == "y" ? true : false;
                if (answer)
                {
                    player.isPlaying = true;
                }
                else
                {
                    player.isPlaying = false;
                }
            }
        }
        public override void ListPlayers()
        {
            Console.WriteLine("Blackjack players: ");
            base.ListPlayers();
        }
    }
}
