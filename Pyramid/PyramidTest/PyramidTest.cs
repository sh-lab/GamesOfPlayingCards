using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Sh_Lab.PlayingCards;
using Net.Sh_Lab.PlayingCards.Pyramid;

namespace PyramidTest
{
    [TestClass]
    public class PyramidTest
    {
        /// <summary>
        /// 一段目  K
        /// 二段目 Q A
        /// QとA ⇒ Kの順に除去。
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var dictionary = new Dictionary<Card, IPosition>
            {
                { Card.KingOfSpades, new Field(1, 1) },
                { Card.AceOfClubs, new Field(2, 1) },
                { Card.QueenOfClubs, new Field(2, 2) }
            };

            var pyramid = new Pyramid(dictionary);

            Assert.IsTrue(pyramid.CanRemove(Card.AceOfClubs, Card.QueenOfClubs));
            Assert.IsTrue(pyramid.CanRemove(Card.QueenOfClubs, Card.AceOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.AceOfClubs, Card.KingOfSpades));
            Assert.IsFalse(pyramid.CanRemove(Card.KingOfSpades, Card.QueenOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.KingOfSpades));
            Assert.IsFalse(pyramid.CanRemove(Card.QueenOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.AceOfClubs));


            // AとQを除去
            pyramid.Remove(Card.AceOfClubs, Card.QueenOfClubs);

            Assert.IsTrue(pyramid[Card.AceOfClubs] is Outside);
            Assert.IsTrue(pyramid[Card.QueenOfClubs] is Outside);

            Assert.IsFalse(pyramid.CanRemove(Card.AceOfClubs, Card.QueenOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.QueenOfClubs, Card.AceOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.AceOfClubs, Card.KingOfSpades));
            Assert.IsFalse(pyramid.CanRemove(Card.KingOfSpades, Card.QueenOfClubs));
            Assert.IsTrue(pyramid.CanRemove(Card.KingOfSpades));
            Assert.IsFalse(pyramid.CanRemove(Card.QueenOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.AceOfClubs));


            /// Kを除去
            pyramid.Remove(Card.KingOfSpades);

            Assert.IsTrue(pyramid[Card.KingOfSpades] is Outside);

            Assert.IsFalse(pyramid.CanRemove(Card.AceOfClubs, Card.QueenOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.QueenOfClubs, Card.AceOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.AceOfClubs, Card.KingOfSpades));
            Assert.IsFalse(pyramid.CanRemove(Card.KingOfSpades, Card.QueenOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.KingOfSpades));
            Assert.IsFalse(pyramid.CanRemove(Card.QueenOfClubs));
            Assert.IsFalse(pyramid.CanRemove(Card.AceOfClubs));
        }

        /// <summary>
        /// 一段目  A
        /// 二段目 A 
        /// 山札 J Q Q
        /// 山札をすべて引いてリディール
        /// QとA ⇒ 山札からJを引く ⇒ 山札からQを引く ⇒ QとAの順に除去。
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            var dictionary = new Dictionary<Card, IPosition>
            {
                { Card.AceOfSpades, new Field(1, 1) },
                { Card.AceOfClubs, new Field(2, 1) },
                { Card.AceOfDiamonds, new Field(2, 2) },
                { Card.JackOfClubs, new Deck(2)},
                { Card.QueenOfSpades, new Deck(1)},
                { Card.QueenOfHearts, new Deck(0)},
            };

            var pyramid = new Pyramid(dictionary);

            pyramid.Draw(Card.JackOfClubs);
            pyramid.Draw(Card.QueenOfSpades);
            pyramid.Draw(Card.QueenOfHearts);

            Assert.IsTrue(pyramid.CanRedeal());

            pyramid.Redeal();
        }
    }
}
