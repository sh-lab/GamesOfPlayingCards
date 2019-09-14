using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Sh_Lab.PlayingCards;
using System.Linq;

namespace PlayingCardsTest
{
    [TestClass]
    public class CardListGeneratorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = CardListGenerator.GenerateDoubleJokerCardList();

            // 54枚のカードのリストか？
            Assert.AreEqual(54, result.Count);

            // 各カードは一枚づつか？
            foreach (CardId id in Enum.GetValues(typeof(CardId)))
            {
                Assert.AreEqual(1, result.Count(e => e.Id == id));
            }

            // 各カードのSuitのNumberの検証
            Assert.AreEqual(2, result.Count(e => e.Suit == Suit.None));
            Assert.AreEqual(13, result.Count(e => e.Suit == Suit.Spades));
            Assert.AreEqual(13, result.Count(e => e.Suit == Suit.Hearts));
            Assert.AreEqual(13, result.Count(e => e.Suit == Suit.Diamonds));
            Assert.AreEqual(13, result.Count(e => e.Suit == Suit.Clubs));

            Assert.AreEqual(2, result.Count(e => e.Rank == Rank.None));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Ace));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Two));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Three));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Four));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Five));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Six));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Seven));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Eight));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Nine));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Ten));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Jack));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.Queen));
            Assert.AreEqual(4, result.Count(e => e.Rank == Rank.King));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = CardListGenerator.GenerateSingleJokerCardList();

            // ExtraJokerを除く53枚のカードか
            Assert.AreEqual(53, result.Count);
            Assert.IsFalse(result.Contains(Card.ExtraJoker));

        }

        [TestMethod]
        public void TestMethod3()
        {
            var result = CardListGenerator.GenerateNoJokerCardList();

            // Joker,ExtraJokerを除く52枚のカードか
            Assert.AreEqual(52, result.Count);
            Assert.IsFalse(result.Contains(Card.Joker));
            Assert.IsFalse(result.Contains(Card.ExtraJoker));

        }
    }
}
