using System;
using Blackjack.Interfaces;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{

    [TestClass]
    public class GamblerTest
    {
        [TestMethod]
        public void TestGamblerConstructor()
        {
            Gambler gambler = new Gambler("test");
            Assert.AreEqual("test", gambler.Name);
            Assert.AreEqual(0, gambler.Hand.Count);
        }

        public class MockCard : ICard
        {
            public CardSuit Suit { get; set; }
            public CardFace Face { get; set; }
            public int Value { get; set; }
        }

        [TestMethod]
        public void TestGetCard()
        {
            // arrange
            var card1 = new Mock<ICard>(MockBehavior.Strict);
            var card = new MockCard();
            card.Value = 13;

            var dealer = new Mock<IDealer>(MockBehavior.Strict);
            dealer.Setup(x => x.Deal()).Returns(card);

            Gambler g = new Gambler("test");

            // act
            var gamblerGetCard = g.GetCard(dealer.Object);

            // assert
            Assert.AreEqual(1, g.Hand.Count);
            Assert.AreEqual(card.Value, gamblerGetCard.Value);   
        }

        [TestMethod]
        public void TestClearHand()
        {
            // arrange
            var card = new MockCard();
            Gambler g = new Gambler("test");

            var dealer = new Mock<IDealer>(MockBehavior.Strict);
            dealer.Setup(x => x.Deal()).Returns(card);

            // act
            g.GetCard(dealer.Object);
            g.GetCard(dealer.Object);
            g.GetCard(dealer.Object);

            int handCount = g.Hand.Count;

            // assert
            Assert.AreEqual(3, handCount);
        }
    }
}
