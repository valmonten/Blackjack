using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack
{ 
    public class Card : ICard
    {
        // Properties each card will have.
        public CardSuit Suit { get; set; }
        public CardFace Face { get; set; }
        public int Value { get; set; }

        /// <summary>
        /// This constructor creates one card with a suit, face, value based on the arguments passed.
        /// </summary>
        /// <param name="suit">The suit of the card.</param>
        /// <param name="face">The face of the card.</param>
        /// <param name="value">The value of the card based on its face.</param>
        public Card(CardSuit suit, CardFace face, int value)
        {
            this.Suit = suit;
            this.Face = face;
            this.Value = value;
        }

    }
}
