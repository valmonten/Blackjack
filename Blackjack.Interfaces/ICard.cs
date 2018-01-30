using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
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

    public interface ICard
    {
        Suit Suit { get; set; }
        Face Face { get; set; }
        int Value { get; set; }

        /// <summary>
        /// Function to create a card.
        /// </summary>
        void CreateCard(Suit suit, Face face, int value);
    }
}
