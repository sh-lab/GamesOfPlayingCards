using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Sh_Lab.PlayingCards;
using Net.Sh_Lab.PlayingCards.Klondike;

namespace KlondikeTest
{
    [TestClass]
    public class KlondikeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dictionary = new Dictionary<Card, IPosition>();

            dictionary.Add(Card.KingOfDiamonds, new Stock(0));
            dictionary.Add(Card.AceOfClubs, new Stock(1));

            var klondike = new Klondike(dictionary);

            Assert.IsTrue(klondike.CanDraw(Card.AceOfClubs));
            Assert.IsFalse(klondike.CanDraw(Card.KingOfDiamonds));

            klondike.Draw(Card.AceOfClubs);
            klondike.Draw(Card.KingOfDiamonds);


            klondike.MoveTableau(Card.KingOfDiamonds, Column.First);
            klondike.MoveFundation(Card.AceOfClubs);

        }
    }
}
