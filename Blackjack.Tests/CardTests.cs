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
            Suit testSuit = 0;
            Face testFace = 0;
            int testValue = 1;

            // Act
            Card actual = new Card(testSuit, testFace, testValue);

            // Assert
            Assert.AreEqual("Heart", actual.Suit);
            Assert.AreEqual("Ace", actual.Face);
            Assert.AreEqual(1, actual.Value);
        }
    }
}
