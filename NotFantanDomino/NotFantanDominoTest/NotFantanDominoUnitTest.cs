using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Sh_Lab.PlayingCards;
using Net.Sh_Lab.PlayingCards.NotFantanDomino;

namespace NotFantanDominoTest
{
    [TestClass]
    public class NotFantanDominoUnitTest
    {
        [TestMethod]
        public void TestMethodNotFantanDominoGenerator()
        {
            var target =  NotFantanDominoGenerator.Generate();

            Assert.AreEqual(13, target.Count(pair => pair.Value == Position.FirstPlayerHnad));
            Assert.AreEqual(13, target.Count(pair => pair.Value == Position.SecondPlayerHnad));
            Assert.AreEqual(13, target.Count(pair => pair.Value == Position.ThirdPlayerHnad));
            Assert.AreEqual(13, target.Count(pair => pair.Value == Position.FourthPlayerHnad));
        }

        [TestMethod]
        public void TestMethodNotFantanDomino1()
        {
            var dictionary = new Dictionary<Card, Position>();

            dictionary.Add(Card.SevenOfDiamonds, Position.SecondPlayerHnad);
            dictionary.Add(Card.EightOfDiamonds, Position.ThirdPlayerHnad);
            dictionary.Add(Card.NineOfDiamonds, Position.ThirdPlayerHnad);
            dictionary.Add(Card.TenOfDiamonds, Position.ThirdPlayerHnad);

            var notFantanDomino = new NotFantanDomino(dictionary);

            Assert.AreEqual(PlayerNumber.Second, notFantanDomino.TurnPlayer);
            notFantanDomino.Release(new List<Card>(){Card.SevenOfDiamonds});

            Assert.AreEqual(PlayerNumber.Third, notFantanDomino.TurnPlayer);

            Assert.IsFalse(notFantanDomino.CanRelease(new List<Card>() { Card.SevenOfDiamonds }));
            Assert.IsFalse(notFantanDomino.CanRelease(new List<Card>() { Card.EightOfDiamonds }));
            Assert.IsTrue(notFantanDomino.CanRelease(new List<Card>() { Card.NineOfDiamonds, Card.TenOfDiamonds }));

            notFantanDomino.Release(new List<Card>() { Card.NineOfDiamonds, Card.TenOfDiamonds });

        }
    }
}
