using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }

    public enum Face
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        // Fields a card will have.
        private Suit suit;
        private Face face;
        private int value;

        /// <summary>
        /// This method creates one card with a suit, face, value based on the arguments passed.
        /// </summary>
        /// <param name="suit">The suit of the card.</param>
        /// <param name="face">The face of the card.</param>
        /// <param name="value">The value of the card.</param>
        public void CreateCard(Suit suit, Face face, int value)
        {
            this.suit = suit;
            this.face = face;
            this.value = value;
        }
    }
}
