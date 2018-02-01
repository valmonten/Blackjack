using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Blackjack.Interfaces;
using System.Collections.Generic;

namespace Blackjack.Tests
{
    [TestClass]
    public class DealerTests
    {
        [TestMethod]
        public void TestClearHand()
        {
            //Arrange
            //Sets up the cards
            var c1 = new Mock<ICard>(MockBehavior.Strict);
            var c2 = new Mock<ICard>(MockBehavior.Strict);
            
            //Adds the card to the hand
            List<ICard> hand = new List<ICard>();
            hand.Add(c1.Object);
            hand.Add(c2.Object);
            // Passes hand into the dealer
            var d = new Dealer(hand);

            //Empty hand to compare
            List<ICard> expected = new List<ICard>();

            //Act
            d.ClearHand();
            

            //Assert
            Assert.AreEqual(d.Hand.Count, 0);
            
        }
        [TestMethod]
        public void TestGetCard()
        {
            // Arrange
            //Creates a mock card and the dealer we want to test
            var c1 = new Mock<ICard>(MockBehavior.Strict);
            var d = new Dealer("Nathan");
            var dealer = new Mock<IDealer>(MockBehavior.Strict);
            dealer.Setup(x => x.Deal()).Returns((ICard)c1);

            //Act
            d.GetCard((IDealer)dealer);

            //Assert
            Assert.AreEqual(d.Hand.Count, 1);


        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetCardException()
        {
            //Arrange
            var d = new Dealer("Nathan");

            //Act 
            d.GetCard(null);
        }

        
    }
}
