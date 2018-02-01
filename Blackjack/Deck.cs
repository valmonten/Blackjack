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
        public List<Card> cards;

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

            // Array of default card values that correspond with Enum of CardFace
            int[] faceValues = new int[] { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            // Creates deck of cards, which will each have a suit, face, and value.
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
            cards.RemoveRange(0, cards.Count);
        }

        /// <summary>
        /// Shuffles the cards the specified number of times.
        /// </summary>
        /// <param name="numTimes">Number of times deck is to be shuffled.</param>
        public void Shuffle(int numTimes)
        {
            // Variables used to help split the deck in half.
            var totalNumCards = cards.Count;
            int halfNumCards = totalNumCards / 2;

            // Generate random number of cards to skip when riffle shuffling.
            Random randNumCardToSkip = new Random();

            // Creates two empty half-decks to be shuffled together.
            var deckLeft = new Queue<Card>();
            var deckRight = new Queue<Card>();

            // Shuffle the deck according to the number of times specified.
            while (numTimes > 0)
            {
                // Loops through current deck and adds all cards in the top half into deckLeft.
                for (var i = 0; i < halfNumCards; i++)
                {
                    deckLeft.Enqueue(cards[i]);
                }

                // Loops through current deck and adds all cards in the top half into deckRight.
                for (var i = totalNumCards - 1; i >= halfNumCards; i--)
                {
                    deckRight.Enqueue(cards[i]);
                }

                // Removes all cards from deck to prepare for new cards.
                cards.RemoveRange(0, cards.Count);

                // Generates random number of cards to skip per turn from both the left and right half-decks when shuffling.
                var leftDeckSkip = randNumCardToSkip.Next(1, 4);
                var rightDeckSkip = randNumCardToSkip.Next(1, 4);

                // if there are too few cards to dequeue in deckLeft
                if (leftDeckSkip > deckLeft.Count)
                {
                    while (deckLeft.Any())
                    {
                        var leftCard = deckLeft.Dequeue();
                        cards.Add(leftCard);
                    }
                }

                // if there are too few cards to dequeue in deckRight
                if (rightDeckSkip > deckLeft.Count)
                {
                    while (deckRight.Any())
                    {
                        var rightCard = deckRight.Dequeue();
                        cards.Add(rightCard);
                    }
                }

                while(cards.Count <= 52 && deckLeft.Any() && deckRight.Any())
                {
                    // Remove cards from leftCardDeck and adds it to the main Deck
                    if (deckLeft.Count != 0)
                    {
                        for (var i = 0; i <= leftDeckSkip; i++)
                        {
                            var leftCard = deckLeft.Dequeue();
                            cards.Add(leftCard);
                        }
                    }

                    // Remove cards from rightCardDeck and adds it to the main Deck
                    if (deckRight.Count != 0)
                    {
                        for (var i = 0; i <= rightDeckSkip; i++)
                        {
                            var rightCard = deckRight.Dequeue();
                            cards.Add(rightCard);
                        }
                    }
                }


                numTimes--;
            }
        }


        void IDeck.RemainingCardsInDeck()
        {
            throw new NotImplementedException();
        }

    }
}
