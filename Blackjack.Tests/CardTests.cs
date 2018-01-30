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
            Suit testSuit = Suit.Heart;
            Face testFace = Face.Ace;
            int testValue = 1;

            // Act
            Card actual = new Card(testSuit, testFace, testValue);

            // Assert
            Assert.AreEqual(Suit.Heart, actual.Suit);
            Assert.AreEqual(Face.Ace, actual.Face);
            Assert.AreEqual(1, actual.Value);
        }
    }
}
