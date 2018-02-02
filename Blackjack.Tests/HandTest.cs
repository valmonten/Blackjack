using System;
using Blackjack.Interfaces;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Blackjack.Tests
{

    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void TestHandConstructor()
        {
            Hand hand = new Hand();
            Assert.AreEqual(0, hand.Count);
        }

        [TestMethod]
        public void TestCount()
        {
            // arrange
            Hand hand = new Hand();
            var card = new Mock<ICard>(MockBehavior.Strict);

            // act
            hand.AllCards.Add(card.Object);

            // assert
            Assert.AreEqual(1, hand.Count);
        }

        public class MockCard : ICard
        {
            public CardSuit Suit { get; set; }
            public CardFace Face { get; set; }
            public int Value { get; set; }
        }

        [TestMethod]
        public void TestSumCardsValue()
        {
            // arrange
            Hand hand = new Hand();

            var cardAce = new MockCard();
            cardAce.Face = CardFace.Ace;
            cardAce.Value = 11;
            
            var card6 = new MockCard();
            card6.Face = CardFace.Six;
            card6.Value = 6;


            var card7 = new MockCard();
            card7.Face = CardFace.Seven;
            card7.Value = 7;

            var card8 = new MockCard();
            card8.Face = CardFace.Eight;
            card8.Value = 8;


            var cardKing = new MockCard();
            cardKing.Face = CardFace.King;
            cardKing.Value = 10;


            int expectedSumWhenAceIs_11 = 11 + cardKing.Value;
            int expectedSumWhenAceIs_1 = 1 + card6.Value + card7.Value + card8.Value + cardKing.Value;

            // act

            // Add Card King and Ace to the Hand, making the sum to be 21, so that Ace is determined to be 1
            hand.AllCards.Add(cardAce);
            hand.AllCards.Add(cardKing);
            int actualSumWhenAceIs_11 = hand.SumCardsValue();
            int AceValue11 = hand.AllCards
                .FirstOrDefault(c => c.Face == CardFace.Ace)
                .Value;

            // Add more cards to make the sum greater than 21, so that Ace value is 1
            hand.AllCards.Add(card6);
            hand.AllCards.Add(card7);
            hand.AllCards.Add(card8);
            int actualSumWhenAceIs_1 = hand.SumCardsValue();
            int AceValue1 = hand.AllCards
                .FirstOrDefault(c => c.Face == CardFace.Ace)
                .Value;

            //TODO:
            //int sum = hand.SumCardsValue();
            //int ace = hand.AllCards.FirstOrDefault(c => c.Face == CardFace.Ace).Value;
            //Assert.AreEqual(1, ace);
            //Assert.AreEqual(15, sum);

            // assert
            Assert.AreEqual(expectedSumWhenAceIs_11, actualSumWhenAceIs_11);
            Assert.AreEqual(11, AceValue11);
            Assert.AreEqual(expectedSumWhenAceIs_1, actualSumWhenAceIs_1);
            Assert.AreEqual(1, AceValue1);

        }
    }
}
