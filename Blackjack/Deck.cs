using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        private List<Card> cards;

        // Build Method(s)

        // Shuffle Method

        // Reset Method

        // Draw card method

        public Card DrawACard()
        {
            Card cardToReturn = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return cardToReturn;
        }

        // Remaining cards method

    }
}
