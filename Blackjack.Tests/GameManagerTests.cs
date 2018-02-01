using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Blackjack.Interfaces;
using Blackjack;

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


            // Act
            GameManager gameManager = new GameManager(dealer, inputProvider, 
                outputProvider, tableRenderer);


            // Assert
            Assert.AreEqual(dealer, gameManager.Dealer);
            Assert.AreEqual(inputProvider, gameManager.InputProvider);
            Assert.AreEqual(outputProvider, gameManager.OutputProvider);
            Assert.AreEqual(tableRenderer, gameManager.TableRenderer);
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
        }
    }
}
