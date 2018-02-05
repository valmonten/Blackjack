using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Blackjack.Interfaces;
using Blackjack;
using System.Collections.Generic;

namespace Blackjack.Tests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void TestOverloadedConstructor()
        {
            // Arrange
            var dealer = new Dealer("Test");
            var inputProvider = new ConsoleInputProvider();
            var outputProvider = new ConsoleOutputProvider();
            var tableRenderer = new ConsoleTableRenderer();
            var playersInOrder = new Queue<IPlayer>();
            var gamblers = new List<IGambler>();


            // Act
            GameManager gameManager = new GameManager(dealer, inputProvider, 
                outputProvider, tableRenderer, playersInOrder, gamblers);


            // Assert
            Assert.AreEqual(dealer, gameManager.Dealer);
            Assert.AreEqual(inputProvider, gameManager.InputProvider);
            Assert.AreEqual(outputProvider, gameManager.OutputProvider);
            Assert.AreEqual(tableRenderer, gameManager.TableRenderer);
            Assert.AreEqual(playersInOrder, gameManager.PlayersInOrder);
            Assert.AreEqual(gamblers, gameManager.Gamblers);
        }

        [TestMethod]
        public void TestDefaultConstructor()
        {
            // Arrange
            GameManager gameManager = new GameManager();

            // Assert
            Assert.IsNotNull(gameManager.Dealer);
            Assert.IsNotNull(gameManager.InputProvider);
            Assert.IsNotNull(gameManager.OutputProvider);
            Assert.IsNotNull(gameManager.TableRenderer);
            Assert.IsNotNull(gameManager.PlayersInOrder);
            Assert.IsNotNull(gameManager.Gamblers);
        }

    //    [TestMethod]
    //    public void TestDetermineWinner()
    //    {
    //        // Arrange
    //        GameManager gameManager = new GameManager();
    //        GameManager gameManager2 = new GameManager();

    //        var mockGambler1 = new Mock<IGambler>(MockBehavior.Strict);
    //        var mockDealer1 = new Mock<IDealer>(MockBehavior.Strict);
    //        gameManager.Gamblers.Add(mockGambler1.Object);
    //        gameManager.Table = new Table(gameManager.Dealer, gameManager.Gamblers);
    //        mockGambler1.Setup(x => x.Hand.SumCardsValue()).Returns(15);
    //        mockDealer1.Setup(x => x.Hand.SumCardsValue()).Returns(16);

    //        gameManager.PlayersInOrder.Enqueue(mockGambler1.Object);
    //        gameManager.PlayersInOrder.Enqueue(mockDealer1.Object);
    //        bool expected = true;

    //        gameManager2.PlayersInOrder.Enqueue(mockGambler1.Object);
    //        gameManager2.PlayersInOrder.Enqueue(mockDealer1.Object);
    //        gameManager2.Table = new Table(gameManager2.Dealer, gameManager2.Gamblers);
    //        bool expected2 = false;

    //        // Act
    //        gameManager.PlayersInOrder.Dequeue();
    //        gameManager.PlayersInOrder.Dequeue();
    //        bool actual = gameManager.DetermineWinner(mockGambler1.Object, mockDealer1.Object);
    //        bool actual2 = gameManager2.DetermineWinner(mockGambler1.Object, mockDealer1.Object);

    //        // Assert
    //        Assert.AreEqual(expected, actual);
    //        Assert.AreEqual(expected2, actual2);
    //    }
    }
}
