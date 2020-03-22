using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Net.Sh_Lab.PlayingCards
{
    public static class CardExtensions
    {
        /// <summary>
        /// カード辞書
        /// スーツとランクのタプルからカードの実体を取得する。
        /// ※ジョーカーは除く
        /// </summary>
        public static readonly IReadOnlyDictionary<(Suit, Rank), Card> CardDictionary = new Dictionary<(Suit, Rank), Card>()
        {
            { (Suit.Spades, Rank.Ace), Card.AceOfSpades},
            { (Suit.Spades, Rank.Two), Card.TwoOfSpades},
            { (Suit.Spades, Rank.Three), Card.ThreeOfSpades},
            { (Suit.Spades, Rank.Four), Card.FourOfSpades},
            { (Suit.Spades, Rank.Five), Card.FiveOfSpades},
            { (Suit.Spades, Rank.Six), Card.SixOfSpades},
            { (Suit.Spades, Rank.Seven), Card.SevenOfSpades},
            { (Suit.Spades, Rank.Eight), Card.EightOfSpades},
            { (Suit.Spades, Rank.Nine), Card.NineOfSpades},
            { (Suit.Spades, Rank.Ten), Card.TenOfSpades},
            { (Suit.Spades, Rank.Jack), Card.JackOfSpades},
            { (Suit.Spades, Rank.Queen), Card.QueenOfSpades},
            { (Suit.Spades, Rank.King), Card.KingOfSpades},

            { (Suit.Hearts, Rank.Ace), Card.AceOfHearts},
            { (Suit.Hearts, Rank.Two), Card.TwoOfHearts},
            { (Suit.Hearts, Rank.Three), Card.ThreeOfHearts},
            { (Suit.Hearts, Rank.Four), Card.FourOfHearts},
            { (Suit.Hearts, Rank.Five), Card.FiveOfHearts},
            { (Suit.Hearts, Rank.Six), Card.SixOfHearts},
            { (Suit.Hearts, Rank.Seven), Card.SevenOfHearts},
            { (Suit.Hearts, Rank.Eight), Card.EightOfHearts},
            { (Suit.Hearts, Rank.Nine), Card.NineOfHearts},
            { (Suit.Hearts, Rank.Ten), Card.TenOfHearts},
            { (Suit.Hearts, Rank.Jack), Card.JackOfHearts},
            { (Suit.Hearts, Rank.Queen), Card.QueenOfHearts},
            { (Suit.Hearts, Rank.King), Card.KingOfHearts},

            { (Suit.Diamonds, Rank.Ace), Card.AceOfDiamonds},
            { (Suit.Diamonds, Rank.Two), Card.TwoOfDiamonds},
            { (Suit.Diamonds, Rank.Three), Card.ThreeOfDiamonds},
            { (Suit.Diamonds, Rank.Four), Card.FourOfDiamonds},
            { (Suit.Diamonds, Rank.Five), Card.FiveOfDiamonds},
            { (Suit.Diamonds, Rank.Six), Card.SixOfDiamonds},
            { (Suit.Diamonds, Rank.Seven), Card.SevenOfDiamonds},
            { (Suit.Diamonds, Rank.Eight), Card.EightOfDiamonds},
            { (Suit.Diamonds, Rank.Nine), Card.NineOfDiamonds},
            { (Suit.Diamonds, Rank.Ten), Card.TenOfDiamonds},
            { (Suit.Diamonds, Rank.Jack), Card.JackOfDiamonds},
            { (Suit.Diamonds, Rank.Queen), Card.QueenOfDiamonds},
            { (Suit.Diamonds, Rank.King), Card.KingOfDiamonds},

            { (Suit.Clubs, Rank.Ace), Card.AceOfClubs},
            { (Suit.Clubs, Rank.Two), Card.TwoOfClubs},
            { (Suit.Clubs, Rank.Three), Card.ThreeOfClubs},
            { (Suit.Clubs, Rank.Four), Card.FourOfClubs},
            { (Suit.Clubs, Rank.Five), Card.FiveOfClubs},
            { (Suit.Clubs, Rank.Six), Card.SixOfClubs},
            { (Suit.Clubs, Rank.Seven), Card.SevenOfClubs},
            { (Suit.Clubs, Rank.Eight), Card.EightOfClubs},
            { (Suit.Clubs, Rank.Nine), Card.NineOfClubs},
            { (Suit.Clubs, Rank.Ten), Card.TenOfClubs},
            { (Suit.Clubs, Rank.Jack), Card.JackOfClubs},
            { (Suit.Clubs, Rank.Queen), Card.QueenOfClubs},
            { (Suit.Clubs, Rank.King), Card.KingOfClubs},

        };

        /// <summary>
        /// このカードの柄が同じでランクが一つ上のカードを取得します。
        /// </summary>
        /// <param name="card">対象のカード</param>
        /// <param name="canLoop">AceとKingをつなげるか</param>
        /// <returns></returns>
        public static Card? Up(this Card card, bool canLoop = false)
        {
            if (card.IsJoker)
            {
                return null;
            }

            var nextRank = card.Rank.Up(canLoop);

            if(nextRank.HasValue)
            {
                return CardDictionary[(card.Suit, nextRank.Value)];
            }

            return null;
        }

        /// <summary>
        /// このカードの柄が同じでランクが一つ下のカードを取得します。
        /// </summary>
        /// <param name="card">対象のカード</param>
        /// <param name="canLoop">AceとKingをつなげるか</param>
        /// <returns></returns>
        public static Card? Down(this Card card, bool canLoop = false)
        {
            if (card.IsJoker)
            {
                return null;
            }

            var nextRank = card.Rank.Down(canLoop);

            if (nextRank.HasValue)
            {
                return CardDictionary[(card.Suit, nextRank.Value)];
            }

            return null;
        }
    }
}
