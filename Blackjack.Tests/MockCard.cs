using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Interfaces;

namespace Blackjack.Tests
{
    public class MockCard : ICard
    {
        public CardSuit Suit { get; set; }
        public CardFace Face { get; set; }
        public int Value { get; set; }
    }
}
