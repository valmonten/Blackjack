using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void TestDeckConstructor()
        {
            // arrange
            var list = new List<Card>();
            var expectedLength = 0;

            // act
            var newDeck = new Deck();
            var actualLength = newDeck.RemainingCardsInDeck();

            // assert
            Assert.AreEqual(expectedLength, actualLength);
        }
        [TestMethod]
        public void TestDeckBuild()
        {
            // arrange
            Deck newDeck = new Deck();
            int expected1 = 52;

            // act
            newDeck.Build();
            var actual1 = newDeck.RemainingCardsInDeck();

            // assert
            Assert.AreEqual(expected1, actual1);
        }


        //[TestMethod]
        //public void TestShuffle()
        //{
        // arrange


        // act


        // assert
        //}

        //[TestMethod]
        //public void TestReset()
        //{
        //}

        [TestMethod]
        public void TestDrawCard1()
        {
            // arrange
            Deck newDeck = new Deck();
            int expected = 50;

            // act
            newDeck.Build();
            newDeck.DrawCard();
            newDeck.DrawCard();
            var actual = newDeck.RemainingCardsInDeck();

            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestDrawCardNotNull()
        {
            // arrange
            Deck newDeck = new Deck();

            // act
            newDeck.Build();
            var actual = newDeck.DrawCard();

            // assert
            Assert.IsNotNull(actual);
        }
    }
}
