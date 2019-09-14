using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Net.Sh_Lab.PlayingCards.Golf
{
    public class Golf : ReadOnlyDictionary<Card, IPosition>
    {

        /// <summary>
        /// AとK(13)の間で行き来できるか。
        /// </summary>
        public bool CanLoop
        {
            get;
            private set;
        }


        /// <summary>
        /// 一番上の手札の位置
        /// </summary>
        private Hand TopHand => Dictionary.Values.OfType<Hand>().OrderByDescending(e => e.Number).First();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary">初期配置</param>
        /// <param name="canLoop">AceとKingをつなげるか？</param>
        public Golf(IDictionary<Card, IPosition> dictionary, bool canLoop) : base(dictionary)
        {
            CanLoop = canLoop;
        }

        /// <summary>
        /// カードが手札に移動可能か？
        /// </summary>
        /// <param name="card">移動するカード</param>
        /// <returns>移動可否</returns>
        public bool CanMoveToHand(Card card)
        {
            // 存在しないカードは移動不可能
            if (!ContainsKey(card))
            {
                return false;
            }

            var position = Dictionary[card];

            // 山札の一番上なら移動可能
            if (position is Deck deck &&
                deck.Number ==
                    Dictionary.Values.OfType<Deck>().OrderByDescending(e => e.Number).First().Number)
            {
                return true;
            }

            // 場札じゃないと移動できない。
            if (!(position is Field field))
            {
                return false;
            }

            // 場札の一番上じゃないと移動できない。
            if (field.Number != Dictionary.Values.OfType<Field>().
            Where(e => e.Lane == field.Lane).OrderByDescending(e => e.Number).First().Number)
            {
                return false;
            }

            // 手札の一番上のカード取得。
            var topHandCard = Dictionary.Where(e => e.Value is Hand hand && hand.Equals(TopHand)).Select(e => e.Key).First();

            // どちらかがジョーカーなら移動可能。
            if (card.IsJoker || topHandCard.IsJoker)
            {
                return true;
            }

            // 差が1なら移動可能
            if (Math.Abs(card.Rank - topHandCard.Rank) == 1)
            {
                return true;
            }

            // AとK(13)がつながらないルールの場合は移動不可。
            if (!CanLoop)
            {
                return false;
            }

            // AとK(13)の判定
            if (card.Rank == Rank.Ace
                && topHandCard.Rank == Rank.King)
            {
                return true;
            }
            else if (card.Rank == Rank.King
               && topHandCard.Rank == Rank.Ace)
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// 指定したカードがCanMove可能なら手札の一番上に移動。
        /// </summary>
        /// <param name="card"></param>
        public void MoveToHand(Card card)
        {
            if (!CanMoveToHand(card))
            {
                throw new InvalidOperationException();
            }

            // 指定したカードを手札の一番上に置く。
            Dictionary[card] = new Hand(TopHand.Number + 1);

        }

    }
}
