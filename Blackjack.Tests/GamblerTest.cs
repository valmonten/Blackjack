using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{
    [TestClass]
    public class GamblerTest
    {
        [TestMethod]
        public void TestGamblerConstructor()
        {
            Gambler gambler = new Gambler("test");
            Assert.AreEqual("test", gambler.Name);
            Assert.AreEqual(0, gambler.Hand.Count);
        }
    }
}
