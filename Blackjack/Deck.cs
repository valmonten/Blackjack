using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;


namespace Blackjack
{
    public class Deck : IDeck
    {
        private List<Card> cards;

        public void Build()
        {
            throw new NotImplementedException();
        }

        // Build Method(s)

        // Shuffle Method

        // Reset Method

        // Draw card method
        public ICard DrawCard()
        {
            Card cardToReturn = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return cardToReturn;
        }

        // Remaining cards method
        public int RemainingCardsInDeck()
        {
            return cards.Count;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        void IDeck.RemainingCardsInDeck()
        {
            throw new NotImplementedException();
        }
    }
}
