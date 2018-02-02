using System;
using System.Linq;
using Blackjack.Interfaces;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

            Gambler gambler = new Gambler("test");

            // act
            var gamblerGetCard = gambler.GetCard(dealer.Object);

            // assert
            Assert.AreEqual(1, gambler.Hand.Count);
            Assert.AreEqual(card.Value, gamblerGetCard.Value);   
        }

        [TestMethod]
        public void TestClearHand()
        {
            // arrange
            var card = new MockCard();
            Gambler gambler = new Gambler("test");

            var dealer = new Mock<IDealer>(MockBehavior.Strict);
            dealer.Setup(x => x.Deal()).Returns(card);

            // act
            // passing the MockDealer in gambler.GetCard(IDealer dealer)
            gambler.GetCard(dealer.Object);
            gambler.GetCard(dealer.Object);
            gambler.GetCard(dealer.Object);

            int handCount = gambler.Hand.Count;

            // assert
            Assert.AreEqual(3, handCount);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSplitMeWhenHandWasAlreadySplit()
        {
            //Arrange
            
            var g = new Gambler(true, new Hand(), "Nathan");

            //Act
            g.SplitMe();
            
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSplitMeWhenFacesDoNotMatch()
        {
            //Arrange
            var handy = new Mock<IHand>(MockBehavior.Strict);
            var c1 = new Mock<ICard>(MockBehavior.Strict);
            c1.Setup(x => x.Face).Returns(CardFace.King);
            handy.Setup(x => x.AllCards[0]).Returns(c1.Object);
            handy.Setup(x => x.AllCards[1].Face).Returns(CardFace.Queen);

            var face = handy.Object.AllCards[0].Face;
            var face2 = handy.Object.AllCards[1].Face;
            var g = new Gambler(false, handy.Object, "Nathan");

            //Act
            g.SplitMe();

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSplitMeWhenMoreThanTwoCards()
        {
            //Arrange
            var handy = new Mock<IHand>(MockBehavior.Strict);
            handy.Setup(x => x.Count).Returns(3);

            var g = new Gambler(false, handy.Object, "Nathan");

            //Act
            g.SplitMe();

        }
        [TestMethod]
        public void TestSplitMeWithValidInput()
        {
            //Arrange
            var handy = new Mock<IHand>(MockBehavior.Strict);
            var handy2 = new Mock<IHand>(MockBehavior.Strict);
            var c1 = new Mock<ICard>(MockBehavior.Strict);
            var c2 = new Mock<ICard>(MockBehavior.Strict);
            c1.Setup(x => x.Face).Returns(CardFace.King);
            c2.Setup(x => x.Face).Returns(CardFace.King);

            handy.Setup(x => x.AllCards).Returns(new List<ICard>() {c1.Object, c2.Object });
            handy2.Setup(x => x.AllCards).Returns(new List<ICard>() {c1.Object});
            

            handy.Setup(x => x.Count).Returns(2);

            var g = new Gambler(false, handy.Object, "Nathan");
            

            //Act
            g.SplitMe();

            //Assert
            Assert.AreEqual(true, g.isHandSplit);
            CollectionAssert.AreEqual(handy2.Object.AllCards.ToList(), handy.Object.AllCards.ToList());
            Assert.AreEqual(1, g.SplitHand.Count);
        }
    }
}
