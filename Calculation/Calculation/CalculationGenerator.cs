using System.Linq;
using System.Collections.Generic;

namespace Net.Sh_Lab.PlayingCards.Calculation
{
    /// <summary>
    /// Calculationの生成機
    /// </summary>
    public static class CalculationGenerator
    {
        /// <summary>
        /// 各台札にA,2,3,4を配置したCalculationを生成する。
        /// </summary>
        /// <returns>生成したCalculation</returns>
        public static Calculation Generate()
        {
            var dictionary = new Dictionary<Card, IPosition>();

            var cards = CardListGenerator.GenerateNoJokerShuffledCardList();

            var ace = cards.First(e => e.Rank == Rank.Ace);
            dictionary.Add(ace, new Foundation(FoundationColumn.First));
            cards.Remove(ace);

            var two = cards.First(e => e.Rank == Rank.Two);
            dictionary.Add(two, new Foundation(FoundationColumn.Second));
            cards.Remove(two);

            var three = cards.First(e => e.Rank == Rank.Three);
            dictionary.Add(three, new Foundation(FoundationColumn.Third));
            cards.Remove(three);

            var four = cards.First(e => e.Rank == Rank.Four);
            dictionary.Add(four, new Foundation(FoundationColumn.Fourth));
            cards.Remove(four);

            var drawCard = cards[0];
            dictionary.Add(drawCard, new WastePile());
            cards.Remove(drawCard);

            for (int i = 0; i < cards.Count; i++)
            {
                dictionary.Add(cards[i], new Stock(i));
            }


            return new Calculation(dictionary);
        }

        /// <summary>
        /// 全てのカードを山札に配置したCalculationを生成する。
        /// </summary>
        /// <returns>生成したCalculation</returns>
        public static Calculation GenerateAllStockGame()
        {
            return new Calculation(
                CardListGenerator.GenerateNoJokerShuffledCardList()
                .Select((card, index) => (card, index))
                .ToDictionary(pair => pair.card,
                pair => (IPosition)new Stock(pair.index)));
        }
    }
}
