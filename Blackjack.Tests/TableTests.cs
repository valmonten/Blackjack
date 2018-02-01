using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Blackjack.Interfaces;
using Blackjack;
using System.Linq;

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
            var gambler = new Gambler("Bob");
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
            var dealer = new Dealer("Bob");
            //act
            var table1 = new Table(dealer, null);
        }
        //[TestMethod]
        //public void TestTableconstructorValid()
        //{
        //    //arrange
        //    var dealer = new Dealer("Bob");
        //    List<Gambler> players = new List<Gambler> { new Gambler() };
        //    //act
        //    var table = new Table(dealer, players);
        //    //assert
        //    Assert.AreEqual(dealer.Name, table.Dealer.Name);
        //    Assert.AreEqual(players.First().Name, table.Players.First().Name);
        //}
    }
}
