using System;
using Blackjack.Interfaces;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            var mockDeck = new Mock<IDeck>(MockBehavior.Strict);
            mockDeck.Setup(x => x.DrawCard()).Returns(new Card(CardSuit.Heart , CardFace.King, 10));

            Dealer dealer = new Dealer(mockDeck.Object, "test");

            // act
            ICard card = dealer.Deal();

            // assert
            Assert.AreEqual(card.Suit, CardSuit.Heart);
        }

        [TestMethod]
        public void TestClearHand()
        {
            // arrange
            var mockHand = new Mock<IHand>(MockBehavior.Strict);
            var mockCard = new Mock<ICard>(MockBehavior.Strict);
            List<ICard> cards = new List<ICard> { mockCard.Object };

            mockHand.Setup(x => x.AllCards).Returns(cards);
            
            Dealer dealer = new Dealer(mockHand.Object);
            
            //Assert hand has the mock card
            Assert.AreEqual(1, dealer.Hand.AllCards.Count);

            //Act
            dealer.ClearHand();

            // Assert hand cleared the mock card
            Assert.AreEqual(0, dealer.Hand.AllCards.Count);
        }
    }
}
