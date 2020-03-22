using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards
{
    /// <summary>
    /// カードのリスト用
    /// </summary>
    public static class CardListGenerator
    {
        private readonly static Card[] cards = {

            Card.Joker, Card.ExtraJoker,

            Card.AceOfSpades, Card.TwoOfSpades, Card.ThreeOfSpades, Card.FourOfSpades, Card.FiveOfSpades,
            Card.SixOfSpades, Card.SevenOfSpades, Card.EightOfSpades, Card.NineOfSpades,Card.TenOfSpades,
            Card.JackOfSpades, Card.QueenOfSpades, Card.KingOfSpades,

            Card.AceOfHearts, Card.TwoOfHearts, Card.ThreeOfHearts, Card.FourOfHearts, Card.FiveOfHearts,
            Card.SixOfHearts, Card.SevenOfHearts, Card.EightOfHearts, Card.NineOfHearts, Card.TenOfHearts,
            Card.JackOfHearts, Card.QueenOfHearts, Card.KingOfHearts,

            Card.AceOfDiamonds, Card.TwoOfDiamonds, Card.ThreeOfDiamonds, Card.FourOfDiamonds, Card.FiveOfDiamonds,
            Card.SixOfDiamonds, Card.SevenOfDiamonds, Card.EightOfDiamonds, Card.NineOfDiamonds, Card.TenOfDiamonds,
            Card.JackOfDiamonds, Card.QueenOfDiamonds, Card.KingOfDiamonds,

            Card.AceOfClubs, Card.TwoOfClubs, Card.ThreeOfClubs, Card.FourOfClubs, Card.FiveOfClubs,
            Card.SixOfClubs, Card.SevenOfClubs, Card.EightOfClubs, Card.NineOfClubs, Card.TenOfClubs,
            Card.JackOfClubs, Card.QueenOfClubs, Card.KingOfClubs

            };



        /// <summary>
        /// ジョーカーを含まないカードのリストをCardId順に生成。
        /// </summary>
        /// <returns>カードのリスト</returns>
        public static IList<Card> GenerateNoJokerCardList()
        {
            var cardList = GenerateSingleJokerCardList();

            cardList.Remove(Card.Joker);

            return cardList;
        }


        /// <summary>
        /// ジョーカーを一枚含んだカードのリストをCardId順に生成。
        /// </summary>
        /// <returns>カードのリスト</returns>
        public static IList<Card> GenerateSingleJokerCardList()
        {
            var cardList = GenerateDoubleJokerCardList();

            cardList.Remove(Card.ExtraJoker);

            return cardList;
        }

        /// <summary>
        /// ジョーカーを二枚含んだカードのリストをCardId順に生成。
        /// </summary>
        /// <returns>カードのリスト</returns>
        public static IList<Card> GenerateDoubleJokerCardList()
        {

            return cards.ToList();
        }

        /// <summary>
        /// ジョーカーを含まないカードのリストをランダムに並び替えてに生成。
        /// </summary>
        /// <returns>カードのリスト</returns>
        public static IList<Card> GenerateNoJokerShuffledCardList()
        {
            return GenerateNoJokerCardList().OrderBy(e => Guid.NewGuid()).ToList<Card>();
        }

        /// <summary>
        /// ジョーカーを一枚含んだカードのリストをランダムに並び替えてに生成。
        /// </summary>
        /// <returns>カードのリスト</returns>
        public static IList<Card> GenerateSingleJokerShuffledCardList()
        {
            return GenerateSingleJokerCardList().OrderBy(e => Guid.NewGuid()).ToList<Card>();
        }

        /// <summary>
        /// ジョーカーを二枚含んだカードのリストをランダムに並び替えてに生成。
        /// </summary>
        /// <returns>カードのリスト</returns>
        public static IList<Card> GenerateDoubleJokerShuffledCardList()
        {
            return GenerateDoubleJokerCardList().OrderBy(e => Guid.NewGuid()).ToList<Card>();
        }
    }
}
