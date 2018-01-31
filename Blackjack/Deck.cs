using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{
    public class Deck
    {
        private List<Card> cards;

        /// <summary>
        /// Creates an empty deck that contains a list of cards.
        /// </summary>
        public Deck()
        {
            cards = new List<Card>();
        }

        /// <summary>
        /// Creates a deck of 52 cards.
        /// </summary>
        public void Build()
        {
            // List of card suits
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>().ToList();

            // Array of card faces
            var cardFaces = Enum.GetValues(typeof(CardFace)).Cast<CardFace>().ToList();

            // Array of values
            int[] faceValues = new int[] { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            // Create deck of cards
            for (var i = 0; i < suits.Count; i++)
            {
                for (var j = 0; j < cardFaces.Count; j++)
                {
                    cards.Add(new Card(suits[i], cardFaces[j], faceValues[j]));
                }
            }
        }

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
