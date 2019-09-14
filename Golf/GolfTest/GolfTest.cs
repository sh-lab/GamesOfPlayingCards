using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Sh_Lab.PlayingCards.Golf;
using System.Linq;
using Net.Sh_Lab.PlayingCards;
using System.Collections.Generic;

namespace GolfTest
{
    [TestClass]
    public class GolfTest
    {
        /// <summary>
        /// ループ不可なルールで一通りのメソッド確認。
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {

            var dictionary = new Dictionary<Card, IPosition>
            {
                { Card.KingOfClubs, new Hand(0) },
                { Card.QueenOfClubs, new Field(Lane.First, 0) },
                { Card.QueenOfDiamonds, new Field(Lane.First, 1) },
                { Card.Joker, new Field(Lane.Second, 0) },
                { Card.JackOfDiamonds, new Field(Lane.Second, 1) },
                { Card.AceOfSpades, new Field(Lane.Third, 0) },
                { Card.TwoOfClubs, new Deck(1) },
                { Card.ExtraJoker, new Deck(0) }
            };


            var golf = new Golf(dictionary, false);

            Assert.IsFalse(golf.CanLoop);

            Assert.AreEqual(2, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfClubs));
            Assert.IsTrue(golf.CanMoveToHand(Card.QueenOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.Joker));
            Assert.IsFalse(golf.CanMoveToHand(Card.JackOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsTrue(golf.CanMoveToHand(Card.TwoOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.ExtraJoker));


            golf.MoveToHand(Card.QueenOfDiamonds);

            Assert.IsTrue(golf[Card.QueenOfDiamonds] is Hand);
            Assert.AreEqual(2, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.Joker));
            Assert.IsTrue(golf.CanMoveToHand(Card.JackOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsTrue(golf.CanMoveToHand(Card.TwoOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.ExtraJoker));


            golf.MoveToHand(Card.JackOfDiamonds);

            Assert.IsTrue(golf[Card.JackOfDiamonds] is Hand);
            Assert.AreEqual(2, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsTrue(golf.CanMoveToHand(Card.QueenOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfDiamonds));
            Assert.IsTrue(golf.CanMoveToHand(Card.Joker));
            Assert.IsFalse(golf.CanMoveToHand(Card.JackOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsTrue(golf.CanMoveToHand(Card.TwoOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.ExtraJoker));


            golf.MoveToHand(Card.QueenOfClubs);

            Assert.IsTrue(golf[Card.QueenOfClubs] is Hand);
            Assert.AreEqual(2, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfDiamonds));
            Assert.IsTrue(golf.CanMoveToHand(Card.Joker));
            Assert.IsFalse(golf.CanMoveToHand(Card.JackOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsTrue(golf.CanMoveToHand(Card.TwoOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.ExtraJoker));


            golf.MoveToHand(Card.TwoOfClubs);

            Assert.IsTrue(golf[Card.TwoOfClubs] is Hand);
            Assert.AreEqual(1, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfDiamonds));
            Assert.IsTrue(golf.CanMoveToHand(Card.Joker));
            Assert.IsFalse(golf.CanMoveToHand(Card.JackOfDiamonds));
            Assert.IsTrue(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsFalse(golf.CanMoveToHand(Card.TwoOfClubs));
            Assert.IsTrue(golf.CanMoveToHand(Card.ExtraJoker));


            golf.MoveToHand(Card.AceOfSpades);

            Assert.IsTrue(golf[Card.AceOfSpades] is Hand);
            Assert.AreEqual(1, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfDiamonds));
            Assert.IsTrue(golf.CanMoveToHand(Card.Joker));
            Assert.IsFalse(golf.CanMoveToHand(Card.JackOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsFalse(golf.CanMoveToHand(Card.TwoOfClubs));
            Assert.IsTrue(golf.CanMoveToHand(Card.ExtraJoker));

            golf.MoveToHand(Card.Joker);

            Assert.IsTrue(golf[Card.Joker] is Hand);
            Assert.AreEqual(1, golf.DeckCount());
            Assert.IsTrue(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.QueenOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.Joker));
            Assert.IsFalse(golf.CanMoveToHand(Card.JackOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsFalse(golf.CanMoveToHand(Card.TwoOfClubs));
            Assert.IsTrue(golf.CanMoveToHand(Card.ExtraJoker));
        }

        /// <summary>
        /// ループ可なルールでA⇔Kの動きを確認。
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            var dictionary = new Dictionary<Card, IPosition>
            {
                { Card.KingOfClubs, new Hand(0) },
                { Card.AceOfSpades, new Field(Lane.First, 0) },
                { Card.KingOfDiamonds, new Field(Lane.Second, 1) },
                { Card.FiveOfClubs, new Field(Lane.Second, 0) },
            };

            var golf = new Golf(dictionary, true);

            Assert.AreEqual(0, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsTrue(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.FiveOfClubs));


            golf.MoveToHand(Card.AceOfSpades);

            Assert.AreEqual(0, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsFalse(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsTrue(golf.CanMoveToHand(Card.KingOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.FiveOfClubs));


            golf.MoveToHand(Card.KingOfDiamonds);

            Assert.AreEqual(0, golf.DeckCount());
            Assert.IsFalse(golf.IsWin());
            Assert.IsTrue(golf.IsLose());

            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfClubs));
            Assert.IsFalse(golf.CanMoveToHand(Card.AceOfSpades));
            Assert.IsFalse(golf.CanMoveToHand(Card.KingOfDiamonds));
            Assert.IsFalse(golf.CanMoveToHand(Card.FiveOfClubs));

        }

    }
}
