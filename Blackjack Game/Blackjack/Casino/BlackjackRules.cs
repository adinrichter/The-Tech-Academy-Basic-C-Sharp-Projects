using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Blackjack
{
    public class BlackjackRules
    {
        private static Dictionary<Face, int> _cardValues = new Dictionary<Face, int>()
        {
            [Face.Two] = 2,
            [Face.Three] = 3,
            [Face.Four] = 4,
            [Face.Five] = 5,
            [Face.Six] = 6,
            [Face.Seven] = 7,
            [Face.Eight] = 8,
            [Face.Nine] = 9,
            [Face.Ten] = 10,
            [Face.Jack] = 10,
            [Face.Queen] = 10,
            [Face.King] = 10,
            [Face.Ace] = 1
        };

        public static int[] getHandValues(List<Card> Hand)
        {
            int aceCount = Hand.Count(x => x.Face == Face.Ace);
            int[] result = new int[aceCount + 1];
            int value = Hand.Sum(x => _cardValues[x.Face]);
            result[0] = value;
            if (result.Length == 1)
            {
                return result;
            }
            for (int i = 1; i < result.Length; i++)
            {
                value += (i * 10);
                result[i] = value;
            }
            return result;
        }

        public static bool isBlackjack(List<Card> Hand)
        {
            int[] possibleValues = getHandValues(Hand);
            int value = possibleValues.Max();
            if (value == 21) return true;
            else return false;
        }

        public static bool isBusted(List<Card> Hand)
        {
            int value = getHandValues(Hand).Min();
            if (value > 21) return true;
            else return false;
        }

        public static bool dealerStay(List<Card> Hand)
        {
            int[] handValues = getHandValues(Hand);
            foreach (int value in handValues)
            {
                if (value >= 17 && value <= 21) return true;
            }
            return false;
        }

        public static bool? compareHands(List<Card> PlayerHand, List<Card> DealerHand)
        {
            int[] playerValues = getHandValues(PlayerHand);
            int[] dealerValues = getHandValues(DealerHand);
            int playerValue = playerValues.Where(x => x <= 21).Max();
            int dealerValue = dealerValues.Where(x => x <= 21).Max();
            if (playerValue > dealerValue) return true;
            else if (playerValue < dealerValue) return false;
            else return null;
        }
    }
}