using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Sh_Lab.PlayingCards;

namespace PlayingCardsTest
{
    [TestClass]
    public class CardExtensionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var card = Card.AceOfSpades;

            Assert.AreEqual(Card.TwoOfSpades, card.Up());
            Assert.IsFalse(card.Down().HasValue);
            Assert.AreEqual(Card.KingOfSpades, card.Down(true));
        }
    }
}
