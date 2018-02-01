using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Blackjack.Interfaces;
using Blackjack;
using System.Linq;
using Moq;

namespace Blackjack.Tests
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestTableConstructorNullDealer()
        {
            //arrange
            var player = new Mock<IGambler>(MockBehavior.Strict);
            List<IGambler> players = new List<IGambler>() { player.Object };
            //act
            var table1 = new Table(null, null);
            var table2 = new Table(null, players);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestTableConstructorNoPlayers()
        {
            //arrange
            var dealer = new Mock<IDealer>(MockBehavior.Strict);
            //var dealer = new Dealer("Bob");
            //act
            var table1 = new Table(dealer.Object, null);
        }
        [TestMethod]
        public void TestTableconstructorValid()
        {
            //arrange
            var player = new Mock<IGambler>(MockBehavior.Strict);
            player.Setup(x => x.Name).Returns("Joe");
            List<IGambler> players = new List<IGambler>() { player.Object };
            var dealer = new Mock<IDealer>(MockBehavior.Strict);
            dealer.Setup(x => x.Name).Returns("Schmoe");
            //act
            var table = new Table(dealer.Object, players);
            //assert
            Assert.AreEqual(dealer.Object.Name, table.Dealer.Name);
            Assert.AreEqual(players.First().Name, table.Players.First().Name);
        }
    }
}
