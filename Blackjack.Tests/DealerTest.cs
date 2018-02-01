using System;
using Blackjack.Interfaces;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{

    [TestClass]
    public class DealerTest
    {
        [TestMethod]
        public void TestDealerConstructor()
        {
            // act
            Dealer dealer = new Dealer("test");
            dealer.Deck.Build();

            // assert
            Assert.AreEqual("test", dealer.Name);
            Assert.AreEqual(0, dealer.Hand.Count);
            Assert.AreEqual(52, dealer.Deck.RemainingCardsInDeck());
        }

        //public class MockCard : ICard
        //{
        //    public CardSuit Suit { get; set; }
        //    public CardFace Face { get; set; }
        //    public int Value { get; set; }
        //}

        [TestMethod]
        public void TestDeal()
        {
            // arrange
            Dealer dealer = new Dealer("test");
            dealer.Deck.Build();

            int expectedRemaining = 52 - 4;
            int expectedHandCount = 4;

            // act
            ICard card = dealer.GetCard(dealer);
            ICard card1 = dealer.GetCard(dealer);
            ICard card2 = dealer.GetCard(dealer);
            ICard card3 = dealer.GetCard(dealer);
            int actualRemaining = dealer.Deck.RemainingCardsInDeck();
            int actualHandCount = dealer.Hand.Count;

            // assert
            Assert.AreEqual(expectedRemaining, actualRemaining);
            Assert.AreEqual(expectedHandCount, actualHandCount);
        }

        [TestMethod]
        public void TestClearHand()
        {
            // arrange
            Dealer dealer = new Dealer("test");
            dealer.Deck.Build();

            // act
            dealer.GetCard(dealer);
            dealer.GetCard(dealer);
            dealer.GetCard(dealer);
            dealer.GetCard(dealer);

            dealer.ClearHand();

            // assert
            Assert.AreEqual(0, dealer.Hand.Count);
        }
    }
}
