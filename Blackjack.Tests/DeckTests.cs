using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack.Interfaces;

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
            var expected2 = CardFace.King;
            var expected3 = CardSuit.Club;
            var expected4 = 10;

            // act
            newDeck.Build();
            var actual1 = newDeck.RemainingCardsInDeck();
            var actual2 = newDeck.DrawCard().Face;
            var actual3 = newDeck.DrawCard().Suit;
            var actual4 = newDeck.DrawCard().Value;

            // assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);
        }

        [TestMethod]
        public void TestDeckShuffle()
        {
            // arrange
            Deck newDeck = new Deck();
            newDeck.Build();
            int expected1 = 52;
            //var expected2 = newDeck;

            // act
            newDeck.Shuffle(1);
            int actual1 = newDeck.RemainingCardsInDeck();
            //var actual2 = newDeck;


            // assert
            Assert.AreEqual(expected1, actual1);
            //CollectionAssert.AreNotEqual(expected2, actual2);
        }

        [TestMethod]
        public void TestDeckReset()
        {
            // arrange
            Deck newDeck = new Deck();
            newDeck.Build();
            int expected = 0;

            // act
            newDeck.Reset();
            int actual = newDeck.RemainingCardsInDeck();

            // assert
            Assert.AreEqual(expected, actual);
        }

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
