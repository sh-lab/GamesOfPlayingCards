using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Sh_Lab.PlayingCards;

namespace PlayingCardsTest
{
    [TestClass]
    public class RankExtensionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var queen = Rank.Queen;

            Assert.AreEqual(Rank.King, queen.Up());

            var king = Rank.King;

            Assert.IsFalse(king.Up().HasValue);

            Assert.AreEqual(Rank.Ace, king.Up(true));
        }
    }
}
