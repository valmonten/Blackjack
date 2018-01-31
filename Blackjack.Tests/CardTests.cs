using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Interfaces;

namespace Blackjack.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void TestCardConstructor()
        {
            // Arrange
            CardSuit testSuit = CardSuit.Heart;
            CardFace testFace = CardFace.Ace;
            int testValue = 1;

            // Act
            Card actual = new Card(testSuit, testFace, testValue);

            // Assert
            Assert.AreEqual(testSuit, actual.Suit);
            Assert.AreEqual(testFace, actual.Face);
            Assert.AreEqual(testValue, actual.Value);
        }
    }
}
