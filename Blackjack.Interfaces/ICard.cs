using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Interfaces
{
    public enum CardSuit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }

    public enum CardFace
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
        CardSuit Suit { get; set; }
        CardFace Face { get; set; }
        int Value { get; set; }
    }
}
