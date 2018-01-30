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
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public int Value { get; set; }

        /// <summary>
        /// This method creates one card with a suit, face, value based on the arguments passed.
        /// </summary>
        /// <param name="suit">The suit of the card.</param>
        /// <param name="face">The face of the card.</param>
        /// <param name="value">The value of the card.</param>
        public void CreateCard(Suit suit, Face face, int value)
        {
            this.Suit = suit;
            this.Face = face;
            this.Value = value;
        }
    }
}
