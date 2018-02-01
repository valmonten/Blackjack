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

        // Draw card method
        public ICard DrawCard()
        {
            if (cards.Count == 0) //Check if Deck is not empty 
            {
                this.Build();
            }
            Card cardDrawn = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return cardDrawn;
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

        /// <summary>
        /// Shuffles the cards the specified number of times.
        /// </summary>
        /// <param name="numTimes">Number of times deck is to be shuffled.</param>
        public void Shuffle(int numTimes)
        {
            throw new NotImplementedException();
        }

    }
}
