using Net.Sh_Lab.PlayingCards;
using Net.Sh_Lab.PlayingCards.Calculation;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CalculationTest
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            var target = CalculationGenerator.Generate();

            Assert.AreEqual(52, target.Count);
            Assert.AreEqual(Rank.Two, target.NextRank(FoundationColumn.First));
            Assert.AreEqual(Rank.Four, target.NextRank(FoundationColumn.Second));
            Assert.AreEqual(Rank.Six, target.NextRank(FoundationColumn.Third));
            Assert.AreEqual(Rank.Eight, target.NextRank(FoundationColumn.Fourth));
        }

        [Test()]
        public void TestCase2()
        {
            var dictionary = new Dictionary<Card, IPosition>();

            dictionary.Add(Card.AceOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.TwoOfClubs, new Foundation(FoundationColumn.Second));
            dictionary.Add(Card.ThreeOfClubs, new Foundation(FoundationColumn.Third));
            dictionary.Add(Card.FourOfClubs, new Foundation(FoundationColumn.Fourth));

            dictionary.Add(Card.TwoOfHearts, new WastePile());

            var target = new Calculation(dictionary);

            Assert.IsTrue(target.CanMoveFoundation(Card.TwoOfHearts, FoundationColumn.First));

            target.MoveFoundation(Card.TwoOfHearts, FoundationColumn.First);

            Assert.AreEqual(FoundationColumn.First, ((Foundation)target[Card.TwoOfHearts]).Column);
        }

        [Test()]
        public void TestCase3()
        {
            var dictionary = new Dictionary<Card, IPosition>();

            dictionary.Add(Card.AceOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.TwoOfClubs, new Foundation(FoundationColumn.Second));
            dictionary.Add(Card.ThreeOfClubs, new Foundation(FoundationColumn.Third));
            dictionary.Add(Card.FourOfClubs, new Foundation(FoundationColumn.Fourth));

            dictionary.Add(Card.ThreeOfDiamonds, new Tableau(TableaColumn.First, 0));
            dictionary.Add(Card.TwoOfHearts, new Tableau(TableaColumn.First, 1));

            var target = new Calculation(dictionary);

            Assert.IsTrue(target.CanMoveFoundation(Card.TwoOfHearts, FoundationColumn.First));

            target.MoveFoundation(Card.TwoOfHearts, FoundationColumn.First);

            Assert.AreEqual(FoundationColumn.First, ((Foundation)target[Card.TwoOfHearts]).Column);
        }

        [Test()]
        public void TestCase4()
        {
            var dictionary = new Dictionary<Card, IPosition>();

            dictionary.Add(Card.AceOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.TwoOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.ThreeOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.FourOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.FiveOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.SixOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.SevenOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.EightOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.NineOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.TenOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.JackOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.QueenOfClubs, new Foundation(FoundationColumn.First));
            dictionary.Add(Card.KingOfClubs, new Foundation(FoundationColumn.First));

            var target = new Calculation(dictionary);

            Assert.IsFalse(target.NextRank(FoundationColumn.First).HasValue);
        }
    }
}
