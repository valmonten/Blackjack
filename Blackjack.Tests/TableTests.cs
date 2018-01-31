using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Blackjack.Interfaces;

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
            var gambler = new Gambler();
            List<IGambler> players = new List<IGambler>();
            //act
            var table1 = new Table(null, null);
            var table2 = new Table(null, players);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestTableConstructorNoPlayers()
        {
            //arrange
            var dealer = new Dealer();
            //act
            var table1 = new Table(dealer, null);
        }
    }
}
