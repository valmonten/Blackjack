using System;
using Blackjack.Interfaces;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Blackjack.Tests
{

    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void TestHandConstructor()
        {
            Hand hand = new Hand();
            Assert.AreEqual(0, hand.Count);
        }

        [TestMethod]
        public void TestCount()
        {
            // arrange
            Hand hand = new Hand();
            var card = new Mock<ICard>(MockBehavior.Strict);

            // act
            hand.AllCards.Add(card.Object);

            // assert
            Assert.AreEqual(1, hand.Count);
        }

        public class MockCard : ICard
        {
            public CardSuit Suit { get; set; }
            public CardFace Face { get; set; }
            public int Value { get; set; }
        }

        [TestMethod]
        public void TestSumCardsValue()
        {
            // arrange
            Hand hand = new Hand();

            //var cardAce = new Mock<ICard>(MockBehavior.Strict);
            //cardAce.Setup(c => c.Face).Returns(CardFace.Ace);
            //cardAce.Setup(c => c.Value).Returns(1);

            //var card8 = new Mock<ICard>(MockBehavior.Strict);
            //card8.Setup(c => c.Face).Returns(CardFace.Eight);
            //card8.Setup(c => c.Value).Returns(8);

            //var cardKing = new Mock<ICard>(MockBehavior.Strict);
            //cardKing.Setup(c => c.Face).Returns(CardFace.King);
            //cardKing.Setup(c => c.Value).Returns(13);

            var cardAce = new MockCard();
            cardAce.Face = CardFace.Ace;
            cardAce.Value = (int)CardFace.Ace + 1;
            Assert.AreEqual(1, cardAce.Value);

            var card8 = new MockCard();
            card8.Face = CardFace.Eight;
            card8.Value = (int)CardFace.Eight + 1;
            Assert.AreEqual(8, card8.Value);


            var cardKing = new MockCard();
            cardKing.Face = CardFace.King;
            cardKing.Value = (int)CardFace.King + 1;
            Assert.AreEqual(13, cardKing.Value);

            int whenAceIs1Sum = 1 + 8 + 13;
            int whenAceIs11Sum = 11 + 8;

            // act
            //cardAce.Object.Value = (int)CardFace.Ace;

            //card8.Object.Face = CardFace.Eight;
            //card8.Object.Value = (int)CardFace.Eight;

            //cardKing.Object.Face = CardFace.King;
            //cardKing.Object.Value = (int)CardFace.King;

            //hand.AllCards.Add(cardAce.Object);
            //hand.AllCards.Add(card8.Object);
            hand.AllCards.Add(cardAce);
            hand.AllCards.Add(card8);
            int sum11 = hand.SumCardsValue();
            int AceValue11 = hand.AllCards
                .FirstOrDefault(c => c.Face == CardFace.Ace)
                .Value;

            hand.AllCards.Add(cardKing);

            int sum1 = hand.SumCardsValue();
            int AceValue1 = hand.AllCards
                .FirstOrDefault(c => c.Face == CardFace.Ace)
                .Value;

            // assert
            Assert.AreEqual(whenAceIs11Sum, sum11);
            Assert.AreEqual(11, AceValue11);
            Assert.AreEqual(whenAceIs1Sum, sum1);
            Assert.AreEqual(1, AceValue1);

        }
    }
}
